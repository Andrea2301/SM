using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Application
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // 🔹 Obtener un usuario por ID
        public async Task<User?> GetUserById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de usuario no es válido");

            return await _userRepository.GetUserById(id);
        }

        // 🔹 Obtener todos los usuarios
        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        // 🔹 Crear un usuario nuevo
        public async Task<User> AddUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("El nombre de usuario es obligatorio");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("El email es obligatorio");

            // Validación de duplicado
            var existingUsers = await _userRepository.GetAll();
            if (existingUsers.Any(u => u.Email == user.Email))
                throw new InvalidOperationException("Ya existe un usuario con ese correo electrónico");

            return await _userRepository.Add(user);
        }

        // 🔹 Actualizar usuario existente
        public async Task<bool> UpdateUser(User user)
        {
            if (user.Id <= 0)
                throw new ArgumentException("El ID de usuario no es válido");

            var existing = await _userRepository.GetUserById(user.Id);
            if (existing == null)
                return false;

            existing.Username = user.Username;
            existing.Password = user.Password;
            existing.Email = user.Email;
            existing.Role = user.Role;

            await _userRepository.Update(existing);
            return true;
        }

        // 🔹 Eliminar usuario
        public async Task<bool> DeleteUser(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de usuario no es válido");

            var existing = await _userRepository.GetUserById(id);
            if (existing == null)
                return false;

            await _userRepository.Delete(id);
            return true;
        }
    }
}
