using TaskManagementAPI.Entities;

namespace TaskManagementAPI.Interface
{
    public interface IEmployee
    {
        Task<List<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> UpdateEmployee(Employee employee);

        Task<Employee> DeleteEmployee(int id);
    }
}
