using AutoMapper;

namespace TestLEAE.BusinessLayer.AutoMapper
{
    public class IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
