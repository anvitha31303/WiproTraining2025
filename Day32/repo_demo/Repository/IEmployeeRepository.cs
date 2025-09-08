using System.Web;

// using rep_pattern_demo.Models;
using repo_demo.Models;

namespace RepositoryWithMVC.Repository
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int studentId);
        int AddEmployee(Employee EmployeeEntity);

        int UpdateEmployee(Employee EmployeeEntity);

        void DelectEmployee(int EmployeeId);
    }
}