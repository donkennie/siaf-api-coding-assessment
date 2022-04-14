using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIAF_API.Models
{
    public class Products
    {

        public int Id { get; set; }

        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0!")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Slug => ProductName.Replace(' ', '-');

        public Categories Category  { get; set; }



    }
}
