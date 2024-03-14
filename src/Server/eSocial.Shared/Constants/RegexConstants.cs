using System.Text.RegularExpressions;

namespace eSocial.Shared.Constants;

public static partial class RegexConstants
{
    public static readonly Regex EmailRegex = new(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
}