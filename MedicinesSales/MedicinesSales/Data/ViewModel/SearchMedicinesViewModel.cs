using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MedicinesSales.Data.Model;
using MedicinesSales.Data.Database;
using MedicinesSales.Data.View;
using System.Windows;
using System.ComponentModel;

namespace MedicinesSales.Data.ViewModel
{
     class SearchMedicinesViewModel
    {

        private ObservableCollection <SearchItemModel> _dataGridMedicines = new ObservableCollection <SearchItemModel>();
        public ObservableCollection  <SearchItemModel> DataGridMedicines
        {
            get { return _dataGridMedicines; }
            set { _dataGridMedicines = value; }
        }
        public ICommand NewMedicine { get; set; }
        public ICommand FindMedicines { get; set; }
        public ICommand DeleteMedicine { get; set; }
        private SearchItemModel _selectedItem;
        public SearchItemModel SelectedItem {
            get { return _selectedItem; }
            set { _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public string _searchLine { get; set; }

       public SearchMedicinesViewModel()
        {
            NewMedicine = new Command(arg => AddItem());
            FindMedicines = new Command(arg => FindItem());
            DeleteMedicine = new Command(arg => DeleteItem());
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


        public void GetDataFromDatabase() {
            DatabaseModel database = new DatabaseModel();
            HashSet <SearchItemModel> itemsFromDB = database.GetMedicines();
            foreach (SearchItemModel item in itemsFromDB)
                DataGridMedicines.Add(item);         
        }
        private void AddItem()
        {
            SearchItemModel item = new SearchItemModel(); 
        }
        private void FindItem()
        {
            DataGridMedicines.Clear();
            DatabaseModel database = new DatabaseModel();
            HashSet<SearchItemModel> itemsFromDB = database.FindMedicines(_searchLine);
            foreach (SearchItemModel item in itemsFromDB)
                DataGridMedicines.Add(item);
        }
        private void DeleteItem (){
            if (_selectedItem != null){
                DatabaseModel database = new DatabaseModel();
                database.DeleteMedicine(_selectedItem);
                DataGridMedicines.Remove(_selectedItem);
                _selectedItem = null;
            }
        }
    }
}
