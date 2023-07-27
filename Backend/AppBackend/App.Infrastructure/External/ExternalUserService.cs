using App.Application.External;
using App.Domain.Entities;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.External
{
    
        public class ExternalUserService :IHostedService
        {
            private readonly ApplicationDbContext _dbContext;

            public ExternalUserService(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

        // public async Task SeedUserDataAsync()
        //{
        //    if (!_dbContext.Users.Any())
        //    {
        //        using var httpClient = new HttpClient();
        //        var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var content = await response.Content.ReadAsStringAsync();
        //            var users = JsonConvert.DeserializeObject<List<ExternalUser>>(content);

        //            foreach (var user in users)
        //            {
        //            var newUser = new User
        //            {
        //                Name = user.Name,
        //                UserName = user.Username,
        //                Email = user.Email,
        //                // Map other properties as needed to match the User entity
        //                Address = new ExternalAddress
        //                {
        //                    Street = user.Address?.Street,
        //                    Suite = user.Address?.Suite,
        //                    City = user.Address?.City,
        //                    Zipcode = user.Address?.Zipcode,
        //                    Geo = new ExternalGeo
        //                    {
        //                        Lat = user.Address?.Geo?.Lat,
        //                        Lng = user.Address?.Geo?.Lng
        //                    }
        //                },
        //                Phone = user.Phone,
        //                Website = user.Website,
        //                Company = new ExternalCompany
        //                {
        //                   // Id  = user.Company?.Id,
        //                    Name = user.Company?.Name,
        //                    CatchPhrase = user.Company?.CatchPhrase,
        //                    Bs = user.Company?.Bs
        //                },
        //                Password = "YourDefaultPassword" // Set a default password for the user if required
        //            };

        //            _dbContext.Users.Add(newUser);
        //            }

        //            await _dbContext.SaveChangesAsync();
        //        }
        //    }
        //}
        public async Task SeedUserDataAsync()
        {
            var httpClient = new HttpClient();
            var usersResponse = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            var users = await usersResponse.Content.ReadAsStringAsync();
            var usersList = JsonConvert.DeserializeObject<List<User>>(users);

            _dbContext.Users.AddRange(usersList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
          await  SeedUserDataAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
    }

