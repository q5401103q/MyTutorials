using AutoMapper;
using BimCheck.IDal;
using DapperExtensions;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.IBll
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:30:33
    /// 描述：
    /// </summary>
    public abstract class ServiceBase : IService
    {
        private IDataRepository _dataRepository;
        private Logger _logger;

        /// <summary>
        /// 基础数据操作接口
        /// </summary>
        public IDataRepository DataRepository
        {
            get
            {
                return _dataRepository;
            }
            set
            {
                _dataRepository = value;
            }
        }

        /// <summary>
        /// 日志
        /// </summary>
        public Logger logger
        {
            get
            {
                return _logger;
            }
            set
            {
                _logger = value;
            }
        }

        /// <summary>
        /// 按Id获取
        /// </summary>
        /// <param name="primaryId">主键Id</param>
        /// <returns>业务对象</returns>
        public T1 GetById<T1, T2>(dynamic primaryId)
            where T1 : class
            where T2 : class
        {
            T2 t2 = _dataRepository.GetById<T2>(primaryId);
            return AutoMapperHelper<T2, T1>.AutoConvert(t2);
        }

        /// <summary>
        /// 全部获取
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T1> GetAll<T1, T2>()
            where T1 : class
            where T2 : class
        {
            IEnumerable<T2> dataList = _dataRepository.GetAll<T2>();
            IEnumerable<T1> entityList = dataList.Select(Mapper.Map<T1>);
            return entityList;
        }

        /// <summary>
        /// 按条件获取
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public IEnumerable<T1> Get<T1, T2>(string sql, dynamic param = null)
            where T1 : class
            where T2 : class
        {
            IEnumerable<T2> dataList = _dataRepository.Get<T2>(sql, param);
            IEnumerable<T1> entityList = dataList.Select(Mapper.Map<T1>);
            return entityList;
        }

        /// <summary>
        /// 表达式获取方法
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="map"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public IEnumerable<TReturn> Get<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null)
        {
            return _dataRepository.Get<TFirst, TSecond, TReturn>(sql, map, param);
        }

        /// <summary>
        /// 分页获取，条件排序
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="allRowsCount"></param>
        /// <param name="predicate"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IEnumerable<T1> GetPage<T1, T2>(int pageIndex, int pageSize, out long allRowsCount,
            IPredicate predicate = null, IList<ISort> sort = null)
            where T1 : class
            where T2 : class
        {
            IEnumerable<T2> dataList = _dataRepository.GetPage<T2>(pageIndex, pageSize, out allRowsCount, predicate, sort);
            IEnumerable<T1> entityList = dataList.Select(Mapper.Map<T1>);
            return entityList;
        }
    }
}
