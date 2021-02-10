using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Dtos;
using TestTask.Models;
using TestTask.ServiceInterfaces;

namespace TestTask.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMultipleAsync([FromBody] IEnumerable<CreateUserViewModel> createUserViewModels)
        {
            var createUserDtos = _mapper.Map<IEnumerable<CreateUserDto>>(createUserViewModels);

            await _userService.CreateMultipleAsync(createUserDtos);

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(GetUserViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserViewModel updateUserViewModel)
        {
            var updateUserDto = _mapper.Map<UpdateUserDto>(updateUserViewModel);

            var userDto = await _userService.UpdateAsync(updateUserDto);

            var userViewModel = _mapper.Map<GetUserViewModel>(userDto);

            return Ok(userViewModel);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetUserViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var userDtos = await _userService.GetAllAsync();

            var userViewModels = _mapper.Map<IEnumerable<GetUserViewModel>>(userDtos);

            return View(userViewModels);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] int id)
        {
            await _userService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
