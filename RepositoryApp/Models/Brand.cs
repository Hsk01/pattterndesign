using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RepositoryApp.Models
{
    public class Brand
    {
        [Key]
        public Guid BrandId { get; set; }
        public string Name { get; set; }
    }
}
