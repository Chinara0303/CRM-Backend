using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class PositionRepository: Repository<Position>,IPositionRepository
    {
        public PositionRepository(AppDbContext context) : base(context) { }
        public async Task<bool> CheckByName(string name)
        {
            var datas = await _entities.ToListAsync();
            bool check = false;
            if (datas.Count > 0)
            {
                foreach (var item in datas)
                {
                    if (item.Name.ToLower() != name.ToLower())
                        check = true;
                    else
                        check = false;
                }
            }
            else
                check = true;
            return check;
        }
    }
}
