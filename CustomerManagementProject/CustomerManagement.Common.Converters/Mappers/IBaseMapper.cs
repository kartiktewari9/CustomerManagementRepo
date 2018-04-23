using AutoMapper;

namespace CustomerManagement.Common.Converters.Mappers
{
    public interface IBaseMapper
    {
        void CreateMap(IMapperConfigurationExpression config);
    }
}
