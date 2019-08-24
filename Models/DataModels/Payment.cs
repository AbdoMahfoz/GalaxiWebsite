using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DataModels
{
    public class Payment : BaseModel
    {
        [Required]
        public int CheckInId { get; set; }
        public virtual CheckIn CheckIn { get; set; }
        [Required]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int Amount { get; set; }
        public float PaidPrice { get; set; }
    }
}
