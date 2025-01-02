using DotNetOpenAPI.Models;
namespace DotNetOpenAPI.Repositories
{
    public interface ICRUDActions
    {
        public List<EmployeeDB> GetEmployees();
        public EmployeeDB? GetEmployee(int id);
    }
}
