using Postgrest.Models;
using System.ComponentModel.DataAnnotations;

using Postgrest.Models;
namespace DotNetCoreWithSuperbase.Models
{
    public class Student:BaseModel
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
