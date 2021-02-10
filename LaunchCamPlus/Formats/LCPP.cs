using System;
using System.Collections.Generic;
using System.IO;
using Hack.io;
using Hack.io.BCAM;
using Hack.io.YAZ0;

namespace LaunchCamPlus
{
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
        public static Version LatestVersion = new Version(0,3);
        private List<string> Entries { get; set; } = new List<string>();
        public string Name;
        public string Creator;
        public string this[int index]
        {
            get { return Entries[index]; }
            set { Entries[index] = value; }
        }
        public void Add(string entry) => Entries.Add(entry);
        public void Add(BCAMEntry entry) => Entries.Add(entry.ToClipboard());
        public void AddRange(List<string> list) => Entries.AddRange(list);
        public void Remove(int index) => Entries.RemoveAt(index);
        public void Clear() => Entries.Clear();
        public int Count => Entries.Count;

        public LCPP() { }
        public LCPP(string Filename)
        {
            FileStream FS = new FileStream(Filename, FileMode.Open);
            string id = FS.ReadString(4);
            if (!id.Equals("LCPP") && !id.Equals("LCPC"))
            {
                FS.Close();
                return;
            }
            if (id.Equals("LCPP"))
            {
                Version FileVersion = new Version(FS.ReadByte(), FS.ReadByte());
                if (LatestVersion.CompareTo(FileVersion) > 0)
                    FileLoader = LoadLegacyFile;
                else
                    FileLoader = LoadModernFile;
            }
            else
            {
                if (FS.ReadString(2).Equals("NW"))
                    FileLoader = LoadCompressedModernFile;
                else
                    FileLoader = LoadCompressedLegacyFile;
                FS.Position -= 2;
            }

            FileLoader(FS);
            FS.Close();
        }

        public void Save(string Filename, bool Compress)
        {
            FileStream FS = new FileStream(Filename, FileMode.Create);
            FileSaver = new FileInfo(Filename).Extension.Equals(".lcpc") ? (DataManager)SaveCompressedModernFile : SaveModernFile;

            FileSaver(FS);
            FS.Close();
        }

        protected DataManager FileLoader { get; set; }
        protected DataManager FileSaver { get; set; }
        protected delegate void DataManager(Stream FS);

        /// <summary>
        /// LCPP Versions 0.3+
        /// </summary>
        /// <param name="FS"></param>
        public void LoadModernFile(Stream FS)
        {
            Name = FS.ReadString();
            Creator = FS.ReadString();
            int count = BitConverter.ToInt32(FS.Read(0, 4), 0);
            while (FS.Position % 8 != 0)
                FS.Position++;
            for (int i = 0; i < count; i++)
                Entries.Add(FS.ReadString());
        }
        /// <summary>
        /// LCPP Versions 0.1 and 0.2
        /// </summary>
        /// <param name="FS"></param>
        public void LoadLegacyFile(Stream FS)
        {
            byte[] ToRead = new byte[10]; //Version of LaunchCamPlus
            FS.Read(ToRead, 0, 10);
            string LCPVersion = Program.StringEncoder.GetString(ToRead);
            ToRead = new byte[49]; //Preset Name
            FS.Read(ToRead, 0, 48);
            string presetname = Program.StringEncoder.GetString(ToRead).Replace("\0", "");
            ToRead = new byte[49]; //Preset Creator
            FS.Read(ToRead, 0, 48);
            string creator = Program.StringEncoder.GetString(ToRead).Replace("\0", "");
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
                string CurrentString = Program.StringEncoder.GetString(ToRead);

                BCAMEntry Properties = new BCAMEntry();
                string[] Props = CurrentString.Split(',');

                string[] P;
                Vector3<float> FixPoint = new Vector3<float>();
                Vector3<float> WorldPoint = new Vector3<float>();
                Vector3<float> PlayerOffset = new Vector3<float>();
                Vector3<float> VerticalPanAxis = new Vector3<float>();
                Vector3<float> UpAxis = new Vector3<float>();
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
                            Properties.RotationX = Convert.ToSingle(P[1]);
                            break;
                        case "RotationY":
                            P[1] = P[1].Replace("f", "");
                            Properties.RotationY = Convert.ToSingle(P[1]);
                            break;
                        case "RotationZ":
                            P[1] = P[1].Replace("f", "");
                            Properties.RotationZ = Convert.ToSingle(P[1]);
                            break;
                        case "Zoom":
                            P[1] = P[1].Replace("f", "");
                            Properties.Zoom = Convert.ToSingle(P[1]);
                            break;
                        case "DPDRotation":
                            Properties.FieldOfView = Convert.ToSingle(P[1]);
                            break;
                        case "TransitionSpeed":
                            Properties.TransitionTime = Convert.ToInt32(P[1]);
                            break;
                        case "EndTransitionSpeed":
                            Properties.TransitionEndTime = Convert.ToInt32(P[1]);
                            break;
                        case "GroundMoveSpeed":
                            Properties.TransitionGroundTime = Convert.ToInt32(P[1]);
                            break;
                        case "UseDPAD":
                            Properties.Num1 = Convert.ToInt32(P[1]);
                            break;
                        case "UnknownNum2":
                            Properties.Num2 = Convert.ToInt32(P[1]);
                            break;
                        case "MaxY":
                            Properties.MaxY = Convert.ToSingle(P[1]);
                            break;
                        case "MinY":
                            Properties.MinY = Convert.ToSingle(P[1]);
                            break;
                        case "GroundStartMoveDelay":
                            Properties.GroundMoveDelay = Convert.ToInt32(P[1]);
                            break;
                        case "AirStartMoveDelay":
                            Properties.AirMoveDelay = Convert.ToInt32(P[1]);
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
                            Properties.DisableReset = P[1] == "true" ? true : false;
                            break;
                        case "DisableDPAD":
                            Properties.EnableFoV = P[1] == "true" ? true : false;
                            break;
                        case "SharpZoom":
                            Properties.StaticLookOffset = P[1] == "true" ? true : false;
                            break;
                        case "DisableAntiBlur":
                            Properties.DisableAntiBlur = P[1] == "true" ? true : false;
                            break;
                        case "DisableCollision":
                            Properties.DisableCollision = P[1] == "true" ? true : false;
                            break;
                        case "DisableFirstPerson":
                            Properties.DisableFirstPerson = P[1] == "true" ? true : false;
                            break;
                        case "GFlagEndErpFrame":
                            Properties.GFlagEndErpFrame = P[1] == "true" ? true : false;
                            break;
                        case "GFlagThrough":
                            Properties.GFlagThrough = P[1] == "true" ? true : false;
                            break;
                        case "GFlagEndTransitionSpeed":
                            Properties.GFlagEndTime = 0;
                            break;
                        case "VPanUse":
                            Properties.EnableVerticalPanAxis = P[1] == "true" ? true : false;
                            break;
                        case "EventUseEndTransition":
                            Properties.EventUseTransitionEndTime = P[1] == "true" ? true : false;
                            break;
                        case "EventUseTransition":
                            Properties.EventUseTransitionTime = P[1] == "true" ? true : false;
                            break;
                        default:
                            System.Windows.Forms.MessageBox.Show("Sorry, but this Preset file is corrupted or outdated", "LCPP Error");
                            return;
                    }
                }

                Properties.FixPointOffset = FixPoint;
                Properties.WorldPointOffset = WorldPoint;
                Properties.PlayerOffset = PlayerOffset;
                Properties.VerticalPanAxis = VerticalPanAxis;
                Properties.UpAxis = UpAxis;
                Entries.Add(Properties.ToClipboard());
            }
            
            Creator = creator;
            Name = presetname;
        }

        public void LoadCompressedModernFile(Stream FS)
        {
            FS.Position += 2;
            byte[] Bytes = FS.Read(0, (int)(FS.Length - FS.Position));
            MemoryStream MS = new MemoryStream(YAZ0.Decompress(Bytes))
            {
                Position = 0x06
            };
            LoadModernFile(MS);
        }

        public void LoadCompressedLegacyFile(Stream FS)
        {
            byte[] Read = new byte[4];
            int stringlength = FS.ReadByte();
            Read = new byte[stringlength];
            FS.Read(Read, 0, stringlength);
            Name = Program.StringEncoder.GetString(Read);

            stringlength = FS.ReadByte();
            Read = new byte[stringlength];
            FS.Read(Read, 0, stringlength);
            Creator = Program.StringEncoder.GetString(Read);

            Read = new byte[4];
            FS.Read(Read, 0, 4);
            Array.Reverse(Read);
            int CameraCount = BitConverter.ToInt32(Read, 0);

            FS.Read(Read, 0, 4);
            Array.Reverse(Read);
            long Offset = BitConverter.ToInt32(Read, 0);

            for (int i = 0; i < CameraCount; i++)
            {
                BCAMEntry Added = new BCAMEntry()
                {
                    Version = (int)FindNumber(FS, Offset),
                    Identification = FindString(FS, Offset),
                    Type = FindString(FS, Offset),
                    RotationX = FindNumber(FS, Offset),
                    RotationY = FindNumber(FS, Offset),
                    RotationZ = FindNumber(FS, Offset),
                    Zoom = FindNumber(FS, Offset),
                    FieldOfView = FindNumber(FS, Offset),
                    TransitionTime = (int)FindNumber(FS, Offset),
                    TransitionEndTime = (int)FindNumber(FS, Offset),
                    TransitionGroundTime = (int)FindNumber(FS, Offset),
                    Num1 = (int)FindNumber(FS, Offset),
                    Num2 = (int)FindNumber(FS, Offset),
                    MaxY = FindNumber(FS, Offset),
                    MinY = FindNumber(FS, Offset),
                    GroundMoveDelay = (int)FindNumber(FS, Offset),
                    AirMoveDelay = (int)FindNumber(FS, Offset),
                    UDown = (int)FindNumber(FS, Offset),
                    LookOffset = FindNumber(FS, Offset),
                    LookOffsetVertical = FindNumber(FS, Offset),
                    UpperBorder = FindNumber(FS, Offset),
                    LowerBorder = FindNumber(FS, Offset),
                    EventFrames = (int)FindNumber(FS, Offset),
                    EventPriority = (int)FindNumber(FS, Offset),
                    FixPointOffset = new Vector3<float>(FindNumber(FS, Offset), FindNumber(FS, Offset), FindNumber(FS, Offset)),
                    WorldPointOffset = new Vector3<float>(FindNumber(FS, Offset), FindNumber(FS, Offset), FindNumber(FS, Offset)),
                    PlayerOffset = new Vector3<float>(FindNumber(FS, Offset), FindNumber(FS, Offset), FindNumber(FS, Offset)),
                    VerticalPanAxis = new Vector3<float>(FindNumber(FS, Offset), FindNumber(FS, Offset), FindNumber(FS, Offset)),
                    UpAxis = new Vector3<float>(FindNumber(FS, Offset), FindNumber(FS, Offset), FindNumber(FS, Offset)),
                    DisableReset = FindBoolean(FS, Offset),
                    StaticLookOffset = FindBoolean(FS, Offset),
                    DisableAntiBlur = FindBoolean(FS, Offset),
                    DisableCollision = FindBoolean(FS, Offset),
                    DisableFirstPerson = FindBoolean(FS, Offset),
                    GFlagEndErpFrame = FindBoolean(FS, Offset),
                    GFlagThrough = FindBoolean(FS, Offset),
                    GFlagEndTime = FindBoolean(FS, Offset) ? 1 : 0,
                    EnableVerticalPanAxis = FindBoolean(FS, Offset),
                    EventUseTransitionEndTime = FindBoolean(FS, Offset),
                    EventUseTransitionTime = FindBoolean(FS, Offset),
                };
                Entries.Add(Added.ToClipboard());
            }
        }
        #region Legacy Compression Loading functions
        private float FindNumber(Stream LCPCFile, long ValuesOffset)
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
        private string FindString(Stream LCPCFile, long ValuesOffset)
        {
            byte[] Read = new byte[4];
            LCPCFile.Read(Read, 0, 4);
            Array.Reverse(Read);
            long Valueoffset = BitConverter.ToInt32(Read, 0);
            long currentpos = LCPCFile.Position;
            LCPCFile.Seek(ValuesOffset + Valueoffset, SeekOrigin.Begin);
            string value = LCPCFile.ReadString();
            LCPCFile.Position = currentpos;
            return value;
        }
        private bool FindBoolean(Stream LCPCFile, long ValuesOffset)
        {
            byte[] Read = new byte[4];
            LCPCFile.Read(Read, 0, 4);
            Array.Reverse(Read);
            long Valueoffset = BitConverter.ToInt32(Read, 0);
            long currentpos = LCPCFile.Position;
            LCPCFile.Seek(ValuesOffset + Valueoffset, SeekOrigin.Begin);

            bool ret = LCPCFile.ReadByte() == 0x01 ? true : false;

            LCPCFile.Position = currentpos;

            return ret;
        }
        #endregion

        public void SaveModernFile(Stream FS)
        {
            FS.Write(new byte[4] { 0x4C, 0x43, 0x50, 0x50 }, 0, 4);
            FS.WriteByte((byte)LatestVersion.Major);
            FS.WriteByte((byte)LatestVersion.Minor);
            FS.WriteString(Name, 0x00);
            FS.WriteString(Creator, 0x00);
            FS.Write(BitConverter.GetBytes(Entries.Count), 0, 4);
            while (FS.Position % 8 != 0)
                FS.WriteByte(0x00);
            for (int i = 0; i < Entries.Count; i++)
                FS.WriteString(Entries[i], 0x00);
        }

        public MemoryStream SaveModernFile()
        {
            MemoryStream FS = new MemoryStream();
            FS.Write(new byte[4] { 0x4C, 0x43, 0x50, 0x50 }, 0, 4);
            FS.WriteByte((byte)LatestVersion.Major);
            FS.WriteByte((byte)LatestVersion.Minor);
            FS.WriteString(Name, 0x00);
            FS.WriteString(Creator, 0x00);
            FS.Write(BitConverter.GetBytes(Entries.Count), 0, 4);
            while (FS.Position % 8 != 0)
                FS.WriteByte(0x00);
            for (int i = 0; i < Entries.Count; i++)
                FS.WriteString(Entries[i], 0x00);

            return FS;
        }

        public void SaveCompressedModernFile(Stream FS)
        {
            FS.Write(new byte[6] { 0x4C, 0x43, 0x50, 0x43, 0x4E, 0x57 }, 0, 4);
            byte[] Result = YAZ0.Compress(SaveModernFile()).ToArray();
            FS.Write(Result, 0, Result.Length);
        }
    }
}
