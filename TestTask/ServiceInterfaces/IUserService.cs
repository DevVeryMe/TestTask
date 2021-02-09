using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Dtos;

namespace TestTask.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetAllAsync();

        Task<GetUserDto> UpdateAsync(UpdateUserDto updateUserDto);

        Task DeleteByIdAsync(int id);
    }
}
