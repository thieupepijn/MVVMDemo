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
        public RelayCommand MakeNameEmptyCommand { get; set; }

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
                UpdateRelayCommands();
            }
        }

           
        public NameViewModel()
        {
            Name = string.Empty;
           
            NewNameCommand = new RelayCommand(NewExecute);
            ShowNameCommand = new RelayCommand(ShowExecute, ShowCanExecute);
            MakeNameEmptyCommand = new RelayCommand(EmptyExecute, EmptyCanExecute);
        }

        private void UpdateRelayCommands()
        {
            if (NewNameCommand != null)
            {
                NewNameCommand.Update();
            }
            if (ShowNameCommand != null)
            {
                ShowNameCommand.Update();
            }
            if (MakeNameEmptyCommand != null)
            {
                MakeNameEmptyCommand.Update();
            }
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

        private void EmptyExecute()
        {
            Name = string.Empty;
        }

        private bool EmptyCanExecute()
        {
            return !String.IsNullOrEmpty(Name);
        }

       

    }
}
