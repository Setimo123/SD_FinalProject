
using Consultation.Domain;
using Consultation.Domain.Enum;
using Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UM_Consultation_App_MAUI.MvvmHelper
{
    public class Helper
    {
        public static string GetSemesterName(Semester value)
        {
            return value.GetType()
                        .GetMember(value.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()?
                        .GetName() ?? value.ToString();
        }

        public static string GetYearLevelName(YearLevel value)
        {
            return value.GetType()
                        .GetMember(value.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()?
                        .GetName() ?? value.ToString();
        }

        public static void DisplayMessage(string message)
        {
            App.Current.MainPage.DisplayAlert("Display Message", message, "Ok");
        }

        public static List<string> StringSplitter(char splitter, string word)
        {
            string[] split = word.Split(splitter);
            List<string> wordSplit = new List<string>();
            foreach (var i in split)
            {
                wordSplit.Add(i);
            }

            return wordSplit;
        }



        public async static Task<bool> DisplayOption(string message,string FirstOption,string SecondOption)
        {
            bool ChosenOption = await App.Current.MainPage.DisplayAlert("Mobile Message", message, FirstOption, SecondOption);
            return ChosenOption;
        } 
    }
}
