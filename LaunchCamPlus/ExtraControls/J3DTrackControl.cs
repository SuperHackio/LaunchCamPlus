using Hack.io.Utility;
using static System.Net.Mime.MediaTypeNames;

namespace LaunchCamPlus.ExtraControls;

public partial class J3DTrackControl : UserControl
{
    private int mZoomX = 10;
    public int ZoomX
    {
        get => mZoomX;
        set
        {
            if (value < 1)
                value = 1;
            mZoomX = value;
        }
    }
    private int mZoomY = 40;
    public int ZoomY
    {
        get => mZoomY;
        set
        {
            if (value < 1)
                value = 1;
            mZoomY = value;
        }
    }

    private int mMouseWheelMultiplier = 1;
    public int MouseWheelMultiplier
    {
        get => mMouseWheelMultiplier;
        set => mMouseWheelMultiplier = value == 0 ? 1 : value;
    }

    public SplineType Spline { get; set; } = SplineType.HERMITE;
    public bool SingleTangent { get; set; } = false;
    public bool DrawTangents { get; set; } = true;

    public List<DataPoint> Points;
    public List<int> HighlightPoints;
    public int MaxLength;

    public J3DTrackControl()
    {
        InitializeComponent();
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        Points = new();
        HighlightPoints = new();
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);

        //ZoomX += (e.Delta / SystemInformation.MouseWheelScrollDelta)*mMouseWheelMultiplier;
        //ZoomY += (e.Delta / SystemInformation.MouseWheelScrollDelta)*mMouseWheelMultiplier;

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        float HalfHeight = Height / 2;
        float XPadding = 0, YPadding = 0;

        float VirtualXScale = MaxLength / (Width-XPadding);
        (float MinValue, float MaxValue) = GetMinMax();
        float VirtualYScale = (MaxValue - MinValue) / Height;
        float TangentScale = VirtualXScale / VirtualYScale;

        // Call the OnPaint method of the base class.
        base.OnPaint(e);

        Color ThemeCol = Color.FromArgb(75, 255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B);
        using Pen p = new(ThemeCol, 1);
        Graphics g = e.Graphics;
        int CellCountColumn = (int)Math.Ceiling(Width / 24d);
        int CellCountRow = (int)(Height / 24);
        int ColumnSize = (Width / CellCountColumn);
        int RowSize = (Height / CellCountRow);

        //int PositionX = 0;
        //int PositionY = 0;

        g.DrawRectangle(p, 0,0,Width-1,Height-1);
        g.DrawRectangle(p, 0,0,Width-1,Height-1);

        for (int x = 1; x < CellCountColumn; ++x)
        {
            g.DrawLine(p, x * ColumnSize, 0, x * ColumnSize, CellCountColumn * ColumnSize);
        }

        for (int y = 1; y < CellCountRow; ++y)
        {
            g.DrawLine(p, 0, y * RowSize, CellCountColumn * RowSize, y * RowSize);
        }
        g.DrawLine(p, 0, HalfHeight, Width, HalfHeight);

        Color FakeRed = Color.FromArgb(200, 255 - BackColor.R / 8, 0, 0);
        Color FakePurple = Color.FromArgb(200, 255 - BackColor.R / 8, 0, 255 - BackColor.B / 8);
        Color FakeGreen = Color.FromArgb(200, 0, 255 - BackColor.G / 8, 0);
        Color FakeDarkGreen = Color.FromArgb(200, 0, 160, 0);
        Color FakeDarkBlue = Color.FromArgb(200, 0, 160, 220);
        using SolidBrush BrushRed = new(FakeRed);
        using SolidBrush BrushGreen = new(FakeGreen);
        using Pen PenRed = new(FakeRed, 2);
        using Pen PenPurple = new(FakePurple, 2);
        using Pen PenDarkGreen = new(FakeDarkGreen, 2);
        using Pen PenDarkBlue = new(FakeDarkBlue, 2);
        

        (float min, float max) = GetMinMax();
        float diff = max - min;

        if (Points.Count == 1 || diff == 0) //If Diff == 0, we flatlined
        {
            //Ignore everything else
            g.DrawLine(PenRed, -5, HalfHeight, Width + 5, HalfHeight);
            g.FillEllipse(HighlightPoints.Contains(0) ? BrushGreen : BrushRed, 0, HalfHeight - 5, 10, 10);
            return;
        }

        float XCalc = (Width-XPadding) / MaxLength;
        float YCalc = (Height-YPadding) / diff;
        float DiffYCalc = diff * YCalc;
        float PositionOffsetX = 0;
        float PositionOffsetY = (min * YCalc)-(YPadding/2);

        for (int i = 0; i < Points.Count; i++)
        {
            DataPoint DP = Points[i];
            (float CurrentX, float CurrentY) = GetPos(DP);
            g.FillEllipse(BrushRed, CurrentX - 5, CurrentY - 5, 10, 10);
        }
        for (int i = 0; i < Points.Count; i++)
        {
            Pen PDrawIn = PenRed, PDrawOut = PenRed;
            Brush BrushCircle = BrushRed;
            if (HighlightPoints.Contains(i))
            {
                PDrawIn = PenDarkBlue;
                PDrawOut = PenDarkGreen;
                BrushCircle = BrushGreen;
            }

            DataPoint DP = Points[i];
            (float CurrentX, float CurrentY) = GetPos(DP);

            if (i < Points.Count - 1)
            {
                //TODO: Support for Teleporting
                DataPoint DPNext = Points[i + 1];
                (float NextX, float NextY) = GetPos(DPNext);
                switch (Spline)
                {
                    case SplineType.HERMITE:
                        if (DPNext.Frame - DP.Frame == 1)
                        {
                            g.DrawLine(PenPurple, CurrentX, CurrentY, NextX, NextY);
                            break; 
                        }

                        float length = (NextX - CurrentX);
                        for (int t = (int)CurrentX; t < (int)NextX; t++)
                        {
                            float calc = (t - CurrentX) / length;

                            //float Value = NewHermiteInterpolation(t, CurrentX, CurrentY, ((SingleTangent ? DP.InSlope : DP.OutSlope) * TangentScale) * -length, NextX, NextY, (DPNext.InSlope * TangentScale) * -length);
                            float Value = NewHermiteInterpolation(t, CurrentX, CurrentY, -((SingleTangent ? DP.InSlope : DP.OutSlope) * TangentScale), NextX, NextY, -(DPNext.InSlope * TangentScale));
                            //float Value = NewHermiteInterpolation(CurrentY, ((SingleTangent ? DP.InSlope : DP.OutSlope) * TangentScale) * -length, NextY, (DPNext.InSlope * TangentScale) * -length, calc);
                            
                            //this prevents errors from occuring due to...idk bad rounding?
                            if (Value < 100000 && Value > -100000)
                                g.FillEllipse(BrushRed, t-1.5f, Value-1.5f, 3,3);
                        }
                        break;
                    case SplineType.LINEAR:
                        g.DrawLine(PenRed, CurrentX, CurrentY, NextX, NextY);
                        break;
                    case SplineType.STEP:
                        g.DrawLine(PenRed, CurrentX, CurrentY, NextX, CurrentY);
                        g.DrawLine(PenRed, NextX, CurrentY, NextX, NextY);
                        break;
                    default:
                        throw new Exception();
                }
            }

            float TangentLineDist = 20;

            float TangentOutLineDistance = TangentLineDist; //Z
            float selection = (SingleTangent ? DP.InSlope : DP.OutSlope) * TangentScale / 30;
            double AngleCurrentOutgoing = Math.Atan(Math.Abs(selection)); //y Angle
            double AngleAtEndPointOutgoing = 180f.DegreeToRadian() - 90f.DegreeToRadian() - AngleCurrentOutgoing;
            double CurrentOutgoingX = (TangentOutLineDistance * Math.Sin(AngleAtEndPointOutgoing)) / Math.Sin(1.5708);
            double CurrentOutgoingY = Math.Sqrt((TangentOutLineDistance * TangentOutLineDistance) - (CurrentOutgoingX * CurrentOutgoingX));

            if (CurrentOutgoingY is float.NaN)
                CurrentOutgoingY = 0;

            if (DrawTangents)
                g.DrawLine(PDrawOut, CurrentX, CurrentY, CurrentX + (float)(CurrentOutgoingX), CurrentY + (float)(CurrentOutgoingY * -Math.Sign(selection))); //Subtraction because flipped Y axis

            float TangentInLineDistance = TangentLineDist; //Z
            double AngleCurrentIngoing = Math.Atan(Math.Abs(DP.InSlope * TangentScale / 30)); //y Angle
            double AngleAtEndPointIngoing = 180f.DegreeToRadian() - 90f.DegreeToRadian() - AngleCurrentIngoing;
            double CurrentIngoingX = (TangentInLineDistance * Math.Sin(AngleAtEndPointIngoing)) / Math.Sin(1.5708);
            double CurrentIngoingY = Math.Sqrt((TangentInLineDistance * TangentInLineDistance) - (CurrentIngoingX * CurrentIngoingX));

            if (CurrentIngoingY is float.NaN)
                CurrentIngoingY = 0;

            if (DrawTangents)
                g.DrawLine(PDrawIn, CurrentX, CurrentY, CurrentX - (float)(CurrentIngoingX), CurrentY - (float)(CurrentIngoingY * -Math.Sign(DP.InSlope))); //Addition because flipped Y axis


            if (HighlightPoints.Contains(i))
                g.FillEllipse(BrushCircle, CurrentX - 5, CurrentY - 5, 10, 10);
        }

        using Brush TextBrushX = new SolidBrush(Color.FromArgb(200, 255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B));
        using Brush TextBrushY = new SolidBrush(Color.FromArgb(200, 255 - BackColor.R, 255 - BackColor.G, 255 - BackColor.B));
        g.DrawString("0", Font, TextBrushX, 0, HalfHeight);
        g.DrawString((max+YPadding).ToString(), Font, TextBrushY, 0, 0);
        g.DrawString((min-YPadding).ToString(), Font, TextBrushY, 0, Height-Font.Height);
        string m = MaxLength.ToString();
        g.DrawString(m, Font, TextBrushX, Width - m.Length*7.25f, HalfHeight);

        (float x, float y) GetPos(DataPoint dddppp)
        {
            float Y = (dddppp.Value * YCalc) - PositionOffsetY;
            float Ydist = Y - HalfHeight;
            return ((dddppp.Frame * XCalc) - PositionOffsetX, HalfHeight - Ydist);
        }        
    }

    public static float NewHermiteInterpolation(float Time, float Key1Time, float Key1Value, float Key1Slope, float Key2Time, float Key2Value, float Key2Slope)
    {
        float f10 = Time - Key1Time;
        float f0 = 30.0f;
        float f9 = Key2Time - Key1Time;
        Key1Time = Key1Slope / f0;
        float f8 = f10 / f9;
        Key1Slope = f8 * f8;
        f0 = Key2Slope / f0;
        Time = f8 + f8;
        Key2Time = Key1Slope - f8;
        f9 = Key1Value - Key2Value;
        Key1Slope = (Time * Key2Time) - Key1Slope;
        Time = (Key1Time * Key2Time) + Key1Time;
        Key1Slope = (Key1Slope * f9) + Key1Value;
        Time = (f0 * Key2Time) + Time;
        Time = (f8 * Key1Time) - Time;
        Time = -((f10 * Time) - Key1Slope);
        return Time;
    }

    private (float min, float max) GetMinMax()
    {
        float min = float.PositiveInfinity;
        float max = float.NegativeInfinity;
        for (int i = 0; i < Points.Count; i++)
        {
            if (Points[i].Value > max)
                max = Points[i].Value;
            if (Points[i].Value < min)
                min = Points[i].Value;
        }
        return (min, max);
    }


    public class DataPoint
    {
        public float Frame;
        public float Value;
        public float InSlope;
        public float OutSlope;

        public override string ToString() => $"{Frame}: {Value} [{InSlope}/{OutSlope}]";
    }

    public enum SplineType
    {
        HERMITE,
        LINEAR,
        STEP
    }
}
