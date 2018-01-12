using AutoMapper;

namespace ShareFlow.Interface.AutoMapper
{
    public class Config
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(configure =>
            {
                configure.AddProfile(new ModelToEntityMappingProfile());
                configure.AddProfile(new EntityToModelMappingProfile());
            });
        }
    }
}