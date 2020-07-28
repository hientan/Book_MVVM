using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BookManagement.Enums;
using BookManagement.Utils;

namespace BookManagement.ViewModel
{
    public class StartMainViewModel : Conductor<object>
    {
        /// <summary>
        /// IWindowManager
        /// </summary>
        IWindowManager manager = new WindowManager();

        /// <summary>
        /// username
        /// </summary>
        private Visibility isOpen;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public Visibility IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                NotifyOfPropertyChange(() => IsOpen);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private string fullName;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                NotifyOfPropertyChange(() => FullName);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private string strRole;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
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
        private string strDate;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public string StrDate
        {
            get { return strDate; }
            set
            {
                strDate = value;
                NotifyOfPropertyChange(() => StrDate);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private Visibility role;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public Visibility Role
        {
            get { return role; }
            set
            {
                role = value;
                NotifyOfPropertyChange(() => Role);
            }
        }


        
        public StartMainViewModel(string fullname, int roles)
        {
            this.IsOpen = Visibility.Hidden;
            this.FullName = fullname;
            this.StrDate = DateTime.Now.ToShortDateString();
            Role = roles != (int)Roles.Admin ? Visibility.Collapsed : Visibility.Visible;
            this.StrRole = roles == (int)Roles.Admin ? Utils.Localization.Instance.GetString(Constant.Constant.Admin_001)
                           : roles == (int)Roles.Contributor ? Utils.Localization.Instance.GetString(Constant.Constant.Contributor_001)
                           : Utils.Localization.Instance.GetString(Constant.Constant.User_001);

            ActivateItem(new ChangePasswordViewModel());
        }

        #region public method
        /// <summary>
        /// 
        /// </summary>
        public void OnMenu()
        {
            IsOpen = IsOpen == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }
        public void SignOut()
        {
            manager.ShowWindow(new LoginViewModel(), null, null);
            this.TryClose();
        }

        /// <summary>
        /// Navigate Screen
        /// </summary>
        /// <param name="command"></param>
        public void LeftMenu(string command)
        {
            ScreenId fea = ScreenId.None;
            if (!string.IsNullOrEmpty(command))
            {
                Enum.TryParse(command, out fea);
            }
            switch (fea)
            {
                case ScreenId.SrcBook:
                    ActivateItem(new BookViewModel());
                    break;
                case ScreenId.SrcUser:
                    ActivateItem(new UserViewModel());
                    break;
                case ScreenId.SrcChangePass:
                    ActivateItem(new ChangePasswordViewModel());
                    break;
                case ScreenId.SrcAuthor:
                    ActivateItem(new AuthorViewModel());
                    break;
                case ScreenId.SrcCategoty:
                    ActivateItem(new CategoryViewModel());
                    break;
            }
        }
        #endregion

    }
}