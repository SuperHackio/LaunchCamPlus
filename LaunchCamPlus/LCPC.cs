using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using LCPPManager;

/// <summary>
/// Unfinished. DO NOT USE
/// </summary>
namespace LCPCManager
{
    #region Format Documentation
    /*
     * Compression for Launch Cam Plus Preset Files
     * <------------------------------------------------------------------------------------->
     * HEADER:
     * Format => byte[4] {4C, 43, 50, 43} "LCPC"
     * Length of Preset Name
     * Name of preset | Zeros are truncated
     * Length of Preset Creator
     * Preset Creator | Zeros are truncated
     * Number of Cameras
     * Offset to Values List
     * <------------------------------------------------------------------------------------->
     * ENTRIES:
     * Offset to:
     * Version
     * Identification
     * Num
     * Type
     * Rotation X
     * Rotation Y
     * Rotation Z
     * Zoom
     * DPDRotation
     * TransitionSpeed
     * EndTransitionSpeed
     * GroundMoveSpeed
     * UseDPAD
     * UnknownNum2
     * MaxY
     * MinY
     * GroundStartMoveDelay
     * AirStartMoveDelay
     * UnknownUDown
     * UnknownLOffset
     * UnknownLOffsetV
     * UpperBorder
     * LowerBorder
     * EventFrames
     * EventPriority
     * FixpointOffsetX
     * FixpointOffsetY
     * FixpointOffsetZ
     * WorldPointX
     * WorldPointY
     * WorldPointZ
     * PlayerOffsetX
     * PlayerOffsetY
     * PlayerOffsetZ
     * VPanAxisX
     * VPanAxisY
     * VPanAxisZ
     * UnknownUpX
     * UnknownUpY
     * UnknownUpZ
     * DisableReset
     * FlagLOffsetRPOff
     * DisableAntiBlur
     * DisableCollision
     * DisablePOV
     * GFlagEndErpFrame
     * GFlagThrough
     * GFlagEndTransitionSpeed
     * VPanUse
     * EventUseEndTransition
     * EventUseTransition
     * <------------------------------------------------------------------------------------->
     * VALUE LIST: Stores all the values used by the cameras. There should never be more than one of the same value
     * Section Length
     * Values
    */
    #endregion

    public class LCPC
    {
        public LCPC(string LCPP) //Compressing
        {
            LCPP lcpp = new LCPP(LCPP);

            FileStream lcpcFile;
            try
            {
                lcpcFile = new FileStream(LCPP+".LCPC", FileMode.Create);
            }
            catch (Exception)
            {
                throw new System.IO.IOException("The file could not be accessed for writing.");
            }

            lcpcFile.Write(new byte[4] { 0x4C, 0x43, 0x50, 0x43 }, 0, 4);
            lcpcFile.Write(new byte[1] { (byte)lcpp.enc.GetBytes(lcpp.Name).Length }, 0, 1);
            lcpcFile.Write(lcpp.enc.GetBytes(lcpp.Name), 0, lcpp.enc.GetBytes(lcpp.Name).Length);
            lcpcFile.Write(new byte[1] { (byte)lcpp.enc.GetBytes(lcpp.Creator).Length }, 0, 1);
            lcpcFile.Write(lcpp.enc.GetBytes(lcpp.Creator), 0, lcpp.enc.GetBytes(lcpp.Creator).Length);
            byte[] ToWrite = System.BitConverter.GetBytes(lcpp.CameraCount);
            Array.Reverse(ToWrite);
            lcpcFile.Write(ToWrite, 0, 4); //Number of cameras

            List<Value> ValListA = new List<Value>();

            for (int i = 0; i < lcpp.CameraCount; i++)
            {
                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.Version))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.Version));

                if (!ValListA.Any(C => C.String == lcpp.EntryList[i].Properties.Identification))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.Identification));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.Num))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.Num));

                if (!ValListA.Any(C => C.String == lcpp.EntryList[i].Properties.Type))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.Type));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.RotationX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.RotationX));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.RotationY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.RotationY));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.RotationZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.RotationZ));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.Zoom))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.Zoom));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.DPDRotation))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.DPDRotation));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.TransitionSpeed))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.TransitionSpeed));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.EndTransitionSpeed))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.EndTransitionSpeed));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.GroundMoveSpeed))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.GroundMoveSpeed));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.UseDPAD))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UseDPAD));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.UnknownNum2))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownNum2));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.MaxY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.MaxY));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.MinY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.MinY));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.GroundStartMoveDelay))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.GroundStartMoveDelay));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.AirStartMoveDelay))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.AirStartMoveDelay));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.UnknownUDown))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownUDown));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.UnknownLOffset))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownLOffset));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.UnknownLOffsetV))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownLOffsetV));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.UpperBorder))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UpperBorder));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.LowerBorder))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.LowerBorder));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.EventFrames))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.EventFrames));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.EventPriority))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.EventPriority));


                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.FixpointOffsetX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.FixpointOffsetX));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.FixpointOffsetY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.FixpointOffsetY));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.FixpointOffsetZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.FixpointOffsetZ));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.WorldPointX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.WorldPointX));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.WorldPointY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.WorldPointY));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.WorldPointZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.WorldPointZ));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.PlayerOffsetX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.PlayerOffsetX));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.PlayerOffsetY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.PlayerOffsetY));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.PlayerOffsetZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.PlayerOffsetZ));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.VPanAxisX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.VPanAxisX));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.VPanAxisY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.VPanAxisY));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.VPanAxisZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.VPanAxisZ));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.UnknownUpX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownUpX));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.UnknownUpY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownUpY));

                if (!ValListA.Any(C => C.Number == lcpp.EntryList[i].Properties.UnknownUpZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownUpZ));


                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.DisableReset))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.DisableReset));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.FlagLOffsetRPOff))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.FlagLOffsetRPOff));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.DisableAntiBlur))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.DisableAntiBlur));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.DisableCollision))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.DisableCollision));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.DisablePOV))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.DisablePOV));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.GFlagEndErpFrame))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.GFlagEndErpFrame));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.GFlagThrough))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.GFlagThrough));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.GFlagEndTransitionSpeed))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.GFlagEndTransitionSpeed));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.VPanUse))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.VPanUse));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.EventUseEndTransition))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.EventUseEndTransition));

                if (!ValListA.Any(C => C.Boolean == lcpp.EntryList[i].Properties.EventUseTransition))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.EventUseTransition));
            }

            int count = 0;
            foreach (Value v in ValListA)
            {
                count += v.GetSize();
            }

            byte[] Buffer = new byte[count];
            List<byte> Reffub = new List<byte>();
            foreach (Value v in ValListA)
            {
                Reffub.AddRange(v.GetBytes());
            }
            for (int i = 0; i < Buffer.Length; i++)
            {
                Buffer[i] = Reffub[i];
            }

            for (int i = 0; i < lcpp.CameraCount; i++)
            {
                int[] offsets = new int[51];
                //lcpp.EntryList[i].Properties
                int offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.Version)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[0] = offsetcount;
                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].String == lcpp.EntryList[i].Properties.Identification)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[1] = offsetcount;
                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.Num)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[2] = offsetcount;
                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].String == lcpp.EntryList[i].Properties.Type)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[3] = offsetcount;
            }


        }
    }

    public class Value
    {
        public float Number;
        public string String;
        public bool Boolean;

        public int length = 0;
        public bool IsNumber = false;

        public Value(int x) { Number = x; IsNumber = true; }
        public Value(float x) { Number = x; IsNumber = true; }
        public Value(string x) => String = x;
        public Value(bool x) => Boolean = x;


        public int GetSize()
        {
            if (IsNumber)
            {
                length = 4;
            }
            else if (String == null)
            {
                length = 1;
            }
            else
            {
                length = System.Text.Encoding.GetEncoding(932).GetByteCount(String);
            }
            return length;
        }

        public List<byte> GetBytes()
        {
            List<byte> x = new List<byte>();
            byte[] y;
            if (IsNumber)
            {
                byte[] ToWrite = BitConverter.GetBytes(Number);
                Array.Reverse(ToWrite);
                y = ToWrite;
            }
            else if (String == null)
            {
                if (Boolean)
                    y = new byte[1] { 0x01 };
                else
                    y = new byte[1] { 0x00 };
            }
            else
            {
                y = System.Text.Encoding.GetEncoding(932).GetBytes(String);
            }
            for (int i = 0; i < y.Length; i++)
            {
                x.Add(y[i]);
            }

            return x;
        }
    }
}
