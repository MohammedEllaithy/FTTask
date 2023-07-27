using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Common.Interfaces.Presistence
{
    public interface IUserRepository
    {
      Task AddAsync(User user);
      Task<User?> GetUserByEmail(string email);
    }
}
