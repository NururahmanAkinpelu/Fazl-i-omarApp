﻿using Backend.Context;
using Backend.Entities;
using Backend.Interface.Repositories;

namespace Backend.Implementation.Repositories
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
