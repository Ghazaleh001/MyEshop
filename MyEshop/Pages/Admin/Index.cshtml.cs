using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using MyEshop.Data;

namespace MyEshop.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private MyEshopContext _context;
        public IndexModel(MyEshopContext context)
        {
            _context = context;
        }
        public IEnumerable<MyEshop.Models.Product> Products { get; set; }

        public void OnGet()
        {
            Products = _context.Products.Include(p => p.Item).ToList();
        }
        public void OnPost()
        {

        }
    }
}
