using GoByBus.Core.Entities;
using GoByBus.Core.Models;
using GoByBus.Infrastructure.IRepositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoByBus.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IMongoCollection<UserEntity> _usersCollection;

        public UserRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<UserEntity>(
                databaseSettings.Value.UsersCollectionName);
        }

        public async Task<UserEntity> RegisterUser(UserEntity user)
        {
            await _usersCollection.InsertOneAsync(user);

            return user;
        }



    }
}
