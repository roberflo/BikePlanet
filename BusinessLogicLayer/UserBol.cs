using GFShop.DataAccessLayer.Repositories.Interfaces;
using GFStore.ApplicationLayer.Dto;
using GFStore.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using GFShop.DataAccessLayer.Entities;
using GFShop.Helpers;
using GFShop.Utils;
using GFStore.Utils;
using GFStore.ApplicationLayer.Dto.Response;

namespace GFStore.BusinessLogicLayer
{
    public class UserBol : IUserBol
    {
        private IUserRepository _userRepository { get; set; }
        private IMapper _mapper { get; set; }

        private IAuthenticationHelper _authenticationHelper { get; set; }

        public UserBol(IUserRepository userRepository, IMapper mapper, IAuthenticationHelper authenticationHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationHelper = authenticationHelper;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDto>>(_userRepository.GetAll());
        }

        public UserDto GetById(int id)
        {
            return _mapper.Map<UserDto>(_userRepository.GetById(id));
        }

        public void Update(UserDto user, string password = null)
        {
            throw new NotImplementedException();
        }

        public UserCreatedResponse CreateUser(UserDto userDto)
        {
            // validation
            if (string.IsNullOrWhiteSpace(userDto.Password))
                throw new AppException("Password is required");

            if (_userRepository.UsernameExist(userDto.Username))
                throw new AppException("Username \"" + userDto.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            _authenticationHelper.CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);

            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = "User";

            return _mapper.Map<UserCreatedResponse>( _userRepository.Create(user));
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public AuthenticatedUserResponse Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _userRepository.GetByUsername(username);

            if (user == null) return null;

            // check if password is correct
            if (!_authenticationHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successfull
           string Token = _authenticationHelper.AuthenticationToken(user);

            //Map
            AuthenticatedUserResponse authenticatedUser = _mapper.Map<AuthenticatedUserResponse>((user));
            authenticatedUser.Token = Token;
            return authenticatedUser;
        }
    }
}
