using TIP.Extensions;

namespace TIP.Dtos
{
    public class EnterpriseDTO
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }


        [NoMap]
        public virtual ICollection<DepartmentDTO> Departments{ get; set; }
    }
}
