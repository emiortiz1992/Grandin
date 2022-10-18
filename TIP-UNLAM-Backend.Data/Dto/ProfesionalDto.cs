using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIP_UNLAM_Backend.Data.Dto
{
    public class ProfesionalDto
    {
        [Required]
        public int id { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
