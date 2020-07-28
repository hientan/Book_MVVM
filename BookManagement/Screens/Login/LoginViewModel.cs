using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BookManagement.Enums;
using BookManagement.Utils;

namespace BookManagement.ViewModel
{
    public class LoginViewModel : BaseScreenViewModel
    {
        IWindowManager manager = new WindowManager();
        /// <summary>
        /// username
        /// </summary>
        private string username;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
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
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
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
        private string textError;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public string TextError
        {
            get { return textError; }
            set
            {
                textError = value;
                NotifyOfPropertyChange(() => TextError);
            }
        }

        /// <summary>
        /// Create new instance.
        public LoginViewModel()
        {
        }

        public void Login()
        {
            string strError = string.Empty;
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                if (!Util.ValidatePassword(Password, out strError))
                {
                    TextError = strError;
                    return;
                }
                var checkLogin = BD.CheckLogin(Username, Password).Select(m => m).FirstOrDefault();
                if (checkLogin != null)
                {
                    string fullname = checkLogin.FirstName + checkLogin.LastName;
                    int role = checkLogin.Role ?? (int)Roles.User;
                    Globals.NameUser = checkLogin.Username;
                    Globals.RoleUser = role;
                    manager.ShowWindow(new StartMainViewModel(fullname, role), null, null);
                    this.TryClose();
                }

                else
                {
                    TextError = Utils.Localization.Instance.GetString(Constant.Constant.Login_001);
                }

            }
        }
        public void Cancel()
        {
            this.TryClose();
        }
        


    }
}