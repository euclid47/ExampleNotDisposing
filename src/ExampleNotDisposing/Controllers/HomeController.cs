using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleNotDisposing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleNotDisposing.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
	        using (var ctx = new CompanyDbContext())
	        {
		        var results = await ctx.Companies.Include(x => x.Employees).ToListAsync();
				return View(results);
			}
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

	    public async Task<IActionResult> Seed()
	    {
		    using (var ctx = new CompanyDbContext())
		    {
			    var company = new Company
			    {
				    CompanyName = "Company 1",
					Ein = "123456789",
					Employees = new List<Employee>
					{
						new Employee
						{
							FirstName = "John",
							LastName = "Doe"
						},
						new Employee
						{
							FirstName = "Jane",
							LastName = "Doe"
						}
					}
			    };

			    ctx.Companies.Add(company);

			    await ctx.SaveChangesAsync();
		    }

		    return View();
	    }
    }
}
