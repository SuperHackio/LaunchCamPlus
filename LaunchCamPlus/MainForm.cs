using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BCSV_Editor;
using Cameras;
using LCPPManager;
using LCPCManager;
using RARCManagment;
using DiscordRichPresence;
using LCPEManager;

namespace LaunchCamPlus
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CenterToScreen();
            Text = "Launch Cam Plus - " + Application.ProductVersion;
            //---------------------------------------------------------------------------------------------
            Loading = true;
            CamTypeComboBox.DataSource = Enum.GetValues(typeof(Camera.CameraType));
            RotationAxisComboBox.SelectedIndex = 0;
            CoordinateComboBox.SelectedIndex = 0;
            Loading = false;
            RIchPresence.Initialize();
            DiscordTimer.Start();
        }
        public MainForm(string Openwith)
        {
            InitializeComponent();
            CenterToScreen();
            Text = "Launch Cam Plus - " + Application.ProductVersion;
            //---------------------------------------------------------------------------------------------
            Loading = true;
            CamTypeComboBox.DataSource = Enum.GetValues(typeof(Camera.CameraType));
            RotationAxisComboBox.SelectedIndex = 0;
            CoordinateComboBox.SelectedIndex = 0;
            Loading = false;
            RIchPresence.Initialize();

            OpenWith(Openwith);
            DiscordTimer.Start();
        }

        /// <summary>
        /// Loads the plugins
        /// </summary>
        public void LoadPlugins()
        {
            PluginLoader loader = new PluginLoader();
            loader.LoadPlugins(@AppDomain.CurrentDomain.BaseDirectory);

            foreach (ILCPE LCPE in PluginLoader.Plugins)
            {
                if (!CheckCompatibility(Version.Parse(Application.ProductVersion), Version.Parse(LCPE.LowestVersion)) & CheckCompatibility(Version.Parse(Application.ProductVersion), LCPE.HighestVersion))
                {
                    MessageBox.Show(LCPE.Name + " cannot be used in LCP " + Application.ProductVersion, "Invalid Plugin Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                if (!loader.Verify(LCPE))
                {
                    MessageBox.Show(LCPE.Name + " cannot be used in Public Builds of LCP." + Environment.NewLine + "If you are testing a plugin, please use a DEV LCP build", "Unsigned Plugin Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                if (!ActivePlugins.Any(P => P == LCPE))
                    ActivePlugins.Add(LCPE);
            }

            foreach (ILCPE Plug in ActivePlugins)
            {
                ToolStripMenuItem TSMI = new ToolStripMenuItem(Plug.Name);
                TSMI.Click += PluginItem_Click;
                TSMI.ToolTipText = Plug.Description;
                TSMI.Tag = Plug;
                TSMI.Image = Properties.Resources.PluginRun;
                PluginsToolStripMenuItem.DropDownItems.Add(TSMI);
                PluginsToolStripMenuItem.Enabled = true;
                PluginsToolStripMenuItem.ToolTipText = $"Active Plugins: {ActivePlugins.Count}";
            }
        }
        /// <summary>
        /// Checks for Updates
        /// </summary>
        /// <returns></returns>
        public bool CheckForUpdates()
        {
            WebClient Client = new WebClient();
            try
            {
                Client.DownloadFile("https://raw.githubusercontent.com/SuperHackio/LaunchCamPlus/master/LaunchCamPlus/UpdateAlert.txt", @AppDomain.CurrentDomain.BaseDirectory + "VersionCheck.txt");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to retrieve update information","Connection Failure",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //No internet lol
            }
            if (File.Exists(@AppDomain.CurrentDomain.BaseDirectory + "VersionCheck.txt")) {
                Version Internet = new Version(File.ReadAllText(@AppDomain.CurrentDomain.BaseDirectory + "VersionCheck.txt"));
                File.Delete(@AppDomain.CurrentDomain.BaseDirectory + "VersionCheck.txt");
                Version Local = new Version(Application.ProductVersion);
                if ( Local.CompareTo(Internet) < 0 )
                    return true;
                else
                    return false;
            }
            else return false;
        }
        /// <summary>
        /// Displays that the Update is ready
        /// </summary>
        public void HasUpdateReady()
        {
            AboutToolStripMenuItem.BackColor = Color.Red;
            GitHubReleasesPageToolStripMenuItem.BackColor = Color.Red;
            GitHubReleasesPageToolStripMenuItem.ToolTipText += " - NEW UPDATE IS READY!";
        }

        List<ILCPE> ActivePlugins = new List<ILCPE>();
        DRPC RIchPresence = new DRPC();

        OpenFileDialog ofd = new OpenFileDialog() { Filter = "Supported Files | *.bcam; *.arc; *.rarc|Camera Files |*.bcam|Level Archive |*.rarc; *.arc" };
        SaveFileDialog sfd = new SaveFileDialog();
        OpenFileDialog pofd = new OpenFileDialog() { Filter = "Preset Files | *.lcpp; *.lcpc|Camera Preset |*.lcpp|Compressed Camera Preset |*.lcpc" }; //presets
        SaveFileDialog psfd = new SaveFileDialog() { Filter = "Camera Preset |*.lcpp|Compressed Camera Preset |*.lcpc" }; //presets
        FileInfo fInfo;

        /// <summary>
        /// Contains all the cameras being used
        /// </summary>
        List<Camera> CameraList = new List<Camera>();
        List<CameraEvent> CameraEventList = new List<CameraEvent>();
        List<Camera> BackupList;
        Camera CopyCamera;
        BCSV bcsv;
        RARC rar;

        public bool HasUpdate = false;
        bool OriginalFile = true;
        int Idletimer = 0;

        string[] Hashes = new string[]{
        #region General
        "14F51CD8", //Version
        "00000D1B", //ID
        "00000DC1", //Num
        "20C58F89", //Type
        "ABC4A1CF",
        "ABC4A1CE",
        "0035807D",
        "002F0DA6",
        "00300D4C",
        "AE79D1C0",
        "EB66C5C3",
        "B6004E72",
        "0033C56B",
        "0033C56C",
        "06A54929",
        "062675A0",
        "D26F6AA9",
        "93AECC0B",
        "069FE297",
        "145863FF",
        "76B41C57",
        "06A558A2",
        "06262B01",
        "05C676D0",
        "730D4555",
#endregion

        #region Coordinates
        "BEC02B34", //Fixpoint Offset X
        "BEC02B35", //Fixpoint Offset Y
        "BEC02B36", //Fixpoint Offset Z
        //--------------------------------------------------------------------------------------------------
        "31CB1323",
        "31CB1324",
        "31CB1325",
        //--------------------------------------------------------------------------------------------------
        "AC52894B",
        "AC52894C",
        "AC52894D",
        //--------------------------------------------------------------------------------------------------
        "3B5CB472",
        "3B5CB473",
        "3B5CB474",
        //--------------------------------------------------------------------------------------------------
        "0036D9C5",
        "0036D9C6",
        "0036D9C7",
        #endregion

        #region Flags
        "41E363AC",
        "9F02074F",
        "82D5627E",
        "E2044E84",
        "521E5C3F",
        "BB74D6C1",
        "DA484167",
        "ED8DD072",
        "67D981E8",
        "26C8C3C0",
        "45E50EE5",
        "1BCD52AA"
        #endregion
        };

        public string[] JapCameraEvents = new string[] {
            #region Common Events [5+]
            "シナリオスターター", //- Scenario starter [!]
            "ピンクスーパースピンドライバー固有出現イベント用", //- For pink super spin driver unique occurrence event
            "ピンクスーパースピンドライバー", //- Pink Super Spin Driver [!]
            "スーパースピンドライバー固有出現イベント用", //- Super spin driver for unique occurrence event
            "スーパースピンドライバー", //- Super spin driver [!]
            "スピンドライバ固有",//- Spin driver specific
            "スピンドライバ", //- Spin driver [!]
            "パワースター出現ポイント固有", //- Power Star Appearence Point Specific
            "パワースター固有", //- Power Star Specific
            "土管固有出現", //- unique appearance of clay pipe
            "簡易デモ実行固有簡易デモ", //- Simple demo execution Specific simple demo
            "伸び植物固有出現デモ", //- Extended plants unique appearance demonstration
            "伸び植物固有掴まり", //- Extended plant-specific grafting
            "つるスライダー固有滑り", //- Vine slider intrinsic slip
            //"ハラペココインチコ固有飛行", //- Halapeco Coin Chico specific flight
            "デブチコ固有変身", //- Debuchico specific makeover
            "デブチコ固有飛行", //- Debuchico specific flight
            #endregion

            #region Generic Events [5]
            "引き戻し", //- Pull Back
            "水上フォロー", //- Water Follow
            "水中フォロー", //- Underwater Follow
            "水中プラネット", //- Underwater Planet
            "フーファイターカメラ", //- Foo Fighter Camera
            #endregion

            #region Other Events [5]
            "デフォルト水面カメラ", //- Default Water Surface Camera [o]
            "デフォルト水中カメラ", //- Default Underwater Camera [o]
            "デフォルトフーファイターカメラ", //- Default Flying Mario Camera [o]
            "スタートカメラ", //- Start Camera [O]
            "デフォルトカメラ" //- Default Camera [O]
            #endregion
            
        }; //Strings marked with [!] need event sub-IDs | Strings marked with [O] are for 'o:' Camera Types

        public string[] EngCameraEvents = new string[] {
            #region Common Events [5+]
            "Scenario Starter", //- シナリオスターター
            "Pink Launch Star Appearance", //- ピンクスーパースピンドライバー固有出現イベント用
            "Pink Launch Star", //- ピンクスーパースピンドライバー
            "Launch Star Appearance", //- スーパースピンドライバー固有出現イベント用
            "Launch Star", //- スーパースピンドライバー
            "Sling Star Appearance", //- スピンドライバ固有
            "Sling Star", //- スピンドライバ
            "Power Star Appear Point",//- パワースター出現ポイント固有
            "Power Star Appearance", //- パワースター固有
            "Warp Pipe", //- 土管固有出現
            "Simple Demo Executor", //- 簡易デモ実行固有簡易デモ
            "Sproutle Vine Appearance", //- 伸び植物固有出現デモ
            "Sproutle Vine", //- 伸び植物固有掴まり
            "Sprauto Vine", //- つるスライダー固有滑り
            //"Hungry Luma (SMG2)", //- ハラペココインチコ固有飛行
            "Hungry Luma Transformation (SMG1)", //- デブチコ固有変身
            "Hungry Luma Flight (SMG1)", //- デブチコ固有飛行
            #endregion

            #region Generic events [5]
            "Pull Back", //- 引き戻し
            "Water Follow", //- 水上フォロー
            "Underwater Follow", //- 水中フォロー
            "Underwater Planet", //- 水中プラネット
            "Foo Fighter", //- フーファイターカメラ
            #endregion

            #region Other Events [5]
            "Default Water Surface Camera", //- デフォルト水面カメラ
            "Default Underwater Camera", //- デフォルト水中カメラ
            "Default Flying Mario", //- デフォルトフーファイターカメラ
            "Default Start", //- スタートカメラ
            "Default Camera" //- デフォルトカメラ
            #endregion
            
        }; //Strings marked with [!] need event sub-IDs | Strings marked with [O] are for 'o:' Camera Types

        int CopyID = 0;

        bool ColSwitch = false;
        int ColR = -1;
        int ColG = -1;
        int ColB = -1;

        bool Loading = false;
        bool Delete = false;

        #region Drawing
        Graphics GraphicsEngine;
        SolidBrush CopiedBrush = new SolidBrush(Color.White);
        RectangleF CopiedIndicator = new RectangleF();
        #endregion

        public void SetAppStatus(bool trigger, bool file = true)
        {
            FileToolStripMenuItem.Enabled = file;
            SaveToolStripMenuItem.Enabled = trigger;
            SaveAsToolStripMenuItem.Enabled = trigger;

            EditToolStripMenuItem.Enabled = trigger;
            ToolsToolStripMenuItem.Enabled = trigger;
            CameraListBox.Enabled = trigger;

            CamIDTextBox.Enabled = trigger;
            CamTypeComboBox.Enabled = trigger;
            RotationTrackBar.Enabled = trigger;
            RotationDegRadioButton.Enabled = trigger;
            RotationRadRadioButton.Enabled = trigger;
            RotationValueNumericUpDown.Enabled = trigger;
            RotationAxisComboBox.Enabled = trigger;

            CamZoomNumericUpDown.Enabled = trigger;
            CamFOVNumericUpDown.Enabled = trigger;
            CamIntNumericUpDown.Enabled = trigger;
            CamEndIntNumericUpDown.Enabled = trigger;
            GndIntNumericUpDown.Enabled = trigger;

            AllowDPadRotationCheckBox.Enabled = trigger;
            Num2CheckBox.Enabled = trigger;
            MaxYNumericUpDown.Enabled = trigger;
            MinYNumericUpDown.Enabled = trigger;

            GroundMoveDelayNumericUpDown.Enabled = trigger;
            AirMoveDelayNumericUpDown.Enabled = trigger;

            FrontZoomNumericUpDown.Enabled = trigger;
            HeightZoomNumericUpDown.Enabled = trigger;
            UDownNumericUpDown.Enabled = trigger;

            UpperNumericUpDown.Enabled = trigger;
            LowerNumericUpDown.Enabled = trigger;

            EventLengthNumericUpDown.Enabled = trigger;
            EventPriorityNumericUpDown.Enabled = trigger;

            foreach (Control Con in CoordinateGroupBox.Controls)
                Con.Enabled = trigger;

            DisableResetCheckBox.Enabled = trigger;
            SharpZoomCheckBox.Enabled = trigger;
            EnableBlurCheckbox.Enabled = trigger;
            NoCollisionCheckBox.Enabled = trigger;
            DisableFirstPersonCheckBox.Enabled = trigger;
            VPanCheckBox.Enabled = trigger;
            EventEndTransCheckBox.Enabled = trigger;
            EventTransCheckBox.Enabled = trigger;
            GEndErpFrameCheckBox.Enabled = trigger;
            GThruCheckBox.Enabled = trigger;
            GEndTransCheckBox.Enabled = trigger;

            MoveUpButton.Enabled = trigger;
            MoveDownButton.Enabled = trigger;
        }

        public float ConvertToBCSVAngle(float angle) => ((float)Math.PI / 180) * angle;
        public float ConvertToBCSVAngle(int angle) => ((float)Math.PI / 180) * angle;

        public int ConvertToAngle(decimal angle) => (int)Math.Round((180 / Math.PI) * (double)angle);

        //---------------------------------------------------------------------------------------------

        private void CameraListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Delete)
                return;
            Loading = true;
            if (CameraList.Count != 0 && CameraListBox.SelectedIndex > -1)
            {
                try
                {
                    CamIDTextBox.Text = CameraList[CameraListBox.SelectedIndex].Identification;
                    Enum.TryParse(CameraList[CameraListBox.SelectedIndex].Type, out Camera.CameraType CT);
                    CamTypeComboBox.SelectedItem = CT;
                    //--------------------------------------------------------------------------------------------------------------------------------------
                    if (RotationDegRadioButton.Checked)
                    {
                        switch (RotationAxisComboBox.SelectedIndex)
                        {
                            case 0:
                                RotationValueNumericUpDown.Value = ConvertToAngle((decimal)CameraList[CameraListBox.SelectedIndex].RefineAngle(CameraList[CameraListBox.SelectedIndex].RotationX));
                                break;
                            case 1:
                                RotationValueNumericUpDown.Value = ConvertToAngle((decimal)CameraList[CameraListBox.SelectedIndex].RefineAngle(CameraList[CameraListBox.SelectedIndex].RotationY));
                                break;
                            case 2:
                                RotationValueNumericUpDown.Value = ConvertToAngle((decimal)CameraList[CameraListBox.SelectedIndex].RefineAngle(CameraList[CameraListBox.SelectedIndex].RotationZ));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("Angle Axis");
                        }
                    }
                    else
                    {
                        switch (RotationAxisComboBox.SelectedIndex)
                        {
                            case 0:
                                RotationValueNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].RotationX;
                                break;
                            case 1:
                                RotationValueNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].RotationY;
                                break;
                            case 2:
                                RotationValueNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].RotationZ;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("Angle Axis");
                        }
                    }
                }
                catch (Exception y)
                {
                    if (y.Message == "Angle Axis")
                    {
                        MessageBox.Show("Failed to read the angle");
                    }
                }
                CamZoomNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].Zoom;
                CamFOVNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].DPDRotation;

                CamIntNumericUpDown.Value = CameraList[CameraListBox.SelectedIndex].TransitionSpeed;
                CamEndIntNumericUpDown.Value = CameraList[CameraListBox.SelectedIndex].EndTransitionSpeed;
                GndIntNumericUpDown.Value = CameraList[CameraListBox.SelectedIndex].GroundMoveSpeed;

                RailCamIDNumericUpDown.Value = CameraList[CameraListBox.SelectedIndex].RailID;
                AllowDPadRotationCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].UseDPAD;
                Num2CheckBox.Checked = CameraList[CameraListBox.SelectedIndex].UnknownNum2;
                MaxYNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].MaxY;
                MinYNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].MinY;
                GroundMoveDelayNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].GroundStartMoveDelay;
                AirMoveDelayNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].AirStartMoveDelay;
                FrontZoomNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].FrontZoom;
                HeightZoomNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].HeightZoom;
                UDownNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].UnknownUDown;

                UpperNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].UpperBorder;
                LowerNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].LowerBorder;

                EventLengthNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].EventFrames;
                EventPriorityNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].EventPriority;

                //--------------------------------------------------------------------------------------------------------------------------------------

                switch (CoordinateComboBox.SelectedIndex)
                {
                    case 0:
                        XNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].FixpointOffsetX;
                        break;
                    case 1:
                        XNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].WorldPointX;
                        break;
                    case 2:
                        XNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].PlayerOffsetX;
                        break;
                    case 3:
                        XNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].UnknownUpX;
                        break;
                    case 4:
                        XNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].VPanAxisX;
                        break;
                }
                switch (CoordinateComboBox.SelectedIndex)
                {
                    case 0:
                        YNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].FixpointOffsetY;
                        break;
                    case 1:
                        YNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].WorldPointY;
                        break;
                    case 2:
                        YNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].PlayerOffsetY;
                        break;
                    case 3:
                        YNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].UnknownUpY;
                        break;
                    case 4:
                        YNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].VPanAxisY;
                        break;
                }
                switch (CoordinateComboBox.SelectedIndex)
                {
                    case 0:
                        ZNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].FixpointOffsetZ;
                        break;
                    case 1:
                        ZNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].WorldPointZ;
                        break;
                    case 2:
                        ZNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].PlayerOffsetZ;
                        break;
                    case 3:
                        ZNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].UnknownUpZ;
                        break;
                    case 4:
                        ZNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].VPanAxisZ;
                        break;
                }

                //--------------------------------------------------------------------------------------------------------------------------------------

                DisableResetCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].DisableReset;
                NoCollisionCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].DisableCollision;
                SharpZoomCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].SharpZoom;
                EnableBlurCheckbox.Checked = CameraList[CameraListBox.SelectedIndex].DisableAntiBlur;
                DisableFirstPersonCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].DisableFirstPerson;
                VPanCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].VPanUse;
                EventEndTransCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].EventUseEndTransition;
                EventTransCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].EventUseTransition;
                GEndErpFrameCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].GFlagEndErpFrame;
                GThruCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].GFlagThrough;
                GEndTransCheckBox.Checked = CameraList[CameraListBox.SelectedIndex].GFlagEndTransitionSpeed;
            }
            Loading = false;
        }

        /// <summary>
        /// Rearranges the cameras
        /// </summary>
        /// <param name="Source">Camera to move</param>
        /// <param name="OldIndex">Camera to move before/after</param>
        /// <param name="Direction">True - Move Up | False - Move down</param>
        private void RearrangeCameras(Camera Source, Camera Location, bool Direction)
        {
            LinkedList<Camera> Reorganize = new LinkedList<Camera>();

            foreach (Camera Cam in CameraList)
            {
                Reorganize.AddLast(Cam);
            }

            LinkedListNode<Camera> MovingNode = Reorganize.Find(Source);
            LinkedListNode<Camera> TargetNode = Reorganize.Find(Location);


            if (Direction)
            {
                Reorganize.Remove(MovingNode);
                Reorganize.AddBefore(TargetNode, Source);
            }
            else
            {
                Reorganize.Remove(MovingNode);
                Reorganize.AddAfter(TargetNode, Source);
            }
            CameraList.Clear();

            foreach (Camera Cam in Reorganize)
            {
                CameraList.Add(Cam);
            }

            CameraListBox.Items.Clear();

            foreach (Camera Cam in CameraList)
            {
                DoNameCheck(Cam);
            }
        }
        
        //---------------------------------------------------------------------------------------------

        #region Loading the Settings

        private void CamIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                DoNameCheck();
                OriginalFile = false;
            }
        }
        
        private void CamTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                CameraList[CameraListBox.SelectedIndex].Type = CamTypeComboBox.SelectedItem.ToString();
                OriginalFile = false;
            }
            switch (CamTypeComboBox.SelectedItem)
            {
                case Camera.CameraType.CAM_TYPE_RAIL_DEMO:
                case Camera.CameraType.CAM_TYPE_RAIL_FOLLOW:
                case Camera.CameraType.CAM_TYPE_RAIL_WATCH:
                    AllowDPadRotationCheckBox.Visible = false;
                    RailCamIDLabel.Visible = true;
                    RailCamIDNumericUpDown.Visible = true;
                    break;
                default:
                    AllowDPadRotationCheckBox.Visible = true;
                    RailCamIDLabel.Visible = false;
                    RailCamIDNumericUpDown.Visible = false;
                    break;
            }
        }

        private void RotationTrackBar_Scroll(object sender, EventArgs e)
        {
            if (RotationDegRadioButton.Checked)
            {
                RotationValueNumericUpDown.Value = RotationTrackBar.Value - 180;
            }
            else
            {
                RotationValueNumericUpDown.Value = (decimal)ConvertToBCSVAngle(RotationTrackBar.Value - 180);
            }
        }

        private void RotationDegRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RotationDegRadioButton.Checked)
            {
                RotationValueNumericUpDown.Value = RotationTrackBar.Value - 180;
                RotationTrackBar.TickStyle = TickStyle.BottomRight;
            }
        }

        private void RotationRadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RotationRadRadioButton.Checked)
            {
                RotationValueNumericUpDown.Value = (decimal)ConvertToBCSVAngle(RotationTrackBar.Value - 180);
                RotationTrackBar.TickStyle = TickStyle.TopLeft;
            }
        }

        private void RotationValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (RotationRadRadioButton.Checked)
            {
                if ((double)RotationValueNumericUpDown.Value > 3.1415900)
                {
                    RotationValueNumericUpDown.Value = (decimal)3.1415900f;
                }
                else if ((double)RotationValueNumericUpDown.Value < -3.1415900)
                {
                    RotationValueNumericUpDown.Value = (decimal)(-3.1415900f);
                }
                RotationTrackBar.Value = ConvertToAngle(RotationValueNumericUpDown.Value) + 180;

                if (!Loading)
                {
                    switch (RotationAxisComboBox.SelectedIndex)
                    {
                        case 0:
                            CameraList[CameraListBox.SelectedIndex].RotationX = (float)RotationValueNumericUpDown.Value;
                            break;
                        case 1:
                            CameraList[CameraListBox.SelectedIndex].RotationY = (float)RotationValueNumericUpDown.Value;
                            break;
                        case 2:
                            CameraList[CameraListBox.SelectedIndex].RotationZ = (float)RotationValueNumericUpDown.Value;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Angle Axis");
                    }
                    OriginalFile = false;
                }
            }
            else
            {
                if ((double)RotationValueNumericUpDown.Value > 180)
                {
                    RotationValueNumericUpDown.Value = (decimal)180;
                }
                else if ((double)RotationValueNumericUpDown.Value < -180)
                {
                    RotationValueNumericUpDown.Value = (decimal)(-180);
                }
                RotationTrackBar.Value = (int)Math.Round(RotationValueNumericUpDown.Value + 180);

                if (!Loading)
                {
                    switch (RotationAxisComboBox.SelectedIndex)
                    {
                        case 0:
                            CameraList[CameraListBox.SelectedIndex].RotationX = ConvertToBCSVAngle((float)RotationValueNumericUpDown.Value);
                            break;
                        case 1:
                            CameraList[CameraListBox.SelectedIndex].RotationY = ConvertToBCSVAngle((float)RotationValueNumericUpDown.Value);
                            break;
                        case 2:
                            CameraList[CameraListBox.SelectedIndex].RotationZ = ConvertToBCSVAngle((float)RotationValueNumericUpDown.Value);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Angle Axis");
                    }
                }
            }
        }

        private void RotationAxisComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            Loading = true;
            try
            {
                if (RotationDegRadioButton.Checked)
                {
                    switch (RotationAxisComboBox.SelectedIndex)
                    {
                        case 0:
                            RotationValueNumericUpDown.Value = ConvertToAngle((decimal)CameraList[CameraListBox.SelectedIndex].RotationX);
                            break;
                        case 1:
                            RotationValueNumericUpDown.Value = ConvertToAngle((decimal)CameraList[CameraListBox.SelectedIndex].RotationY);
                            break;
                        case 2:
                            RotationValueNumericUpDown.Value = ConvertToAngle((decimal)CameraList[CameraListBox.SelectedIndex].RotationZ);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Angle Axis");
                    }
                }
                else
                {
                    switch (RotationAxisComboBox.SelectedIndex)
                    {
                        case 0:
                            RotationValueNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].RotationX;
                            break;
                        case 1:
                            RotationValueNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].RotationY;
                            break;
                        case 2:
                            RotationValueNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].RotationZ;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Angle Axis");
                    }
                }

            }
            catch (Exception)
            {
            }
            Loading = false;
        }

        //---------------------------------------------------------------------------------------------

        private void CamZoomumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                CameraList[CameraListBox.SelectedIndex].Zoom = (float)CamZoomNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        private void FOVNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                CameraList[CameraListBox.SelectedIndex].DPDRotation = (float)CamFOVNumericUpDown.Value;
                OriginalFile = false;
            }
        }
        
        //---------------------------------------------------------------------------------------------

        private void CamIntnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                CameraList[CameraListBox.SelectedIndex].TransitionSpeed = (int)CamIntNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        private void CamEndIntNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                CameraList[CameraListBox.SelectedIndex].EndTransitionSpeed = (int)CamEndIntNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        private void GndIntNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].GroundMoveSpeed = (int)GndIntNumericUpDown.Value;
                OriginalFile = false;
            }
        }


        private void AllowDPadRotationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].UseDPAD = AllowDPadRotationCheckBox.Checked;
                OriginalFile = false;
            }
        }

        private void Num2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) {
                CameraList[CameraListBox.SelectedIndex].UnknownNum2 = Num2CheckBox.Checked;
                OriginalFile = false;
            }
        }


        private void MaxYNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].MaxY = (float)MaxYNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        private void MinYNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].MinY = (float)MinYNumericUpDown.Value;
                OriginalFile = false;
            }
        }


        private void GroundMoveDelayNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].GroundStartMoveDelay = (int)GroundMoveDelayNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        private void AirMoveDelayNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].AirStartMoveDelay = (int)AirMoveDelayNumericUpDown.Value;
                OriginalFile = false;
            }
        }


        private void FrontZoomNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].FrontZoom = (float)FrontZoomNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        private void HeightZoomNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].HeightZoom = (float)HeightZoomNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        private void UDownNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].UnknownUDown = (int)UDownNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        private void UpperNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading) {
                CameraList[CameraListBox.SelectedIndex].UpperBorder = (float)UpperNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        private void LowerNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].LowerBorder = (float)LowerNumericUpDown.Value;
                OriginalFile = false;
            }
        }
        
        //---------------------------------------------------------------------------------------------

        private void EventLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading) {
                CameraList[CameraListBox.SelectedIndex].EventFrames = (int)EventLengthNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        private void EventPriorityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading){
                CameraList[CameraListBox.SelectedIndex].EventPriority = (int)EventPriorityNumericUpDown.Value;
                OriginalFile = false;
            }
        }

        //---------------------------------------------------------------------------------------------

        private void CoordinateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            Loading = true;
            try
            {
                switch (CoordinateComboBox.SelectedIndex)
                {
                    case 0:
                        XNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].FixpointOffsetX;
                        break;
                    case 1:
                        XNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].WorldPointX;
                        break;
                    case 2:
                        XNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].PlayerOffsetX;
                        break;
                    case 3:
                        XNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].UnknownUpX;
                        break;
                    case 4:
                        XNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].VPanAxisX;
                        break;
                }
                switch (CoordinateComboBox.SelectedIndex)
                {
                    case 0:
                        YNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].FixpointOffsetY;
                        break;
                    case 1:
                        YNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].WorldPointY;
                        break;
                    case 2:
                        YNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].PlayerOffsetY;
                        break;
                    case 3:
                        YNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].UnknownUpY;
                        break;
                    case 4:
                        YNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].VPanAxisY;
                        break;
                }
                switch (CoordinateComboBox.SelectedIndex)
                {
                    case 0:
                        ZNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].FixpointOffsetZ;
                        break;
                    case 1:
                        ZNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].WorldPointZ;
                        break;
                    case 2:
                        ZNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].PlayerOffsetZ;
                        break;
                    case 3:
                        ZNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].UnknownUpZ;
                        break;
                    case 4:
                        ZNumericUpDown.Value = (decimal)CameraList[CameraListBox.SelectedIndex].VPanAxisZ;
                        break;
                }
            }
            catch (Exception)
            {
            }
            
            Loading = false;
        }

        private void XNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                switch (CoordinateComboBox.SelectedIndex)
                {
                    case 0:
                        CameraList[CameraListBox.SelectedIndex].FixpointOffsetX = (float)XNumericUpDown.Value;
                        break;
                    case 1:
                        CameraList[CameraListBox.SelectedIndex].WorldPointX = (float)XNumericUpDown.Value;
                        break;
                    case 2:
                        CameraList[CameraListBox.SelectedIndex].PlayerOffsetX = (float)XNumericUpDown.Value;
                        break;
                    case 3:
                        CameraList[CameraListBox.SelectedIndex].UnknownUpX = (float)XNumericUpDown.Value;
                        break;
                    case 4:
                        CameraList[CameraListBox.SelectedIndex].VPanAxisX = (float)XNumericUpDown.Value;
                        break;
                }
                OriginalFile = false;
            }
        }

        private void YNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                switch (CoordinateComboBox.SelectedIndex)
                {
                    case 0:
                        CameraList[CameraListBox.SelectedIndex].FixpointOffsetY = (float)YNumericUpDown.Value;
                        break;
                    case 1:
                        CameraList[CameraListBox.SelectedIndex].WorldPointY = (float)YNumericUpDown.Value;
                        break;
                    case 2:
                        CameraList[CameraListBox.SelectedIndex].PlayerOffsetY = (float)YNumericUpDown.Value;
                        break;
                    case 3:
                        CameraList[CameraListBox.SelectedIndex].UnknownUpY = (float)YNumericUpDown.Value;
                        break;
                    case 4:
                        CameraList[CameraListBox.SelectedIndex].VPanAxisY = (float)YNumericUpDown.Value;
                        break;
                }
                OriginalFile = false;
        }
        }

        private void ZNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                switch (CoordinateComboBox.SelectedIndex)
                {
                    case 0:
                        CameraList[CameraListBox.SelectedIndex].FixpointOffsetZ = (float)ZNumericUpDown.Value;
                        break;
                    case 1:
                        CameraList[CameraListBox.SelectedIndex].WorldPointZ = (float)ZNumericUpDown.Value;
                        break;
                    case 2:
                        CameraList[CameraListBox.SelectedIndex].PlayerOffsetZ = (float)ZNumericUpDown.Value;
                        break;
                    case 3:
                        CameraList[CameraListBox.SelectedIndex].UnknownUpZ = (float)ZNumericUpDown.Value;
                        break;
                    case 4:
                        CameraList[CameraListBox.SelectedIndex].VPanAxisZ = (float)ZNumericUpDown.Value;
                        break;
                }
                OriginalFile = false;
            }
        }

        //---------------------------------------------------------------------------------------------

        private void DisableResetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) {CameraList[CameraListBox.SelectedIndex].DisableReset = DisableResetCheckBox.Checked;
                OriginalFile = false;
            }
        }

        private void SharpZoomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) { CameraList[CameraListBox.SelectedIndex].SharpZoom = SharpZoomCheckBox.Checked;
                OriginalFile = false;
            }
        }

        private void EnableBlurCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) { CameraList[CameraListBox.SelectedIndex].DisableAntiBlur = EnableBlurCheckbox.Checked;
                OriginalFile = false;
            }
        }

        private void NoCollisionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) { CameraList[CameraListBox.SelectedIndex].DisableCollision = NoCollisionCheckBox.Checked;
                OriginalFile = false;
            }
        }

        private void DisableFirstPersonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) { CameraList[CameraListBox.SelectedIndex].DisableFirstPerson = DisableFirstPersonCheckBox.Checked;
                OriginalFile = false;
            }
        }

        private void VPanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) { CameraList[CameraListBox.SelectedIndex].VPanUse = VPanCheckBox.Checked;
                OriginalFile = false;
            }
        }

        private void EventEndTransCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) { CameraList[CameraListBox.SelectedIndex].EventUseEndTransition = EventEndTransCheckBox.Checked;
                OriginalFile = false;
            }
        }

        private void EventTransCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) { CameraList[CameraListBox.SelectedIndex].EventUseTransition = EventTransCheckBox.Checked;
                OriginalFile = false;
            }
        }

        private void GEndErpFrameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) { CameraList[CameraListBox.SelectedIndex].GFlagEndErpFrame = GEndErpFrameCheckBox.Checked;
                OriginalFile = false;
            }
        }

        private void GThruCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) { CameraList[CameraListBox.SelectedIndex].GFlagThrough = GThruCheckBox.Checked;
                OriginalFile = false;
            }
        }

        private void GEndTransCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading) { CameraList[CameraListBox.SelectedIndex].GFlagEndTransitionSpeed = GEndTransCheckBox.Checked;
                OriginalFile = false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void RailCamIDNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!Loading) {CameraList[CameraListBox.SelectedIndex].RailID = (int)RailCamIDNumericUpDown.Value;
                OriginalFile = false;
            }
        }
        #endregion

        //---------------------------------------------------------------------------------------------

        #region Keyboard Shortcuts
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (FileToolStripMenuItem.Enabled)
            {
                if (e.Control && e.KeyCode == Keys.N && NewToolStripMenuItem.Enabled)
                    NewToolStripMenuItem_Click(NewToolStripMenuItem, EventArgs.Empty);
                if (e.Control && e.KeyCode == Keys.O && OpenToolStripMenuItem.Enabled)
                    OpenToolStripMenuItem_Click(OpenToolStripMenuItem, EventArgs.Empty);
                if (e.Control && e.KeyCode == Keys.S && SaveToolStripMenuItem.Enabled)
                    SaveToolStripMenuItem_Click(SaveToolStripMenuItem, EventArgs.Empty);
                if (e.Control && e.Shift && e.KeyCode == Keys.S && SaveAsToolStripMenuItem.Enabled)
                    SaveAsToolStripMenuItem_Click(SaveAsToolStripMenuItem, EventArgs.Empty);
            }
            if (EditToolStripMenuItem.Enabled)
            {
                if (e.Control && e.Shift && e.KeyCode == Keys.A)
                    AddNewToolStripMenuItem_Click(AddNewToolStripMenuItem, EventArgs.Empty);
                if (e.Control && e.Shift && e.KeyCode == Keys.C && CopyToolStripMenuItem.Enabled)
                    CopyToolStripMenuItem_Click(CopyToolStripMenuItem, EventArgs.Empty);
                if ((e.Control && e.Shift && e.KeyCode == Keys.V)&&PasteToolStripMenuItem.Enabled)
                    PasteToolStripMenuItem_Click(PasteToolStripMenuItem, EventArgs.Empty);
                if ((e.Control && e.KeyCode == Keys.Delete && DeleteToolStripMenuItem.Enabled) && CameraList.Count != 0)
                    DeleteToolStripMenuItem_Click(DeleteToolStripMenuItem, EventArgs.Empty);
            }
            if (ToolsToolStripMenuItem.Enabled)
            {
                if (e.Control && e.Shift && e.KeyCode == Keys.I)
                    IDAssistantToolStripMenuItem_Click(IDAssistantToolStripMenuItem, EventArgs.Empty);
            }
        }
        #endregion

        #region Presets

        #region General
        private void StandardCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraList.Add(new Camera(CameraList.Count) { Version = 196631, Identification = Camera.IDOptions.c.ToString() + ":" + CameraList.Count.ToString().PadLeft(4, '0'), Type = Camera.CameraType.CAM_TYPE_XZ_PARA.ToString(), RotationX = 0f, RotationY = 0f, RotationZ = 0f, Zoom = 1000, DPDRotation = 45f, TransitionSpeed = 120, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = true, UnknownNum2 = false, MaxY = 300f, MinY = 800f, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0f, HeightZoom = 0f, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 0, EventPriority = 0, FixpointOffsetX = 0f, FixpointOffsetY = 300f, FixpointOffsetZ = 0f, WorldPointX = 0f, WorldPointY = 0f, WorldPointZ = 0f, PlayerOffsetX = 0f, PlayerOffsetY = 0f, PlayerOffsetZ = 0f, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0f, UnknownUpY = 0f, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = false, EventUseEndTransition = false, EventUseTransition = false });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
        }
        private void TopDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraList.Add(new Camera(CameraList.Count) { Version = 196631, Identification = Camera.IDOptions.c.ToString() + ":" + CameraList.Count.ToString().PadLeft(4, '0'), Type = Camera.CameraType.CAM_TYPE_XZ_PARA.ToString(), RotationX = ConvertToBCSVAngle(90f), RotationY = 0f, RotationZ = 0f, Zoom = 2500, DPDRotation = 45f, TransitionSpeed = 120, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = true, UnknownNum2 = false, MaxY = 300f, MinY = 800f, GroundStartMoveDelay = 60, AirStartMoveDelay = 60, UnknownUDown = 120, FrontZoom = 0f, HeightZoom = 0f, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 0, EventPriority = 0, FixpointOffsetX = 0f, FixpointOffsetY = 0f, FixpointOffsetZ = 0f, WorldPointX = 0f, WorldPointY = 0f, WorldPointZ = 0f, PlayerOffsetX = 0f, PlayerOffsetY = 0f, PlayerOffsetZ = 0f, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0f, UnknownUpY = 0f, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = false, EventUseEndTransition = false, EventUseTransition = false });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
        }
        private void BasicPlanetToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CameraList.Add(new Camera(CameraList.Count) { Version = 196631, Identification = Camera.IDOptions.c.ToString() + ":" + CameraList.Count.ToString().PadLeft(4, '0'), Num = 0, Type = Camera.CameraType.CAM_TYPE_CUBE_PLANET.ToString(), RotationX = 0.175f, RotationY = 0.261f, RotationZ = 0f, Zoom = 1100f, DPDRotation = 45, TransitionSpeed = 78, EndTransitionSpeed = 0, GroundMoveSpeed = 100, UseDPAD = true, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 0, AirStartMoveDelay = 78, UnknownUDown = 78, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 0, EventPriority = 0, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 10, PlayerOffsetY = 10, PlayerOffsetZ = 10, VPanAxisX = 10, VPanAxisY = 10, VPanAxisZ = 10, UnknownUpX = 10, UnknownUpY = 19, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = true, EventUseEndTransition = false, EventUseTransition = false });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
        }
        private void OpenWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraList.Add(new Camera(CameraList.Count) { Version = 196630, Identification = "c:0000", Num = 0, Type = "CAM_TYPE_FOLLOW", RotationX = 0.3f, RotationY = 0f, RotationZ = 0f, Zoom = 0.15f, DPDRotation = 45, TransitionSpeed = 120, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = true, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 100, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 0, EventPriority = 0, FixpointOffsetX = 0, FixpointOffsetY = 170, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 1000, PlayerOffsetY = 900, PlayerOffsetZ = 0, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = true, EventUseEndTransition = false, EventUseTransition = false });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
        }
        #endregion

        #region Spawn
        #endregion

        #region Events
        #region Scenario Starters
        private void ScenarioStarterSmoothMovingAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraList.Add(new Camera(CameraList.Count) { Version = 196631, Identification = "e:シナリオスターター:000:00番目", Num = 0, Type = "CAM_TYPE_CHARMED_FIX", RotationX = 0, RotationY = 0, RotationZ = 0, Zoom = 0, DPDRotation = 45, TransitionSpeed = 0, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = false, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 250, EventPriority = 1, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 800, PlayerOffsetX = -40, PlayerOffsetY = -30, PlayerOffsetZ = 650, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = true, EventUseEndTransition = true, EventUseTransition = true});
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            DoNameCheck(CameraList.Count - 1);
            CameraList.Add(new Camera(CameraList.Count) { Version = 196631, Identification = "e:シナリオスターター:000:01番目", Num = 0, Type = "CAM_TYPE_EYEPOS_FIX_THERE", RotationX = 0, RotationY = 0, RotationZ = 0, Zoom = 0, DPDRotation = 45, TransitionSpeed = 120, EndTransitionSpeed = 120, GroundMoveSpeed = 160, UseDPAD = false, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 140, EventPriority = 1, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 0, PlayerOffsetY = 0, PlayerOffsetZ = 0, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = true, EventUseEndTransition = true, EventUseTransition = true });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            DoNameCheck(CameraList.Count - 1);
            CameraList.Add(new Camera(CameraList.Count) { Version = 196631, Identification = "e:シナリオスターター:000:02番目", Num = 0, Type = "CAM_TYPE_EYEPOS_FIX_THERE", RotationX = 0, RotationY = 0, RotationZ = 0, Zoom = 0, DPDRotation = 45, TransitionSpeed = 120, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = false, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 0, EventPriority = 1, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 0, PlayerOffsetY = 0, PlayerOffsetZ = 0, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = true, EventUseEndTransition = false, EventUseTransition = false });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            DoNameCheck(CameraList.Count - 1);
        }
        #endregion

        #region Launch Stars
        private void LaunchStarSmoothMovingAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraList.Add(new Camera(CameraList.Count) { Version = 1966311, Identification = "e:スーパースピンドライバー:000:00番目", Num = 0, Type = "CAM_TYPE_EYEPOS_FIX_THERE", RotationX = 0, RotationY = 0, RotationZ = 0, Zoom = 0, DPDRotation = 45, TransitionSpeed = 120, EndTransitionSpeed = 120, GroundMoveSpeed = 160, UseDPAD = false, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 60, EventPriority = 1, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 0, PlayerOffsetY = 0, PlayerOffsetZ = 0, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = true, EventUseEndTransition = true, EventUseTransition = true });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            DoNameCheck(CameraList.Count - 1);
            CameraList.Add(new Camera(CameraList.Count) { Version = 1966311, Identification = "e:スーパースピンドライバー:000:01番目", Num = 0, Type = "CAM_TYPE_OBJ_PARALLEL", RotationX = 3.141593f, RotationY = 1.570796f, RotationZ = 0, Zoom = 1200, DPDRotation = 45, TransitionSpeed = 120, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = false, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 210, EventPriority = 1, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 0, PlayerOffsetY = 0, PlayerOffsetZ = 0, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = true, EventUseEndTransition = true, EventUseTransition = true });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            DoNameCheck(CameraList.Count - 1);
            CameraList.Add(new Camera(CameraList.Count) { Version = 1966311, Identification = "e:スーパースピンドライバー:000:02番目", Num = 0, Type = "CAM_TYPE_EYEPOS_FIX_THERE", RotationX = 0, RotationY = 0, RotationZ = 0, Zoom = 0, DPDRotation = 45, TransitionSpeed = 120, EndTransitionSpeed = 120, GroundMoveSpeed = 160, UseDPAD = false, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 30, EventPriority = 1, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 0, PlayerOffsetY = 0, PlayerOffsetZ = 0, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = true, EventUseEndTransition = true, EventUseTransition = true });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            DoNameCheck(CameraList.Count - 1);
        }

        private void LaunchStarSmoothShakingAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraList.Add(new Camera(CameraList.Count) { Version = 196631, Identification = "e:スーパースピンドライバー:000:00番目", Num = 0, Type = "CAM_TYPE_XZ_PARA", RotationX = 0f, RotationY = 2.96706f, RotationZ = 0f, Zoom = 1560f, DPDRotation = 45, TransitionSpeed = 120, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = false, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 0, EventPriority = 1, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 0, PlayerOffsetY = 0, PlayerOffsetZ = 0, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = true, EventUseEndTransition = false, EventUseTransition = false });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            DoNameCheck(CameraList.Count - 1);
            CameraList.Add(new Camera(CameraList.Count) { Version = 196631, Identification = "e:スーパースピンドライバー:000:01番目", Num = 0, Type = "CAM_TYPE_XZ_PARA", RotationX = -0.2617994f, RotationY = 1f, RotationZ = 0f, Zoom = 1500f, DPDRotation = 45, TransitionSpeed = 120, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = false, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 310, EventPriority = 1, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = -0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 0, PlayerOffsetY = 1, PlayerOffsetZ = 0, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = false, EventUseEndTransition = false, EventUseTransition = false });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            DoNameCheck(CameraList.Count - 1);
            CameraList.Add(new Camera(CameraList.Count) { Version = 196631, Identification = "e:スーパースピンドライバー:000:02番目", Num = 0, Type = "CAM_TYPE_XZ_PARA", RotationX = 0f, RotationY = 0f, RotationZ = 0f, Zoom = 0f, DPDRotation = 45, TransitionSpeed = 120, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = false, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 80, EventPriority = 1, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 0, PlayerOffsetY = 0, PlayerOffsetZ = 0, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = false, EventUseEndTransition = false, EventUseTransition = false });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            DoNameCheck(CameraList.Count - 1);
        }
        #endregion

        private void SimpleDemoExecutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraList.Add(new Camera(CameraList.Count){ Version = 196631, Identification = "e:簡易デモ実行固有簡易デモ000", Num = 0, Type = "CAM_TYPE_XZ_PARA", RotationX = 0f, RotationY = 0f, RotationZ = 0f, Zoom = 2000f, DPDRotation = 45, TransitionSpeed = 120, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = false, UnknownNum2 = false, MaxY = 300, MinY = 800, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0, HeightZoom = 0, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 100, EventPriority = 0, FixpointOffsetX = 0, FixpointOffsetY = 0, FixpointOffsetZ = 0, WorldPointX = 0, WorldPointY = 0, WorldPointZ = 0, PlayerOffsetX = 0, PlayerOffsetY = 0, PlayerOffsetZ = 0, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0, UnknownUpY = 0, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = true, EventUseEndTransition = false, EventUseTransition = false });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            DoNameCheck(CameraList.Count - 1);
        }


        #endregion

        #region Other
        #endregion

        #endregion

        //---------------------------------------------------------------------------------------------

        #region ToolStrip Items
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!OriginalFile)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to make a new file?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (rar != null)
                    {
                        rar.Dispose();
                        rar = null;
                    }
                    CameraListBox.Refresh();
                    PasteToolStripMenuItem.BackColor = default(Color);
                    CopyCamera = null;
                    CopyTimer.Stop();
                    ColR = -1;
                    ColG = -1;
                    ColB = -1;
                    SetAppStatus(false, false);
                    CameraList.Clear();
                    CameraEventList.Clear();
                    CameraListBox.Items.Clear();
                    NewFileTimer.Start();
                    EditToolStripMenuItem.Enabled = true;
                    CopyToolStripMenuItem.Enabled = false;
                    PasteToolStripMenuItem.Enabled = false;
                    DeleteToolStripMenuItem.Enabled = false;
                    PresetsToolStripMenuItem.Enabled = false;

                    fInfo = null;
                    RIchPresence.Update("Super Mario Galaxy Camera Editor 1/2", "New File");
                }
                else if (dialogResult == DialogResult.No)
                {
                    //Is there even anything to do?
                }
            }
            else
            {
                if (rar != null)
                {
                    rar.Dispose();
                    rar = null;
                }
                CameraListBox.Refresh();
                PasteToolStripMenuItem.BackColor = default(Color);
                CopyCamera = null;
                CopyTimer.Stop();
                ColR = -1;
                ColG = -1;
                ColB = -1;
                SetAppStatus(false, false);
                CameraList.Clear();
                CameraEventList.Clear();
                CameraListBox.Items.Clear();
                NewFileTimer.Start();
                EditToolStripMenuItem.Enabled = true;
                CopyToolStripMenuItem.Enabled = false;
                PasteToolStripMenuItem.Enabled = false;
                DeleteToolStripMenuItem.Enabled = false;
                PresetsToolStripMenuItem.Enabled = false;

                fInfo = null;
                RIchPresence.Update("Super Mario Galaxy Camera Editor 1/2", "New File");
            }
        }
        
        private void NewFileTimer_Tick(object sender, EventArgs e)
        {
            if (ColR == -1 && ColG == -1 && ColB == -1)
            {
                ColR = 255; ColG = 106; ColB = 0;
            }
            EditToolStripMenuItem.BackColor = Color.FromArgb(ColR, ColG, ColB);
            AddNewToolStripMenuItem.BackColor = Color.FromArgb(ColR, ColG, ColB);
            ColG = ColSwitch ? ColG - 5 : ColG + 5;
            if (ColG > 198)
            {
                ColSwitch = true;
            }
            else if (ColG < 70)
            {
                ColSwitch = false;
            }
        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraList.Add(new Camera(CameraList.Count) { Version = 196631, Identification = Camera.IDOptions.c.ToString() + ":XXXX", Type = Camera.CameraType.CAM_TYPE_XZ_PARA.ToString(), RotationX = 0f, RotationY = 0f, RotationZ = 0f, Zoom = 1000, DPDRotation = 45f, TransitionSpeed = 120, EndTransitionSpeed = 0, GroundMoveSpeed = 160, UseDPAD = true, UnknownNum2 = false, MaxY = 300f, MinY = 800f, GroundStartMoveDelay = 120, AirStartMoveDelay = 120, UnknownUDown = 120, FrontZoom = 0f, HeightZoom = 0f, UpperBorder = 0.3f, LowerBorder = 0.1f, EventFrames = 0, EventPriority = 0, FixpointOffsetX = 0f, FixpointOffsetY = 300f, FixpointOffsetZ = 0f, WorldPointX = 0f, WorldPointY = 0f, WorldPointZ = 0f, PlayerOffsetX = 0f, PlayerOffsetY = 0f, PlayerOffsetZ = 0f, VPanAxisX = 0, VPanAxisY = 1, VPanAxisZ = 0, UnknownUpX = 0f, UnknownUpY = 0f, UnknownUpZ = 0, DisableReset = false, SharpZoom = false, DisableAntiBlur = false, DisableCollision = false, DisableFirstPerson = false, GFlagEndErpFrame = false, GFlagThrough = false, GFlagEndTransitionSpeed = false, VPanUse = false, EventUseEndTransition = false, EventUseTransition = false });
            CameraListBox.Items.Add(CameraList[CameraList.Count - 1].Identification);
            if (AddNewToolStripMenuItem.BackColor != default(Color))
            {
                NewFileTimer.Stop();
                EditToolStripMenuItem.BackColor = default(Color);
                AddNewToolStripMenuItem.BackColor = default(Color);
                ColR = -1;
                ColG = -1;
                ColB = -1;
                SetAppStatus(true);
                SaveToolStripMenuItem.Enabled = true;
                CopyToolStripMenuItem.Enabled = true;
                SaveAsToolStripMenuItem.Enabled = true;
                DeleteToolStripMenuItem.Enabled = true;
                PresetsToolStripMenuItem.Enabled = true;
                CameraListBox.SelectedIndex = 0;
                if (CopyCamera != null)
                    PasteToolStripMenuItem.Enabled = true;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!OriginalFile)
            {
                if (MessageBox.Show("Are you sure you want to open a different file?", "Confirmation", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            //ofd.Filter = "Camera Files (*.bcam)|*.bcam|Level Archive (*.rarc *.arc)|*.rarc; *.arc";
            //ofd.FilterIndex = 1;
            ofd.FileName = "";
            //bool israrc = false;
            string bcsvName = "";
            
            //BCAM only from here on out.... oh boy.
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                if ((rar != null && rar.OriginalPath == ofd.FileName) || (bcsv != null && bcsv.FileName == ofd.FileName))
                {
                    MessageBox.Show("The chosen file is already opened.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FileInfo inuse = new FileInfo(ofd.FileName);
                if (IsFileLocked(inuse))
                {
                    MessageBox.Show("The chosen file could not be accessed.","Access Denied",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                bool ARC = new FileInfo(ofd.FileName).Extension == ".arc";
                bool RARC = new FileInfo(ofd.FileName).Extension == ".rarc";
                bool BCAM = new FileInfo(ofd.FileName).Extension == ".bcam";


                if (rar != null) {
                    rar.Dispose();
                    rar = null;
                }
                FileInfo old = null;
                if (fInfo != null)
                {
                     old = fInfo;
                }
                fInfo = new FileInfo(ofd.FileName);
                //RARC Pitstop
                if (ARC ^ RARC)
                {
                    FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                    FileInfo fi = new FileInfo(ofd.FileName);
                    rar = new RARC(fs, fi,"stage",fi.Name.Replace(fi.Extension,""));
                    FileInfo ffff = rar.FindFile("cameraparam.bcam");
                    if (ffff == null) {
                        fs.Close();
                        fInfo = old;
                        return;
                    }

                    ofd.FileName = ffff.FullName;
                    fs.Close();
                }

                fInfo = new FileInfo(ofd.FileName);
                bcsvName = ofd.FileName;
                CameraList.Clear();
                CameraEventList.Clear();
                CameraListBox.Items.Clear();

                bcsv = new BCSV(bcsvName);

                if (bcsv.header.entryCount == 0)
                {
                    if (MessageBox.Show("This BCAM is empty! Would you like to Start a new file?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        CameraListBox.Refresh();
                        PasteToolStripMenuItem.BackColor = default(Color);
                        CopyCamera = null;
                        CopyTimer.Stop();
                        ColR = -1;
                        ColG = -1;
                        ColB = -1;
                        SetAppStatus(false, false);
                        CameraList.Clear();
                        CameraEventList.Clear();
                        CameraListBox.Items.Clear();
                        NewFileTimer.Start();
                        EditToolStripMenuItem.Enabled = true;
                        CopyToolStripMenuItem.Enabled = false;
                        PasteToolStripMenuItem.Enabled = false;
                        DeleteToolStripMenuItem.Enabled = false;
                        PresetsToolStripMenuItem.Enabled = false;

                        RIchPresence.Update("Super Mario Galaxy 1/2 Camera Editor", "New File");
                        return;
                    }
                    else
                    {
                        SetAppStatus(false, true);
                        return;
                    }

                }
                for (uint i = 0; i < bcsv.header.entryCount; i++)
                {
                    Camera addme = new Camera(CameraList.Count);
                    
                    for (int j = 0; j < bcsv.header.fieldCount; j++)
                    {
                        //Lets find out where Everything is kept
                        for(int y = 0; y < bcsv.header.fieldCount; y++)
                        {
                            if (bcsv.fieldList[y].nameHash.ToString("X2").PadLeft(8, '0') == Hashes[j])
                            {
                                switch (j)
                                {
                                    case 0:
                                        addme.Version = int.Parse(bcsv.entryList[i].data[y].ToString());
                                        break;
                                    case 1:
                                        addme.Identification = bcsv.entryList[i].data[y].ToString();
                                        break;
                                    case 2:
                                        addme.Num = int.Parse(bcsv.entryList[i].data[y].ToString());
                                        break;
                                    case 3:
                                        addme.Type = bcsv.entryList[i].data[y].ToString();
                                        break;
                                    case 4:
                                        addme.RotationX = addme.RefineAngle(Convert.ToSingle(bcsv.entryList[i].data[y]));
                                        break;
                                    case 5:
                                        addme.RotationY = addme.RefineAngle(Convert.ToSingle(bcsv.entryList[i].data[y]));
                                        break;
                                    case 6:
                                        addme.RotationZ = addme.RefineAngle(Convert.ToSingle(bcsv.entryList[i].data[y]));
                                        break;
                                    case 7:
                                        addme.Zoom = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 8:
                                        addme.DPDRotation = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 9:
                                        addme.TransitionSpeed = int.Parse(bcsv.entryList[i].data[y].ToString());
                                        break;
                                    case 10:
                                        addme.EndTransitionSpeed = int.Parse(bcsv.entryList[i].data[y].ToString());
                                        break;
                                    case 11:
                                        addme.GroundMoveSpeed = int.Parse(bcsv.entryList[i].data[y].ToString());
                                        break;
                                    case 12:
                                        if ((addme.Type == Camera.CameraType.CAM_TYPE_RAIL_WATCH.ToString())^(addme.Type == Camera.CameraType.CAM_TYPE_RAIL_FOLLOW.ToString()))
                                            addme.RailID = Convert.ToInt32(bcsv.entryList[i].data[y]);
                                        else
                                            addme.UseDPAD = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 13:
                                        addme.UnknownNum2 = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 14:
                                        addme.MaxY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 15:
                                        addme.MinY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 16:
                                        addme.GroundStartMoveDelay = int.Parse(bcsv.entryList[i].data[y].ToString());
                                        break;
                                    case 17:
                                        addme.AirStartMoveDelay = int.Parse(bcsv.entryList[i].data[y].ToString());
                                        break;
                                    case 18:
                                        addme.UnknownUDown = int.Parse(bcsv.entryList[i].data[y].ToString());
                                        break;
                                    case 19:
                                        addme.FrontZoom = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 20:
                                        addme.HeightZoom = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 21:
                                        addme.UpperBorder = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 22:
                                        addme.LowerBorder = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 23:
                                        addme.EventFrames = int.Parse(bcsv.entryList[i].data[y].ToString());
                                        break;
                                    case 24:
                                        addme.EventPriority = int.Parse(bcsv.entryList[i].data[y].ToString());
                                        break;
                                    case 25:
                                        addme.FixpointOffsetX = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 26:
                                        addme.FixpointOffsetY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 27:
                                        addme.FixpointOffsetZ = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 28:
                                        addme.WorldPointX = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 29:
                                        addme.WorldPointY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 30:
                                        addme.WorldPointZ = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 31:
                                        addme.PlayerOffsetX = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 32:
                                        addme.PlayerOffsetY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 33:
                                        addme.PlayerOffsetZ = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 34:
                                        addme.VPanAxisX = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 35:
                                        addme.VPanAxisY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 36:
                                        addme.VPanAxisZ = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 37:
                                        addme.UnknownUpX = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 38:
                                        addme.UnknownUpY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 39:
                                        addme.UnknownUpZ = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                        break;
                                    case 40:
                                        addme.DisableReset = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 41:
                                        addme.SetDPADUse();
                                        break;
                                    case 42:
                                        addme.SharpZoom = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 43:
                                        addme.DisableAntiBlur = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 44:
                                        addme.DisableCollision = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 45:
                                        addme.DisableFirstPerson = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 46:
                                        addme.GFlagEndErpFrame = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 47:
                                        addme.GFlagThrough = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 48:
                                        addme.GFlagEndTransitionSpeed = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 49:
                                        addme.VPanUse = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 50:
                                        addme.EventUseEndTransition = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    case 51:
                                        addme.EventUseTransition = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                        break;
                                    default:
                                        throw new ArgumentException("How the heck did this happen lol");
                                }
                            }
                        }

                    }
                    CameraList.Add(addme);
                    DoNameCheck(addme);
                }
                SetAppStatus(true);
                CameraListBox.SelectedIndex = 0;

                CameraListBox.Refresh();
                PasteToolStripMenuItem.BackColor = default(Color);
                //CopyCamera = null;
                CopyTimer.Stop();
                ColR = -1;
                ColG = -1;
                ColB = -1;

                SaveToolStripMenuItem.Enabled = true;
                SaveAsToolStripMenuItem.Enabled = true;
                RIchPresence.Update(MessageB: "Editing " + (rar != null ? rar.Selfinfo.Name : fInfo.Name));
                OriginalFile = true;
            }
        }

        private void OpenWith(string Filename)
        {
            FileInfo inuse = new FileInfo(Filename);
            if (IsFileLocked(inuse))
            {
                MessageBox.Show("The chosen file could not be accessed.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string bcsvName = "";

            bool ARC = new FileInfo(Filename).Extension == ".arc";
            bool RARC = new FileInfo(Filename).Extension == ".rarc";
            bool BCAM = new FileInfo(Filename).Extension == ".bcam";


            if (rar != null)
            {
                rar.Dispose();
                rar = null;
            }
            FileInfo old = null;
            if (fInfo != null)
            {
                old = fInfo;
            }
            fInfo = new FileInfo(Filename);
            //RARC Pitstop
            if (ARC ^ RARC)
            {
                FileStream fs = new FileStream(Filename, FileMode.Open);
                FileInfo fi = new FileInfo(Filename);
                rar = new RARC(fs, fi);
                FileInfo ffff = rar.FindFile("cameraparam.bcam");
                if (ffff == null)
                {
                    fs.Close();
                    fInfo = old;
                    return;
                }

                Filename = ffff.FullName;
                fs.Close();
            }

            fInfo = new FileInfo(Filename);
            bcsvName = Filename;
            CameraList.Clear();
            CameraEventList.Clear();
            CameraListBox.Items.Clear();

            bcsv = new BCSV(bcsvName);

            if (bcsv.header.entryCount == 0)
            {
                if (MessageBox.Show("This BCAM is empty! Would you like to Start a new file?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CameraListBox.Refresh();
                    PasteToolStripMenuItem.BackColor = default(Color);
                    CopyCamera = null;
                    CopyTimer.Stop();
                    ColR = -1;
                    ColG = -1;
                    ColB = -1;
                    SetAppStatus(false, false);
                    CameraList.Clear();
                    CameraEventList.Clear();
                    CameraListBox.Items.Clear();
                    NewFileTimer.Start();
                    EditToolStripMenuItem.Enabled = true;
                    CopyToolStripMenuItem.Enabled = false;
                    PasteToolStripMenuItem.Enabled = false;
                    DeleteToolStripMenuItem.Enabled = false;
                    PresetsToolStripMenuItem.Enabled = false;
                    
                    RIchPresence.Update("Super Mario Galaxy Camera Editor 1/2", "New File");
                    return;
                }
                else
                {
                    SetAppStatus(false, true);
                    return;
                }

            }
            for (uint i = 0; i < bcsv.header.entryCount; i++)
            {
                Camera addme = new Camera(CameraList.Count);

                for (int j = 0; j < bcsv.header.fieldCount; j++)
                {
                    //Lets find out where Everything is kept
                    for (int y = 0; y < bcsv.header.fieldCount; y++)
                    {
                        if (bcsv.fieldList[y].nameHash.ToString("X2").PadLeft(8, '0') == Hashes[j])
                        {
                            switch (j)
                            {
                                case 0:
                                    addme.Version = int.Parse(bcsv.entryList[i].data[y].ToString());
                                    break;
                                case 1:
                                    addme.Identification = bcsv.entryList[i].data[y].ToString();
                                    break;
                                case 2:
                                    addme.Num = int.Parse(bcsv.entryList[i].data[y].ToString());
                                    break;
                                case 3:
                                    addme.Type = bcsv.entryList[i].data[y].ToString();
                                    break;
                                case 4:
                                    addme.RotationX = addme.RefineAngle(Convert.ToSingle(bcsv.entryList[i].data[y]));
                                    break;
                                case 5:
                                    addme.RotationY = addme.RefineAngle(Convert.ToSingle(bcsv.entryList[i].data[y]));
                                    break;
                                case 6:
                                    addme.RotationZ = addme.RefineAngle(Convert.ToSingle(bcsv.entryList[i].data[y]));
                                    break;
                                case 7:
                                    addme.Zoom = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 8:
                                    addme.DPDRotation = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 9:
                                    addme.TransitionSpeed = int.Parse(bcsv.entryList[i].data[y].ToString());
                                    break;
                                case 10:
                                    addme.EndTransitionSpeed = int.Parse(bcsv.entryList[i].data[y].ToString());
                                    break;
                                case 11:
                                    addme.GroundMoveSpeed = int.Parse(bcsv.entryList[i].data[y].ToString());
                                    break;
                                case 12:
                                    if ((addme.Type == Camera.CameraType.CAM_TYPE_RAIL_WATCH.ToString()) ^ (addme.Type == Camera.CameraType.CAM_TYPE_RAIL_FOLLOW.ToString()))
                                        addme.RailID = Convert.ToInt32(bcsv.entryList[i].data[y]);
                                    else
                                        addme.UseDPAD = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 13:
                                    addme.UnknownNum2 = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 14:
                                    addme.MaxY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 15:
                                    addme.MinY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 16:
                                    addme.GroundStartMoveDelay = int.Parse(bcsv.entryList[i].data[y].ToString());
                                    break;
                                case 17:
                                    addme.AirStartMoveDelay = int.Parse(bcsv.entryList[i].data[y].ToString());
                                    break;
                                case 18:
                                    addme.UnknownUDown = int.Parse(bcsv.entryList[i].data[y].ToString());
                                    break;
                                case 19:
                                    addme.FrontZoom = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 20:
                                    addme.HeightZoom = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 21:
                                    addme.UpperBorder = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 22:
                                    addme.LowerBorder = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 23:
                                    addme.EventFrames = int.Parse(bcsv.entryList[i].data[y].ToString());
                                    break;
                                case 24:
                                    addme.EventPriority = int.Parse(bcsv.entryList[i].data[y].ToString());
                                    break;
                                case 25:
                                    addme.FixpointOffsetX = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 26:
                                    addme.FixpointOffsetY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 27:
                                    addme.FixpointOffsetZ = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 28:
                                    addme.WorldPointX = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 29:
                                    addme.WorldPointY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 30:
                                    addme.WorldPointZ = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 31:
                                    addme.PlayerOffsetX = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 32:
                                    addme.PlayerOffsetY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 33:
                                    addme.PlayerOffsetZ = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 34:
                                    addme.VPanAxisX = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 35:
                                    addme.VPanAxisY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 36:
                                    addme.VPanAxisZ = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 37:
                                    addme.UnknownUpX = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 38:
                                    addme.UnknownUpY = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 39:
                                    addme.UnknownUpZ = Convert.ToSingle(bcsv.entryList[i].data[y]);
                                    break;
                                case 40:
                                    addme.DisableReset = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 41:
                                    addme.SetDPADUse();
                                    break;
                                case 42:
                                    addme.SharpZoom = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 43:
                                    addme.DisableAntiBlur = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 44:
                                    addme.DisableCollision = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 45:
                                    addme.DisableFirstPerson = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 46:
                                    addme.GFlagEndErpFrame = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 47:
                                    addme.GFlagThrough = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 48:
                                    addme.GFlagEndTransitionSpeed = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 49:
                                    addme.VPanUse = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 50:
                                    addme.EventUseEndTransition = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                case 51:
                                    addme.EventUseTransition = Convert.ToSingle(bcsv.entryList[i].data[y]) == 1 ? true : false;
                                    break;
                                default:
                                    throw new ArgumentException("How the heck did this happen lol");
                            }
                        }
                    }

                }
                CameraList.Add(addme);
                DoNameCheck(addme);
            }
            SetAppStatus(true);
            CameraListBox.SelectedIndex = 0;

            CameraListBox.Refresh();
            PasteToolStripMenuItem.BackColor = default(Color);
            //CopyCamera = null;
            CopyTimer.Stop();
            ColR = -1;
            ColG = -1;
            ColB = -1;

            SaveToolStripMenuItem.Enabled = true;
            SaveAsToolStripMenuItem.Enabled = true;
            RIchPresence.Update(MessageB: "Editing Cameras");
            
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Ecode = false;
            string outfile = "";
            if (fInfo == null)
            {
                sfd.Filter = "Camera Files |*.bcam|Level Archive |*.rarc; *.arc";
                sfd.FilterIndex = 1;
                sfd.FileName = "";
                sfd.ShowDialog();

                if (sfd.FileName != "")
                {
                    outfile = sfd.FileName;
                    if (rar != null)
                    {
                        rar.Dispose();
                        rar = null;
                    }
                    rar = null;
                    fInfo = new FileInfo(sfd.FileName);
                }
                else
                    return;
            }
            else
                outfile = fInfo.FullName;
            
            SaveToBCSV(outfile);
            if (rar != null)
            {
                DialogResult d = MessageBox.Show("Would you like to Yaz0 Encode your Archive?", "Yaz0", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Ecode = d == DialogResult.Yes ? true : false; 
                rar.Save(Ecode,"stage");
            }
            OriginalFile = true;
            RIchPresence.Update(MessageB: "Editing " + fInfo.Name);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string outfile = "";
            sfd.Filter = "Camera Files (*.bcam)|*.bcam";
            sfd.FilterIndex = 1;
            sfd.FileName = "";
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                if (rar != null)
                {
                    rar.Dispose();
                    rar = null;
                }
                fInfo = new FileInfo(sfd.FileName);
                outfile = sfd.FileName;
                SaveToBCSV(outfile);
                OriginalFile = true;
                RIchPresence.Update(MessageB: "Editing "+fInfo.Name);
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyCamera = CameraList[CameraListBox.SelectedIndex];
            CopyID = CameraListBox.SelectedIndex;
            GraphicsEngine = CameraListBox.CreateGraphics();
            CopiedIndicator.X = 0;
            CopiedIndicator.Y = 13*CopyID;
            CopiedIndicator.Width = 207;
            CopiedIndicator.Height = 13;
            CopyTimer.Start();
            PasteToolStripMenuItem.Enabled = true;
        }

        private void CopyTimer_Tick(object sender, EventArgs e)
        {
            if (ColR == -1 && ColG == -1 && ColB == -1)
            {
                ColR = 255; ColG = 182; ColB = 55;
            }
            CopiedBrush.Color = Color.FromArgb(150, ColR, ColG, ColB);

            PasteToolStripMenuItem.BackColor = Color.FromArgb(ColR, ColG, ColB);
            ColB = ColSwitch ? ColB - 5 : ColB + 5;
            if (ColB > 145)
            {
                ColSwitch = true;
            }
            else if (ColB < 55)
            {
                ColSwitch = false;
            }
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CameraList[CameraListBox.SelectedIndex] = new Camera(CameraList.Count) { Version = CopyCamera.Version, Identification = CopyCamera.Identification, Type = CopyCamera.Type, RotationX = CopyCamera.RotationX, RotationY = CopyCamera.RotationY, RotationZ = CopyCamera.RotationZ, Zoom = CopyCamera.Zoom, DPDRotation = CopyCamera.DPDRotation, TransitionSpeed = CopyCamera.TransitionSpeed, EndTransitionSpeed = CopyCamera.EndTransitionSpeed, GroundMoveSpeed = CopyCamera.GroundMoveSpeed, UseDPAD = CopyCamera.UseDPAD, UnknownNum2 = CopyCamera.UnknownNum2, MaxY = CopyCamera.MaxY, MinY = CopyCamera.MinY, GroundStartMoveDelay = CopyCamera.GroundStartMoveDelay, AirStartMoveDelay = CopyCamera.AirStartMoveDelay, UnknownUDown = CopyCamera.UnknownUDown, FrontZoom = CopyCamera.FrontZoom, HeightZoom = CopyCamera.HeightZoom, UpperBorder = CopyCamera.UpperBorder, LowerBorder = CopyCamera.LowerBorder, EventFrames = CopyCamera.EventFrames, EventPriority = CopyCamera.EventPriority, FixpointOffsetX = CopyCamera.FixpointOffsetX, FixpointOffsetY = CopyCamera.FixpointOffsetY, FixpointOffsetZ = CopyCamera.FixpointOffsetZ, WorldPointX = CopyCamera.WorldPointX, WorldPointY = CopyCamera.WorldPointY, WorldPointZ = CopyCamera.WorldPointZ, PlayerOffsetX = CopyCamera.PlayerOffsetX, PlayerOffsetY = CopyCamera.PlayerOffsetY, PlayerOffsetZ = CopyCamera.PlayerOffsetZ, VPanAxisX = CopyCamera.VPanAxisX, VPanAxisY = CopyCamera.VPanAxisY, VPanAxisZ = CopyCamera.VPanAxisZ, UnknownUpX = CopyCamera.UnknownUpX, UnknownUpY = CopyCamera.UnknownUpY, UnknownUpZ = CopyCamera.UnknownUpZ, DisableReset = CopyCamera.DisableReset, SharpZoom = CopyCamera.SharpZoom, DisableAntiBlur = CopyCamera.DisableAntiBlur, DisableCollision = CopyCamera.DisableCollision, DisableFirstPerson = CopyCamera.DisableFirstPerson, GFlagEndErpFrame = CopyCamera.GFlagEndErpFrame, GFlagThrough = CopyCamera.GFlagThrough, GFlagEndTransitionSpeed = CopyCamera.GFlagEndTransitionSpeed, VPanUse = CopyCamera.VPanUse, EventUseEndTransition = CopyCamera.EventUseEndTransition, EventUseTransition = CopyCamera.EventUseTransition };
            CameraListBox.Items[CameraListBox.SelectedIndex] = CopyCamera.Identification;
            DoNameCheck();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int deleteme = CameraListBox.SelectedIndex;
            CameraList.RemoveAt(deleteme);
            CameraListBox.Items.RemoveAt(deleteme);
            if (CameraList.Count == 0)
            {
                SetAppStatus(false, false);
                CameraList.Clear();
                CameraListBox.Items.Clear();
                NewFileTimer.Start();
                EditToolStripMenuItem.Enabled = true;
                CopyToolStripMenuItem.Enabled = false;
                PasteToolStripMenuItem.Enabled = false;
                DeleteToolStripMenuItem.Enabled = false;
                PresetsToolStripMenuItem.Enabled = false;
            }
            else
            {
                if (deleteme == 0)
                    CameraListBox.SelectedIndex = 0;
                if (deleteme >= 1)
                    CameraListBox.SelectedIndex = deleteme - 1;
            }
        }

        private void ExportPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupList = CameraList;
            RIchPresence.Update(MessageB: "Exporting a Preset");
            new PresetForm(CameraList).ShowDialog();
            RIchPresence.Update(MessageB: "Editing " + rar.Selfinfo.Name);
            CameraList = BackupList;
        }

        private void LoadPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pofd.FilterIndex = 1;
            pofd.FileName = "";
            pofd.ShowDialog();

            LCPP ImportPreset = new LCPP();

            if (pofd.FileName != "")
            {
                if (new FileInfo(pofd.FileName).Extension == ".lcpc")
                    ImportPreset = new LCPC(new FileStream(pofd.FileName, FileMode.Open)).LCPP;
                else
                    ImportPreset = new LCPP(pofd.FileName);
                foreach (Entry E in ImportPreset.EntryList)
                {
                    CameraList.Add(E.RetrieveCameraSettings(CameraList.Count));
                    DoNameCheck(E.Properties);
                }
            }
        }

        private void IDAssistantToolStripMenuItem_Click(object sender, EventArgs e) => new IdentificationAssistance(this).Show();

        #region About ToolStrip Items

        private void GitHubIssuesPageToolStripMenuItem_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://github.com/SuperHackio/LaunchCamPlus/issues");

        private void GitHubReleasesPageToolStripMenuItem_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://github.com/SuperHackio/LaunchCamPlus/releases");

        private void GitHubWikipediaToolStripMenuItem_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://github.com/SuperHackio/LaunchCamPlus/wiki");

        #endregion

        private void AutoSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Camera> New = new List<Camera>();
            foreach (Camera Cam in CameraList)
                if (Cam.Identification.StartsWith("c:"))
                    New.Add(Cam);

            foreach (Camera Cam in CameraList)
                if (Cam.Identification.StartsWith("s:"))
                    New.Add(Cam);

            foreach (Camera Cam in CameraList)
                if (Cam.Identification.StartsWith("e:"))
                    New.Add(Cam);

            foreach (Camera Cam in CameraList)
                if (Cam.Identification.StartsWith("o:"))
                    New.Add(Cam);

            foreach (Camera Cam in CameraList)
                if (Cam.Identification.StartsWith("g:"))
                    New.Add(Cam);
            CameraList = New;
            CameraListBox.Items.Clear();

            foreach (Camera Cam in CameraList)
                DoNameCheck(Cam);
        }

        private void ErrorCheckSelectedCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CameraListBox.SelectedIndex < 0)
                return;

            Camera Scanning = CameraList[CameraListBox.SelectedIndex];
            List<string> Errors = new List<string>();
            List<string> Warnings = new List<string>();
            if (Scanning.Identification.StartsWith("c:"))
            {
                if (Scanning.Identification.Length != 6 & Scanning.Identification.Length != 0)
                    Errors.Add("The Identification is too short or too long.\r");
                if (!System.Text.RegularExpressions.Regex.IsMatch(Scanning.Identification.Replace("c:", ""), @"\A\b[0-9a-fA-F]+\b\Z"))
                    Errors.Add("The Identification contains invalid characters.");


                if (Scanning.EventFrames != 0)
                    Warnings.Add("Event Frames are not used in Camera Areas");
                if (Scanning.EventPriority != 0)
                    Warnings.Add("Event Priority is not used in a Camera Area");

                if (Scanning.Type == Camera.CameraType.CAM_TYPE_XZ_PARA.ToString())
                {
                    if (Scanning.WorldPointX != 0.0 || Scanning.WorldPointY != 0.0 || Scanning.WorldPointZ != 0.0)
                        Warnings.Add("World Point X, Y, Z, are not used in CAM_TYPE_XZ_PARA");
                    if (Scanning.FrontZoom != 0.0 || Scanning.HeightZoom != 0.0)
                        Warnings.Add("Front Zoom and Height Zoom are not used in CAM_TYPE_XZ_PARA");
                    if (Scanning.SharpZoom)
                        Warnings.Add("Sharp Zooming is not used in CAM_TYPE_XZ_PARA");
                    if (Scanning.VPanUse)
                        Warnings.Add("Panning Bounds are not used in CAM_TYPE_XZ_PARA");
                }
                if (Scanning.Type == Camera.CameraType.CAM_TYPE_FOLLOW.ToString())
                {
                    if (Scanning.WorldPointX != 0.0 || Scanning.WorldPointY != 0.0 || Scanning.WorldPointZ != 0.0)
                        Warnings.Add("World Point X, Y, Z, are not used in CAM_TYPE_FOLLOW");
                    if (Scanning.Zoom != 0.0)
                        Warnings.Add("Zoom is a speed modifier in CAM_TYPE_FOLLOW");
                }
            }
            else if (Scanning.Identification.StartsWith("e:"))
            {
                Warnings.Add("Event Camera's are not yet supported");
            }
            else
                if (Scanning.Identification.Length == 0)
                    Errors.Add("The Identification is blank.");

            if (Errors.Count == 0 && Warnings.Count == 0)
                MessageBox.Show("No errors were found in Camera "+ Scanning.Identification, "Good to go", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (string message in Errors)
                MessageBox.Show(message, "Error in: " + Scanning.Identification + " | List ID: " + CameraListBox.SelectedIndex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            foreach (string message in Warnings)
                MessageBox.Show(message, "Warning in: " + Scanning.Identification + " | List ID: " + CameraListBox.SelectedIndex, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ErrorCheckAllCamerasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int S = CameraListBox.SelectedIndex;
            for (int i = 0; i < CameraList.Count; i++)
            {
                CameraListBox.SelectedIndex = i;
                ErrorCheckSelectedCameraToolStripMenuItem_Click(ErrorCheckSelectedCameraToolStripMenuItem, EventArgs.Empty);
            }
            CameraListBox.SelectedIndex = S;
        }

        private void PluginItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem TMIS = (ToolStripMenuItem)sender;
            ILCPE ActivePlugin = (ILCPE)TMIS.Tag;

            List<object> Params = new List<object>();
            for (int i = 0; i < ActivePlugin.Permissions.Length; i++)
            {
                switch (ActivePlugin.Permissions[i])
                {
                    case Permission.None:
                        break;
                    case Permission.CameraList:
                        Params.Add(CameraList);
                        break;
                    case Permission.BCSV:
                        Params.Add(bcsv);
                        break;
                    case Permission.Archive:
                        Params.Add(rar);
                        break;
                    case Permission.FullAccess:
                        Params.Add(CameraList);
                        Params.Add(bcsv);
                        Params.Add(rar);
                        break;
                }
            }
            object[] INPUT = new object[Params.Count];
            Params.CopyTo(INPUT);
            ActivePlugin.Run(INPUT);
        }
        #endregion

        //---------------------------------------------------------------------------------------------

        /// <summary>
        /// Checks the selected Camera
        /// </summary>
        /// <param name="CamID">int</param>
        public void DoNameCheck(int CamID)
        {
            string[] str = CameraList[CamID].Identification.Split(':');
            string finalID = "";
            bool caught = false;
            for (int j = 0; j < JapCameraEvents.Length; j++)
            {
                foreach (string sa in str)
                {
                    if (sa == JapCameraEvents[j] || sa.Contains(JapCameraEvents[j]))
                    {
                        caught = true;
                        finalID = CameraList[CamID].Identification.Replace(sa, EngCameraEvents[j]);
                        char a = CameraList[CamID].Identification[CameraList[CamID].Identification.Length - 1];
                        if (a >= '0' && a <= '9')
                        {
                            finalID += CameraList[CamID].Identification[CameraList[CamID].Identification.Length - 3];
                            finalID += CameraList[CamID].Identification[CameraList[CamID].Identification.Length - 2];
                            finalID += CameraList[CamID].Identification[CameraList[CamID].Identification.Length - 1];
                        }
                        else
                        {
                            finalID = finalID.Replace("番目", "th");
                        }
                        break;
                    }
                }
                if (caught)
                    break;
            }
            if (!caught)
            {
                CameraListBox.Items[CamID] = CamIDTextBox.Text.Replace("c:", "Camera Area: ").Replace("e:", "Event: ").Replace("o:", "Other: ").Replace("s:", "Spawn Point: ").Replace("g:", "Ground: "); ;
            }
            else
            {
                CameraListBox.Items[CamID] = finalID.Replace("e:", "Event: ").Replace("o:", "Other: ");
            }
        }
        /// <summary>
        /// Checks the Input Camera
        /// </summary>
        /// <param name="addme">Camera</param>
        public void DoNameCheck(Camera addme)
        {
            bool caught = false;
            for (int j = 0; j < JapCameraEvents.Length; j++)
            {
                string[] str = addme.Identification.Split(':');
                string finalID = "";
                foreach (string sa in str)
                {
                    if (sa == JapCameraEvents[j] || sa.Contains(JapCameraEvents[j]))
                    {
                        CameraEventList.Add(new CameraEvent(JapCameraEvents[j], EngCameraEvents[j], addme));
                        caught = true;
                        finalID = addme.Identification.Replace("e:", "Event: ").Replace("o:", "Other: ");
                        finalID = finalID.Replace(sa, EngCameraEvents[j]);
                        char a = addme.Identification[addme.Identification.Length-1];
                        if (a >= '0' && a <= '9')
                        {
                            finalID += addme.Identification[addme.Identification.Length - 3];
                            finalID += addme.Identification[addme.Identification.Length - 2];
                            finalID += addme.Identification[addme.Identification.Length - 1];
                        }
                        else
                        {
                            finalID = finalID.Replace("番目", "th");
                        }
                        CameraListBox.Items.Add(finalID);
                        break;
                    }
                }
                if (caught)
                {
                    
                    break;
                }
            }
            if (!caught)
            {
                string x = addme.Identification;
                x = x.ToLower().Replace("c:", "Camera Area: ").Replace("s:", "Spawn Point: ").Replace("g:", "Ground: ");
                CameraListBox.Items.Add(x);
            }
        }
        /// <summary>
        /// Checks the Selected Camera
        /// </summary>
        public void DoNameCheck()
        {
            CameraList[CameraListBox.SelectedIndex].Identification = CamIDTextBox.Text;

            string[] str = CamIDTextBox.Text.Split(':');
            string finalID = "";
            bool caught = false;
            for (int j = 0; j < JapCameraEvents.Length; j++)
            {

                foreach (string sa in str)
                {
                    if (sa == JapCameraEvents[j] || sa.Contains(JapCameraEvents[j]))
                    {
                        caught = true;
                        finalID = CamIDTextBox.Text.Replace(sa,EngCameraEvents[j]);
                        char a = CamIDTextBox.Text[CamIDTextBox.Text.Length - 1];
                        char b = CamIDTextBox.Text[CamIDTextBox.Text.Length - 2];
                        char c = CamIDTextBox.Text[CamIDTextBox.Text.Length - 3];
                        if ((a >= '0' && a <= '9')&& (b >= '0' && b <= '9') && (c >= '0' && c <= '9'))
                        {
                            finalID += CamIDTextBox.Text[CamIDTextBox.Text.Length - 3];
                            finalID += CamIDTextBox.Text[CamIDTextBox.Text.Length - 2];
                            finalID += CamIDTextBox.Text[CamIDTextBox.Text.Length - 1];
                        }
                        else
                        {
                            finalID = finalID.Replace("番目", "th");
                        }
                        //CameraListBox.Items.Add(finalID);
                        break;
                    }
                }
                if (caught)
                {
                    break;
                }
            }
            if (!caught)
            {
                CameraListBox.Items[CameraListBox.SelectedIndex] = CamIDTextBox.Text.Replace("c:", "Camera Area: ").Replace("e:", "Event: ").Replace("o:", "Other: ").Replace("s:", "Spawn Point: ").Replace("g:", "Ground: "); ;
            }
            else
            {
                CameraListBox.Items[CameraListBox.SelectedIndex] = finalID.Replace("e:", "Event: ").Replace("o:", "Other: ");
            }
        }
        
        private void SetBCSVEntry(int i, int count, object input) => bcsv.entryList[i].data[count] = input;

        private void SaveToBCSV(string outfile)
        {
            uint lastoffset = 628;
            uint StringsOffset = 628 + (uint)(CameraList.Count * 208);
            List<string> CameraTypes = new List<string>() { "4C4350322E332E302E30" };
            List<string> CameraIdentifications = new List<string>();
            foreach (Camera Cam in CameraList) //place the Strings in their lists for later ;)
            {
                if (!CameraTypes.Any(C => C == Cam.Type))
                    CameraTypes.Add(Cam.Type);
                if (!CameraIdentifications.Any(I => I == Cam.Identification))
                    CameraIdentifications.Add(Cam.Identification);
            }
            byte[] FieldTypes = new byte[] { 0x00, 0x06, 0x00, 0x06, 0x02, 0x02, 0x02, 0x02, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x02, 0x00, 0x00, 0x00, 0x02, 0x02, 0x02, 0x02, 0x00, 0x00, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            BCSV Save = new BCSV();

            BCSVHeader Header = new BCSVHeader
            {
                fieldCount = 52,
                entryCount = (uint)CameraList.Count,
                dataOffset = 640,
                entryDataSize = 208
            };

            BCSVField[] FieldList = new BCSVField[Header.fieldCount];
            for (int i = 0; i < FieldList.Length; i++)
            {
                BCSVField AddField = new BCSVField
                {
                    dataOffset = (ushort)(4 * i),
                    dataType = FieldTypes[i],
                    nameHash = (uint)(Convert.ToInt32(Hashes[i], 16)),
                    mask = 4294967295,
                    shiftVal = 0
                };
                FieldList[i] = AddField;
            }

            BCSVEntry[] EntryList = new BCSVEntry[CameraList.Count];
            for (int i = 0; i < CameraList.Count; i++)
            {
                BCSVEntry AddEntry = new BCSVEntry
                {
                    changed = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                    data = CameraList[i].MakeBCSV(),
                    dataType = FieldTypes,
                    offset = new uint[] { lastoffset, lastoffset + 4, lastoffset + 8, lastoffset + 12, lastoffset + 16, lastoffset + 20, lastoffset + 24, lastoffset + 28, lastoffset + 32, lastoffset + 36, lastoffset + 40, lastoffset + 44, lastoffset + 48, lastoffset + 52, lastoffset + 56, lastoffset + 60, lastoffset + 64, lastoffset + 68, lastoffset + 72, lastoffset + 76, lastoffset + 80, lastoffset + 84, lastoffset + 88, lastoffset + 92, lastoffset + 96, lastoffset + 100, lastoffset + 104, lastoffset + 108, lastoffset + 112, lastoffset + 116, lastoffset + 120, lastoffset + 124, lastoffset + 128, lastoffset + 132, lastoffset + 136, lastoffset + 140, lastoffset + 144, lastoffset + 148, lastoffset + 152, lastoffset + 156, lastoffset + 160, lastoffset + 164, lastoffset + 168, lastoffset + 172, lastoffset + 176, lastoffset + 180, lastoffset + 184, lastoffset + 188, lastoffset + 192, lastoffset + 196, lastoffset + 200, lastoffset + 204 }
                };
                lastoffset = AddEntry.offset[AddEntry.offset.Length - 1];
                AddEntry.size = CameraList[i].GetSizes();
                AddEntry.stringOffs = CameraList[i].GetStringOffsets(CameraTypes, CameraIdentifications, i);
                EntryList[i] = AddEntry;
            }

            Save.header = Header;
            Save.fieldList = FieldList;
            Save.entryList = EntryList;
            Save.Write(CameraTypes, CameraIdentifications, outfile);
        }

        /// <summary>
        /// Check if a file cannot be opened.
        /// </summary>
        /// <param name="file">File to check for</param>
        /// <returns>If the file is locked, returns true.</returns>
        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RIchPresence.Quit();
            if (rar != null)
                rar.Dispose();
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (CameraListBox.SelectedIndex < 1)
                return;

            int i = CameraListBox.SelectedIndex;
            RearrangeCameras(CameraList[CameraListBox.SelectedIndex], CameraList[CameraListBox.SelectedIndex-1], true);
            CameraListBox.SelectedIndex = i - 1;
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (CameraListBox.SelectedIndex == CameraListBox.Items.Count -1)
                return;

            int i = CameraListBox.SelectedIndex;
            RearrangeCameras(CameraList[CameraListBox.SelectedIndex], CameraList[CameraListBox.SelectedIndex+1], false);
            CameraListBox.SelectedIndex = i + 1;
        }
        
        private void MainForm_Load(object sender, EventArgs e) => Activate();

        /// <summary>
        /// Check to make sure the plugin is supported by the current LCP version
        /// </summary>
        /// <param name="LCPVersion">Curent LCP version</param>
        bool CheckCompatibility(Version LCPVersion, Version Lowestversion)
        {
            int result = LCPVersion.CompareTo(Lowestversion);

            if (result >= 0)//Versions are the compatable
                return true;
            else//versions are not compatable
                return false;
        }
        bool CheckCompatibility(Version LCPVersion, string HighestVersion)
        {
            if (HighestVersion == null)
                return true;

            int result = LCPVersion.CompareTo(Version.Parse(HighestVersion));

            if (result >= 0)//Versions are not compatable
                return false;
            else//versions are compatable
                return true;
        }

        private void DiscordTimer_Tick(object sender, EventArgs e)
        {
            Idletimer++;
            if (ActiveForm == this)
                RIchPresence.Update(RIchPresence.DisplayA, RIchPresence.DisplayB, "active", "Active", false);

            if (Idletimer > 120)
            {
                RIchPresence.Update(RIchPresence.DisplayA, RIchPresence.DisplayB, "idle", "Idle",false);
                Idletimer = 0;
            }
        }
    }
}
