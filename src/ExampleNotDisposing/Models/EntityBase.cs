using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleNotDisposing.Models
{
    public class EntityBase
    {
		[Required]
		public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

		[ConcurrencyCheck]
		public DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;
	}
}
