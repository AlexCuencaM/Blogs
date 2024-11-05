using Blogs.Models;
using Blogs.Models.DTOs;
using Blogs.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Blogs.Services;

public class UsersService(BlogContext context): IUsersService
{
    private readonly BlogContext _context = context;
    public async Task<List<UsersDTO>> GetUsersAsync()
    {
        return await _context.Users.Select(x => new UsersDTO
        {
            Name = x.Name,
            Age = x.Age,
            Email = x.Email,
        }).ToListAsync();
    }
}
