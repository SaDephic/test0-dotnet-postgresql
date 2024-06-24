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
        public List<CutSalary> with_result = new List<CutSalary>();
        public List<CutSalary> without_result = new List<CutSalary>();
        public async Task OnGet()
        {

            var catdepart = _context.employee.ToList().GroupBy(x => x.Department_id);
            foreach (var d_id in catdepart)
            {
                var summ = d_id.Sum(x => x.Salary);
                with_result.Add(new CutSalary
                {
                    Id = with_result.Count + 1,
                    Department_name = _context.department.ToList().Find(x => x.Id == d_id.Key).Name,
                    Salary = summ / 12
                });
            }

            foreach (var d_id in catdepart)
            {
                List<Employee> nulled = d_id.ToList().FindAll(x => x.Chief_id.Equals(0)).ToList();
                while(nulled.Count > 0)
                {
                    d_id.ToList().Remove(nulled.FirstOrDefault()); 
                    nulled.RemoveAt(0); 
                }

                var summ = d_id.Sum(x => x.Salary);
                without_result.Add(new CutSalary
                {
                    Id = without_result.Count + 1,
                    Department_name = _context.department.ToList().Find(x => x.Id == d_id.Key).Name,
                    Salary = summ /12
                });
            }
        }
    }
}