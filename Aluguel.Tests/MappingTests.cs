using Aluguel.API.AutoMapperProfiles;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aluguel.Tests
{
    public class MappingTests
    {
        [Fact]
        public void SetupCiclista()
        {
            MapperConfiguration mapperConfiguration = new(cfg =>
            {
                cfg.AddProfile(new CiclistaAutoMapperProfile());
            }); ;

            IMapper mapper = new Mapper(mapperConfiguration);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Fact]
        public void SetupFuncionario()
        {
            MapperConfiguration mapperConfiguration = new(cfg =>
            {
                cfg.AddProfile(new FuncionarioAutoMapperProfile());
            }); ;

            IMapper mapper = new Mapper(mapperConfiguration);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
