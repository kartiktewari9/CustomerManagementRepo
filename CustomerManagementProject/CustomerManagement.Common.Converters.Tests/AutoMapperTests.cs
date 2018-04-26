using AutoMapper;
using NUnit;
using NUnit.Framework;

namespace CustomerManagement.Common.Converters.Tests
{
    [TestFixture]
    public class AutoMapperTests
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Mapper.Initialize(Bootstrap.InitMappingConfig);
        }

        [Test]
        public void All_Mappers_Are_Mapping_Correctly()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
