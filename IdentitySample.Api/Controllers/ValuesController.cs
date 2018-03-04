using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentitySample.Application.Api.Interfaces;
using IdentitySample.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IdentitySample.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUserManager<ApplicationUser> _userManager;
        public ValuesController(IUserManager<ApplicationUser> userManager)

        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("api/Home")]
        public async Task<IActionResult> Get()
        {
            return Ok("Teste");
        }

        [HttpPost]
        [Authorize]
        [SwaggerResponse(200, typeof(IdentityResult))]
        [SwaggerResponse(500, typeof(Exception))]
        [Route("api/Home")]
        public async Task<IActionResult> Post([FromBody]PostUser test)
        {
            try
            {
                var result = await _userManager.CreateAsync(new ApplicationUser
                {
                    Email = test.Email,
                    UserName = test.Email
                }, test.Password);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

public struct PostUser
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
}