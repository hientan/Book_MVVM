using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class Author : BaseScreenViewModel
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
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private DateTime birthday;
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                NotifyOfPropertyChange(() => Birthday);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string website;
        public string Website
        {
            get { return website; }
            set
            {
                website = value;
                NotifyOfPropertyChange(() => Website);
            }
        }
    }
}
