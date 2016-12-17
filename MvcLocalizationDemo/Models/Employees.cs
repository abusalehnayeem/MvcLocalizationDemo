using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MvcLocalizationDemo.ResourceProvider;

namespace MvcLocalizationDemo.Models
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Name", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = "Name")]
        public string Name { get; set; }
        [MaxLength(15)]
        [Display(Name = "Title", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = "Name")]
        public string Title { get; set; }
        [MaxLength(20)]
        [Display(Name = "Department", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources),
                  ErrorMessageResourceName = "Name")]
        public string Department { get; set; }
    }
}