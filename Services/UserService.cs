using MongoDB.Driver;
using ProjectRoot.Models;
using ProjectRoot.Database;

namespace ProjectRoot.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserService(MongoDBService mongoDBService)
        {
            _usersCollection = mongoDBService.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetAllAsync() =>
            await _usersCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetByIdAsync(string id) =>
            await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User user) =>
            await _usersCollection.InsertOneAsync(user);

        public async Task DeleteAsync(string id) =>
            await _usersCollection.DeleteOneAsync(x => x.Id == id);
    }
}