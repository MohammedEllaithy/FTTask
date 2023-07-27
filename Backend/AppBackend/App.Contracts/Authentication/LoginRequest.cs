using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Contracts.Authentication
{
    public record LoginRequest
  (
      [Required(ErrorMessage = "Email is required")]
      string Email,
      [Required(ErrorMessage = "Password is required")]
      string Password
   );
}
