using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Models;
using static DevelopmentChallenge.Data.Core.Enums.LanguageEnum;
using ReportStrings = DevelopmentChallenge.Data.Resources.Resources;

namespace DevelopmentChallenge.Data.Core.Reports
{
    public static class GeoFormReportGenerator
    {
        public static string Imprimir(List<GeometricForm> forms, Language language)
        {
            var cultureInfo = CultureInfoFor(language);
            ReportStrings.Culture = cultureInfo;

            if (!forms.Any())
                return ReportStrings.EmptyList;

            var sb = new StringBuilder();
            sb.Append(ReportStrings.ReportTitle);

            var groups = forms.GroupBy(f => f.GetType())
                .Select(g => new
                {
                    Representative = g.First(),
                    Count = g.Count(),
                    Area = g.Sum(f => f.CalculateArea()),
                    Perimeter = g.Sum(f => f.CalculatePerimeter())
                })
                .ToList();

            foreach (var group in groups)
            {
                var key = group.Count == 1
                    ? group.Representative.SingularResourceKey
                    : group.Representative.PluralResourceKey;
                var typeName = ReportStrings.ResourceManager.GetString(key, cultureInfo);

                sb.Append(string.Format(
                    cultureInfo,
                    ReportStrings.SumByShape,
                    group.Count,
                    typeName,
                    group.Area.ToString("#.##", cultureInfo),
                    group.Perimeter.ToString("#.##", cultureInfo)));
            }

            var totalCount = groups.Sum(g => g.Count);
            var totalArea = groups.Sum(g => g.Area);
            var totalPerimeter = groups.Sum(g => g.Perimeter);

            sb.AppendFormat(
                cultureInfo,
                ReportStrings.Total,
                totalCount,
                totalPerimeter.ToString("#.##", cultureInfo),
                totalArea.ToString("#.##", cultureInfo));

            return sb.ToString();
        }

        private static readonly IReadOnlyDictionary<Language, CultureInfo> Cultures =
            new Dictionary<Language, CultureInfo>
            {
                [Language.ES] = CultureInfo.GetCultureInfo("es-AR"),
                [Language.EN] = CultureInfo.GetCultureInfo("en-US"),
                [Language.IT] = CultureInfo.GetCultureInfo("it-IT"),
            };

        private static CultureInfo CultureInfoFor(Language language) =>
            Cultures.TryGetValue(language, out var culture)
                ? culture
                : throw new ArgumentOutOfRangeException(
                    nameof(language), language, $"Language '{language}' is not supported.");
    }
}
