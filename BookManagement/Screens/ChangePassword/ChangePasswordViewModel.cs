using BookManagement.Enums;
using BookManagement.Utils;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookManagement.ViewModel
{
    public class ChangePasswordViewModel : BaseScreenViewModel
    {

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
        private string role;
        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                NotifyOfPropertyChange(() => Role);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private string passwordCurrent;
        public string PasswordCurrent
        {
            get { return passwordCurrent; }
            set
            {
                passwordCurrent = value;
                NotifyOfPropertyChange(() => PasswordCurrent);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private string passwordNew;
        public string PasswordNew
        {
            get { return passwordNew; }
            set
            {
                passwordNew = value;
                NotifyOfPropertyChange(() => PasswordNew);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private string passwordComfirm;
        public string PasswordComfirm
        {
            get { return passwordComfirm; }
            set
            {
                passwordComfirm = value;
                NotifyOfPropertyChange(() => PasswordComfirm);
            }
        }


        public ChangePasswordViewModel()
        {
            Initialize();
        }
        private void Initialize()
        {
            var list = this.BD.tbl_Users.Where(m => m.Username == Globals.NameUser).FirstOrDefault();
            if (list != null)
            {
                this.Username = list.Username;
                this.Firstname = list.FirstName;
                this.Lastname = list.LastName;
                this.Role = list.Role == (int)Roles.Admin ? Utils.Localization.Instance.GetString(Constant.Constant.Admin_001)
                          : list.Role == (int)Roles.Contributor ? Utils.Localization.Instance.GetString(Constant.Constant.Contributor_001)
                          : Utils.Localization.Instance.GetString(Constant.Constant.User_001);
            }

        }

        public void ChangeInfo()
        {
            BD.UpdateInfoUser(Username, Firstname, Lastname);
            MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.ChangePassword_001));
        }

        public void ChangePass()
        {
            string strError = string.Empty;
            if (string.IsNullOrEmpty(PasswordCurrent) || string.IsNullOrEmpty(PasswordNew) || string.IsNullOrEmpty(PasswordComfirm))
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.ChangePassword_002));
                return;
            }
            if(PasswordNew != PasswordComfirm)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.ChangePassword_003));
                return;
            }
            if (!Util.ValidatePassword(PasswordNew, out strError))
            {
                MessageBox.Show(strError);
                return;
            }
            int isSuccess = this.BD.UpdatePasswordUser(Username, PasswordCurrent, PasswordNew);
            if (isSuccess == Constant.Constant.Error)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.ChangePassword_004));
            }
            else
            {
                PasswordCurrent = string.Empty;
                PasswordNew = string.Empty;
                PasswordComfirm = string.Empty;
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.ChangePassword_005));
            }

        }






    }
}