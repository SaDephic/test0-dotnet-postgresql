using Microsoft.AspNetCore.Mvc.RazorPages;

namespace test0_dotnet_postgresql.Pages
{
    public class ListModel : PageModel
    {
        private readonly DataContext _context;

        public ListModel(DataContext context)
        {
            _context = context;
        }
        public IList<Department> Department { get; set; }
        public IList<Employee> Employees { get; set; }

        public async Task OnGet()
        {
            Department = _context.department.ToList();
            Employees = _context.employee.ToList();
        }
    }
}