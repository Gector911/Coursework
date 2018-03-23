using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MedicinesSales.Data.Model;
using MedicinesSales.Data.View;
using System.ComponentModel;
using MedicinesSales.Data.Database;

namespace MedicinesSales.Data.ViewModel
{
    class ProgramViewModel : INotifyPropertyChanged
    {

        #region Fields
        private DatabaseModel database;

        private Page ProfileAccount;
        private Page _currentPage;
        #endregion

        #region Properties
        public Page CurrentPage
        {
            get { return _currentPage;  }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        #endregion

        public ProgramViewModel () {
            database = new DatabaseModel();

            ExitApplication = new Command(arg=>ExitFromApp());
            OpenProfileAccount = new Command(arg => OpenProfileEmployee());

            ProfileAccount = new EmployeeProfileView ();
        }


        #region INotyfyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        #region Commands
        public ICommand OpenProfileAccount { get; set; }
        public ICommand ExitApplication { get; set; }
        #endregion

        #region Methods
        private void ExitFromApp()
        {
            Application.Current.Shutdown();
        }
        private void OpenProfileEmployee()
        {
            CurrentPage = ProfileAccount;
        }
        #endregion
    }
}
