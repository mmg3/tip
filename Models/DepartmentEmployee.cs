using System;
using System.Collections.Generic;
using TIP.Extensions;

namespace TIP.Models
{
    public partial class DepartmentEmployee
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
        public int IdDepartment { get; set; }
        public int IdEmployee { get; set; }


        [NoMap]
        public virtual Department DepartmentNav{ get; set; }

        [NoMap]
        public virtual Employee EmployeeNav { get; set; }
    }
}
