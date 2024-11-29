using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracking.client
{
    internal class UserDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string password { get; set; }
    }
}
