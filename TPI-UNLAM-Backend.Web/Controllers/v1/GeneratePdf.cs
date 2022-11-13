using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace TPI_UNLAM_Backend.Controllers.v1
{
    public class GeneratePdf : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public FileResult GeneratePdfs(string html)
        {
            html = html.Replace("strtTag", "<").Replace("EndTag", ">");

            HtmlToPdf oHtmlToPdf = new HtmlToPdf();
            PdfDocument oPdfDocument = oHtmlToPdf.ConvertHtmlString(html);
            byte[] pdf = oPdfDocument.Save();
            oPdfDocument.Close();

            return File(
                pdf,
                "application/pdf",
                "StudentList.pdf"
                );
        }
    }
}
