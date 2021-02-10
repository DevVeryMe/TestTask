using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTask.Dtos;
using TestTask.Entities;
using TestTask.ServiceInterfaces;

namespace TestTask.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        private readonly TestTaskDbContext _testTaskDbContext;


        public UserService(IMapper mapper,
            TestTaskDbContext testTaskDbContext)
        {
            _mapper = mapper;
            _testTaskDbContext = testTaskDbContext;
        }

        public async Task CreateMultipleAsync(IEnumerable<CreateUserDto> createUserDtos)
        {
            // Server side validation(missing)...

            var userEntitiesToCreate = 
                _mapper.Map<IEnumerable<UserEntity>>(createUserDtos);

            await _testTaskDbContext.Users.AddRangeAsync(userEntitiesToCreate);
            await _testTaskDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetUserDto>> GetAllAsync()
        {
            var userEntities = _testTaskDbContext
                .Users
                .AsNoTracking()
                .AsEnumerable();

            var userDtos = _mapper.Map<IEnumerable<GetUserDto>>(userEntities);

            return userDtos;
        }

        public async Task<GetUserDto> UpdateAsync(UpdateUserDto updateUserDto)
        {
            var userToUpdate = await _testTaskDbContext
                .Users
                .FindAsync(updateUserDto.Id);

            ValidateEntityNotNull(userToUpdate);

            userToUpdate.Name = updateUserDto.Name;
            userToUpdate.BirthDate = updateUserDto.BirthDate;
            userToUpdate.IsMarried = updateUserDto.IsMarried;
            userToUpdate.PhoneNumber = updateUserDto.PhoneNumber;
            userToUpdate.Salary = updateUserDto.Salary;

            await _testTaskDbContext.SaveChangesAsync();

            var resultUserDto = _mapper.Map<GetUserDto>(userToUpdate);

            return resultUserDto;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var userToDelete = await _testTaskDbContext
                .Users
                .FindAsync(id);

            ValidateEntityNotNull(userToDelete);

            _testTaskDbContext.Users.Remove(userToDelete);

            await _testTaskDbContext.SaveChangesAsync();
        }

        private static void ValidateEntityNotNull(UserEntity userToValidate)
        {
            if (userToValidate is null)
            {
                throw new ArgumentException();
            }
        }
    }
}
