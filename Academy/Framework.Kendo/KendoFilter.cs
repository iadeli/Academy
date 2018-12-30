using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Framework.Kendo
{
    public class KendoFilter : IFilter
    {
        public DataSourceRequest DataSourceRequest { get; set; }
        public KendoFilter(DataSourceRequest request)
        {
            DataSourceRequest = request;

        }
    }

    public class KendoFilterService : IFilterService
    {
        public PagedResult<T> ApplyFilter<T>(IQueryable<T> query, IFilter filter)
        {
            //if(!(filter is KendoFilter)) throw new Exception();
            var kendoFilter = filter as KendoFilter;

            if(kendoFilter == null) throw new Exception();
            var result = query.ToDataSourceResult(kendoFilter.DataSourceRequest);
            return new PagedResult<T>(result.Data as List<T>, result.Total);
        }
    }
}
