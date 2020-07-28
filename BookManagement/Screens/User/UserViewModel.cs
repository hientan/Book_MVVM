using BookManagement.Enums;
using BookManagement.Models;
using BookManagement.Utils;
using BookManagement.Constant;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookManagement.ViewModel
{
    public class UserViewModel : BaseScreenViewModel
    {
        #region private property
        /// <summary>
        /// isDelete
        /// </summary>
        private bool isDelete = false;
        #endregion

        #region public Property

        /// <summary>
        /// username
        /// </summary>
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyOfPropertyChange(() => Id);
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
        /// <summary>
        /// Status sort ASC of cardName
        /// </summary>
        private Visibility cardNameAsc = Visibility.Hidden;
        /// <summary>
        /// Status sort DES of cardName
        /// </summary>
        private Visibility cardNameDes = Visibility.Hidden;
        /// <summary>
        /// Status sort ASC of cardControl
        /// </summary>
        private Visibility cardControlAsc = Visibility.Hidden;
        /// <summary>
        /// Status sort DES of cardControl
        /// </summary>
        private Visibility cardControlDes = Visibility.Hidden;
        /// <summary>
        /// Status sort of cardName
        /// </summary>
        public Visibility CardNameAsc
        {
            get { return cardNameAsc; }
            set
            {
                cardNameAsc = value;
                this.NotifyOfPropertyChange(() => this.CardNameAsc);
            }
        }
        /// <summary>
        /// Status sort of cardName
        /// </summary>
        public Visibility CardNameDes
        {
            get { return cardNameDes; }
            set
            {
                cardNameDes = value;
                this.NotifyOfPropertyChange(() => this.CardNameDes);
            }
        }
        /// <summary>
        /// Status sort of cardName
        /// </summary>
        public Visibility CardControlAsc
        {
            get { return cardControlAsc; }
            set
            {
                cardControlAsc = value;
                this.NotifyOfPropertyChange(() => this.CardControlAsc);
            }
        }
        /// <summary>
        /// Status sort of cardName
        /// </summary>
        public Visibility CardControlDes
        {
            get { return cardControlDes; }
            set
            {
                cardControlDes = value;
                this.NotifyOfPropertyChange(() => this.CardControlDes);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private ObservableCollection<User> listUser;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public ObservableCollection<User> ListUser
        {
            get { return listUser; }
            set
            {
                listUser = value;
                NotifyOfPropertyChange(() => ListUser);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private ObservableCollection<ControlItemcbb> cbbRole;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public ObservableCollection<ControlItemcbb> CbbRole
        {
            get { return cbbRole; }
            set
            {
                cbbRole = value;
                NotifyOfPropertyChange(() => CbbRole);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private int selectitem = 0;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public int Selectitem
        {
            get { return selectitem; }
            set
            {
                selectitem = value;
                NotifyOfPropertyChange(() => Selectitem);
            }
        }

        /// <summary>
        /// listUserDefaut
        /// </summary>
        private ObservableCollection<User> listUserDefaut;
        #endregion

        #region Contructor

        public UserViewModel()
        {
            InitCbbRole();
            Initialize();
        }
        #endregion

        #region Private Method


        private void InitCbbRole()
        {
            var a = Utils.Localization.Instance.GetString("");
            ObservableCollection<ControlItemcbb> control = new ObservableCollection<ControlItemcbb>();
            control.Add(new ControlItemcbb() { Index = (int)Roles.User, Control = Utils.Localization.Instance.GetString(Constant.Constant.User_001) });
            control.Add(new ControlItemcbb() { Index = (int)Roles.Contributor, Control = Utils.Localization.Instance.GetString(Constant.Constant.Contributor_001) });
            control.Add(new ControlItemcbb() { Index = (int)Roles.Admin, Control = Utils.Localization.Instance.GetString(Constant.Constant.Admin_001) });
            CbbRole = control;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            var lisst = from a in this.BD.tbl_Users
                        select new User()
                        {
                            ID = a.Id,
                            Username = a.Username,
                            Password = a.Password,
                            Firstname = a.FirstName,
                            Lastname = a.LastName,
                            Role = (int)a.Role,
                            StrRole = (int)a.Role == (int)Roles.Admin ? Utils.Localization.Instance.GetString(Constant.Constant.Admin_001)
: (int)a.Role == (int)Roles.Contributor ? Utils.Localization.Instance.GetString(Constant.Constant.Contributor_001)
: Utils.Localization.Instance.GetString(Constant.Constant.User_001)

                        };
            listUserDefaut = new ObservableCollection<User>(lisst.ToList<User>());
            ListUser = new ObservableCollection<User>(listUserDefaut);
        }
        public void SortingEvent(bool typeSort)
        {
            if (typeSort)
            {
                if (this.CardNameAsc == Visibility.Visible && this.CardNameDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListUser = new ObservableCollection<User>(listUserDefaut);
                }
                else if (this.CardNameDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListUser = new ObservableCollection<User>(listUserDefaut.OrderByDescending(m => m.ID));
                    this.CardNameDes = Visibility.Visible;
                }
                else
                {
                    this.DisableSortIcon();
                    this.ListUser = new ObservableCollection<User>(listUserDefaut.OrderBy(m => m.ID));
                    this.CardNameAsc = Visibility.Visible;
                }
            }
            else
            {
                if (this.CardControlAsc == Visibility.Visible && this.CardControlDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListUser = new ObservableCollection<User>(listUserDefaut);
                }
                else if (this.CardControlDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListUser = new ObservableCollection<User>(listUserDefaut.OrderByDescending(m => m.Username));
                    this.CardControlDes = Visibility.Visible;
                }
                else
                {
                    this.DisableSortIcon();
                    this.ListUser = new ObservableCollection<User>(listUserDefaut.OrderBy(m => m.Username));
                    this.CardControlAsc = Visibility.Visible;
                }
            }
        }
        /// <summary>
        /// Disable Sort Icon
        /// </summary>
        private void DisableSortIcon()
        {
            this.CardNameAsc = Visibility.Hidden;
            this.CardNameDes = Visibility.Hidden;
            this.CardControlAsc = Visibility.Hidden;
            this.CardControlDes = Visibility.Hidden;
        }
        #endregion

        #region public method

        /// <summary>
        /// Click Control Lable
        /// </summary>
        /// <param name="e"></param>
        /// <param name="dataContext"></param>
        public void ClicklRow(MouseButtonEventArgs e, object dataContext)
        {
            var listUser = (User)dataContext;
            this.Id = listUser.ID;
            this.Username = listUser.Username;
            this.Password = listUser.Password;
            this.Firstname = listUser.Firstname;
            this.Lastname = listUser.Lastname;
            this.Selectitem = listUser.Role;
            this.isDelete = true;
        }

        /// <summary>
        /// AddItem
        /// </summary>
        public void AddItem()
        {
            string strError = string.Empty;
            if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.User_002));
                return;
            }
            if (!Util.ValidatePassword(Password, out strError))
            {
                MessageBox.Show(strError);
                return;
            }
            int isSuccess = this.BD.InsertUser(Username, Password, Firstname, Lastname, Role);
            if (isSuccess == Constant.Constant.Error)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.User_003));
            }
            else
            {
                Initialize();
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.User_004));
            }
        }

        /// <summary>
        /// UpdateItem
        /// </summary>
        public void UpdateItem()
        {
            string strError = string.Empty;
            if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.User_002));
                return;
            }
            if (!Util.ValidatePassword(Password, out strError))
            {
                MessageBox.Show(strError);
                return;
            }

            int isSuccess = this.BD.UpdateUser(Id, Username, Password, Firstname, Lastname, Selectitem);
            if (isSuccess == Constant.Constant.Error)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.User_003));
            }
            else
            {
                Initialize();
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.User_005));
            }
        }

        /// <summary>
        /// DeleteItem
        /// </summary>
        public void DeleteItem()
        {
            if (isDelete == false)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.User_007));
            }
            else
            {
                this.BD.DeleteUser(Id);
                Initialize();
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.User_006));
            }
        }

        
        #endregion
    }
}

