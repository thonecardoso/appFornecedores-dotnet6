using Microsoft.AspNetCore.Mvc.Razor;

namespace DevIO.Application.Extensions;

public static class RazorExtensions
{
    public static string FormatDocument(this RazorPage page, int personType, string documento)
    {
        return personType == 1 ? Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00") : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
    }

}
