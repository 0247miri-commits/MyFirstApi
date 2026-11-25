using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Zxcvbn;
using Entities;
using Service;

namespace MyApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private IUserService _service;
        public UserController(IUserService userService, ILogger<UserController> logger )
        {
            _service = userService;
            _logger = logger;
        }
        //Now it is read from the query string (api/User?id=5)
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await _service.GetUser(id);
            if (user!=null)
                return Ok(user);
            return NotFound("A user hadn't found");

        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Post([FromBody] User userDetails)
        {
            if (!ModelState.IsValid) // Check if the validation checks passed
            {
                return BadRequest(ModelState);
            }
            //חוזק הסיסמא
           if (!_service.VaildPassword(userDetails))
                return BadRequest("Check your password strength");

            // נבצע בדיקה שהמייל אינו קיים במערכת עדיין
            if (!await _service.UniqueUser(userDetails))
                return BadRequest("Your Email is inside the system already");
            await _service.InsertUser(userDetails);
           
            return CreatedAtAction(nameof(Get), new { id = userDetails.Id }, userDetails);




        }
        [HttpPost("passwordStrength")]
        public IActionResult Post([FromBody] PasswordToCheck userPassword)
        {
            return Ok(_service.PasswordStrong(userPassword.Password));

            
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Post([FromBody] LoginDetails loginDetails)
        {
            if (!ModelState.IsValid) //  Check if the validation checks passed
            {
                return BadRequest(ModelState);
            }
            int id =await _service.UserExistsInSystem(loginDetails);
           if (id==-1)
            return NotFound("User Details don't exist");
          User user = await _service.GetUser(id);
           return Ok(user);

        }

        // עדכון פרטים למשתמש
        [HttpPut("{id}")]
        public async Task Put(int id,[FromBody] User userToUpdate)
        {
            await _service.UpdateUserInSystem(id, userToUpdate);
           
        }
    }
}
