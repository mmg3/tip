using TIP.Extensions;

namespace TIP.Dtos
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }


        [NoMap]
        public virtual ICollection<DepartmentEmployeeDTO> DepartmentEmployees { get; set; }
    }
}
