using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web.Compilation;
using MvcLocalizationDemo.Data;
using MvcLocalizationDemo.DTO;
using MvcLocalizationDemo.Models;

namespace MvcLocalizationDemo.ResourceProvider
{
    public class SqlResourceProvider : IResourceProvider
    {
        private static Dictionary<string, ResourceEntryDTO> _resources;
        private static readonly object LockResources = new object();
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private bool Cache { get; set; } = true;

        public object GetObject(string resourceKey, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(resourceKey) || string.IsNullOrWhiteSpace(resourceKey))
                throw new ArgumentNullException(nameof(resourceKey));
            if (culture == null)
                return null;
            if (_resources != null)
                return Cache
                    ? _resources[$"{resourceKey}.{culture}"].Value
                    : ReadResource(resourceKey, culture).Value;
            lock (LockResources)
            {
                var dictionary = new Dictionary<string, ResourceEntryDTO>();
                foreach (var resource in ReadResources())
                    dictionary.Add(string.Format("{0}.{1}", resource.Name, resource.Culture), resource);
                _resources = dictionary;
            }
            return Cache
                ? _resources[string.Format("{0}.{1}", resourceKey, culture)].Value
                : ReadResource(resourceKey, culture).Value;
        }

        public IResourceReader ResourceReader
        {
            get { throw new NotImplementedException(); }
        }

        private IEnumerable<ResourceEntryDTO> ReadResources()
        {
            return _db.ResourceEntry.Select(r => new ResourceEntryDTO
            {
                Culture = r.Culture,
                Name = r.Name,
                Value = r.Value
            }).ToList();
        }

        private ResourceEntry ReadResource(string name, CultureInfo culture)
        {
            var cultureName = culture.Name;
            return _db.ResourceEntry.FirstOrDefault(r => r.Name == name && r.Culture == cultureName);
        }
    }
}