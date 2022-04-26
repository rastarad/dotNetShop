using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ModelsDto
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        [Range(1,10000)]
        public int Price { get; set; }
    }
}
