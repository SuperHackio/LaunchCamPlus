using System;
using System.Windows.Forms;
using Cameras;

namespace LaunchCamPlus
{
    public partial class IdentificationAssistance : Form
    {
        public IdentificationAssistance(MainForm F)
        {
            InitializeComponent();
            CenterToParent();

            Employer = F;
            startup = true;
            CategoryComboBox.SelectedIndex = 0;
            EventComboBox.DataSource = Employer.EngCameraEvents;
            startup = false;
            RecalcTimer.Start();
        }

        MainForm Employer;
        //ToolTip TT = new ToolTip() { ShowAlways = true };

        bool startup = false;

        bool[] EventNeedsColin = new bool[] {
            true, //- シナリオスターター    Scenario starter
            false, //- ピンクスーパースピンドライバー固有出現イベント用    Pink Launch Star Appearance
            true, //- ピンクスーパースピンドライバー    Pink Launch Star
            false, //- スーパースピンドライバー固有出現イベント用    Launch Star Appearance
            true, //- スーパースピンドライバー    Launch Star
            false, //- スピンドライバ固有    Sling Star Appearance
            true, //- スピンドライバ    Sling Star
            false, //- Power Star Appear point
            false, //- パワースター固有    Power Star Appearance
            false, //- 土管固有出現    Warp Pipe
            false, //- 簡易デモ実行固有簡易デモ    Simple Demo Executor
            false, //- 伸び植物固有出現デモ    Sproutle Vine Appearance
            false, //- 伸び植物固有掴まり    Sproutle Vine
            false, //- つるスライダー固有滑り    Sprauto Vine
            //false, //- ハラペココインチコ固有飛行    Hungry Luma (SMG2)
            false, //- デブチコ固有変身    Hungry Luma Transformation (SMG1)
            false, //- デブチコ固有飛行    Hungry Luma Flight (SMG1)
            //----------------------------------------------------------------------------------------
            false, //- 引き戻し    Pull Back
            false, //- 水上フォロー    Water Follow
            false, //- 水中フォロー    Underwater Follow
            false, //- 水中プラネット    Underwater Planet
            false, //- フーファイターカメラ    Foo Fighter
            //----------------------------------------------------------------------------------------
            false, //- デフォルト水面カメラ    Default Water Surface Camera
            false, //- デフォルト水中カメラ    Default Underwater Camera
            false, //- デフォルトフーファイターカメラ    Default Flying Mario Camera
            false, //- スタートカメラ    Start Camera
            false, //- デフォルトカメラ    Default Camera
        };

        private void GetID()
        {
            IDTextBox.Text = "";
            IDTextBox.Text += ((Camera.IDOptions)CategoryComboBox.SelectedIndex).ToString();
            IDTextBox.Text += ":";

            string tmp;
            switch (CategoryComboBox.SelectedIndex)
            {
                case 0:
                case 1:
                    tmp = Convert.ToInt32(CamIDNumericUpDown.Value).ToString("X");
                    IDTextBox.Text += tmp.PadLeft(4, '0');
                    break;
                case 2:
                    tmp = Convert.ToInt32(CamIDNumericUpDown.Value).ToString("X");
                    IDTextBox.Text += Employer.JapCameraEvents[EventComboBox.SelectedIndex];
                    if (EventNeedsColin[EventComboBox.SelectedIndex])
                    {
                        IDTextBox.Text += ":";
                    }
                    if (EventComboBox.SelectedItem.ToString() != "Foo Fighter" && EventComboBox.SelectedItem.ToString() != "Underwater Planet" &&
                        EventComboBox.SelectedItem.ToString() != "Underwater Follow" && EventComboBox.SelectedItem.ToString() != "Underwater Follow" &&
                        EventComboBox.SelectedItem.ToString() != "Water Follow" && EventComboBox.SelectedItem.ToString() != "Pull Back")
                    {
                        IDTextBox.Text += tmp.PadLeft(4, '0').Remove(0, 1);
                    }
                    if (AddSubCheckBox.Checked)
                    {
                        IDTextBox.Text += ":";
                        IDTextBox.Text += SubCamIDNumericUpDown.Value.ToString().PadLeft(2, '0');
                        IDTextBox.Text += "番目";
                    }
                    break;
                case 3:
                    IDTextBox.Text += Employer.JapCameraEvents[EventComboBox.SelectedIndex];
                    break;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Employer.CamIDTextBox.Text = IDTextBox.Text;
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
            switch (CategoryComboBox.SelectedIndex)
            {
                case 2:
                case 3:
                    EventComboBox.Enabled = true;
                    break;
                case 0:
                case 1:
                    EventComboBox.Enabled = false;
                    break;
            }
            switch (CategoryComboBox.SelectedIndex)
            {
                case 0:
                case 1:
                case 3:
                    SubCamIDNumericUpDown.Enabled = false;
                    break;
                case 2:
                    SubCamIDNumericUpDown.Enabled = true;
                    break;
            }
            startup = true;
                switch (CategoryComboBox.SelectedIndex)
                {
                    case 2:
                        EventComboBox.SelectedIndex = 0;
                        break;
                    case 3:
                        EventComboBox.SelectedIndex = EventComboBox.Items.Count-1;
                        break;
                }
            startup = false;
            }
        }

        private void RecalcTimer_Tick(object sender, EventArgs e)
        {
            GetID();
        }

        private void EventComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!startup)
            {
                switch (EventComboBox.SelectedItem.ToString())
                {
                    case "Default Water Surface Camera":
                    case "Default Underwater Camera":
                    case "Default Flying Mario":
                    case "Default Start":
                    case "Default Camera":
                        startup = true;
                        CategoryComboBox.SelectedIndex = 3;
                        startup = false;
                        break;
                    default:
                        startup = true;
                        CategoryComboBox.SelectedIndex = 2;
                        startup = false;
                        break;
                }
            }
        }
    }
}
