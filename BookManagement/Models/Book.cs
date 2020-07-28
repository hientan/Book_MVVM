using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class Book : BaseScreenViewModel
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
        /// <summary>
        /// username
        /// </summary>
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string author;
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                NotifyOfPropertyChange(() => Author);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string creator;
        public string Creator
        {
            get { return creator; }
            set
            {
                creator = value;
                NotifyOfPropertyChange(() => Creator);
            }
        }
        /// <summary>
        /// username
        /// </summary>
        private string categories;
        public string Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                NotifyOfPropertyChange(() => Categories);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private string cover;
        public string Cover
        {
            get { return cover; }
            set
            {
                cover = value;
                NotifyOfPropertyChange(() => Cover);
            }
        }

        /// <summary>
        /// username
        /// </summary>
        private string content;
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                NotifyOfPropertyChange(() => Content);
            }
        }
    }
}
