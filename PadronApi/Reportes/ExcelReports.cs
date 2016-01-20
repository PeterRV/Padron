using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using PadronApi.Dto;
using ScjnUtilities;
using System.Reflection;
using System.Windows.Input;
using System.Windows;


namespace PadronApi.Reportes
{
    public class ExcelReports
    {
        private readonly ObservableCollection<Obra> obrasImprimir;
        readonly string filepath;

        Application oExcel;
        Workbooks oBooks;
        _Workbook oBook;
        Sheets oSheets;
        _Worksheet oSheet;
        Range range;
        
        public ExcelReports(ObservableCollection<Obra> obrasImprimir, string ruta)
        {
            this.filepath = ruta;
            this.obrasImprimir = obrasImprimir;            
        }

        public void InformeGeneralObras()
        {
            oExcel = new Application();
            oBooks = oExcel.Workbooks;
            oBook = oBooks.Add(1);
            oSheets = (Sheets)oBook.Worksheets;
            oSheet = oSheets.get_Item(1);

            this.oSheet.Cells[1,1] = "Consecutivo";
            this.oSheet.Cells[1,2] = "Título";
            this.oSheet.Cells[1,3] = "Núm. de Material";
            this.oSheet.Cells[1,4] = "Año";
            this.oSheet.Cells[1,5] = "Tiraje";            

            int ind = 2;
            for (int j = 0; j < obrasImprimir.Count; j++)
            {
                oSheet.Cells[1][ind] = obrasImprimir[j].Consecutivo;
                oSheet.Cells[2][ind] = obrasImprimir[j].Titulo;
                oSheet.Cells[3][ind] = obrasImprimir[j].NumMaterial;
                oSheet.Cells[4][ind] = obrasImprimir[j].AnioPublicacion;
                oSheet.Cells[5][ind] = obrasImprimir[j].Tiraje;
                ind++;
            }            
            this.oExcel.ActiveWorkbook.Save();
            this.oExcel.Quit();
        }
    }
}
