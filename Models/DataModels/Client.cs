﻿using System.ComponentModel.DataAnnotations;

namespace Models.DataModels
{
    public class Client : BaseModel
    {
        [Required]
        public string Phonenumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Email { get; set; }
        public int Year { get; set; }
    }
}
