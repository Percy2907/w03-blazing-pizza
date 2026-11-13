using System.Globalization;

namespace BlazingPizza;

public static class PriceFormatter
{
    private static readonly CultureInfo PeruvianCulture = CultureInfo.GetCultureInfo("es-PE");

    public static string Format(decimal price) => price.ToString("C", PeruvianCulture);
}
