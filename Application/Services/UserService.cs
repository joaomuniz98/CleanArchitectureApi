using Application.DTOs;
using Application.Interfaces;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUser
    {

        public readonly MyDbContext _context;

        public UserService(MyDbContext context)
        {
            _context = context;
        }

        public Task<UserDto> CreateUser(UserDto userDto)
        {
           var getUser =  _context.Users.Where(x => x.Email == userDto.Email).FirstOrDefault();

            if(getUser == null)
            {
                getUser.Email = userDto.Email;
                getUser.Name = userDto.Name;
                getUser.Password = userDto.Password;

                _context.Users.Add(getUser);
                _context.SaveChanges();
            }
           
            return Task.FromResult(userDto);
        }
    }
}
