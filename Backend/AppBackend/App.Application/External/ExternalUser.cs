using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.External
{
    public class ExternalUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ExternalAddress Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public ExternalCompany Company { get; set; }
    }
}
