namespace WebApplication1.Models.ViewModels
{
    public class EmployeesViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
