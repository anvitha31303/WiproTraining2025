using Microsoft.EntityFrameworkCore;
using repo_demo.Models;

namespace RepositoryWithMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        // ✅ Get all employees
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        // ✅ Get employee by Id
        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.Find(employeeId);
        }

        // ✅ Add new employee
        public int AddEmployee(Employee employeeEntity)
        {
            if (employeeEntity != null)
            {
                _context.Employees.Add(employeeEntity);
                _context.SaveChanges();
                return employeeEntity.EmployeeId;
            }
            return -1;
        }

        // ✅ Update employee
        public int UpdateEmployee(Employee employeeEntity)
        {
            if (employeeEntity != null)
            {
                _context.Entry(employeeEntity).State = EntityState.Modified;
                _context.SaveChanges();
                return employeeEntity.EmployeeId;
            }
            return -1;
        }

        // ✅ Delete employee
        public void DelectEmployee(int employeeId)
        {
            var employeeEntity = _context.Employees.Find(employeeId);
            if (employeeEntity != null)
            {
                _context.Employees.Remove(employeeEntity);
                _context.SaveChanges();
            }
        }

        // ✅ Dispose Pattern
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
