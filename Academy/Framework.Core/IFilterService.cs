using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public interface IFilter { }
    public interface IFilterService
    {
        PagedResult<T> ApplyFilter<T>(IQueryable<T> query, IFilter filter);
    }
}
