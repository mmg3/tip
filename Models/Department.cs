﻿using System;
using System.Collections.Generic;
using TIP.Extensions;

namespace TIP.Models
{
    public partial class Department
    {
        public Department()
        {
            DepartmentEmployees = new HashSet<DepartmentEmployee>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int IdEnterprise { get; set; }


        [NoMap]
        public virtual Enterprise EnterpriseNav { get; set; }

        [NoMap]
        public virtual ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }
    }
}
