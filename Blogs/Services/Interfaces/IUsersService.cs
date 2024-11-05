using Blogs.Models.DTOs;

namespace Blogs.Services.Interfaces;

public interface IUsersService
{
    Task<List<UsersDTO>> GetUsersAsync();
}
