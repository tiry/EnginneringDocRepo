using DotNetOpenAPI.Models;

namespace DotNetOpenAPI.Repositories
{
    public class CRUDActions : ICRUDActions
    {
        public static List<EmployeeDB> employees = new List<EmployeeDB>()
        {
            new EmployeeDB() { Id = 1, Name = "John", Department = "IT", Email = "john@hyland.com" },
            new EmployeeDB() { Id = 2, Name = "Jane", Department = "HR", Email = "jane@hyland.com" }
        };           

        public EmployeeDB? GetEmployee(int id)
        {
            // Find the employee with the given id
            return employees.Find(e => e.Id == id);
        }

        public List<EmployeeDB> GetEmployees()
        {
            return employees;
        }
    }
}
