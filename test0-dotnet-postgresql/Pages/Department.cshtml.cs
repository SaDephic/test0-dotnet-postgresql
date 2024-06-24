using Microsoft.AspNetCore.Mvc.RazorPages;

namespace test0_dotnet_postgresql.Pages
{
    public class DepartmentModel : PageModel
    {
        private readonly DataContext _context;

        public DepartmentModel(DataContext context)
        {
            _context = context;
        }
        public IList<Employee> Employees { get; set; }
        public IList<Department> Department { get; set; }

        public List<Department> result = new List<Department>();

        public async Task OnGet()
        {
            // !!! wrong without salary union
            /*var catdepart = _context.employee.ToList().GroupBy(x => x.Department_id);
            foreach (var d_id in catdepart)
            {
                result.AddRange(_context.department.ToList().Where(x => x.Id == d_id.ToList().MaxBy(t => t.Salary).Department_id).ToList());
            }*/

            Employees = _context.employee.ToList();
            Department = _context.department.ToList();

            result = Department.Where(x => x.Id == Employees.MaxBy(t => t.Salary).Department_id).ToList();

            /*Employee temp = new Employee();
            for (int i = 0; i < Employees.Count; ++i)
            {
                if (Employees[i].Salary >= temp.Salary || temp.Salary == null)
                {
                    temp = Employees[i];
                }
            }

            for (int i = 0; i < Department.Count; ++i)
            {
                if (Department[i].Id == temp.Department_id)
                {
                    result.Add(Department[i]);
                    break;
                }
            }*/
        }
    }
}