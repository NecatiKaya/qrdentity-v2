namespace Qrdentity.Web.Services;

public interface ICodeGeneratorService
{
    public string Generate(int length = 6);
}