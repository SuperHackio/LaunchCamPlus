using Hack.io.Util;
using LaunchCamPlus;
using LaunchCamPlus.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hack.io.BCAM
{
    public class BCAM
    {
        public Dictionary<uint, BCAMField> Fields { get; set; }
        public int FieldCount => Fields == null ? -1 : Fields.Count;
        public List<BCAMEntry> Entries { get; internal set; }
        public int EntryCount => Entries == null ? -1 : Entries.Count;

        public BCAMEntry this[int index]
        {
            get { return Entries[index]; }
            set { Entries[index] = value; }
        }
        public void Add(BCAMEntry entry) => Entries.Add(entry);
        public void AddRange(List<BCAMEntry> list) => Entries.AddRange(list);
        public void Remove(int index) => Entries.RemoveAt(index);
        public void Clear() => Entries.Clear();
        public void Sort() => Entries = Entries.OrderBy(o => o.Identification).ToList();

        public BCAM()
        {
            Entries = new List<BCAMEntry>();
        }
        public BCAM(Stream BCSV)
        {
            Fields = new Dictionary<uint, BCAMField>();
            Entries = new List<BCAMEntry>();

            int entrycount = BitConverter.ToInt32(BCSV.ReadReverse(0, 4), 0);
            Console.Write($"{entrycount} Cameras ");
            int fieldcount = BitConverter.ToInt32(BCSV.ReadReverse(0, 4), 0);
            Console.WriteLine($"done with {fieldcount} fields");
            uint dataoffset = BitConverter.ToUInt32(BCSV.ReadReverse(0, 4), 0);
            uint entrysize = BitConverter.ToUInt32(BCSV.ReadReverse(0, 4), 0);

            Console.WriteLine("Loading Fields:");
            for (int i = 0; i < fieldcount; i++)
            {
                BCAMField currentfield = new BCAMField(BCSV);
                Fields.Add(currentfield.HashName, currentfield);
                Console.Write($"\r{Math.Min(((float)(i + 1) / (float)fieldcount) * 100.0f, 100.0f)}%          ");
            }
            Console.WriteLine("Complete!");

#if DEBUG
            for (int i = 0; i < 53; i++)
            {
                if (!Fields.ContainsKey(PreferredHashOrder[i]))
                {
                    Console.WriteLine("Excluded Field: " + HashLookup[PreferredHashOrder[i]]);
                }
            }
#endif

            Console.WriteLine("Loading Entries:");
            for (int i = 0; i < entrycount; i++)
            {
                BCAMEntry currententry = new BCAMEntry(BCSV, Fields, dataoffset + (entrycount * entrysize));
                Entries.Add(currententry);
                BCSV.Position += entrysize;

                Console.Write($"\r{Math.Min(((float)(i + 1) / (float)entrycount) * 100.0f, 100.0f)}%          ");
            }
            Console.WriteLine("Complete!");
        }

        public void Save(Stream BCSV)
        {
            CameraDefaults.InitDataTypeList();
            BCSV.WriteReverse(BitConverter.GetBytes(EntryCount), 0, 4);
            List<uint> FinalHashes = new List<uint>();

            ushort offset = 0;
            if (Settings.Default.IsEnforceCompress)
            {
                //FinalHashes.Add(PreferredHashOrder[0]);
                //FinalHashes.Add(PreferredHashOrder[1]);
                for (int i = 0; i < EntryCount; i++)
                    for (int j = 0; j < Entries[i].Data.Count; j++)
                        if (!FinalHashes.Contains(Entries[i].Data.ElementAt(j).Key))
                            FinalHashes.Add(Entries[i].Data.ElementAt(j).Key);

                if (Entries.Any(E => E.IsOfCategory("e")))
                {
                    if (!FinalHashes.Contains(0x05C676D0))
                        FinalHashes.Add(0x05C676D0);
                    if (!FinalHashes.Contains(0x730D4555))
                        FinalHashes.Add(0x730D4555);
                }

                if (FinalHashes.Any(O => O == 0xBEC02B34 || O == 0xBEC02B35 || O == 0xBEC02B36))
                    for (int i = 0; i < 3; i++)
                        if (!FinalHashes.Contains((uint)(0xBEC02B34 + i)))
                            FinalHashes.Add((uint)(0xBEC02B34 + i));

                if (FinalHashes.Any(O => O == 0x31CB1323 || O == 0x31CB1324 || O == 0x31CB1325))
                    for (int i = 0; i < 3; i++)
                        if (!FinalHashes.Contains((uint)(0x31CB1323 + i)))
                            FinalHashes.Add((uint)(0x31CB1323 + i));

                if (FinalHashes.Any(O => O == 0xAC52894B || O == 0xAC52894C || O == 0xAC52894D))
                    for (int i = 0; i < 3; i++)
                        if (!FinalHashes.Contains((uint)(0xAC52894B + i)))
                            FinalHashes.Add((uint)(0xAC52894B + i));

                if (FinalHashes.Any(O => O == 0x3B5CB472 || O == 0x3B5CB473 || O == 0x3B5CB474))
                    for (int i = 0; i < 3; i++)
                        if (!FinalHashes.Contains((uint)(0x3B5CB472 + i)))
                            FinalHashes.Add((uint)(0x3B5CB472 + i));

                if (FinalHashes.Any(O => O == 0x0036D9C5 || O == 0x0036D9C6 || O == 0x0036D9C7))
                    for (int i = 0; i < 3; i++)
                        if (!FinalHashes.Contains((uint)(0x0036D9C5 + i)))
                            FinalHashes.Add((uint)(0x0036D9C5 + i));


                FinalHashes = FinalHashes.SortBy(PreferredHashOrder);

                Fields = new Dictionary<uint, BCAMField>();
                //short FlagOffset = -1;
                //byte flagshift = 0;
                //BitArray MaskArray;
                for (int i = 0; i < FinalHashes.Count; i++)
                {
                    BCAMField CurrentField = new BCAMField() { HashName = FinalHashes[i], EntryOffset = offset, DataType = CameraDefaults.DefaultTypes[FinalHashes[i]] };

                    //if (Settings.Default.IsEnforceCompress && FlagHashes.Any(O => O == FinalHashes[i]))
                    //{
                    //    MaskArray = new BitArray(new int[1]);
                    //    if (FlagOffset == -1)
                    //    {
                    //        FlagOffset = (short)offset;
                    //        offset += 4;
                    //    }

                    //    CurrentField.EntryOffset = (ushort)FlagOffset;
                    //    MaskArray[flagshift] = true;
                    //    CurrentField.Bitmask = (uint)MaskArray.ToInt32();
                    //    CurrentField.ShiftAmount = flagshift++;
                    //}
                    //else
                    //{
                        CurrentField.ShiftAmount = 0;
                        switch (CurrentField.DataType)
                        {
                            case DataTypes.STRING:
                            case DataTypes.FLOAT:
                            case DataTypes.UINT32:
                            case DataTypes.INT32:
                                offset += 4;
                                CurrentField.Bitmask = 0xFFFFFFFF;
                                break;
                            case DataTypes.INT16:
                                offset += 2;
                                CurrentField.Bitmask = 0x0000FFFF;
                                break;
                            case DataTypes.BYTE:
                                offset++;
                                CurrentField.Bitmask = 0x000000FF;
                                break;
                            case DataTypes.UNKNOWN:
                            case DataTypes.NULL:
                            default:
                                throw new Exception();
                        }
                    //}

                    Fields.Add(FinalHashes[i], CurrentField);
                }
            }
            else
            {
                Fields = new Dictionary<uint, BCAMField>();
                for (int i = 0; i < PreferredHashOrder.Length; i++)
                {
                    Fields.Add(PreferredHashOrder[i], new BCAMField() { HashName = PreferredHashOrder[i], Bitmask = HashDataTypes[i] == DataTypes.BYTE ? 0x000000FF : (HashDataTypes[i] == DataTypes.INT16 ? 0x0000FFFF : 0xFFFFFFFF), DataType = HashDataTypes[i], EntryOffset = offset, ShiftAmount = 0 });
                    offset += (ushort)(HashDataTypes[i] == DataTypes.BYTE ? 1 : (HashDataTypes[i] == DataTypes.INT16 ? 2 : 4));
                    FinalHashes.Add(PreferredHashOrder[i]);
                }
            }

#if DEBUG
            for (int i = 0; i < 53; i++)
            {
                if (!FinalHashes.Contains(PreferredHashOrder[i]))
                {
                    Console.WriteLine("Excluded Field: "+HashLookup[PreferredHashOrder[i]]);
                }
            }
#endif
            #region Fill the Entries
            for (int i = 0; i < EntryCount; i++)
                Entries[i].FillMissingFields(FinalHashes);
            #endregion

            #region Collect the strings
            List<string> Strings = new List<string>() { "930" };
            for (int i = 0; i < EntryCount; i++)
            {
                for (int j = 0; j < Entries[i].Data.Count; j++)
                {
                    if (Fields.ContainsKey(Entries[i].Data.ElementAt(j).Key) && Fields[Entries[i].Data.ElementAt(j).Key].DataType == DataTypes.STRING)
                    {
                        if (!Strings.Any(O => O.Equals((string)Entries[i].Data.ElementAt(j).Value)))
                            Strings.Add((string)Entries[i].Data.ElementAt(j).Value);
                    }
                }
            }
            #endregion

            BCSV.WriteReverse(BitConverter.GetBytes(Fields.Count), 0, 4);
            BCSV.Write(new byte[4], 0, 4);
            BCSV.WriteReverse(BitConverter.GetBytes((int)offset), 0, 4);

            Console.WriteLine("Writing the Fields:");
            for (int i = 0; i < Fields.Count; i++)
            {
                Fields.ElementAt(i).Value.Write(BCSV);
                Console.Write($"\r{Math.Min(((float)(i + 1) / (float)Fields.Count) * 100.0f, 100.0f)}%          ");
            }
            Console.WriteLine("Complete!");

            while (BCSV.Position % 4 != 0)
                BCSV.WriteByte(0x00);

            uint DataPos = (uint)BCSV.Position;
            BCSV.Position = 0x08;
            BCSV.WriteReverse(BitConverter.GetBytes(DataPos), 0, 4);
            BCSV.Position = DataPos;
            Console.WriteLine("Writing the Entries:");
            for (int i = 0; i < EntryCount; i++)
            {
                Entries[i].Save(BCSV, Fields, offset, Strings);
                Console.Write($"\r{Math.Min(((float)(i + 1) / (float)Entries.Count) * 100.0f, 100.0f)}%          ");
            }
            Console.WriteLine("Complete!");
            for (int i = 0; i < Strings.Count; i++)
            {
                BCSV.WriteString(Strings[i], 0x00);
            }
            uint numPadding = 16 - (uint)(BCSV.Position % 16);
            byte[] padding = new byte[numPadding];
            for (int i = 0; i < numPadding; i++)
                padding[i] = 64;
            BCSV.Write(padding, 0, (int)numPadding);
        }

        public int InsertAndCombine(int StartingValue, int AddingValue, out uint Mask, out byte ShiftVal)
        {
            Mask = 0;
            ShiftVal = 0;

            BitArray StartingBits = new BitArray(new int[] { StartingValue });
            BitArray AddingBits = new BitArray(new int[] { AddingValue });

            int MinAddBitSize = GetMinLength(AddingValue);
            bool success = false;
            for (int i = 0; i < StartingBits.Count-MinAddBitSize; i++)
            {
                if (StartingBits[i] == AddingBits[0])
                {
                    bool CanFit = true;
                    for (int j = 0; j < MinAddBitSize; j++)
                    {
                        if (StartingBits[i+j] != AddingBits[j])
                        {
                            CanFit = false;
                            break;
                        }
                    }

                    if (CanFit)
                    {
                        success = true;
                        BitArray BitMask = new BitArray(new int[1]);
                        for (int j = 0; j < MinAddBitSize; j++)
                        {
                            BitMask[i + j] = true;
                        }
                        Mask = (uint)BitMask.ToInt32();
                        ShiftVal = (byte)i;
                        break;
                    }
                }
            }
            if (!success)
            {
                int NumberInsertLocation = GetMinLength(StartingValue);
                int BackwardsOffset = 0;
                bool HasFoundFit = false;
                int BestFitOffset = 0;
                while (NumberInsertLocation - BackwardsOffset > 0)
                {
                    if (StartingBits[NumberInsertLocation-BackwardsOffset] == AddingBits[0])
                    {
                        bool CanFit = true;
                        for (int i = 0; i < MinAddBitSize; i++)
                        {
                            if (AddingBits[i] && StartingBits[(NumberInsertLocation-BackwardsOffset)+i] != AddingBits[i])
                            {
                                if ((NumberInsertLocation - BackwardsOffset) + i < NumberInsertLocation)
                                {
                                    CanFit = false;
                                    break;
                                }
                            }
                        }

                        if (CanFit)
                        {
                            HasFoundFit = true;
                            BestFitOffset = NumberInsertLocation - BackwardsOffset;
                            break;
                        }
                    }
                    BackwardsOffset++;
                }

                for (int j = 0; j < MinAddBitSize; j++)
                {
                    StartingBits[HasFoundFit ? BestFitOffset + j : NumberInsertLocation] = AddingBits[j];
                }

                BitArray BitMask = new BitArray(new int[1]);
                for (int j = 0; j < MinAddBitSize; j++)
                {
                    BitMask[HasFoundFit ? BestFitOffset + j : NumberInsertLocation] = true;
                }
                Mask = (uint)BitMask.ToInt32();
                ShiftVal = (byte)(HasFoundFit ? BestFitOffset : NumberInsertLocation);
            }


            return StartingBits.ToInt32();
        }

        private int GetMinLength(int val)
        {
            for (int i = 28; i >= 0; i -= 4)
                if ((val >> i) > 0)
                    return i + 4;
            return 0;
        }


        public static uint FieldNameToHash(string field)
        {
            uint ret = 0;
            foreach (char ch in field)
            {
                ret *= 0x1F;
                ret += ch;
            }
            return ret;
        }

        public static readonly uint[] PreferredHashOrder = new uint[]{
        #region General
        0x14F51CD8, //Version
        0x00000DC1, //No
        0x00000D1B, //ID
        0x20C58F89, //Type
        0xCAD56011, //string
        0xABC4A1CF, //RotationX
        0xABC4A1CE, //RotationY
        0x0035807D, //RotationZ
        0x002F0DA6, //Zoom
        0x00300D4C, //Field of View
        0xAE79D1C0, //Transition Time
        0xEB66C5C3, //End Transition Time
        0xB6004E72, //Ground Speed.....Does literally nothing. Only different in like, 8 files between both games.
        0x0033C56B, //num1 [Various things]
        0x0033C56C, //num2 [Various things]
        0x06A54929, //MaxY
        0x062675A0, //MinY
        0xD26F6AA9, //GroundStarMoveDelay
        0x93AECC0B, //AirStartMoveDelay
        0x069FE297, //udown...does literally nothing...?
        0x145863FF, //Front Zoom
        0x76B41C57, //Height Zoom
        0x06A558A2, //Upper Border
        0x06262B01, //Lower Border
        0x05C676D0, //Event Frames
        0x730D4555, //Event Priority
        #endregion

        #region Coordinates
        0xBEC02B34, //Fixpoint Offset X
        0xBEC02B35, //Fixpoint Offset Y
        0xBEC02B36, //Fixpoint Offset Z
        //--------------------------------------------------------------------------------------------------
        0x31CB1323, //Worldpoint Offset X
        0x31CB1324, //Worldpoint Offset Y
        0x31CB1325, //Worldpoint Offset Z
        //--------------------------------------------------------------------------------------------------
        0xAC52894B, //Player Offset X
        0xAC52894C, //Player Offset Y
        0xAC52894D, //Player Offset Z
        //--------------------------------------------------------------------------------------------------
        0x3B5CB472, //Verticle Pan Axis X
        0x3B5CB473, //Verticle Pan Axis Y
        0x3B5CB474, //Verticle Pan Axis Z
        //--------------------------------------------------------------------------------------------------
        0x0036D9C5, //Up Axis X
        0x0036D9C6, //Up Axis Y
        0x0036D9C7, //Up Axis Z
        #endregion

        #region Flags
        //Put all these into 1 int through the power of masking
        0x41E363AC, //DisableReset
        0x9F02074F, //Enable Field of View
        0x82D5627E, //Enable Sharp Zoom
        0xE2044E84, //Disable Anti-blur
        0x521E5C3F, //Disable Collision
        0xBB74D6C1, //Disable First Person
        0xDA484167, //GroupFlagEndErpFrame
        0xED8DD072, //GroupFlagThrough
        0x67D981E8, //GroupFlagEndTransitionSpeed
        0x26C8C3C0, //Use Verticle Pan Axis
        0x45E50EE5, //Event Use Transition
        0x1BCD52AA  //Event Use End Transition
        #endregion
        };
        
        public static readonly string[] HashNames = new string[]{
        #region General
        "Version",
        "No",
        "ID",
        "Type",
        "string",
        "RotationX",
        "RotationY",
        "RotationZ",
        "Zoom",
        "Field of View",
        "Transition Time",
        "End Transition Time",
        "Ground Speed",
        "num1",
        "num2",
        "MaxY",
        "MinY",
        "GroundStarMoveDelay",
        "AirStartMoveDelay",
        "udown",
        "Look Offset",
        "Look Offset Vertical",
        "Upper Border",
        "Lower Border",
        "Event Frames",
        "Event Priority",
        #endregion

        #region Coordinates
        "Fixpoint Offset X",
        "Fixpoint Offset Y",
        "Fixpoint Offset Z",
        //--------------------------------------------------------------------------------------------------
        "Worldpoint Offset X",
        "Worldpoint Offset Y",
        "Worldpoint Offset Z",
        //--------------------------------------------------------------------------------------------------
        "Player Offset X",
        "Player Offset Y",
        "Player Offset Z",
        //--------------------------------------------------------------------------------------------------
        "Verticle Pan Axis X",
        "Verticle Pan Axis Y",
        "Verticle Pan Axis Z",
        //--------------------------------------------------------------------------------------------------
        "Up Axis X",
        "Up Axis Y",
        "Up Axis Z",
        #endregion

        #region Flags
        //Put all these into 1 int through the power of masking
        "DisableReset",
        "Enable Field of View",
        "Static Look Offset",
        "Disable Anti-blur",
        "Disable Collision",
        "Disable First Person",
        "GroupFlagEndErpFrame",
        "GroupFlagThrough",
        "GroupFlagEndTransitionSpeed",
        "Use Verticle Pan Axis",
        "Event Use Transition",
        "Event Use End Transition",
        #endregion
        };

        public static readonly DataTypes[] HashDataTypes = new DataTypes[]
        {
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.STRING,
            DataTypes.STRING,
            DataTypes.STRING,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.INT32,
            DataTypes.INT32,

            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,
            DataTypes.FLOAT,

            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
            DataTypes.INT32,
        };

        //The game doesn't allow this.... Can we get an F in the chat.
        //private static uint[] FlagHashes => new uint[]
        //{
        //    //Put all these into 1 int through the power of masking
        //    0x41E363AC, //DisableReset
        //    0x9F02074F, //Enable Field of View
        //    0x82D5627E, //Enable Sharp Zoom
        //    0xE2044E84, //Disable Anti-blur
        //    0x521E5C3F, //Disable Collision
        //    0xBB74D6C1, //Disable First Person
        //    0xDA484167, //GroupFlagEndErpFrame
        //    0xED8DD072, //GroupFlagThrough
        //    0x67D981E8, //GroupFlagEndTransitionSpeed //LOL THIS ISN'T EVEN A FLAG 😂
        //    0x26C8C3C0, //Use Verticle Pan Axis'
        //    0x45E50EE5, //Event Use Transition
        //    0x1BCD52AA  //Event Use End Transition
        //};

        public Dictionary<uint, string> HashLookup
        {
            get
            {
                if (_lookup == null)
                {
                    _lookup = new Dictionary<uint, string>();
                    for (int i = 0; i < PreferredHashOrder.Length; i++)
                        _lookup.Add(PreferredHashOrder[i], HashNames[i]);
                }
                return _lookup;
            }
        }
        private Dictionary<uint, string> _lookup = null;
    }

    public class BCAMField
    {
        public uint HashName { get; set; }
        public uint Bitmask { get; set; }
        public ushort EntryOffset { get; internal set; }
        public byte ShiftAmount { get; set; }
        public DataTypes DataType { get; set; }

        public BCAMField()
        {

        }
        public BCAMField(Stream BCSV)
        {
            HashName = BitConverter.ToUInt32(BCSV.ReadReverse(0, 4), 0);
            Bitmask = BitConverter.ToUInt32(BCSV.ReadReverse(0, 4), 0);
            EntryOffset = BitConverter.ToUInt16(BCSV.ReadReverse(0, 2), 0);
            ShiftAmount = (byte)BCSV.ReadByte();
            DataType = (DataTypes)BCSV.ReadByte();
        }

        internal void Write(Stream BCSV)
        {
            BCSV.WriteReverse(BitConverter.GetBytes(HashName), 0, 4);
            BCSV.WriteReverse(BitConverter.GetBytes(Bitmask), 0, 4);
            BCSV.WriteReverse(BitConverter.GetBytes(EntryOffset), 0, 2);
            BCSV.WriteByte(ShiftAmount);
            BCSV.WriteByte((byte)DataType);
        }
    }

    public class BCAMEntry
    {
        public Dictionary<uint, object> Data { get; set; }

        public BCAMEntry()
        {
            Data = new Dictionary<uint, object>();
        }
        internal BCAMEntry(Stream BCSV, Dictionary<uint, BCAMField> fields, long StringOffset)
        {
            long EntryStartPosition = BCSV.Position;
            Data = new Dictionary<uint, object>();
            for (int i = 0; i < fields.Count; i++)
            {
                BCSV.Position = EntryStartPosition + fields.ElementAt(i).Value.EntryOffset;
                switch (fields.ElementAt(i).Value.DataType)
                {
                    case DataTypes.INT32:
                        int readvalue = BitConverter.ToInt32(BCSV.ReadReverse(0, 4), 0);
                        uint Bitmask = fields.ElementAt(i).Value.Bitmask;
                        byte Shift = fields.ElementAt(i).Value.ShiftAmount;
                        Data.Add(fields.ElementAt(i).Key, (int)((readvalue & Bitmask) >> Shift));
                        break;
                    case DataTypes.UNKNOWN:
                        Data.Add(fields.ElementAt(i).Key, null);
                        Console.WriteLine("=== WARNING ===");
                        Console.WriteLine("BCSV Entry is of the UNKNOWN type (0x01). This shouldn't happen.");
                        break;
                    case DataTypes.FLOAT:
                        Data.Add(fields.ElementAt(i).Key, BitConverter.ToSingle(BCSV.ReadReverse(0, 4), 0));
                        break;
                    case DataTypes.UINT32:
                        Data.Add(fields.ElementAt(i).Key, BitConverter.ToUInt32(BCSV.ReadReverse(0, 4), 0));
                        break;
                    case DataTypes.INT16:
                        Data.Add(fields.ElementAt(i).Key, BitConverter.ToInt16(BCSV.ReadReverse(0, 2), 0));
                        break;
                    case DataTypes.BYTE:
                        Data.Add(fields.ElementAt(i).Key, (byte)BCSV.ReadByte());
                        break;
                    case DataTypes.STRING:
                        BCSV.Position = StringOffset + BitConverter.ToUInt32(BCSV.ReadReverse(0, 4), 0);
                        Data.Add(fields.ElementAt(i).Key, BCSV.ReadString());
                        break;
                    case DataTypes.NULL:
                        Data.Add(fields.ElementAt(i).Key, null);
                        Console.WriteLine("=== WARNING ===");
                        Console.WriteLine("BCSV Entry is of the NULL type (0x07). This shouldn't happen.");
                        break;
                }
            }
            BCSV.Position = EntryStartPosition;
        }

        internal void Save(Stream BCSV, Dictionary<uint, BCAMField> fields, uint DataLength, List<string> Strings)
        {
            BitArray flagvalue = new BitArray(new int[1]);
            long OriginalPosition = BCSV.Position;
            BCSV.Write(new byte[DataLength], 0, (int)DataLength);
            for (int i = 0; i < fields.Count; i++)
            {
                BCSV.Position = OriginalPosition + fields.ElementAt(i).Value.EntryOffset;
                if (Data.ContainsKey(fields.ElementAt(i).Key))
                {
                    switch (fields.ElementAt(i).Value.DataType)
                    {
                        case DataTypes.INT32:
                            if (fields.ElementAt(i).Value.Bitmask != 0xFFFFFFFF)
                            {
                                flagvalue[fields.ElementAt(i).Value.ShiftAmount] = (int)Data[fields.ElementAt(i).Key] == 1;
                                int temp = flagvalue.ToInt32();
                                BCSV.WriteReverse(BitConverter.GetBytes(temp), 0, 4);
                            }
                            else
                                BCSV.WriteReverse(BitConverter.GetBytes(int.Parse(Data[fields.ElementAt(i).Key].ToString())), 0, 4);
                            break;
                        case DataTypes.UNKNOWN:
                            break;
                        case DataTypes.FLOAT:
                            BCSV.WriteReverse(BitConverter.GetBytes((float)Data[fields.ElementAt(i).Key]), 0, 4);
                            break;
                        case DataTypes.UINT32:
                            BCSV.WriteReverse(BitConverter.GetBytes((uint)Data[fields.ElementAt(i).Key]), 0, 4);
                            break;
                        case DataTypes.INT16:
                            BCSV.WriteReverse(BitConverter.GetBytes((short)Data[fields.ElementAt(i).Key]), 0, 2);
                            break;
                        case DataTypes.BYTE:
                            BCSV.WriteReverse(BitConverter.GetBytes((byte)Data[fields.ElementAt(i).Key]), 0, 1);
                            break;
                        case DataTypes.STRING:
                            Encoding enc = Encoding.GetEncoding(932);
                            uint StringOffset = 0;
                            for (int j = 0; j < Strings.Count; j++)
                            {
                                if (Strings[j].Equals((string)Data[fields.ElementAt(i).Key]))
                                {
                                    BCSV.WriteReverse(BitConverter.GetBytes(StringOffset), 0, 4);
                                    break;
                                }
                                StringOffset += (uint)(enc.GetBytes(Strings[j]).Length + 1);
                            }
                            break;
                        case DataTypes.NULL:
                            break;
                    }
                }
            }
            BCSV.Position = OriginalPosition + DataLength;
        }

        internal void FillMissingFields(List<uint> fields)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                if (!Data.ContainsKey(fields[i]))
                {
                    Data.Add(fields[i], CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[fields[i]]);

                    if (Data[fields[i]] is bool)
                        Data[fields[i]] = ((bool)Data[fields[i]]) ? 1 : 0;
                }
            }
        }

        public bool ContainsKey(uint key) => Data.ContainsKey(key);
        
        public bool IsOfCategory(string Category) => Identification.StartsWith(Category+":");
        public string GetCategory() => (Identification.Length > 2 && Identification[1]==':') ? Identification.Split(':')[0] : "u";

        public bool FromClipboard(string input)
        {
            if (!input.StartsWith("LCP|"))
                return false;

            int DataIndex = 0;
            Dictionary<uint, object> backup = Data;
            try
            {
                string[] DataSplit = input.Split('|');

                Data.Clear();
                for (int i = 1; i < DataSplit.Length; i++)
                {
                    string[] currentdata = DataSplit[i].Split('%');
                    DataIndex = i;
                    if (uint.TryParse(currentdata[0], System.Globalization.NumberStyles.HexNumber, null, out uint result))
                        Data.Add(result, Convert.ChangeType(currentdata[1], System.Type.GetType("System." + currentdata[2], true)));
                }
                if (!Data.ContainsKey(0x00000D1B) && backup.ContainsKey(0x00000D1B))
                    Data.Add(0x00000D1B, backup[0x00000D1B]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Pasting at Data Set {DataIndex}: "+e.Message);
                Data = backup;
                return false;
            }
            return true;
        }
        public string ToClipboard()
        {
            string clip = "LCP";
            for (int i = 0; i < Data.Count; i++)
                clip += "|"+Data.ElementAt(i).Key.ToString("X8")+"%"+Data.ElementAt(i).Value.ToString()+"%"+Data.ElementAt(i).Value.GetType().ToString().Replace("System.","");
            return clip;
        }

        /// <summary>
        /// USELESS
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// USELESS
        /// </summary>
        public int Num { get; set; }

        public string Identification
        {
            get
            {
                if (Data.ContainsKey(0x00000D1B))
                    return (string)Data[0x00000D1B];
                else
                    return "<MISSING>";
            }
            set
            {
                if (Data.ContainsKey(0x00000D1B))
                    Data[0x00000D1B] = value;
                else
                    Data.Add(0x00000D1B, value);
            }
        }
        public string Type
        {
            get
            {
                if (Data.ContainsKey(0x20C58F89))
                    return (string)Data[0x20C58F89];
                else
                    return "CAM_TYPE_XZ_PARA";
            }
            set
            {
                if (Data.ContainsKey(0x20C58F89))
                    Data[0x20C58F89] = value;
                else
                    Data.Add(0x20C58F89, value);
            }
        }

        public float RotationX
        {
            get
            {
                if (Data.ContainsKey(0xABC4A1CF))
                    return (float)Data[0xABC4A1CF];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xABC4A1CF];
            }
            set
            {
                if (Data.ContainsKey(0xABC4A1CF))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xABC4A1CF])
                        Data.Remove(0xABC4A1CF);
                    else
                        Data[0xABC4A1CF] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xABC4A1CF])
                    Data.Add(0xABC4A1CF, value);
            }
        }
        public float RotationY
        {
            get
            {
                if (Data.ContainsKey(0xABC4A1CE))
                    return (float)Data[0xABC4A1CE];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xABC4A1CE];
            }
            set
            {
                if (Data.ContainsKey(0xABC4A1CE))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xABC4A1CE])
                        Data.Remove(0xABC4A1CE);
                    else
                        Data[0xABC4A1CE] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xABC4A1CE])
                    Data.Add(0xABC4A1CE, value);
            }
        }
        /// <summary>
        /// Roll
        /// </summary>
        public float RotationZ
        {
            get
            {
                if (Data.ContainsKey(0x0035807D))
                    return (float)Data[0x0035807D];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0035807D];
            }
            set
            {
                if (Data.ContainsKey(0x0035807D))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0035807D])
                        Data.Remove(0x0035807D);
                    else
                        Data[0x0035807D] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0035807D])
                    Data.Add(0x0035807D, value);
            }
        }
        
        public float Zoom
        {
            get
            {
                if (Data.ContainsKey(0x002F0DA6))
                    return (float)Data[0x002F0DA6];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x002F0DA6];
            }
            set
            {
                if (Data.ContainsKey(0x002F0DA6))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x002F0DA6])
                        Data.Remove(0x002F0DA6);
                    else
                        Data[0x0002F0DA6] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x002F0DA6])
                    Data.Add(0x002F0DA6, value);
            }
        }
        public float FieldOfView
        {
            get
            {
                if (Data.ContainsKey(0x00300D4C))
                    return (float)Data[0x00300D4C];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x00300D4C];
            }
            set
            {
                if (Data.ContainsKey(0x00300D4C))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x00300D4C])
                        Data.Remove(0x00300D4C);
                    else
                        Data[0x00300D4C] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x00300D4C])
                    Data.Add(0x00300D4C, value);
            }
        }
        
        public int TransitionTime
        {
            get
            {
                if (Data.ContainsKey(0xAE79D1C0))
                    return (int)Data[0xAE79D1C0];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAE79D1C0];
            }
            set
            {
                if (Data.ContainsKey(0xAE79D1C0))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAE79D1C0])
                        Data.Remove(0xAE79D1C0);
                    else
                        Data[0xAE79D1C0] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAE79D1C0])
                    Data.Add(0xAE79D1C0, value);
            }
        }
        /// <summary>
        /// Event value, only used by e: cameras
        /// </summary>
        public int TransitionEndTime
        {
            get
            {
                if (Data.ContainsKey(0xEB66C5C3))
                    return (int)Data[0xEB66C5C3];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xEB66C5C3];
            }
            set
            {
                if (Data.ContainsKey(0xEB66C5C3))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xEB66C5C3])
                        Data.Remove(0xEB66C5C3);
                    else
                        Data[0xEB66C5C3] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xEB66C5C3])
                    Data.Add(0xEB66C5C3, value);
            }
        }
        public int TransitionGroundTime
        {
            get
            {
                if (Data.ContainsKey(0xB6004E72))
                    return (int)Data[0xB6004E72];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xB6004E72];
            }
            set
            {
                if (Data.ContainsKey(0xB6004E72))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xB6004E72])
                        Data.Remove(0xB6004E72);
                    else
                        Data[0xB6004E72] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xB6004E72])
                    Data.Add(0xB6004E72, value);
            }
        }

        public int Num1
        {
            get
            {
                if (Data.ContainsKey(0x0033C56B))
                    return (int)Data[0x0033C56B];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0033C56B];
            }
            set
            {
                if (Data.ContainsKey(0x0033C56B))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0033C56B])
                        Data.Remove(0x0033C56B);
                    else
                        Data[0x0033C56B] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0033C56B])
                    Data.Add(0x0033C56B, value);
            }
        }
        public int Num2
        {
            get
            {
                if (Data.ContainsKey(0x0033C56C))
                    return (int)Data[0x0033C56C];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0033C56C];
            }
            set
            {
                if (Data.ContainsKey(0x0033C56C))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0033C56C])
                        Data.Remove(0x0033C56C);
                    else
                        Data[0x0033C56C] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0033C56C])
                    Data.Add(0x0033C56C, value);
            }
        }
        public string String
        {
            get
            {
                if (Data.ContainsKey(0xCAD56011))
                    return (string)Data[0xCAD56011];
                else
                    return (string)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xCAD56011];
            }
            set
            {
                if (Data.ContainsKey(0xCAD56011))
                {
                    if (value.Equals((string)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xCAD56011]))
                        Data.Remove(0xCAD56011);
                    else
                        Data[0xCAD56011] = value;
                }
                else if (!value.Equals((string)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xCAD56011]))
                    Data.Add(0xCAD56011, value);
            }
        }
        
        public float MaxY
        {
            get
            {
                if (Data.ContainsKey(0x06A54929))
                    return (float)Data[0x06A54929];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x06A54929];
            }
            set
            {
                if (Data.ContainsKey(0x06A54929))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x06A54929])
                        Data.Remove(0x06A54929);
                    else
                        Data[0x06A54929] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x06A54929])
                    Data.Add(0x06A54929, value);
            }
        }
        public float MinY
        {
            get
            {
                if (Data.ContainsKey(0x062675A0))
                    return (float)Data[0x062675A0];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x062675A0];
            }
            set
            {
                if (Data.ContainsKey(0x062675A0))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x062675A0])
                        Data.Remove(0x062675A0);
                    else
                        Data[0x062675A0] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x062675A0])
                    Data.Add(0x062675A0, value);
            }
        }

        public int GroundMoveDelay
        {
            get
            {
                if (Data.ContainsKey(0xD26F6AA9))
                    return (int)Data[0xD26F6AA9];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xD26F6AA9];
            }
            set
            {
                if (Data.ContainsKey(0xD26F6AA9))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xD26F6AA9])
                        Data.Remove(0xD26F6AA9);
                    else
                        Data[0xD26F6AA9] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xD26F6AA9])
                    Data.Add(0xD26F6AA9, value);
            }
        }
        public int AirMoveDelay
        {
            get
            {
                if (Data.ContainsKey(0x93AECC0B))
                    return (int)Data[0x93AECC0B];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x93AECC0B];
            }
            set
            {
                if (Data.ContainsKey(0x93AECC0B))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x93AECC0B])
                        Data.Remove(0x93AECC0B);
                    else
                        Data[0x93AECC0B] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x93AECC0B])
                    Data.Add(0x93AECC0B, value);
            }
        }
        public int UDown
        {
            get
            {
                if (Data.ContainsKey(0x069FE297))
                    return (int)Data[0x069FE297];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x069FE297];
            }
            set
            {
                if (Data.ContainsKey(0x069FE297))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x069FE297])
                        Data.Remove(0x069FE297);
                    else
                        Data[0x069FE297] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x069FE297])
                    Data.Add(0x069FE297, value);
            }
        }

        public float LookOffset
        {
            get
            {
                if (Data.ContainsKey(0x145863FF))
                    return (float)Data[0x145863FF];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x145863FF];
            }
            set
            {
                if (Data.ContainsKey(0x145863FF))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x145863FF])
                        Data.Remove(0x145863FF);
                    else
                        Data[0x145863FF] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x145863FF])
                    Data.Add(0x145863FF, value);
            }
        }
        public float LookOffsetVertical
        {
            get
            {
                if (Data.ContainsKey(0x76B41C57))
                    return (float)Data[0x76B41C57];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x76B41C57];
            }
            set
            {
                if (Data.ContainsKey(0x76B41C57))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x76B41C57])
                        Data.Remove(0x76B41C57);
                    else
                        Data[0x76B41C57] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x76B41C57])
                    Data.Add(0x76B41C57, value);
            }
        }
        public float UpperBorder
        {
            get
            {
                if (Data.ContainsKey(0x06A558A2))
                    return (float)Data[0x06A558A2];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x06A558A2];
            }
            set
            {
                if (Data.ContainsKey(0x06A558A2))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x06A558A2])
                        Data.Remove(0x06A558A2);
                    else
                        Data[0x06A558A2] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x06A558A2])
                    Data.Add(0x06A558A2, value);
            }
        }
        public float LowerBorder
        {
            get
            {
                if (Data.ContainsKey(0x06262B01))
                    return (float)Data[0x06262B01];
                else
                    return (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x06262B01];
            }
            set
            {
                if (Data.ContainsKey(0x06262B01))
                {
                    if (value == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x06262B01])
                        Data.Remove(0x06262B01);
                    else
                        Data[0x06262B01] = value;
                }
                else if (value != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x06262B01])
                    Data.Add(0x06262B01, value);
            }
        }

        /// <summary>
        /// Event value, only used by e: cameras
        /// </summary>
        public int EventFrames
        {
            get
            {
                if (Data.ContainsKey(0x05C676D0))
                    return (int)Data[0x05C676D0];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x05C676D0];
            }
            set
            {
                if (Data.ContainsKey(0x05C676D0))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x05C676D0])
                        Data.Remove(0x05C676D0);
                    else
                        Data[0x05C676D0] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x05C676D0])
                    Data.Add(0x05C676D0, value);
            }
        }
        /// <summary>
        /// Event value, only used by e: cameras
        /// </summary>
        public int EventPriority
        {
            get
            {
                if (Data.ContainsKey(0x730D4555))
                    return (int)Data[0x730D4555];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x730D4555];
            }
            set
            {
                if (Data.ContainsKey(0x730D4555))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x730D4555])
                        Data.Remove(0x730D4555);
                    else
                        Data[0x730D4555] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x730D4555])
                    Data.Add(0x730D4555, value);
            }
        }

        public Vector3<float> FixPointOffset
        {
            get
            {
                return new Vector3<float>(
                    Data.ContainsKey(0xBEC02B34) ? (float)Data[0xBEC02B34] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBEC02B34],
                    Data.ContainsKey(0xBEC02B35) ? (float)Data[0xBEC02B35] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBEC02B35],
                    Data.ContainsKey(0xBEC02B36) ? (float)Data[0xBEC02B36] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBEC02B36]);
            }
            set
            {
                if (Data.ContainsKey(0xBEC02B34))
                {
                    if (value.XValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBEC02B34])
                        Data.Remove(0xBEC02B34);
                    else
                        Data[0xBEC02B34] = value.XValue;
                }
                else if (value.XValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBEC02B34])
                    Data.Add(0xBEC02B34, value.XValue);

                if (Data.ContainsKey(0xBEC02B35))
                {
                    if (value.YValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBEC02B35])
                        Data.Remove(0xBEC02B35);
                    else
                        Data[0xBEC02B35] = value.YValue;
                }
                else if (value.YValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBEC02B35])
                    Data.Add(0xBEC02B35, value.YValue);

                if (Data.ContainsKey(0xBEC02B36))
                {
                    if (value.ZValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBEC02B36])
                        Data.Remove(0xBEC02B36);
                    else
                        Data[0xBEC02B36] = value.ZValue;
                }
                else if (value.ZValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBEC02B36])
                    Data.Add(0xBEC02B36, value.ZValue);
            }
        }
        public Vector3<float> WorldPointOffset
        {
            get
            {
                return new Vector3<float>(
                    Data.ContainsKey(0x31CB1323) ? (float)Data[0x31CB1323] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x31CB1323],
                    Data.ContainsKey(0x31CB1324) ? (float)Data[0x31CB1324] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x31CB1324],
                    Data.ContainsKey(0x31CB1325) ? (float)Data[0x31CB1325] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x31CB1325]);
            }
            set
            {
                if (Data.ContainsKey(0x31CB1323))
                {
                    if (value.XValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x31CB1323])
                        Data.Remove(0x31CB1323);
                    else
                        Data[0x31CB1323] = value.XValue;
                }
                else if (value.XValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x31CB1323])
                    Data.Add(0x31CB1323, value.XValue);

                if (Data.ContainsKey(0x31CB1324))
                {
                    if (value.YValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x31CB1324])
                        Data.Remove(0x31CB1324);
                    else
                        Data[0x31CB1324] = value.YValue;
                }
                else if (value.YValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x31CB1324])
                    Data.Add(0x31CB1324, value.YValue);

                if (Data.ContainsKey(0x31CB1325))
                {
                    if (value.ZValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x31CB1325])
                        Data.Remove(0x31CB1325);
                    else
                        Data[0x31CB1325] = value.ZValue;
                }
                else if (value.ZValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x31CB1325])
                    Data.Add(0x31CB1325, value.ZValue);
            }
        }
        public Vector3<float> PlayerOffset
        {
            get
            {
                return new Vector3<float>(
                    Data.ContainsKey(0xAC52894B) ? (float)Data[0xAC52894B] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAC52894B],
                    Data.ContainsKey(0xAC52894C) ? (float)Data[0xAC52894C] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAC52894C],
                    Data.ContainsKey(0xAC52894D) ? (float)Data[0xAC52894D] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAC52894D]);
            }
            set
            {
                if (Data.ContainsKey(0xAC52894B))
                {
                    if (value.XValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAC52894B])
                        Data.Remove(0xAC52894B);
                    else
                        Data[0xAC52894B] = value.XValue;
                }
                else if (value.XValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAC52894B])
                    Data.Add(0xAC52894B, value.XValue);

                if (Data.ContainsKey(0xAC52894C))
                {
                    if (value.YValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAC52894C])
                        Data.Remove(0xAC52894C);
                    else
                        Data[0xAC52894C] = value.YValue;
                }
                else if (value.YValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAC52894C])
                    Data.Add(0xAC52894C, value.YValue);

                if (Data.ContainsKey(0xAC52894D))
                {
                    if (value.ZValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAC52894D])
                        Data.Remove(0xAC52894D);
                    else
                        Data[0xAC52894D] = value.ZValue;
                }
                else if (value.ZValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xAC52894D])
                    Data.Add(0xAC52894D, value.ZValue);
            }
        }
        public Vector3<float> VerticalPanAxis
        {
            get
            {
                return new Vector3<float>(
                    Data.ContainsKey(0x3B5CB472) ? (float)Data[0x3B5CB472] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x3B5CB472],
                    Data.ContainsKey(0x3B5CB473) ? (float)Data[0x3B5CB473] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x3B5CB473],
                    Data.ContainsKey(0x3B5CB474) ? (float)Data[0x3B5CB474] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x3B5CB474]);
            }
            set
            {
                if (Data.ContainsKey(0x3B5CB472))
                {
                    if (value.XValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x3B5CB472])
                        Data.Remove(0x3B5CB472);
                    else
                        Data[0x3B5CB472] = value.XValue;
                }
                else if (value.XValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x3B5CB472])
                    Data.Add(0x3B5CB472, value.XValue);

                if (Data.ContainsKey(0x3B5CB473))
                {
                    if (value.YValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x3B5CB473])
                        Data.Remove(0x3B5CB473);
                    else
                        Data[0x3B5CB473] = value.YValue;
                }
                else if (value.YValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x3B5CB473])
                    Data.Add(0x3B5CB473, value.YValue);

                if (Data.ContainsKey(0x3B5CB474))
                {
                    if (value.ZValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x3B5CB474])
                        Data.Remove(0x3B5CB474);
                    else
                        Data[0x3B5CB474] = value.ZValue;
                }
                else if (value.ZValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x3B5CB474])
                    Data.Add(0x3B5CB474, value.ZValue);
            }
        }
        public Vector3<float> UpAxis
        {
            get
            {
                return new Vector3<float>(
                    Data.ContainsKey(0x0036D9C5) ? (float)Data[0x0036D9C5] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0036D9C5],
                    Data.ContainsKey(0x0036D9C6) ? (float)Data[0x0036D9C6] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0036D9C6],
                    Data.ContainsKey(0x0036D9C7) ? (float)Data[0x0036D9C7] : (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0036D9C7]);
            }
            set
            {
                if (Data.ContainsKey(0x0036D9C5))
                {
                    if (value.XValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0036D9C5])
                        Data.Remove(0x0036D9C5);
                    else
                        Data[0x0036D9C5] = value.XValue;
                }
                else if (value.XValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0036D9C5])
                    Data.Add(0x0036D9C5, value.XValue);

                if (Data.ContainsKey(0x0036D9C6))
                {
                    if (value.YValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0036D9C6])
                        Data.Remove(0x0036D9C6);
                    else
                        Data[0x0036D9C6] = value.YValue;
                }
                else if (value.YValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0036D9C6])
                    Data.Add(0x0036D9C6, value.YValue);

                if (Data.ContainsKey(0x0036D9C7))
                {
                    if (value.ZValue == (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0036D9C7])
                        Data.Remove(0x0036D9C7);
                    else
                        Data[0x0036D9C7] = value.ZValue;
                }
                else if (value.ZValue != (float)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x0036D9C7])
                    Data.Add(0x0036D9C7, value.ZValue);
            }
        }
        
        public bool DisableReset
        {
            get
            {
                if (Data.ContainsKey(0x41E363AC))
                    return (int)Data[0x41E363AC] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x41E363AC];
            }
            set
            {
                if (Data.ContainsKey(0x41E363AC))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x41E363AC])
                        Data.Remove(0x41E363AC);
                    else
                        Data[0x41E363AC] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x41E363AC])
                    Data.Add(0x41E363AC, value ? 1 : 0);
            }
        }
        public bool EnableFoV
        {
            get
            {
                if (Data.ContainsKey(0x9F02074F))
                    return (int)Data[0x9F02074F] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x9F02074F];
            }
            set
            {
                if (Data.ContainsKey(0x9F02074F))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x9F02074F])
                        Data.Remove(0x9F02074F);
                    else
                        Data[0x9F02074F] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x9F02074F])
                    Data.Add(0x9F02074F, value ? 1 : 0);
            }
        }
        public bool StaticLookOffset
        {
            get
            {
                if (Data.ContainsKey(0x82D5627E))
                    return (int)Data[0x82D5627E] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x82D5627E];
            }
            set
            {
                if (Data.ContainsKey(0x82D5627E))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x82D5627E])
                        Data.Remove(0x82D5627E);
                    else
                        Data[0x82D5627E] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x82D5627E])
                    Data.Add(0x82D5627E, value ? 1 : 0);
            }
        }
        public bool DisableAntiBlur
        {
            get
            {
                if (Data.ContainsKey(0xE2044E84))
                    return (int)Data[0xE2044E84] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xE2044E84];
            }
            set
            {
                if (Data.ContainsKey(0xE2044E84))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xE2044E84])
                        Data.Remove(0xE2044E84);
                    else
                        Data[0xE2044E84] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xE2044E84])
                    Data.Add(0xE2044E84, value ? 1 : 0);
            }
        }
        public bool DisableCollision
        {
            get
            {
                if (Data.ContainsKey(0x521E5C3F))
                    return (int)Data[0x521E5C3F] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x521E5C3F];
            }
            set
            {
                if (Data.ContainsKey(0x521E5C3F))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x521E5C3F])
                        Data.Remove(0x521E5C3F);
                    else
                        Data[0x521E5C3F] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x521E5C3F])
                    Data.Add(0x521E5C3F, value ? 1 : 0);
            }
        }
        public bool DisableFirstPerson
        {
            get
            {
                if (Data.ContainsKey(0xBB74D6C1))
                    return (int)Data[0xBB74D6C1] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBB74D6C1];
            }
            set
            {
                if (Data.ContainsKey(0xBB74D6C1))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBB74D6C1])
                        Data.Remove(0xBB74D6C1);
                    else
                        Data[0xBB74D6C1] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xBB74D6C1])
                    Data.Add(0xBB74D6C1, value ? 1 : 0);
            }
        }
        /// <summary>
        /// Game Flag, only used by g: cameras
        /// </summary>
        public bool GFlagEndErpFrame
        {
            get
            {
                if (Data.ContainsKey(0xDA484167))
                    return (int)Data[0xDA484167] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xDA484167];
            }
            set
            {
                if (Data.ContainsKey(0xDA484167))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xDA484167])
                        Data.Remove(0xDA484167);
                    else
                        Data[0xDA484167] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xDA484167])
                    Data.Add(0xDA484167, value ? 1 : 0);
            }
        }
        /// <summary>
        /// Game Flag, only used by g: cameras
        /// </summary>
        public bool GFlagThrough
        {
            get
            {
                if (Data.ContainsKey(0xED8DD072))
                    return (int)Data[0xED8DD072] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xED8DD072];
            }
            set
            {
                if (Data.ContainsKey(0xED8DD072))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xED8DD072])
                        Data.Remove(0xED8DD072);
                    else
                        Data[0xED8DD072] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0xED8DD072])
                    Data.Add(0xED8DD072, value ? 1 : 0);
            }
        }
        /// <summary>
        /// Game Flag, only used by g: cameras
        /// </summary>
        public int GFlagEndTime
        {
            get
            {
                if (Data.ContainsKey(0x67D981E8))
                    return (int)Data[0x67D981E8];
                else
                    return (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x67D981E8];
            }
            set
            {
                if (Data.ContainsKey(0x67D981E8))
                {
                    if (value == (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x67D981E8])
                        Data.Remove(0x67D981E8);
                    else
                        Data[0x67D981E8] = value;
                }
                else if (value != (int)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x67D981E8])
                    Data.Add(0x67D981E8, value);
            }
        }
        public bool EnableVerticalPanAxis
        {
            get
            {
                if (Data.ContainsKey(0x26C8C3C0))
                    return (int)Data[0x26C8C3C0] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x26C8C3C0];
            }
            set
            {
                if (Data.ContainsKey(0x26C8C3C0))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x26C8C3C0])
                        Data.Remove(0x26C8C3C0);
                    else
                        Data[0x26C8C3C0] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x26C8C3C0])
                    Data.Add(0x26C8C3C0, value ? 1 : 0);
            }
        }
        /// <summary>
        /// Event Flag, only used by e: cameras
        /// </summary>
        public bool EventUseTransitionTime
        {
            get
            {
                if (Data.ContainsKey(0x1BCD52AA))
                    return (int)Data[0x1BCD52AA] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x1BCD52AA];
            }
            set
            {
                if (Data.ContainsKey(0x1BCD52AA))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x1BCD52AA])
                        Data.Remove(0x1BCD52AA);
                    else
                        Data[0x1BCD52AA] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x1BCD52AA])
                    Data.Add(0x1BCD52AA, value ? 1 : 0);
            }
        }
        /// <summary>
        /// Event Flag, only used by e: cameras
        /// </summary>
        public bool EventUseTransitionEndTime
        {
            get
            {
                if (Data.ContainsKey(0x45E50EE5))
                    return (int)Data[0x45E50EE5] > 0;
                else
                    return (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x45E50EE5];
            }
            set
            {
                if (Data.ContainsKey(0x45E50EE5))
                {
                    if (value == (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x45E50EE5])
                        Data.Remove(0x45E50EE5);
                    else
                        Data[0x45E50EE5] = value ? 1 : 0;
                }
                else if (value != (bool)CameraDefaults.Defaults[CameraDefaults.Defaults.ContainsKey(Type) ? Type : "CAM_TYPE_XZ_PARA"].DefaultValues[0x45E50EE5])
                    Data.Add(0x45E50EE5, value ? 1 : 0);
            }
        }


        public static bool operator ==(BCAMEntry Left, BCAMEntry Right) => Left.Equals(Right);
        public static bool operator !=(BCAMEntry Left, BCAMEntry Right) => !Left.Equals(Right);
        /// <summary>
        /// Auto-Generated
        /// </summary>
        /// <param name="obj">Object to compare to</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is BCAMEntry entry &&
                   EqualityComparer<Dictionary<uint, object>>.Default.Equals(Data, entry.Data) &&
                   IsOfCategory(entry.GetCategory()) &&
                   Identification == entry.Identification &&
                   Type == entry.Type &&
                   RotationX == entry.RotationX &&
                   RotationY == entry.RotationY &&
                   RotationZ == entry.RotationZ &&
                   Zoom == entry.Zoom &&
                   FieldOfView == entry.FieldOfView &&
                   TransitionTime == entry.TransitionTime &&
                   TransitionEndTime == entry.TransitionEndTime &&
                   TransitionGroundTime == entry.TransitionGroundTime &&
                   Num1 == entry.Num1 &&
                   Num2 == entry.Num2 &&
                   String == entry.String &&
                   MaxY == entry.MaxY &&
                   MinY == entry.MinY &&
                   GroundMoveDelay == entry.GroundMoveDelay &&
                   AirMoveDelay == entry.AirMoveDelay &&
                   UDown == entry.UDown &&
                   LookOffset == entry.LookOffset &&
                   LookOffsetVertical == entry.LookOffsetVertical &&
                   UpperBorder == entry.UpperBorder &&
                   LowerBorder == entry.LowerBorder &&
                   EventFrames == entry.EventFrames &&
                   EventPriority == entry.EventPriority &&
                   EqualityComparer<Vector3<float>>.Default.Equals(FixPointOffset, entry.FixPointOffset) &&
                   EqualityComparer<Vector3<float>>.Default.Equals(WorldPointOffset, entry.WorldPointOffset) &&
                   EqualityComparer<Vector3<float>>.Default.Equals(PlayerOffset, entry.PlayerOffset) &&
                   EqualityComparer<Vector3<float>>.Default.Equals(VerticalPanAxis, entry.VerticalPanAxis) &&
                   EqualityComparer<Vector3<float>>.Default.Equals(UpAxis, entry.UpAxis) &&
                   DisableReset == entry.DisableReset &&
                   EnableFoV == entry.EnableFoV &&
                   StaticLookOffset == entry.StaticLookOffset &&
                   DisableAntiBlur == entry.DisableAntiBlur &&
                   DisableCollision == entry.DisableCollision &&
                   DisableFirstPerson == entry.DisableFirstPerson &&
                   GFlagEndErpFrame == entry.GFlagEndErpFrame &&
                   GFlagThrough == entry.GFlagThrough &&
                   GFlagEndTime == entry.GFlagEndTime &&
                   EnableVerticalPanAxis == entry.EnableVerticalPanAxis &&
                   EventUseTransitionTime == entry.EventUseTransitionTime &&
                   EventUseTransitionEndTime == entry.EventUseTransitionEndTime;
        }
        /// <summary>
        /// Auto-Generated
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = 1520949657;
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<uint, object>>.Default.GetHashCode(Data);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Identification);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + RotationX.GetHashCode();
            hashCode = hashCode * -1521134295 + RotationY.GetHashCode();
            hashCode = hashCode * -1521134295 + RotationZ.GetHashCode();
            hashCode = hashCode * -1521134295 + Zoom.GetHashCode();
            hashCode = hashCode * -1521134295 + FieldOfView.GetHashCode();
            hashCode = hashCode * -1521134295 + TransitionTime.GetHashCode();
            hashCode = hashCode * -1521134295 + TransitionEndTime.GetHashCode();
            hashCode = hashCode * -1521134295 + TransitionGroundTime.GetHashCode();
            hashCode = hashCode * -1521134295 + Num1.GetHashCode();
            hashCode = hashCode * -1521134295 + Num2.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(String);
            hashCode = hashCode * -1521134295 + MaxY.GetHashCode();
            hashCode = hashCode * -1521134295 + MinY.GetHashCode();
            hashCode = hashCode * -1521134295 + GroundMoveDelay.GetHashCode();
            hashCode = hashCode * -1521134295 + AirMoveDelay.GetHashCode();
            hashCode = hashCode * -1521134295 + UDown.GetHashCode();
            hashCode = hashCode * -1521134295 + LookOffset.GetHashCode();
            hashCode = hashCode * -1521134295 + LookOffsetVertical.GetHashCode();
            hashCode = hashCode * -1521134295 + UpperBorder.GetHashCode();
            hashCode = hashCode * -1521134295 + LowerBorder.GetHashCode();
            hashCode = hashCode * -1521134295 + EventFrames.GetHashCode();
            hashCode = hashCode * -1521134295 + EventPriority.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Vector3<float>>.Default.GetHashCode(FixPointOffset);
            hashCode = hashCode * -1521134295 + EqualityComparer<Vector3<float>>.Default.GetHashCode(WorldPointOffset);
            hashCode = hashCode * -1521134295 + EqualityComparer<Vector3<float>>.Default.GetHashCode(PlayerOffset);
            hashCode = hashCode * -1521134295 + EqualityComparer<Vector3<float>>.Default.GetHashCode(VerticalPanAxis);
            hashCode = hashCode * -1521134295 + EqualityComparer<Vector3<float>>.Default.GetHashCode(UpAxis);
            hashCode = hashCode * -1521134295 + DisableReset.GetHashCode();
            hashCode = hashCode * -1521134295 + EnableFoV.GetHashCode();
            hashCode = hashCode * -1521134295 + StaticLookOffset.GetHashCode();
            hashCode = hashCode * -1521134295 + DisableAntiBlur.GetHashCode();
            hashCode = hashCode * -1521134295 + DisableCollision.GetHashCode();
            hashCode = hashCode * -1521134295 + DisableFirstPerson.GetHashCode();
            hashCode = hashCode * -1521134295 + GFlagEndErpFrame.GetHashCode();
            hashCode = hashCode * -1521134295 + GFlagThrough.GetHashCode();
            hashCode = hashCode * -1521134295 + GFlagEndTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EnableVerticalPanAxis.GetHashCode();
            hashCode = hashCode * -1521134295 + EventUseTransitionTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EventUseTransitionEndTime.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// Identification - Data: DataCount
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Identification + " - Data: " + Data.Count;
    }

    public enum DataTypes : byte
    {
        INT32 = 0,
        UNKNOWN = 1,
        FLOAT = 2,
        UINT32 = 3,
        INT16 = 4,
        BYTE = 5,
        STRING = 6,
        NULL = 7
    }

    public static class BCAMEx
    {
        public static string GetTranslatedName(this BCAMEntry entry)
        {
            string Final = "";
            string Original = entry.Data[0x00000D1B].ToString();
            if (Original.StartsWith("c:"))
            {
                if (short.TryParse(Original.Split(':')[1], System.Globalization.NumberStyles.HexNumber, null, out short result))
                {
                    Final += $"Camera Area {(Settings.Default.IsUseHexID ? result.ToString("X").PadLeft(Settings.Default.IsUseLongID ? 4:0, '0') : result.ToString().PadLeft(Settings.Default.IsUseLongID ? 4 : 0, '0'))}";
                }
                else
                {
                    Final = Original.Replace("c:", "Camera Area ");
                }
            }
            else if (Original.StartsWith("s:"))
            {
                if (short.TryParse(Original.Split(':')[1], System.Globalization.NumberStyles.HexNumber, null, out short result))
                {
                    Final += $"Spawn Point {(Settings.Default.IsUseHexID ? result.ToString("X").PadLeft(Settings.Default.IsUseLongID ? 4 : 0, '0') : result.ToString().PadLeft(Settings.Default.IsUseLongID ? 4 : 0, '0'))}";
                }
                else
                {
                    Final = Original.Replace("s:", "Spawn Point ");
                }
            }
            else if (Original.StartsWith("e:"))
            {
                string val = Original.Replace('[', '<').Replace(']', '>'); //Regex is so dumb
                Match m = Regex.Match(val, @"^e:\S+?<\S+?>$", RegexOptions.IgnoreCase);
                if (m.Success)
                    Final += "Demo: "+Original.Replace("e:","");
                else
                { 
                    string targetkey = string.Concat(Original.Split(':')[1].Where(IsNonDigit));
                    Final += Events.ContainsKey(targetkey) ? "Event: "+Original.Substring(2).Replace(targetkey, Events[targetkey]+" ").Replace("番目", "th") : Original;
                }
            }
            else if (Original.StartsWith("o:"))
            {
                if (OtherEvents.ContainsKey(Original.Split(':')[1]))
                    Final += "Other: " + OtherEvents[Original.Split(':')[1]];
                else
                    Final = Original.Replace("o:", "Other: ");
            }
            else if (Original.StartsWith("g:"))
            {
                Final = Original.Replace("g:", "Group: ");
            }
            else
                Final = "Invalid ID";

            return Final;
        }
        public static bool TryGetEventKey(this BCAMEntry entry, out string TargetKey)
        {
            try
            {
                TargetKey = string.Concat(entry.Identification.Split(':')[1].Where(IsNonDigit));
            }
            catch (Exception)
            {
                TargetKey = "";
                return false;
            }
            return true;
        }
        public static bool TryGetEventNum(this BCAMEntry entry, out int ID)
        {
            ID = 0;
            string[] IDValues = entry.Identification.Split(':');
            string TargetNo = string.Concat(IDValues.Length == 4 ? IDValues[2].Where(char.IsDigit): IDValues[1].Where(char.IsDigit));
            if (TargetNo.Length > 0 && int.TryParse(TargetNo, out ID))
            {
                return true;
            }
            return false;
        }
        public static int GetEventNum(this BCAMEntry entry)
        {
            if (entry.TryGetEventNum(out int ID))
                return ID;
            else
                return -1;
        }
        public static bool TryGetCameraNum(this BCAMEntry entry, out short ID) => short.TryParse(entry.Identification.Split(':')[1], out ID);
        public static short GetCameraNum(this BCAMEntry entry)
        {
            if (entry.TryGetCameraNum(out short ID))
                return ID;
            else
                return -1;
        }

        public static bool IsNonDigit(char c) => !(c >= 0x30 && c <= 0x39);

        public static string RemoveDigits(this string str) => string.Concat(str.Where(IsNonDigit));
        
        public static float RefineAngle(this float angle)
        {
            if (angle < -3.14159f)
                while (angle < -3.14159f)
                    angle += 6.28319f;
            else if (angle > 3.14159f)
                while (angle > 3.14159f)
                    angle -= 6.28319f;
            return angle;
        }
        /// <summary>
        /// Converts a Radian to a Degree
        /// </summary>
        /// <param name="angle">Radian angle</param>
        /// <returns>Degree Angle</returns>
        public static float RadianToDegree(this float angle)
        {
            return (float)(angle * (180.0 / Math.PI));
        }
        /// <summary>
        /// Converts a Degree to a Radian
        /// </summary>
        /// <param name="angle">Degree Angle</param>
        /// <returns>Radian Angle</returns>
        public static float DegreeToRadian(this float angle)
        {
            return (float)(Math.PI * angle / 180.0);
        }

        public static int ToInt32(this BitArray array)
        {
            if (array.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] Finalarray = new int[1];
            array.CopyTo(Finalarray, 0);
            return Finalarray[0];
        }

        /// <summary>
        /// e: cameras
        /// </summary>
        public static Dictionary<string, EventData> Events = new Dictionary<string, EventData>()
        {
            { "シナリオスターター", new EventData("Scenario Starter", true, true) },
            { "スーパースピンドライバー固有出現イベント用", new EventData("Launch Star Appearance", true, false) },
            { "スーパースピンドライバー", new EventData("Launch Star", true, true) },
            { "スピンドライバ固有出現イベント用", new EventData("Sling Star Appearance", true, false) },
            { "スピンドライバ", new EventData("Sling Star", true, true) },
            { "グリーンスーパースピンドライバー固有出現イベント用", new EventData("Green Launch Star Appearance", true, false) },
            { "グリーンスーパースピンドライバー", new EventData("Green Launch Star", true, true)},
            { "ピンクスーパースピンドライバー固有出現イベント用", new EventData("Pink Launch Star Appearance", true, false) },
            { "ピンクスーパースピンドライバー", new EventData("Pink Launch Star", true, true)},
            { "Gキャプチャーターゲット固有", new EventData("Pull Star Appearance", true, false) },
            { "グランドスター固有", new EventData("Grand Star Appearance", true, false) },
            { "パワースター固有", new EventData("Power Star Appearance", true, false) },
            { "グリーンスター固有", new EventData("Green Star Appearance", true, false) },
            { "パワースター出現ポイント固有", new EventData("Power Star Appear Point", true, false) },
            { "チコ集め固有集めデモカメラ", new EventData("Silver Star Completion", true, false) },
            { "簡易デモ実行固有簡易デモ", new EventData("Simple Demo Executor", true, false) },
            { "鍵スイッチ固有", new EventData("Key Switch Appearence", true, false) },
            { "カプセルケージ固有", new EventData("Capsule Cage Opening", true, false) },
            { "ゴロ岩カバー檻固有", new EventData("Capsule Cage (Alt) Opening", true, false) },
            { "土管固有出現", new EventData("Warp Pipe", true, false) },
            { "ウォータープレッシャー固有", new EventData("Bubble Shooter", true, false) },
            { "ポール固有", new EventData("Pole", true, false) },
            { "ポール（２方向）固有", new EventData("Pole 2 Way", true, false) },
            { "ポール（モデル無し）固有", new EventData("Pole (No Model)", true, false) },
            { "ポール（鉄骨）固有", new EventData("Square Pole", true, false) },
            { "ポール(モデル無し鉄骨)固有", new EventData("Square Pole (No Model)", true, false) },
            { "ポール（木Ａ）固有", new EventData("Pole Tree A", true, false) },
            { "ポール（木B）固有", new EventData("Pole Tree B", true, false) },
            { "移動用砲台固有", new EventData("Player Cannon", true, false) },
            { "１ＵＰキノコ固有", new EventData("1-UP Appearence", true, false) },
            { "？コイン固有", new EventData("?-Coin Collection", true, false) },
            { "伸び植物固有出現デモ", new EventData("Sproutle Vine Appearance", true, false) },
            { "伸び植物固有掴まり", new EventData("Sproutle Vine", true, false) },
            { "つるスライダー固有滑り", new EventData("Sprauto Vine", true, false) },
            { "つる花固有掴まり", new EventData("Creeper Plant", true, false) },
            { "空中ブランコ固有", new EventData("Trapeze Vine", true, false) },
            { "音符の妖精固有", new EventData("Note Fairy Appearance", true, false) },
            { "インフェルノジェネレータ固有出現デモカメラ", new EventData("Cosmic Clones Appearance", true, false) },
            { "バネベーゴマン", new EventData("Spring Topman", true, true) },
            { "隠れバネベーゴマン", new EventData("Hiding Spring Topman", true, true) },
            { "モンテ固有", new EventData("Chuckster Pianta", true, false) },
            { "ハラペココインチコ固有飛行", new EventData("Coin Hungry Luma", true, false) },
            { "チューブスライダー固有滑り", new EventData("Tube Slider", true, false) },
            { "チューブスライダー固有飛び出し", new EventData("Tube Slider Exit", true, false) },
            { "プチポーター固有基点でワープイン", new EventData("Minigame Teleporter (Prepare to Warp)", true, false) },
            { "プチポーター固有ワープ点でワープアウト", new EventData("Minigame Teleporter (Arrive at Destination)", true, false) },
            { "プチポーター固有ワープ点でワープイン", new EventData("Minigame Teleporter (Prepare return warp)", true, false) },
            { "プチポーター固有基点でワープアウト", new EventData("Minigame Teleporter (Arrive from returning)", true, false) },

            { "看板固有会話", new EventData("Message: Signboard", true, false) },
            { "でか看板固有会話", new EventData("Message: Big Signboard", true, false) },
            { "ピーチ固有会話", new EventData("Message: Peach", true, false) },
            { "キノピオ固有会話", new EventData("Message: Toad", true, false) },
            { "郵便屋さんキノピオ固有注目会話", new EventData("Message: Mailtoad", true, false) },
            { "銀行屋さんキノピオ固有注目会話", new EventData("Message: Banktoad", true, false) },
            { "ウサギ固有会話", new EventData("Message: Star Bunny", true, false) },
            { "ロゼッタ固有会話", new EventData("Message: Rosalina", true, false) },
            { "マイスター固有会話", new EventData("Message: Lubba", true, false) },
            { "チコ固有会話", new EventData("Message: Luma", true, false) },
            { "でかチコ固有会話", new EventData("Message: Big Luma", true, false) },
            { "ハニークイーン固有会話", new EventData("Message: Queen Bee", true, false) },
            { "ハニービー固有会話", new EventData("Message: Honeybee", true, false) },
            { "ペンギン仙人固有会話", new EventData("Message: Penguin Elder", true, false) },
            { "ペンギンコーチ固有会話", new EventData("Message: Penguin Coach", true, false) },
            { "ペンギン固有会話", new EventData("Message: Penguin", true, false) },
            { "パマタリアン固有会話", new EventData("Message: Gearmo", true, false) },
            { "パマタリアンハンター固有会話", new EventData("Message: Gearmo Hunter", true, false) },
            { "赤ボム兵固有会話", new EventData("Message: Bob-omb Buddy", true, false) },
            { "モンテ固有会話", new EventData("Message: Pianta", true, false) },
            { "ピーチャン固有会話", new EventData("Message: Jibberjay", true, false) },
            { "モック固有会話", new EventData("Message: Whittle", true, false) },
            { "さすらいの遊び人(通常会話)固有会話", new EventData("Message: The Chimp (NPC)", true, false) },


            { "引き戻し", new EventData("Pull Back Area", false, false) },
            { "水上フォロー", new EventData("Water Follow", false, false) },
            { "水中フォロー", new EventData("Underwater Follow", false, false) },
            { "水中プラネット", new EventData("Underwater Planet", false, false) },
            { "フーファイターカメラ", new EventData("Foo Fighter Camera", false, false) },

            { "DemoName[CameraPartName]", new EventData("Demo Camera Template", false, false) }
        };
        /// <summary>
        /// o: cameras
        /// </summary>
        public static Dictionary<string, EventData> OtherEvents = new Dictionary<string, EventData>()
        {
            { "デフォルト水面カメラ", new EventData("Default Water Surface", false, false) },
            { "デフォルト水中カメラ", new EventData("Default Underwater", false, false) },
            { "デフォルトフーファイターカメラ", new EventData("Default Flying Mario", false, false) },
            { "スタートカメラ", new EventData("Default Spawn Point", false, false) },
            { "デフォルトカメラ", new EventData("Default Camera", false, false) }
        };


        private static short CalculateNextValidID(List<short> CurrentShorts)
        {
            CurrentShorts.Sort();
            short target = 0;
            for (int i = 0; i < CurrentShorts.Count; i++)
            {
                if (target != CurrentShorts[i])
                    break;
                target++;
            }
            return target;
        }
        private static int CalculateNextValidID(List<int> CurrentInts)
        {
            CurrentInts.Sort();
            int target = 0;
            for (int i = 0; i < CurrentInts.Count; i++)
            {
                if (target != CurrentInts[i])
                    break;
                target++;
            }
            return target;
        }

        private static List<short> GetSpecificList(string id, BCAM Cameras)
        {
            List<short> CurrentShorts = new List<short>();
            for (int i = 0; i < Cameras.EntryCount; i++)
                if (Cameras[i].Identification.StartsWith($"{id}:") && short.TryParse(Cameras[i].Identification.Split(':')[1], System.Globalization.NumberStyles.HexNumber, null, out short result))
                    CurrentShorts.Add(result);
            return CurrentShorts;
        }
        private static List<int> GetSpecificList(string id, BCAM Cameras, EventData Event)
        {
            List<int> CurrentInts = new List<int>();
            for (int i = 0; i < Cameras.EntryCount; i++)
            {
                if (Cameras[i].Identification.StartsWith($"{id}:"))
                {
                    string ID = string.Concat(Cameras[i].Identification.Split(':')[1].Where(IsNonDigit));
                    if (Event.English.Equals(Events[ID].English))
                    {
                        string[] IDParts = Cameras[i].Identification.Split(':');
                        if (IDParts.Length == 4)
                            ID = string.Concat(Cameras[i].Identification.Split(':')[2]);
                        else
                            ID = string.Concat(Cameras[i].Identification.Replace($"{id}:", "").Where(char.IsNumber));
                        if (int.TryParse(ID, System.Globalization.NumberStyles.HexNumber, null, out int result))
                            CurrentInts.Add(result);
                    }
                }
            }
            return CurrentInts.Count == 0 ? new List<int>() { -1 } : CurrentInts;
        }

        public static short CalculateNextCameraArea(BCAM Cameras) => CalculateNextValidID(GetSpecificList("c", Cameras));
        public static short CalculateNextStart(BCAM Cameras) => CalculateNextValidID(GetSpecificList("s", Cameras));
        public static int CalculateNextEvent(BCAM Cameras, EventData Event) => CalculateNextValidID(GetSpecificList("e", Cameras, Event));

        public static void MoveCamera(this BCAM bcam, int OriginalID, CameraMoveOptions MoveOption)
        {
            int NewPos = OriginalID;
            switch (MoveOption)
            {
                case CameraMoveOptions.UP:
                    if (OriginalID == 0)
                        NewPos = bcam.EntryCount - 1;
                    else
                        NewPos--;
                    break;
                case CameraMoveOptions.DOWN:
                    if (OriginalID == bcam.EntryCount - 1)
                        NewPos = 0;
                    else
                        NewPos++;
                    break;
                case CameraMoveOptions.TOP:
                    NewPos = 0;
                    break;
                case CameraMoveOptions.BOTTOM:
                    NewPos = bcam.EntryCount - 1;
                    break;
            }
            bcam.Entries.Move(OriginalID, NewPos);
        }

        public enum CameraMoveOptions
        {
            /// <summary>
            /// Move up 1
            /// </summary>
            UP,
            /// <summary>
            /// Move down 1
            /// </summary>
            DOWN,
            /// <summary>
            /// Move to the Top
            /// </summary>
            TOP,
            /// <summary>
            /// Move to the Bottom
            /// </summary>
            BOTTOM
        }
    }

    public class EventData
    {
        public string English { get; set; }
        public bool NeedsID { get; set; }
        public bool NeedsSubID { get; set; }

        public EventData()
        {
            English = "Undefined";
            NeedsSubID = false;
        }
        public EventData(string s,bool needsid, bool needssubid)
        {
            English = s;
            NeedsID = needsid;
            NeedsSubID = needssubid;
        }

        public static implicit operator string(EventData x) => x.English;
        public override string ToString() => English;
    }

    public class CameraDefaults
    {
        public static Dictionary<string, CameraDefaults> Defaults = new Dictionary<string, CameraDefaults>()
        {
            //==================================================================================================================================================================
            { "CAM_TYPE_XZ_PARA", new CameraDefaults(196631, 0, 0.2984513f, 0f, 0f, 1200f, 45f, 100, 100, 160, 1, 0, "", 300f, 800f, 120, 120, 120, 0f, 0f, 0.30f, 0.10f, 0, 0,
                new Vector3<float>(0,0,0), new Vector3<float>(0,0,0), new Vector3<float>(0,0,0), new Vector3<float>(0,1,0), new Vector3<float>(0,1,0),
                false, false, false, false, false, false, false, false, 0, true, false, false) },
            //==================================================================================================================================================================
            { "CAM_TYPE_EYEPOS_FIX_THERE", new CameraDefaults(196631, 0, 0.0f, 0f, 0f, 0f, 45f, 100, 100, 160, 1, 0, "", 0f, 0f, 0, 0, 120, 0f, 0f, 0.0f, 0.0f, 0, 0,
                new Vector3<float>(0,0,0), new Vector3<float>(0,0,0), new Vector3<float>(0,0,0), new Vector3<float>(0,0,0), new Vector3<float>(0,1,0),
                false, false, false, false, false, false, false, false, 0, false, false, false) },
            //==================================================================================================================================================================
            { "CAM_TYPE_WONDER_PLANET", new CameraDefaults(196631, 0, 0.0f, 0f, 0f, 0f, 45f, 100, 100, 160, 1, 0, "", 300f, 800f, 120, 120, 120, 0f, 0f, 0.3f, 0.1f, 0, 0,
                new Vector3<float>(0,0,0), new Vector3<float>(0,0,0), new Vector3<float>(0,0,0), new Vector3<float>(0,0,0), new Vector3<float>(0,0,0),
                false, false, false, false, false, false, false, false, 0, false, false, false) },
            //==================================================================================================================================================================
            { "CAM_TYPE_POINT_FIX", new CameraDefaults(196631, 0, 0.0f, 0.0f, 0f, 1200f, 45f, 100, 100, 160, 0, 0, "", 300f, 800f, 120, 120, 120, 0f, 0f, 0.0f, 0.0f, 0, 0,
                new Vector3<float>(0,0,0), new Vector3<float>(0,0,0), new Vector3<float>(0,0.99989913f,0), new Vector3<float>(0,0,0), new Vector3<float>(0,1,0),
                false, false, false, false, false, false, false, false, 0, false, false, false) },
            //==================================================================================================================================================================
        };

        internal CameraDefaults(int version, int number, float XRot, float YRot, float ZRot, float zoom, float fov, int time, int endtime, int gndtime, int num1, int num2, string str, float maxY, float minY,
            int gndmovedelay, int airmovedelay, int udown, float lookoffset, float lookoffsety, float upperborder, float lowerborder, int evframes, int evpriority,
            Vector3<float> fixpointoffset, Vector3<float> worldpointoffset, Vector3<float> playeroffset, Vector3<float> verticalpanaxis, Vector3<float> upaxis,
            bool disablereset, bool enablefov, bool staticlookoffset, bool disableantiblur, bool disablecollision, bool disablefirstperson, bool Gflagenderpframe, bool Gflagthrough, int Gflagendtime,
            bool useverticalpanaxis, bool eventuseendtime, bool eventusetime) => DefaultValues = new Dictionary<uint, object>
            {
                { 0x14F51CD8, version },
                { 0x00000DC1, number },
                { 0xABC4A1CF, XRot },
                { 0xABC4A1CE, YRot },
                { 0x0035807D, ZRot },
                { 0x002F0DA6, zoom },
                { 0x00300D4C, fov },
                { 0xAE79D1C0, time },
                { 0xEB66C5C3, endtime },
                { 0xB6004E72, gndtime },
                { 0x0033C56B, num1 },
                { 0x0033C56C, num2 },
                { 0xCAD56011, str },
                { 0x06A54929, maxY },
                { 0x062675A0, minY },
                { 0xD26F6AA9, gndmovedelay },
                { 0x93AECC0B, airmovedelay },
                { 0x069FE297, udown },
                { 0x145863FF, lookoffset },
                { 0x76B41C57, lookoffsety },
                { 0x06A558A2, upperborder },
                { 0x06262B01, lowerborder },
                { 0x05C676D0, evframes },
                { 0x730D4555, evpriority },

                { 0xBEC02B34, fixpointoffset.XValue },
                { 0xBEC02B35, fixpointoffset.YValue },
                { 0xBEC02B36, fixpointoffset.ZValue },
                { 0x31CB1323, worldpointoffset.XValue },
                { 0x31CB1324, worldpointoffset.YValue },
                { 0x31CB1325, worldpointoffset.ZValue },
                { 0xAC52894B, playeroffset.XValue },
                { 0xAC52894C, playeroffset.YValue },
                { 0xAC52894D, playeroffset.ZValue },
                { 0x3B5CB472, verticalpanaxis.XValue },
                { 0x3B5CB473, verticalpanaxis.YValue },
                { 0x3B5CB474, verticalpanaxis.ZValue },
                { 0x0036D9C5, upaxis.XValue },
                { 0x0036D9C6, upaxis.YValue },
                { 0x0036D9C7, upaxis.ZValue },

                { 0x41E363AC, disablereset },
                { 0x9F02074F, enablefov },
                { 0x82D5627E, staticlookoffset },
                { 0xE2044E84, disableantiblur },
                { 0x521E5C3F, disablecollision },
                { 0xBB74D6C1, disablefirstperson },
                { 0xDA484167, Gflagenderpframe },
                { 0xED8DD072, Gflagthrough },
                { 0x67D981E8, Gflagendtime },
                { 0x26C8C3C0, useverticalpanaxis },
                { 0x45E50EE5, eventusetime },
                { 0x1BCD52AA, eventuseendtime }
            };

        public Dictionary<uint, object> DefaultValues;

        public static Dictionary<uint, DataTypes> DefaultTypes = null;

        public static void InitDataTypeList()
        {
            if (DefaultTypes != null)
                return;

            DefaultTypes = new Dictionary<uint, DataTypes>();
            for (int i = 0; i < BCAM.PreferredHashOrder.Length; i++)
            {
                DefaultTypes.Add(BCAM.PreferredHashOrder[i], BCAM.HashDataTypes[i]);
            }
        }

        public static implicit operator BCAMEntry(CameraDefaults x)
        {
            BCAMEntry output = new BCAMEntry();
            for (int i = 0; i < x.DefaultValues.Count; i++)
            {
                if (x.DefaultValues.ElementAt(i).Value is bool)
                    output.Data.Add(x.DefaultValues.ElementAt(i).Key, (bool)x.DefaultValues.ElementAt(i).Value ? 1 : 0);
                else
                    output.Data.Add(x.DefaultValues.ElementAt(i).Key, x.DefaultValues.ElementAt(i).Value);
            }
            return output;
        }
    }
}
