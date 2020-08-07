using BimCheck.Common;
using BimCheck.IBll;
using BimCheck.IDal;
using BimCheck.Model.Dto;
using BimCheck.Model.Entity;
using BimCheck.Model.Search;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Bll
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/16 9:53:43
    /// 描述：
    /// </summary>
    public class UserService : ServiceBase, IUserService
    {
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="dataRepository"></param>
        public UserService(IDataRepository dataRepository)
        {
            DataRepository = dataRepository;
        }

        /// <summary>
        /// 根据用户名和密码查询用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public T_UserDto LoginByUsername(T_UserSingleModel model)
        {
            var password = MD5Helper.ComputeMD5(model.Password);

            string sql = "SELECT * FROM T_USER WHERE USERNAME = @P_USERNAME AND PASSWORD= @P_PASSWORD";

            var user = DataRepository.GetFirstOrDefault<T_User>(sql, new { P_USERNAME = model.Username, P_PASSWORD = password });

            return AutoMapperHelper<T_User, T_UserDto>.AutoConvert(user);
        }
    }
}
