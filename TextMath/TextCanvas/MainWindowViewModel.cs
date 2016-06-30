using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextCanvas
{
    public class MainWindowViewModel:ViewModelBase
    {
        private BindingCommand charInputCommand;

        public MainWindowViewModel()
        {
            charInputCommand = new BindingCommand(InputChar, null);
        }

        public BindingCommand CharInputCommand
        {
            get { return charInputCommand; }
            set { charInputCommand = value; this.OnPropertyChanged("CharInputCommand"); }
        }

        private void InputChar(object obj)
        {
            if (null!=obj)
            {
                string inputChar = obj.ToString();
            }
            


        }

        private bool CanInputChar(object obj)
        {
            return true;
        }

    }
}
