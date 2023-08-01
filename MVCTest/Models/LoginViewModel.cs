﻿using System.ComponentModel.DataAnnotations;

namespace MVCTest.Models
{
    public class LoginViewModel
    {
        [Key]
        public Guid LoginId { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
