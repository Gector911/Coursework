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

        private Page PharmacySale;
        private Page PharmacyDelivery;
        private Page WarehouseDelivery;
        private Page WarehouseReceiving;
        private Page ProfileAccount;
        private Page DataBaseMedicines;
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
            OpenDatabaseMedicines = new Command(arg => OpenDatabaseMedicine());
            OpenPharmacySales = new Command(arg => OpenPharmacyMedicineSales());
            OpenPharmacyReceived = new Command(arg => OpenPharmacyMedicineDeliveries());
            OpenWarehouseDeliveries = new Command(arg => OpenPharmacyMedicineDeliveries());
            OpenWarehouseReceived = new Command(arg => OpenWarehouseMedicineReceiving());

            ProfileAccount = new EmployeeProfileView ();
            DataBaseMedicines = new SearchMedicinesView ();
            PharmacySale = new PharmacySaleView ();
            PharmacyDelivery = new ReceivingPharmacyView();
            WarehouseDelivery = new DeliveryWarehouseView ();
            WarehouseReceiving = new ReceivingWarehouseView ();
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
        public ICommand OpenDatabaseMedicines { get; set; }
        public ICommand OpenPharmacySales { get; set; }
        public ICommand OpenPharmacyReceived { get; set; }
        public ICommand OpenWarehouseDeliveries { get; set; }
        public ICommand OpenWarehouseReceived { get; set; }
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
        private void OpenDatabaseMedicine(){
            CurrentPage = DataBaseMedicines;
        }
        private void OpenPharmacyMedicineSales()
        {
            CurrentPage = PharmacySale;
        }
        private void OpenPharmacyMedicineDeliveries()
        {
            CurrentPage = PharmacyDelivery;
        }
        private void OpenWarehouseMedicineDeliveries()
        {
            CurrentPage = WarehouseDelivery;
        }
        private void OpenWarehouseMedicineReceiving() {
            CurrentPage = WarehouseReceiving;
        }
        #endregion
    }
}
