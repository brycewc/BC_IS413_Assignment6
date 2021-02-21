using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BC_IS413_Assignment6.Models
{
    public interface IAmazonBooksRepository
    {
        IQueryable<Book> Books { get; }
    }
}
