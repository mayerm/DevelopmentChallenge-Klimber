using DevelopmentChallenge.Data.Models;
using DevelopmentChallenge.Data.Models.Conics;
using DevelopmentChallenge.Data.Models.Polygons;
using DevelopmentChallenge.Data.Models.Polygons.Quadrilaterals;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DevelopmentChallenge.Data.Core
{
    public static class GeoFormReportGenerator
    {
        public enum Language
        {
            ES = 1,
            EN = 2,
            IT = 3
        }

        public static string Imprimir(List<GeometricForm> forms, int idioma)
        {
            try
            {
                string lang = Enum.GetName(typeof(Language), idioma);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(string.Join("-", lang.ToLower(), lang));
                CultureInfo cultureInfo = CultureInfo.GetCultureInfo(string.Join("-", lang.ToLower(), lang));
                ResourceManager rm = new ResourceManager("DevelopmentChallenge.Data.Resources.Resources", Assembly.GetExecutingAssembly());

                if (!forms.Any())
                    return rm.GetString("EmptyList", cultureInfo);

                StringBuilder sb = new StringBuilder();
                sb.Append(rm.GetString("ReportTitle"));
                int totalForms = forms.Count;
                decimal totalArea = 0;
                decimal totalPerimeter = 0;

                sb.Append(ProcessForms(forms, typeof(Square), ref totalArea, ref totalPerimeter, ref rm));
                sb.Append(ProcessForms(forms, typeof(Circle), ref totalArea, ref totalPerimeter, ref rm));
                sb.Append(ProcessForms(forms, typeof(Triangle), ref totalArea, ref totalPerimeter, ref rm));
                sb.Append(ProcessForms(forms, typeof(Rectangle), ref totalArea, ref totalPerimeter, ref rm));
                sb.Append(ProcessForms(forms, typeof(Trapeze), ref totalArea, ref totalPerimeter, ref rm));
                // FOOTER
                sb.AppendFormat(rm.GetString("Total"), totalForms, totalPerimeter.ToString("#.##"), totalArea.ToString("#.##"));
                return sb.ToString();
            }
            catch(MissingManifestResourceException mmrEx)
            {                
                throw new NotImplementedException($"Resource file has not been created; it is pointing to a wrong/non existing resource file or the resource you are trying to call does not exist.{Environment.NewLine}Check the baseName of the ResourceManager and any spelling errors.{Environment.NewLine}Source: {mmrEx.Source}");
            }
        }

        private static string ProcessForms(IEnumerable<GeometricForm> forms, Type type, ref decimal totalArea, ref decimal totalPerimeter, ref ResourceManager rm)
        {
            forms = forms.Where(f => f.GetType() == type);
            int quantity = forms.Count();
            if (quantity == 0) return string.Empty;
            decimal area =  forms.Sum(f => f.CalculateArea());
            decimal perimeter = forms.Sum(f => f.CalculatePerimeter());
            totalArea += area;
            totalPerimeter += perimeter;
            string typeName = rm.GetString(type.Name + (quantity != 1 ? "s" : string.Empty));
            return string.Format(rm.GetString("SumByShape"), quantity, typeName, area.ToString("#.##"), perimeter.ToString("#.##")); 
        }

    }
}
