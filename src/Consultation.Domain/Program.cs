using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consultation.Domain
{
    public class Program
    {
        [Key]
        public int ProgramID { get; set; }
        
        public string  ProgramName { get; set; }

        public string Description { get; set; }

        //Program to department is many-to-one relationship

        [ForeignKey(nameof(DepartmentID))]
        public int  DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        
    }
}
