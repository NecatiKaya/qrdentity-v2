using Qrdentity.Web.Core.Data;

namespace Qrdentity.Web.Proxies.Product;

public sealed class GetProductsListRequestProxy  : PagingRequest
{
    public string NamePrefix { get; set; } = default!;

    public GetProductsListRequestProxy()
    {
        SortKey = "Name";
    }
}