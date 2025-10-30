
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Consultation.Domain;
using Consultation.Infrastructure.Data;
using FlutterAPI.ViewModel;

namespace FlutterAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        private readonly AppDbContext _context;

        public AuthenticationController(AppDbContext context,
            UserManager<Users> UserManager, SignInManager<Users> SignInManager)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
            _context = context;
        }

        //Register Controller
        [HttpPost]
        public async Task<IActionResult> UserRegister([FromBody] UserViewModel UserModel)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //user instance
            var users = new Users
            {
                UserName = UserModel.UserEmail,
                Email = UserModel.UserEmail,
                UMID = UserModel.UMID,
                UserType = UserModel.UserType,
            };

            //hasher
            var hasher = await _userManager.CreateAsync(users, UserModel.UserPassword);

            //Conditional statement for the hasher
            if(!hasher.Succeeded)
                return BadRequest(hasher.Errors);


            //switch statement for the usertype is student,fauclty or admin who register
            switch ((int)UserModel.UserType)
            {
                case 0:
                    var student = new Student
                    {
                        StudentUMID = UserModel.UMID,
                        StudentName = UserModel.StudentName,
                        Email = UserModel.UserEmail,
                        Users = users,
                        ProgramID = 1, 
                    };
                    _context.Students.Add(student);
                    break;
                case 1:
                    var Faculty = new Faculty
                    {
                        FacultyUMID= UserModel.UMID,
                        FacultyName = UserModel.FacultyName,
                        Users = users
                    };
                    _context.Faculty.Add(Faculty);
                    break;
                case 2:
                    var admin = new Admin
                    {
                        AdminName = UserModel.UserEmail,
                        Users = users
                    };
                    _context.Admin.Add(admin);
                    break;
                default:
                    return BadRequest("Invalid User Type");
            }


            //ActionLog instance
            string message = $"{UserModel.UserEmail} has been registered";
            var actionlogs = ActionLogController.ActionLogger(message, UserModel.UserEmail, UserModel.UserType,
                users); 
  
            _context.ActionLog.Add(actionlogs);

            await _context.SaveChangesAsync();

            return Ok("Registration successful");
        }

        //Log-in Controller
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserViewModel UsersModel)
        {
            //Query for the hasher and user
             var result = await _signInManager.PasswordSignInAsync(
            UsersModel.UserEmail, UsersModel.UserPassword, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
                return Unauthorized("Invalid Username and Password");

            //Action Log instance
     

            return Ok(new
            {
                message = "Login successful",
                username = UsersModel.UserEmail
            });
        }
    }
}
