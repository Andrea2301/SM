using ProductCatalog.Domain.Entities;

namespace ProductCatalog.Domain.Interfaces;

public interface IUserRepository 
{
    Task<Users> GetUsersById(int id);
    Task<List<Users>> GetAll();
    Task<Users> Add(Users user);
    Task<Users> Update(Users user);
    Task Delete(int id);
    
}