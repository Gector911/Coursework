using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MedicinesSales.Data.Account
{
   class Account
    {
        public static bool CheckValidation(string textField, string expression)
        {
            Regex regex = new Regex(expression);
            if (regex.IsMatch(textField)) return true;
            else return false;
        }

    }
}
