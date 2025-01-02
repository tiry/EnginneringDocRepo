using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNetOpenAPI.Repositories;
using Microsoft.AspNetCore.Cors;
namespace DotNetOpenAPI.Controllers
{
    /// <summary>
    /// This controller is responsible for handling requests related to employees CRUD operations.
    /// Will provide the necessary http response codes and data.
    /// The controller will interact with the ICURDActions interface to get the data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]   
    //add cors policy
    [EnableCors("AllowAll")]
    public class EmployeesController : ControllerBase
    {
        private readonly ICRUDActions _crudActions;

        /// <summary>
        /// This is the constructor of the EmployeesController class.
        /// </summary>
        /// <param name="crudActions"></param>

        public EmployeesController(ICRUDActions crudActions)
        {
            _crudActions = crudActions;
        }

        ///<summary>
        ///License Information: All rights reserved by Kaushik Natua
        /// </summary>
        
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <remarks>
        /// This method will return all the employees present under EmployeeList        
        /// 
        /// You can do futher modification of the code to check for an empty list and return 404 Not Found
        ///  
        /// 
        ///  
        /// Sample request:
        ///
        ///     Get: /api/Employees
        ///     
        /// Sample Response:    
        /// [
        ///     {
        ///          "id": 1,
        ///           "name": "John",
        ///                 "department": "IT",
        ///                  "email": "john@hyland.com"
        ///              },
        ///      {
        ///         "id": 2,
        ///         "name": "Jane",
        ///         "department": "HR",
        ///         "email": "jane@hyland.com"
        ///
        /// }
        /// ]
        /// </remarks>
        /// <returns>200 OK with the list of employees</returns>
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_crudActions.GetEmployees());
        }

        /// <summary>
        /// Get an employee by id
        /// </summary>
        /// /// <remarks>
        /// This method will return an employee if searched id is present under EmployeeList        
        /// 
        /// If the employee is not found, it will return 404 Not Found
        ///  
        /// 
        ///  
        /// Sample request:
        ///
        /// Get: /api/Employees/1
        ///     
        /// Sample Response:    
        ///  
        ///     {
        ///          "id": 1,
        ///           "name": "John",
        ///                 "department": "IT",
        ///                  "email": "john@hyland.com"
        ///      }
        ///      
        ///   Sample request:
        ///   
        ///   Get: /api/Employees/123456
        /// 
        ///   Sample Response:
        ///   
        ///   404 Not Found
        /// 
        /// </remarks>
        /// <param name="id">The id of the employee</param>
        /// <returns>200 OK with the employee data</returns>
        /// <returns>404 Not Found if the employee is not found</returns>
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _crudActions.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
