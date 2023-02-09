using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Entities
{
    [Table("TBL_STUDENT_DTL")]
    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public string schoolId { get; set; }

        public string grade { get; set; }
    }
}
