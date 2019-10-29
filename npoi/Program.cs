using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet("测试");
            sheet.SetColumnWidth(0, 10 * 256);   //设置宽度，超过255会抛异常
            sheet.SetColumnWidth(1, 20 * 256);   //设置宽度，超过255会抛异常
            sheet.SetColumnWidth(2, 30 * 256);   //设置宽度，超过255会抛异常

            //标题单元格字体
            var headerFont = (XSSFFont)workbook.CreateFont();
            headerFont.Color = HSSFColor.Black.Index;
            headerFont.FontHeightInPoints = 11;
            headerFont.IsBold = true;

            //标题单元格样式
            var headerStyle = workbook.CreateCellStyle();
            headerStyle.Alignment = HorizontalAlignment.Center;
            headerStyle.VerticalAlignment = VerticalAlignment.Center;
            headerStyle.FillForegroundColor = HSSFColor.Grey25Percent.Index;
            headerStyle.FillPattern = FillPattern.SolidForeground;
            headerStyle.BorderLeft = BorderStyle.Thin;
            headerStyle.BorderRight = BorderStyle.Thin;
            headerStyle.BorderTop = BorderStyle.Thin;
            headerStyle.BorderBottom = BorderStyle.Thick;
            headerStyle.SetFont(headerFont);

            //创建标题行
            var headerRow = sheet.CreateRow(0);
            headerRow.HeightInPoints = 20;

            #region 填充标题内容
            var headerCol0 = headerRow.CreateCell(0);
            headerCol0.SetCellType(CellType.String);
            headerCol0.SetCellValue("序号");
            headerCol0.CellStyle = headerStyle;

            var headerCol1 = headerRow.CreateCell(1);
            headerCol1.SetCellType(CellType.String);
            headerCol1.SetCellValue("名称");
            headerCol1.CellStyle = headerStyle;

            var headerCol2 = headerRow.CreateCell(2);
            headerCol2.SetCellType(CellType.String);
            headerCol2.SetCellValue("图片");
            headerCol2.CellStyle = headerStyle;

            var headerCol3 = headerRow.CreateCell(3);
            headerCol3.SetCellType(CellType.String);
            headerCol3.SetCellValue("部门");
            headerCol3.CellStyle = headerStyle;
            #endregion

            //数据单元格字体1
            XSSFFont hyperLinkFont = (XSSFFont)workbook.CreateFont();
            hyperLinkFont.Color = HSSFColor.Blue.Index;
            hyperLinkFont.FontHeightInPoints = 11;

            //数据单元格样式1
            ICellStyle hyperLinkStyle = workbook.CreateCellStyle();
            hyperLinkStyle.Alignment = HorizontalAlignment.Left;
            hyperLinkStyle.VerticalAlignment = VerticalAlignment.Center;
            hyperLinkStyle.FillForegroundColor = HSSFColor.Blue.Index;
            hyperLinkStyle.BorderLeft = BorderStyle.Thin;
            hyperLinkStyle.BorderRight = BorderStyle.Thin;
            hyperLinkStyle.BorderTop = BorderStyle.Thin;
            hyperLinkStyle.BorderBottom = BorderStyle.Thin;
            hyperLinkStyle.SetFont(hyperLinkFont);

            //数据单元格字体2
            XSSFFont normalCellFont = (XSSFFont)workbook.CreateFont();
            normalCellFont.Color = HSSFColor.Black.Index;
            normalCellFont.FontHeightInPoints = 11;

            //数据单元格样式2
            var normalCellStyle = workbook.CreateCellStyle();
            normalCellStyle.Alignment = HorizontalAlignment.Left;
            normalCellStyle.VerticalAlignment = VerticalAlignment.Center;
            normalCellStyle.BorderLeft = BorderStyle.Thin;
            normalCellStyle.BorderRight = BorderStyle.Thin;
            normalCellStyle.BorderTop = BorderStyle.Thin;
            normalCellStyle.BorderBottom = BorderStyle.Thin;
            normalCellStyle.SetFont(normalCellFont);

            #region 填充数据内容
            int rownum = 1;
            while(rownum < 10)
            {
                var dataRow = sheet.CreateRow(rownum);
                dataRow.HeightInPoints = 15;

                var dataCol00 = dataRow.CreateCell(0);
                dataCol00.SetCellType(CellType.Numeric);
                dataCol00.SetCellValue(rownum);
                dataCol00.CellStyle = normalCellStyle;

                var dataCol01 = dataRow.CreateCell(1);
                dataCol01.SetCellType(CellType.String);
                dataCol01.SetCellValue($"这是内容-{rownum}");
                dataCol01.CellStyle = normalCellStyle;

                //超链接
                XSSFHyperlink link = new XSSFHyperlink(HyperlinkType.Url);
                link.Address = $"{rownum}.png";

                var dataCol02 = dataRow.CreateCell(2);
                dataCol02.SetCellType(CellType.String);
                dataCol02.SetCellValue("点击查看图片");
                dataCol02.CellStyle = hyperLinkStyle;   //设置样式                       
                dataCol02.Hyperlink = link;             //设置超链接

                var dataCol03 = dataRow.CreateCell(3);
                dataCol03.SetCellType(CellType.String);
                dataCol03.SetCellValue(rownum > 4 ? "研发部" : "财务部");
                dataCol03.CellStyle = normalCellStyle;

                rownum++;
            }
            #endregion

            //合并单元格测试
            sheet.AddMergedRegion(new CellRangeAddress(1, 4, 3, 3)); //firstRow,lastRow,firstColumn,lastColumn
            sheet.AddMergedRegion(new CellRangeAddress(5, 9, 3, 3)); //firstRow,lastRow,firstColumn,lastColumn

            //写入文件
            FileStream file = new FileStream(@"C:\my.xlsx", FileMode.OpenOrCreate);
            workbook.Write(file);
            file.Close();
        }
    }
}
