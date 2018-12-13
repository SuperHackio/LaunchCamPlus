using System;
using System.Collections.Generic;
using System.IO;
using Cameras;

namespace LCPPManager
{
    #region Format Documentation
    /*
     * LCPP is LaunchCamPlus's Preset file format made for adding pre-built presets easily.
     * <------------------------------------------------------------------------------------->
     * HEADER: Always A0 bytes total
     * Format => byte[4] {4C, 43, 50, 50} "LCPP"
     * File Version => byte[2]
     * Version of LaunchCamPlus => byte[A] {56, 65, 72, <LCP version in bytes>}
     * Name of preset => byte[48] {<Limit 40 bytes (64 characters. should be enough)>} Note: Unused bytes are written in as 0x00
     * Preset Creator => byte[48] {<Limit 40 bytes (64 characters. should be enough)>} Note: Unused bytes are written in as 0x00
     * Number of cameras => byte[4] {<number of camera entries>}
     * Padding => byte[] {25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25}
     * <------------------------------------------------------------------------------------->
     * ENTRIES: Size Varies
     * Entry Length => byte[4] {<length in bytes to the next camera>}
     * Camera => byte[?] {Version, Identification, Type, RotationX, RotationY, RotationZ, Zoom, DPDRotation, TransitionSpeed, EndTransitionSpeed, GroundMoveSpeed = 160, UseDPAD, UnknownNum2, MaxY, MinY, GroundStartMoveDelay, AirStartMoveDelay, UnknownUDown, UnknownLOffset, UnknownLOffsetV, UpperBorder, LowerBorder, EventFrames, EventPriority, FixpointOffsetX, FixpointOffsetY, FixpointOffsetZ, WorldPointX, WorldPointY, WorldPointZ, PlayerOffsetX, PlayerOffsetY, PlayerOffsetZ, VPanAxisX, VPanAxisY, VPanAxisZ, UnknownUpX, UnknownUpY, UnknownUpZ, DisableReset, FlagLOffsetRPOff, DisableAntiBlur, DisableCollision, DisablePOV, GFlagEndErpFrame, GFlagThrough, GFlagEndTransitionSpeed, VPanUse, EventUseEndTransition, EventUseTransition}
    */
    #endregion

    public class LCPP
    {
        public int CameraCount;
        public List<Camera> PresetList;

        public List<Entry> EntryList = new List<Entry>();
        System.Text.Encoding enc = System.Text.Encoding.GetEncoding(932);

        /// <summary>
        /// Writes a LCPP file
        /// </summary>
        /// <param name="filename">string</param>
        /// <param name="CamList">CameraList</param>
        public LCPP(string filename, List<Camera> CamList, string PresetName = "Untitled", string PresetCreator = "Unknown") //Write
        {
            for (int i = 0; i < CamList.Count; i++)
            {
                EntryList.Add(new Entry(CamList[i],enc));
            }

            FileStream lcppFile;
            try
            {
                lcppFile = new FileStream(filename, FileMode.Create);
            }
            catch (Exception)
            {
                throw new System.IO.IOException("The file could not be accessed for writing.");
            }

            byte[] ToWrite;
            byte[] tmp;
            #region Write the Header
            lcppFile.Write(new byte[4] { 0x4C, 0x43, 0x50, 0x50 }, 0, 4); //Format
            lcppFile.Write(new byte[2] { 0x00, 0x02 }, 0, 2); //File Version

            ToWrite = new byte[10];
            
            tmp = enc.GetBytes(System.Windows.Forms.Application.ProductVersion);
            ToWrite[0] = 0x56;
            ToWrite[1] = 0x65;
            ToWrite[2] = 0x72;
            for (int i = 3; i < 10; i++)
            {
                ToWrite[i] = tmp[i - 3];
            }
            lcppFile.Write(ToWrite, 0, 10); //Version of LaunchCamPlus

            ToWrite = new byte[48];
            tmp = enc.GetBytes(PresetName);
            for (int i = 0; i < enc.GetBytes(PresetName).Length; i++)
            {
                ToWrite[i] = tmp[i];
            }
            lcppFile.Write(ToWrite, 0, 48); //Name of preset

            ToWrite = new byte[48];
            tmp = enc.GetBytes(PresetCreator);
            for (int i = 0; i < enc.GetBytes(PresetCreator).Length; i++)
            {
                ToWrite[i] = tmp[i];
            }
            lcppFile.Write(ToWrite, 0, 48); //Preset Creator

            ToWrite = System.BitConverter.GetBytes(CamList.Count);
            Array.Reverse(ToWrite);
            lcppFile.Write(ToWrite, 0, 4); //Number of cameras

            ToWrite = new byte[] { 0x25, 0x25, 0x25, 0x25, 0x25, 0x25, 0x25, 0x25, 0x25, 0x25, 0x25, 0x25 };
            lcppFile.Write(ToWrite, 0, ToWrite.Length); //Padding
            #endregion

            #region Write the Entries
            foreach (Entry entry in EntryList)
            {
                ToWrite = System.BitConverter.GetBytes(entry.length);
                Array.Reverse(ToWrite);
                lcppFile.Write(ToWrite, 0, 4);
                lcppFile.Write(enc.GetBytes(entry.write), 0, entry.length);
            }
            #endregion

            #region Write some Padding
            UInt32 numPadding = (UInt32)16 - (UInt32)(lcppFile.Position % 16);
            Byte[] padding = new Byte[numPadding];
            for (int i = 0; i < numPadding; i++)
            {
                padding[i] = 0x7C;
            }
            lcppFile.Write(padding, 0, (Int32)numPadding);
            #endregion

            lcppFile.Close();
        }
        /// <summary>
        /// Reads a LCPP file
        /// </summary>
        /// <param name="filename">string</param>
        public LCPP(string filename)//Read
        {
            string format;
            int version;
            string LCPVersion;
            string PresetName;
            string Creator;
            int cameranum;
            int nextoffset=0;

            FileStream lcppFile;
            try
            {
                lcppFile = new FileStream(filename, FileMode.Open);
            }
            catch (Exception)
            {
                throw new System.IO.IOException("The file could not be accessed for reading.");
            }
            byte[] ToRead = new byte[4]; //Format
            lcppFile.Read(ToRead, 0, 4);
            format = enc.GetString(ToRead);
            ToRead = new byte[2]; //Version
            lcppFile.Read(ToRead, 0, 2);
            version = Convert.ToInt32(ToRead[0]+ToRead[1]);
            ToRead = new byte[10]; //Version of LaunchCamPlus
            lcppFile.Read(ToRead, 0, 10);
            LCPVersion = enc.GetString(ToRead);
            ToRead = new byte[49]; //Preset Name
            lcppFile.Read(ToRead, 0, 48);
            PresetName = enc.GetString(ToRead).Replace("\0","");
            ToRead = new byte[49]; //Preset Creator
            lcppFile.Read(ToRead, 0, 48);
            Creator = enc.GetString(ToRead).Replace("\0", "");
            ToRead = new byte[4]; //Number of Cameras
            lcppFile.Read(ToRead, 0, 4);
            cameranum = Convert.ToInt32(ToRead[0] + ToRead[1] + ToRead[2] + ToRead[3]);
            ToRead = new byte[12]; //Padding
            lcppFile.Read(ToRead, 0, 12);
            //<------------------------------------------------------------------------------------------>
            for (int i = 0; i < cameranum; i++)
            {
                ToRead = new byte[4];
                lcppFile.Read(ToRead, 0, 4);
                Array.Reverse(ToRead);
                nextoffset = System.BitConverter.ToInt32(ToRead,0);
                ToRead = new byte[nextoffset];
                lcppFile.Read(ToRead, 0, nextoffset);
                EntryList.Add(new Entry(enc.GetString(ToRead)));
            }

            lcppFile.Close();
        }
    }

    public class Entry
    {
        public Camera Properties;
        public int length;
        public string write = "";

        /// <summary>
        /// Makes a Writeable entry
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="encoder"></param>
        public Entry(Camera camera, System.Text.Encoding encoder)
        {
            Properties = camera;
            write = "Version=" + Properties.Version + ",Identification=\"" + Properties.Identification +"\",Num="+Properties.Num + ",Type=\"" + Properties.Type + "\",RotationX=" + Properties.RotationX.ToString().Replace(',','.')+"f,RotationY=" + Properties.RotationY.ToString().Replace(',', '.') +
                "f,RotationZ="+Properties.RotationZ.ToString().Replace(',', '.') + "f,Zoom="+Properties.Zoom+"f,DPDRotation="+Properties.DPDRotation+",TransitionSpeed="+Properties.TransitionSpeed+",EndTransitionSpeed="+
                Properties.EndTransitionSpeed+",GroundMoveSpeed="+Properties.GroundMoveSpeed+",UseDPAD="+Properties.UseDPAD+",UnknownNum2="+Properties.UnknownNum2+",MaxY="+Properties.MaxY+",MinY="+Properties.MinY+
                ",GroundStartMoveDelay="+Properties.GroundStartMoveDelay+",AirStartMoveDelay="+Properties.AirStartMoveDelay+",UnknownUDown="+Properties.UnknownUDown+",UnknownLOffset="+Properties.UnknownLOffset+
                ",UnknownLOffsetV="+Properties.UnknownLOffsetV+",UpperBorder="+Properties.UpperBorder.ToString().Replace(',', '.') + "f,LowerBorder="+Properties.LowerBorder.ToString().Replace(',', '.') + "f,EventFrames="+Properties.EventFrames+",EventPriority="+Properties.EventPriority+
                ",FixpointOffsetX="+Properties.FixpointOffsetX+",FixpointOffsetY="+Properties.FixpointOffsetX+",FixpointOffsetZ="+Properties.FixpointOffsetZ+",WorldPointX="+Properties.WorldPointX+",WorldPointY="+Properties.WorldPointY+
                ",WorldPointZ="+Properties.WorldPointZ+",PlayerOffsetX="+Properties.PlayerOffsetX+",PlayerOffsetY="+Properties.PlayerOffsetY+",PlayerOffsetZ="+Properties.PlayerOffsetZ+",VPanAxisX="+Properties.VPanAxisX+
                ",VPanAxisY="+Properties.VPanAxisY+",VPanAxisZ="+Properties.VPanAxisZ+",UnknownUpX="+Properties.UnknownUpX+",UnknownUpY="+Properties.UnknownUpY+",UnknownUpZ="+Properties.UnknownUpZ+",DisableReset="+Properties.DisableReset+
                ",FlagLOffsetRPOff="+Properties.FlagLOffsetRPOff+",DisableAntiBlur="+Properties.DisableAntiBlur+",DisableCollision="+Properties.DisableCollision+",DisablePOV="+Properties.DisablePOV+",GFlagEndErpFrame="+Properties.GFlagEndErpFrame+
                ",GFlagThrough="+Properties.GFlagThrough+",GFlagEndTransitionSpeed="+Properties.GFlagEndTransitionSpeed+",VPanUse="+Properties.VPanUse+",EventUseEndTransition="+Properties.EventUseEndTransition+",EventUseTransition="+Properties.EventUseTransition;
            length = encoder.GetBytes(write).Length;
            write = write.Replace("False","false");
            write = write.Replace("True", "true");
        }

        /// <summary>
        /// Makes an Entry from a File
        /// </summary>
        /// <param name="FromFile"></param>
        public Entry(string FromFile)
        {
            string[] Props;
            Properties = new Camera(0);
            Props = FromFile.Split(',');

            string[] P;
            for (int i = 0; i < Props.Length; i++)
            {
                P = Props[i].Split('=');
                switch (P[0])
                {
                    case "Version":
                        Properties.Version = Convert.ToInt32(P[1]);
                        break;
                    case "Identification":
                        Properties.Identification = P[1].Replace("\"","");
                        break;
                    case "Num":
                        Properties.Num = Convert.ToInt32(P[1]);
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
                        Properties.DPDRotation = Convert.ToSingle(P[1]);
                        break;
                    case "TransitionSpeed":
                        Properties.TransitionSpeed = Convert.ToInt32(P[1]);
                        break;
                    case "EndTransitionSpeed":
                        Properties.EndTransitionSpeed = Convert.ToInt32(P[1]);
                        break;
                    case "GroundMoveSpeed":
                        Properties.GroundMoveSpeed = Convert.ToInt32(P[1]);
                        break;
                    case "UseDPAD":
                        Properties.UseDPAD = P[1] == "True" ? true : false;
                        break;
                    case "UnknownNum2":
                        Properties.UnknownNum2 = P[1] == "True" ? true : false;
                        break;
                    case "MaxY":
                        Properties.MaxY = Convert.ToSingle(P[1]);
                        break;
                    case "MinY":
                        Properties.MinY = Convert.ToSingle(P[1]);
                        break;
                    case "GroundStartMoveDelay":
                        Properties.GroundStartMoveDelay = Convert.ToInt32(P[1]);
                        break;
                    case "AirStartMoveDelay":
                        Properties.AirStartMoveDelay = Convert.ToInt32(P[1]);
                        break;
                    case "UnknownUDown":
                        Properties.UnknownUDown = Convert.ToInt32(P[1]);
                        break;
                    case "UnknownLOffset":
                        Properties.UnknownLOffset = Convert.ToSingle(P[1]);
                        break;
                    case "UnknownLOffsetV":
                        Properties.UnknownLOffsetV = Convert.ToSingle(P[1]);
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
                        Properties.FixpointOffsetX = Convert.ToSingle(P[1]);
                        break;
                    case "FixpointOffsetY":
                        Properties.FixpointOffsetY = Convert.ToSingle(P[1]);
                        break;
                    case "FixpointOffsetZ":
                        Properties.FixpointOffsetZ = Convert.ToSingle(P[1]);
                        break;
                    case "WorldPointX":
                        Properties.WorldPointX = Convert.ToSingle(P[1]);
                        break;
                    case "WorldPointY":
                        Properties.WorldPointY = Convert.ToSingle(P[1]);
                        break;
                    case "WorldPointZ":
                        Properties.WorldPointZ = Convert.ToSingle(P[1]);
                        break;
                    case "PlayerOffsetX":
                        Properties.PlayerOffsetX = Convert.ToSingle(P[1]);
                        break;
                    case "PlayerOffsetY":
                        Properties.PlayerOffsetY = Convert.ToSingle(P[1]);
                        break;
                    case "PlayerOffsetZ":
                        Properties.PlayerOffsetZ = Convert.ToSingle(P[1]);
                        break;
                    case "VPanAxisX":
                        Properties.VPanAxisX = Convert.ToSingle(P[1]);
                        break;
                    case "VPanAxisY":
                        Properties.VPanAxisY = Convert.ToSingle(P[1]);
                        break;
                    case "VPanAxisZ":
                        Properties.VPanAxisZ = Convert.ToSingle(P[1]);
                        break;
                    case "UnknownUpX":
                        Properties.UnknownUpX = Convert.ToSingle(P[1]);
                        break;
                    case "UnknownUpY":
                        Properties.UnknownUpY = Convert.ToSingle(P[1]);
                        break;
                    case "UnknownUpZ":
                        Properties.UnknownUpZ= Convert.ToSingle(P[1]);
                        break;
                    case "DisableReset":
                        Properties.DisableReset = P[1] == "True" ? true : false;
                        break;
                    case "DisableDPAD":
                        Properties.SetDPADUse();
                        break;
                    case "FlagLOffsetRPOff":
                        Properties.FlagLOffsetRPOff = P[1] == "True" ? true : false;
                        break;
                    case "DisableAntiBlur":
                        Properties.DisableAntiBlur = P[1] == "True" ? true : false;
                        break;
                    case "DisableCollision":
                        Properties.DisableCollision = P[1] == "True" ? true : false;
                        break;
                    case "DisablePOV":
                        Properties.DisablePOV = P[1] == "True" ? true : false;
                        break;
                    case "GFlagEndErpFrame":
                        Properties.GFlagEndErpFrame= P[1] == "True" ? true : false;
                        break;
                    case "GFlagThrough":
                        Properties.GFlagThrough = P[1] == "True" ? true : false;
                        break;
                    case "GFlagEndTransitionSpeed":
                        Properties.GFlagEndTransitionSpeed = P[1] == "True" ? true : false;
                        break;
                    case "VPanUse":
                        Properties.VPanUse = P[1] == "True" ? true : false;
                        break;
                    case "EventUseEndTransition":
                        Properties.EventUseEndTransition = P[1] == "True" ? true : false;
                        break;
                    case "EventUseTransition":
                        Properties.EventUseTransition = P[1] == "True" ? true : false;
                        break;
                    default: System.Windows.Forms.MessageBox.Show("Sorry, but this Preset file is corrupted or outdated","LCPP Error"); return;
                }
            }


        }

        /// <summary>
        /// Get the Camera
        /// </summary>
        /// <returns>Camera</returns>
        public Camera RetrieveCameraSettings(int camnum = 0)
        {
            Properties.ListID = camnum;
            return Properties;
        }
    }
}
