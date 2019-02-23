using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CANMFiles
{
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
                Keys.Add(new Keyset(canmFile,v));
            }

            byte[] r = new byte[4];
            canmFile.Read(r, 0, 4);
            Array.Reverse(r);
            Header.FloatTableSize = BitConverter.ToInt32(r,0);

            foreach (Keyset ks in Keys)
            {
                ks.GetKeyframes(canmFile);
            }
        }

        public void Write(FileStream canmFile)
        {
            byte[] Wright = new byte[4];
            canmFile.Write(Encoding.ASCII.GetBytes("ANDOCKAN"),0,8);
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
                canmFile.Write(Wright,0,4);
                if (Keys[i].KeyframeCount <= 2)
                {
                    try
                    {
                        if (Keys[i-1].KeyframeCount != 1)
                        {
                            prevoffset += (3 * Keys[i-1].KeyframeCount)-1;
                        }
                    }
                    catch (Exception) { }
                    Wright = BitConverter.GetBytes(prevoffset+=1);
                }
                else
                {
                    if (i!=0)
                    {
                        Wright = BitConverter.GetBytes(prevoffset = 3 * Keys[i].KeyframeCount + prevoffset);
                    }
                    else
                    {
                        Wright = new byte[4];
                    }
                }
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
            Wright = BitConverter.GetBytes(Miles.Count+8);
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
            canmFile.Read(Reader,0,4);
            Array.Reverse(Reader);
            Unknown1 = BitConverter.ToInt32(Reader,0);
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

    public class Keyset
    {
        public Value Name; //Not in the file. | Not to be written to the file.
        public enum Value { XPos, YPos, ZPos, XDir, YDir, ZDir, Unknown, Zoom }

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
                this.Keyframes.Add(new Keyframe(canmFile,(this.DataIndex*4)+((12)*i),this.KeyframeCount == 1));
            }
            canmFile.Position = pos;
        }
    }

    public class Keyframe
    {
        public float Time; //Position in the Timeline
        public float Value; //Value (Depends on what is being edited)
        public float Velocity; //Smoothness... kinda

        public Keyframe(FileStream canmFile,int ID,bool IsSingle)
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
            Time = BitConverter.ToSingle(Reading,0);
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
