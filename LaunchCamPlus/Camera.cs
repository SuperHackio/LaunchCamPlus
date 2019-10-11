using System.Collections.Generic;

namespace Cameras
{
    public partial class Camera //There are 52
    {
        public Camera() { }
        public Camera(int id)
        {
            this.ListID = id;
            this.RotationX = RefineAngle(this.RotationX);
            this.RotationY = RefineAngle(this.RotationY);
            this.RotationZ = RefineAngle(this.RotationZ);
        }
        //-----------------------------------------------------
        public int ListID { get; set; }

        #region Info Settings [4]
        /// <summary>
        /// Camera Version. Standard is 196631.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Camera ID. Ground is not an publically availible option.
        /// </summary>
        public string Identification { get; set; }
        public string IDDisplay(IDOptions ID)
        {
            switch (ID)
            {
                case IDOptions.c: return "Camera Area";
                case IDOptions.s: return "Spawn Point";
                case IDOptions.e: return "Event";
                case IDOptions.o: return "Other";
                case IDOptions.g: return "Ground";

                default: return "Undefined";
            }
        }

        public int Num { get; set; }

        public string Type { get; set; }

        #endregion

        #region Rotations & Zoom [4]
        public float RotationX { get; set; } // Up / down [X Rotation]
        public float RotationY { get; set; } // Left / Right [Y Rotation]
        public float RotationZ { get; set; } // Rotates screen [Z Rotation]

        public float Zoom { get; set; } //Distance away from Mario [Distance]
        #endregion
        
        public float DPDRotation { get; set; } //Rotation of the D-PAD (or Field Of View, for whatever reason...) [D-Pad Rotation]

        #region Speeds [3]
        public int TransitionSpeed { get; set; } //Time it takes for the camera to activate [CamInt]
        public int EndTransitionSpeed { get; set; } //Time it takes for the camera to deactivate [CamEndInt]
        public int GroundMoveSpeed { get; set; } //How fast the camera moves while the player is on the ground [GndInt]
        #endregion

        public bool UseDPAD { get; set; } //Allow D-PAD rotation? [Num1]
        public bool UnknownNum2 { get; set; } //???????? [Num2]
        //--------------------------------------------------------------------------------------------------
        public float MaxY { get; set; } //The location that the camera starts following the player (Jumping up) [Max. Movement on Y-axis]
        public float MinY { get; set; } //The location that the camera starts following the player (Falling down) [Min. Movement on Y-axis]

        #region Delays (and 1 unknown) [3]
        public int GroundStartMoveDelay { get; set; } //Delay before the camera starts moving on the ground [PushDelay]
        public int AirStartMoveDelay { get; set; } //Delay before the camera starts moving in the air [PushDelayLow]
        public int UnknownUDown { get; set; } //???????? [UDown]
        #endregion

        public float FrontZoom { get; set; } //Distance in front of mario to look at [LOffset]
        public float HeightZoom { get; set; } //Distance above/below mario to look at [LOffsetV]

        public float UpperBorder { get; set; } //Camera Border [Upper]
        public float LowerBorder { get; set; } //Camera Border [Lower]
        //--------------------------------------------------------------------------------------------------
        public int EventFrames { get; set; } //How long the camera is active for when it's event is triggered (100 = 1 second) [EvFrm]
        public int EventPriority { get; set; } //Priority of this camera. Higher events will activate instead of lower events [EvPriority]

        #region Coordinates [15]
        public float FixpointOffsetX { get; set; } //Shifts the camera left/right by this amount [X-Offset from Fixpoint]
        public float FixpointOffsetY { get; set; } //Shifts the camera up/down by this amount [Y-Offset from Fixpoint]
        public float FixpointOffsetZ { get; set; } //Shifts the camera forwards/backwards by this amount [Z-Offset from Fixpoint]
        //--------------------------------------------------------------------------------------------------
        public float WorldPointX { get; set; } //X Position in the galaxy [Fixpoint X]
        public float WorldPointY { get; set; } //Y Position in the galaxy [Fixpoint Y]
        public float WorldPointZ { get; set; } //Z Position in the galaxy [Fixpoint Z]
        //--------------------------------------------------------------------------------------------------
        public float PlayerOffsetX { get; set; } //Shifts the camera left/right by this amount [X-Offset from Mario]
        public float PlayerOffsetY { get; set; } //Shifts the camera up/down by this amount [Y-Offset from Mario]
        public float PlayerOffsetZ { get; set; } //Shifts the camera forwards/backwards by this amount [Z-Offset from Mario]
        //--------------------------------------------------------------------------------------------------
        public float VPanAxisX { get; set; } // D-PAD Rotate on the X axis (Unconfirmed) [VPanAxis.X]
        public float VPanAxisY { get; set; } // D-PAD Rotate on the Y axis (Unconfirmed) [VPanAxis.Y]
        public float VPanAxisZ { get; set; } // D-PAD Rotate on the Z axis (Unconfirmed) [VPanAxis.Z]
        //--------------------------------------------------------------------------------------------------
        public float UnknownUpX { get; set; } //???????? [Up.X]
        public float UnknownUpY { get; set; } //???????? [Up.Y]
        public float UnknownUpZ { get; set; } //???????? [Up.Z]
        #endregion

        #region Flags [12]
        public bool DisableReset { get; set; } //Prevents the camera from rotating to the original camera angle when re-entering the Camera Area [Disable reset]
        private bool DisableDPAD { get; set; } //I don't know why this exists, but if Num1 is true then this setting is useless. Will auto-set to true [Disable D-Pad Rotation]

        public bool SharpZoom { get; set; } //Disables Smooth Movement when zooming with Front Zoom and Height Zoom [Flag.LOfserpOff]

        public bool DisableAntiBlur { get; set; } //Enables Blur, apparently [Disable Anti-Blur]
        public bool DisableCollision { get; set; } //Allows the camera to go through the collision [Disable Collision]
        public bool DisableFirstPerson { get; set; } //Disables First Person [Disable Point-of-View]

        public bool GFlagEndErpFrame { get; set; } //???????? [GFlag.EnableEndErpFrame]
        public bool GFlagThrough { get; set; } //???????? [GFlag.thru]
        public bool GFlagEndTransitionSpeed { get; set; } //???????? [GFlag.CamEndInt]

        public bool VPanUse { get; set; } //???????? [VPanUse]
        public bool EventUseEndTransition { get; set; } //Use an End Transition when the event is over (Unconfirmed)
        public bool EventUseTransition { get; set; } //Use a Transition when this event begins (Unconfirmed)
        #endregion
    }

    public partial class Camera //Commands
    {
        /// <summary>
        /// Makes a new Object Array that can be put into a BCSV entry
        /// </summary>
        /// <returns>object[]</returns>
        public object[] MakeBCSV()
        {
            return new object[] {
                this.Version,
                this.Identification,
                this.Num,
                this.Type,
                this.RotationX,
                this.RotationY,
                this.RotationZ,
                this.Zoom,
                this.DPDRotation,
                this.TransitionSpeed,
                this.EndTransitionSpeed,
                this.GroundMoveSpeed,
                this.Type == CameraType.CAM_TYPE_RAIL_WATCH.ToString() ? this.RailID : (this.UseDPAD ? 1 : 0),
                this.UnknownNum2 ? 1 : 0,
                this.MaxY,
                this.MinY,
                this.GroundStartMoveDelay,
                this.AirStartMoveDelay,
                this.UnknownUDown,
                this.FrontZoom,
                this.HeightZoom,
                this.UpperBorder,
                this.LowerBorder,
                this.EventFrames,
                this.EventPriority,
                this.FixpointOffsetX,
                this.FixpointOffsetY,
                this.FixpointOffsetZ,
                this.WorldPointX,
                this.WorldPointY,
                this.WorldPointZ,
                this.PlayerOffsetX,
                this.PlayerOffsetY,
                this.PlayerOffsetZ,
                this.VPanAxisX,
                this.VPanAxisY,
                this.VPanAxisZ,
                this.UnknownUpX,
                this.UnknownUpY,
                this.UnknownUpZ,
                this.DisableReset ? 1 : 0,
                this.DisableDPAD ? 1 : 0,
                this.SharpZoom ? 1 : 0,
                this.DisableAntiBlur ? 1 : 0,
                this.DisableCollision ? 1 : 0,
                this.DisableFirstPerson ? 1 : 0,
                this.GFlagEndErpFrame ? 1 : 0,
                this.GFlagThrough ? 1 : 0,
                this.GFlagEndTransitionSpeed ? 1 : 0,
                this.VPanUse ? 1 : 0,
                this.EventUseEndTransition ? 1 : 0,
                this.EventUseTransition ? 1 : 0
            };
        }

        /// <summary>
        /// Makes a new Byte Array that can be put into a BCSV Entry
        /// </summary>
        /// <returns>byte[]</returns>
        public byte[] GetSizes()
        {
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding(932);
            return new byte[]
            {
                0x04,
                (byte)(this.Identification.Length),
                0x04,
                (byte)this.Type.Length,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04,
                0x04
            };
        }

        /// <summary>
        /// Makes a new UInt Array that can e put into a BCSV Entry
        /// </summary>
        /// <param name="Strings">List of Camera Types to include</param>
        /// <returns>uint[]</returns>
        public uint[] GetStringOffsets(List<string> CameraTypes, List<string> Identifications, int CameraNumber, int ID = -1)
        {
            uint[] returnmeplz = new uint[52];

            returnmeplz[0] = 0;

            uint IDOffset = 0; //Offset to the ID that comes after all the types
            uint TypeOffset = 0; //Offset to the camera type
            uint OffsetToIDs = 0; //Offset to where the ID's start.
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding(932);

            //NOTE: RE-WRITE THIS ASAP!!!!!

            foreach (string s in CameraTypes)
            {
                OffsetToIDs += (uint)(s.Length + 1);
            }

            for (int i = 0; i < CameraNumber; i++) //Offset to the Identification
            {
                IDOffset += (uint)enc.GetBytes(Identifications[i]).Length+1;
            }

            IDOffset += OffsetToIDs; //--------------------------------------------------------

            for (int i = 0; i < CameraTypes.Count; i++)
            {
                if (this.Type == CameraTypes[i])
                {
                    ID = i;
                    break;
                }
            }
            for (int i = 0; i < ID; i++)
            {
                TypeOffset += (uint)(CameraTypes[i].Length + 1);
            }

            #region
            /*
            if (IDOffset != 0)
            {
                returnmeplz[1] = OffsetToIDs;
            }
            else
            {
                returnmeplz[1] = IDOffset + OffsetToIDs;
            }*/
            returnmeplz[1] = IDOffset;
            returnmeplz[2] = 0;
            returnmeplz[3] = TypeOffset;
            #endregion

            return returnmeplz;
        }

        public void SetDPADUse() => this.DisableDPAD = this.UseDPAD ? false : false;

        public float RefineAngle(float angle)
        {
            float NewAngle = RadianToDegree(angle);
            if (NewAngle < -180)
            {
                while (NewAngle < -180)
                {
                    NewAngle += 360;
                }
            }
            else if (NewAngle > 180)
            {
                while (NewAngle > 180)
                {
                    NewAngle -= 360;
                }
            }
            
            return DegreeToRadian(NewAngle);
        }

        /// <summary>
        /// Converts a Radian to a Degree
        /// </summary>
        /// <param name="angle">Radian angle</param>
        /// <returns>Degree Angle</returns>
        private float RadianToDegree(float angle)
        {
            return (float)(angle * (180.0 / System.Math.PI));
        }
        /// <summary>
        /// Converts a Degree to a Radian
        /// </summary>
        /// <param name="angle">Degree Angle</param>
        /// <returns>Radian Angle</returns>
        private float DegreeToRadian(float angle)
        {
            return (float)(System.Math.PI * angle / 180.0);
        }
    }

    public partial class Camera //Enums and arrays
    {
        /// <summary>
        /// The Enumerator of Camera ID Types.
        /// [ c | s | e | o | g ]
        /// </summary>
        public enum IDOptions { c, s, e, o, g }

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

    public partial class Camera //Specific Camera Extensions
    {
        /// <summary>
        /// For a Rail that uses Cameras, the Path Argument 0 must equal this number
        /// </summary>
        public int RailID { get; set; } //Only confirmed to be used by CAM_TYPE_RAIL_WATCH & CAM_TYPE_RAIL_FOLLOW
    }

    public class CameraEvent //Represent Event Cameras
    {
        public CameraEvent(string Jap, string Eng, Camera ID) {
            this.Identification = ID;
            this.Japanese = Jap;
            this.English = Eng;
        }

        public Camera Identification { get; set; } //Identification (ID in the Camera List)
        public string Japanese { get; set; } //Japanese Translation
        public string English { get; set; } //English Translation
    }
}