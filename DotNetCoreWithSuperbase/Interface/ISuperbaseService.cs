using DotNetCoreWithSuperbase.Models;

namespace DotNetCoreWithSuperbase.Interface
{
    public interface ISuperbaseService
    {
        Task<List<Student>> GetStudentsAsync();
    }
}
