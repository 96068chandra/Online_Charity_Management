﻿using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Role
    {
        public int RoleId { get; set; }
      
        public required string RoleName { get; set; }
    }
}
