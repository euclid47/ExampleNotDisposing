using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleNotDisposing.Models
{
    public class Employee : EntityBase
    {
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		public long CompanyId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		[ForeignKey("CompanyId")]
		public virtual Company Company { get; set; }
	}
}
