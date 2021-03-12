using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Models
{
    public  class Person : ICacheValue
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public int GetSize()
        {
            // Assuming each character is 2 bytes (Unicode formatting)
            return this.LastName.Length * 2 + this.FirstName.Length * 2;
        }
    }
}
