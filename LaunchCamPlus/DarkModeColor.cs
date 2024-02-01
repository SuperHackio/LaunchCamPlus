using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchCamPlus;

public static class ProgramColours
{
    public static Color ControlBackColor => Program.Settings.IsDarkMode ? Color.FromArgb(62, 62, 66) : Color.FromArgb(240, 240, 240);
    public static Color WindowColour => Program.Settings.IsDarkMode ? Color.FromArgb(37, 37, 38) : Color.FromArgb(255, 255, 255);
    public static Color TextColour => Program.Settings.IsDarkMode ? Color.FromArgb(241, 241, 241) : Color.FromArgb(0, 0, 0);
    public static Color BorderColour => Program.Settings.IsDarkMode ? Color.FromArgb(50, 50, 50) : Color.Gray;
}

public class MyRenderer : ToolStripProfessionalRenderer
{
    public MyRenderer() : base(new MyColors()) { }

    protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
    {
        if (e.Item is ToolStripMenuItem)
            e.ArrowColor = ProgramColours.TextColour;
        base.OnRenderArrow(e);
    }
}

internal class MyColors : ProfessionalColorTable
{
    public override Color ButtonSelectedHighlight => Color.Black;

    public override Color ButtonSelectedHighlightBorder => Color.Black;

    public override Color ButtonPressedHighlight => Color.Black;

    public override Color ButtonPressedHighlightBorder => Color.Black;

    public override Color ButtonCheckedHighlight => Color.Black;

    public override Color ButtonCheckedHighlightBorder => Color.Black;

    public override Color ButtonPressedBorder => Color.Black;

    public override Color ButtonSelectedBorder => Color.Black;

    public override Color ButtonCheckedGradientBegin => Color.Black;

    public override Color ButtonCheckedGradientMiddle => Color.Black;

    public override Color ButtonCheckedGradientEnd => Color.Black;

    public override Color ButtonSelectedGradientBegin => Color.Black;

    public override Color ButtonSelectedGradientMiddle => Color.Black;

    public override Color ButtonSelectedGradientEnd => Color.Black;

    public override Color ButtonPressedGradientBegin => Color.Black;

    public override Color ButtonPressedGradientMiddle => Color.Black;

    public override Color ButtonPressedGradientEnd => Color.Black;

    public override Color CheckBackground => Color.Black;

    public override Color CheckSelectedBackground => Color.Black;

    public override Color CheckPressedBackground => Color.Black;

    public override Color GripDark => Color.Black;

    public override Color GripLight => Color.Black;

    public override Color ImageMarginGradientBegin => Color.Black;

    public override Color ImageMarginGradientMiddle => Color.Black;

    public override Color ImageMarginGradientEnd => Color.Black;

    public override Color ImageMarginRevealedGradientBegin => Color.Black;

    public override Color ImageMarginRevealedGradientMiddle => Color.Black;

    public override Color ImageMarginRevealedGradientEnd => Color.Black;

    public override Color MenuStripGradientBegin => Color.Black;

    public override Color MenuStripGradientEnd => Color.Black;

    public override Color MenuItemSelected => Color.Black;

    public override Color MenuItemBorder => Color.Black;

    public override Color MenuBorder => Color.Black;

    public override Color MenuItemSelectedGradientBegin => Color.Black;

    public override Color MenuItemSelectedGradientEnd => Color.Black;

    public override Color MenuItemPressedGradientBegin => Color.Black;

    public override Color MenuItemPressedGradientMiddle => Color.White;

    public override Color MenuItemPressedGradientEnd => Color.Black;

    public override Color RaftingContainerGradientBegin => Color.Black;

    public override Color RaftingContainerGradientEnd => Color.Black;

    public override Color SeparatorDark => Color.Black;

    public override Color SeparatorLight => Color.Black;

    public override Color StatusStripGradientBegin => Color.Black;

    public override Color StatusStripGradientEnd => Color.Black;

    public override Color ToolStripBorder => Color.Black;

    public override Color ToolStripDropDownBackground => Color.Black;

    public override Color ToolStripGradientBegin => Color.Black;

    public override Color ToolStripGradientMiddle => Color.Black;

    public override Color ToolStripGradientEnd => Color.Black;

    public override Color ToolStripContentPanelGradientBegin => Color.Black;

    public override Color ToolStripContentPanelGradientEnd => Color.Black;

    public override Color ToolStripPanelGradientBegin => Color.Black;

    public override Color ToolStripPanelGradientEnd => Color.Black;

    public override Color OverflowButtonGradientBegin => Color.Black;

    public override Color OverflowButtonGradientMiddle => Color.Black;

    public override Color OverflowButtonGradientEnd => Color.Black;
}
