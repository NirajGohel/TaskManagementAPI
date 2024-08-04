using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Entities;
using TaskManagementAPI.Interface;
using BC = BCrypt.Net.BCrypt;

namespace TaskManagementAPI.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }
        
        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            
            if(employee == null)
            {
                return new Employee();
            }

            return employee;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            string hashPassword = BC.HashPassword(employee.Password);
            employee.Password = hashPassword;

            var res = _context.Employees.AddAsync(employee);
            if (res.IsCompleted)
            {                
                await _context.SaveChangesAsync();
            }

            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var dbEmployee = await _context.Employees.FindAsync(updatedEmployee.Id);

            if (dbEmployee == null)
            {
                return new Employee();
            }

            dbEmployee.FirstName = updatedEmployee.FirstName;
            dbEmployee.LastName = updatedEmployee.LastName;            
            dbEmployee.Position = updatedEmployee.Position;
            dbEmployee.ManagerId = updatedEmployee.ManagerId;
            dbEmployee.TeamId = updatedEmployee.TeamId;
            dbEmployee.IsAdmin = updatedEmployee.IsAdmin;

            await _context.SaveChangesAsync();
            return dbEmployee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var dbEmployee = await _context.Employees.FindAsync(id);

            if (dbEmployee == null)
            {
                return new Employee();
            }

            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();

            return dbEmployee;
        }
    }
}
