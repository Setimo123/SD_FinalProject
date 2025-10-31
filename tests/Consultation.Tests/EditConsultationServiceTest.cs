using Consultation.BackEndCRUD.Service.ConsultationServices;
using Consultation.BackEndCRUD.ViewModel.ConsultationViewModel;
using Consultation.Domain.Enum;
using Consultation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultation.Desktop.Test
{
    [TestFixture]
    public class EditConsultationServiceTest
    {

        private AppDbContext _context;
        private EditConsultationService _editService;


        [SetUp]
        public void Setup()
        {
            var option = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("YData Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=ConsultationDatabase;" +
                "Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=False;Trust Server Certificate=False;" +
                "Application Intent=ReadWrite;Multi Subnet Failover=False")
            .Options;

            _context = new AppDbContext(option);
            _editService = new EditConsultationService(_context);

        }

        [Test]
        public async Task GetEditConsultation_QueryingConsultation_ConsultationVM()
        {
            //EditConsultationViewModel expected = new EditConsultationViewModel
            //{
            //    studentName = "Ellaine Musni",
            //    courseCode = "CEE108",
            //    studentUMID = "547343",
            //    concernDescription = "Requesting help with project scope",
            //    startedTime = new TimeOnly(10),
            //    Status = Status.Pending
            //};

            var result = await _editService.getEditConsultation(2);

            Assert.That(result.studentName, Is.EqualTo("Ellaine Musni"));
            Assert.That(result.courseCode, Is.EqualTo("CEE108"));
            Assert.That(result.studentUMID, Is.EqualTo("547343"));
            Assert.That(result.concernDescription, Is.EqualTo("Requesting help with project scope"));
            Assert.That(result.startedTime, Is.EqualTo(new TimeOnly(10, 0, 0)));
            Assert.That(result.dateSchedule, Is.EqualTo(new DateTime(2025, 7, 15, 0, 0, 0)));
            Assert.That(result.Status, Is.EqualTo(Status.Pending));

        }
    
        [TearDown]

        public void TearDown()
        {
            _context.Dispose();
        }

    }
}
