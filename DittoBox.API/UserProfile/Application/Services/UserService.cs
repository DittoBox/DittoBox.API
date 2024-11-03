using DittoBox.API.Shared.Domain.Repositories;
using DittoBox.API.UserProfile.Domain.Models.Entities;
using DittoBox.API.UserProfile.Domain.Repositories;
using DittoBox.API.UserProfile.Domain.Services.Application;
using System.Security.Cryptography;
using System.Text;

namespace DittoBox.API.UserProfile.Application.Services
{
    public class UserService(
        IUserRepository userRepository) : IUserService
    {
        public async Task<User> CreateUser(string username, string email, string password)
        {
            var user = new User(username, EncryptPassword(password), email);
            await userRepository.Add(user);
            return user;
        }

        public string EncryptPassword(string password)
        {
            var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
        }

        public async Task<User?> GetUser(int id)
        {
            return await userRepository.GetById(id);
        }

        public async Task DeleteUser(int id)
        {
            var user = await userRepository.GetById(id);
            if (user != null)
            {
                await userRepository.Delete(user);
            }
        }

        public async Task UpdateUser(User user)
        {
            await userRepository.Update(user);
        }

		public async Task<IEnumerable<User>> GetUsers()
		{
			return await userRepository.GetAll();
		}
	}
}
