using Microsoft.EntityFrameworkCore;
using LoanApproval.API.Models;

namespace LoanApproval.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<LoanApplication> LoanApplications { get; set; }
    }
}
