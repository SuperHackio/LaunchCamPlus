using Hack.io.BCSV;
using Hack.io.Utility;
using System.Text.RegularExpressions;
using static LaunchCamPlus.Formats.BCAMUtility;

namespace LaunchCamPlus.Formats;

public class BCAM : BCSV
{
    #region CAMERA_HASHES
    public const uint HASH_VERSION = 0x14F51CD8;
    public const uint HASH_ID = 0x00000D1B;
    public const uint HASH_CAMTYPE = 0x20C58F89;
    public const uint HASH_STRING = 0xCAD56011;
    public const uint HASH_ANGLEB = 0xABC4A1CF;
    public const uint HASH_ANGLEA = 0xABC4A1CE;
    public const uint HASH_ROLL = 0x0035807D;
    public const uint HASH_DIST = 0x002F0DA6;
    public const uint HASH_FOVY = 0x00300D4C;
    public const uint HASH_CAMINT = 0xAE79D1C0;
    public const uint HASH_CAMENDINT = 0xEB66C5C3;
    public const uint HASH_GNDINT = 0xB6004E72;
    public const uint HASH_NUM1 = 0x0033C56B;
    public const uint HASH_NUM2 = 0x0033C56C;
    public const uint HASH_UPLAY = 0x06A54929;
    public const uint HASH_LPLAY = 0x062675A0;
    public const uint HASH_PUSHDELAY = 0xD26F6AA9;
    public const uint HASH_PUSHDELAYLOW = 0x93AECC0B;
    public const uint HASH_UDOWN = 0x069FE297;
    public const uint HASH_LOFFSET = 0x145863FF;
    public const uint HASH_LOFFSETV = 0x76B41C57;
    public const uint HASH_UPPER = 0x06A558A2;
    public const uint HASH_LOWER = 0x06262B01;
    public const uint HASH_EVFRM = 0x05C676D0;
    public const uint HASH_EVPRIORITY = 0x730D4555;
    public const uint HASH_WOFFSET_X = 0xBEC02B34;
    public const uint HASH_WOFFSET_Y = 0xBEC02B35;
    public const uint HASH_WOFFSET_Z = 0xBEC02B36;
    public const uint HASH_WPOINT_X = 0x31CB1323;
    public const uint HASH_WPOINT_Y = 0x31CB1324;
    public const uint HASH_WPOINT_Z = 0x31CB1325;
    public const uint HASH_AXIS_X = 0xAC52894B;
    public const uint HASH_AXIS_Y = 0xAC52894C;
    public const uint HASH_AXIS_Z = 0xAC52894D;
    public const uint HASH_VPANAXIS_X = 0x3B5CB472;
    public const uint HASH_VPANAXIS_Y = 0x3B5CB473;
    public const uint HASH_VPANAXIS_Z = 0x3B5CB474;
    public const uint HASH_UP_X = 0x0036D9C5;
    public const uint HASH_UP_Y = 0x0036D9C6;
    public const uint HASH_UP_Z = 0x0036D9C7;
    public const uint HASH_FLAG_NORESET = 0x41E363AC;
    public const uint HASH_FLAG_NOFOVY = 0x9F02074F;
    public const uint HASH_FLAG_LOFSERPOFF = 0x82D5627E;
    public const uint HASH_FLAG_ANTIBLUROFF = 0xE2044E84;
    public const uint HASH_FLAG_COLLISIONOFF = 0x521E5C3F;
    public const uint HASH_FLAG_SUBJECTIVEOFF = 0xBB74D6C1;
    public const uint HASH_GFLAG_ENABLEENDERPFRAME = 0xDA484167;
    public const uint HASH_GFLAG_THRU = 0xED8DD072;
    public const uint HASH_GFLAG_CAMENDINT = 0x67D981E8;
    public const uint HASH_VPANUSE = 0x26C8C3C0;
    public const uint HASH_EFLAG_ENABLEENDERPFRAME = 0x45E50EE5;
    public const uint HASH_EFLAG_ENABLEERPFRAME = 0x1BCD52AA;
    #endregion

    /// <summary>
    /// Gets or sets the BCSV.Entry at the specified index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public new Entry this[int index]
    {
        get => (Entry)base[index];
        set => base[index] = value;
    }

    public BCAM()
    {
        AddRange(PreMadeFields);
    }

    protected override Entry CreateEntry() => new();

    public int IndexOf(Entry entry)
    {
        for (int i = 0; i < Entries.Count; i++)
        {
            if (ReferenceEquals(Entries[i], entry))
                return i;
        }
        return -1;
    }

    public override void Load(Stream Strm)
    {
        base.Load(Strm);
        for (int i = 0; i < PreMadeFields.Count; i++)
        {
            Field f = PreMadeFields[i];
            if (!ContainsField(f.HashName))
                Fields.Add(f.HashName, f);
        }
    }

    public void OrderBy(Func<BCSV.Entry, object> keySelector) => Entries = [.. Entries.OrderBy(keySelector)];

    public void MoveCamera(int OriginalID, CameraMoveOptions MoveOption)
    {
        int NewPos = OriginalID;
        switch (MoveOption)
        {
            case CameraMoveOptions.UP:
                if (OriginalID == 0)
                    NewPos = EntryCount - 1;
                else
                    NewPos--;
                break;
            case CameraMoveOptions.DOWN:
                if (OriginalID == EntryCount - 1)
                    NewPos = 0;
                else
                    NewPos++;
                break;
            case CameraMoveOptions.TOP:
                NewPos = 0;
                break;
            case CameraMoveOptions.BOTTOM:
                NewPos = EntryCount - 1;
                break;
        }
        Entries.Move(OriginalID, NewPos);
    }

    public void Optimize(IReadOnlyList<uint> Hashes)
    {
        Fields.Clear();
        for (int i = 0; i < Hashes.Count; i++)
        {
            int index = Array.IndexOf(PreferredHashOrder, Hashes[i]);
            Field f = PreMadeFields[index];
            Fields.Add(f.HashName, f);
        }
    }

    public new class Entry : BCSV.Entry
    {
        public const string CLIPBOARD_HEAD = "LCP";

        #region PROPERTIES
        /// <summary>
        /// The version of the camera engine to run on
        /// </summary>
        public int Version
        {
            get => (int)GetDataOrCamTypeDefault(HASH_VERSION);
            set => SetData(HASH_VERSION, value);
        }
        /// <summary>
        /// The camera Identification that links it to objects in-game
        /// </summary>
        public string Identification
        {
            get => Data.TryGetValue(HASH_ID, out object? value) ? (string)(value ?? "<UNSET>") : "<MISSING>";
            set => SetData(HASH_ID, value);
        }
        /// <summary>
        /// The Camera Type
        /// </summary>
        public string Type
        {
            get => Data.TryGetValue(HASH_CAMTYPE, out object? value) ? (string)(value ?? "CAM_TYPE_XZ_PARA") : "CAM_TYPE_XZ_PARA";
            set => SetData(HASH_CAMTYPE, value);
        }

        public float AngleB
        {
            get => (float)GetDataOrCamTypeDefault(HASH_ANGLEB);
            set => SetData(HASH_ANGLEB, value);
        }

        public float AngleA
        {
            get => (float)GetDataOrCamTypeDefault(HASH_ANGLEA);
            set => SetData(HASH_ANGLEA, value);
        }

        public float Roll
        {
            get => (float)GetDataOrCamTypeDefault(HASH_ROLL);
            set => SetData(HASH_ROLL, value);
        }

        public float Dist
        {
            get => (float)GetDataOrCamTypeDefault(HASH_DIST);
            set => SetData(HASH_DIST, value);
        }
        public float FieldOfViewY
        {
            get => (float)GetDataOrCamTypeDefault(HASH_FOVY);
            set => SetData(HASH_FOVY, value);
        }

        public int CamInt
        {
            get => (int)GetDataOrCamTypeDefault(HASH_CAMINT);
            set => SetData(HASH_CAMINT, value);
        }
        /// <summary>
        /// Event value, only used by e: cameras
        /// </summary>
        public int CamEndInt
        {
            get => (int)GetDataOrCamTypeDefault(HASH_CAMENDINT);
            set => SetData(HASH_CAMENDINT, value);
        }
        public int GndInt
        {
            get => (int)GetDataOrCamTypeDefault(HASH_GNDINT);
            set => SetData(HASH_GNDINT, value);
        }

        public int Num1
        {
            get => (int)GetDataOrCamTypeDefault(HASH_NUM1);
            set => SetData(HASH_NUM1, value);
        }
        public int Num2
        {
            get => (int)GetDataOrCamTypeDefault(HASH_NUM2);
            set => SetData(HASH_NUM2, value);
        }
        public string String
        {
            get => (string)GetDataOrCamTypeDefault(HASH_STRING);
            set => SetData(HASH_STRING, value);
        }

        public float UPlay
        {
            get => (float)GetDataOrCamTypeDefault(HASH_UPLAY);
            set => SetData(HASH_UPLAY, value);
        }
        public float LPlay
        {
            get => (float)GetDataOrCamTypeDefault(HASH_LPLAY);
            set => SetData(HASH_LPLAY, value);
        }

        public int PushDelay
        {
            get => (int)GetDataOrCamTypeDefault(HASH_PUSHDELAY);
            set => SetData(HASH_PUSHDELAY, value);
        }
        public int PushDelayLow
        {
            get => (int)GetDataOrCamTypeDefault(HASH_PUSHDELAYLOW);
            set => SetData(HASH_PUSHDELAYLOW, value);
        }
        public int UDown
        {
            get => (int)GetDataOrCamTypeDefault(HASH_UDOWN);
            set => SetData(HASH_UDOWN, value);
        }

        public float LookOffset
        {
            get => (float)GetDataOrCamTypeDefault(HASH_LOFFSET);
            set => SetData(HASH_LOFFSET, value);
        }
        public float LookOffsetVertical
        {
            get => (float)GetDataOrCamTypeDefault(HASH_LOFFSETV);
            set => SetData(HASH_LOFFSETV, value);
        }
        public float UpperBorder
        {
            get => (float)GetDataOrCamTypeDefault(HASH_UPPER);
            set => SetData(HASH_UPPER, value);
        }
        public float LowerBorder
        {
            get => (float)GetDataOrCamTypeDefault(HASH_LOWER);
            set => SetData(HASH_LOWER, value);
        }

        /// <summary>
        /// Event value, only used by e: cameras
        /// </summary>
        public int EventFrames
        {
            get => (int)GetDataOrCamTypeDefault(HASH_EVFRM);
            set => SetData(HASH_EVFRM, value);
        }
        /// <summary>
        /// Event value, only used by e: cameras
        /// </summary>
        public int EventPriority
        {
            get => (int)GetDataOrCamTypeDefault(HASH_EVPRIORITY);
            set => SetData(HASH_EVPRIORITY, value);
        }

        public Vector3<float> WOffset
        {
            get => new(WOffsetX, WOffsetY, WOffsetZ);
            set
            {
                WOffsetX = value.XValue;
                WOffsetY = value.YValue;
                WOffsetZ = value.ZValue;
            }
        }
        public float WOffsetX
        {
            get => (float)GetDataOrCamTypeDefault(HASH_WOFFSET_X);
            set => SetData(HASH_WOFFSET_X, value);
        }
        public float WOffsetY
        {
            get => (float)GetDataOrCamTypeDefault(HASH_WOFFSET_Y);
            set => SetData(HASH_WOFFSET_Y, value);
        }
        public float WOffsetZ
        {
            get => (float)GetDataOrCamTypeDefault(HASH_WOFFSET_Z);
            set => SetData(HASH_WOFFSET_Z, value);
        }

        public Vector3<float> WPoint
        {
            get => new(WPointX, WPointY, WPointZ);
            set
            {
                WPointX = value.XValue;
                WPointY = value.YValue;
                WPointZ = value.ZValue;
            }
        }
        public float WPointX
        {
            get => (float)GetDataOrCamTypeDefault(HASH_WPOINT_X);
            set => SetData(HASH_WPOINT_X, value);
        }
        public float WPointY
        {
            get => (float)GetDataOrCamTypeDefault(HASH_WPOINT_Y);
            set => SetData(HASH_WPOINT_Y, value);
        }
        public float WPointZ
        {
            get => (float)GetDataOrCamTypeDefault(HASH_WPOINT_Z);
            set => SetData(HASH_WPOINT_Z, value);
        }

        public Vector3<float> Axis
        {
            get => new(AxisX, AxisY, AxisZ);
            set
            {
                AxisX = value.XValue;
                AxisY = value.YValue;
                AxisZ = value.ZValue;
            }
        }
        public float AxisX
        {
            get => (float)GetDataOrCamTypeDefault(HASH_AXIS_X);
            set => SetData(HASH_AXIS_X, value);
        }
        public float AxisY
        {
            get => (float)GetDataOrCamTypeDefault(HASH_AXIS_Y);
            set => SetData(HASH_AXIS_Y, value);
        }
        public float AxisZ
        {
            get => (float)GetDataOrCamTypeDefault(HASH_AXIS_Z);
            set => SetData(HASH_AXIS_Z, value);
        }

        public Vector3<float> VerticalPanAxis
        {
            get => new(VPanAxisX, VPanAxisY, VPanAxisZ);
            set
            {
                VPanAxisX = value.XValue;
                VPanAxisY = value.YValue;
                VPanAxisZ = value.ZValue;
            }
        }
        public float VPanAxisX
        {
            get => (float)GetDataOrCamTypeDefault(HASH_VPANAXIS_X);
            set => SetData(HASH_VPANAXIS_X, value);
        }
        public float VPanAxisY
        {
            get => (float)GetDataOrCamTypeDefault(HASH_VPANAXIS_Y);
            set => SetData(HASH_VPANAXIS_Y, value);
        }
        public float VPanAxisZ
        {
            get => (float)GetDataOrCamTypeDefault(HASH_VPANAXIS_Z);
            set => SetData(HASH_VPANAXIS_Z, value);
        }

        public Vector3<float> Up
        {
            get => new(UpX, UpY, UpZ);
            set
            {
                UpX = value.XValue;
                UpY = value.YValue;
                UpZ = value.ZValue;
            }
        }
        public float UpX
        {
            get => (float)GetDataOrCamTypeDefault(HASH_UP_X);
            set => SetData(HASH_UP_X, value);
        }
        public float UpY
        {
            get => (float)GetDataOrCamTypeDefault(HASH_UP_Y);
            set => SetData(HASH_UP_Y, value);
        }
        public float UpZ
        {
            get => (float)GetDataOrCamTypeDefault(HASH_UP_Z);
            set => SetData(HASH_UP_Z, value);
        }

        public int NoReset
        {
            get => (int)GetDataOrCamTypeDefault(HASH_FLAG_NORESET);
            set => SetData(HASH_FLAG_NORESET, value);
        }
        public int NoFieldOfViewY
        {
            get => (int)GetDataOrCamTypeDefault(HASH_FLAG_NOFOVY);
            set => SetData(HASH_FLAG_NOFOVY, value);
        }
        public int LookOffsetErpOff
        {
            get => (int)GetDataOrCamTypeDefault(HASH_FLAG_LOFSERPOFF);
            set => SetData(HASH_FLAG_LOFSERPOFF, value);
        }
        public int AntiBlurOff
        {
            get => (int)GetDataOrCamTypeDefault(HASH_FLAG_ANTIBLUROFF);
            set => SetData(HASH_FLAG_ANTIBLUROFF, value);
        }
        public int CollisionOff
        {
            get => (int)GetDataOrCamTypeDefault(HASH_FLAG_COLLISIONOFF);
            set => SetData(HASH_FLAG_COLLISIONOFF, value);
        }
        public int SubjectiveOff
        {
            get => (int)GetDataOrCamTypeDefault(HASH_FLAG_SUBJECTIVEOFF);
            set => SetData(HASH_FLAG_SUBJECTIVEOFF, value);
        }

        public int GFlagEndErpFrame
        {
            get => (int)GetDataOrCamTypeDefault(HASH_GFLAG_ENABLEENDERPFRAME);
            set => SetData(HASH_GFLAG_ENABLEENDERPFRAME, value);
        }

        public int GFlagThrough
        {
            get => (int)GetDataOrCamTypeDefault(HASH_GFLAG_THRU);
            set => SetData(HASH_GFLAG_THRU, value);
        }

        public int GFlagEndTime
        {
            get => (int)GetDataOrCamTypeDefault(HASH_GFLAG_CAMENDINT);
            set => SetData(HASH_GFLAG_CAMENDINT, value);
        }
        public int VPanAxisUse
        {
            get => (int)GetDataOrCamTypeDefault(HASH_VPANUSE);
            set => SetData(HASH_VPANUSE, value);
        }
        /// <summary>
        /// Event Flag, only used by e: cameras
        /// </summary>
        public int EventUseTransitionTime
        {
            get => (int)GetDataOrCamTypeDefault(HASH_EFLAG_ENABLEERPFRAME);
            set => SetData(HASH_EFLAG_ENABLEERPFRAME, value);
        }
        /// <summary>
        /// Event Flag, only used by e: cameras
        /// </summary>
        public int EventUseTransitionEndTime
        {
            get => (int)GetDataOrCamTypeDefault(HASH_EFLAG_ENABLEENDERPFRAME);
            set => SetData(HASH_EFLAG_ENABLEENDERPFRAME, value);
        }
        #endregion

        public uint[] ContainedHashes => [.. Data.Keys];

        public Entry()
        {
        }

        public object GetDataOrCamTypeDefault(uint Hash)
        {
            if (Data.TryGetValue(Hash, out object? obj) && obj is not null)
                return obj;

#pragma warning disable CS8603 // Possible null reference return.
            return GetDefaultValue(Hash);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public static object? GetDefaultValue(uint Hash)
        {
            if (DEFAULT_CAMERA_SETTINGS.TryGetValue(Hash, out Dictionary<uint, object>? DefaultSettings) && DefaultSettings != null)
            {
                int DEFAULTS_VERSION = Program.Settings.IsUseSMG1Defaults ? DEFAULT_VERSION_SMG1 : DEFAULT_VERSION_SMG2;
                if (DefaultSettings.TryGetValue((uint)DEFAULTS_VERSION, out object? value) && value != null)
                    return value;
                return DefaultSettings[0];
            }
            return null;
        }

        private void SetData(uint Hash, object valueToSet)
        {
            object? DEFAULT_VALUE = GetDefaultValue(Hash);
            if (!Data.TryAdd(Hash, valueToSet))
            {
                if (DEFAULT_VALUE is not null && valueToSet.Equals(DEFAULT_VALUE) && Hash != HASH_VERSION && Hash != HASH_ID && Hash != HASH_CAMTYPE)
                    Data.Remove(Hash);
                else
                    Data[Hash] = valueToSet;
            }
        }

        public void OptimizeForCamType()
        {
            for (int i = 0; i < PreferredHashOrder.Length; i++)
            {
                switch (HashDataTypes[i])
                {
                    case DataTypes.INT32:
                        CalcInt32(PreferredHashOrder[i]);
                        break;
                    case DataTypes.FLOAT:
                        CalcSingle(PreferredHashOrder[i]);
                        break;
                    case DataTypes.STRING:
                        CalcString(PreferredHashOrder[i]);
                        break;
                    default:
                        throw new Exception();
                }
            }

            //Verify that all Vectors have all their X, Y, and Z fields present.
            VerifyVector(BCAM.HASH_WOFFSET_X, BCAM.HASH_WOFFSET_Y, BCAM.HASH_WOFFSET_Z);
            VerifyVector(BCAM.HASH_WPOINT_X, BCAM.HASH_WPOINT_Y, BCAM.HASH_WPOINT_Z);
            VerifyVector(BCAM.HASH_AXIS_X, BCAM.HASH_AXIS_Y, BCAM.HASH_AXIS_Z);
            VerifyVector(BCAM.HASH_VPANAXIS_X, BCAM.HASH_VPANAXIS_Y, BCAM.HASH_VPANAXIS_Z);
            VerifyVector(BCAM.HASH_UP_X, BCAM.HASH_UP_Y, BCAM.HASH_UP_Z);


            void CalcInt32(uint Hash)
            {
                if (Data.ContainsKey(Hash))
                    SetData(Hash, (int)GetDataOrCamTypeDefault(Hash));
            }
            void CalcSingle(uint Hash)
            {
                if (Data.ContainsKey(Hash))
                    SetData(Hash, (float)GetDataOrCamTypeDefault(Hash));
            }
            void CalcString(uint Hash)
            {
                if (Data.ContainsKey(Hash))
                    SetData(Hash, (string)GetDataOrCamTypeDefault(Hash));
            }

            void VerifyVector(uint XHash, uint YHash, uint ZHash)
            {
                bool HasX = Data.ContainsKey(XHash);
                bool HasY = Data.ContainsKey(YHash);
                bool HasZ = Data.ContainsKey(ZHash);
                if (!HasX && !HasY && !HasZ)
                    return;

                if (!HasX)
                    SetData(XHash, (float)GetDataOrCamTypeDefault(XHash));
                if (!HasY)
                    SetData(YHash, (float)GetDataOrCamTypeDefault(YHash));
                if (!HasZ)
                    SetData(ZHash, (float)GetDataOrCamTypeDefault(ZHash));
            }
        }
    
        public static Entry CreateDefaultCamera()
        {
            Entry result = new()
            {
                Version = Program.Settings.IsUseSMG1Defaults ? DEFAULT_VERSION_SMG1 : DEFAULT_VERSION_SMG2
            };
            for (int i = 0; i < PreferredHashOrder.Length; i++)
            {
                object? defaultvalue = GetDefaultValue(PreferredHashOrder[i]);
                if (defaultvalue is not null)
                    result.SetData(PreferredHashOrder[i], defaultvalue);
            }
            return result;
        }
    
        public static Entry CloneCameraFull(Entry source)
        {
            Entry result = new();
            for (int i = 0; i < PreferredHashOrder.Length; i++)
            {
                if (source.Data.TryGetValue(PreferredHashOrder[i], out object? v))
                {
                    result.TryAdd(PreferredHashOrder[i], v);
                }
                else
                {
                    object? defaultvalue = GetDefaultValue(PreferredHashOrder[i]);
                    if (defaultvalue is not null)
                        result.SetData(PreferredHashOrder[i], defaultvalue);
                }
            }
            return result;
        }
    }

    public static readonly uint[] PreferredHashOrder = [
        #region General
        HASH_VERSION, //Version
        HASH_ID, //ID
        HASH_CAMTYPE, //Type

        HASH_STRING, //string
        HASH_ANGLEB, //RotationX
        HASH_ANGLEA, //RotationY
        HASH_ROLL, //RotationZ
        HASH_DIST, //Zoom
        HASH_FOVY, //Field of View
        HASH_CAMINT, //Transition Time
        HASH_CAMENDINT, //End Transition Time
        HASH_GNDINT, //Ground Speed.....Does literally nothing. Only different in like, 8 files between both games.
        HASH_NUM1, //num1 [Various things]
        HASH_NUM2, //num2 [Various things]
        HASH_UPLAY, //MaxY
        HASH_LPLAY, //MinY
        HASH_PUSHDELAY, //GroundStarMoveDelay
        HASH_PUSHDELAYLOW, //AirStartMoveDelay
        HASH_UDOWN, //udown...does literally nothing...?
        HASH_LOFFSET, //Front Zoom
        HASH_LOFFSETV , //Height Zoom
        HASH_UPPER, //Upper Border
        HASH_LOWER, //Lower Border
        HASH_EVFRM, //Event Frames
        HASH_EVPRIORITY, //Event Priority
        #endregion

        #region Coordinates
        HASH_WOFFSET_X, //Fixpoint Offset X
        HASH_WOFFSET_Y, //Fixpoint Offset Y
        HASH_WOFFSET_Z, //Fixpoint Offset Z
        //--------------------------------------------------------------------------------------------------
        HASH_WPOINT_X, //Worldpoint Offset X
        HASH_WPOINT_Y, //Worldpoint Offset Y
        HASH_WPOINT_Z, //Worldpoint Offset Z
        //--------------------------------------------------------------------------------------------------
        HASH_AXIS_X, //Player Offset X
        HASH_AXIS_Y, //Player Offset Y
        HASH_AXIS_Z, //Player Offset Z
        //--------------------------------------------------------------------------------------------------
        HASH_VPANAXIS_X, //Verticle Pan Axis X
        HASH_VPANAXIS_Y, //Verticle Pan Axis Y
        HASH_VPANAXIS_Z, //Verticle Pan Axis Z
        //--------------------------------------------------------------------------------------------------
        HASH_UP_X, //Up Axis X
        HASH_UP_Y, //Up Axis Y
        HASH_UP_Z, //Up Axis Z
        #endregion

        #region Flags
        HASH_FLAG_NORESET, //DisableReset
        HASH_FLAG_NOFOVY, //Enable Field of View
        HASH_FLAG_LOFSERPOFF, //Enable Sharp Zoom
        HASH_FLAG_ANTIBLUROFF, //Disable Anti-blur
        HASH_FLAG_COLLISIONOFF, //Disable Collision
        HASH_FLAG_SUBJECTIVEOFF, //Disable First Person
        HASH_GFLAG_ENABLEENDERPFRAME, //GroupFlagEndErpFrame
        HASH_GFLAG_THRU, //GroupFlagThrough
        HASH_GFLAG_CAMENDINT, //GroupFlagEndTransitionSpeed
        HASH_VPANUSE, //Use Verticle Pan Axis
        HASH_EFLAG_ENABLEENDERPFRAME, //Event Use Transition
        HASH_EFLAG_ENABLEERPFRAME //Event Use End Transition
        #endregion
    ];
    private static readonly DataTypes[] HashDataTypes = [
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
        ];
    private static List<Field>? mPreMadeFields = null;
    private static List<Field> PreMadeFields
    {
        get
        {
            //Initially I was going to cache this
            //But that ended up breaking things so I made it regenerate it each time...
            //if (mPreMadeFields is null)
            {
                mPreMadeFields = [];
                for (int i = 0; i < PreferredHashOrder.Length; i++)
                    mPreMadeFields.Add(new Field() { AutoRecalc = true, HashName = PreferredHashOrder[i], DataType = HashDataTypes[i] });
            }
            return mPreMadeFields;
        }
    }
    /// <summary>
    /// The Enumerator of Camera Types
    /// </summary>
    public enum CameraType
    {
        CAM_TYPE_2D_SLIDE, //Slides 4 ways only. (Not forward or backward)
        CAM_TYPE_ANIM,
        CAM_TYPE_BEHIND_DEBUG,
        CAM_TYPE_BLACK_HOLE,
        CAM_TYPE_BOSS_DONKETSU,
        CAM_TYPE_CHARMED_FIX,
        CAM_TYPE_CHARMED_VECREG,
        CAM_TYPE_CHARMED_VECREG_TOWER,
        CAM_TYPE_CUBE_PLANET, //Allows the camera to rotate to fit the current gravity
        CAM_TYPE_DEAD,
        CAM_TYPE_DONKETSU_TEST,
        CAM_TYPE_DPD,
        CAM_TYPE_EYEPOS_FIX, //Moves the camera to a fixed location
        CAM_TYPE_EYEPOS_FIX_THERE, //Freezes the camera on place - Only rotates until freed
        CAM_TYPE_EYE_FIXED_THERE_TEST,
        CAM_TYPE_FOLLOW,
        CAM_TYPE_FOO_FIGHTER, //Red Star Related
        CAM_TYPE_FOO_FIGHTER_PLANET, //Red Star Related
        CAM_TYPE_FREEZE,
        CAM_TYPE_FRONT_AND_BACK,
        CAM_TYPE_GROUND,
        CAM_TYPE_ICECUBE_PLANET,
        CAM_TYPE_INNER_CYLINDER,
        CAM_TYPE_INWARD_SPHERE,
        CAM_TYPE_INWARD_TOWER, //Moves around a fixpoint so the fixpoint X & Z pos is never visible (Unconfirmed)
        CAM_TYPE_INWARD_TOWER_TEST,
        CAM_TYPE_MEDIAN_PLANET,
        CAM_TYPE_MEDIAN_TOWER,
        CAM_TYPE_MTXREG_PARALLEL,
        CAM_TYPE_OBJ_PARALLEL, //Moves based on Mario's position. Usually used for Flying
        CAM_TYPE_POINT_FIX,
        CAM_TYPE_RACE_FOLLOW,
        CAM_TYPE_RAIL_DEMO,
        CAM_TYPE_RAIL_FOLLOW,
        CAM_TYPE_RAIL_WATCH,
        CAM_TYPE_SLIDER,
        CAM_TYPE_SPHERE_TRUNDLE,
        CAM_TYPE_SPIRAL_DEMO,
        CAM_TYPE_SUBJECTIVE,
        CAM_TYPE_TALK, //NPC Camera
        CAM_TYPE_TOWER, //Moves around a fixpoint so the fixpoint X & Z pos is always visible
        CAM_TYPE_TOWER_POS,
        CAM_TYPE_TRIPOD_PLANET,
        CAM_TYPE_TRUNDLE,
        CAM_TYPE_TWISTED_PASSAGE,
        CAM_TYPE_WATER_FOLLOW,
        CAM_TYPE_WATER_PLANET,
        CAM_TYPE_WATER_PLANET_BOSS,
        CAM_TYPE_WONDER_PLANET,
        CAM_TYPE_XZ_PARA //The most basic camera ever.
    }
}

public static partial class BCAMUtility
{
    #region DEFAULTS
    //These are global for all cameras
    public const int DEFAULT_VERSION_SMG1 = 196630;
    public const int DEFAULT_VERSION_SMG2 = 196631;
    public const string DEFAULT_ID = "";
    public const string DEFAULT_CAMTYPE = "";
    // 0 = Applies for all camera versions
    public static readonly Dictionary<uint, Dictionary<uint, object>> DEFAULT_CAMERA_SETTINGS = new()
    {
        {
            BCAM.HASH_STRING, new()
            {
                { 0, "" }
            }
        },
        {
            BCAM.HASH_ANGLEB, new()
            {
                { 0, 0.3f }
            }
        },
        {
            BCAM.HASH_ANGLEA, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_ROLL, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_DIST, new()
            {
                { 0, 1200.0f }
            }
        },
        {
            BCAM.HASH_FOVY, new()
            {
                { 0, 45.0f }
            }
        },
        {
            BCAM.HASH_CAMINT, new()
            {
                { 0, 120 }
            }
        },
        {
            BCAM.HASH_CAMENDINT, new()
            {
                { 0, 120 }
            }
        },
        {
            BCAM.HASH_GNDINT, new()
            {
                { 0, 160 }
            }
        },
        {
            BCAM.HASH_NUM1, new()
            {
                { 0, 0 },
                { DEFAULT_VERSION_SMG1, 0 },
                { DEFAULT_VERSION_SMG2, 1 },
            }
        },
        {
            BCAM.HASH_NUM2, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_UPLAY, new()
            {
                { 0, 300.0f }
            }
        },
        {
            BCAM.HASH_LPLAY, new()
            {
                { 0, 800.0f }
            }
        },
        {
            BCAM.HASH_PUSHDELAY, new()
            {
                { 0, 120 }
            }
        },
        {
            BCAM.HASH_PUSHDELAYLOW, new()
            {
                { 0, 120 }
            }
        },
        {
            BCAM.HASH_UDOWN, new()
            {
                { 0, 120 }
            }
        },
        {
            BCAM.HASH_LOFFSET, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_LOFFSETV, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_UPPER, new()
            {
                { 0, 0.3f }
            }
        },
        {
            BCAM.HASH_LOWER, new()
            {
                { 0, 0.1f }
            }
        },
        {
            BCAM.HASH_EVFRM, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_EVPRIORITY, new()
            {
                { 0, 1 }
            }
        },
        {
            BCAM.HASH_WOFFSET_X, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_WOFFSET_Y, new()
            {
                { 0, 100.0f },
                { DEFAULT_VERSION_SMG1, 100.0f },
                { DEFAULT_VERSION_SMG2,   0.0f },
            }
        },
        {
            BCAM.HASH_WOFFSET_Z, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_WPOINT_X, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_WPOINT_Y, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_WPOINT_Z, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_AXIS_X, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_AXIS_Y, new()
            {
                { 0, 1.0f }
            }
        },
        {
            BCAM.HASH_AXIS_Z, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_VPANAXIS_X, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_VPANAXIS_Y, new()
            {
                { 0, 1.0f }
            }
        },
        {
            BCAM.HASH_VPANAXIS_Z, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_UP_X, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_UP_Y, new()
            {
                { 0, 0.0f },
                { DEFAULT_VERSION_SMG1, 0.0f },
                { DEFAULT_VERSION_SMG2, 1.0f },
            }
        },
        {
            BCAM.HASH_UP_Z, new()
            {
                { 0, 0.0f }
            }
        },
        {
            BCAM.HASH_FLAG_NORESET, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_FLAG_NOFOVY, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_FLAG_LOFSERPOFF, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_FLAG_ANTIBLUROFF, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_FLAG_COLLISIONOFF, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_FLAG_SUBJECTIVEOFF, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_GFLAG_ENABLEENDERPFRAME, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_GFLAG_THRU, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_GFLAG_CAMENDINT, new()
            {
                { 0, 120 }
            }
        },
        {
            BCAM.HASH_VPANUSE, new()
            {
                { 0, 1 }
            }
        },
        {
            BCAM.HASH_EFLAG_ENABLEENDERPFRAME, new()
            {
                { 0, 0 }
            }
        },
        {
            BCAM.HASH_EFLAG_ENABLEERPFRAME, new()
            {
                { 0, 0 }
            }
        },
    };
    #endregion

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

    //public class CameraDefaults
    //{
    //    public readonly static Dictionary<string, CameraDefaults> Defaults = new()
    //    {
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_XZ_PARA", new CameraDefaults(AngleA:0, AngleB:0, Dist:3000f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_WONDER_PLANET", new CameraDefaults(AxisX:500.0f, AxisY:2000.0f, AngleA:0.7853982f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_TOWER", new CameraDefaults(WPointX:0, WPointY:0, WPointZ:0, AxisX:0, AxisY:1.0f, AxisZ:0, AngleA:0, AngleB:0, Dist:2000.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_TOWER_POS", new CameraDefaults(WPointX:0, WPointY:0, WPointZ:0, AxisX:0, AxisY:1.0f, AxisZ:0, AngleA:0, AngleB:0, UpX:1000.0f, UpY: 0.5f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_INWARD_TOWER", new CameraDefaults(WPointX:0, WPointY:0, WPointZ:0, AxisX:0, AxisY:1, AxisZ:0, AngleA:0, AngleB:0, Dist:2000.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_INWARD_SPHERE", new CameraDefaults(Dist:1500.0f, AngleA:500.0f, AngleB:300.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_POINT_FIX", new CameraDefaults() },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_EYEPOS_FIX", new CameraDefaults() },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_EYEPOS_FIX_THERE", new CameraDefaults() },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_TRUNDLE", new CameraDefaults(WPointX:0, WPointY:0, WPointZ:0, AxisX:1.0f, AxisY:0, AxisZ:0, Dist:2000.0f, AngleA:0, AngleB:0, UpX:0) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_SPHERE_TRUNDLE", new CameraDefaults(DEFAULT_VERSION_SMG2) }, //SMG2 ONLY
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_INNER_CYLINDER", new CameraDefaults(WPointX:0, WPointY:0, WPointZ:0, AxisX:0, AxisY:0, AxisZ:0, AngleA:0, AngleB:0, Dist:0) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_CUBE_PLANET", new CameraDefaults(Dist:3000.0f, AngleA:0.5235988f, AngleB:0.35f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_CHARMED_FIX", new CameraDefaults(AxisX:0, AxisY:0, AxisZ:0, UpX:0, UpY:1, UpZ:0, WPointX:0, WPointY:0, WPointZ:1000.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_CHARMED_VECREG", new CameraDefaults(String:"", Dist:1000.0f, AxisX:0, AxisY:0, AxisZ:0, AngleA:0.5f, AngleB:0.02f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_CHARMED_VECREG_TOWER", new CameraDefaults() },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_MEDIAN_PLANET", new CameraDefaults(String:"", AxisX:1200.0f, AxisY:3000.0f, AngleA:0.7853982f, AngleB:0.0f, Dist:2000.0f, AxisZ: 0.2f, WPointX:0.5f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_MEDIAN_TOWER", new CameraDefaults(String:"", WPointX:0, WPointY:0, WPointZ:0, AxisX:0, AxisY:1, AxisZ:0, AngleA:0.5235988f, UpX:1200.0f, UpY:0, UpZ:0.5f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_FOLLOW", new CameraDefaults(AxisX:1200.0f, AxisY:300.0f, AngleA:0.17453294f, AngleB:0.34906587f, Dist:0.15f, num1:1) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_RACE_FOLLOW", new CameraDefaults(WPointX:500.0f, WPointY:1200.0f, AngleA:0.2617994f, num1:0, WPointZ:0) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_WATER_FOLLOW", new CameraDefaults(AxisY:300.0f, AxisX:1200.0f, Dist:0.01f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_WATER_PLANET", new CameraDefaults(AxisX:500.0f, AxisY:2000.0f, AngleA:0.7853982f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_WATER_PLANET_BOSS", new CameraDefaults(AxisY:300.0f, AxisX:1200.0f, Dist:0.01f, num1:0, WPointX:0, WPointY:0, WPointZ:0, AxisZ:0, UpY:0, UpX:0, UpZ:0) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_TRIPOD_PLANET", new CameraDefaults(AxisX:0, AxisY:1, AxisZ:0, WPointX:0, WPointY:0, WPointZ:0, AngleA:0, AngleB:0, Dist:1000.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_TRIPOD_BOSS", new CameraDefaults(DEFAULT_VERSION_SMG1, UpZ:0) }, //SMG1 ONLY
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_TRIPOD_BOSS_JOINT", new CameraDefaults(DEFAULT_VERSION_SMG1, AngleB:0, AngleA:0, Dist:3000.0f, num1:0) }, //SMG1 ONLY
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_CHARMED_TRIPOD_BOSS", new CameraDefaults(DEFAULT_VERSION_SMG1, num1:-1, UpX:0, UpY:1, UpZ:0, WPointX:0, WPointY:0, WPointZ:1000.0f, AxisX:0, AxisY:0) }, //SMG1 ONLY
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_FOO_FIGHTER", new CameraDefaults(AxisY:300.0f, AxisX:1200.0f, Dist:0.03f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_FOO_FIGHTER_PLANET", new CameraDefaults(AxisX:500.0f, AxisY:2000.0f, AngleA:0.7853982f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_RAIL_WATCH", new CameraDefaults(num2:0, AxisX:0, Dist:1200.0f, AngleA:0) },
    //        //==================================================================================================================================================================
    //        //Num1 is cut in half. 0xAAAABBBB (num1 >> 16) and (num1 & 0x0000FFFF)
    //        { "CAM_TYPE_RAIL_DEMO", new CameraDefaults() },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_RAIL_FOLLOW", new CameraDefaults(Dist:0, WPointX:30.0f, WPointY:0.35f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_OBJ_PARALLEL", new CameraDefaults(AngleA:0, AngleB:0, Dist:3000.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_MTXREG_PARALLEL", new CameraDefaults(String:"", AngleB:0, AngleA:0, Dist:1000.0f, WPointX:0, WPointY:0, WPointZ:0) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_SLIDER", new CameraDefaults(AngleB:0.5235988f, AngleA:0, Dist:3000.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_2D_SLIDE", new CameraDefaults(AxisX:1, AxisY:0, AxisZ:0, UpX:0, UpY:1, UpZ:0, WPointX:0, WPointY:0, WPointZ:0, AngleA:0, Dist:1000.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_GROUND", new CameraDefaults(AngleA:0, AngleB:0, Dist:1000.0f, UpX:0, UpY:1, UpZ:0) },
    //        //==================================================================================================================================================================
    //        //Num1 is cut in half. 0x003C0000 => 0x003c and 0x0000 separately
    //        { "CAM_TYPE_SPIRAL_DEMO", new CameraDefaults(num1:0x003C0000, num2:0, WPointZ:1000.0f, AxisZ:1000.0f, WPointX:0, AxisX:0) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_TWISTED_PASSAGE", new CameraDefaults(AxisX:500.0f, AxisY:1300.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_FRONT_AND_BACK", new CameraDefaults(WPointX:0, WPointY:0, WPointZ:0, AxisX:0, AxisY:1, AxisZ:0, AngleA:0, AngleB:0, Dist:1200.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_FREEZE", new CameraDefaults(DEFAULT_VERSION_SMG2) }, //SMG2 ONLY
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_TALK", new CameraDefaults(WPointX:0, WPointY:0, WPointZ:0, UpX:0, UpY:1, UpZ:0, AxisX:120.0f, AxisY:450.0f) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_ANIM", new CameraDefaults() },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_DEAD", new CameraDefaults(Dist:0.5f, num1:0, num2:0) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_BLACK_HOLE", new CameraDefaults(WPointX:0, WPointY:0, WPointZ:0, AxisX:0, AxisY:0, AxisZ:0) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_DPD", new CameraDefaults(num1:0, Dist:0, FovY:40, AngleA:1.5707964f, AngleB:1.5707964f, WPointZ:0, WPointX:0.05f, WPointY:0.99f, num2:0, UpX:0) },
    //        //==================================================================================================================================================================
    //        { "CAM_TYPE_SUBJECTIVE", new CameraDefaults() },
    //        //==================================================================================================================================================================
    //    };

    //    internal CameraDefaults(
    //        int version = DEFAULT_VERSION_SMG2,
    //        float AngleB = DEFAULT_ANGLEB,
    //        float AngleA = DEFAULT_ANGLEA,
    //        float Roll = DEFAULT_ROLL,
    //        float Dist = DEFAULT_DIST,
    //        float FovY = DEFAULT_FOVY,
    //        int CamInt = DEFAULT_CAMINT,
    //        int CamEndInt = DEFAULT_CAMENDINT,
    //        int GndInt = DEFAULT_GNDINT,
    //        int num1 = DEFAULT_NUM1,
    //        int num2 = DEFAULT_NUM2,
    //        string String = DEFAULT_STRING,
    //        float UPlay = DEFAULT_UPLAY,
    //        float LPlay = DEFAULT_LPLAY,
    //        int PushDelay = DEFAULT_PUSHDELAY,
    //        int PushDelayLow = DEFAULT_PUSHDELAYLOW,
    //        int udown = DEFAULT_UDOWN,
    //        float lookoffset = DEFAULT_LOFFSET,
    //        float lookoffsety = DEFAULT_LOFFSETV,
    //        float upperborder = DEFAULT_UPPER,
    //        float lowerborder = DEFAULT_LOWER,
    //        int evframes = DEFAULT_EVFRM,
    //        int evpriority = DEFAULT_EVPRIORITY,
    //        float WOffsetX = DEFAULT_WOFFSET_X,
    //        float WOffsetY = DEFAULT_WOFFSET_Y,
    //        float WOffsetZ = DEFAULT_WOFFSET_Z,
    //        float WPointX = DEFAULT_WPOINT_X,
    //        float WPointY = DEFAULT_WPOINT_Y,
    //        float WPointZ = DEFAULT_WPOINT_Z,
    //        float AxisX = DEFAULT_AXIS_X,
    //        float AxisY = DEFAULT_AXIS_Y,
    //        float AxisZ = DEFAULT_AXIS_Z,
    //        float VPanAxisX = DEFAULT_VPANAXIS_X,
    //        float VPanAxisY = DEFAULT_VPANAXIS_Y,
    //        float VPanAxisZ = DEFAULT_VPANAXIS_Z,
    //        float UpX = DEFAULT_UP_X,
    //        float UpY = DEFAULT_UP_Y,
    //        float UpZ = DEFAULT_UP_Z,
    //        int disablereset = DEFAULT_FLAG_NORESET,
    //        int enablefov = DEFAULT_FLAG_NOFOVY,
    //        int staticlookoffset = DEFAULT_FLAG_LOFSERPOFF,
    //        int disableantiblur = DEFAULT_FLAG_ANTIBLUROFF,
    //        int disablecollision = DEFAULT_FLAG_COLLISIONOFF,
    //        int disablefirstperson = DEFAULT_FLAG_SUBJECTIVEOFF,
    //        int Gflagenderpframe = DEFAULT_GFLAG_ENABLEENDERPFRAME,
    //        int Gflagthrough = DEFAULT_GFLAG_THRU,
    //        int Gflagendtime = DEFAULT_GFLAG_CAMENDINT,
    //        int useverticalpanaxis = DEFAULT_VPANUSE,
    //        int eventuseendtime = DEFAULT_EFLAG_ENABLEENDERPFRAME,
    //        int eventusetime = DEFAULT_EFLAG_ENABLEERPFRAME) => DefaultValues = new()
    //        {
    //            { BCAM.HASH_VERSION, version },
    //            { BCAM.HASH_ANGLEB, AngleB },
    //            { BCAM.HASH_ANGLEA, AngleA },
    //            { BCAM.HASH_ROLL, Roll },
    //            { BCAM.HASH_DIST, Dist },
    //            { BCAM.HASH_FOVY, FovY },
    //            { BCAM.HASH_CAMINT, CamInt },
    //            { BCAM.HASH_CAMENDINT, CamEndInt },
    //            { BCAM.HASH_GNDINT, GndInt },
    //            { BCAM.HASH_NUM1, num1 },
    //            { BCAM.HASH_NUM2, num2 },
    //            { BCAM.HASH_STRING, String },
    //            { BCAM.HASH_UPLAY, UPlay },
    //            { BCAM.HASH_LPLAY, LPlay },
    //            { BCAM.HASH_PUSHDELAY, PushDelay },
    //            { BCAM.HASH_PUSHDELAYLOW, PushDelayLow },
    //            { BCAM.HASH_UDOWN, udown },
    //            { BCAM.HASH_LOFFSET, lookoffset },
    //            { BCAM.HASH_LOFFSETV, lookoffsety },
    //            { BCAM.HASH_UPPER, upperborder },
    //            { BCAM.HASH_LOWER, lowerborder },
    //            { BCAM.HASH_EVFRM, evframes },
    //            { BCAM.HASH_EVPRIORITY, evpriority },

    //            { BCAM.HASH_WOFFSET_X, WOffsetX },
    //            { BCAM.HASH_WOFFSET_Y, WOffsetY },
    //            { BCAM.HASH_WOFFSET_Z, WOffsetZ },
    //            { BCAM.HASH_WPOINT_X, WPointX },
    //            { BCAM.HASH_WPOINT_Y, WPointY },
    //            { BCAM.HASH_WPOINT_Z, WPointZ },
    //            { BCAM.HASH_AXIS_X, AxisX },
    //            { BCAM.HASH_AXIS_Y, AxisY },
    //            { BCAM.HASH_AXIS_Z, AxisZ },
    //            { BCAM.HASH_VPANAXIS_X, VPanAxisX },
    //            { BCAM.HASH_VPANAXIS_Y, VPanAxisY },
    //            { BCAM.HASH_VPANAXIS_Z, VPanAxisZ },
    //            { BCAM.HASH_UP_X, UpX },
    //            { BCAM.HASH_UP_Y, UpY },
    //            { BCAM.HASH_UP_Z, UpZ },

    //            { BCAM.HASH_FLAG_NORESET, disablereset },
    //            { BCAM.HASH_FLAG_NOFOVY, enablefov },
    //            { BCAM.HASH_FLAG_LOFSERPOFF, staticlookoffset },
    //            { BCAM.HASH_FLAG_ANTIBLUROFF, disableantiblur },
    //            { BCAM.HASH_FLAG_COLLISIONOFF, disablecollision },
    //            { BCAM.HASH_FLAG_SUBJECTIVEOFF, disablefirstperson },
    //            { BCAM.HASH_GFLAG_ENABLEENDERPFRAME, Gflagenderpframe },
    //            { BCAM.HASH_GFLAG_THRU, Gflagthrough },
    //            { BCAM.HASH_GFLAG_CAMENDINT, Gflagendtime },
    //            { BCAM.HASH_VPANUSE, useverticalpanaxis },
    //            { BCAM.HASH_EFLAG_ENABLEENDERPFRAME, eventusetime },
    //            { BCAM.HASH_EFLAG_ENABLEERPFRAME, eventuseendtime }
    //        };

    //    internal readonly Dictionary<uint, object> DefaultValues;

    //    public static object GetCamTypeDefault(uint Hash, string Type)
    //    {
    //        if (!CameraDefaults.Defaults.TryGetValue(Type, out CameraDefaults? Defaults))
    //            Defaults = CameraDefaults.Defaults["CAM_TYPE_XZ_PARA"];
    //        return Defaults.DefaultValues[Hash];
    //    }
    //}

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
        public EventData(string s, bool needsid, bool needssubid)
        {
            English = s;
            NeedsID = needsid;
            NeedsSubID = needssubid;
        }

        public static implicit operator string(EventData x) => x.English;
        public override string ToString() => English;

        /// <summary>
        /// e: cameras
        /// </summary>
        public readonly static Dictionary<string, EventData> Events = new()
        {
            { "シナリオスターター", new("Scenario Starter", true, true) },

            { "スーパースピンドライバー固有出現イベント用", new("Launch Star Appearance", true, false) },
            { "スーパースピンドライバー", new("Launch Star", true, true) },

            { "スピンドライバ固有出現イベント用", new("Sling Star Appearance", true, false) },
            { "スピンドライバ", new("Sling Star", true, true) },

            { "グリーンスーパースピンドライバー固有出現イベント用", new("Green Launch Star Appearance", true, false) },
            { "グリーンスーパースピンドライバー", new("Green Launch Star", true, true)},

            { "ピンクスーパースピンドライバー固有出現イベント用", new("Pink Launch Star Appearance", true, false) },
            { "ピンクスーパースピンドライバー", new("Pink Launch Star", true, true)},

            { "Gキャプチャーターゲット固有", new("Pull Star Appearance", true, false) },

            { "グランドスター固有", new("Grand Star Appearance", true, false) },
            { "パワースター固有", new("Power Star Appearance", true, false) },
            { "グリーンスター固有", new("Green Star Appearance", true, false) },
            { "パワースター出現ポイント固有", new("Power Star Appear Point", true, false) },

            { "チコ集め固有集めデモカメラ", new("Silver Star Completion", true, false) },
            { "簡易デモ実行固有簡易デモ", new("Simple Demo Executor", true, false) },
            { "鍵スイッチ固有", new("Key Switch Appearence", true, false) },
            { "カプセルケージ固有", new("Capsule Cage Opening", true, false) },
            { "ゴロ岩カバー檻固有", new("Metal Capsule Cage Opening", true, false) },
            { "土管固有出現", new("Warp Pipe", true, false) },
            { "土管（水中用）固有出現", new("Warp Pipe (In Water)", true, false) },
            { "ウォータープレッシャー固有", new("Bubble Shooter", true, false) },

            { "ポール固有", new("Pole", true, false) },
            { "ポール（２方向）固有", new("Pole 2 Way", true, false) },
            { "ポール（モデル無し）固有", new("Pole (No Model)", true, false) },
            { "ポール（鉄骨）固有", new("Square Pole", true, false) },
            { "ポール(モデル無し鉄骨)固有", new("Square Pole (No Model)", true, false) },
            { "ポール（木Ａ）固有", new("Pole Tree A", true, false) },
            { "ポール（木B）固有", new("Pole Tree B", true, false) },

            { "移動用砲台固有", new("Player Cannon", true, false) },
            { "１ＵＰキノコ固有", new("1-UP Appearence", true, false) },
            { "？コイン固有", new("?-Coin Collection", true, false) },

            { "伸び植物固有出現デモ", new("Sproutle Vine Appearance", true, false) },
            { "伸び植物固有掴まり", new("Sproutle Vine", true, false) },
            { "つるスライダー固有滑り", new("Sprauto Vine", true, false) },
            { "つる花固有掴まり", new("Creeper Plant", true, false) },
            { "空中ブランコ固有", new("Trapeze Vine", true, false) },
            { "スイングロープ固有", new("Swinging Vine", true, false) },

            { "ポイハナ固有", new("Cataquack Launch", true, false) },

            { "音符の妖精固有", new("Note Fairy Appearance", true, false) },
            { "インフェルノジェネレータ固有出現デモカメラ", new("Cosmic Clones Appearance", true, false) },
            { "ブラックホール固有", new("Black Hole Death", true, false) },
            { "ブラックホール[キューブ指定]固有", new("Black Hole (Cube) Death", true, false) },
            { "ジャンプビーマー", new("Spring Beamer", true, true) },
            { "ジャンプガーダー", new("Guard Beamer", true, true) },
            { "バネベーゴマン", new("Spring Topman", true, true) },
            { "隠れバネベーゴマン", new("Hiding Spring Topman", true, true) },
            { "モンテ固有", new("Chuckster Pianta", true, false) },
            { "アイテムドリル固有", new("Spin Drill Usage", true, false) },
            { "グライバード固有死亡", new("Fluzzard Death", true, false) },

            { "ゴーストマリオ固有", new("Cosmic Race (unknown usage)", true, false) },
            { "ゴーストマリオ固有レース開始1", new("Cosmic Race Appearance", true, false) },
            { "ゴーストマリオ固有レース開始2", new("Cosmic Race Staredown", true, false) },
            { "ゴーストマリオ固有レース開始3", new("Cosmic Race Countdown", true, false) },
            { "ゴーストマリオ固有レース終了", new("Cosmic Race Losing Camera", true, false) },

            { "ハラペココインチコ固有飛行", new("[SMG2] Coin Hungry Luma Flight", true, false) },
            { "ハラペコスターピースチコ固有変身", new("[SMG2] Starbit Hungry Luma Transformation", true, false) },
            { "ハラペコスターピースチコ固有飛行", new("[SMG2] Starbit Hungry Luma Flight", true, false) },

            { "チューブスライダー固有滑り", new("Tube Slider", true, false) },
            { "チューブスライダー固有飛び出し", new("Tube Slider Exit", true, false) },
            { "プチポーター固有基点でワープイン", new("Minigame Teleporter (Prepare to Warp)", true, false) },
            { "プチポーター固有ワープ点でワープアウト", new("Minigame Teleporter (Arrive at Destination)", true, false) },
            { "プチポーター固有ワープ点でワープイン", new("Minigame Teleporter (Prepare return warp)", true, false) },
            { "プチポーター固有基点でワープアウト", new("Minigame Teleporter (Arrive from returning)", true, false) },

            { "ワープカメラ (GroupID)-(The ASCII character ObjArg0+65 represents)", new("Warp Pod Template", false, false) },

            { "看板固有会話", new("Message: Signboard", true, false) },
            { "でか看板固有会話", new("Message: Big Signboard", true, false) },
            { "ピーチ固有会話", new("Message: Peach", true, false) },
            { "キノピオ固有会話", new("Message: Toad", true, false) },
            { "郵便屋さんキノピオ固有注目会話", new("Message: Mailtoad", true, false) },
            { "銀行屋さんキノピオ固有注目会話", new("Message: Banktoad", true, false) },
            { "ウサギ固有会話", new("Message: Star Bunny", true, false) },
            { "ロゼッタ固有会話", new("Message: Rosalina", true, false) },
            { "マイスター固有会話", new("Message: Lubba", true, false) },
            { "チコ固有会話", new("Message: Luma", true, false) },
            { "でかチコ固有会話", new("Message: Big Luma", true, false) },
            { "よろず屋チコ固有独自会話", new("Message: Luma Shop", true, false) },
            { "ハニークイーン固有会話", new("Message: Queen Bee", true, false) },
            { "ハニービー固有会話", new("Message: Honeybee", true, false) },
            { "ペンギン仙人固有会話", new("Message: Penguin Elder", true, false) },
            { "ペンギンコーチ固有会話", new("Message: Penguin Coach", true, false) },
            { "ペンギン固有会話", new("Message: Penguin", true, false) },
            { "パマタリアン固有会話", new("Message: Gearmo", true, false) },
            { "パマタリアンハンター固有会話", new("Message: Gearmo Hunter", true, false) },
            { "赤ボム兵固有会話", new("Message: Bob-omb Buddy", true, false) },
            { "モンテ固有会話", new("Message: Pianta", true, false) },
            { "ピーチャン固有会話", new("Message: Jibberjay", true, false) },
            { "モック固有会話", new("Message: Whittle", true, false) },
            { "さすらいの遊び人(通常会話)固有会話", new("Message: The Chimp (NPC)", true, false) },


            { "引き戻し", new("Pull Back Area", false, false) },
            { "水上フォロー", new("Water Follow", false, false) },
            { "水中フォロー", new("Underwater Follow", false, false) },
            { "水中プラネット", new("Underwater Planet", false, false) },
            { "フーファイターカメラ", new("Foo Fighter Camera", false, false) },

            { "DemoName[CameraPartName]", new("Demo Camera Template", false, false) },
            { "g:ObjectName:CameraID:0", new("Collision Camera Template", false, false) },
        };
        /// <summary>
        /// o: cameras
        /// </summary>
        public readonly static Dictionary<string, EventData> OtherEvents = new()
        {
            { "デフォルト水面カメラ", new("Default Water Surface", false, false) },
            { "デフォルト水中カメラ", new("Default Underwater", false, false) },
            { "デフォルトフーファイターカメラ", new("Default Flying Mario", false, false) },
            { "スタートカメラ", new("Default Spawn Point", false, false) },
            { "デフォルトカメラ", new("Default Camera", false, false) }
        };
    }

    public static string GetTranslatedName(this BCAM.Entry entry)
    {
        string INVALID = "Invalid ID";
        string Original = entry.Identification.ToString();
        string[] OriginalParts = Original.Split(':');
        if (TryMakeNumberName("c:", "Camera Area", out string NewString))
            return NewString;

        if (TryMakeNumberName("s:", "Spawn Point", out NewString))
            return NewString;

        if (TryMakeEventName("e:", out NewString))
            return NewString;

        if (TryMakeEventName("o:", out NewString))
            return NewString;

        if (Original.StartsWith("g:"))
            return Original.Replace("g:", "Group: ");

        return (
            string.IsNullOrWhiteSpace(NewString) &&
            !Original.StartsWith("c:") &&
            !Original.StartsWith("s:") &&
            !Original.StartsWith("e:") &&
            !Original.StartsWith("o:")) ? INVALID : Original;

        bool TryMakeNumberName(string StartsWith, string Translated, out string result)
        {
            result = string.Empty;
            if (!Original.StartsWith(StartsWith))
                return false;

            if (OriginalParts.Length < 2)
                return false;

            result = $"{Translated} ";
            if (short.TryParse(OriginalParts[1], System.Globalization.NumberStyles.HexNumber, null, out short readshort))
            {
                bool UseLong = Program.Settings.IsUseLongId;
                short Abs = Math.Abs(readshort);
                result += $"{(readshort < 0 ? "-":"")}{(Program.Settings.IsUseHexId ? Abs.ToString("X").PadLeft(UseLong ? 4 : 0, '0') : Abs.ToString().PadLeft(UseLong ? 4 : 0, '0'))}";
            }

            return true;
        }
    
        bool TryMakeEventName(string StartsWith, out string result)
        {
            result = string.Empty;
            if (!Original.StartsWith(StartsWith))
                return false;

            if (OriginalParts.Length < 2)
                return false;

            if (DemoCameraRegex().IsMatch(Original))
            {
                result = $"Demo: {Original[2..]}";
                return true;
            }

            if (WarpPodCameraRegex().IsMatch(Original))
            {
                result = Original;

                //Warp pods have a very....interesting pattern to them...
                string[] data = Original.Split();
                if (data.Length != 2)
                    goto Exit;
                string[] values = data[1].Split('-');
                if (values.Length != 2)
                    goto Exit;
                result = $"Event: Warp Pod (Group {values[0]}, Arg0 = {values[1][0] - 'A'})";
                return true;
            }
        Exit:

            EventData? Evt;
            if (OriginalParts[1].Length >= 3)
            {
                string KeyNoLast3Numbers = OriginalParts[1][..^3];
                if (EventData.Events.TryGetValue(KeyNoLast3Numbers, out Evt))
                {
                    result = $"Event {Original[2..].Replace(KeyNoLast3Numbers, Evt + " ").Replace("番目", "th")}";
                    return true;
                }
            }


            string targetkey = string.Concat(OriginalParts[1].Where(IsNonDigit));
            if(EventData.Events.TryGetValue(targetkey, out Evt))
            {
                result = $"Event {Original[2..].Replace(targetkey, Evt + " ").Replace("番目", "th")}";
                return true;
            }

            if (EventData.OtherEvents.TryGetValue(targetkey, out Evt))
            {
                result = $"Other: {Evt}";
                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// Only for c: and s:
    /// </summary>
    /// <param name="cameras"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static ushort GetNextOpenShortNumber(BCAM cameras, Regex type)
    {
        List<ushort> UsedShorts = [];
        IEnumerable<BCAM.Entry> ShortNumberCameras = GetEnumeratorOfCameraType(cameras, type);
        foreach (BCAM.Entry item in ShortNumberCameras)
        {
            string[] split = item.Identification.Split(':');
            // No need to check length as the Regex would've failed if it didn't have a ':' in it.
            if (ushort.TryParse(split[1], System.Globalization.NumberStyles.HexNumber, null, out ushort result))
                UsedShorts.Add(result);
        }
        UsedShorts.Sort();
        int i = 0;
        for (; i < UsedShorts.Count; i++)
        {
            if (i != UsedShorts[i])
                break;
        }
        return (ushort)i;
    }

    public static int GetNextOpenEventNumber(BCAM cameras, Regex type)
    {
        List<int> UsedValues = [];
        IEnumerable<BCAM.Entry> EventCameraList = GetEnumeratorOfCameraType(cameras, type);
        foreach (BCAM.Entry item in EventCameraList)
        {
            Match m = EventNoPartIDRegex().Match(item.Identification);
            if (m.Success && int.TryParse(m.Groups[1].Value, out int NoPartID))
            {
                UsedValues.Add(NoPartID);
                continue;
            }

            m = EventWithPartIDRegex().Match(item.Identification);
            if (m.Success && int.TryParse(m.Groups[1].Value, out int WithPartID))
            {
                UsedValues.Add(WithPartID);
                continue;
            }
        }
        UsedValues.Sort();
        int i = 0;
        for (; i < UsedValues.Count; i++)
        {
            if (i != UsedValues[i])
                break;
        }
        return (ushort)i;
    }

    public static IEnumerable<BCAM.Entry> GetEnumeratorOfCameraType(BCAM cameras, Regex type)
    {
        for (int i = 0; i < cameras.EntryCount; i++)
        {
            BCAM.Entry e = cameras[i];
            if (type.IsMatch(e.Identification))
                yield return e;
        }
    }

    public static bool IsNonDigit(char c) => !(c >= 0x30 && c <= 0x39);

    [GeneratedRegex(@"c:[0-9a-f]{4}")]
    public static partial Regex CameraAreaIDRegex();
    [GeneratedRegex(@"s:[0-9a-f]{4}")]
    public static partial Regex StartIDRegex();
    public static Regex CreateEventIDRegex(string EventID, bool IsMultiPart) => IsMultiPart ? new(@$"e:{EventID}:[0-9]{{3}}:[0-9]{{2}}番目") : new(@$"e:{EventID}[0-9]{{3}}");

    [GeneratedRegex(@"e:\S+?([0-9]{3})")]
    private static partial Regex EventNoPartIDRegex();
    [GeneratedRegex(@"e:\S+?:([0-9]{3}):[0-9]{2}番目")]
    private static partial Regex EventWithPartIDRegex();
    [GeneratedRegex(@"e:\S+?\[\S+?\]")]
    private static partial Regex DemoCameraRegex();
    [GeneratedRegex(@"e:.*\s\d-\S")]
    private static partial Regex WarpPodCameraRegex();
}