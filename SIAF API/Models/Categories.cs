using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIAF_API.Models
{
    public class Categories
    {
        [Column("CategoriesId")]
        public int Id { get; set; }

        public string CategoryName { get; set; }

       // public ICollection<Products> Products { get; set; }
    }
}
