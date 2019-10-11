using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// It's a keyframe setup. The header is size 0x20 with constant values. Following that are keyframe indexers. Listed in order, they are: 
///
///    0x20 x_pos 
///    0x2C y_pos 
///    0x38 z_pos 
///    0x44 dir_x 
///    0x50 dir_y 
///    0x5C dir_z 
///    0x68 unknown 
///    0x74 Zoom
///
///    Each keyframe indexer is size 0xC 
///
///    keyframe_indexer: 
///    0x00 KeyframeCount 
///    0x04 DataIndex
///    0x08 Padding
///
///    If element_count is 1, then the camera will use only 1 float value for that field throughout the intro.
///    Otherwise, if element count is greater than 1, then the camera will use multiple keyframes which are 3 floats each: 
///
///    Keyframe: 
///    0x00 Time 
///    0x04 Value
///    0x08 Velocity
///
///
///    The value table is at 0x80. It starts with a uint value for its size and then lists the table values as floats.
///    It seems to always end with the floating point values 0.1, 1E+9 and NAN.
/// </summary>
namespace CANMFiles
{
    /// <summary>
    /// Intro Camera Files
    /// </summary>
    public class CANM
    {
        public Header Header;
        public List<Keyset> Keys = new List<Keyset>();

        public CANM(FileStream canmFile)
        {
            Header = new Header(canmFile);

            for (int i = 0; i < 8; i++)
            {
                Keyset.Value v = Keyset.Value.Unknown;
                switch (i)
                {
                    case 0:
                        v = Keyset.Value.XPos;
                        break;
                    case 1:
                        v = Keyset.Value.YPos;
                        break;
                    case 2:
                        v = Keyset.Value.ZPos;
                        break;
                    case 3:
                        v = Keyset.Value.XDir;
                        break;
                    case 4:
                        v = Keyset.Value.YDir;
                        break;
                    case 5:
                        v = Keyset.Value.ZDir;
                        break;
                    case 6:
                        v = Keyset.Value.Unknown;
                        break;
                    case 7:
                        v = Keyset.Value.Zoom;
                        break;
                }
                Keys.Add(new Keyset(canmFile, v));
            }

            byte[] r = new byte[4];
            canmFile.Read(r, 0, 4);
            Array.Reverse(r);
            Header.FloatTableSize = BitConverter.ToInt32(r, 0);

            foreach (Keyset ks in Keys)
            {
                ks.GetKeyframes(canmFile);
            }
        }

        public void Write(FileStream canmFile)
        {
            byte[] Wright = new byte[4];
            canmFile.Write(Encoding.ASCII.GetBytes("ANDOCKAN"), 0, 8);
            Wright = BitConverter.GetBytes(Header.Unknown1);
            Array.Reverse(Wright);
            canmFile.Write(Wright, 0, 4);
            Wright = BitConverter.GetBytes(Header.Unknown2);
            Array.Reverse(Wright);
            canmFile.Write(Wright, 0, 4);
            Wright = BitConverter.GetBytes(Header.Unknown3);
            Array.Reverse(Wright);
            canmFile.Write(Wright, 0, 4);
            Wright = BitConverter.GetBytes(Header.Unknown4);
            Array.Reverse(Wright);
            canmFile.Write(Wright, 0, 4);
            Wright = BitConverter.GetBytes(Header.Unknown5);
            Array.Reverse(Wright);
            canmFile.Write(Wright, 0, 4);
            Wright = BitConverter.GetBytes(Header.OffsetToFloats);
            Array.Reverse(Wright);
            canmFile.Write(Wright, 0, 4);


            int prevoffset = 0;
            for (int i = 0; i < Keys.Count; i++)
            {
                Wright = BitConverter.GetBytes(Keys[i].KeyframeCount);
                Array.Reverse(Wright);
                canmFile.Write(Wright, 0, 4); //Write KeyframeCount

                Wright = BitConverter.GetBytes(prevoffset);
                prevoffset += Keys[i].KeyframeCount * (Keys[i].KeyframeCount > 1 ? 3 : 1); //Write DataIndex
                Array.Reverse(Wright);
                canmFile.Write(Wright, 0, 4);

                canmFile.Write(new byte[4] { 0x00, 0x00, 0x00, 0x00 }, 0, 4);//Padding
            }

            List<byte> Miles = new List<byte>();
            foreach (Keyset K in Keys)
            {
                for (int i = 0; i < K.Keyframes.Count; i++)
                {
                    if (K.KeyframeCount == 1)
                    {
                        Wright = BitConverter.GetBytes(K.Keyframes[i].Value);
                        Array.Reverse(Wright);
                        Miles.AddRange(Wright);
                        continue;
                    }
                    Wright = BitConverter.GetBytes(K.Keyframes[i].Time);
                    Array.Reverse(Wright);
                    Miles.AddRange(Wright);
                    Wright = BitConverter.GetBytes(K.Keyframes[i].Value);
                    Array.Reverse(Wright);
                    Miles.AddRange(Wright);
                    Wright = BitConverter.GetBytes(K.Keyframes[i].Velocity);
                    Array.Reverse(Wright);
                    Miles.AddRange(Wright);
                }
            }

            Wright = new byte[4];
            Wright = BitConverter.GetBytes(Miles.Count + 8);
            Array.Reverse(Wright);
            canmFile.Write(Wright, 0, 4);
            Wright = Miles.ToArray();
            canmFile.Write(Wright, 0, Wright.Length);

            canmFile.Write(new byte[] { 0x3D, 0xCC, 0xCC, 0xCD, 0x4E, 0x6E, 0x6B, 0x28, 0xFF, 0xFF, 0xFF, 0xFF }, 0, 12);
        }
    }

    public class Header
    {
        public string Format = "ANDOCKAN"; //0x08
        public int Unknown1; // 0x00000001
        public int Unknown2; // 0x00000000

        public int Unknown3; // 0x00000001
        public int Unknown4; // 0x00000004
        public int Unknown5; // 0x000001E0

        public int OffsetToFloats; // 0x00000060

        public int FloatTableSize = 0;

        public Header(FileStream canmFile)
        {
            byte[] Reader = new byte[8];
            canmFile.Read(Reader, 0, 8);
            string check = Encoding.ASCII.GetString(Reader);
            if (check != Format)
            {
                throw new Exception("Failed to read the file!", new Exception("CANM Header is missing or corrupted."));
            }
            Reader = new byte[4];
            canmFile.Read(Reader, 0, 4);
            Array.Reverse(Reader);
            Unknown1 = BitConverter.ToInt32(Reader, 0);
            canmFile.Read(Reader, 0, 4);
            Array.Reverse(Reader);
            Unknown2 = BitConverter.ToInt32(Reader, 0);
            canmFile.Read(Reader, 0, 4);
            Array.Reverse(Reader);
            Unknown3 = BitConverter.ToInt32(Reader, 0);
            canmFile.Read(Reader, 0, 4);
            Array.Reverse(Reader);
            Unknown4 = BitConverter.ToInt32(Reader, 0);
            canmFile.Read(Reader, 0, 4);
            Array.Reverse(Reader);
            Unknown5 = BitConverter.ToInt32(Reader, 0);
            canmFile.Read(Reader, 0, 4);
            Array.Reverse(Reader);
            OffsetToFloats = BitConverter.ToInt32(Reader, 0);
        }
    }

    /// <summary>
    /// Value Group
    /// </summary>
    public class Keyset
    {
        /// <summary>
        /// Determines what value this is
        /// </summary>
        public Value Name; //Not in the file. | Not to be written to the file.
        /// <summary>
        /// Value options
        /// </summary>
        public enum Value
        {
            /// <summary>
            /// X Position of the Camera
            /// </summary>
            XPos,
            /// <summary>
            /// Y Position of the Camera
            /// </summary>
            YPos,
            /// <summary>
            /// Z Position of the Camera
            /// </summary>
            ZPos,
            /// <summary>
            /// X Position to look at
            /// </summary>
            XDir,
            /// <summary>
            /// Y Position to look at
            /// </summary>
            YDir,
            /// <summary>
            /// Z Position to look at
            /// </summary>
            ZDir,
            /// <summary>
            /// Unknown
            /// </summary>
            Unknown,
            /// <summary>
            /// Zoom
            /// </summary>
            Zoom
        }

        /// <summary>
        /// The number of Keyframes
        /// </summary>
        public int KeyframeCount;
        public int DataIndex;
        public int Padding; // 0x00000000

        public List<Keyframe> Keyframes = new List<Keyframe>();

        public Keyset(FileStream canmFile, Value value)
        {
            Name = value;
            byte[] Read = new byte[4];
            canmFile.Read(Read, 0, 4);
            Array.Reverse(Read);
            KeyframeCount = BitConverter.ToInt32(Read, 0);
            canmFile.Read(Read, 0, 4);
            Array.Reverse(Read);
            DataIndex = BitConverter.ToInt32(Read, 0);
            canmFile.Read(Read, 0, 4);
            Array.Reverse(Read);
            Padding = BitConverter.ToInt32(Read, 0);
        }

        public void GetKeyframes(FileStream canmFile)
        {
            long pos = canmFile.Position;
            for (int i = 0; i < this.KeyframeCount; i++)
            {
                canmFile.Position = pos;
                this.Keyframes.Add(new Keyframe(canmFile, (this.DataIndex * 4) + ((12) * i), this.KeyframeCount == 1));
            }
            canmFile.Position = pos;
        }
    }

    /// <summary>
    /// Camera Keyframe
    /// </summary>
    public class Keyframe
    {
        /// <summary>
        /// The keyframe position in the timeline
        /// </summary>
        public float Time; //Position in the Timeline
        /// <summary>
        /// Value. Depends on what keyset this keyframe belongs to
        /// </summary>
        public float Value; //Value (Depends on what is being edited)
        /// <summary>
        /// Smoothness.....kinda
        /// </summary>
        public float Velocity; //Smoothness... kinda

        public Keyframe(FileStream canmFile, int ID, bool IsSingle)
        {
            canmFile.Seek(ID, SeekOrigin.Current);
            byte[] Reading = new byte[4];
            canmFile.Read(Reading, 0, 4);
            Array.Reverse(Reading);
            if (IsSingle)
            {
                Value = BitConverter.ToSingle(Reading, 0);
                return;
            }
            Time = BitConverter.ToSingle(Reading, 0);
            canmFile.Read(Reading, 0, 4);
            Array.Reverse(Reading);
            Value = BitConverter.ToSingle(Reading, 0);
            canmFile.Read(Reading, 0, 4);
            Array.Reverse(Reading);
            Velocity = BitConverter.ToSingle(Reading, 0);
        }

        public Keyframe()
        {
            Time = 0;
            Value = 0;
            Velocity = 0;
        }
    }
}
