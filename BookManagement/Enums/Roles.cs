using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Enums
{
    public enum Roles
    {
        User = 0,
        Contributor = 1,
        Admin = 2,
    }
    public enum ScreenId
    {
        None,
        SrcBook,
        SrcUser,
        SrcChangePass,
        SrcAuthor,
        SrcCategoty,
    }
}
