using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class User : BaseScreenViewModel
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
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
                NotifyOfPropertyChange(() => Firstname);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string lastname;
        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                NotifyOfPropertyChange(() => Lastname);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string strRole;
        public string StrRole
        {
            get { return strRole; }
            set
            {
                strRole = value;
                NotifyOfPropertyChange(() => StrRole);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private int role;
        public int Role
        {
            get { return role; }
            set
            {
                role = value;
                NotifyOfPropertyChange(() => Role);
            }
        }
    }
}

