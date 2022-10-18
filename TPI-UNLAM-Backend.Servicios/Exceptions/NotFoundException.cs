using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPI_UNLAM_Backend.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("") { }
        public NotFoundException(string message) : base(message) { }
    }
}
