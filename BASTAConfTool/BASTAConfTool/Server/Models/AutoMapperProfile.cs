using AutoMapper;

namespace BASTAConfTool.Server.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Conference, Shared.DTO.ConferenceOverview>();
            CreateMap<Shared.DTO.ConferenceOverview, Models.Conference>();
            CreateMap<Models.Conference, Shared.DTO.ConferenceDetails>();
            CreateMap<Shared.DTO.ConferenceDetails, Models.Conference>();
        }
    }
}
