using Microsoft.EntityFrameworkCore;
using CrudEFCoreNet6.Models;

namespace CrudEFCoreNet6.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
        }

        public DbSet<Usuario>? Usuario {get; set;}

    }
}