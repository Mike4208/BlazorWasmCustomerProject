using BlazorWasmCustomerProject.Shared.Models;

namespace BlazorWebbAsemblyApp_Customer.Server.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, Pagination pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination
                .QuantityPerPage).Take(pagination.QuantityPerPage);
        }
    }
}
