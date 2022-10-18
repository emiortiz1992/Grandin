using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIP_UNLAM_Backend.Data.Dto
{
    public class LoginDto
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string contrasena { get; set; }
    }
}
