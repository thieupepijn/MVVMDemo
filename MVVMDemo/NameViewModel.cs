using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo
{
    public class NameViewModel : ViewModel
    {
        public RelayCommand NewNameCommand { get; set; }

        private string _name;    
        public string Name {
            get
            {
                return _name;
            }
           
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

           
        public NameViewModel()
        {
            Name = string.Empty;
            Action action = delegate () { Name = Util.RandomName(); };
            NewNameCommand = new RelayCommand(action);   
            
            
        }

       

       

    }
}
