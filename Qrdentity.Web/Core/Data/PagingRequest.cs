namespace Qrdentity.Web.Core.Data;

public abstract class PagingRequest
{
    public PagingRequest()
    {
        if (Skip < 0)
        {
            //TODO
            throw new Exception("");
        }

        if (Take < 1)
        {
            //TODO
            throw new Exception("");
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(SortOrder);
        ArgumentException.ThrowIfNullOrWhiteSpace(SortKey);
    }

    public string SortOrder { get; set; } = "ASC";

    public string SortKey { get; set; } = "Id";

    public int Skip { get; set; }

    public int Take { get; set; } = 50;
}