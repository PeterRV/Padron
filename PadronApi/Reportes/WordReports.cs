using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Word;
using PadronApi.Dto;
using ScjnUtilities;

namespace PadronApi.Reportes
{
    public class WordReports
    {

        private readonly ObservableCollection<Obra> obrasImprimir;

        Microsoft.Office.Interop.Word.Application oWord;
        Microsoft.Office.Interop.Word.Document oDoc;
        object oMissing = System.Reflection.Missing.Value;
        object oEndOfDoc = "\\endofdoc";

        //Microsoft.Office.Interop.Word.Table oTable;

        readonly string filepath = Path.GetTempFileName() + ".docx";

        public WordReports(ObservableCollection<Obra> obrasImprimir)
        {
            this.obrasImprimir = obrasImprimir;
        }


        public void InformeGenerlaObras()
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oDoc.PageSetup.Orientation = WdOrientation.wdOrientLandscape;


            try
            {
                //Insert a paragraph at the beginning of the document.
                Microsoft.Office.Interop.Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                //oPara1.Range.ParagraphFormat.Space1;
                oPara1.Range.Text = "SUPREMA CORTE DE JUSTICIA DE LA NACIÓN";

                oPara1.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Size = 10;
                oPara1.Range.Font.Name = "Arial";
                oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.Text = "COORDINACIÓN DE COMPILACIÓN Y ";
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.Text = "SISTEMATIZACIÓN DE TESIS";
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.Text = "RELACIÓN DE TESIS PARA PUBLICAR EN EL SEMANARIO JUDICIAL DE LA FEDERACIÓN Y EN SU GACETA";
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.Text = "TOTAL:   " + obrasImprimir.Count() + " Obras";
                oPara1.Range.InsertParagraphAfter();
                oPara1.Range.InsertParagraphAfter();


                int fila = 1;
                Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                Table oTable = oDoc.Tables.Add(wrdRng, obrasImprimir.Count + 2, 5, ref oMissing, ref oMissing);
                //oTable.Rows[1].HeadingFormat = 1;
                oTable.Range.ParagraphFormat.SpaceAfter = 6;
                oTable.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Range.Font.Size = 9;
                oTable.Range.Font.Name = "Arial";
                oTable.Range.Font.Bold = 0;
                oTable.Borders.Enable = 1;

                oTable.Columns[1].SetWidth(60, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[2].SetWidth(350, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[3].SetWidth(80, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[4].SetWidth(60, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[5].SetWidth(60, WdRulerStyle.wdAdjustSameWidth);


                oTable.Cell(fila, 1).Range.Text = "Consecutivo";
                oTable.Cell(fila, 2).Range.Text = "Título";
                oTable.Cell(fila, 3).Range.Text = "Núm. de Material";
                oTable.Cell(fila, 4).Range.Text = "Año";
                oTable.Cell(fila, 5).Range.Text = "Tiraje";

                oTable.Cell(fila, 1).Range.Font.Bold = 1;
                oTable.Cell(fila, 2).Range.Font.Bold = 1;
                oTable.Cell(fila, 3).Range.Font.Bold = 1;
                oTable.Cell(fila, 4).Range.Font.Bold = 1;
                oTable.Cell(fila, 5).Range.Font.Bold = 1;


                fila++;
                int consecutivo = 1;

                foreach (Obra print in obrasImprimir)
                {
                    oTable.Cell(fila, 1).Range.Text = consecutivo.ToString();
                    oTable.Cell(fila, 2).Range.Text = print.Titulo;
                    oTable.Cell(fila, 2).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;
                    oTable.Cell(fila, 3).Range.Text = print.NumMaterial;
                    oTable.Cell(fila, 4).Range.Text = print.AnioPublicacion.ToString();
                    oTable.Cell(fila, 5).Range.Text = print.Tiraje.ToString();
                    // oTable.Cell(fila, 3).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphJustify;

                    fila++;
                    consecutivo++;
                }


                foreach (Section wordSection in oDoc.Sections)
                {
                    object pagealign = WdPageNumberAlignment.wdAlignPageNumberRight;
                    object firstpage = true;
                    wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].PageNumbers.Add(ref pagealign, ref firstpage);
                }

                oWord.ActiveDocument.SaveAs(filepath);
                oWord.ActiveDocument.Saved = true;
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Listado", "ListadoDeTesis");
            }
            finally
            {
                oWord.Visible = true;
                //oDoc.Close();

            }
        }





        private WdColorIndex GetCellColor(int idColor)
        {
            if (idColor == 2)
                return WdColorIndex.wdRed;
            else if (idColor == 3)
                return WdColorIndex.wdBlue;
            else if (idColor == 4)
                return WdColorIndex.wdViolet;
            else if (idColor == 5)
                return WdColorIndex.wdDarkRed;
            else if (idColor == 6)
                return WdColorIndex.wdGreen;
            else
                return WdColorIndex.wdBlack;
        }


    }
}
