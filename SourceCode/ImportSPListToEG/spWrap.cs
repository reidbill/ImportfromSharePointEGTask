using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;

namespace ImportSPListToEG
{
    public static class spWrap
    {
        private const int DaysBetweenSASandDotNetReference = 715509;	// Number of days between SAS reference (01JAN1960) and DotNet reference (01JAN0001)
        private const int DaysBetweenSASandExcelReference = 21916;		// Number of days between SAS reference (01JAN1960) and Excel reference (01JAN1900)
        private const int SecondsPerDay = 86400;						// Number of seconds per day
        public static double DotNetToSASDate(DateTime dotNetDateTime)
        {
            // Since SAS doesn't consider the years 4000 and 8000 leap years, but .NET
            // does, we have to take these extra leap days into account if the date is greater
            // than or equal to 2/29/4000 or 2/29/8000.
            int daysBetweenSASandDotNetReference = DaysBetweenSASandDotNetReference;
            if (dotNetDateTime >= new DateTime(8000, 2, 29))
                daysBetweenSASandDotNetReference += 2;
            else if (dotNetDateTime >= new DateTime(4000, 2, 29))
                daysBetweenSASandDotNetReference++;

            double days = (double)dotNetDateTime.Ticks / TimeSpan.TicksPerDay;	// result is number of days since 01JAN0001, according to .NET
            days -= daysBetweenSASandDotNetReference;		// result is number of days since 01JAN1960, according to SAS
            return days;
        }

        /// <summary>
        /// Converts a .NET DateTime to a SAS date value.
        /// </summary>
        /// <param name="dotNetDateTime">The .NET DateTime to convert.</param>
        /// <returns>The equivalent SAS datetime value.</returns>
        public static double DotNetToSASDatetime(DateTime dotNetDateTime)
        {
            double sasDatetime = DotNetToSASDate(dotNetDateTime.Date) * SecondsPerDay;
            double partDayInSeconds = DotNetToSASTime(dotNetDateTime.TimeOfDay);
            return sasDatetime + partDayInSeconds;
        }

        /// <summary>
        /// Converts a .NET TimeSpan to a SAS time value.
        /// </summary>
        /// <param name="dotNetTime">The .NET TimeSpan to convert.</param>
        /// <returns>The equivalent SAS time value.</returns>
        public static double DotNetToSASTime(TimeSpan dotNetTime)
        {
            return (double)dotNetTime.Ticks / TimeSpan.TicksPerSecond;
        }

        public static List<SPList> GetLists(string siteUrl)
        {
            List<SPList> rc = new List<SPList>();
            using (ClientContext SPContext = new ClientContext(siteUrl))
            {
                Web site = SPContext.Web;
                SPContext.Load(site);
                SPContext.ExecuteQuery();

                ListCollection myListCollection = site.Lists;
                SPContext.Load(myListCollection);
                SPContext.ExecuteQuery();

                foreach (List curList in myListCollection)
                {
                    SPContext.Load(curList);
                    SPContext.ExecuteQuery();
                    rc.Add(new SPList(curList, siteUrl));
                }
            }
            return rc;
        }

        public static List<SPColumn> GetColumnList(SPList list)
        {
            List<SPColumn> rc = new List<SPColumn>();
            using (ClientContext cc = new ClientContext(list.siteUrl))
            {
                Web site = cc.Web;
                cc.Load(site);
                cc.Load(site.Lists);
                cc.ExecuteQuery();
                List splist = site.Lists.GetById(list.ID);

                cc.Load(splist);
                cc.Load(splist.Fields);
                cc.ExecuteQuery();
                foreach (Field f in splist.Fields)
                {
                    cc.Load(f);
                    cc.ExecuteQuery();
                    try
                    {
                        switch (f.FieldTypeKind)
                        {
                            case FieldType.Integer:
                            case FieldType.Text:
                            case FieldType.Note:
                            case FieldType.DateTime:
                            case FieldType.Counter:
                            case FieldType.Choice:
                            case FieldType.Boolean:
                            case FieldType.Number:
                            case FieldType.Currency:
                            case FieldType.URL:
                            case FieldType.Guid:
                            case FieldType.MultiChoice:
                            case FieldType.GridChoice:
                            case FieldType.User:                                
                                rc.Add(new SPColumn(f, splist, -1));
                                break;
                        }
                    }
                    catch (Exception ex)
                    {                        
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
            }
            return rc;
        }               
    }

}
