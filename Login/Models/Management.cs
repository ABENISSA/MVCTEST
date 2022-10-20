using System;
using System.Collections.Generic;

#nullable disable

namespace Login.Models
{
    public partial class Management
    {
        public Management()
        {
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OrdererId { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
