using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LeSportif.Services
{
    public class Validator

    {
        const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        private string ErrorMsg;

        public string ValidateEmailPass(string email, string pass)
        {
            ErrorMsg = "";
            if (String.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                ErrorMsg += "\nInvalid Email";
            }

            if (string.IsNullOrWhiteSpace(pass) || pass.Length < 6)
            {
                ErrorMsg += "\nPassword must have 6 charactor length";
            }

            return ErrorMsg;
        }
    }
}
