using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products.Models;


namespace Products

{
    public class MyDbContext : DbContext
    {
        public DbSet<ProductViewModel> Products { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Database = TSQLV4; Integrated Security = True");
        //}
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {

        }

       
    }
}
