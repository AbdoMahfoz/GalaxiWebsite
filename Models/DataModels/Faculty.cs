using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DataModels
{
    public class Faculty : BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}
