//CÔNG TY TNHH GIẢI PHÁP THỊ GIÁC MÁY TÍNH
//support@viscomsolution.com
//0939.825.125


//To install EPPlus to handle excel file, go to menu in Visual Studio: Tools -> NuGet Package Manager -> Package Manager Console
//Type following in console:
//PM> Install-Package EPPlus


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.Drawing;
using OfficeOpenXml.Style;
using System.Windows.Forms;
using OfficeOpenXml.Table;
using System.Data;

#if READ_EXCEL
using ExcelDataReader;
#endif

namespace TGMTcs
{
    public class TGMTexcel
    {
        ExcelPackage m_excel;
        ExcelWorkbook m_workbook;

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TGMTexcel(string fileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                m_excel = new ExcelPackage(new FileInfo(fileName));
                m_workbook = m_excel.Workbook;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Save()
        {
            m_excel.Save();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SaveAs(string fileName)
        {
            m_excel.SaveAs(new FileInfo(fileName));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetCellValue(int worksheetID, int row, int col,  string value)
        {
            m_workbook.Worksheets[worksheetID].Cells[row, col].Value = value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetStyle(int worksheetID, int row, int col, Color bgcolor, Color foreColor, bool bold = false)
        {
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Fill.BackgroundColor.SetColor(bgcolor);
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Font.Color.SetColor(foreColor);
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Font.Bold = bold;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Set alignment for entire row
        public void SetAlignmentRow(int worksheetID, int rowIdx, ExcelHorizontalAlignment hAlign = ExcelHorizontalAlignment.Center, ExcelVerticalAlignment vAlign = ExcelVerticalAlignment.Center)
        {
            var worksheet = m_workbook.Worksheets[worksheetID];

            if(worksheet.Dimension == null)
                return;

            var startCol = worksheet.Dimension.Start.Column;
            var endCol = worksheet.Dimension.End.Column;

            for(int col = startCol; col <= endCol; col++)
            {
                worksheet.Cells[rowIdx, col].Style.HorizontalAlignment = hAlign;
                worksheet.Cells[rowIdx, col].Style.VerticalAlignment = vAlign;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Set alignment for entire column
        public void SetAlignmentColumn(int worksheetID, int colIdx, ExcelHorizontalAlignment hAlign = ExcelHorizontalAlignment.Center, ExcelVerticalAlignment vAlign = ExcelVerticalAlignment.Center)
        {
            var worksheet = m_workbook.Worksheets[worksheetID];

            if(worksheet.Dimension == null)
                return;

            var startRow = worksheet.Dimension.Start.Row;
            var endRow = worksheet.Dimension.End.Row;

            for(int row = startRow; row <= endRow; row++)
            {
                worksheet.Cells[row, colIdx].Style.HorizontalAlignment = hAlign;
                worksheet.Cells[row, colIdx].Style.VerticalAlignment = vAlign;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        // Set alignment for a range of cells
        public void SetAlignmentRange(int worksheetID, int fromRow, int fromCol, int toRow, int toCol,
            ExcelHorizontalAlignment hAlign = ExcelHorizontalAlignment.Center,
            ExcelVerticalAlignment vAlign = ExcelVerticalAlignment.Center)
        {
            var worksheet = m_workbook.Worksheets[worksheetID];

            for(int row = fromRow; row <= toRow; row++)
            {
                for(int col = fromCol; col <= toCol; col++)
                {
                    worksheet.Cells[row, col].Style.HorizontalAlignment = hAlign;
                    worksheet.Cells[row, col].Style.VerticalAlignment = vAlign;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetFormatNumber(int worksheetID, int col, string format)
        {
            m_workbook.Worksheets[worksheetID].Columns[col].Style.Numberformat.Format = format;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetCellTextColor(int worksheetID, int row, int col, Color foreColor)
        {
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Font.Color.SetColor(foreColor);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetCellAlignment(int worksheetID, int row, int col, ExcelHorizontalAlignment hAlign = ExcelHorizontalAlignment.Center, ExcelVerticalAlignment vAlign = ExcelVerticalAlignment.Center)
        {            
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.HorizontalAlignment = hAlign;
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.VerticalAlignment = vAlign;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //column ID begin at 1
        public void SetAutoFitContent(int worksheetID, int col)
        {
            m_workbook.Worksheets[worksheetID].Column(col).AutoFit();            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddRow(int worksheetID, int row, object[] values)
        {
            for(int i=0; i<values.Length;i++)
            {
                m_workbook.Worksheets[worksheetID].Cells[row, i+ 1].Value = values[i];
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddSheet(string sheetName)
        {
            if(m_workbook.Worksheets[sheetName] == null)
                m_workbook.Worksheets.Add(sheetName);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetTitle(int worksheetID, int row, int col, string value)
        {
            SetCellValue(worksheetID, row, col, value);
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Font.Bold = true;
            m_workbook.Worksheets[worksheetID].Cells[row, col].Style.Font.Size = 20;


            string range = (char)('A' + col) + row.ToString() + ":" + (char)('A' + col + 4) + row.ToString();
            m_workbook.Worksheets[worksheetID].Cells[range].Merge = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DrawTable(int worksheetID, int fromRow, int fromCol, int toRow, int toCol)
        {
            //var FirstTableRange = m_workbook.Worksheets[worksheetID].Cells[fromRow, fromCol, toRow, toCol];
            //FirstTableRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            //FirstTableRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            //FirstTableRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            //FirstTableRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            ExcelWorksheet ws = m_workbook.Worksheets[worksheetID];
            //create a range for the table
            ExcelRange range = ws.Cells[fromRow, fromCol, toRow, toCol];
            //add a table to the range
            ExcelTable table = ws.Tables.Add(range, "Table1");
            table.ShowHeader = true;
            table.TableStyle = TableStyles.Medium2;

            // AutoFit columns to look better
            ws.Cells[ws.Dimension.Address].AutoFitColumns();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ExcelWorksheet GetWorksheet(string filePath, int sheetIndex)
        {
            FileInfo existingFile = new FileInfo(filePath);
            if (!existingFile.Exists)
                return null;

            try
            {
                ExcelPackage package = new ExcelPackage(existingFile);
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetIndex];
                return worksheet;
            }
            catch (Exception ex)
            {
            }

            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

#if READ_EXCEL
        public static DataTable ReadExcel(string filepath)
        {
            if (!File.Exists(filepath))
                return null;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var stream = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var reader = ExcelReaderFactory.CreateReader(stream);

            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration { UseHeaderRow = false }
            };

            DataSet result = reader.AsDataSet(conf);
            if (result.Tables.Count == 0)
                return null;


            // Try to get the specified sheet
            DataTable table = result.Tables[0];
            return table;
        }
#endif

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int Col(string chr)
        {
            if (chr.Length == 1)
            {
                return char.ToUpper(chr[0]) - 'A' + 1;
            }
            else if (chr.Length == 2)
            {
                return (char.ToUpper(chr[0]) - 'A' + 1) * 26 + (char.ToUpper(chr[1]) - 'A') + 1;
            }
            else
            {
                throw new ArgumentException("Invalid column name.");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetRowHeight(int worksheetID, int row, double height)
        {
            m_workbook.Worksheets[worksheetID].Row(row).Height = height;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SetColumnWidth(int worksheetID, int col, double width)
        {
            m_workbook.Worksheets[worksheetID].Column(col).Width = width;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddImageToCell(int worksheetID, int row, int col, string imagePath, int maxWidthPixels = 100, int maxHeightPixels = 75)
        {
            if(!File.Exists(imagePath))
                return;

            try
            {
                var worksheet = m_workbook.Worksheets[worksheetID];

                // Load image to get original dimensions
                using(var image = Image.FromFile(imagePath))
                {
                    int originalWidth = image.Width;
                    int originalHeight = image.Height;

                    // Calculate aspect ratio
                    float aspectRatio = (float)originalWidth / originalHeight;

                    int finalWidth;
                    int finalHeight;

                    // Determine final size while maintaining aspect ratio
                    if(originalWidth > originalHeight)
                    {
                        // Landscape orientation - constrain by width
                        finalWidth = Math.Min(maxWidthPixels, originalWidth);
                        finalHeight = (int)(finalWidth / aspectRatio);

                        // Check if height exceeds max
                        if(finalHeight > maxHeightPixels)
                        {
                            finalHeight = maxHeightPixels;
                            finalWidth = (int)(finalHeight * aspectRatio);
                        }
                    }
                    else
                    {
                        // Portrait orientation - constrain by height
                        finalHeight = Math.Min(maxHeightPixels, originalHeight);
                        finalWidth = (int)(finalHeight * aspectRatio);

                        // Check if width exceeds max
                        if(finalWidth > maxWidthPixels)
                        {
                            finalWidth = maxWidthPixels;
                            finalHeight = (int)(finalWidth / aspectRatio);
                        }
                    }

                    // Create unique name for the picture
                    string pictureName = $"Img_{row}_{col}_{DateTime.Now.Ticks}";

                    // Add picture to worksheet
                    var picture = worksheet.Drawings.AddPicture(pictureName, new FileInfo(imagePath));

                    // Position the picture to align with the cell (center it)
                    int rowOffset = Math.Max(2, (maxHeightPixels - finalHeight) / 2);
                    int colOffset = Math.Max(2, (maxWidthPixels - finalWidth) / 2);

                    picture.SetPosition(row - 1, rowOffset, col - 1, colOffset);

                    // Set the calculated size
                    picture.SetSize(finalWidth, finalHeight);

                    // Center align the cell
                    worksheet.Cells[row, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
            }
            catch(Exception ex)
            {
                // Silently handle errors
            }
        }
    }
}
