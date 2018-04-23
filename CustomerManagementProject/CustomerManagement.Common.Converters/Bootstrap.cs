using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CustomerManagement.Common.Converters.Mappers;

namespace CustomerManagement.Common.Converters
{
    public class Bootstrap
    {
        public static void InitMappingConfig(IMapperConfigurationExpression config)
        {
            var type = typeof(IBaseMapper);
            var types = typeof(IBaseMapper).Assembly.GetTypes()
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .ToList();

            types.ForEach(t =>
            {
                var n = (IBaseMapper)Activator.CreateInstance(t);
                n.CreateMap(config);
            });
        }
    }
}
