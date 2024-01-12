namespace Qrdentity.Web.Utilities;

public static class RandomMultiFactorCodeGenerator
{
    public static string MultiFactorCodeGenerator(int length = 6)
    {
        string codeToRegister = string.Join(string.Empty,
            Random.Shared.GetItems(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }, length));
        return codeToRegister;
    }
}