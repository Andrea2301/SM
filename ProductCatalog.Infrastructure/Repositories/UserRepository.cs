using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<Users> GetUsersById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Users>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Users> Add(Users user)
    {
        throw new NotImplementedException();
    }

    public async Task<Users> Update(Users user)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}