using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicinesSales.Data.Model;
using MedicinesSales.Data.Database;


namespace MedicinesSales.Data.ViewModel
{
   class LoginInViewModel
    {
        #region Constructor
        public LoginInViewModel()
        {
            ClickCommand = new Command(arg => ClickMethod());
            LoginIn = new LoginInModel(); 
        }
        #endregion


        #region Properties
        public LoginInModel LoginIn { get; set; }
        #endregion

        #region Commands
        public ICommand ClickCommand { get; set; }
        #endregion

        private void ClickMethod()
        {
            DatabaseModel database = new DatabaseModel();
            if (database.CheckMatchAccount(LoginIn.login, LoginIn.password))
            {

                Program window = new Program();
                window.Show();
                Application.Current.MainWindow.Close();
            }
            else MessageBox.Show("Data entered incorrectly!");
        }
    }
}
