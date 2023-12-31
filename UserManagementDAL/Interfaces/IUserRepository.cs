﻿using UserManagementDAL.Entities;

namespace UserManagementDAL.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetUserByEmailAsync(string email);
}

