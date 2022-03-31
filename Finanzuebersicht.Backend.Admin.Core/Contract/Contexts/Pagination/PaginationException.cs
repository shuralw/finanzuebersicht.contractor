using System;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Contexts.Pagination
{
    public class PaginationException : ApplicationException
    {
        public PaginationException(string message)
            : base(message)
        {
        }

        public PaginationException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}