using SAS.Shared.AddIns;
using SAS.Tasks.Toolkit;
using System;
using System.Collections.Generic;

namespace ImportSPListToEG
{
    // unique identifier for this task
    [ClassId("DAD97A48-D339-456E-9BC0-51713700A2E7")]
    // location of the task icon to show in the menu and process flow
    [IconLocation("ImportSPListToEG.task.ico")]
    // InputResourceType.Data for data set, or 
    // InputResourceType.None for none required
    [InputRequired(InputResourceType.None)]
    public class ImportFromSharePointTask : SasTask
    {
        #region private members

        private ImportFromSharePointListTaskSettings settings;

        #endregion

        #region Initialization
        public ImportFromSharePointTask()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // 
            // ImportSPListToEG
            // 
            this.GeneratesReportOutput = false;
            this.ProcsUsed = "DATA Step";
            this.ProductsRequired = "Base";
            this.RequiresData = false;
            this.TaskCategory = "Data";
            this.TaskDescription = "Create a SAS Dataset based on a SharePoint list";
            this.TaskName = "Import Data From SharePoint List";

        }
        #endregion

        #region overrides
        public override bool Initialize()
        {
            settings = new ImportFromSharePointListTaskSettings();
            return true;
        }

        public override string GetXmlState()
        {
            return settings.ToXml();
        }

        public override void RestoreStateFromXml(string xmlState)
        {
            settings = new ImportFromSharePointListTaskSettings();
            settings.FromXml(xmlState);
        }

        /// <summary>
        /// Show the task user interface
        /// </summary>
        /// <param name="Owner"></param>
        /// <returns>whether to cancel the task, or run now</returns>
        public override ShowResult Show(System.Windows.Forms.IWin32Window Owner)
        {
            ImportFromSharePointListTaskForm dlg = new ImportFromSharePointListTaskForm(this.Consumer);
            dlg.Settings = settings;
            if (System.Windows.Forms.DialogResult.OK == dlg.ShowDialog(Owner))
            {
                // gather settings values from the dialog
                settings = dlg.Settings;
                return ShowResult.RunNow;
            }
            else
                return ShowResult.Canceled;
        }

        /// <summary>
        /// Get the SAS program that this task should generate
        /// based on the options specified.
        /// </summary>
        /// <returns>a valid SAS program to run</returns>
        public override string GetSasCode()
        {
            SasServer s = new SasServer(Consumer.AssignedServer);
            string enc = s.GetSasSystemOptionValue("ENCODING");
            SPList.ServerCodePage = SASEncodingToWindowsCodepage(enc);
            return settings.GetSasProgram();
        }

        public override int OutputDataCount { get { return 1; } }
        public override System.Collections.Generic.List<ISASTaskDataDescriptor> OutputDataDescriptorList
        {
            get
            {
                List<ISASTaskDataDescriptor> rc = null;
                if (this.Consumer != null)
                {
                    rc = new List<ISASTaskDataDescriptor>();
                    rc.Add(SASTaskDataDescriptor.CreateLibrefDataDescriptor(Consumer.AssignedServer, settings.outputLibrary, settings.outputDataName, settings.outputDataName));
                }
                return rc;
            }
        }
        public override void OnCreateNewOutputDataNames()
        {
            base.OnCreateNewOutputDataNames();
        }
        #endregion

        #region static map of sas encodings to windows codepage and util methods
        static private Dictionary<String, Int32> SASEncodings = null;
        static private void InitializeSASEncodings()
        {
            if (SASEncodings == null)
                SASEncodings = new Dictionary<String, Int32>();

            SASEncodings.Clear();

            // 12 character ENDOCING names.
            SASEncodings.Add("utf-7".ToUpper(), 65000);
            SASEncodings.Add("utf-8".ToUpper(), 65001);
            SASEncodings.Add("utf-16le".ToUpper(), 1200);
            SASEncodings.Add("utf-16".ToUpper(), 1200);
            SASEncodings.Add("utf-16be".ToUpper(), 1201);
            SASEncodings.Add("utf-32le".ToUpper(), 12000);
            SASEncodings.Add("utf-32".ToUpper(), 12000);
            SASEncodings.Add("utf-32be".ToUpper(), 12001);
            SASEncodings.Add("us-ascii".ToUpper(), 20127);
            SASEncodings.Add("wlatin1".ToUpper(), 1252);
            SASEncodings.Add("wlatin2".ToUpper(), 1250);
            SASEncodings.Add("wbaltic".ToUpper(), 1257);
            SASEncodings.Add("wcyrillic".ToUpper(), 1251);
            SASEncodings.Add("warabic".ToUpper(), 1256);
            SASEncodings.Add("wgreek".ToUpper(), 1253);
            SASEncodings.Add("whebrew".ToUpper(), 1255);
            SASEncodings.Add("wturkish".ToUpper(), 1254);
            SASEncodings.Add("wvietnamese".ToUpper(), 1258);
            SASEncodings.Add("pcoem874".ToUpper(), 874);
            SASEncodings.Add("msdos720".ToUpper(), 720);
            SASEncodings.Add("msdos737".ToUpper(), 737);
            SASEncodings.Add("msdos775".ToUpper(), 775);
            SASEncodings.Add("aroman".ToUpper(), 10000);
            SASEncodings.Add("aarabic".ToUpper(), 10004);
            SASEncodings.Add("ahebrew".ToUpper(), 10005);
            SASEncodings.Add("agreek".ToUpper(), 10006);
            SASEncodings.Add("acyrillic".ToUpper(), 10007);
            SASEncodings.Add("athai".ToUpper(), 10021);
            SASEncodings.Add("aeasteuro".ToUpper(), 10029);
            SASEncodings.Add("aturkish".ToUpper(), 10081);
            SASEncodings.Add("acroatian".ToUpper(), 10082);
            SASEncodings.Add("aiceland".ToUpper(), 10079);
            SASEncodings.Add("aromanian".ToUpper(), 10010);
            SASEncodings.Add("aukrainian".ToUpper(), 10017);
            SASEncodings.Add("ebcdic037".ToUpper(), 37);
            SASEncodings.Add("ebcdic273".ToUpper(), 20273);
            SASEncodings.Add("ebcdic275".ToUpper(), 0);
            SASEncodings.Add("ebcdic277".ToUpper(), 20277);
            SASEncodings.Add("ebcdic278".ToUpper(), 20278);
            SASEncodings.Add("ebcdic280".ToUpper(), 20280);
            SASEncodings.Add("ebcdic284".ToUpper(), 20284);
            SASEncodings.Add("ebcdic285".ToUpper(), 20285);
            SASEncodings.Add("ebcdic297".ToUpper(), 20287);
            SASEncodings.Add("ebcdic420".ToUpper(), 20420);
            SASEncodings.Add("ebcdic424".ToUpper(), 20424);
            SASEncodings.Add("ebcdic425".ToUpper(), 0);
            SASEncodings.Add("ebcdic500".ToUpper(), 500);
            SASEncodings.Add("ebcdic838".ToUpper(), 20838);
            SASEncodings.Add("ebcdic870".ToUpper(), 870);
            SASEncodings.Add("ebcdic875".ToUpper(), 875);
            SASEncodings.Add("ebcdic924".ToUpper(), 20924);
            SASEncodings.Add("ebcdic1025".ToUpper(), 21025);
            SASEncodings.Add("ebcdic1026".ToUpper(), 1026);
            SASEncodings.Add("ebcdic1047".ToUpper(), 1047);
            SASEncodings.Add("ebcdic1112".ToUpper(), 0);
            SASEncodings.Add("ebcdic1122".ToUpper(), 0);
            SASEncodings.Add("ebcdic1130".ToUpper(), 0);
            SASEncodings.Add("ebcdic1140".ToUpper(), 1140);
            SASEncodings.Add("ebcdic1141".ToUpper(), 1141);
            SASEncodings.Add("ebcdic1142".ToUpper(), 1142);
            SASEncodings.Add("ebcdic1143".ToUpper(), 1143);
            SASEncodings.Add("ebcdic1144".ToUpper(), 1144);
            SASEncodings.Add("ebcdic1145".ToUpper(), 1145);
            SASEncodings.Add("ebcdic1146".ToUpper(), 1146);
            SASEncodings.Add("ebcdic1147".ToUpper(), 1147);
            SASEncodings.Add("ebcdic1148".ToUpper(), 1148);
            SASEncodings.Add("pcoem437".ToUpper(), 437);
            SASEncodings.Add("pcoem850".ToUpper(), 850);
            SASEncodings.Add("pcoem852".ToUpper(), 852);
            SASEncodings.Add("pcoem855".ToUpper(), 855);
            SASEncodings.Add("pcoem857".ToUpper(), 857);
            SASEncodings.Add("pcoem858".ToUpper(), 858);
            SASEncodings.Add("pcoem860".ToUpper(), 860);
            SASEncodings.Add("pcoem862".ToUpper(), 862);
            SASEncodings.Add("pcoem863".ToUpper(), 863);
            SASEncodings.Add("pcoem864".ToUpper(), 864);
            SASEncodings.Add("pcoem865".ToUpper(), 865);
            SASEncodings.Add("pcoem866".ToUpper(), 866);
            SASEncodings.Add("pcoem869".ToUpper(), 869);
            // SASEncodings.Add("pcoem874".ToUpper(), 874);
            SASEncodings.Add("pcoem921".ToUpper(), 0);
            SASEncodings.Add("pcoem922".ToUpper(), 0);
            SASEncodings.Add("pcoem1129".ToUpper(), 0);
            SASEncodings.Add("latin1".ToUpper(), 28591);
            SASEncodings.Add("latin2".ToUpper(), 28592);
            SASEncodings.Add("cyrillic".ToUpper(), 28595);
            SASEncodings.Add("arabic".ToUpper(), 28596);
            SASEncodings.Add("greek".ToUpper(), 28597);
            SASEncodings.Add("hebrew".ToUpper(), 28598);
            SASEncodings.Add("latin5".ToUpper(), 28599);
            SASEncodings.Add("latin6".ToUpper(), 0);
            SASEncodings.Add("thai".ToUpper(), 0);
            SASEncodings.Add("latin9".ToUpper(), 28605);
            SASEncodings.Add("roman8".ToUpper(), 0);
            SASEncodings.Add("saslatin1".ToUpper(), 0);
            SASEncodings.Add("saslatin2".ToUpper(), 0);
            SASEncodings.Add("sas1047".ToUpper(), 0);
            SASEncodings.Add("open_ed-037".ToUpper(), 37);
            SASEncodings.Add("open_ed-273".ToUpper(), 20273);
            SASEncodings.Add("open_ed-275".ToUpper(), 0);
            SASEncodings.Add("open_ed-277".ToUpper(), 20277);
            SASEncodings.Add("open_ed-278".ToUpper(), 20278);
            SASEncodings.Add("open_ed-280".ToUpper(), 20280);
            SASEncodings.Add("open_ed-284".ToUpper(), 20284);
            SASEncodings.Add("open_ed-285".ToUpper(), 20285);
            SASEncodings.Add("open_ed-297".ToUpper(), 20297);
            SASEncodings.Add("open_ed-420".ToUpper(), 20420);
            SASEncodings.Add("open_ed-424".ToUpper(), 20424);
            SASEncodings.Add("open_ed-500".ToUpper(), 500);
            SASEncodings.Add("open_ed-803".ToUpper(), 0);
            SASEncodings.Add("open_ed-838".ToUpper(), 20838);
            SASEncodings.Add("open_ed-870".ToUpper(), 870);
            SASEncodings.Add("open_ed-875".ToUpper(), 875);
            SASEncodings.Add("open_ed-924".ToUpper(), 20924);
            SASEncodings.Add("open_ed-1025".ToUpper(), 21025);
            SASEncodings.Add("open_ed-1026".ToUpper(), 1026);
            SASEncodings.Add("open_ed-1047".ToUpper(), 1047);
            SASEncodings.Add("open_ed-1112".ToUpper(), 0);
            SASEncodings.Add("open_ed-1122".ToUpper(), 0);
            SASEncodings.Add("open_ed-1130".ToUpper(), 0);
            SASEncodings.Add("open_ed-1140".ToUpper(), 1140);
            SASEncodings.Add("open_ed-1141".ToUpper(), 1141);
            SASEncodings.Add("open_ed-1142".ToUpper(), 1142);
            SASEncodings.Add("open_ed-1143".ToUpper(), 1143);
            SASEncodings.Add("open_ed-1144".ToUpper(), 1144);
            SASEncodings.Add("open_ed-1145".ToUpper(), 1145);
            SASEncodings.Add("open_ed-1146".ToUpper(), 1146);
            SASEncodings.Add("open_ed-1147".ToUpper(), 1147);
            SASEncodings.Add("open_ed-1148".ToUpper(), 1148);
            SASEncodings.Add("ucs-2".ToUpper(), 1200);
            SASEncodings.Add("z_sbcs_1114".ToUpper(), 0);
            SASEncodings.Add("bigfive".ToUpper(), 0);
            SASEncodings.Add("cns11643-1".ToUpper(), 0);
            SASEncodings.Add("cns11643-2".ToUpper(), 0);
            SASEncodings.Add("cns11643-3".ToUpper(), 0);
            SASEncodings.Add("z_dbcs_835".ToUpper(), 0);
            SASEncodings.Add("ibm-937".ToUpper(), 0);
            SASEncodings.Add("fujitsu-tw".ToUpper(), 0);
            SASEncodings.Add("hitachi-tw".ToUpper(), 0);
            SASEncodings.Add("hitsas-tw".ToUpper(), 0);
            SASEncodings.Add("dec-tw".ToUpper(), 0);
            SASEncodings.Add("euc-tw".ToUpper(), 0);
            SASEncodings.Add("hp15-tw".ToUpper(), 0);
            SASEncodings.Add("big5".ToUpper(), 950);
            SASEncodings.Add("ms-950".ToUpper(), 950);
            SASEncodings.Add("ibm-950".ToUpper(), 950);
            SASEncodings.Add("macos-2".ToUpper(), 0);
            SASEncodings.Add("ibm-935".ToUpper(), 0);
            SASEncodings.Add("fujitsu-cn".ToUpper(), 0);
            SASEncodings.Add("hitachi-cn".ToUpper(), 0);
            SASEncodings.Add("hitsas-cn".ToUpper(), 0);
            SASEncodings.Add("dec-cn".ToUpper(), 0);
            SASEncodings.Add("euc-cn".ToUpper(), 51936);
            SASEncodings.Add("ms-936".ToUpper(), 936);
            SASEncodings.Add("ibm-1381".ToUpper(), 0);
            SASEncodings.Add("macos-25".ToUpper(), 0);
            SASEncodings.Add("ibm-939".ToUpper(), 0);
            SASEncodings.Add("ibm-930".ToUpper(), 0);
            SASEncodings.Add("fujitsu-jp".ToUpper(), 0);
            SASEncodings.Add("fujitsu-kana".ToUpper(), 0);
            SASEncodings.Add("hitachi-jp".ToUpper(), 0);
            SASEncodings.Add("hitachi-kana".ToUpper(), 0);
            SASEncodings.Add("pcjis".ToUpper(), 0);
            SASEncodings.Add("jis-7".ToUpper(), 0);
            SASEncodings.Add("hitsas-jp".ToUpper(), 0);
            SASEncodings.Add("hitsas-kana".ToUpper(), 0);
            SASEncodings.Add("nec-jp".ToUpper(), 0);
            SASEncodings.Add("nec-kana".ToUpper(), 0);
            SASEncodings.Add("dec-jp".ToUpper(), 0);
            SASEncodings.Add("euc-jp".ToUpper(), 51932);
            SASEncodings.Add("shift-jis".ToUpper(), 932);
            SASEncodings.Add("macos-1".ToUpper(), 10001);
            SASEncodings.Add("ms-932".ToUpper(), 932);
            SASEncodings.Add("ibm-942".ToUpper(), 0);
            SASEncodings.Add("kor-cp833".ToUpper(), 20833);
            SASEncodings.Add("kor-cp1088".ToUpper(), 0);
            SASEncodings.Add("kor-cp1126".ToUpper(), 0);
            SASEncodings.Add("ks-5601-1992".ToUpper(), 0);
            SASEncodings.Add("ks-5657-1991".ToUpper(), 0);
            SASEncodings.Add("kor-cp834".ToUpper(), 0);
            SASEncodings.Add("kor-cp951".ToUpper(), 0);
            SASEncodings.Add("kor-cp971".ToUpper(), 0);
            SASEncodings.Add("kor-cp1362".ToUpper(), 0);
            SASEncodings.Add("ibm-933".ToUpper(), 0);
            SASEncodings.Add("fujitsu-ko".ToUpper(), 0);
            SASEncodings.Add("hitachi-ko".ToUpper(), 0);
            SASEncodings.Add("hitsas-ko".ToUpper(), 0);
            SASEncodings.Add("euc-kr".ToUpper(), 51949);
            SASEncodings.Add("ms-949".ToUpper(), 949);
            SASEncodings.Add("ibm-949".ToUpper(), 949);
            SASEncodings.Add("macos-3".ToUpper(), 0);
            SASEncodings.Add("utf-e".ToUpper(), 0);
            SASEncodings.Add("uscu".ToUpper(), 0);

            // 4 character ENCODING names
            SASEncodings.Add("ansi".ToUpper(), 20127);
            SASEncodings.Add("wlt1".ToUpper(), 1252);
            SASEncodings.Add("wlt2".ToUpper(), 1250);
            SASEncodings.Add("wbal".ToUpper(), 1257);
            SASEncodings.Add("wcyr".ToUpper(), 1251);
            SASEncodings.Add("wara".ToUpper(), 1256);
            SASEncodings.Add("wgrk".ToUpper(), 1253);
            SASEncodings.Add("wheb".ToUpper(), 1255);
            SASEncodings.Add("wtur".ToUpper(), 1254);
            SASEncodings.Add("wvie".ToUpper(), 1258);
            SASEncodings.Add("p874".ToUpper(), 874);
            SASEncodings.Add("p720".ToUpper(), 720);
            SASEncodings.Add("p737".ToUpper(), 737);
            SASEncodings.Add("p775".ToUpper(), 775);
            SASEncodings.Add("arom".ToUpper(), 10000);
            SASEncodings.Add("aara".ToUpper(), 10004);
            SASEncodings.Add("aheb".ToUpper(), 10005);
            SASEncodings.Add("agrk".ToUpper(), 10006);
            SASEncodings.Add("acyr".ToUpper(), 10007);
            SASEncodings.Add("atha".ToUpper(), 10021);
            SASEncodings.Add("aeur".ToUpper(), 10029);
            SASEncodings.Add("atur".ToUpper(), 10081);
            SASEncodings.Add("acro".ToUpper(), 10082);
            SASEncodings.Add("aice".ToUpper(), 10079);
            SASEncodings.Add("armn".ToUpper(), 10010);
            SASEncodings.Add("aukr".ToUpper(), 10017);
            SASEncodings.Add("e037".ToUpper(), 37);
            SASEncodings.Add("e273".ToUpper(), 20273);
            SASEncodings.Add("e275".ToUpper(), 0);
            SASEncodings.Add("e277".ToUpper(), 20277);
            SASEncodings.Add("e278".ToUpper(), 20278);
            SASEncodings.Add("e280".ToUpper(), 20280);
            SASEncodings.Add("e284".ToUpper(), 20284);
            SASEncodings.Add("e285".ToUpper(), 20285);
            SASEncodings.Add("e297".ToUpper(), 20287);
            SASEncodings.Add("e420".ToUpper(), 20420);
            SASEncodings.Add("e424".ToUpper(), 20424);
            SASEncodings.Add("e425".ToUpper(), 0);
            SASEncodings.Add("e500".ToUpper(), 500);
            SASEncodings.Add("e838".ToUpper(), 20838);
            SASEncodings.Add("e870".ToUpper(), 870);
            SASEncodings.Add("e875".ToUpper(), 875);
            SASEncodings.Add("e924".ToUpper(), 20924);
            SASEncodings.Add("ecyr".ToUpper(), 21025);
            SASEncodings.Add("etur".ToUpper(), 1026);
            SASEncodings.Add("elat".ToUpper(), 1047);
            SASEncodings.Add("ebal".ToUpper(), 0);
            SASEncodings.Add("eest".ToUpper(), 0);
            SASEncodings.Add("evie".ToUpper(), 0);
            SASEncodings.Add("e140".ToUpper(), 1140);
            SASEncodings.Add("e141".ToUpper(), 1141);
            SASEncodings.Add("e142".ToUpper(), 1142);
            SASEncodings.Add("e143".ToUpper(), 1143);
            SASEncodings.Add("e144".ToUpper(), 1144);
            SASEncodings.Add("e145".ToUpper(), 1145);
            SASEncodings.Add("e146".ToUpper(), 1146);
            SASEncodings.Add("e147".ToUpper(), 1147);
            SASEncodings.Add("e148".ToUpper(), 1148);
            SASEncodings.Add("p437".ToUpper(), 437);
            SASEncodings.Add("p850".ToUpper(), 850);
            SASEncodings.Add("p852".ToUpper(), 852);
            SASEncodings.Add("p855".ToUpper(), 855);
            SASEncodings.Add("p857".ToUpper(), 857);
            SASEncodings.Add("p858".ToUpper(), 858);
            SASEncodings.Add("p860".ToUpper(), 860);
            SASEncodings.Add("p862".ToUpper(), 862);
            SASEncodings.Add("p863".ToUpper(), 863);
            SASEncodings.Add("p864".ToUpper(), 864);
            SASEncodings.Add("p865".ToUpper(), 865);
            SASEncodings.Add("p866".ToUpper(), 866);
            SASEncodings.Add("p869".ToUpper(), 869);
            // SASEncodings.Add("p874".ToUpper(), 874);
            SASEncodings.Add("p921".ToUpper(), 0);
            SASEncodings.Add("p922".ToUpper(), 0);
            SASEncodings.Add("pvie".ToUpper(), 0);
            SASEncodings.Add("lat1".ToUpper(), 28591);
            SASEncodings.Add("lat2".ToUpper(), 28592);
            SASEncodings.Add("cyrl".ToUpper(), 28595);
            SASEncodings.Add("arab".ToUpper(), 28596);
            SASEncodings.Add("grek".ToUpper(), 28597);
            SASEncodings.Add("hebr".ToUpper(), 28598);
            SASEncodings.Add("lat5".ToUpper(), 28599);
            SASEncodings.Add("lat6".ToUpper(), 0);
            // SASEncodings.Add("thai".ToUpper(), 0);
            SASEncodings.Add("lat9".ToUpper(), 28605);
            SASEncodings.Add("rom8".ToUpper(), 0);
            SASEncodings.Add("slt1".ToUpper(), 0);
            SASEncodings.Add("slt2".ToUpper(), 0);
            SASEncodings.Add("selt".ToUpper(), 0);
            SASEncodings.Add("eous".ToUpper(), 37);
            SASEncodings.Add("eode".ToUpper(), 20273);
            SASEncodings.Add("eobr".ToUpper(), 0);
            SASEncodings.Add("eoda".ToUpper(), 20277);
            SASEncodings.Add("eofi".ToUpper(), 20278);
            SASEncodings.Add("eoit".ToUpper(), 20280);
            SASEncodings.Add("eoes".ToUpper(), 20284);
            SASEncodings.Add("eouk".ToUpper(), 20285);
            SASEncodings.Add("eofr".ToUpper(), 20297);
            SASEncodings.Add("eoar".ToUpper(), 20420);
            SASEncodings.Add("eoiw".ToUpper(), 20424);
            SASEncodings.Add("eosw".ToUpper(), 500);
            SASEncodings.Add("eoa2".ToUpper(), 0);
            SASEncodings.Add("eoth".ToUpper(), 20838);
            SASEncodings.Add("eol2".ToUpper(), 870);
            SASEncodings.Add("eoel".ToUpper(), 875);
            SASEncodings.Add("eolt".ToUpper(), 20924);
            SASEncodings.Add("eocy".ToUpper(), 21025);
            SASEncodings.Add("eotr".ToUpper(), 1026);
            SASEncodings.Add("eol1".ToUpper(), 1047);
            SASEncodings.Add("eobl".ToUpper(), 0);
            SASEncodings.Add("eoet".ToUpper(), 0);
            SASEncodings.Add("eovi".ToUpper(), 0);
            SASEncodings.Add("eo40".ToUpper(), 1140);
            SASEncodings.Add("eo41".ToUpper(), 1141);
            SASEncodings.Add("eo42".ToUpper(), 1142);
            SASEncodings.Add("eo43".ToUpper(), 1143);
            SASEncodings.Add("eo44".ToUpper(), 1144);
            SASEncodings.Add("eo45".ToUpper(), 1145);
            SASEncodings.Add("eo46".ToUpper(), 1146);
            SASEncodings.Add("eo47".ToUpper(), 1147);
            SASEncodings.Add("eo48".ToUpper(), 1148);
            SASEncodings.Add("unic".ToUpper(), 1200);
            SASEncodings.Add("ucs4".ToUpper(), 12000);
            SASEncodings.Add("ypcs".ToUpper(), 0);
            SASEncodings.Add("five".ToUpper(), 0);
            SASEncodings.Add("cns1".ToUpper(), 0);
            SASEncodings.Add("cns2".ToUpper(), 0);
            SASEncodings.Add("cns3".ToUpper(), 0);
            SASEncodings.Add("ibmt".ToUpper(), 0);
            SASEncodings.Add("yibm".ToUpper(), 0);
            SASEncodings.Add("yfuj".ToUpper(), 0);
            SASEncodings.Add("yhit".ToUpper(), 0);
            SASEncodings.Add("yhts".ToUpper(), 0);
            SASEncodings.Add("yvms".ToUpper(), 0);
            SASEncodings.Add("yeuc".ToUpper(), 0);
            SASEncodings.Add("yhpx".ToUpper(), 0);
            // SASEncodings.Add("big5".ToUpper(), 950);
            SASEncodings.Add("ywin".ToUpper(), 950);
            SASEncodings.Add("ypc".ToUpper(), 950);
            SASEncodings.Add("ymac".ToUpper(), 0);
            SASEncodings.Add("zibm".ToUpper(), 0);
            SASEncodings.Add("zfuj".ToUpper(), 0);
            SASEncodings.Add("zhit".ToUpper(), 0);
            SASEncodings.Add("zhts".ToUpper(), 0);
            SASEncodings.Add("zvms".ToUpper(), 0);
            SASEncodings.Add("zeuc".ToUpper(), 51936);
            SASEncodings.Add("zwin".ToUpper(), 936);
            SASEncodings.Add("zpc".ToUpper(), 0);
            SASEncodings.Add("zmac".ToUpper(), 0);
            SASEncodings.Add("jibm".ToUpper(), 0);
            SASEncodings.Add("j930".ToUpper(), 0);
            SASEncodings.Add("jfuj".ToUpper(), 0);
            SASEncodings.Add("jfuk".ToUpper(), 0);
            SASEncodings.Add("jhit".ToUpper(), 0);
            SASEncodings.Add("jhik".ToUpper(), 0);
            SASEncodings.Add("jspc".ToUpper(), 0);
            SASEncodings.Add("jis7".ToUpper(), 0);
            SASEncodings.Add("jhts".ToUpper(), 0);
            SASEncodings.Add("jhks".ToUpper(), 0);
            SASEncodings.Add("jnec".ToUpper(), 0);
            SASEncodings.Add("jnek".ToUpper(), 0);
            SASEncodings.Add("jvms".ToUpper(), 0);
            SASEncodings.Add("jeuc".ToUpper(), 51932);
            SASEncodings.Add("sjis".ToUpper(), 932);
            SASEncodings.Add("jmac".ToUpper(), 10001);
            SASEncodings.Add("j932".ToUpper(), 932);
            SASEncodings.Add("j942".ToUpper(), 0);
            SASEncodings.Add("k833".ToUpper(), 20833);
            SASEncodings.Add("kpcs".ToUpper(), 0);
            SASEncodings.Add("kwsb".ToUpper(), 0);
            SASEncodings.Add("ksdb".ToUpper(), 0);
            SASEncodings.Add("kdbx".ToUpper(), 0);
            SASEncodings.Add("k834".ToUpper(), 0);
            SASEncodings.Add("k951".ToUpper(), 0);
            SASEncodings.Add("k971".ToUpper(), 0);
            SASEncodings.Add("kwdb".ToUpper(), 0);
            SASEncodings.Add("kibm".ToUpper(), 0);
            SASEncodings.Add("kfuj".ToUpper(), 0);
            SASEncodings.Add("khit".ToUpper(), 0);
            SASEncodings.Add("khts".ToUpper(), 0);
            SASEncodings.Add("keuc".ToUpper(), 51949);
            SASEncodings.Add("kwin".ToUpper(), 949);
            SASEncodings.Add("kpc".ToUpper(), 949);
            SASEncodings.Add("kmac".ToUpper(), 0);
            SASEncodings.Add("utf7".ToUpper(), 65000);
            SASEncodings.Add("utf8".ToUpper(), 65001);
            SASEncodings.Add("utfe".ToUpper(), 0);
            SASEncodings.Add("utf2".ToUpper(), 1200);
            // SASEncodings.Add("uscu".ToUpper(), 0);

            // 32 character ENCODING names
            SASEncodings.Add("ASCII (ANSII)".ToUpper(), 20127);
            SASEncodings.Add("Western (Windows)".ToUpper(), 1252);
            SASEncodings.Add("Central Europe (Windows)".ToUpper(), 1250);
            SASEncodings.Add("Baltic (Windows)".ToUpper(), 1257);
            SASEncodings.Add("Cyrillic (Windows)".ToUpper(), 1251);
            SASEncodings.Add("Arabic (Windows)".ToUpper(), 1256);
            SASEncodings.Add("Greek (Windows)".ToUpper(), 1253);
            SASEncodings.Add("Hebrew (Windows)".ToUpper(), 1255);
            SASEncodings.Add("Turkish (Windows)".ToUpper(), 1254);
            SASEncodings.Add("Vietnamese (Windows)".ToUpper(), 1258);
            SASEncodings.Add("Thai (Windows)".ToUpper(), 874);
            SASEncodings.Add("Arabic (MS-DOS)".ToUpper(), 720);
            SASEncodings.Add("Greek (MS-DOS)".ToUpper(), 737);
            SASEncodings.Add("Baltic (MS-DOS)".ToUpper(), 775);
            SASEncodings.Add("Roman (MacIntosh)".ToUpper(), 10000);
            SASEncodings.Add("Arabic (MacIntosh)".ToUpper(), 10004);
            SASEncodings.Add("Hebrew (MacIntosh)".ToUpper(), 10005);
            SASEncodings.Add("Greek (MacIntosh)".ToUpper(), 10006);
            SASEncodings.Add("Cyrillic (MacIntosh)".ToUpper(), 10007);
            SASEncodings.Add("Thai (MacIntosh)".ToUpper(), 10021);
            SASEncodings.Add("East Europe (MacIntosh)".ToUpper(), 10029);
            SASEncodings.Add("Turkish (MacIntosh)".ToUpper(), 10081);
            SASEncodings.Add("Croatian (MacIntosh)".ToUpper(), 10082);
            SASEncodings.Add("Icelandic (MacIntosh)".ToUpper(), 10079);
            SASEncodings.Add("Romanian (MacIntosh)".ToUpper(), 10010);
            SASEncodings.Add("Ukrainian (MacIntosh)".ToUpper(), 10017);
            SASEncodings.Add("Old North American (EBCDIC)".ToUpper(), 37);
            SASEncodings.Add("Old Austria/Germany(EBCDIC)".ToUpper(), 20273);
            SASEncodings.Add("Brazil (EBCDIC)".ToUpper(), 0);
            SASEncodings.Add("Old Denmark/Norway (EBCDIC)".ToUpper(), 20277);
            SASEncodings.Add("Old Finland/Sweden (EBCDIC)".ToUpper(), 20278);
            SASEncodings.Add("Old Italy (EBCDIC)".ToUpper(), 20280);
            SASEncodings.Add("Old Spain (EBCDIC)".ToUpper(), 20284);
            SASEncodings.Add("Old United Kingdom (EBCDIC)".ToUpper(), 20285);
            SASEncodings.Add("Old France (EBCDIC)".ToUpper(), 20287);
            SASEncodings.Add("Old Arabic (EBCDIC)".ToUpper(), 20420);
            SASEncodings.Add("Hebrew (EBCDIC)".ToUpper(), 20424);
            SASEncodings.Add("Arabic (EBCDIC)".ToUpper(), 0);
            SASEncodings.Add("Old International (EBCDIC)".ToUpper(), 500);
            SASEncodings.Add("Thai (EBCDIC)".ToUpper(), 20838);
            SASEncodings.Add("Central Europe (EBCDIC)".ToUpper(), 870);
            SASEncodings.Add("Greek (EBCDIC)".ToUpper(), 875);
            SASEncodings.Add("European (EBCDIC)".ToUpper(), 20924);
            SASEncodings.Add("Cyrillic (EBCDIC)".ToUpper(), 21025);
            SASEncodings.Add("Turkish (EBCDIC)".ToUpper(), 1026);
            SASEncodings.Add("Western (EBCDIC)".ToUpper(), 1047);
            SASEncodings.Add("Baltic (EBCDIC)".ToUpper(), 0);
            SASEncodings.Add("Estonian (EBCDIC)".ToUpper(), 0);
            SASEncodings.Add("Vietnamese (EBCDIC)".ToUpper(), 0);
            SASEncodings.Add("North American (EBCDIC)".ToUpper(), 1140);
            SASEncodings.Add("Austria/Germany (EBCDIC)".ToUpper(), 1141);
            SASEncodings.Add("Denmark/Norway (EBCDIC)".ToUpper(), 1142);
            SASEncodings.Add("Finland/Sweden (EBCDIC)".ToUpper(), 1143);
            SASEncodings.Add("Italy (EBCDIC)".ToUpper(), 1144);
            SASEncodings.Add("Spain (EBCDIC)".ToUpper(), 1145);
            SASEncodings.Add("United Kingdom (EBCDIC)".ToUpper(), 1146);
            SASEncodings.Add("France (EBCDIC)".ToUpper(), 1147);
            SASEncodings.Add("International (EBCDIC)".ToUpper(), 1148);
            SASEncodings.Add("USA (IBM-PC)".ToUpper(), 437);
            SASEncodings.Add("Western (IBM-PC)".ToUpper(), 850);
            SASEncodings.Add("Central Europe (IBM-PC)".ToUpper(), 852);
            SASEncodings.Add("Cyrillic deprecated  (IBM-PC)".ToUpper(), 855);
            SASEncodings.Add("Turkish  (IBM-PC)".ToUpper(), 857);
            SASEncodings.Add("European (IBM-PC)".ToUpper(), 858);
            SASEncodings.Add("Portuguese (IBM-PC)".ToUpper(), 860);
            SASEncodings.Add("Hebrew (IBM-PC)".ToUpper(), 862);
            SASEncodings.Add("French Canadian (IBM-PC)".ToUpper(), 863);
            SASEncodings.Add("Arabic (IBM-PC)".ToUpper(), 864);
            SASEncodings.Add("Nordic (IBM-PC)".ToUpper(), 865);
            SASEncodings.Add("Cyrillic (IBM-PC)".ToUpper(), 866);
            SASEncodings.Add("Greek (IBM-PC)".ToUpper(), 869);
            SASEncodings.Add("Thai (IBM-PC)".ToUpper(), 874);
            SASEncodings.Add("Baltic (IBM-PC)".ToUpper(), 0);
            SASEncodings.Add("Estonia (IBM-PC)".ToUpper(), 0);
            SASEncodings.Add("Vietnamese (IBM-PC)".ToUpper(), 0);
            SASEncodings.Add("Western (ISO)".ToUpper(), 28591);
            SASEncodings.Add("Central Europe (ISO)".ToUpper(), 28592);
            SASEncodings.Add("Cyrillic (ISO)".ToUpper(), 28595);
            SASEncodings.Add("Arabic (ISO)".ToUpper(), 28596);
            SASEncodings.Add("Greek (ISO)".ToUpper(), 28597);
            SASEncodings.Add("Hebrew (ISO)".ToUpper(), 28598);
            SASEncodings.Add("Turkish (ISO)".ToUpper(), 28599);
            SASEncodings.Add("Baltic (ISO)".ToUpper(), 0);
            SASEncodings.Add("Thai (ISO)".ToUpper(), 0);
            SASEncodings.Add("European (ISO)".ToUpper(), 28605);
            SASEncodings.Add("Roman (HP)".ToUpper(), 0);
            SASEncodings.Add("Western (SAS-Windows)".ToUpper(), 0);
            SASEncodings.Add("Central Europe (SAS-Windows)".ToUpper(), 0);
            SASEncodings.Add("Western (SAS-EBCDIC)".ToUpper(), 0);
            SASEncodings.Add("Old North American (OpenEdition)".ToUpper(), 37);
            SASEncodings.Add("Old Austria/Germany(OpenEdition)".ToUpper(), 20273);
            SASEncodings.Add("Brazil (OpenEdition)".ToUpper(), 0);
            SASEncodings.Add("Old Denmark/Norway (OpenEdition)".ToUpper(), 20277);
            SASEncodings.Add("Old Finland/Sweden (OpenEdition)".ToUpper(), 20278);
            SASEncodings.Add("Old Italy (OpenEdition)".ToUpper(), 20280);
            SASEncodings.Add("Old Spain (OpenEdition)".ToUpper(), 20284);
            SASEncodings.Add("Old United Kingdom (OpenEdition)".ToUpper(), 20285);
            SASEncodings.Add("Old France (OpenEdition)".ToUpper(), 20297);
            SASEncodings.Add("Old Arabic (OpenEdition)".ToUpper(), 20420);
            SASEncodings.Add("Hebrew (OpenEdition)".ToUpper(), 20424);
            SASEncodings.Add("Old International (OpenEdition)".ToUpper(), 500);
            SASEncodings.Add("Arabic (OpenEdition)".ToUpper(), 0);
            SASEncodings.Add("Thai (OpenEdition)".ToUpper(), 20838);
            SASEncodings.Add("Central Europe (OpenEdition)".ToUpper(), 870);
            SASEncodings.Add("Greek (OpenEdition)".ToUpper(), 875);
            SASEncodings.Add("European (OpenEdition)".ToUpper(), 20924);
            SASEncodings.Add("Cyrillic (OpenEdition)".ToUpper(), 21025);
            SASEncodings.Add("Turkish (OpenEdition)".ToUpper(), 1026);
            SASEncodings.Add("Western (OpenEdition)".ToUpper(), 1047);
            SASEncodings.Add("Baltic (OpenEdition)".ToUpper(), 0);
            SASEncodings.Add("Estonian (OpenEdition)".ToUpper(), 0);
            SASEncodings.Add("Vietnamese (OpenEdition)".ToUpper(), 0);
            SASEncodings.Add("North America (OpenEdition)".ToUpper(), 1140);
            SASEncodings.Add("Austria/Germany (OpenEdition)".ToUpper(), 1141);
            SASEncodings.Add("Denmark/Norway (OpenEdition)".ToUpper(), 1142);
            SASEncodings.Add("Finland/Sweden (OpenEdition)".ToUpper(), 1143);
            SASEncodings.Add("Italy (OpenEdition)".ToUpper(), 1144);
            SASEncodings.Add("Spain (OpenEdition)".ToUpper(), 1145);
            SASEncodings.Add("United Kingdom (OpenEdition)".ToUpper(), 1146);
            SASEncodings.Add("France (OpenEdition)".ToUpper(), 1147);
            SASEncodings.Add("International (OpenEdition)".ToUpper(), 1148);
            SASEncodings.Add("Unicode (UCS-2)".ToUpper(), 1200);
            SASEncodings.Add("Unicode (UTF-32)".ToUpper(), 12000);
            SASEncodings.Add("Trad Chinese - IBM-937".ToUpper(), 0);
            SASEncodings.Add("Trad Chinese - Fujitsu JEF".ToUpper(), 0);
            SASEncodings.Add("Trad Chinese - Hitachi KEIS".ToUpper(), 0);
            SASEncodings.Add("Trad Chinese - SAS Hitachi".ToUpper(), 0);
            SASEncodings.Add("Trad Chinese (DEC)".ToUpper(), 0);
            SASEncodings.Add("Trad Chinese (EUC)".ToUpper(), 0);
            SASEncodings.Add("Trad Chinese (HP15)".ToUpper(), 0);
            SASEncodings.Add("Trad Chinese ()".ToUpper(), 950);
            SASEncodings.Add("Trad Chinese (PCMS)".ToUpper(), 950);
            SASEncodings.Add("Trad Chinese (PCIBM)".ToUpper(), 950);
            SASEncodings.Add("Trad Chinese (PCMAC)".ToUpper(), 0);
            SASEncodings.Add("Simp Chinese (IBM)".ToUpper(), 0);
            SASEncodings.Add("Simp Chinese (FACOM)".ToUpper(), 0);
            SASEncodings.Add("Simp Chinese (HITAC)".ToUpper(), 0);
            SASEncodings.Add("Simp Chinese (XHITAC)".ToUpper(), 0);
            SASEncodings.Add("Simp Chinese (DEC)".ToUpper(), 0);
            SASEncodings.Add("Simp Chinese (EUC)".ToUpper(), 51936);
            SASEncodings.Add("Simp Chinese (PCMS)".ToUpper(), 936);
            SASEncodings.Add("Simp Chinese (PCIBM)".ToUpper(), 0);
            SASEncodings.Add("Simp Chinese (PCMAC)".ToUpper(), 0);
            SASEncodings.Add("Japanese (IBM)".ToUpper(), 0);
            SASEncodings.Add("Katakana (IBM)".ToUpper(), 0);
            SASEncodings.Add("Japanese (FACOM)".ToUpper(), 0);
            SASEncodings.Add("Katakana (FACOM)".ToUpper(), 0);
            SASEncodings.Add("Japanese (HITAC)".ToUpper(), 0);
            SASEncodings.Add("Katakana (HITAC)".ToUpper(), 0);
            SASEncodings.Add("Japanese (PCJIS)".ToUpper(), 0);
            SASEncodings.Add("Japanese (JIS7)".ToUpper(), 0);
            SASEncodings.Add("Japanese (XHITAC)".ToUpper(), 0);
            SASEncodings.Add("Katakana (XHITAC)".ToUpper(), 0);
            SASEncodings.Add("Japanese (NEC)".ToUpper(), 0);
            SASEncodings.Add("Katakana (NEC)".ToUpper(), 0);
            SASEncodings.Add("Japanese (DEC)".ToUpper(), 0);
            SASEncodings.Add("Japanese (EUC)".ToUpper(), 51932);
            SASEncodings.Add("Japanese (SJIS)".ToUpper(), 932);
            SASEncodings.Add("Japanese (PCMAC)".ToUpper(), 10001);
            SASEncodings.Add("Japanese (PCMS)".ToUpper(), 932);
            SASEncodings.Add("Japanese (PCIBM)".ToUpper(), 0);
            SASEncodings.Add("Korean (IBM)".ToUpper(), 0);
            SASEncodings.Add("Korean (FACOM)".ToUpper(), 0);
            SASEncodings.Add("Korean (HITAC)".ToUpper(), 0);
            SASEncodings.Add("Korean (XHITAC)".ToUpper(), 0);
            SASEncodings.Add("Korean (EUC)".ToUpper(), 51949);
            SASEncodings.Add("Korean (PCMS)".ToUpper(), 949);
            SASEncodings.Add("Korean (PCIBM)".ToUpper(), 949);
            SASEncodings.Add("Korean (PCMAC)".ToUpper(), 0);
            SASEncodings.Add("Unicode (UTF-7)".ToUpper(), 65000);
            SASEncodings.Add("Unicode (UTF-8)".ToUpper(), 65001);
            SASEncodings.Add("Unicode (UTF-EBCDIC)".ToUpper(), 0);
            SASEncodings.Add("Unicode (UTF-16)".ToUpper(), 1200);
            SASEncodings.Add("Unicode Compression".ToUpper(), 0);

        }
        static public Int32 SASEncodingToWindowsCodepage(String encodingName)
        {
            if (SASEncodings == null)
                InitializeSASEncodings();

            if (String.IsNullOrEmpty(encodingName) == true)
                throw new ArgumentException("Encoding name was null or an empty string.", "encodingName");

            if (SASEncodings.ContainsKey(encodingName.ToUpper()) == false)
                return 0;

            return SASEncodings[encodingName.ToUpper()];
        }
        #endregion

    }
}