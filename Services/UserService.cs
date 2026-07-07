using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBackend.Data;
using MyBackend.Models;
using MyBackend.DTOs;

namespace MyBackend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _context.Users
                .Where(u => u.IsActive)
                .ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user?.IsActive == true ? _mapper.Map<UserDto>(user) : null;
        }

        public async Task<UserDto> CreateAsync(CreateUserRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password); // простая хэшировка

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> UpdateAsync(int id, UpdateUserRequest request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || !user.IsActive) return null;

            _mapper.Map(request, user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.IsActive = false; // soft delete
            await _context.SaveChangesAsync();
            return true;
        }
    }
}