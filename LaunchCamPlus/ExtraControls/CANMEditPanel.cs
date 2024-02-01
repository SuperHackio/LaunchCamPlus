using Hack.io.CANM;
using System.Diagnostics.CodeAnalysis;

namespace LaunchCamPlus.ExtraControls
{
    public partial class CANMEditPanel : UserControl, IReloadTheme
    {
        [AllowNull]
        CANM.Track _Item;
        bool IsFullFrames;

        private bool IsReload;

        public Action<int>? LengthChanger;
        public int SelectedIndex => DataListBox.SelectedIndex;

        public CANMEditPanel()
        {
            InitializeComponent();
            CANMLengthColourNumericUpDown.ValueChange2 += CANMLengthColourNumericUpDown_ValueChanged;

            KeyframeTimeColourNumericUpDown.ValueChange2 += KeyframeTimeColourNumericUpDown_ValueChanged;
            KeyframeTimeColourNumericUpDown.ValueChange2 += InvalidateTrackView;
            KeyframeValueColourNumericUpDown.ValueChange2 += KeyframeValueColourNumericUpDown_ValueChanged;
            KeyframeValueColourNumericUpDown.ValueChange2 += InvalidateTrackView;
            KeyframeInColourNumericUpDown.ValueChange2 += KeyframeInColourNumericUpDown_ValueChanged;
            KeyframeInColourNumericUpDown.ValueChange2 += InvalidateTrackView;
            KeyframeOutColourNumericUpDown.ValueChange2 += KeyframeOutColourNumericUpDown_ValueChanged;
            KeyframeOutColourNumericUpDown.ValueChange2 += InvalidateTrackView;
        }

        public void ReloadTheme() => ControlEx.ReloadTheme(this);

        public void LoadTrack(CANM.Track Track, bool IsCanm, int NewSelected = 0)
        {
            _Item = Track;
            IsFullFrames = IsCanm;

            CANMJ3dTrackControl.Points.Clear();
            CANMJ3dTrackControl.HighlightPoints.Clear();
            DataListBox.Items.Clear();
            CANMJ3dTrackControl.Spline = !IsFullFrames ? J3DTrackControl.SplineType.HERMITE : J3DTrackControl.SplineType.LINEAR;
            for (int i = 0; i < _Item.Count; i++)
            {
                J3DTrackControl.DataPoint DP = new()
                {
                    Frame = _Item[i].FrameId,
                    Value = _Item[i].Value,
                    InSlope = _Item[i].InSlope,
                    OutSlope = _Item[i].OutSlope
                };
                CANMJ3dTrackControl.Points.Add(DP);

                DataListBox.Items.Add(DP.ToString());
            }

            DataListBox.SelectedIndex = NewSelected;

            CANMJ3dTrackControl.SingleTangent = Track.UseSingleSlope;
            KeyframeInColourNumericUpDown.Enabled = !IsFullFrames;
            KeyframeOutColourNumericUpDown.Enabled = !CANMJ3dTrackControl.SingleTangent && !IsFullFrames;
            //KeyframeSetBothLinearButton.Enabled = !CANMJ3dTrackControl.SingleTangent;

        }

        internal void SetTime(int length)
        {
            CANMLengthColourNumericUpDown.Value = length;
        }

        public static float CalculateLinearSlope(CANM.Track.Frame FirstKey, CANM.Track.Frame SecondKey) => ((SecondKey.Value - FirstKey.Value) / (SecondKey.FrameId - FirstKey.FrameId)) * 30;

        private void DataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsReload)
                return;

            CANMJ3dTrackControl.HighlightPoints.Clear();
            if (DataListBox.Items.Count == 0 || DataListBox.SelectedIndex < 0)
            {
                KeyframeTimeColourNumericUpDown.Enabled =
                    KeyframeValueColourNumericUpDown.Enabled =
                    KeyframeInColourNumericUpDown.Enabled =
                    KeyframeOutColourNumericUpDown.Enabled = false;
                return;
            }

            KeyframeTimeColourNumericUpDown.Enabled =
                KeyframeValueColourNumericUpDown.Enabled =
                KeyframeInColourNumericUpDown.Enabled = true;
            KeyframeOutColourNumericUpDown.Enabled = !CANMJ3dTrackControl.SingleTangent;

            KeyframeTimeColourNumericUpDown.Value = (decimal)_Item[DataListBox.SelectedIndex].FrameId;
            KeyframeValueColourNumericUpDown.Value = (decimal)_Item[DataListBox.SelectedIndex].Value;
            KeyframeInColourNumericUpDown.Value = (decimal)_Item[DataListBox.SelectedIndex].InSlope;
            KeyframeOutColourNumericUpDown.Value = (decimal)_Item[DataListBox.SelectedIndex].OutSlope;

            CANMJ3dTrackControl.HighlightPoints.Add(DataListBox.SelectedIndex);
            CANMJ3dTrackControl.Invalidate();
        }

        private void CANMLengthColourNumericUpDown_ValueChanged(EventArgs e)
        {
            CANMJ3dTrackControl.MaxLength = (int)CANMLengthColourNumericUpDown.Value;
            LengthChanger?.Invoke(CANMJ3dTrackControl.MaxLength);
            CANMJ3dTrackControl.Invalidate();
        }

        private void InvalidateTrackView(EventArgs e)
        {
            IsReload = true;
            var Selected = _Item[DataListBox.SelectedIndex];
            CANMJ3dTrackControl.Points.Clear();
            CANMJ3dTrackControl.HighlightPoints.Clear();
            DataListBox.Items.Clear();
            CANMJ3dTrackControl.Spline = !IsFullFrames ? J3DTrackControl.SplineType.HERMITE : J3DTrackControl.SplineType.LINEAR;

            _Item.Sort((l, r) => l.FrameId.CompareTo(r.FrameId));

            for (int i = 0; i < _Item.Count; i++)
            {
                J3DTrackControl.DataPoint DP = new()
                {
                    Frame = _Item[i].FrameId,
                    Value = _Item[i].Value,
                    InSlope = _Item[i].InSlope,
                    OutSlope = _Item[i].OutSlope
                };
                CANMJ3dTrackControl.Points.Add(DP);

                DataListBox.Items.Add(DP.ToString());
            }
            DataListBox.SelectedIndex = _Item.IndexOf(Selected);
            IsReload = false;
            CANMJ3dTrackControl.HighlightPoints.Add(DataListBox.SelectedIndex);
            CANMJ3dTrackControl.Invalidate();
            KeyframeInColourNumericUpDown.Enabled = !IsFullFrames;
            KeyframeOutColourNumericUpDown.Enabled = !CANMJ3dTrackControl.SingleTangent && !IsFullFrames;
        }

        private void KeyframeTimeColourNumericUpDown_ValueChanged(EventArgs e)
        {
            if (DataListBox.Items.Count == 0 || DataListBox.SelectedIndex < 0)
                return;

            if (_Item.Any(o => KeyframeTimeColourNumericUpDown.Value == (decimal)o.FrameId))
            {
                int x = (int)_Item[DataListBox.SelectedIndex].FrameId - (int)KeyframeTimeColourNumericUpDown.Value;
                if (x == 0)
                    return;

                int TriedValue = TryGetNextOpen((int)KeyframeTimeColourNumericUpDown.Value, -x);
                if (TriedValue != -1)
                {
                    _Item[DataListBox.SelectedIndex].FrameId = TriedValue;
                    KeyframeTimeColourNumericUpDown.Value = TriedValue;
                    return;
                }
                KeyframeTimeColourNumericUpDown.Value = (decimal)_Item[DataListBox.SelectedIndex].FrameId; //Reset if cannot find valid in that direction
                return;
            }

            _Item[DataListBox.SelectedIndex].FrameId = (int)KeyframeTimeColourNumericUpDown.Value;

            int TryGetNextOpen(int start, int dir)
            {
                for (int i = start; i > 0 && i <= (int)CANMLengthColourNumericUpDown.Value; i += dir)
                {
                    if (_Item.Any(o => i == (decimal)o.FrameId))
                        continue;
                    return i;
                }
                return -1;
            }
        }

        private void KeyframeValueColourNumericUpDown_ValueChanged(EventArgs e)
        {
            if (DataListBox.Items.Count == 0 || DataListBox.SelectedIndex < 0)
                return;

            _Item[DataListBox.SelectedIndex].Value = (float)KeyframeValueColourNumericUpDown.Value;
        }

        private void KeyframeInColourNumericUpDown_ValueChanged(EventArgs e)
        {
            if (DataListBox.Items.Count == 0 || DataListBox.SelectedIndex < 0)
                return;

            _Item[DataListBox.SelectedIndex].InSlope = (float)KeyframeInColourNumericUpDown.Value;
        }

        private void KeyframeOutColourNumericUpDown_ValueChanged(EventArgs e)
        {
            if (DataListBox.Items.Count == 0 || DataListBox.SelectedIndex < 0)
                return;

            _Item[DataListBox.SelectedIndex].OutSlope = (float)KeyframeOutColourNumericUpDown.Value;
        }


        private void KeyframeSetBothLinearButton_Click(object sender, EventArgs e)
        {
            KeyframeSetInLinearButton_Click(sender, e);
            KeyframeSetOutLinearButton_Click(sender, e);
        }

        private void KeyframeSetBothZeroButton_Click(object sender, EventArgs e)
        {
            KeyframeInColourNumericUpDown.Value = 0;
            KeyframeOutColourNumericUpDown.Value = 0;
        }

        private void KeyframeSetInLinearButton_Click(object sender, EventArgs e)
        {
            if (CANMJ3dTrackControl.SingleTangent)
                return;
            if (DataListBox.Items.Count == 0 || DataListBox.SelectedIndex < 0)
                return;

            if (DataListBox.SelectedIndex == 0)
                return;

            CANM.Track.Frame Current = _Item[DataListBox.SelectedIndex];
            CANM.Track.Frame Previous = _Item[DataListBox.SelectedIndex - 1];
            float Value = CalculateLinearSlope(Previous, Current);
            Previous.OutSlope = Value;
            Current.InSlope = Value;
            KeyframeInColourNumericUpDown.Value = (decimal)Value;
            InvalidateTrackView(e);
        }

        private void KeyframeSetInZeroButton_Click(object sender, EventArgs e)
        {
            if (DataListBox.Items.Count == 0 || DataListBox.SelectedIndex < 0)
                return;
            KeyframeInColourNumericUpDown.Value = 0;
        }

        private void KeyframeSetOutLinearButton_Click(object sender, EventArgs e)
        {
            if (CANMJ3dTrackControl.SingleTangent)
                return;
            if (DataListBox.Items.Count == 0 || DataListBox.SelectedIndex == DataListBox.Items.Count - 1)
                return;

            CANM.Track.Frame Current = _Item[DataListBox.SelectedIndex];
            CANM.Track.Frame Next = _Item[DataListBox.SelectedIndex + 1];
            float Value = CalculateLinearSlope(Current, Next);
            Next.InSlope = Value;
            Current.OutSlope = Value;
            KeyframeOutColourNumericUpDown.Value = (decimal)Value;
            InvalidateTrackView(e);
        }

        private void KeyframeSetOutZeroButton_Click(object sender, EventArgs e)
        {
            if (CANMJ3dTrackControl.SingleTangent)
                return;
            if (DataListBox.Items.Count == 0 || DataListBox.SelectedIndex < 0)
                return;
            KeyframeOutColourNumericUpDown.Value = 0;
        }

        private void DataListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (DataListBox.SelectedIndex == -1)
                return;

            if (e.Control && e.KeyCode == Keys.C)
            {
                e.SuppressKeyPress = true;

                //Copy keyframe
                string Clip = _Item[DataListBox.SelectedIndex].ToClipboard();
                Clipboard.SetText(Clip);
                Console.WriteLine("CANM Frame copied!");
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                float OriginalKeyframeId = _Item[DataListBox.SelectedIndex].FrameId;
                string Clip = Clipboard.GetText();
                CANM.Track.Frame ClipboardFrame = new();
                if (ClipboardFrame.FromClipboard(Clip))
                {
                    //Validate the keyframe
                    if (_Item.ContainsFrame(ClipboardFrame.FrameId))
                    {
                        if (ClipboardFrame.FrameId != OriginalKeyframeId)
                        {
                            float NextFrameId = _Item.GetNextOpenFrame((int)CANMLengthColourNumericUpDown.Value);
                            if (NextFrameId == -1)
                            {
                                Console.WriteLine("No space for new keyframe, overwriting selected");
                                ClipboardFrame.FrameId = OriginalKeyframeId;
                            }
                            else if (NextFrameId != OriginalKeyframeId)
                            {
                                Console.WriteLine("Pasted Keyframe exists and is different than the original. A new position has been decided");
                                ClipboardFrame.FrameId = NextFrameId;
                            }
                            else
                            {
                                Console.WriteLine("Pasted Keyframe exists and is different than the original. The position decided is the same as the original.");
                                ClipboardFrame.FrameId = OriginalKeyframeId;
                            }
                        }
                        else
                        {
                            Console.WriteLine("CANM Frame pasted!");
                        }
                        ClipboardFrame.CopyTo(_Item[DataListBox.SelectedIndex]);
                    }
                    else
                    {
                        Console.WriteLine("CANM Frame pasted!");
                        ClipboardFrame.CopyTo(_Item[DataListBox.SelectedIndex]);
                    }
                    Program.IsUnsavedChanges = true;
                    DataListBox_SelectedIndexChanged(sender, e);
                }
                else
                    Console.WriteLine("CANM Frame paste FAILURE!");
            }
        }
    }
}
