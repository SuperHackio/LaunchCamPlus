using Hack.io.Interface;
using Hack.io.Utility;
using System.Text;

namespace LaunchCamPlus;

/* == Format Specification ==
 * 
 * 0x00 = MAGIC (LCPS)
 * 0x04 = SETTINGSVERSION
 * 0x08 = Splash screen Size (2 ints)
 * 0x10 = Previous Splash (string*)
 * 0x14 = Creator Name (string?*)
 */

/// <summary>
/// LCP Settings file
/// </summary>
internal class Settings : ILoadSaveFile
{
    public const string MAGIC = "LCPS";
    public const string SETTINGSVERSION_LATEST = SETTINGSVERSION_0001;
    public const string SETTINGSVERSION_0001 = "0001";

    private FileStream DiskAccess;

    public Size SplashSize = new(846, 462); //Default
    public string LastSplash = "";

    public string? CreatorName = null;

    public bool IsFirstLaunch;
    public bool IsDarkMode;
    public bool IsUseHexId = true;
    public bool IsUseLongId = true;
    public bool IsUseYaz0 = true;
    public bool IsUseOnboardCompression = false;
    public bool IsIdentificationAssistOpen = false;
    public bool IsUseUniqueEditor = false;
    public bool IsShowAboutOnBoot = true;
    public bool IsCompressPresets = false;
    public bool IsUpdateDetected = false;
    public bool IsUseSMG1Defaults = false;

    private static string DEFAULT_USERNAME => new Random().NextInt64().ToString();

    public Settings(string Path)
    {
        if (!File.Exists(Path))
        {
            //First time usage woo
            IsFirstLaunch = true;
            CreatorName = DEFAULT_USERNAME;
            DiskAccess = new(Path, FileMode.OpenOrCreate);
            Save(DiskAccess);
            DiskAccess.Close();
            return;
        }

        DiskAccess = new(Path, FileMode.Open);
        Load(DiskAccess);
        DiskAccess.Close();
    }

    public void OnChanged(object? sender, EventArgs e)
    {
        DiskAccess = new(DiskAccess.Name, FileMode.Create);
        Save(DiskAccess);
        DiskAccess.Close();
    }

    public void Load(Stream Strm)
    {
        try
        {
            StreamUtil.SetEndianLittle();
            FileUtil.ExceptionOnBadMagic(Strm, MAGIC);
            string Version = Strm.ReadString(4, Encoding.ASCII);

            if (Version.Equals(SETTINGSVERSION_0001))
            {
                SplashSize = new(Strm.ReadInt32(), Strm.ReadInt32());
                LastSplash = Strm.ReadFromOffset(StreamUtil.ReadUInt32, 0, StreamUtil.ReadStringJIS);
                uint CreatorNamePtr = Strm.ReadUInt32();
                if (CreatorNamePtr == 0)
                    CreatorName = DEFAULT_USERNAME;

                IsFirstLaunch = Strm.ReadByte() != 0;
                IsDarkMode = Strm.ReadByte() != 0;
                IsUseHexId = Strm.ReadByte() != 0;
                IsUseLongId = Strm.ReadByte() != 0;
                IsUseYaz0 = Strm.ReadByte() != 0;
                IsUseOnboardCompression = Strm.ReadByte() != 0;
                IsIdentificationAssistOpen = Strm.ReadByte() != 0;
                IsUseUniqueEditor = Strm.ReadByte() != 0;
                IsShowAboutOnBoot = Strm.ReadByte() != 0;
                IsCompressPresets = Strm.ReadByte() != 0;
                IsUseSMG1Defaults = Strm.ReadByte() != 0;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to load settings: {e.Message}");
            DiskAccess.Close();

            IsFirstLaunch = true;
            CreatorName = DEFAULT_USERNAME;
            DiskAccess = new(DiskAccess.Name, FileMode.Create);
            Save(DiskAccess);
            DiskAccess.Close();
        }
    }

    public void Save(Stream Strm)
    {
        StreamUtil.SetEndianLittle();

        Strm.WriteString(MAGIC, Encoding.ASCII, null);
        Strm.WriteString(SETTINGSVERSION_LATEST, Encoding.ASCII, null);

        Strm.WriteInt32(SplashSize.Width);
        Strm.WriteInt32(SplashSize.Height);
        long PausePosition = Strm.Position;
        Strm.WritePlaceholderMulti(4, 2);
        Strm.WriteByte((byte)(IsFirstLaunch ? 1 : 0));
        Strm.WriteByte((byte)(IsDarkMode ? 1 : 0));
        Strm.WriteByte((byte)(IsUseHexId ? 1 : 0));
        Strm.WriteByte((byte)(IsUseLongId ? 1 : 0));
        Strm.WriteByte((byte)(IsUseYaz0 ? 1 : 0));
        Strm.WriteByte((byte)(IsUseOnboardCompression ? 1 : 0));
        Strm.WriteByte((byte)(IsIdentificationAssistOpen ? 1 : 0));
        Strm.WriteByte((byte)(IsUseUniqueEditor ? 1 : 0));
        Strm.WriteByte((byte)(IsShowAboutOnBoot ? 1 : 0));
        Strm.WriteByte((byte)(IsCompressPresets ? 1 : 0));
        Strm.WriteByte((byte)(IsUseSMG1Defaults ? 1 : 0));
        Strm.PadTo(16);
        uint LastSplashPos = (uint)Strm.Position;
        Strm.WriteStringJIS(LastSplash);
        uint CreatorNamePos = 0;
        if (CreatorName is not null)
        {
            CreatorNamePos = (uint)Strm.Position;
            Strm.WriteStringJIS(CreatorName);
        }
        Strm.Position = PausePosition;
        Strm.WriteUInt32(LastSplashPos);
        Strm.WriteUInt32(CreatorNamePos);
    }
}
