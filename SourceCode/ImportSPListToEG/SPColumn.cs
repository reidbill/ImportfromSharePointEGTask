using Microsoft.SharePoint.Client;
using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace ImportSPListToEG
{
    public class SPColumn
    {
        public const string SASChar = "Character";
        public const string SASNum = "Numeric";
        public const string DEFAULTCHARFORMAT = "$CHAR255.";
        public const string DEFAULTNUMFORMAT = "BEST12.";
        public const string SPSPACE = "_x0020_";
        private string _sasName = null;
        #region public properties
        public string Description { get; private set; }
        public string SPFieldType { get; private set; }
        public bool Hidden { get; private set; }
        public Guid ID { get; private set; }
        public bool includeInCode { get; set; }
        public int InformatLength
        {
            get
            {
                int rc = 255;
                string curInFormat = SASInFormat;
                var result = Regex.Match(curInFormat, @"\d+").Value;
                var result2 = Regex.Match(curInFormat, @"\d+$").Value;
                var result3 = Regex.Match(curInFormat, @"\d+(?!\D*\d)").Value;
                rc = Convert.ToInt32(result);
                return rc;
            }
        }

        public string SetSASInFormat = string.Empty;        
        public string SASInFormat
        {
            get
            {
                string rc = SetSASInFormat;
                if (string.IsNullOrEmpty(SetSASInFormat))
                {
                    if (SASType == SASChar)
                        rc = DEFAULTCHARFORMAT;
                    else
                        rc = DEFAULTNUMFORMAT;
                }
                return rc;
            }
            set { SetSASInFormat = value; }
        }
        public string SetSASFormat = string.Empty;
        public string SASFormat
        {
            get
            {
                string rc = SetSASFormat;
                if (string.IsNullOrEmpty(SetSASFormat))
                {
                    if (SASType == SASChar)
                        rc = DEFAULTCHARFORMAT;
                    else
                        rc = DEFAULTNUMFORMAT;
                }
                return rc;
            }
            set { SetSASFormat = value; }
        }        
        public string SASName
        {
            get
            {
                return _sasName.Length > 36 ? _sasName.Substring(0, 36) : _sasName;
            }
            set
            {
                _sasName = value;
            }
        }
        public string SASType { get; set; }
        public string SPName { get; private set; }        
        public int SASOrder { get; set; }
        public string Title { get; private set; }
        #endregion
        #region construction/serialization
        private SPColumn()
        {  }
        public SPColumn(Field f, List list, int Order)
        {          
            Title = f.Title;
            ID = f.Id;            
            SPFieldType = f.FieldTypeKind.ToString();
            SASFormat = GetDefaultFormat(f);
            SASType = SASTypeFromFieldType(f.FieldTypeKind);
            _sasName = f.InternalName;
            if (_sasName.Contains(SPSPACE))
                _sasName = f.InternalName.Replace(SPSPACE, "_");
            if (_sasName.Length > 36)
                _sasName = _sasName.Substring(0, 36);
            SPName = f.InternalName;
            this.includeInCode = false;
            Description = f.Description;
            Hidden = f.Hidden;
            SASOrder = Order;
        }
        public SPColumn(XmlNode xColumn)
        {
            Title = xColumn.Attributes["Title"].Value;
            ID = new Guid(xColumn.Attributes["ID"].Value);
            SPFieldType = xColumn.Attributes["FieldType"].Value;
            SASType = xColumn.Attributes["SASType"].Value;
            includeInCode = Convert.ToBoolean(xColumn.Attributes["Include"].Value,System.Globalization.CultureInfo.InvariantCulture);
            _sasName = xColumn.Attributes["SASName"].Value;            
            SPName = xColumn.Attributes["SPName"].Value;
            SASOrder = Convert.ToInt32(xColumn.Attributes["OutOrder"].Value);
            Hidden = Convert.ToBoolean(xColumn.Attributes["Hidden"].Value, System.Globalization.CultureInfo.InvariantCulture);
            if (xColumn.Attributes["SASFormat"] != null)
                SetSASFormat = xColumn.Attributes["SASFormat"].Value;
            if (xColumn.Attributes["SASInFormat"] != null)
                SetSASInFormat = xColumn.Attributes["SASInFormat"].Value;
            if ( xColumn["Description"] != null )
                Description = xColumn["Description"].InnerText;
        }
        public static SPColumn Clone(SPColumn original)
        {
            SPColumn clone = new SPColumn();
            clone._sasName = original._sasName;
            clone.Description = original.Description;
            clone.Hidden = original.Hidden;
            clone.ID = original.ID;
            clone.includeInCode = original.includeInCode;
            clone.SASFormat = original.SASFormat;
            clone.SASInFormat = original.SASInFormat;
            clone.SASName = original.SASName;
            clone.SASOrder = original.SASOrder;
            clone.SASType = original.SASType;            
            clone.SPFieldType = original.SPFieldType;
            clone.SPName = original.SPName;
            clone.Title = original.Title;
            return clone;
        }
        internal static void CopyColumnSettings(SPColumn newCol, SPColumn oldCol)
        {
            newCol.includeInCode = oldCol.includeInCode;
            newCol.SASOrder = oldCol.SASOrder;
            newCol.SASFormat = oldCol.SASFormat;
            newCol.SASInFormat = oldCol.SASInFormat;
            newCol.SASType = oldCol.SASType;
        }
        public void WriteSerializationString(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("Column");
            xWriter.WriteAttributeString("Title", Title);
            xWriter.WriteAttributeString("ID", ID.ToString());
            xWriter.WriteAttributeString("FieldType", SPFieldType);
            xWriter.WriteAttributeString("SASType", SASType);
            xWriter.WriteAttributeString("Include", includeInCode.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xWriter.WriteAttributeString("SASName", _sasName);
            xWriter.WriteAttributeString("SPName", SPName);
            xWriter.WriteAttributeString("OutOrder", SASOrder.ToString(System.Globalization.CultureInfo.InvariantCulture));
            xWriter.WriteAttributeString("Hidden", Hidden.ToString(System.Globalization.CultureInfo.InvariantCulture));
            if (!string.IsNullOrEmpty(SetSASFormat))
                xWriter.WriteAttributeString("SASFormat", SetSASFormat);
            if (!string.IsNullOrEmpty(SetSASInFormat))
                xWriter.WriteAttributeString("SASInFormat", SetSASInFormat);
            if (!string.IsNullOrEmpty(Description))
                xWriter.WriteElementString("Description", Description);
            xWriter.WriteEndElement();
        }
        #endregion
        #region private helpers
        private static string GetDefaultFormat(Field f)
        {
            string rc = string.Empty;
            switch (f.FieldTypeKind)
            {
                case FieldType.Text:
                    {
                        FieldText ft = f as FieldText;
                        if (ft != null)
                            rc = string.Format("$CHAR{0}.", ft.MaxLength);
                    }
                    break;
                case FieldType.DateTime:
                    rc = "DATETIME16.";
                    break;
            }
            return rc;
        }
        #endregion
        #region public methods
        public string getDATAStepInFormat(bool stopOnError)
        {
            string rc = string.Empty;
            if (SASType == SPColumn.SASChar)
                rc = SASInFormat;
            else
            {
                if (stopOnError)
                    rc = SASInFormat;
                else
                    rc = string.Format("?? {0}", SASInFormat);

            }
            return rc;
        }
        public static string SASTypeFromFieldType(FieldType sptype)
        {
            string rc = SPColumn.SASChar;
            switch (sptype)
            {
                case FieldType.Integer:
                case FieldType.Number:
                case FieldType.Counter:
                case FieldType.Currency:
                case FieldType.DateTime:
                    rc = SPColumn.SASNum;
                    break;
            }
            return rc;
        }
        public static string SASTypeFromFieldType(string FieldTypeKind)
        {            
            FieldType sptype = (FieldType)Enum.Parse(typeof(FieldType), FieldTypeKind);
            return SASTypeFromFieldType(sptype);
        }
        #endregion
        #region overrides
        public override string ToString()
        {
            return Title;
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if ( obj is SPColumn )
                return ID.Equals(((SPColumn)obj).ID);
            return false;
        }
        public static bool operator ==(SPColumn x, SPColumn y)
        {
            if (((Object)x) == null)
                return ((Object)y) == null;
            if (((Object)y) == null)
                return false;
            else return x.Equals(y);
        }
        public static bool operator !=(SPColumn x, SPColumn y)
        {
            if (((Object)x) == null)
                return ((Object)y) != null;
            if (((Object)y) == null)
                return true;
            else return !x.Equals(y);
        }
        #endregion
    }
}
