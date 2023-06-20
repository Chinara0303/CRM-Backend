using Domain.Entities;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class TeacherSocialRepository : Repository<TeacherSocial>, ITeacherSocialRepository
    {
        public TeacherSocialRepository(AppDbContext context) : base(context)
        {
        }
    }
}
