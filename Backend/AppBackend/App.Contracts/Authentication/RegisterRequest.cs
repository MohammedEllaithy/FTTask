using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Contracts.Authentication
{
    public record RegisterRequest
    (
        string Name,
        string UserName,
        string Email,
        string Password
     );
}
