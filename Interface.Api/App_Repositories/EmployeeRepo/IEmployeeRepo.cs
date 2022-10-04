using Interface.Api.Models;

namespace Interface.Api.App_Repositories.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        Task<Employee> CreateEmployee(Employee employee);   
        void UpdateEmployee(Employee updateEmp);
        Task<Employee> DeleteEmployee(Guid Id);     
        Task<List<Employee>>  GetAllEmployeeS();
        Task<Employee> GetEmployeeById(Guid Id);    
    }
}
