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
        public RelayCommand ShowNameCommand { get; set; }

        private string _name;    
        public string Name {
            get
            {
                return _name;
            }
           
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                if (ShowNameCommand != null)
                {
                    ShowNameCommand.Update();
                }
            }
        }

           
        public NameViewModel()
        {
            Name = string.Empty;
           
            NewNameCommand = new RelayCommand(NewExecute);
            ShowNameCommand = new RelayCommand(ShowExecute, ShowCanExecute);
        }

       
        private void NewExecute()
        {
            Name = Util.RandomName();
        }



        private void ShowExecute()
        {
            System.Windows.MessageBox.Show(Name);
        }

        private bool ShowCanExecute()
        {
            return !String.IsNullOrEmpty(Name);
        }
       

    }
}
