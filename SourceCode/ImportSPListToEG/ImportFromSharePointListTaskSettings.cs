using System;
using System.IO;
using System.Xml;

namespace ImportSPListToEG
{
    public class ImportFromSharePointListTaskSettings
    {        
        public ImportFromSharePointListTaskSettings()
        {
            outputLibrary = "WORK";
            outputDataName = "SPLIST";
            removeHtmlFromText = true;
            ShowApplicationLists = false;
            ShowHiddenLists = false;
            ShowGalleryLists = false;
        }

        #region Properties, or task settings        
        public string outputLibrary { get; set; }
        public string outputDataName { get; set; }
        public bool removeHtmlFromText { get; set; }
        public SPList SharePointList { get; set; }
        public bool ShowHiddenLists { get; set; }
        public bool ShowHiddenColumns { get; set; }
        public bool ShowGalleryLists { get; set; }
        public bool ShowApplicationLists { get; set; }
        #endregion

        #region Code to save/restore task settings
        public string ToXml()
        {
            MemoryStream stream = new MemoryStream(512);
            XmlTextWriter xWriter = new XmlTextWriter(stream, System.Text.Encoding.Unicode);
            xWriter.WriteStartElement("ImportFromSharePointListTask");
            //save output lib and dataname, then tell list to save itself
            xWriter.WriteAttributeString("Library", outputLibrary);
            xWriter.WriteAttributeString("DataSet", outputDataName);
            xWriter.WriteAttributeString("RemoveHTML", removeHtmlFromText.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xWriter.WriteAttributeString("ShowHidden", ShowHiddenLists.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xWriter.WriteAttributeString("ShowGallery", ShowGalleryLists.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xWriter.WriteAttributeString("ShowApps", ShowApplicationLists.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xWriter.WriteAttributeString("ShowHiddenCols", ShowHiddenColumns.ToString(System.Globalization.CultureInfo.InvariantCulture));
            SharePointList.WriteSerializationString(xWriter);
            xWriter.WriteEndElement(); //task
            xWriter.Flush();
            StreamReader sr = new StreamReader(stream);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            return sr.ReadToEnd();
        }

        public void FromXml(string xml)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
                XmlElement el = doc["ImportFromSharePointListTask"];
                outputLibrary = el.Attributes["Library"].Value; 
                outputDataName = el.Attributes["DataSet"].Value;
                ShowHiddenLists = Convert.ToBoolean(el.Attributes["ShowHidden"].Value);
                ShowHiddenColumns = Convert.ToBoolean(el.Attributes["ShowHiddenCols"].Value);
                ShowGalleryLists = Convert.ToBoolean(el.Attributes["ShowGallery"].Value);
                if (el.HasAttribute("RemoveHTML"))
                    removeHtmlFromText = Convert.ToBoolean(el.Attributes["RemoveHTML"].Value);
                ShowApplicationLists = Convert.ToBoolean(el.Attributes["ShowApps"].Value);
                SharePointList = new SPList(el);

            }
            catch (XmlException)
            {
                // couldn't read the XML content
            }
        }
        #endregion

        #region Routine to build a SAS program
        public string GetSasProgram()
        {
            return SharePointList.GetDataStepCode(outputLibrary, outputDataName, removeHTML: this.removeHtmlFromText);
        }
        #endregion
    }
}
