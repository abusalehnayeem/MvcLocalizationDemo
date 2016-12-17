using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcLocalizationDemo.Models
{
    public class ResourceEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }
        [MaxLength(150)]
        [Required]
        public string Value { get; set; }
        [MaxLength(5)]
        [Required]
        public string Culture { get; set; }
        public string Type { get; set; }
    }
}