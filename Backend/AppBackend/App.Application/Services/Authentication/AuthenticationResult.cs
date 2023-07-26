using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Authentication
{
    public record AuthenticationResult(
        Guid Id ,
        string Name,
        string Username,
        string Email ,
        string Token 
    );
}
