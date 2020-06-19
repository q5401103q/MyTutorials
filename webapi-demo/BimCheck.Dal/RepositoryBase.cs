using BimCheck.IDal;
using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.Dal
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:09:50
    /// 描述：
    /// </summary>
    public class RepositoryBase : IDataRepository
    {
        #region 属性
        /// <summary>
        /// 私有变量
        /// </summary>
        private ISession _session { get; }

        /// <summary>
        /// 数据库属性
        /// </summary>
        public ISession Session
        {
            get { return _session; }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public RepositoryBase() { }

        /// <summary>
        /// 带参的构造函数，注入
        /// </summary>
        /// <param name="session"></param>
        public RepositoryBase(ISession session)
        {
            this._session = session;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public T Get<T>(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return _session.Connection.Get<T>(id as object, transaction, commandTimeout);
        }
        /// <summary>
        /// 根据查询语句获取数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sql">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="commandType">操作类型包括文本或存储过程等</param>
        /// <returns></returns>
        public T GetFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) where T : class
        {
            return SqlMapper.QueryFirstOrDefault<T>(_session.Connection, sql, param as object, transaction, commandTimeout, commandType);
        }
        /// <summary>
        /// 根据查询语句获取数据
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="commandType">操作类型包括文本或存储过程等</param>
        /// <returns></returns>
        public dynamic GetFirstOrDefault(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.QueryFirstOrDefault(_session.Connection, sql, param as object, transaction, commandTimeout, commandType);
        }
        /// <summary>
        /// 根据查询语句获取对象列表
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="sql">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="buffered">使用缓存</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="commandType">操作类型包括文本或存储过程等</param>
        /// <returns></returns>
        public IEnumerable<T> GetList<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null) where T : class
        {
            return SqlMapper.Query<T>(_session.Connection, sql, param, transaction, buffered, commandTimeout, commandType);
        }
        /// <summary>
        /// 根据表达式获取对象列表
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <param name="sort">排序字段</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <returns></returns>
        public IEnumerable<T> GetList<T>(object predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = false) where T : class
        {
            return _session.Connection.GetList<T>(predicate, sort, transaction, commandTimeout, buffered);
        }
        /// <summary>
        /// 根据SQL语句获取对象列表
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="param">查询参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="buffered">使用缓存</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="commandType">操作类型包括文本或存储过程等</param>
        /// <returns></returns>
        public IEnumerable<dynamic> GetList(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Query(_session.Connection, sql, param as object, transaction, buffered, commandTimeout, commandType);
        }
        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <returns></returns>
        public int Count<T>(IPredicate predicate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return _session.Connection.Count<T>(predicate, transaction, commandTimeout);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="pageIndex">页码，开始于0</param>
        /// <param name="pageSize">条数</param>
        /// <param name="allRowsCount">总条数</param>
        /// <param name="predicate">表达式</param>
        /// <param name="sort">排序</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="buffered">使用缓冲区</param>
        /// <returns></returns>
        public IEnumerable<T> GetPage<T>(int pageIndex, int pageSize, out long allRowsCount, IPredicate predicate, IList<ISort> sort, IDbTransaction transaction = null, int? commandTimeout = null, bool buffered = false) where T : class
        {
            IEnumerable<T> entityList = _session.Connection.GetPage<T>(predicate, sort, pageIndex, pageSize, transaction, commandTimeout, buffered);
            allRowsCount = _session.Connection.Count<T>(predicate, transaction, commandTimeout);

            return entityList;
        }
        #endregion

        #region 执行SQL
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">语句</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <param name="commandType">类型包括文本或存储过程等</param>
        /// <returns></returns>
        public int Execute(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Execute(_session.Connection, sql, param as object, transaction, commandTimeout, commandType);
        }
        #endregion

        #region 插入操作
        /// <summary>
        /// 插入对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">对象实例</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <returns></returns>
        public dynamic Insert<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return _session.Connection.Insert<T>(entity, transaction, commandTimeout);
        }

        /// <summary>
        /// 批量插入对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entities">对象实例列表</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        public void Insert<T>(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            _session.Connection.Insert<T>(entities, transaction, commandTimeout);
        }
        #endregion

        #region 更新操作
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">对象实例</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <returns></returns>
        public bool Update<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return _session.Connection.Update<T>(entity, transaction, commandTimeout);
        }
        #endregion

        #region 删除操作
        /// <summary>
        /// 根据ID删除对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="id">主键</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <returns></returns>
        public bool Delete<T>(dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var entity = Get<T>(id, transaction);
            var obj = entity as T;
            return _session.Connection.Delete<T>(obj, transaction, commandTimeout);
        }

        /// <summary>
        /// 根据表达式删除对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置（秒）</param>
        /// <returns></returns>
        public bool Delete<T>(IPredicate predicate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return _session.Connection.Delete<T>(predicate, transaction, commandTimeout);
        }

        /// <summary>
        /// 根据实例删除对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="entity">对象实例</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandTimeout">超时设置秒（秒）</param>
        /// <returns></returns>
        public bool Delete<T>(T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            return _session.Connection.Delete<T>(entity, transaction, commandTimeout);
        }
        #endregion
    }
}
