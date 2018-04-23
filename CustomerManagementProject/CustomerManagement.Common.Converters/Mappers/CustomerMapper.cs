using System;
using System.Collections.Generic;
using System.Linq;
using CustomerManagement.Data.DAO;
using CustomerManagement.Common.Objects.POCO;
using AutoMapper;

namespace CustomerManagement.Common.Converters.Mappers
{
    public class CustomerMapper: IBaseMapper
    {
        public void CreateMap(IMapperConfigurationExpression config)
        {
            config.CreateMap<Customer, CustomerPoco>()
                .ReverseMap();
        }
    }
}
