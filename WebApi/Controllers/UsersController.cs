using HelloMVC.Models;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService _userService;

        public UsersController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpPost]
        public bool Add(User user)
        {
            return _userService.Add(user);
        }

        [HttpGet]
        public User GetById(int id)
        {
            return _userService.GetById(id);
        }

        [HttpPut]
        public bool Update(User user)
        {
            return _userService.Update(user);
        }

        [HttpDelete]
        public bool Delete(User user)
        {
            return _userService.Delete(user);
        }
    }
}
