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
    class DeliveryWarehouseViewModel
    {
        private DeliveryWarehouseItemModel _selectedItem;
        public DeliveryWarehouseItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public string searchLine { get; set; }

        private ObservableCollection <DeliveryWarehouseItemModel> _dataGridMedicines = new ObservableCollection <DeliveryWarehouseItemModel>();
        public ObservableCollection <DeliveryWarehouseItemModel> DataGridMedicines
        {
            get { return _dataGridMedicines; }
            set { _dataGridMedicines = value; }
        }

        public DeliveryWarehouseViewModel ()
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
            HashSet <DeliveryWarehouseItemModel> itemsFromDB = database.GetWarehouseDeliveries();
            foreach (DeliveryWarehouseItemModel item in itemsFromDB)
                DataGridMedicines.Add(item);
        }
    }
}
