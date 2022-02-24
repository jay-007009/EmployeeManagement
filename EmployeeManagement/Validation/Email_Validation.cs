using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManagement.Validation
{
    public class Email_Validation
    {

        public bool ValidateEmail(string email)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }

        public bool ValidateContact(string contact)
        {

            Regex regex = new Regex(@"[0-9]{10}");
            Match match = regex.Match(contact);
            if (match.Success)
                return true;
            else
                return false;
        }

    }

}
