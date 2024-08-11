﻿using System.ComponentModel.DataAnnotations;

namespace SalonSpaBookingSystem.DTO
{
    public class UserResponseDTO
    {        
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

    }
}
