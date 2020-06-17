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

        #region 查询
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId"></param>
        /// <returns></returns>
        public T GetById<T>(dynamic primaryId, IDbTransaction transaction = null) where T : class
        {
            return _session.Connection.Get<T>(primaryId as object, transaction);
        }

        /// <summary>
        /// 获取全部数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _session.Connection.GetList<T>();
        }

        /// <summary>
        /// 根据条件筛选出数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> Get<T>(string sql, dynamic param = null, bool buffered = true) where T : class
        {
            return SqlMapper.Query<T>(_session.Connection, sql, param as object, _session.Transaction, buffered);
        }

        /// <summary>
        /// 根据条件筛选数据集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<dynamic> Get(string sql, dynamic param = null, bool buffered = true)
        {
            return SqlMapper.Query(_session.Connection, sql, param as object, _session.Transaction, buffered);
        }

        /// <summary>
        /// 统计记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public int Count<T>(IPredicate predicate, bool buffered = false) where T : class
        {
            return _session.Connection.Count<T>(predicate);
        }

        /// <summary>
        /// 查询列表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList<T>(IPredicate predicate = null, IList<ISort> sort = null, bool buffered = false) where T : class
        {
            return _session.Connection.GetList<T>(predicate, sort, null, null, buffered);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="allRowsCount"></param>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetPage<T>(int pageIndex, int pageSize, out long allRowsCount, IPredicate predicate = null, ISort sort = null, bool buffered = true) where T : class
        {
            IList<ISort> orderBy = new List<ISort>();
            orderBy.Add(sort);

            return GetPage<T>(pageIndex, pageSize, out allRowsCount, predicate, orderBy, buffered);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="allRowsCount"></param>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <param name="buffered"></param>
        /// <returns></returns>
        public IEnumerable<T> GetPage<T>(int pageIndex, int pageSize, out long allRowsCount, IPredicate predicate, IList<ISort> sort, bool buffered = true) where T : class
        {
            IEnumerable<T> entityList = _session.Connection.GetPage<T>(predicate, sort, pageIndex, pageSize, null, null, buffered);
            allRowsCount = _session.Connection.Count<T>(predicate);

            return entityList;
        }

        /// <summary>
        /// 根据表达式筛选
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="buffered"></param>
        /// <param name="splitOn"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public IEnumerable<TReturn> Get<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null)
        {
            return SqlMapper.Query(_session.Connection, sql, map, param as object, transaction, buffered, splitOn);
        }

        /// <summary>
        /// 获取多实体集合
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public SqlMapper.GridReader GetMultiple(string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 执行
        /// <summary>
        /// 执行sql操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns>受影响的行数</returns>
        public int Execute(string sql, dynamic param = null, IDbTransaction transaction = null)
        {
            return _session.Connection.Execute(sql, param as object, transaction);
        }
        #endregion

        #region 插入
        /// <summary>
        /// 插入单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public dynamic Insert<T>(T entity, IDbTransaction transaction = null) where T : class
        {
            return _session.Connection.Insert<T>(entity, transaction);
        }
        #endregion

        #region 更新
        /// <summary>
        /// 更新单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update<T>(T entity, IDbTransaction transaction = null) where T : class
        {
            return _session.Connection.Update<T>(entity, transaction);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryId">主键</param>
        /// <returns></returns>
        public bool Delete<T>(dynamic primaryId, IDbTransaction transaction = null) where T : class
        {
            var entity = GetById<T>(primaryId, transaction);
            var obj = entity as T;
            return _session.Connection.Delete<T>(obj, transaction);
        }

        /// <summary>
        /// 删除单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete<T>(IPredicate predicate, IDbTransaction transaction = null) where T : class
        {
            return _session.Connection.Delete<T>(predicate, transaction);
        }
        #endregion
    }
}
