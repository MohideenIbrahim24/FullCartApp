﻿using System.ComponentModel.DataAnnotations;
using FullCart.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace FullCart.Domain.Entities.Identities;

public class AppUser : IdentityUser
{
    public string DisplayName {get;set;}
    public string UserEmail { get; set; }
    public string UserMobileNo { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool IsDeleted { get; set; }
    public Address Address { get; set; }
    
    // public IList<UserRole> Roles { get; set; } = new List<UserRole>();
}

