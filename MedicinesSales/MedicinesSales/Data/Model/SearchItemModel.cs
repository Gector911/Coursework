using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicinesSales.Data.Database;

namespace MedicinesSales.Data.Model 
{
    class SearchItemModel 
    {
        private int _id;
        private string _title;
        private string _description;

        public int id
        { get { return _id; }
          set { _id = value; }
        }
        public string title{
            get { return _title;  }
            set { _title = value;
            }
        }
        public string description{
        
            get { return _description; }
            set { _description = value;
            }
        }
    }
}
