using AutoMapper;
using SGR.AutoMapper;

namespace SGR.Automapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingsProfile>();
            });

        }
    }
}