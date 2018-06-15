using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.excel
{
    public class ExcelHelper
    {
        public void ReadExcel2003(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                //HSSFWorkbook只能操作excel2003以下版本
                HSSFWorkbook workbook = new HSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheetAt(0);

                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);

                    ICell c0 = row.GetCell(0);
                    ICell c1 = row.GetCell(1);

                    List<ICell> celllist = row.Cells.ToList();

                    //some codes here
                }

                workbook.Close();
            }
        }

        public void ReadExcel2007(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                //XSSFWorkbook只能操作excel2007以上版本
                XSSFWorkbook workbook = new XSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheetAt(0); 

                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);

                    ICell c0 = row.GetCell(0);
                    ICell c1 = row.GetCell(1);

                    List<ICell> celllist = row.Cells.ToList();

                    //some codes here
                }

                workbook.Close();
            }
        }

        public void WriteExcel2003(string path, List<Dictionary<string, string>> data)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                HSSFWorkbook workbook = new HSSFWorkbook();

                ISheet sheet = workbook.CreateSheet("sheet1");
                sheet.CreateFreezePane(0, 1);
                
                IRow headerRow = sheet.CreateRow(0);
                headerRow.HeightInPoints = 15f;

                ICellStyle headerStyle = workbook.CreateCellStyle();
                headerStyle.Alignment = HorizontalAlignment.Center;
                headerStyle.VerticalAlignment = VerticalAlignment.Center;

                IFont headerFont = workbook.CreateFont();
                headerFont.IsBold = true;
                headerFont.FontHeightInPoints = 12;
                headerFont.FontName = "宋体";

                headerStyle.SetFont(headerFont);

                var dic = data.ElementAt(0);
                for (int i = 0; i < dic.Count; i++)
                {
                    ICell cell = headerRow.CreateCell(i);
                    cell.CellStyle = headerStyle;
                    cell.SetCellValue(dic.ElementAt(i).Key);
                }

                for (int i = 0; i < data.Count; i++)
                {
                    var item = data.ElementAt(i);
                    IRow row = sheet.CreateRow(i + 1);
                    for (int j=0;j<item.Count;j++)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.SetCellValue(item.ElementAt(j).Value);
                    }                    
                }

                workbook.Write(fs);
            }
        }

        public void WriteExcel2007(string path, List<Dictionary<string, string>> data)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XSSFWorkbook workbook = new XSSFWorkbook();

                ISheet sheet = workbook.CreateSheet("sheet1");
                sheet.CreateFreezePane(0, 1);

                IRow headerRow = sheet.CreateRow(0);
                headerRow.HeightInPoints = 15f;

                ICellStyle headerStyle = workbook.CreateCellStyle();
                headerStyle.Alignment = HorizontalAlignment.Center;
                headerStyle.VerticalAlignment = VerticalAlignment.Center;

                IFont headerFont = workbook.CreateFont();
                headerFont.IsBold = true;
                headerFont.FontHeightInPoints = 12;
                headerFont.FontName = "宋体";

                headerStyle.SetFont(headerFont);

                var dic = data.ElementAt(0);
                for (int i = 0; i < dic.Count; i++)
                {
                    ICell cell = headerRow.CreateCell(i);
                    cell.CellStyle = headerStyle;
                    cell.SetCellValue(dic.ElementAt(i).Key);
                }

                for (int i = 0; i < data.Count; i++)
                {
                    var item = data.ElementAt(i);
                    IRow row = sheet.CreateRow(i + 1);
                    for (int j = 0; j < item.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.SetCellValue(item.ElementAt(j).Value);
                    }
                }

                workbook.Write(fs);
            }
        }
    }
}
