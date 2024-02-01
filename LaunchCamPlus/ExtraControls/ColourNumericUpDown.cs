﻿using System.ComponentModel;
using System.Diagnostics;

namespace LaunchCamPlus.ExtraControls;

public class ColourNumericUpDown : NumericUpDown
{
    private const int WM_PAINT = 0xF;
    private readonly int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;

    [DebuggerStepThrough]
    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == WM_PAINT)
        {
            using var g = Graphics.FromHwnd(Handle);
            // Uncomment this if you don't want the "highlight border".
            //using Pen pp = new(BorderColor, 1);
            //g.DrawRectangle(pp, 0, 0, Width - buttonWidth - 1, Height - 1);

            using Pen p = new(BorderColor, 1);
            g.DrawRectangle(p, 0, 0, Width - buttonWidth - 1, Height - 1);
        }
    }

    public ColourNumericUpDown()
    {
        BorderColor = Color.FromArgb(200, 200, 200);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        //Resize += (object sender, EventArgs e) => { Refresh(); };
    }

    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "Gray")]
    public Color BorderColor { get; set; }
    public delegate void Valuechanged2(EventArgs e);
    public Valuechanged2 ValueChange2 = (EventArgs e) => { };

    private decimal _textval;
    public decimal TextValue
    {
        get
        {
            return _textval;
        }
        set
        {
            _textval = Math.Min(Math.Max(Minimum, value), Maximum);
            Value = _textval;
        }
    }

    protected override void OnValueChanged(EventArgs e)
    {
        _textval = Value;
        ValueChange2(e);
    }

    protected override void OnTextChanged(EventArgs e)
    {
        if (decimal.TryParse(string.IsNullOrWhiteSpace(Text) ? "0.0" : Text, out decimal result))
        {
            _textval = result;
        }
    }
}
