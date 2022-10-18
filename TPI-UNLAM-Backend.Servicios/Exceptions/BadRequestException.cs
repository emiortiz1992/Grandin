using System;

namespace TPI_UNLAM_Backend.Exceptions
{
    public class BadRequestException: Exception
    {
        public BadRequestException() : base("") { }
        public BadRequestException(string message) : base(message) { }
    }
}
