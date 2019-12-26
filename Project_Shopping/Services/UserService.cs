using MongoDB.Driver;
using Project_Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Shopping.Services
{
    public class UserService
    {
        public readonly IMongoCollection<UserDBModel> _user;
        private readonly PasswordProcess _pwProcess;

        public UserService(IDatabaseSettings settings, PasswordProcess passwordProcess)
        {
            var client = new MongoClient(settings.ConnectionString.ToString());
            var database = client.GetDatabase(settings.DatabaseName.ToString());

            _user = database.GetCollection<UserDBModel>(settings.UserCollectionName.ToString());
            _pwProcess = passwordProcess;
        }

        //[Obsolete]
        //public void CountData() =>
        //    _user.Count(it => true).ToString();

        public bool LoginByUser(string username, string password)
        {
            var TruePassword = _pwProcess.Encrypt(password);
            var LoginData  = _user.Find(accout => accout.username == username && accout.password == TruePassword).FirstOrDefault();
            if (LoginData != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UserDBModel GetUserBy_user(string username) =>
            _user.Find(user => user.username == username).FirstOrDefault();
        public IEnumerable<UserDBModel> GetAllUser()
        {
            return _user.Find(user => true).ToEnumerable();
        }

        public UserDBModel GetUserBy_id(string id) =>
            _user.Find(user => user._id == id).FirstOrDefault();

        public UserDBModel CreateUser(UserDBModel userData)
        {
            _user.InsertOne(userData);
            return userData;
        }

        public void UpdateUserByID(string id,UserDBModel UserInput)
        {
            var def = Builders<UserDBModel>.Update
                .Set(it => it._id, UserInput._id)
                .Set(it => it.username, UserInput.username)
                .Set(it => it.password, UserInput.password)
                .Set(it => it.fitst_Name, UserInput.fitst_Name)
                .Set(it => it.last_Name, UserInput.last_Name)
                .Set(it => it.address, UserInput.address)
                .Set(it => it.email, UserInput.email)
                .Set(it => it.phonenumber, UserInput.phonenumber)
                .Set(it => it.role,UserInput.role)
                .Set(it => it.userStatus,UserInput.userStatus)
                .Set(it => it.CreateDateTime, UserInput.CreateDateTime)
                .Set(it => it.UpdateDateTime, DateTime.Now);
            _user.UpdateOne(user => user._id == id, def);
        }

        public void RemoveUser(string id, UserDBModel UserInput)
        {
            _user.DeleteOne(it => it._id == id);
        }
    }
}
