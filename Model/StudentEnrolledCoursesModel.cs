using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM_Consultation_App_MAUI.Model
{
    public partial class StudentEnrolledCoursesModel : ObservableObject
    {
        [ObservableProperty]
        public string coursecode;

        [ObservableProperty]
        public string coursename;

        [ObservableProperty]
        public string instructorname;

        public StudentEnrolledCoursesModel(string _coursecode, string _coursename, string _instructorname)
        {
            coursecode = _coursecode;
            coursename = _coursename;
            instructorname = _instructorname;
        }

        public StudentEnrolledCoursesModel(string coursename)
        {
           Coursename = coursename;
        }
    }
}
