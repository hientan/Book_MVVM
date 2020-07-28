using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class Category : BaseScreenViewModel
    {
        /// <summary>
        /// username
        /// </summary>
        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                NotifyOfPropertyChange(() => ID);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }
        
    }
}
