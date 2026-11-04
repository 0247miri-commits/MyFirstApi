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
        private IUserService _service;
        public UserController(IUserService userService)
        {
            _service = userService;.
            
        }
        //Now it is read from the query string (api/User?id=5)
        [HttpGet("{id}")]
        public ActionResult<UserDetails> Get(int id)
        {
            UserDetails user = _service.GetUser(id);
            if (user!=null)
                return Ok(user);
            return NotFound("A user hadn't found");

        }
        [HttpPost("register")]
        public ActionResult<UserDetails> Post([FromBody] UserDetails userDetails)
        {
            if (!ModelState.IsValid) // Check if the validation checks passed
            {
                return BadRequest(ModelState);
            }
            //חוזק הסיסמא
           if (!_service.VaildPassword(userDetails))
                return BadRequest("Check your password strength");

            // נבצע בדיקה שהמייל אינו קיים במערכת עדיין
            if (!_service.UniqueUser(userDetails))
                return BadRequest("Your Email is inside the system already");
            _service.InsertUser(userDetails);
           
            return CreatedAtAction(nameof(Get), new { id = userDetails.UserId }, userDetails);




        }
        [HttpPost("passwordStrength")]
        public IActionResult Post([FromBody] PasswordToCheck userPassword)
        {
            return Ok(_service.PasswordStrong(userPassword.Password));

            
        }

        [HttpPost("login")]
        public ActionResult<UserDetails> Post([FromBody] LoginDetails loginDetails)
        {
            if (!ModelState.IsValid) //  Check if the validation checks passed
            {
                return BadRequest(ModelState);
            }
            int id = _service.UserExistsInSystem(loginDetails);
           if (id==-1)
            return NotFound("User Details don't exist");
          UserDetails user = _service.GetUser(id);
           return Ok(user);

        }

        // עדכון פרטים למשתמש
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] UserDetails userToUpdate)
        {
            _service.UpdateUserInSystem(id, userToUpdate);
           
        }
    }
}
