using Angular.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Angular.Api.Data
{
    public class EnquiryDbContext : DbContext
    {
        public EnquiryDbContext(DbContextOptions<EnquiryDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<EnquiryMaster> EnquiryMasters { get; set; }
        public DbSet<Services> Services { get; set; }
    }
}
