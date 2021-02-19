using Microsoft.EntityFrameworkCore;
// Core Components
using MarcattiApi.Models;

namespace MarcattiApi.Data
{
  public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<UserRegister> Users { get; set; }
        public DbSet<CustomerRegister> Customers { get; set; }
  }
}
