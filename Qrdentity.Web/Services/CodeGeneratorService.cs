using Qrdentity.Web.Utilities;

namespace Qrdentity.Web.Services;

public sealed class CodeGeneratorService : ICodeGeneratorService
{
    public string Generate(int length = 6)
    {
        string code = RandomMultiFactorCodeGenerator.MultiFactorCodeGenerator(length);
        return code;
    }
}