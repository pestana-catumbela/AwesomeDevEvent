using AutoMapper;
using AwesomeDevEvents.Entities;
using AwesomeDevEvents.Models;

namespace AwesomeDevEvents.Mappers
{
    public class DevEventProfile : Profile
    {
        public DevEventProfile() 
        {
            CreateMap<DevEventInputModel, DevEvent>();
            CreateMap<DevEventSpeakerInputModel, DevEventSpeaker>();

            CreateMap<DevEvent, DevEventViewModel>();
            CreateMap<DevEventSpeaker, DevEventSpeakerViewModel>();
        }
    }
}
