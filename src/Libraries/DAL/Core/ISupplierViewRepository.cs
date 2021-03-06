// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using PetaPoco;

namespace MixERP.Net.Schemas.Core.Data
{
    public interface ISupplierViewRepository
    {
        /// <summary>
        /// Performs count on ISupplierViewRepository.
        /// </summary>
        /// <returns>Returns the number of ISupplierViewRepository.</returns>
        long Count();

        /// <summary>
        /// Return all instances of the "SupplierView" class from ISupplierViewRepository. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "SupplierView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.SupplierView> Get();

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding ISupplierViewRepository.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for ISupplierViewRepository.</returns>
        IEnumerable<DisplayField> GetDisplayFields();

        /// <summary>
        /// Produces a paginated result of 10 items from ISupplierViewRepository.
        /// </summary>
        /// <returns>Returns the first page of collection of "SupplierView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.SupplierView> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 items from ISupplierViewRepository.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "SupplierView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.SupplierView> GetPaginatedResult(long pageNumber);

        List<EntityParser.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on ISupplierViewRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "SupplierView" class using the filter.</returns>
        long CountWhere(List<EntityParser.Filter> filters);

        /// <summary>
        /// Produces a paginated result of 10 items using the supplied filters from ISupplierViewRepository.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "SupplierView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.SupplierView> GetWhere(long pageNumber, List<EntityParser.Filter> filters);

        /// <summary>
        /// Performs a filtered count on ISupplierViewRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "SupplierView" class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Produces a paginated result of 10 items using the supplied filter name from ISupplierViewRepository.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "SupplierView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.SupplierView> GetFiltered(long pageNumber, string filterName);


    }
}