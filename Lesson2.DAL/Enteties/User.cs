using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.DAL.Enteties
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
