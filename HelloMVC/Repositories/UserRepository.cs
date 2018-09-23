using Dapper;
using HelloMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelloMVC.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        int Add(User entity);
        int Update(User entity);
        int Delete(User entity);
    }

    public class UserRepository : IUserRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<User> GetAll()
        {
            var sqlCommand = "SELECT * FROM[User].[dbo].[User]";

            return _db.Query<User>(sqlCommand).ToList();
        }

        public User GetById(int id)
        {
            var sqlCommand = "SELECT * FROM[User].[dbo].[User] WHERE Id = @id";

            return _db.Query<User>(sqlCommand,new {id}).FirstOrDefault();
        }

        public int Add(User entity)
        {
            var sqlCommand = "INSERT INTO [User].[dbo].[User]([UserName],[Tel]) VALUES (@UserName, @Tel)";
        
            return _db.Execute(sqlCommand, new { entity.UserName, entity.Tel });
        }

        public int Update(User entity)
        {
            var sqlCommand = "UPDATE [User].[dbo].[User] SET[UserName] = @UserName,[Tel] = @Tel WHERE Id = @Id";

            return _db.Execute(sqlCommand, new { entity.UserName, entity.Tel, entity.Id });
        }

        public int Delete(User entity)
        {
            var sqlCommand = "DELETE FROM [User].[dbo].[User] WHERE Id = @Id";

            return _db.Execute(sqlCommand, new { entity.Id });
        }
    }
}