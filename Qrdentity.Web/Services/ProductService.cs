using Microsoft.EntityFrameworkCore;
using Qrdentity.Web.Data;
using Qrdentity.Web.Data.Products;
using Qrdentity.Web.Proxies.Product;

namespace Qrdentity.Web.Services;

public sealed class ProductService : IProductService
{
    private readonly QrdentityContext _qrdentityContext;

    public ProductService(QrdentityContext dbContext)
    {
        _qrdentityContext = dbContext;
    }

    public async Task<QrProduct> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        QrProduct? product =
            await _qrdentityContext.QrProducts.Where(eachProduct => eachProduct.Id == id && eachProduct.IsActive)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (product == null)
        {
            //TODO
            throw new Exception("");
        }

        return product;
    }

    public async Task CreateAsync(QrProduct product, CancellationToken cancellationToken = default)
    {
        await _qrdentityContext.QrProducts.AddAsync(product, cancellationToken);
        await _qrdentityContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<QrProduct>> ListProducts(GetProductsListRequestProxy proxy,
        CancellationToken cancellationToken = default)
    {
        IOrderedQueryable<QrProduct> query = _qrdentityContext.QrProducts
            .Where(eachProduct => eachProduct.IsActive)
            .Where(eachProduct =>
                string.IsNullOrWhiteSpace(proxy.NamePrefix) || eachProduct.Name.StartsWith(proxy.NamePrefix))
            .Skip(proxy.Skip)
            .Take(proxy.Take)
            .OrderBy(product => product.Name);

        if (string.Equals(proxy.SortOrder.ToLowerInvariant(), "desc"))
        {
            query = query.OrderByDescending(product => product.Name);
        }

        List<QrProduct> products = await query.ToListAsync(cancellationToken: cancellationToken);
        return products;
    }
}