using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application;

public class UserService
{
    private readonly IUserRepository _userRepository;
    
    // Dependence injection 
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    //---------------Service for Users--------------//
    
    // GetAll user by ID

    public async Task<Users> GetUserById(int id)
    {
        return await _userRepository.GetUsersById(id);
    }
    
    // Get all users
    public async Task<List<Users>> GetAllUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<Users> AddUser(Users user)
    {
        await _userRepository.Add(user);
        return user;
    }
    
    //update a user 

    public async Task<bool> UpdateUser(Users user)
    {
        var exist = await _userRepository.GetUsersById(user.Id);

        if (exist == null)
            return false;
        
        await _userRepository.Update(user);
        return true;
    }
    
    // delete a user 

    public async Task<bool> DeleteUser(int id)
    {
        var exist = await _userRepository.GetUsersById(id);
        
        if (exist == null)
            return false;

        await _userRepository.Delete(id);
        return true;

    }
}