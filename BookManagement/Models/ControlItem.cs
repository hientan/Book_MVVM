using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class ControlItemcbb : BaseScreenViewModel
    {
        /// <summary>
        /// username
        /// </summary>
        private int index;
        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                NotifyOfPropertyChange(() => Index);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string control;
        public string Control
        {
            get { return control; }
            set
            {
                control = value;
                NotifyOfPropertyChange(() => Control);
            }
        }

    }
}
