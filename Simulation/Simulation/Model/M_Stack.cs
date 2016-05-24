using Caliburn.Micro;

namespace Simulation.ViewModels
{
    public class M_Stack : Screen
    {
        private string _Column_Stacknumber;
        private string _Column_Value;

        public string Column_Stacknumber
        {
            get
            {
                return _Column_Stacknumber;
            }

            set
            {
                _Column_Stacknumber = value;
                NotifyOfPropertyChange(() => Column_Stacknumber);
            }
        }
        public string Column_Value
        {
            get
            {
                return _Column_Value;
            }

            set
            {
                _Column_Value = value;
                NotifyOfPropertyChange(() => Column_Value);
            }
        }
    }
}