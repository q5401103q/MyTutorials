using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Model.Entity
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class T_User
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 手机绑定时间
        /// </summary>
        public DateTime? MobileBindDate { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 邮箱绑定时间
        /// </summary>
        public DateTime? EmailBindDate { get; set; }
        /// <summary>
        /// 性别，0=未知，1=男，2=女
        /// </summary>
        public sbyte Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 头像缩略图
        /// </summary>
        public string Thumbnail { get; set; }
        /// <summary>
        /// 有效标志，0=无效用户，1=有效用户
        /// </summary>
        public sbyte Enabled { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        public string CreatedUserId { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// 更新人ID
        /// </summary>
        public string UpdatedUserId { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastestLogonDate { get; set; }
    }
}
