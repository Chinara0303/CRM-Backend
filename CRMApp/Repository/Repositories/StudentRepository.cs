﻿
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.İnterfaces;

namespace Repository.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckByEmail(string emailAddress)
        {
            var datas = await _entities.ToListAsync();
            bool check = false;
            if (datas.Count > 0)
            {
                foreach (var item in datas)
                {
                    if (item.Email.ToLower() != emailAddress.ToLower())
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