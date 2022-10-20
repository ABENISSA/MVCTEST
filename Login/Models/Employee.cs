using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Login.Models
{
    public partial class Employee
    {
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
        [DataType(dataType:DataType.Date)]
        public DateTime StartDate { get; set; }
        public int? DepId { get; set; }

        public virtual Department Dep { get; set; }
    }
}
