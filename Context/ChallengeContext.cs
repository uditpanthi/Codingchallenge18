using Codingchallenge.Models;
using Microsoft.EntityFrameworkCore;
namespace PracticeTest.Context
{
    public class ChallengeContext : DbContext
    {
        public DbSet<Books> books {  get; set; }

        public ChallengeContext(DbContextOptions options) : base(options)
        {
           

        }

    }
}
