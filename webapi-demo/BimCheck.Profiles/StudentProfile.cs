using AutoMapper;
using BimCheck.Model.Dto;
using BimCheck.Model.Entity;
using BimCheck.Model.Search;

namespace BimCheck.Profiles
{
    /// <summary>
    /// 作者：liuzl 
    /// 时间：2020/6/15 9:58:08
    /// 描述：
    /// </summary>
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(source => source.Name, target => target.MapFrom(_ => _.Sname))
                .ForMember(source => source.Age, target => target.MapFrom(_ => _.Sage))
                .ForMember(source => source.Id, target => target.MapFrom(_ => _.SId));

            CreateMap<StudentSingleModel, Student>()
                .ForMember(source => source.Sname, target => target.MapFrom(_ => _.Name))
                .ForMember(source => source.Ssex, target => target.MapFrom(_ => _.Sex))
                .ForMember(source => source.SId, target => target.MapFrom(_ => _.Id))
                .ForMember(source => source.Sage, target => target.MapFrom(_=> _.Age));

        }
    }
}
