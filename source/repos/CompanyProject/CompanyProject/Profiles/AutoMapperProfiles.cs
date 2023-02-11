using AutoMapper;
using domain = CompanyProject.DomainModels;
using CompanyProject.DataModels;

namespace CompanyProject.Profiles
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<domain.Company, Company>()
                .ReverseMap();

            CreateMap<domain.Client, Client>()
                .ReverseMap();

            CreateMap<domain.Employee, Employee>()
                .ReverseMap();

            CreateMap<domain.Project, Project>()
                .ReverseMap();
        }
    }
}
