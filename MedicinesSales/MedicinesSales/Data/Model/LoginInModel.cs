using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MedicinesSales.Data.Model 
{
    class LoginInModel : INotifyPropertyChanged
    {
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

        #region Fields
        private string _login;
        private string _password;
        #endregion

        #region Properties
        public string login {
            get { return _login; }
            set {
                _login = value;
                OnPropertyChanged("login");
            }
        }
        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("password");
            }
        }
        #endregion

    }
}
