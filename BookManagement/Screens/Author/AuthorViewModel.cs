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
    public class AuthorViewModel : BaseScreenViewModel
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
        private string nameAuthor;
        public string NameAuthor
        {
            get { return nameAuthor; }
            set
            {
                nameAuthor = value;
                NotifyOfPropertyChange(() => NameAuthor);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private DateTime birthdayAuthor = DateTime.Now;
        public DateTime BirthdayAuthor
        {
            get { return birthdayAuthor; }
            set
            {
                birthdayAuthor = value;
                NotifyOfPropertyChange(() => BirthdayAuthor);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string addressAuthor;
        public string AddressAuthor
        {
            get { return addressAuthor; }
            set
            {
                addressAuthor = value;
                NotifyOfPropertyChange(() => AddressAuthor);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string websiteAuthor;
        public string WebsiteAuthor
        {
            get { return websiteAuthor; }
            set
            {
                websiteAuthor = value;
                NotifyOfPropertyChange(() => WebsiteAuthor);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private bool isEnable;
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                NotifyOfPropertyChange(() => IsEnable);
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
        private ObservableCollection<Author> listAuthor;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public ObservableCollection<Author> ListAuthor
        {
            get { return listAuthor; }
            set
            {
                listAuthor = value;
                NotifyOfPropertyChange(() => ListAuthor);
            }
        }
        

        /// <summary>
        /// listUserDefaut
        /// </summary>
        private ObservableCollection<Author> listAuthorDefaut;
        #endregion

        #region Contructor
        
        public AuthorViewModel()
        {
            Initialize();
            this.IsEnable = Globals.RoleUser != (int)Roles.Admin ? false : true;
        }
        #endregion

        #region Private Method


        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            var lisst = from a in this.BD.tbl_Authors select new Author()
            {
                ID = a.Id,
                Name = a.Name,
                Birthday = a.Birthday ?? DateTime.Now,
                Address = a.Address,
                Website = a.Website,
                
            };
            listAuthorDefaut = new ObservableCollection<Author>(lisst.ToList<Author>());
            ListAuthor = new ObservableCollection<Author>(listAuthorDefaut);
        }
        public void SortingEvent(bool typeSort)
        {
            if (typeSort)
            {
                if (this.CardNameAsc == Visibility.Visible && this.CardNameDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListAuthor = new ObservableCollection<Author>(listAuthorDefaut);
                }
                else if (this.CardNameDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListAuthor = new ObservableCollection<Author>(listAuthorDefaut.OrderByDescending(m => m.ID));
                    this.CardNameDes = Visibility.Visible;
                }
                else
                {
                    this.DisableSortIcon();
                    this.ListAuthor = new ObservableCollection<Author>(listAuthorDefaut.OrderBy(m => m.ID));
                    this.CardNameAsc = Visibility.Visible;
                }
            }
            else
            {
                if (this.CardControlAsc == Visibility.Visible && this.CardControlDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListAuthor = new ObservableCollection<Author>(listAuthorDefaut);
                }
                else if (this.CardControlDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListAuthor = new ObservableCollection<Author>(listAuthorDefaut.OrderByDescending(m => m.Name));
                    this.CardControlDes = Visibility.Visible;
                }
                else
                {
                    this.DisableSortIcon();
                    this.ListAuthor = new ObservableCollection<Author>(listAuthorDefaut.OrderBy(m => m.Name));
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
            var listAuthor = (Author)dataContext;
            this.Id = listAuthor.ID;
            this.NameAuthor = listAuthor.Name;
            this.BirthdayAuthor = listAuthor.Birthday;
            this.AddressAuthor = listAuthor.Address;
            this.WebsiteAuthor = listAuthor.Website;
            this.isDelete = true;
        }

        /// <summary>
        /// AddItem
        /// </summary>
        public void AddItem()
        {
            
            if(string.IsNullOrEmpty(this.NameAuthor))
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Author_001));
                return;
            }
            int isSuccess =  this.BD.InsertAuthor(NameAuthor, BirthdayAuthor, AddressAuthor, WebsiteAuthor);
            if(isSuccess == Constant.Constant.Error)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Author_002));
            }
            else
            {
                Initialize();
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Author_003));
            }
        }

        /// <summary>
        /// UpdateItem
        /// </summary>
        public void UpdateItem()
        {

            if (string.IsNullOrEmpty(this.NameAuthor))
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Author_001));
                return;
            }
            int isSuccess = this.BD.UpdateAuthor(Id, NameAuthor, BirthdayAuthor, AddressAuthor, WebsiteAuthor);
            if (isSuccess == Constant.Constant.Error)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Author_002));
            }
            else
            {
                Initialize();
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Author_004));
            }
        }

        /// <summary>
        /// DeleteItem
        /// </summary>
        public void DeleteItem()
        {
            if(isDelete == false)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Author_006));
            }
            else
            {
                this.BD.DeleteAuthor(Id);
                Initialize();
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Author_005));
            }
        }
        #endregion
    }
}

