using TIP.Extensions;

namespace TIP.Dtos
{
    public class DepartmentEmployeeDTO
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
        public virtual DepartmentDTO DepartmentNav{ get; set; }

        [NoMap]
        public virtual EmployeeDTO EmployeeNav { get; set; }
    }
}
