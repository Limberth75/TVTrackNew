using DinkToPdf;
using DinkToPdf.Contracts;

namespace TVTrackII.Services
{
    public class ReportePdfService
    {
        private readonly IConverter _converter;

        public ReportePdfService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GenerarPdfDesdeHtml(string html)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    Margins = new MarginSettings { Top = 10, Bottom = 10 }
                },
                Objects = {
                    new ObjectSettings
                    {
                        HtmlContent = html,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _converter.Convert(doc);
        }
    }
}
