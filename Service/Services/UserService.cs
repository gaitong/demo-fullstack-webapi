﻿using HelloMVC.Models;
using HelloMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public bool Add(User user)
        {
            return _userRepository.Add(user) > 0;
        }

        public bool Update(User user)
        {
            return _userRepository.Update(user) > 0;
        }

        public bool Delete(User user)
        {
            return _userRepository.Delete(user) > 0;
        }
    }
}