using MedicinesSales.Data.Database;
using MedicinesSales.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinesSales.Data.ViewModel
{
    class ReceivingPharmacyViewModel
    {
        private ReceivingWarehouseItemModel _selectedItem;
        public ReceivingWarehouseItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public string searchLine { get; set; }

        private ObservableCollection <ReceivingWarehouseItemModel> _dataGridMedicines = new ObservableCollection <ReceivingWarehouseItemModel>();
        public ObservableCollection <ReceivingWarehouseItemModel> DataGridMedicines
        {
            get { return _dataGridMedicines; }
            set { _dataGridMedicines = value; }
        }

        public ReceivingPharmacyViewModel()
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
            HashSet <ReceivingWarehouseItemModel> itemsFromDB = database.GetWarehouseReceiving();
            foreach (ReceivingWarehouseItemModel item in itemsFromDB)
                DataGridMedicines.Add(item);
        }
    }
}
