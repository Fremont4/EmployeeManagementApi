using Interface.Api.Data;
using Interface.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Interface.Api.App_Repositories.EmployeeRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly InterfaceDbContext _interfaceDbContext;
        public EmployeeRepo(InterfaceDbContext interfaceDbContext)
        {
            _interfaceDbContext = interfaceDbContext;
        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _interfaceDbContext.Employees.AddAsync(employee);
            _interfaceDbContext.SaveChanges();
            return employee;

        }

        public async Task<Employee> DeleteEmployee(Guid Id)
        {

                var employee = await _interfaceDbContext.Employees.FindAsync(Id);

                if (employee == null)
                {
                    return null;
                }
                _interfaceDbContext.Employees.Remove(employee);
                await _interfaceDbContext.SaveChangesAsync();
                return employee;
   

        }

        public  async Task<List<Employee>> GetAllEmployeeS()
        {
            List<Employee> emp = new List<Employee>();
            emp = (await _interfaceDbContext.Employees.ToListAsync());
            return emp;
        }

        public Task<Employee> GetEmployeeById(Guid Id)
        {
            throw new NotImplementedException();
        }


        public  void UpdateEmployee(Employee updateEmp)
        {
            var emmp =_interfaceDbContext.Entry(updateEmp).State = EntityState.Modified;
            _interfaceDbContext.SaveChanges();
                  
        }
    }
}


