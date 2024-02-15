using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace UL.Selenium.Portal.WERCSmart.Helpers
{
	public static class WercsmartPdfHelpers
	{
		public static string GetTextFromPdf(string filePath, ITextExtractionStrategy extractionStrategy = null)
		{
			try
			{
				StringWriter output = new StringWriter();
				PdfDocument pdfDocument = new PdfDocument(new PdfReader(filePath));
				for (int i = 1; i <= pdfDocument.GetNumberOfPages(); ++i)
				{
					PdfPage page = pdfDocument.GetPage(i);
					output.WriteLine(extractionStrategy != null ? PdfTextExtractor.GetTextFromPage(page, extractionStrategy) : PdfTextExtractor.GetTextFromPage(page));
				}

				return output.ToString();
			}
			catch
			{
				return null;
			}
		}

		private static Stream GetStreamFromUrl(string url)
		{
			byte[] imageData = null;

			using (WebClient wc = new WebClient())
			{
				imageData = wc.DownloadData(url);
			}

			return new MemoryStream(imageData);
		}

		public static string GetTextFromPdfUri(string address, ITextExtractionStrategy extractionStrategy = null)
		{
			StringWriter output = new StringWriter();
			PdfDocument pdfDocument = new PdfDocument(new PdfReader(GetStreamFromUrl(address)));
			for (int i = 1; i <= pdfDocument.GetNumberOfPages(); ++i)
			{
				PdfPage page = pdfDocument.GetPage(i);
				output.WriteLine(extractionStrategy != null ? PdfTextExtractor.GetTextFromPage(page, extractionStrategy) : PdfTextExtractor.GetTextFromPage(page));
			}

			return output.ToString();
		}
	}
}
