using AutoMapper;
using TestLEAE.DataLayer;
using TestLEAE.ModelsView;

namespace TestLEAE.AutoMapper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Client, ClientView>();
            CreateMap<ClientView, Client>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Founders, opt => opt.Ignore());
            CreateMap<Founder, FounderView>()
                .ForMember(x => x.InnClient, opt => opt.Ignore());
            CreateMap<FounderView, Founder>()
                .ForMember(x => x.IdClient, opt => opt.Ignore())
                .ForMember(x => x.Client, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
