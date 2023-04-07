using AutoMapper;
using DataLayer;
using ChatApp.Models;

namespace ChatApp.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<User, UserModel>()
                .ReverseMap();

            CreateMap<Group, GroupModel>()
                .ReverseMap();
        }
    }
}
