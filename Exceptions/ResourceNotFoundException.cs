using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalExceptionHandling.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base() { }

        public ResourceNotFoundException(string message) : base(message) { }

        public ResourceNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class ProductNotFoundException : ResourceNotFoundException
    {
        public ProductNotFoundException() : base("Relevant product resource was not found") { }

        public ProductNotFoundException(string message) : base(message) { }

    }
}