using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullCart.Api.DTOs
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}