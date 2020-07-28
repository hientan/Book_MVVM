using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookManagement.Models;
using BookManagement.Enums;

namespace BookManagement
{
    public class BaseScreenViewModel : Screen
    {
        public DBBookDataContext BD = new DBBookDataContext();

        
    }
}