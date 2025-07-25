using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Dtos;
using FarmaciaSOFT.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FarmaciaSOFT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            if (dto.UserName == "admin" && dto.Password == "123456")
        {
            var token = _authService.GenerateToken(dto.UserName, "Admin");
            return Ok(new { token });
        }

        return Unauthorized("Usuário ou senha inválidos");
    }


        }
    }
