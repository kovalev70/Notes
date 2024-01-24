﻿namespace Notes.Identity.Models
{
    using Microsoft.AspNetCore.Identity;

    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
