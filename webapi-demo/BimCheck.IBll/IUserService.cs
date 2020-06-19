using BimCheck.Model.Dto;
using BimCheck.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.IBll
{
    public interface IUserService
    {
        T_UserDto LoginByUsername(T_UserSingleModel model);
    }
}
