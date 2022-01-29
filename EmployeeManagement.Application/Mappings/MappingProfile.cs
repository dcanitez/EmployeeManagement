using AutoMapper;
using EmployeeManagement.Application.Models.Employee;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeCreateModel, Employee>();
            CreateMap<EmployeeUpdateModel, Employee>()
                .ForMember(m => m.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(m => m.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(m => m.PhotoPath, opt => opt.MapFrom(src => src.PhotoPath))
                .ForMember(m => m.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(m => m.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));
            CreateMap<Employee, EmployeeDetailsModel>()
                .ForMember(m => m.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
                .ForMember(m => m.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Date.ToShortDateString()))
                .ForMember(m => m.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(m => m.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));

        }
    }
}
