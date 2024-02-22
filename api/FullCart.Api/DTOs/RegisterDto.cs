using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullCart.Api.DTOs
{
    public class RegisterDto
    {
        public string DisplayName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}