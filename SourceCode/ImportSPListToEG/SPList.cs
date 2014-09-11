using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ImportSPListToEG
{
    public class SPList
    {
        private static string endCards4 = ";;;;";
        private List<SPColumn> _columns = new List<SPColumn>();

        public static Int32 ServerCodePage = 0;
        public string siteUrl { get; private set; }
        public string Title { get; private set; }
        public Guid ID { get; private set; }
        public int Count
        {
            get
            {
                return _columns == null ? 0 : _columns.Count;
            }
        }
        public string Description { get; private set; }
        public bool Hidden { get; private set; }
        public bool IsGallery { get; private set; }
        public bool IsAppList { get; private set; }
        public bool removeHTML { get; set; }

        #region constructors and static methods
        private SPList() { } // for the clone
        public SPList(List list, string siteUrl) 
        {
            this.siteUrl = siteUrl;
            Title = list.Title;
            ID = list.Id;            
            Description = list.Description;
            this.Hidden = list.Hidden;
            this.IsAppList = list.IsApplicationList;
            this.IsGallery = list.IsCatalog;            
        }
        public SPList(XmlElement xParent)
        {
            _columns = new List<SPColumn>();
            XmlNode xTop = xParent["SPList"];
            this.Title = xTop.Attributes["Title"].Value;
            this.ID = new Guid(xTop.Attributes["ID"].Value);
            Hidden = Convert.ToBoolean(xTop.Attributes["Hidden"].Value);
            IsGallery = Convert.ToBoolean(xTop.Attributes["isGallery"].Value);
            IsAppList = Convert.ToBoolean(xTop.Attributes["isAppList"].Value);           

            this.siteUrl = xTop["url"].InnerText;
            XmlNode colNode = xTop["Columns"];
            foreach (XmlNode xChild in colNode.ChildNodes)
            {
                if (xChild.Name == "Column")
                {
                    SPColumn col = new SPColumn(xChild);
                    _columns.Add(col);
                }
            }
        }
        public static SPList Clone(SPList original)
        {
            SPList clone = new SPList();
            clone.siteUrl = original.siteUrl;
            clone.Title = original.Title;
            clone.ID = original.ID;
            clone.Description = original.Description;
            clone.Hidden = original.Hidden;
            clone.IsAppList = original.IsAppList;
            clone.IsGallery = original.IsGallery;
            foreach (SPColumn col in original._columns)
                clone._columns.Add(SPColumn.Clone(col));
            return clone;
        }
        #endregion

        #region public methods
        public void AddColumnToCode(SPColumn col)
        {
            IList<SPColumn> cols = GetColumnsForCode();
            col.includeInCode = true;
            col.SASOrder = cols.Count;
        }
        public List<SPColumn> GetColumns(bool refresh = false)
        {
            if (refresh || _columns.Count == 0)
            {
                IList<SPColumn> original = null;
                if (refresh)
                    original = GetColumnsForCode();

                _columns = spWrap.GetColumnList(this);
                if (original != null && original.Count > 0)
                {
                    foreach (SPColumn col in original)
                    {
                        int ndx = _columns.IndexOf(col);
                        if (ndx >= 0)
                        {
                            SPColumn.CopyColumnSettings(_columns[ndx], col);
                        }
                    }
                }
            }
            return new List<SPColumn>(_columns);
        }
        public IList<SPColumn> GetColumnsForCode()
        {
            SortedList<int, SPColumn> rc = new SortedList<int, SPColumn>();
            foreach (SPColumn col in GetColumns(false))
            {
                if (col.includeInCode)
                    rc.Add(col.SASOrder, col);
            }
            return rc.Values;
        }
        public string GetDataStepCode(string outputLibrary, string outputDataName, bool stopOnBadNumData = false, bool removeHTML = true)
        {
            this.removeHTML = removeHTML;
            StringBuilder sbCode = new StringBuilder();
            //start data statement
            sbCode.AppendFormat("DATA {0}.{1};{2}", outputLibrary, outputDataName, Environment.NewLine);
            IList<SPColumn> codeCols = GetColumnsForCode();
            //get format statement
            string fmtStatment = GetFormatStatement(codeCols);
            if (!string.IsNullOrEmpty(fmtStatment))
                sbCode.Append(fmtStatment);

            sbCode.AppendFormat("INFILE CARDS4 DSD;{0}INPUT ", Environment.NewLine);

            //append columns
            foreach (SPColumn curCol in codeCols)
            {
                string fmtString = curCol.getDATAStepInFormat(stopOnBadNumData);
                sbCode.AppendFormat("{0} : {1}{2}", curCol.SASName, fmtString, Environment.NewLine);
            }
            //add closing ; after input statement
            sbCode.AppendFormat(";{0}", Environment.NewLine);

            //add cards
            sbCode.AppendFormat("CARDS4;{0}", Environment.NewLine);
            string[,] data = GetCardsData();
            int upperCol = data.GetUpperBound(1);
            for (int row = 0; row <= data.GetUpperBound(0); row++)
            {

                for (int col = 0; col <= upperCol; col++)
                {
                    string strValue = data[row, col];
                    //if this is a char column, we need to truncate to the informat length
                    SPColumn column = codeCols[col];
                    if (0 == string.Compare(SPColumn.SASChar, column.SASType, true))
                    {
                        int informatLen = column.InformatLength;
                        if (strValue.Length > informatLen)
                        {
                            strValue = strValue.Substring(0, informatLen);
                            if (!strValue.EndsWith("\""))
                                strValue += '"';
                        }
                    }
                    sbCode.AppendFormat("{0}, ", strValue);
                }
                sbCode.Append(Environment.NewLine);
            }
            //append end of everything line
            sbCode.AppendFormat("{0}{1}", endCards4, Environment.NewLine);
            return sbCode.ToString();
        }
        public void MoveColumn(SPColumn column, bool up)
        {
            //find column to switch with
            int targetOrder = up ? column.SASOrder - 1 : column.SASOrder + 1;
            SPColumn targetCol = null;
            foreach (SPColumn curCol in GetColumns(false))
            {
                if (curCol.SASOrder == targetOrder)
                {
                    targetCol = curCol;
                    break;
                }
            }
            if (targetCol != null)
            {
                targetCol.SASOrder = column.SASOrder;
                column.SASOrder = targetOrder;
            }
        }
        public void RemoveColumnFromCode(SPColumn col)
        {
            IList<SPColumn> cols = GetColumnsForCode();
            for (int i = col.SASOrder + 1; i < cols.Count; i++)
            {
                SPColumn curCol = cols[i];
                --curCol.SASOrder;
            }
            col.includeInCode = false;
            col.SASOrder = -1;
        }
        public override string ToString()
        {
            string rc = Title;
            if (string.IsNullOrEmpty(rc))
                rc = base.ToString();
            return rc;
        }
        public void WriteSerializationString(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("SPList");
            //save siteUrl and ID then tell columns to save themselves
            xWriter.WriteAttributeString("Title", Title);
            xWriter.WriteAttributeString("ID", ID.ToString());
            xWriter.WriteAttributeString("Hidden", Hidden.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xWriter.WriteAttributeString("isGallery", IsGallery.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xWriter.WriteAttributeString("isAppList", IsAppList.ToString(System.Globalization.CultureInfo.InvariantCulture));
            
            xWriter.WriteElementString("url", siteUrl);
            xWriter.WriteStartElement("Columns");
            foreach (SPColumn curCol in GetColumns(false))
            {
                curCol.WriteSerializationString(xWriter);
            }
            xWriter.WriteEndElement(); //columns
            xWriter.WriteEndElement(); //splist
        }
        #endregion

        #region private methods
        private string ConvertUnicodeToSASServerEncoding(string spValue)
        {
            string rawValue = spValue;
            try
            {
                Encoding sasEnc = GetEncoding(ServerCodePage);
                Encoding unicode = Encoding.Unicode;
                byte[] unicodeBytes = unicode.GetBytes(spValue);
                byte[] asciiBytes = Encoding.Convert(unicode, sasEnc, unicodeBytes);
                char[] asciiChars = new char[sasEnc.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
                sasEnc.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
                rawValue = new string(asciiChars);
            }
            catch (Exception)
            { }
            return rawValue;
        }
        private string[,] GetCardsData()
        {
            string[,] rc = null;
            
            using (ClientContext SPContext = new ClientContext(siteUrl))
            {
                Web site = SPContext.Web;
                SPContext.Load(site);
                SPContext.ExecuteQuery();
                List list = site.Lists.GetById(this.ID);

                StringBuilder sbQuery = new StringBuilder();
                IList<SPColumn> columns = GetColumnsForCode();
                int cols = columns.Count;
                if (cols > 0)
                {
                    sbQuery.AppendFormat("<View>{0}", Environment.NewLine);
                    sbQuery.AppendFormat("    <Query>{0}", Environment.NewLine);
                    sbQuery.AppendFormat("      <OrderBy>{0}", Environment.NewLine);
                    sbQuery.AppendFormat("        <FieldRef Name='{0}'/>{1}", columns[0].SPName, Environment.NewLine);
                    sbQuery.AppendFormat("      </OrderBy>{0}", Environment.NewLine);
                    sbQuery.AppendFormat("    </Query>{0}", Environment.NewLine);
                    sbQuery.AppendFormat("    <ViewFields>{0}", Environment.NewLine);
                    foreach (SPColumn curcol in columns)
                    {
                        sbQuery.AppendFormat("      <FieldRef Name='{0}'/>{1}", curcol.SPName, Environment.NewLine);
                    }
                    sbQuery.AppendFormat("    </ViewFields>{0}", Environment.NewLine);
                    sbQuery.AppendFormat("</View>{0}", Environment.NewLine);
                    CamlQuery query = new CamlQuery();
                    query.ViewXml = sbQuery.ToString();
                    SPContext.Load(list);
                    SPContext.ExecuteQuery();
                    ListItemCollection items = list.GetItems(query);
                    SPContext.Load(items);
                    SPContext.ExecuteQuery();
                    int rows = items.Count;
                    rc = new string[rows, cols];
                    for (int i = 0; i < rows; i++)
                    {
                        ListItem li = items[i];
                        var itemTextValues = li.FieldValuesAsText;
                        SPContext.Load(itemTextValues);
                        SPContext.ExecuteQuery();

                        for (int j = 0; j < cols; j++)
                        {
                            SPColumn curcol = columns[j];

                            string origSASType = SPColumn.SASTypeFromFieldType(curcol.SPFieldType);
                            string spValue = (origSASType == SPColumn.SASChar ? "\"\"" : ".");
                            if (li[curcol.SPName] != null)
                                spValue = GetStringValueFromField(li[curcol.SPName],itemTextValues[curcol.SPName], curcol.SASType, curcol.SPFieldType);
                            rc[i, j] = spValue;
                        }
                    }
                }
            }

            return rc;
        }
        private Encoding GetEncoding(Int32 codepage)
        {
            Encoding rc = Encoding.ASCII;
            if (codepage != 0)
            {
                try
                {
                    rc = Encoding.GetEncoding(codepage);
                }
                catch
                {
                    //ignore and return default
                }
            }
            return rc;
        }
        private string GetFormatStatement(IList<SPColumn> columns)
        {
            StringBuilder sbFS = new StringBuilder();
            sbFS.AppendFormat("FORMAT{0}", Environment.NewLine);
            foreach (SPColumn curCol in columns)
            {
                sbFS.AppendFormat("     {0}     {1}{2}", curCol.SASName, curCol.SASFormat, Environment.NewLine);
            }
            sbFS.AppendFormat(";{0}", Environment.NewLine);
            return sbFS.ToString();
        }
        private string GetStringValueFromField(object spValue, string textValue, string SASType, string spFieldType)
        {
            if (spValue == null) throw new ArgumentNullException("spValue");
            string rc = "\"\"";
            System.Type st = spValue.GetType();
            string rawValue;
            switch (st.FullName)
            {
                case "System.String":
                    if (removeHTML)
                        rawValue = textValue;
                    else
                        rawValue = (System.String)spValue;
                    break;
                case "System.String[]":
                    {
                        if (removeHTML)
                            rawValue = textValue;
                        else
                        {
                            String[] stvals = (String[])spValue;
                            StringBuilder sb = new StringBuilder();
                            foreach (string str in stvals)
                            {
                                if (sb.Length > 0)
                                    sb.Append(", ");
                                sb.Append(str);
                            }
                            rawValue = sb.ToString();
                        }
                    }
                    break;
                case "Microsoft.SharePoint.Client.FieldUserValue":
                    rawValue = ((FieldUserValue)spValue).LookupValue;
                    break;
                case "Microsoft.SharePoint.Client.FieldUserValue[]":
                    {
                        FieldUserValue[] suv = (FieldUserValue[])spValue;
                        StringBuilder sb = new StringBuilder();
                        foreach (FieldUserValue fuv in suv)
                        {
                            if (sb.Length > 0)
                                sb.Append(", ");
                            sb.AppendFormat("{0}", fuv.LookupValue);
                        }
                        rawValue = sb.ToString();
                    }
                    break;
                case "System.DateTime":
                    if (SASType == SPColumn.SASChar)
                        rawValue = spValue.ToString();
                    else
                    {
                        DateTime dtDotNet = TimeZoneInfo.ConvertTimeFromUtc((DateTime)spValue, TimeZoneInfo.Local);
                        double dtSAS = spWrap.DotNetToSASDatetime(dtDotNet);
                        rawValue = dtSAS.ToString();
                    }
                    break;                    
                case "Microsoft.SharePoint.Client.FieldUrlValue":
                    {
                        Microsoft.SharePoint.Client.FieldUrlValue url = (Microsoft.SharePoint.Client.FieldUrlValue)spValue;
                        rawValue = url.Url;
                    }
                    break;
                default:
                    rawValue = spValue.ToString();
                    break;
            }
            if (!string.IsNullOrEmpty(rawValue))
            {
                if (rawValue.Contains('"'))
                    rawValue = rawValue.Replace("\"", "\"\"");
                if (rawValue.Contains(Environment.NewLine))
                    rawValue = rawValue.Replace(Environment.NewLine, " ");
                if ( rawValue.Contains('\n'))
                    rawValue = rawValue.Replace("\n", " ");               

                rawValue = ConvertUnicodeToSASServerEncoding(rawValue);
                rc = string.Format("\"{0}\"", rawValue);
            }
            return rc;
        }
        #endregion

    }
}
