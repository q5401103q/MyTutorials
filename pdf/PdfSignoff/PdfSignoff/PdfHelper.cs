using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfSignoff
{
    public class PdfHelper
    {
        /// <summary>
        /// 利用itext7生成文字签名
        /// </summary>
        public void ConvertPdf1()
        {
            string sourcePath = $"C:\\test\\source.pdf";
            string targetPath = $"C:\\test\\target.pdf";
            string fontPath = $"C:\\Windows\\Fonts\\simkai.ttf";

            //输入PDF
            using (iText.Kernel.Pdf.PdfReader reader = new iText.Kernel.Pdf.PdfReader(sourcePath))
            {
                //输出PDF
                using (iText.Kernel.Pdf.PdfWriter writer = new iText.Kernel.Pdf.PdfWriter(targetPath))
                {
                    //获取PDF对象
                    using (iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(reader, writer))
                    {
                        //获取Document对象
                        using (iText.Layout.Document document = new iText.Layout.Document(pdfDocument))
                        {
                            //加载字体
                            iText.Kernel.Font.PdfFont font = iText.Kernel.Font.PdfFontFactory.CreateFont(fontPath, iText.IO.Font.PdfEncodings.IDENTITY_H, true);

                            //添加文本
                            document.Add(new iText.Layout.Element.Paragraph("签名1").SetFont(font).SetFontSize(12).SetFixedPosition(1, 3090, 90, 200));
                            document.Add(new iText.Layout.Element.Paragraph("签名2").SetFont(font).SetFontSize(12).SetFixedPosition(1, 3090, 70, 200));
                            document.Add(new iText.Layout.Element.Paragraph("签名3").SetFont(font).SetFontSize(12).SetFixedPosition(1, 3090, 50, 200));
                            document.Add(new iText.Layout.Element.Paragraph("签名4").SetFont(font).SetFontSize(12).SetFixedPosition(1, 3090, 30, 200));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 利用itextsharp生成文字签名
        /// </summary>
        public void ConvertPdf2()
        {
            string sourcePath = $"C:\\test\\source.pdf";
            string targetPath = $"E:\\test\\target.pdf";
            string fontPath = $"C:\\Windows\\Fonts\\simkai.ttf";

            //读原始PDF
            using (iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(sourcePath))
            {
                //定义流
                using (iTextSharp.text.pdf.PdfStamper stream = new iTextSharp.text.pdf.PdfStamper(reader, new FileStream(targetPath, FileMode.Create, FileAccess.Write, FileShare.None)))
                {
                    //加载字体
                    iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED), 12);

                    //获取顶层图层
                    iTextSharp.text.pdf.PdfContentByte canvas = stream.GetOverContent(1);

                    iTextSharp.text.pdf.ColumnText.ShowTextAligned(canvas, iTextSharp.text.Element.ALIGN_LEFT, new iTextSharp.text.Phrase("签名1", font), 3090, 93, 0);   //left, bottom, rotation
                    iTextSharp.text.pdf.ColumnText.ShowTextAligned(canvas, iTextSharp.text.Element.ALIGN_LEFT, new iTextSharp.text.Phrase("签名2", font), 3090, 73, 0);   //left, bottom, rotation
                    iTextSharp.text.pdf.ColumnText.ShowTextAligned(canvas, iTextSharp.text.Element.ALIGN_LEFT, new iTextSharp.text.Phrase("签名3", font), 3090, 53, 0);     //left, bottom, rotation
                    iTextSharp.text.pdf.ColumnText.ShowTextAligned(canvas, iTextSharp.text.Element.ALIGN_LEFT, new iTextSharp.text.Phrase("签名4", font), 3090, 33, 0);   //left, bottom, rotation
                }
            }
        }
    }
}
