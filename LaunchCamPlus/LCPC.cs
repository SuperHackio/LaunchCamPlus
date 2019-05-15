using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using LCPPManager;

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
    
    /// <summary>
    /// The Compressed Version of the Launch Cam Plus Preset (LCPP)
    /// </summary>
    public class LCPC
    {
        public LCPP LCPP;
        /// <summary>
        /// Compresses a pre-existing LCPP file
        /// </summary>
        /// <param name="LCPP">Path to the LCPP</param>
        public LCPC(string LCPP)
        {
            LCPP lcpp = new LCPP(LCPP);

            FileStream lcpcFile;
            try
            {
                lcpcFile = new FileStream(lcpp.File.FullName.Replace(lcpp.File.Extension,".lcpc"), FileMode.Create);
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
                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.Version))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.Version));

                if (!ValListA.Any(C => C.String == lcpp.EntryList[i].Properties.Identification))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.Identification));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.Num))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.Num));

                if (!ValListA.Any(C => C.String == lcpp.EntryList[i].Properties.Type))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.Type));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.RotationX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.RotationX));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.RotationY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.RotationY));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.RotationZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.RotationZ));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.Zoom))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.Zoom));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.DPDRotation))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.DPDRotation));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.TransitionSpeed))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.TransitionSpeed));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.EndTransitionSpeed))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.EndTransitionSpeed));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.GroundMoveSpeed))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.GroundMoveSpeed));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.UseDPAD))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UseDPAD));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.UnknownNum2))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownNum2));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.MaxY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.MaxY));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.MinY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.MinY));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.GroundStartMoveDelay))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.GroundStartMoveDelay));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.AirStartMoveDelay))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.AirStartMoveDelay));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.UnknownUDown))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownUDown));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.FrontZoom))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.FrontZoom));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.HeightZoom))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.HeightZoom));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.UpperBorder))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UpperBorder));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.LowerBorder))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.LowerBorder));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.EventFrames))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.EventFrames));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.EventPriority))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.EventPriority));


                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.FixpointOffsetX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.FixpointOffsetX));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.FixpointOffsetY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.FixpointOffsetY));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.FixpointOffsetZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.FixpointOffsetZ));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.WorldPointX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.WorldPointX));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.WorldPointY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.WorldPointY));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.WorldPointZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.WorldPointZ));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.PlayerOffsetX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.PlayerOffsetX));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.PlayerOffsetY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.PlayerOffsetY));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.PlayerOffsetZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.PlayerOffsetZ));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.VPanAxisX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.VPanAxisX));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.VPanAxisY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.VPanAxisY));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.VPanAxisZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.VPanAxisZ));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.UnknownUpX))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownUpX));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.UnknownUpY))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownUpY));

                if (!ValListA.Any(C => C.IsNumber && C.Number == lcpp.EntryList[i].Properties.UnknownUpZ))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.UnknownUpZ));


                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.DisableReset))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.DisableReset));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.SharpZoom))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.SharpZoom));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.DisableAntiBlur))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.DisableAntiBlur));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.DisableCollision))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.DisableCollision));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.DisableFirstPerson))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.DisableFirstPerson));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.GFlagEndErpFrame))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.GFlagEndErpFrame));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.GFlagThrough))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.GFlagThrough));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.GFlagEndTransitionSpeed))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.GFlagEndTransitionSpeed));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.VPanUse))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.VPanUse));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.EventUseEndTransition))
                    ValListA.Add(new Value(lcpp.EntryList[i].Properties.EventUseEndTransition));

                if (!ValListA.Any(C => C.IsBool && C.Boolean == lcpp.EntryList[i].Properties.EventUseTransition))
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

            List<int[]> ValueOffsets = new List<int[]>();
            List<byte> Bufferer = new List<byte>();

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

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.RotationX)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[4] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.RotationY)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[5] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.RotationZ)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[6] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.Zoom)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[7] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.DPDRotation)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[8] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.TransitionSpeed)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[9] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.EndTransitionSpeed)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[10] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.GroundMoveSpeed)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[11] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.UseDPAD)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[12] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.UnknownNum2)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[13] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.MaxY)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[14] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.MinY)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[15] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.GroundStartMoveDelay)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[16] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.AirStartMoveDelay)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[17] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.UnknownUDown)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[18] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.FrontZoom)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[19] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.HeightZoom)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[20] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.UpperBorder)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[21] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.LowerBorder)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[22] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.EventFrames)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[23] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.EventPriority)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[24] = offsetcount;


                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.FixpointOffsetX)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[25] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.FixpointOffsetY)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[26] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.FixpointOffsetZ)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[27] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.WorldPointX)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[28] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.WorldPointY)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[29] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.WorldPointZ)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[30] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.PlayerOffsetX)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[31] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.PlayerOffsetY)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[32] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.PlayerOffsetZ)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[33] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.VPanAxisX)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[34] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.VPanAxisY)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[35] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.VPanAxisZ)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[36] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.UnknownUpX)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[37] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.UnknownUpY)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[38] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsNumber && ValListA[j].Number == lcpp.EntryList[i].Properties.UnknownUpZ)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[39] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.DisableReset)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[40] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.SharpZoom)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[41] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.DisableAntiBlur)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[42] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.DisableCollision)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[43] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.DisableFirstPerson)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[44] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.GFlagEndErpFrame)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[45] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.GFlagThrough)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[46] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.GFlagEndTransitionSpeed)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[47] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.VPanUse)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[48] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.EventUseEndTransition)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[49] = offsetcount;

                offsetcount = 0;
                for (int j = 0; j < ValListA.Count; j++)
                {
                    if (ValListA[j].IsBool && ValListA[j].Boolean == lcpp.EntryList[i].Properties.EventUseTransition)
                        break;
                    else
                        offsetcount += ValListA[j].length;
                }
                offsets[50] = offsetcount;

                ValueOffsets.Add(offsets);
            }

            foreach (int[] IA in ValueOffsets)
            {
                for (int i = 0; i < IA.Length; i++)
                {
                    byte[] TMP = BitConverter.GetBytes(IA[i]);
                    Array.Reverse(TMP);
                    Bufferer.AddRange(TMP);
                }
            }

            ToWrite = System.BitConverter.GetBytes((int)lcpcFile.Length + 4 + Bufferer.Count);
            Array.Reverse(ToWrite);
            lcpcFile.Write(ToWrite, 0, 4);

            foreach (byte BOI in Bufferer)
                lcpcFile.WriteByte(BOI);

            lcpcFile.Write(Buffer, 0, Buffer.Length);

            lcpcFile.Close();
        }
        /// <summary>
        /// Decompresses a LCPC file
        /// </summary>
        /// <param name="LCPC">File to Decompress</param>
        public LCPC(FileStream LCPCFile)
        {
            LCPP = new LCPP();

            byte[] Read = new byte[4];
            LCPCFile.Read(Read, 0, 4);

            int stringlength = LCPCFile.ReadByte();
            Read = new byte[stringlength];
            LCPCFile.Read(Read, 0, stringlength);
            LCPP.Name = LCPP.enc.GetString(Read);

            stringlength = LCPCFile.ReadByte();
            Read = new byte[stringlength];
            LCPCFile.Read(Read, 0, stringlength);
            LCPP.Creator = LCPP.enc.GetString(Read);
            
            Read = new byte[4];
            LCPCFile.Read(Read, 0, 4);
            Array.Reverse(Read);
            LCPP.CameraCount = BitConverter.ToInt32(Read, 0);
            
            LCPCFile.Read(Read, 0, 4);
            Array.Reverse(Read);
            long Offset = BitConverter.ToInt32(Read, 0);

            for (int i = 0; i < LCPP.CameraCount; i++)
            {
                Cameras.Camera Added = new Cameras.Camera()
                {
                    Version = (int)FindNumber(LCPCFile, Offset),
                    Identification = FindString(LCPCFile, Offset, LCPP.enc),
                    Num = (int)FindNumber(LCPCFile, Offset),
                    Type = FindString(LCPCFile, Offset, LCPP.enc),
                    RotationX = FindNumber(LCPCFile, Offset),
                    RotationY = FindNumber(LCPCFile, Offset),
                    RotationZ = FindNumber(LCPCFile, Offset),
                    Zoom = FindNumber(LCPCFile, Offset),
                    DPDRotation = FindNumber(LCPCFile, Offset),
                    TransitionSpeed = (int)FindNumber(LCPCFile, Offset),
                    EndTransitionSpeed = (int)FindNumber(LCPCFile, Offset),
                    GroundMoveSpeed = (int)FindNumber(LCPCFile, Offset),
                    UseDPAD = FindBoolean(LCPCFile, Offset),
                    UnknownNum2 = FindBoolean(LCPCFile, Offset),
                    MaxY = FindNumber(LCPCFile, Offset),
                    MinY = FindNumber(LCPCFile, Offset),
                    GroundStartMoveDelay = (int)FindNumber(LCPCFile, Offset),
                    AirStartMoveDelay = (int)FindNumber(LCPCFile, Offset),
                    UnknownUDown = (int)FindNumber(LCPCFile, Offset),
                    FrontZoom = FindNumber(LCPCFile, Offset),
                    HeightZoom = FindNumber(LCPCFile, Offset),
                    UpperBorder = FindNumber(LCPCFile, Offset),
                    LowerBorder = FindNumber(LCPCFile, Offset),
                    EventFrames = (int)FindNumber(LCPCFile, Offset),
                    EventPriority = (int)FindNumber(LCPCFile, Offset),
                    FixpointOffsetX = FindNumber(LCPCFile, Offset),
                    FixpointOffsetY = FindNumber(LCPCFile, Offset),
                    FixpointOffsetZ = FindNumber(LCPCFile, Offset),
                    WorldPointX = FindNumber(LCPCFile, Offset),
                    WorldPointY = FindNumber(LCPCFile, Offset),
                    WorldPointZ = FindNumber(LCPCFile, Offset),
                    PlayerOffsetX = FindNumber(LCPCFile, Offset),
                    PlayerOffsetY = FindNumber(LCPCFile, Offset),
                    PlayerOffsetZ = FindNumber(LCPCFile, Offset),
                    VPanAxisX = FindNumber(LCPCFile, Offset),
                    VPanAxisY = FindNumber(LCPCFile, Offset),
                    VPanAxisZ = FindNumber(LCPCFile, Offset),
                    UnknownUpX = FindNumber(LCPCFile, Offset),
                    UnknownUpY = FindNumber(LCPCFile, Offset),
                    UnknownUpZ = FindNumber(LCPCFile, Offset),
                    DisableReset = FindBoolean(LCPCFile, Offset),
                    SharpZoom = FindBoolean(LCPCFile, Offset),
                    DisableAntiBlur = FindBoolean(LCPCFile, Offset),
                    DisableCollision = FindBoolean(LCPCFile, Offset),
                    DisableFirstPerson = FindBoolean(LCPCFile, Offset),
                    GFlagEndErpFrame = FindBoolean(LCPCFile, Offset),
                    GFlagThrough = FindBoolean(LCPCFile, Offset),
                    GFlagEndTransitionSpeed = FindBoolean(LCPCFile, Offset),
                    VPanUse = FindBoolean(LCPCFile, Offset),
                    EventUseEndTransition = FindBoolean(LCPCFile, Offset),
                    EventUseTransition = FindBoolean(LCPCFile, Offset),
                };
                LCPP.EntryList.Add(new Entry(Added));
                LCPP.PresetList.Add(Added);
            }

            LCPCFile.Close();
        }

        private float FindNumber(FileStream LCPCFile, long ValuesOffset)
        {
            byte[] Read = new byte[4];
            LCPCFile.Read(Read, 0, 4);
            Array.Reverse(Read);
            long Valueoffset = BitConverter.ToInt32(Read, 0);
            long currentpos = LCPCFile.Position;
            LCPCFile.Seek(ValuesOffset+Valueoffset,SeekOrigin.Begin);

            LCPCFile.Read(Read, 0, 4);
            Array.Reverse(Read);

            LCPCFile.Position = currentpos;

            return BitConverter.ToSingle(Read,0);
        }
        private string FindString(FileStream LCPCFile, long ValuesOffset, System.Text.Encoding enc)
        {
            byte[] Read = new byte[4];
            LCPCFile.Read(Read, 0, 4);
            Array.Reverse(Read);
            long Valueoffset = BitConverter.ToInt32(Read, 0);
            long currentpos = LCPCFile.Position;
            LCPCFile.Seek(ValuesOffset + Valueoffset, SeekOrigin.Begin);

            List<byte> ReadString = new List<byte>();
            while (LCPCFile.ReadByte()!=0x00)
            {
                LCPCFile.Position--;
                ReadString.Add((byte)LCPCFile.ReadByte());

                if (LCPCFile.Position > LCPCFile.Length)
                    throw new IOException("Failed to read the file. It may be corrupted");
            }
            Read = new byte[ReadString.Count];
            ReadString.CopyTo(Read);

            LCPCFile.Position = currentpos;

            return enc.GetString(Read);
        }
        private bool FindBoolean(FileStream LCPCFile, long ValuesOffset)
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
    }
    /// <summary>
    /// A Value
    /// </summary>
    public class Value
    {
        public float Number;
        public string String;
        public bool Boolean;

        public int length = 0;
        public bool IsNumber = false;
        public bool IsBool = false;

        public Value(int x) { Number = x; IsNumber = true; }
        public Value(float x) { Number = x; IsNumber = true; }
        public Value(string x) => String = x;
        public Value(bool x) { Boolean = x; IsBool = true; }

        public int GetSize()
        {
            if (IsNumber)
            {
                length = 4;
            }
            else if (IsBool)
            {
                length = 1;
            }
            else
            {
                length = System.Text.Encoding.GetEncoding(932).GetByteCount(String)+1;
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
            else if (IsBool)
            {
                if (Boolean)
                    y = new byte[1] { 0x01 };
                else
                    y = new byte[1] { 0x00 };
            }
            else
            {
                y = System.Text.Encoding.GetEncoding(932).GetBytes(String+"\0");
            }

            for (int i = 0; i < y.Length; i++)
            {
                x.Add(y[i]);
            }

            return x;
        }
    }
}
