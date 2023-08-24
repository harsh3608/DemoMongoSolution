﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GoByBus.Core.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string? PersonName { get; set; }

        public string? Gender { get; set; }

        public DateTime DOB { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone] 
        public double Phone { get; set; }

        public string? Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? UserType { get; set; } 

    }
}
