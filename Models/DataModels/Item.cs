using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DataModels
{
    public class Item : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public int Stock { get; set; }
    }
}
