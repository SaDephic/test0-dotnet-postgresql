using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace test0_dotnet_postgresql.Pages
{
    public class SalaryModel : PageModel
    {
        private readonly DataContext _context;

        public SalaryModel(DataContext context)
        {
            _context = context;
        }

        public IList<Employee> Employees { get; set; }

        public List<Employee> result = new List<Employee>();
        public async Task OnGet()
        {
            Employees = _context.employee.ToList();
            var catdepart = Employees.GroupBy(x => x.Department_id);
            foreach (var d_id in catdepart)
            {
                result.AddRange(d_id.ToList().OrderByDescending(x => x.Salary));
            }
            //result = result.OrderBy(pet => pet.Chief_id).ThenBy(pet => pet.Salary).ToList();
        }
    }
}