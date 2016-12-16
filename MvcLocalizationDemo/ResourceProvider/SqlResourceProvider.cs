using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcLocalizationDemo.Data;
using MvcLocalizationDemo.Models;

namespace MvcLocalizationDemo.ResourceProvider
{
    public class SqlResourceProvider:BaseResourceProvider
    {
        private readonly ApplicationDbContext _db;

        public SqlResourceProvider(ApplicationDbContext db)
        {
            _db = db;
        }

        protected override IEnumerable<ResourceEntry> ReadResources()
        {
            return _db.ResourceEntry.Select(r=>new ResourceEntry
            {
                Culture = r.Culture,
                Name = r.Name,
                Value = r.Value
            }).ToList();
        }

        protected override ResourceEntry ReadResource(string name, string culture)
        {
            return _db.ResourceEntry.FirstOrDefault(r => r.Name == name && r.Culture == culture);
        }
    }
}