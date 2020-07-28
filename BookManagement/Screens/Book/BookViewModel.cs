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
using Microsoft.Win32;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Drawing;
using System.IO;

namespace BookManagement.ViewModel
{
    public class BookViewModel : BaseScreenViewModel
    {
        #region private property
        /// <summary>
        /// isDelete
        /// </summary>
        private bool isDelete = false;

        /// <summary>
        /// path
        /// </summary>
        private string path;

        /// <summary>
        /// nameIname
        /// </summary>
        private string nameIname = string.Empty;

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
        private string titleBook;
        public string TitleBook
        {
            get { return titleBook; }
            set
            {
                titleBook = value;
                NotifyOfPropertyChange(() => TitleBook);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string descriptionBook;
        public string DescriptionBook
        {
            get { return descriptionBook; }
            set
            {
                descriptionBook = value;
                NotifyOfPropertyChange(() => DescriptionBook);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string authorBook;
        public string AuthorBook
        {
            get { return authorBook; }
            set
            {
                authorBook = value;
                NotifyOfPropertyChange(() => AuthorBook);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string categoriesBook;
        public string CategoriesBook
        {
            get { return categoriesBook; }
            set
            {
                categoriesBook = value;
                NotifyOfPropertyChange(() => CategoriesBook);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string contentBook;
        public string ContentBook
        {
            get { return contentBook; }
            set
            {
                contentBook = value;
                NotifyOfPropertyChange(() => ContentBook);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private string fileImage;
        public string FileImage
        {
            get { return fileImage; }
            set
            {
                fileImage = value;
                NotifyOfPropertyChange(() => FileImage);
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
        private ObservableCollection<Book> listBook;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public ObservableCollection<Book> ListBook
        {
            get { return listBook; }
            set
            {
                listBook = value;
                NotifyOfPropertyChange(() => ListBook);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private ObservableCollection<ControlItemcbb> cbbAuthor;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public ObservableCollection<ControlItemcbb> CbbAuthor
        {
            get { return cbbAuthor; }
            set
            {
                cbbAuthor = value;
                NotifyOfPropertyChange(() => CbbAuthor);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private int selectitemAuthor = 0;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public int SelectitemAuthor
        {
            get { return selectitemAuthor; }
            set
            {
                selectitemAuthor = value;
                NotifyOfPropertyChange(() => SelectitemAuthor);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private ObservableCollection<ControlItemcbb> cbbCategory;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public ObservableCollection<ControlItemcbb> CbbCategory
        {
            get { return cbbCategory; }
            set
            {
                cbbCategory = value;
                NotifyOfPropertyChange(() => CbbCategory);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private int selectitemCategory = 0;
        /// <summary>
        /// Define total number page content for Binding
        /// </summary>
        public int SelectitemCategory
        {
            get { return selectitemCategory; }
            set
            {
                selectitemCategory = value;
                NotifyOfPropertyChange(() => SelectitemCategory);
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
        /// listBookDefaut
        /// </summary>
        private ObservableCollection<Book> listBookDefaut;
        #endregion

        #region Contructor

        public BookViewModel()
        {
            path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Images");

            InitCbbRole();
            Initialize();
            this.IsEnable = Globals.RoleUser == (int)Roles.User ? false : true;
        }
        #endregion

        #region Private Method


        private void InitCbbRole()
        {

            var listAuthors = from a in this.BD.tbl_Authors
                              select new ControlItemcbb()
                              {
                                  Index = a.Id,
                                  Control = a.Name,
                              };
            ObservableCollection<ControlItemcbb> controlAuthor = new ObservableCollection<ControlItemcbb>(listAuthors.ToList<ControlItemcbb>());
            CbbAuthor = controlAuthor;

            var listCategories = from a in this.BD.tbl_Categories
                                 select new ControlItemcbb()
                                 {
                                     Index = a.Id,
                                     Control = a.Title,
                                 };
            ObservableCollection<ControlItemcbb> controlCategory = new ObservableCollection<ControlItemcbb>(listCategories.ToList<ControlItemcbb>());
            CbbCategory = controlCategory;


        }

        /// <summary>
        /// Initialize()
        /// </summary>
        private void Initialize()
        {
            var lisst = from a in this.BD.tbl_Books
                        join m in this.BD.tbl_Authors
                        on a.Author equals m.Id
                        join c in this.BD.tbl_Categories
                        on a.Categories equals c.Id
                        select new Book()
                        {
                            ID = a.Id,
                            Title = a.Title,
                            Description = a.Description,
                            Author = m.Name,
                            Creator = a.Creator,
                            Categories = c.Title,
                            Cover = path + @"\" + a.Cover,
                            Content = a.Content,

                        };
            listBookDefaut = new ObservableCollection<Book>(lisst.ToList<Book>());
            ListBook = new ObservableCollection<Book>(listBookDefaut);
        }
        public void SortingEvent(bool typeSort)
        {
            if (typeSort)
            {
                if (this.CardNameAsc == Visibility.Visible && this.CardNameDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListBook = new ObservableCollection<Book>(listBookDefaut);
                }
                else if (this.CardNameDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListBook = new ObservableCollection<Book>(listBookDefaut.OrderByDescending(m => m.ID));
                    this.CardNameDes = Visibility.Visible;
                }
                else
                {
                    this.DisableSortIcon();
                    this.ListBook = new ObservableCollection<Book>(listBookDefaut.OrderBy(m => m.ID));
                    this.CardNameAsc = Visibility.Visible;
                }
            }
            else
            {
                if (this.CardControlAsc == Visibility.Visible && this.CardControlDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListBook = new ObservableCollection<Book>(listBookDefaut);
                }
                else if (this.CardControlDes == Visibility.Hidden)
                {
                    this.DisableSortIcon();
                    this.ListBook = new ObservableCollection<Book>(listBookDefaut.OrderByDescending(m => m.Title));
                    this.CardControlDes = Visibility.Visible;
                }
                else
                {
                    this.DisableSortIcon();
                    this.ListBook = new ObservableCollection<Book>(listBookDefaut.OrderBy(m => m.Title));
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


        /// <summary>
        /// CopyFiles
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        private void CopyFiles(string sourcePath, string destinationPath)
        {
            if (!System.IO.Directory.Exists(destinationPath))
            {
                System.IO.Directory.CreateDirectory(destinationPath);
            }
            string newpath = destinationPath + @"\" + nameIname;
            if(!File.Exists(newpath))
            {
                System.IO.File.Copy(sourcePath, newpath, true);
            }
            

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
            var listBook = (Book)dataContext;
            this.Id = listBook.ID;
            this.TitleBook = listBook.Title;
            this.DescriptionBook = listBook.Description;
            this.SelectitemAuthor = CbbAuthor.IndexOf(CbbAuthor.Where(n => n.Control == listBook.Author).FirstOrDefault());
            this.SelectitemCategory = CbbCategory.IndexOf(CbbCategory.Where(n => n.Control == listBook.Categories).FirstOrDefault());
            this.ContentBook = listBook.Content;
            this.FileImage = listBook.Cover;
            this.nameIname = System.IO.Path.GetFileName(FileImage);
            this.isDelete = true;
        }

        /// <summary>
        /// Read File Word
        /// </summary>
        public void ReadFileWord()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Open Word File";
            openFileDialog1.Filter = "Word File (.docx ,.doc)|*.docx;*.doc|PDF File (.pdf)|*.pdf";
            Nullable<bool> result = openFileDialog1.ShowDialog();
            if (result == true)
            {
                if (openFileDialog1.FilterIndex == 2)
                {
                    StringBuilder text = new StringBuilder();
                    using (PdfReader reader = new PdfReader(openFileDialog1.FileName))
                    {
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }
                    }
                    ContentBook = text.ToString();
                }
                else
                {
                    Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                    Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
                    object fileName = openFileDialog1.FileName;
                    // Define an object to pass to the API for missing parameters
                    object missing = System.Type.Missing;
                    doc = word.Documents.Open(ref fileName, ref missing, ref missing);
                    StringBuilder data = new StringBuilder();
                    for (int i = 0; i < doc.Paragraphs.Count; i++)
                    {
                        string temp = doc.Paragraphs[i + 1].Range.Text.Trim();
                        data.Append(temp);
                        data.Append("\n");
                    }
                    doc.Close();
                    word.Quit();
                    ContentBook = data.ToString();
                }
            }
        }

        /// <summary>
        /// AddItem
        /// </summary>
        public void AddItem()
        {
            if (string.IsNullOrEmpty(this.TitleBook) || string.IsNullOrEmpty(this.DescriptionBook) || CbbAuthor == null)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Book_001));
                return;
            }
            this.BD.InsertBook(TitleBook, DescriptionBook, CbbAuthor[SelectitemAuthor].Index, Globals.NameUser, CbbCategory[SelectitemCategory].Index, nameIname, ContentBook);
            if (!string.IsNullOrEmpty(nameIname))
            {
                CopyFiles(FileImage, path);
            }
            this.nameIname = string.Empty;
            this.FileImage = string.Empty;
            Initialize();
            MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Book_003));

        }

        /// <summary>
        /// UpdateItem
        /// </summary>
        public void UpdateItem()
        {

            if (string.IsNullOrEmpty(this.TitleBook) || string.IsNullOrEmpty(this.DescriptionBook) || CbbAuthor == null)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Book_001));
                return;
            }
            if (Globals.RoleUser == (int)Roles.Contributor && !ListBook.Where(w => w.ID == Id && w.Creator == Globals.NameUser).Any())
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Book_002));
                return;
            }

            int isSuccess = this.BD.UpdateBook(Id, TitleBook, DescriptionBook, CbbAuthor[SelectitemAuthor].Index, CbbCategory[SelectitemCategory].Index, nameIname, ContentBook);
            if (!string.IsNullOrEmpty(nameIname))
            {
                CopyFiles(FileImage, path);
            }
            this.nameIname = string.Empty;
            this.FileImage = string.Empty;
            Initialize();
            MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Book_004));
        }

        /// <summary>
        /// DeleteItem
        /// </summary>
        public void DeleteItem()
        {
            if (isDelete == false)
            {
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Author_006));
            }
            else
            {
                this.BD.DeleteBook(Id);
                Initialize();
                this.nameIname = string.Empty;
                this.FileImage = string.Empty;
                MessageBox.Show(Utils.Localization.Instance.GetString(Constant.Constant.Book_005));
            }
        }

        /// <summary>
        /// Search Item
        /// </summary>
        public void SearchItem()
        {

            var search = (from s in listBookDefaut
                          where (
                              (!string.IsNullOrEmpty(TitleBook) && s.Title.ToLower().Contains(TitleBook)) ||
                              (!string.IsNullOrEmpty(DescriptionBook) && s.Description.ToLower().Contains(DescriptionBook)) ||

                              (string.IsNullOrEmpty(TitleBook) && string.IsNullOrEmpty(DescriptionBook))
                              )

                          select s).ToList();
            ListBook = new ObservableCollection<Book>(search);
        }

        /// <summary>
        /// Read File Image
        /// </summary>
        public void ReadFileImage()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Open Word File";
            openFileDialog1.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";
            Nullable<bool> result = openFileDialog1.ShowDialog();
            if (result == true)
            {
                FileImage = openFileDialog1.FileName;
                nameIname = openFileDialog1.SafeFileName;
                
            }
        }
        #endregion
    }


}

