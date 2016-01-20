using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf; 
using iTextSharp.text.html; 
using iTextSharp.text.html.simpleparser;
using PadronApi.Dto;
using System.Diagnostics;
using System.IO;


namespace PadronApi.Reportes
{
    public class PDFReports
    {
        private readonly ObservableCollection<Obra> obrasImprimir;
        readonly string filepath;

        public PDFReports(ObservableCollection<Obra> obrasImprimir, string ruta)
        {
            this.filepath = ruta;
            this.obrasImprimir = obrasImprimir;
        }

        public void InformeGenerlaObras()
        {
            Document doc = new Document(PageSize.LETTER, 9, 9, 9, 9);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Padrón");
            doc.Open();
            Chunk encab = new Chunk("Reporte de obras ", FontFactory.GetFont("COURIER", 18));
            Chunk ap = new Chunk("REPORTE de esta fecha", FontFactory.GetFont("COURIER", 18));

            try
            {              
                doc.Add(new Paragraph(encab));
                doc.Add(new Paragraph(ap));
                //se crea un objeto PdfTable con el numero de columnas del dataGridView 
                PdfPTable datatable = new PdfPTable(5);
                //asignamos algunas propiedades para el diseño del pdf 
                datatable.DefaultCell.Padding = 1;
                float[] headerwidths = new float[5]; // GetTamañoColumnas;
                headerwidths[0] = 1;
                headerwidths[1] = 1;
                headerwidths[2] = 1;
                headerwidths[3] = 1;
                headerwidths[4] = 1;

                datatable.SetWidths(headerwidths);
                datatable.WidthPercentage = 100;
                datatable.DefaultCell.BorderWidth = 1;

                datatable.DefaultCell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;//DEFINIMOS EL COLOR DE LAS CELDAS EN EL PDF
                datatable.DefaultCell.BorderColor = iTextSharp.text.BaseColor.BLACK;//DEFINIMOS EL COLOR DE LOS BORDES
                iTextSharp.text.Font fuente = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA);//LA FUENTE DE NUESTRO TEXTO

                Phrase objP = new Phrase("A", fuente);
                datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                //SE GENERA EL ENCABEZADO DE LA TABLA EN EL PDF 
                objP = new Phrase("Consecutivo", fuente);
                datatable.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.AddCell(objP);
                objP = new Phrase("Título", fuente);
                datatable.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.AddCell(objP);
                objP = new Phrase("Núm. de Material", fuente);
                datatable.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.AddCell(objP);
                objP = new Phrase("Año", fuente);
                datatable.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.AddCell(objP);
                objP = new Phrase("Tiraje", fuente);
                datatable.HorizontalAlignment = Element.ALIGN_CENTER;
                datatable.AddCell(objP);
                
                datatable.HeaderRows = 2;

                datatable.DefaultCell.BorderWidth = 1;

                //SE GENERA EL CUERPO DEL PDF
                for (int i = 0; i < obrasImprimir.Count; i++)
                {                   
                    objP = new Phrase(obrasImprimir[i].Consecutivo.ToString(), fuente);
                    datatable.AddCell(objP);
                    objP = new Phrase(obrasImprimir[i].Titulo.ToString(), fuente);
                    datatable.AddCell(objP);
                    objP = new Phrase(obrasImprimir[i].NumMaterial.ToString(), fuente);
                    datatable.AddCell(objP);
                    objP = new Phrase(obrasImprimir[i].AnioPublicacion.ToString(), fuente);
                    datatable.AddCell(objP);
                    objP = new Phrase(obrasImprimir[i].Tiraje.ToString(), fuente);
                    datatable.AddCell(objP);                    
                    datatable.CompleteRow();
                }
                doc.Add(datatable);                
                doc.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }            
        }       
    }
}
