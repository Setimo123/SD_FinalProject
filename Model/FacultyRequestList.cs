using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM_Consultation_App_MAUI.Model
{
    public partial class FacultyRequestList : ObservableObject
    {
        
            public int Id { get; set; }
            public string CourseCode { get; set; }
            public string StudentName { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Status { get; set; }
            public Color StatusColor { get; set; }
        
    }
}
