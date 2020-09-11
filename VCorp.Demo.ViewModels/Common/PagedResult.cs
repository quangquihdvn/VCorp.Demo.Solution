using System.Collections.Generic;

namespace VCorp.Demo.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
    }
}
