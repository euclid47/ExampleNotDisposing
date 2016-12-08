using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleNotDisposing.Models
{
    public class Company : EntityBase
    {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		public string CompanyName { get; set; }

		public string Ein { get; set; }

		public virtual ICollection<Employee> Employees { get; set; }
	}
}
