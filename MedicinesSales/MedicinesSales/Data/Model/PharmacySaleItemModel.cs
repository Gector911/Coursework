using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinesSales.Data.Model
{
    class PharmacySaleItemModel
    {
        #region Fields
        private string _id;
        private string _name;
        private string _employee;
        private string _quantity;
        private string _profit;
        private string _date;
        #endregion

        #region Properties
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string employee
        {
            get { return _employee; }
            set { _employee = value; }
        }
        public string quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string profit
        {
            get { return _profit; }
            set { _profit = value; }
        }
        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion
    }
}
