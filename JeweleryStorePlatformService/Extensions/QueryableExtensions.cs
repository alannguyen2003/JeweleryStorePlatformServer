using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Common.Mapping;
using Service.Models;


namespace Service.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> items, int page, int size)
    {
        return items.Skip((page - 1) * size).Take(size);
    }

    public static async Task<PaginatedList<TEntityDto>> ListPaginateWithSortAsync<TEntity, TEntityDto>(
    this IQueryable<TEntity> items,
    int? page,
    int? size,
    string? sortBy,
    string? sortOrder,
    AutoMapper.IConfigurationProvider mapperConfiguration
   )
    where TEntityDto : IMapFrom<TEntity>
    {
        if (string.IsNullOrEmpty(sortBy) || !IsValidProperty<TEntityDto>(sortBy))
        {
            // Set a default sorting property if sortBy is null or invalid
            sortBy = typeof(TEntity) == typeof(GIAReport) ? nameof(GIAReport.Id) :
                     typeof(TEntity) == typeof(Diamond) ? nameof(Diamond.Id) :
                     throw new ArgumentException("Invalid sortBy property.");
        }

        sortOrder ??= "asc";
        var pageNumber = page.GetValueOrDefault(1);
        var sizeNumber = size.GetValueOrDefault(10);

        var count = await items.CountAsync();
        var list = await items
            .OrderByCustom(sortBy, sortOrder)
            .Paginate(pageNumber, sizeNumber)
            .ToListAsync();

        var mapper = mapperConfiguration.CreateMapper();
        var result = mapper.Map<List<TEntityDto>>(list);
        return new PaginatedList<TEntityDto>(result, count, pageNumber, sizeNumber);
    }

    private static bool IsValidProperty<TEntityDto>(string propertyName)
    {
        var propertyInfo = typeof(TEntityDto).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        return propertyInfo != null;
    }

    public static IQueryable<TEntity> OrderByCustom<TEntity>(this IQueryable<TEntity> items, string sortBy, string sortOrder)
    {
        if (string.IsNullOrEmpty(sortBy))
            throw new ArgumentNullException(nameof(sortBy), "Sort by parameter cannot be null or empty.");

        var type = typeof(TEntity);
        var parameter = Expression.Parameter(type, "t");
        var property = type.GetProperty(sortBy);

        if (property == null)
            throw new ArgumentException($"Property '{sortBy}' does not exist on type '{type.Name}'.");

        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExpression = Expression.Lambda(propertyAccess, parameter);
        var methodName = sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase) ? "OrderByDescending" : "OrderBy";

        var result = Expression.Call(
            typeof(Queryable),
            methodName,
            new[] { type, property.PropertyType },
            items.Expression,
            Expression.Quote(orderByExpression)
        );

        return items.Provider.CreateQuery<TEntity>(result);
    }
}