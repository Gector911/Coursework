using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MedicinesSales.Data.Database
{
        class ProfileEmployee
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string post { get; set; }
        public string status { get; set; }
        public Byte[] photo { get; set; }     
    }
}
