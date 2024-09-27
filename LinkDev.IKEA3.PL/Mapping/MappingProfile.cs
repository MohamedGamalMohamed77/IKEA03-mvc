using AutoMapper;
using LinkDev.IKEA3.BLL.CustomModels.Departments;
using LinkDev.IKEA3.PL.ViewModels.Departments;

namespace LinkDev.IKEA3.PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Department
            CreateMap<DepartmentDetailsDto, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, UpdatedDepartmentDto>();

            #endregion
            #region Employee

            #endregion
        }
    }
}
