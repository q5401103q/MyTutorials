using BimCheck.Model.Dto;
using BimCheck.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BimCheck.IBll
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:45:49
    /// 描述：
    /// </summary>
    public interface ITestService
    {
        PagedDto GetStudentsPagination(StudentPagedModel model);

        StudentDto GetStudentById(string id);

        IEnumerable<StudentDto> GetStudentsByIds(List<dynamic> ids);

        IEnumerable<StudentDto> GetStudentsByCondition(StudentSingleModel model);

        dynamic GetStudentScore(string id);

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        dynamic AddStudent(StudentSingleModel model);
        /// <summary>
        /// 更新学生
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateStudent(StudentSingleModel model);
        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool DeleteStudent(StudentSingleModel model);
    }
}
