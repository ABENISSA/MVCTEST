using System;
using System.Collections.Generic;

#nullable disable

namespace Login.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MgtId { get; set; }

        public virtual Management Mgt { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
