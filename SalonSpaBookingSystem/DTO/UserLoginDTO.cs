﻿using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
