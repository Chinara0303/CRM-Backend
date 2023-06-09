﻿using Domain.Entities;

namespace Repository.Repositories.İnterfaces
{
    public interface IRoomRepository:IRepository<Room>
    {
        Task<bool> CheckByName(string name);
    }
}
