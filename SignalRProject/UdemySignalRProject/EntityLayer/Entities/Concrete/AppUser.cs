using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        [StringLength(50)]
        public string NameSurname { get; set; }
		[StringLength(30)]
		public string Status { get; set; }
		[StringLength(200)]
		public string userImg { get; set; }
	}
}
