using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformService.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using JeweleryStorePlatformService;
using Service.Common.Mapping;

namespace Service.Extensions
{
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
            IConfigurationProvider mapperConfiguration
           )
            where TEntityDto : IMapFrom<TEntity>
        {
            if (sortBy is null || !IsValidProperty<TEntityDto>(sortBy))
            {
                if (typeof(TEntity) == typeof(Diamond))
                {
                    sortBy = nameof(DiamondDTO.Id);
                }
                else
                {
                    // Provide a default sorting property for other entities if needed
                    sortBy = "Id"; // Assuming Id is a common property
                }
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
            var type = typeof(TEntity);
            var parameter = Expression.Parameter(type, "t");
            var property = type.GetProperty(sortBy);

            if (property == null)
            {
                throw new ArgumentException($"Property '{sortBy}' not found on type '{type.Name}'.", nameof(sortBy));
            }

            var memberAccess = Expression.MakeMemberAccess(parameter, property);
            var lambda = Expression.Lambda(memberAccess, parameter);
            var methodName = sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase) ? "OrderByDescending" : "OrderBy";
            var result = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { type, property.PropertyType },
                items.Expression,
                Expression.Quote(lambda));

            return items.Provider.CreateQuery<TEntity>(result);
        }
    }
}
