using BookManagement.Enums;
using BookManagement.Models;
using BookManagement.Utils;
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
    public class CategoryViewModel : BaseScreenViewModel
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
        private string titleCategory;
        public string TitleCategory
        {
            get { return titleCategory; }
            set
            {
                titleCategory = value;
                NotifyOfPropertyChange(() => TitleCategory);
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
        /// username
        /// </summary>
        private ObservableCollection<Category> listCategory;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public ObservableCollection<Category> ListCategory
        {
            get { return listCategory; }
            set
            {
                listCategory = value;
                NotifyOfPropertyChange(() => ListCategory);
            }
        }
        

        /// <summary>
        /// listUserDefaut
        /// </summary>
        private ObservableCollection<Category> listCategoryDefaut;
        #endregion

        #region Contructor

        public CategoryViewModel()
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
            var lisst = from a in this.BD.tbl_Categories
                        select new Category()
                        {
                            ID = a.Id,
                            Title = a.Title,
                        };
            listCategoryDefaut = new ObservableCollection<Category>(lisst.ToList<Category>());
            ListCategory = new ObservableCollection<Category>(listCategoryDefaut);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeSort"></param>
        public void SortingEvent(bool typeSort)
        {
            if (typeSort)
            {
                if (this.CardNameAsc == Visibility.Visible && this.CardNameDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListCategory = new ObservableCollection<Category>(listCategoryDefaut);
                }
                else if (this.CardNameDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListCategory = new ObservableCollection<Category>(listCategoryDefaut.OrderByDescending(m => m.ID));
                    this.CardNameDes = Visibility.Visible;
                }
                else
                {
                    this.DisableSortIcon();
                    this.ListCategory = new ObservableCollection<Category>(listCategoryDefaut.OrderBy(m => m.ID));
                    this.CardNameAsc = Visibility.Visible;
                }
            }
            else
            {
                if (this.CardControlAsc == Visibility.Visible && this.CardControlDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListCategory = new ObservableCollection<Category>(listCategoryDefaut);
                }
                else if (this.CardControlDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListCategory = new ObservableCollection<Category>(listCategoryDefaut.OrderByDescending(m => m.Title));
                    this.CardControlDes = Visibility.Visible;
                }
                else
                {
                    this.DisableSortIcon();
                    this.ListCategory = new ObservableCollection<Category>(listCategoryDefaut.OrderBy(m => m.Title));
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
            var listUser = (Category)dataContext;
            this.Id = listUser.ID;
            this.TitleCategory = listUser.Title;
            this.isDelete = true;
        }

        /// <summary>
        /// AddItem
        /// </summary>
        public void AddItem()
        {

            if (string.IsNullOrEmpty(this.TitleCategory))
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Category_001));
                return;
            }
            int isSuccess = this.BD.InsertCategory(TitleCategory);
            if (isSuccess == Constant.Constant.Error)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Category_002));
            }
            else
            {
                Initialize();
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Category_003));
            }
        }

        /// <summary>
        /// UpdateItem
        /// </summary>
        public void UpdateItem()
        {

            if (string.IsNullOrEmpty(this.TitleCategory))
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Category_001));
                return;
            }
            int isSuccess = this.BD.UpdateCategory(Id, TitleCategory);
            if (isSuccess == Constant.Constant.Error)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Category_002));
            }
            else
            {
                Initialize();
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Category_004));
            }
        }

        /// <summary>
        /// DeleteItem
        /// </summary>
        public void DeleteItem()
        {
            if (isDelete == false)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Category_006));
            }
            else
            {
                this.BD.DeleteCategory(Id);
                Initialize();
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Category_005));
            }
        }
        #endregion
    }
}
