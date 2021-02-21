using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BC_IS413_Assignment6.Models
{
    public class AmazonBooksDBContext : DbContext
    {
        public AmazonBooksDBContext(DbContextOptions<AmazonBooksDBContext> options) : base(options)
        {

        }

        public DbSet<Book> Books {get; set;}
    }
}
