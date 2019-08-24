using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.DataModels
{
    public class CheckIn : BaseModel
    {
        [Required]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public float TotalMoneySpent { get; set; }
    }
}
