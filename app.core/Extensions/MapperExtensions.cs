using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.core.Extensions;

public static class MapperExtensions
{
    private static readonly IMapper Mapper = GetMapper();

    private static IMapper GetMapper()
    {
        var serviceProvider = new ServiceCollection()
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .BuildServiceProvider();
        var mapper = serviceProvider.GetRequiredService<IMapper>();
        return mapper;
    }

    public static TShowDto Map<TShowDto>(this object entity)
    {
        return Mapper.Map<TShowDto>(entity);
    }


}