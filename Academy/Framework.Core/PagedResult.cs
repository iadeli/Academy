using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public class PagedResult<T>
    {
        public PagedResult(List<T> data, long total)
        {
            Data = data;
            Total = total;
        }
        public List<T> Data { get; set; }
        public long Total { get; set; }
    }
}
