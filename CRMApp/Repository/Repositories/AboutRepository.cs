using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        public AboutRepository(AppDbContext context) : base(context) { }
      
      
    }
}
