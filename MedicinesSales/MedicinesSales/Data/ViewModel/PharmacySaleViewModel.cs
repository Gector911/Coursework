using MedicinesSales.Data.Database;
using MedicinesSales.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicinesSales.Data.ViewModel
{
    class PharmacySaleViewModel
    {
        private PharmacySaleItemModel _selectedItem;
        public PharmacySaleItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public string searchLine { get; set; }

        private ObservableCollection <PharmacySaleItemModel> _dataGridMedicines = new ObservableCollection <PharmacySaleItemModel>();
        public ObservableCollection <PharmacySaleItemModel> DataGridMedicines
        {
            get { return _dataGridMedicines; }
            set { _dataGridMedicines = value; }
        }

        public PharmacySaleViewModel()
        {
            _selectedItem = null;
            GetDataFromDatabase();
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

        public void GetDataFromDatabase()
        {
            DatabaseModel database = new DatabaseModel();
            HashSet <PharmacySaleItemModel> itemsFromDB = database.GetPharmacySales();
            foreach (PharmacySaleItemModel item in itemsFromDB)
                DataGridMedicines.Add(item);
        }
    }
}
