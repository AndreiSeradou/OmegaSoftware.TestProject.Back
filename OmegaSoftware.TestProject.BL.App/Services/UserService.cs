﻿using AutoMapper;
using OmegaSoftware.TestProject.BL.App.Interfaces.Services;
using OmegaSoftware.TestProject.BL.Domain.Models.DTOs;
using OmegaSoftware.TestProject.DAL.Interfaces.Repositories;
using OmegaSoftware.TestProject.DAL.Models;

namespace OmegaSoftware.TestProject.BL.App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool IsExistihgUserByNameAndEmail(string userName, string userEmail)
        {
            var userByName = _userRepository.GetByName(userName);
            var userByEmil = _userRepository.GetByEmail(userEmail);

            if (userByName != null || userByEmil != null)
            {
                return true;
            }

            return false;
        }

        public bool CreateUser(UserDTOs model)
        {
            var dalModel = _mapper.Map<User>(model);
            var result = _userRepository.Create(dalModel);

            return result;
        }

        public bool DeleteUser(UserDTOs model)
        {
            var result = _userRepository.Delete(model.Id);

            return result;
        }

        public ICollection<UserDTOs> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            var result = _mapper.Map<ICollection<UserDTOs>>(users);

            return result;
        }

        public bool UpdateUser(UserDTOs model)
        {
            var dalModel = _mapper.Map<User>(model);
            var result = _userRepository.Update(dalModel);

            return result;
        }
    }
}