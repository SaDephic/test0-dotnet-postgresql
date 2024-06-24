using Microsoft.AspNetCore.Mvc.RazorPages;

namespace test0_dotnet_postgresql.Pages
{
    public class SumModel : PageModel
    {
        private readonly DataContext _context;
        public SumModel(DataContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get; set; }
        public IList<Department> Department { get; set; }

        public List<CutSalary> with_result = new List<CutSalary>();
        public List<CutSalary> without_result = new List<CutSalary>();
        public async Task OnGet()
        {
            Employees = _context.employee.ToList();
            Department = _context.department.ToList();
            //with chief
            var catdepart = Employees.ToList().GroupBy(x => x.Department_id);
            foreach (var d_id in catdepart)
            {
                var summ = d_id.Sum(x => x.Salary * 12);
                with_result.Add(new CutSalary
                {
                    Id = with_result.Count + 1,
                    Department_name = Department.ToList().Find(x => x.Id == d_id.Key).Name,
                    Salary = summ / 12
                });
            }

            //without_chief
            List<Employee> listemployee = Employees.ToList();
            //get all chef id
            var chiefs = listemployee.GroupBy(x => x.Chief_id);
            //remove all chief id
            foreach (var d_id in chiefs)
            {
                if (d_id.Key != null)
                    listemployee.RemoveAll(s => s.Id == d_id.Key);
            }

            catdepart = listemployee.ToList().GroupBy(x => x.Department_id);
            //do departments
            foreach (var d_id in catdepart)
            {
                var summ = d_id.Sum(x => x.Salary * 12);
                without_result.Add(new CutSalary
                {
                    Id = without_result.Count + 1,
                    Department_name = _context.department.ToList().Find(x => x.Id == d_id.Key).Name,
                    Salary = summ / 12
                });
            }
        }
    }
}