using BimCheck.Common;
using BimCheck.IBll;
using BimCheck.IDal;
using BimCheck.Model.Dto;
using BimCheck.Model.Entity;
using BimCheck.Model.Search;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BimCheck.Bll
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:53:43
    /// 描述：
    /// </summary>
    public class TestService : ServiceBase, ITestService
    {
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="dataRepository"></param>
        public TestService(IDataRepository dataRepository)
        {
            DataRepository = dataRepository;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentDto GetStudentById(string id)
        {
            var student = DataRepository.Get<Student>(id);
            return AutoMapperHelper<Student, StudentDto>.AutoConvert(student);
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IEnumerable<StudentDto> GetStudentsByCondition(StudentSingleModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM DBO.STUDENT ");
            sb.Append("WHERE 1=1 ");
            if (!string.IsNullOrEmpty(model.Name))
            {
                sb.Append("AND SNAME LIKE @TMP_NAME ");
            }
            sb.Append("ORDER BY SID");

            var students = DataRepository.GetList<Student>(sb.ToString(), new { TMP_NAME = $"%{model.Name}%" });

            return AutoMapperHelper<IEnumerable<Student>, IEnumerable<StudentDto>>.AutoConvert(students);
        }

        /// <summary>
        /// 根据ID列表查询数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<StudentDto> GetStudentsByIds(List<dynamic> ids)
        {
            var sql = "SELECT * FROM DBO.STUDENT WHERE SID IN ('@ids')";

            var idsIn = string.Join("','", ids);

            var students = DataRepository.GetList<Student>(sql, new { ids = idsIn });

            return AutoMapperHelper<IEnumerable<Student>, IEnumerable<StudentDto>>.AutoConvert(students);
        }

        /// <summary>
        /// 级联查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic GetStudentScore(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ROW_NUMBER() OVER(ORDER BY SC.SID) AS NUM, ");
            sb.Append("STU.SNAME, CO.CNAME, SC.SCORE ");
            sb.Append("FROM SC SC ");
            sb.Append("LEFT JOIN STUDENT STU ");
            sb.Append("ON SC.SID = STU.SID ");
            sb.Append("LEFT JOIN COURSE CO ");
            sb.Append("ON SC.CID = CO.CID ");
            sb.Append("WHERE SC.SID=@TMP_ID");

            var data = DataRepository.GetList<dynamic>(sb.ToString(), new { TMP_ID = id });

            return AutoMapperHelper<dynamic, dynamic>.AutoConvertDynamic(data);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PagedDto GetStudentsPagination(StudentPagedModel model)
        {
            var predicateGroup = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };

            if (!string.IsNullOrEmpty(model.Sex))
            {
                var predicate1 = Predicates.Field<Student>(n => n.Ssex, Operator.Eq, model.Sex);
                predicateGroup.Predicates.Add(predicate1);
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                var predicate2 = Predicates.Field<Student>(n => n.Sname, Operator.Like, model.Name);
                predicateGroup.Predicates.Add(predicate2);
            }

            IList<ISort> sort = new List<ISort>
            {
                new Sort() { PropertyName = "sid", Ascending = true },
                new Sort() { PropertyName = "sage", Ascending = false }
            };

            long totalCount = 0L;
            var students = DataRepository.GetPage<Student>(model.PageIndex, model.PageSize, out totalCount, predicateGroup, sort);
            var dataList = AutoMapperHelper<IEnumerable<Student>, IEnumerable<StudentDto>>.AutoConvert(students);

            return new PagedDto()
            {
                Count = totalCount,
                Data = dataList
            };
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public dynamic AddStudent(StudentSingleModel model)
        {
            var transaction = DataRepository.Session.Begin();
            try
            {
                var student = AutoMapperHelper<StudentSingleModel, Student>.AutoConvert(model);
                var itemId = DataRepository.Insert<Student>(student, transaction);
                DataRepository.Session.Commit();

                return itemId;
            }
            catch (Exception ex)
            {
                DataRepository.Session.Rollback();
                logger.Error(ex);

                return string.Empty;
            }
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteStudent(StudentSingleModel model)
        {
            var transaction = DataRepository.Session.Begin();
            try
            {
                var rowsAffected = DataRepository.Delete<Student>(model.Id, transaction);
                DataRepository.Session.Commit();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                DataRepository.Session.Rollback();
                logger.Error(ex);

                return false;
            }
        }

        /// <summary>
        /// 更新学生
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStudent(StudentSingleModel model)
        {
            var student = DataRepository.Get<Student>(model.Id);
            student.Sage = model.Age;
            student.Sname = model.Name;
            student.Ssex = model.Sex;

            var transaction = DataRepository.Session.Begin();
            try
            {     
                var flag = DataRepository.Update(student, transaction);
                DataRepository.Session.Commit();

                return flag;
            }
            catch (Exception ex)
            {
                DataRepository.Session.Rollback();
                logger.Error(ex);

                return false;
            }
        }
    }
}
