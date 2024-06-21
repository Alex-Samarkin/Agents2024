using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Faker;

namespace AgentsLibrary1
{
    public class APerson
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = Faker.Name.FullName();
        public string Email { get; set; } = Faker.Internet.Email();
        public string Phone { get; set; } = Faker.Phone.Number();
        public string Address { get; set; } = Faker.Address.StreetAddress();
        public bool Gender { get; set; } = Faker.Boolean.Random();
    }
}
