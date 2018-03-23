using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Media.Imaging;
using MedicinesSales.Data.Database;
using MedicinesSales.Data.Other;

namespace MedicinesSales.Data.Model
{
    class EmployeeProfileModel : INotifyPropertyChanged
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
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _age;
        private string _email;
        private string _post;
        private string _status;
        private BitmapImage _photo;
        #endregion

        #region Properties
        public string firstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("firstName");
            }
        }
        public string lastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("lastName");
            }
        }
        public string middleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                OnPropertyChanged("middleName");
            }
        }
        public string age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("age");
            }
        }
        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("email");
            }
        }
        public string post
        {
            get { return _post; }
            set
            {
                _post = value;
                OnPropertyChanged("post");
            }
        }
        public string status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("status");
            }
        }
        public BitmapImage photo
        {
            get { return _photo; }
            set {
                _photo = value;
                OnPropertyChanged("photo");
            }
        }
        #endregion

        #region Methods
        public void GetDataFromDatabase()
        {
            ProfileEmployee employee = DatabaseModel.GetProfileEmployee(1);

            firstName = employee.firstName;
            lastName = employee.lastName;
            middleName = employee.middleName;
            age = employee.age.ToString();

           // if (employee.photo != null)
                 photo = ToolManager.byteArrayToImage(employee.photo);
           // else photo = ToolManager.GetBitmapImage(@"Data\Images\Empty profile photo.jpg");
            email = employee.email;
            post = employee.post;
            status = employee.status;

        }
        #endregion
    }
}
