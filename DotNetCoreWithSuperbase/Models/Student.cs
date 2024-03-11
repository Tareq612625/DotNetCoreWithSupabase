using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWithSuperbase.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string RegId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string MothersName { get; set; }
        public string Image { get; set; }
    }
}
