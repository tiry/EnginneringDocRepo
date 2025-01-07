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

/// <summary>
/// Get all employees
/// </summary>
/// <remarks>
/// 
/// Sample request:
/// Get: /api/Employees
/// 
/// ** This method will return all the employees present under EmployeeList if records exist under the list.
/// 
/// Sample Input:
/// 
/// EmployeeDB List Info:
/// 
///      { Id = 1, Name = "John", Department = "IT", Email = "john@hyland.com" },
///      { Id = 2, Name = "Jane", Department = "HR", Email = "jane@hyland.com" }
///         
///     
/// Sample Response (Output):    
/// 
/// Response Code: 200
/// 
/// Response Body:
/// 
/// [
///     {
///         "id": 1,
///         "name": "John",
///         "department": "IT",
///         "email": "john@hyland.com"
///     },
///     {
///         "id": 2,
///         "name": "Jane",
///         "department": "HR",
///         "email": "jane@hyland.com"
///     }
/// ] 
/// 
/// ****************************************************************************************
/// /// Sample request:
/// Get: /api/Employees
/// 
/// ** If no records are present under EmployeeList, it will return 404 Not Found.
/// 
/// Sample Input:
/// 
/// EmployeeDb List Info: Null
/// 
/// Sample Response (Output):
/// 
/// Status Code: 404 
/// 
/// Response Body: 
/// 
/// No Record Found
/// 
/// </remarks>
///<returns>200 OK with the employees records</returns>
/// <returns>404 Not Found list is empty</returns>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]    
        public IActionResult GetEmployees()
        {
            return Ok(_crudActions.GetEmployees());
        }

        /// <summary>
/// Get an employee by id
/// </summary>
/// /// <remarks>
/// ** This method will return an employee if searched id is present under EmployeeList 
///  
/// Sample request:
///
/// Get: /api/Employees/1
/// 
/// Sample Input:
/// 
/// EmployeeDB List Info:
/// 
///      { Id = 1, Name = "John", Department = "IT", Email = "john@hyland.com" },
///      { Id = 2, Name = "Jane", Department = "HR", Email = "jane@hyland.com" }
///     
/// Sample Response (Output):    
///  
/// Response Code: 200
/// 
/// Response Body:
///     {
///          "id": 1,
///           "name": "John",
///                 "department": "IT",
///                  "email": "john@hyland.com"
///      }
///      
/// ****************************************************************************************
/// 
/// ** If the searched id is not present under EmployeeList, it will return 404 Not Found.
///      
///   Sample request:
///   
///   Get: /api/Employees/123456
/// 
///  Sample Response (Output):
/// 
/// Status Code: 404 
/// 
/// Response Body: 
/// 
/// No Record Found For The Searched Id
/// 
/// </remarks>
/// <param name="id">The id of the employee</param>
/// <returns>200 OK with the employee data</returns>
/// <returns>404 Not Found if the employee is not found</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
