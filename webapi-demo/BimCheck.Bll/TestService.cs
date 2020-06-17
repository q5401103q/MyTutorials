using BimCheck.IBll;
using BimCheck.IDal;
using BimCheck.Model.Dto;
using BimCheck.Model.Entity;
using BimCheck.Model.Search;
using DapperExtensions;
using NLog;
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
        public TestService(IDataRepository dataRepository)
        {
            base.DataRepository = dataRepository;
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentDto GetStudentById(string id)
        {
            return this.GetById<StudentDto, Student>(id);
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

            return this.Get<StudentDto, Student>(sb.ToString(), new { TMP_NAME = $"%{model.Name}%" });
        }

        /// <summary>
        /// 根据ID列表查询数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public IEnumerable<StudentDto> GetStudentsByIds(List<dynamic> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM DBO.STUDENT WHERE SID IN (@ids)");

            var idsIn = $"'{string.Join("','", ids)}'";

            return this.Get<StudentDto, Student>(sb.ToString(), new { ids = idsIn });
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

            return base.Get<dynamic, dynamic>(sb.ToString(), new { TMP_ID = id });
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

            var dataList = this.GetPage<StudentDto, Student>(model.PageIndex, model.PageSize, out long totalCount, predicateGroup, sort);
            return new PagedDto()
            {
                count = totalCount,
                data = dataList
            };
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public dynamic AddStudent(StudentSingleModel model)
        {
            var transaction = base.DataRepository.Session.Begin();
            try
            {
                var student = AutoMapperHelper<StudentSingleModel, Student>.AutoConvert(model);
                var itemId = base.DataRepository.Insert<Student>(student, transaction);
                base.DataRepository.Session.Commit();

                return itemId;
            }
            catch (Exception ex)
            {
                base.DataRepository.Session.Rollback();
                logger.Error(ex);

                return 0;
            }
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteStudent(StudentSingleModel model)
        {
            var transaction = base.DataRepository.Session.Begin();
            try
            {
                var rowsAffected = base.DataRepository.Delete<Student>(model.Id, transaction);
                base.DataRepository.Session.Commit();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                base.DataRepository.Session.Rollback();
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
            var student = this.DataRepository.GetById<Student>(model.Id);
            student.Sage = model.Age;
            student.Sname = model.Name;
            student.Ssex = model.Sex;

            var transaction = base.DataRepository.Session.Begin();
            try
            {     
                var flag = this.DataRepository.Update(student, transaction);
                base.DataRepository.Session.Commit();

                return flag;
            }
            catch (Exception ex)
            {
                base.DataRepository.Session.Rollback();
                logger.Error(ex);

                return false;
            }
        }
    }
}
