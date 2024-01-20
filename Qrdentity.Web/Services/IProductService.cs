using Qrdentity.Web.Data.Products;
using Qrdentity.Web.Proxies.Product;

namespace Qrdentity.Web.Services;

public interface IProductService
{
    Task<QrProduct> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task CreateAsync(QrProduct product, CancellationToken cancellationToken = default);

    Task<List<QrProduct>> ListProductsAsync(GetProductsListRequestProxy proxy,
        CancellationToken cancellationToken = default);

    Task<List<QrProduct>> ListProductsByIdAsync(Guid[] idList,
        CancellationToken cancellationToken = default);
}