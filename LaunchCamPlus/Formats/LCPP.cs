using System.ComponentModel;
using System.Text;
using Hack.io.BCSV;
using Hack.io.Utility;
using Hack.io.YAZ0;

namespace LaunchCamPlus.Formats;

/* Format documentation
* 0x00 - Header starting position
* =========== HEADER =========== 
* 0x00 - byte[4] {4C, 43, 50, 50} "LCPP"
* 0x04 - byte[2] File Version
* 0x06 - byte[x] Preset Name + 1 (null terminator)
* 0x?? - byte[y] Creator Name + 1 (null terminator)
* 0x?? - int Camera Count
* 0x?? - byte[?] padding
* ===========  DATA  ===========
* Null terminated strings. Basically the copy-paste for cameras
*/
public class LCPP
{
    private const string MAGIC = "LCPP";
    private const string MAGIC_COMPRESSED = "LCPC";
    private const string VERSION_NW = "NW";

    public readonly static Version LatestVersion = new(0, 3);
    private List<string> Entries { get; set; } = [];
    public string Name = "<Unnamed>";
    public string Creator = Program.Settings?.CreatorName ?? "<Unnamed>";
    public string this[int index]
    {
        get { return Entries[index]; }
        set { Entries[index] = value; }
    }
    public void Add(string entry) => Entries.Add(entry);
    public void Add(BCSV.Entry entry) => Entries.Add(entry.ToClipboard());
    public void AddRange(List<string> list) => Entries.AddRange(list);
    public void Remove(int index) => Entries.RemoveAt(index);
    public void Clear() => Entries.Clear();
    public int Count => Entries.Count;

    public LCPP() { }
    public LCPP(string Filename)
    {
        FileStream FS = new(Filename, FileMode.Open);
        string id = FS.ReadString(4, Encoding.ASCII);
        if (!id.Equals(MAGIC) && !id.Equals(MAGIC_COMPRESSED))
        {
            FS.Close();
            return;
        }
        if (id.Equals(MAGIC))
        {
            Version FileVersion = new(FS.ReadByte(), FS.ReadByte());
            if (LatestVersion.CompareTo(FileVersion) > 0)
                FileLoader = LoadLegacyFile;
            else
                FileLoader = LoadModernFile;
        }
        else
        {
            if (FS.IsMagicMatch(VERSION_NW))
                FileLoader = LoadCompressedModernFile;
            else
                FileLoader = LoadCompressedLegacyFile;
            FS.Position -= 2;
        }

        FileLoader(FS);
        FS.Close();
    }

    public void Save(string Filename, BackgroundWorker? BGW)
    {
        FileStream FS = new(Filename, FileMode.Create);
        FileSaver = new FileInfo(Filename).Extension.Equals(".lcpc") ? SaveCompressedModernFile : SaveModernFile;

        FileSaver(FS, BGW);
        FS.Close();
    }

    protected Action<Stream>? FileLoader { get; set; }
    protected Action<Stream, BackgroundWorker?>? FileSaver { get; set; }

    /// <summary>
    /// LCPP Versions 0.3+
    /// </summary>
    /// <param name="FS"></param>
    public void LoadModernFile(Stream FS)
    {
        StreamUtil.SetEndianLittle();
        Name = FS.ReadStringJIS();
        Creator = FS.ReadStringJIS();
        int count = FS.ReadInt32();
        while (FS.Position % 8 != 0)
            FS.Position++;
        for (int i = 0; i < count; i++)
            Entries.Add(FS.ReadStringJIS());
    }
    /// <summary>
    /// LCPP Versions 0.1 and 0.2
    /// </summary>
    /// <param name="FS"></param>
    public void LoadLegacyFile(Stream FS)
    {
        byte[] ToRead = new byte[10]; //Version of LaunchCamPlus
        FS.Read(ToRead, 0, 10);
        _ = StreamUtil.ShiftJIS.GetString(ToRead);
        ToRead = new byte[49]; //Preset Name
        FS.Read(ToRead, 0, 48);
        string presetname = StreamUtil.ShiftJIS.GetString(ToRead).Replace("\0", "");
        ToRead = new byte[49]; //Preset Creator
        FS.Read(ToRead, 0, 48);
        string creator = StreamUtil.ShiftJIS.GetString(ToRead).Replace("\0", "");
        ToRead = new byte[4]; //Number of Cameras
        FS.Read(ToRead, 0, 4);
        int cameranum = Convert.ToInt32(ToRead[0] + ToRead[1] + ToRead[2] + ToRead[3]);
        ToRead = new byte[12]; //Padding
        FS.Read(ToRead, 0, 12);
        //<------------------------------------------------------------------------------------------>
        for (int i = 0; i < cameranum; i++)
        {
            ToRead = new byte[4];
            FS.Read(ToRead, 0, 4);
            Array.Reverse(ToRead);
            int nextoffset = BitConverter.ToInt32(ToRead, 0);
            ToRead = new byte[nextoffset];
            FS.Read(ToRead, 0, nextoffset);
            string CurrentString = StreamUtil.ShiftJIS.GetString(ToRead);

            BCAM.Entry Properties = new();
            string[] Props = CurrentString.Split(',');

            string[] P;
            Vector3<float> FixPoint = new();
            Vector3<float> WorldPoint = new();
            Vector3<float> PlayerOffset = new();
            Vector3<float> VerticalPanAxis = new ();
            Vector3<float> UpAxis = new();
            for (int j = 0; j < Props.Length; j++)
            {
                P = Props[j].Split('=');
                switch (P[0])
                {
                    case "Version":
                    case "Num":
                        break;
                    case "Identification":
                        Properties.Identification = P[1].Replace("\"", "");
                        break;
                    case "Type":
                        Properties.Type = P[1].Replace("\"", "");
                        break;
                    case "RotationX":
                        P[1] = P[1].Replace("f", "");
                        Properties.AngleB = Convert.ToSingle(P[1]);
                        break;
                    case "RotationY":
                        P[1] = P[1].Replace("f", "");
                        Properties.AngleA = Convert.ToSingle(P[1]);
                        break;
                    case "RotationZ":
                        P[1] = P[1].Replace("f", "");
                        Properties.Roll = Convert.ToSingle(P[1]);
                        break;
                    case "Zoom":
                        P[1] = P[1].Replace("f", "");
                        Properties.Dist = Convert.ToSingle(P[1]);
                        break;
                    case "DPDRotation":
                        Properties.FieldOfViewY = Convert.ToSingle(P[1]);
                        break;
                    case "TransitionSpeed":
                        Properties.CamInt = Convert.ToInt32(P[1]);
                        break;
                    case "EndTransitionSpeed":
                        Properties.CamEndInt = Convert.ToInt32(P[1]);
                        break;
                    case "GroundMoveSpeed":
                        Properties.GndInt = Convert.ToInt32(P[1]);
                        break;
                    case "UseDPAD":
                        Properties.Num1 = Convert.ToInt32(P[1]);
                        break;
                    case "UnknownNum2":
                        Properties.Num2 = Convert.ToInt32(P[1]);
                        break;
                    case "MaxY":
                        Properties.UPlay = Convert.ToSingle(P[1]);
                        break;
                    case "MinY":
                        Properties.LPlay = Convert.ToSingle(P[1]);
                        break;
                    case "GroundStartMoveDelay":
                        Properties.PushDelay = Convert.ToInt32(P[1]);
                        break;
                    case "AirStartMoveDelay":
                        Properties.PushDelayLow = Convert.ToInt32(P[1]);
                        break;
                    case "UnknownUDown":
                        Properties.UDown = Convert.ToInt32(P[1]);
                        break;
                    case "FrontZoom":
                        Properties.LookOffset = Convert.ToSingle(P[1]);
                        break;
                    case "HeightZoom":
                        Properties.LookOffsetVertical = Convert.ToSingle(P[1]);
                        break;
                    case "UpperBorder":
                        P[1] = P[1].Replace("f", "");
                        Properties.UpperBorder = Convert.ToSingle(P[1]);
                        break;
                    case "LowerBorder":
                        P[1] = P[1].Replace("f", "");
                        Properties.LowerBorder = Convert.ToSingle(P[1]);
                        break;
                    case "EventFrames":
                        Properties.EventFrames = Convert.ToInt32(P[1]);
                        break;
                    case "EventPriority":
                        Properties.EventPriority = Convert.ToInt32(P[1]);
                        break;
                    case "FixpointOffsetX":
                        FixPoint.XValue = Convert.ToSingle(P[1]);
                        break;
                    case "FixpointOffsetY":
                        FixPoint.YValue = Convert.ToSingle(P[1]);
                        break;
                    case "FixpointOffsetZ":
                        FixPoint.ZValue = Convert.ToSingle(P[1]);
                        break;
                    case "WorldPointX":
                        WorldPoint.XValue = Convert.ToSingle(P[1]);
                        break;
                    case "WorldPointY":
                        WorldPoint.YValue = Convert.ToSingle(P[1]);
                        break;
                    case "WorldPointZ":
                        WorldPoint.ZValue = Convert.ToSingle(P[1]);
                        break;
                    case "PlayerOffsetX":
                        PlayerOffset.XValue = Convert.ToSingle(P[1]);
                        break;
                    case "PlayerOffsetY":
                        PlayerOffset.YValue = Convert.ToSingle(P[1]);
                        break;
                    case "PlayerOffsetZ":
                        PlayerOffset.ZValue = Convert.ToSingle(P[1]);
                        break;
                    case "VPanAxisX":
                        VerticalPanAxis.XValue = Convert.ToSingle(P[1]);
                        break;
                    case "VPanAxisY":
                        VerticalPanAxis.YValue = Convert.ToSingle(P[1]);
                        break;
                    case "VPanAxisZ":
                        VerticalPanAxis.ZValue = Convert.ToSingle(P[1]);
                        break;
                    case "UnknownUpX":
                        UpAxis.XValue = Convert.ToSingle(P[1]);
                        break;
                    case "UnknownUpY":
                        UpAxis.YValue = Convert.ToSingle(P[1]);
                        break;
                    case "UnknownUpZ":
                        UpAxis.ZValue = Convert.ToSingle(P[1]);
                        break;
                    case "DisableReset":
                        Properties.NoReset = P[1] == "true" ? 1 : 0;
                        break;
                    case "DisableDPAD":
                        Properties.NoFieldOfViewY = P[1] == "true" ? 1 : 0;
                        break;
                    case "SharpZoom":
                        Properties.LookOffsetErpOff = P[1] == "true" ? 1 : 0;
                        break;
                    case "DisableAntiBlur":
                        Properties.AntiBlurOff = P[1] == "true" ? 1 : 0;
                        break;
                    case "DisableCollision":
                        Properties.CollisionOff = P[1] == "true" ? 1 : 0;
                        break;
                    case "DisableFirstPerson":
                        Properties.SubjectiveOff = P[1] == "true" ? 1 : 0;
                        break;
                    case "GFlagEndErpFrame":
                        Properties.GFlagEndErpFrame = P[1] == "true" ? 1 : 0;
                        break;
                    case "GFlagThrough":
                        Properties.GFlagThrough = P[1] == "true" ? 1 : 0;
                        break;
                    case "GFlagEndTransitionSpeed":
                        Properties.GFlagEndTime = 0;
                        break;
                    case "VPanUse":
                        Properties.VPanAxisUse = P[1] == "true" ? 1 : 0;
                        break;
                    case "EventUseEndTransition":
                        Properties.EventUseTransitionEndTime = P[1] == "true" ? 1 : 0;
                        break;
                    case "EventUseTransition":
                        Properties.EventUseTransitionTime = P[1] == "true" ? 1 : 0;
                        break;
                    default:
                        MessageBox.Show("Sorry, but this Preset file is corrupted or outdated", "LCPP Error");
                        return;
                }
            }

            Properties.WOffset = FixPoint;
            Properties.WPoint = WorldPoint;
            Properties.Axis = PlayerOffset;
            Properties.VerticalPanAxis = VerticalPanAxis;
            Properties.Up = UpAxis;
            Entries.Add(Properties.ToClipboard());
        }

        Creator = creator;
        Name = presetname;
    }

    public void LoadCompressedModernFile(Stream FS)
    {
        FS.Position += 2;
        byte[] Bytes = new byte[(int)(FS.Length - FS.Position)];
        _ = FS.Read(Bytes);
        MemoryStream MS = new(YAZ0.Decompress(Bytes))
        {
            Position = 0x06
        };
        LoadModernFile(MS);
    }

    public void LoadCompressedLegacyFile(Stream FS)
    {
        byte[] Read;
        int stringlength = FS.ReadByte();
        Read = new byte[stringlength];
        FS.Read(Read, 0, stringlength);
        Name = StreamUtil.ShiftJIS.GetString(Read);

        stringlength = FS.ReadByte();
        Read = new byte[stringlength];
        FS.Read(Read, 0, stringlength);
        Creator = StreamUtil.ShiftJIS.GetString(Read);

        Read = new byte[4];
        FS.Read(Read, 0, 4);
        Array.Reverse(Read);
        int CameraCount = BitConverter.ToInt32(Read, 0);

        FS.Read(Read, 0, 4);
        Array.Reverse(Read);
        long Offset = BitConverter.ToInt32(Read, 0);

        for (int i = 0; i < CameraCount; i++)
        {
            BCAM.Entry Added = new()
            {
                Version = (int)FindNumber(FS, Offset),
                Identification = FindString(FS, Offset),
                Type = FindString(FS, Offset),
                AngleB = FindNumber(FS, Offset),
                AngleA = FindNumber(FS, Offset),
                Roll = FindNumber(FS, Offset),
                Dist = FindNumber(FS, Offset),
                FieldOfViewY = FindNumber(FS, Offset),
                CamInt = (int)FindNumber(FS, Offset),
                CamEndInt = (int)FindNumber(FS, Offset),
                GndInt = (int)FindNumber(FS, Offset),
                Num1 = (int)FindNumber(FS, Offset),
                Num2 = (int)FindNumber(FS, Offset),
                UPlay = FindNumber(FS, Offset),
                LPlay = FindNumber(FS, Offset),
                PushDelay = (int)FindNumber(FS, Offset),
                PushDelayLow = (int)FindNumber(FS, Offset),
                UDown = (int)FindNumber(FS, Offset),
                LookOffset = FindNumber(FS, Offset),
                LookOffsetVertical = FindNumber(FS, Offset),
                UpperBorder = FindNumber(FS, Offset),
                LowerBorder = FindNumber(FS, Offset),
                EventFrames = (int)FindNumber(FS, Offset),
                EventPriority = (int)FindNumber(FS, Offset),
                WOffset = new Vector3<float>(FindNumber(FS, Offset), FindNumber(FS, Offset), FindNumber(FS, Offset)),
                WPoint = new Vector3<float>(FindNumber(FS, Offset), FindNumber(FS, Offset), FindNumber(FS, Offset)),
                Axis = new Vector3<float>(FindNumber(FS, Offset), FindNumber(FS, Offset), FindNumber(FS, Offset)),
                VerticalPanAxis = new Vector3<float>(FindNumber(FS, Offset), FindNumber(FS, Offset), FindNumber(FS, Offset)),
                Up = new Vector3<float>(FindNumber(FS, Offset), FindNumber(FS, Offset), FindNumber(FS, Offset)),
                NoReset = FindBoolean(FS, Offset) ? 1 : 0,
                LookOffsetErpOff = FindBoolean(FS, Offset) ? 1 : 0,
                AntiBlurOff = FindBoolean(FS, Offset) ? 1 : 0,
                CollisionOff = FindBoolean(FS, Offset) ? 1 : 0,
                SubjectiveOff = FindBoolean(FS, Offset) ? 1 : 0,
                GFlagEndErpFrame = FindBoolean(FS, Offset) ? 1 : 0,
                GFlagThrough = FindBoolean(FS, Offset) ? 1 : 0,
                GFlagEndTime = FindBoolean(FS, Offset) ? 1 : 0,
                VPanAxisUse = FindBoolean(FS, Offset) ? 1 : 0,
                EventUseTransitionEndTime = FindBoolean(FS, Offset) ? 1 : 0,
                EventUseTransitionTime = FindBoolean(FS, Offset) ? 1 : 0,
            };
            Entries.Add(Added.ToClipboard());
        }
    }
    #region Legacy Compression Loading functions
    private static float FindNumber(Stream LCPCFile, long ValuesOffset)
    {
        byte[] Read = new byte[4];
        LCPCFile.Read(Read, 0, 4);
        Array.Reverse(Read);
        long Valueoffset = BitConverter.ToInt32(Read, 0);
        long currentpos = LCPCFile.Position;
        LCPCFile.Seek(ValuesOffset + Valueoffset, SeekOrigin.Begin);

        LCPCFile.Read(Read, 0, 4);
        Array.Reverse(Read);

        LCPCFile.Position = currentpos;

        return BitConverter.ToSingle(Read, 0);
    }
    private static string FindString(Stream LCPCFile, long ValuesOffset)
    {
        byte[] Read = new byte[4];
        LCPCFile.Read(Read, 0, 4);
        Array.Reverse(Read);
        long Valueoffset = BitConverter.ToInt32(Read, 0);
        long currentpos = LCPCFile.Position;
        LCPCFile.Seek(ValuesOffset + Valueoffset, SeekOrigin.Begin);
        string value = LCPCFile.ReadStringJIS();
        LCPCFile.Position = currentpos;
        return value;
    }
    private static bool FindBoolean(Stream LCPCFile, long ValuesOffset)
    {
        byte[] Read = new byte[4];
        LCPCFile.Read(Read, 0, 4);
        Array.Reverse(Read);
        long Valueoffset = BitConverter.ToInt32(Read, 0);
        long currentpos = LCPCFile.Position;
        LCPCFile.Seek(ValuesOffset + Valueoffset, SeekOrigin.Begin);

        bool ret = LCPCFile.ReadByte() == 0x01;

        LCPCFile.Position = currentpos;

        return ret;
    }
    #endregion

    public void SaveModernFile(Stream FS, BackgroundWorker? BGW)
    {
        StreamUtil.SetEndianLittle();
        FS.Write("LCPP"u8.ToArray(), 0, 4);
        FS.WriteByte((byte)LatestVersion.Major);
        FS.WriteByte((byte)LatestVersion.Minor);
        FS.WriteStringJIS(Name, 0x00);
        FS.WriteStringJIS(Creator, 0x00);
        FS.Write(BitConverter.GetBytes(Entries.Count), 0, 4);
        while (FS.Position % 8 != 0)
            FS.WriteByte(0x00);
        for (int i = 0; i < Entries.Count; i++)
            FS.WriteStringJIS(Entries[i], 0x00);
    }

    public MemoryStream SaveModernFile()
    {
        StreamUtil.SetEndianLittle();
        MemoryStream FS = new();
        FS.Write("LCPP"u8.ToArray(), 0, 4);
        FS.WriteByte((byte)LatestVersion.Major);
        FS.WriteByte((byte)LatestVersion.Minor);
        FS.WriteStringJIS(Name, 0x00);
        FS.WriteStringJIS(Creator, 0x00);
        FS.Write(BitConverter.GetBytes(Entries.Count), 0, 4);
        while (FS.Position % 8 != 0)
            FS.WriteByte(0x00);
        for (int i = 0; i < Entries.Count; i++)
            FS.WriteStringJIS(Entries[i], 0x00);

        return FS;
    }

    public void SaveCompressedModernFile(Stream FS, BackgroundWorker? BGW)
    {
        FS.Write("LCPCNW"u8.ToArray(), 0, 4);
        byte[] e = SaveModernFile().ToArray();
        byte[] Result = YAZ0.Compress(e, BGW);
        FS.Write(Result, 0, Result.Length);
    }
}
