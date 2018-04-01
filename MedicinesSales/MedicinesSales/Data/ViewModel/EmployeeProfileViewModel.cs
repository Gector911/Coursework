using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicinesSales.Data.Model;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;
using MedicinesSales.Data.Database;

namespace MedicinesSales.Data.ViewModel
{
     class EmployeeProfileViewModel 
    {

        #region Properties
        public EmployeeProfileModel employeeProfile { get; set; }
        #endregion

        #region Constructor
        public EmployeeProfileViewModel ()
        {
            DatabaseModel database = new DatabaseModel();
            employeeProfile = database.GetProfileEmployee(1);
        }
        #endregion

        

    }
}
