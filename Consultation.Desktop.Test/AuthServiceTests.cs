//using Consultation.App;
//using Consultation.Domain;
//using Consultation.Infrastructure.Data;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Consultation.Desktop.Test
//{
//    [TestFixture]
//    public class AuthServiceTests
//    {
//        private AppDbContext _context;
//        private AuthService _authService;


//        [SetUp] 
//        public void Setup()
//        {
//            var option = new DbContextOptionsBuilder<AppDbContext>()
//            .UseSqlServer("YData Source=(localdb)\\MSSQLLocalDB;" +
//                "Initial Catalog=ConsultationDatabase;" +
//                "Integrated Security=True;Connect Timeout=30;" +
//                "Encrypt=False;Trust Server Certificate=False;" +
//                "Application Intent=ReadWrite;Multi Subnet Failover=False")
//            .Options;

//            _context = new AppDbContext(option);
//            _authService = new AuthService(_context);

//        }


//        [Test]

//        public void Login_WithExistingUser_ReturnsUser()
//        {
//            var user = _authService.Login("ReyMateo.550200@umindanao.edu.ph", "MyFaculty123!");
//            Assert.IsNotNull(user);
//        }


//        [TearDown]

//        public void TearDown()
//        {
//            _context.Dispose();
//        }


//    }


//}
