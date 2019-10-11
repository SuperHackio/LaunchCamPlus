using Hackio.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace BCSV_Editor
{
    public class BCSVHeader
    {
        public uint entryCount;
        public uint fieldCount;
        public uint dataOffset;
        public uint entryDataSize;

        public BCSVHeader()
        {

        }

        public BCSVHeader(FileStream bcsvFile, byte mode)
        {
            if (mode == 0) /* Read */
            {
                Read(bcsvFile);
            }
        }

        /// <summary>
        /// Reads a BCSV File
        /// </summary>
        /// <param name="bcsvFile">The BCSV file's Header</param>
        public void Read(FileStream bcsvFile)
        {
            //FileStream bcsvFile = new FileStream(fileName, FileMode.Open);

            byte[] entryCountString = new byte[4];
            bcsvFile.Read(entryCountString, 0, 4);
            Array.Reverse(entryCountString);
            entryCount = System.BitConverter.ToUInt32(entryCountString, 0);

            byte[] fieldCountString = new byte[4];
            bcsvFile.Seek(4, SeekOrigin.Begin);
            bcsvFile.Read(fieldCountString, 0, 4);
            Array.Reverse(fieldCountString);
            fieldCount = System.BitConverter.ToUInt32(fieldCountString, 0);

            byte[] dataOffsetString = new byte[4];
            bcsvFile.Seek(8, SeekOrigin.Begin);
            bcsvFile.Read(dataOffsetString, 0, 4);
            Array.Reverse(dataOffsetString);
            dataOffset = System.BitConverter.ToUInt32(dataOffsetString, 0);

            byte[] entryDataSizeString = new byte[4];
            bcsvFile.Seek(12, SeekOrigin.Begin);
            bcsvFile.Read(entryDataSizeString, 0, 4);
            Array.Reverse(entryDataSizeString);
            entryDataSize = System.BitConverter.ToUInt32(entryDataSizeString, 0);

            //bcsvFile.Close();
        }

    }

    public class BCSVField
    {
        public uint nameHash;
        public uint mask;
        public ushort dataOffset;
        public byte shiftVal;
        public byte dataType;

        public BCSVField(FileStream bcsvFile, uint offs, byte mode)
        {
            if (mode == 0)
            {
                Read(bcsvFile, offs);
            }
        }

        public BCSVField()
        {
        }

        /// <summary>
        /// Reads a BCSV File
        /// </summary>
        /// <param name="bcsvFile">The BCSV file's Fields</param>
        public void Read(FileStream bcsvFile, uint offs)
        {
            //FileStream bcsvFile = new FileStream(fileName, FileMode.Open);

            byte[] nameHashString = new byte[4];
            bcsvFile.Seek(offs, SeekOrigin.Begin);
            bcsvFile.Read(nameHashString, 0, 4);
            Array.Reverse(nameHashString);
            nameHash = System.BitConverter.ToUInt32(nameHashString, 0);

            byte[] maskString = new byte[4];
            bcsvFile.Seek(offs + 4, SeekOrigin.Begin);
            bcsvFile.Read(maskString, 0, 4);
            Array.Reverse(maskString);
            mask = System.BitConverter.ToUInt32(maskString, 0);

            byte[] dataOffsetString = new byte[2];
            bcsvFile.Seek(offs + 8, SeekOrigin.Begin);
            bcsvFile.Read(dataOffsetString, 0, 2);
            Array.Reverse(dataOffsetString);
            dataOffset = System.BitConverter.ToUInt16(dataOffsetString, 0);

            byte[] shiftValString = new byte[1];
            bcsvFile.Seek(offs + 10, SeekOrigin.Begin);
            bcsvFile.Read(shiftValString, 0, 1);
            shiftVal = shiftValString[0];

            byte[] dataTypeString = new byte[1];
            bcsvFile.Seek(offs + 11, SeekOrigin.Begin);
            bcsvFile.Read(dataTypeString, 0, 1);
            dataType = dataTypeString[0];

            //bcsvFile.Close();
        }
    }

    public class BCSVEntry
    {
        public object[] data;
        public byte[] dataType;
        public byte[] changed; //0: Unchanged, 1: Changed
        public uint[] offset; //Offset within file, relative to start of file
        public byte[] size;
        public uint[] stringOffs;

        public BCSVEntry(FileStream bcsvFile, uint dataOffset, uint entryNum, BCSVField[] fieldList, uint fieldCount, uint entryDataSize, uint stringOffset, byte mode)
        {
            if (mode == 0)
            {
                Read(bcsvFile, dataOffset, entryNum, fieldList, fieldCount, entryDataSize, stringOffset);
            }
        }

        public BCSVEntry()
        {
        }

        /// <summary>
        /// Reads a BCSV File
        /// </summary>
        /// <param name="bcsvFile">The BCSV file's Entries</param>
        public void Read(FileStream bcsvFile, uint dataOffset, uint entryNum, BCSVField[] fieldList, uint fieldCount, uint entryDataSize, uint stringOffset)
        {
            uint i;

            //FileStream bcsvFile = new FileStream(fileName, FileMode.Open);
            data = new object[fieldCount];
            dataType = new byte[fieldCount];
            changed = new byte[fieldCount];
            offset = new uint[fieldCount];
            size = new byte[fieldCount];
            stringOffs = new uint[fieldCount];

            //bcsvFile.Seek(((entryNum + 1) * dataOffset), SeekOrigin.Begin);
                       

            for (i = 0; i < fieldCount; i++)
            {
                //MessageBox.Show(Convert.ToString(dataOffset + fieldList[i].dataOffset));
                offset[i] = dataOffset + fieldList[i].dataOffset;
                bcsvFile.Seek(dataOffset + fieldList[i].dataOffset, SeekOrigin.Begin);
                dataType[i] = fieldList[i].dataType;
                changed[i] = 0;
                switch (fieldList[i].dataType)
                {
                    case 0: //S32
                        size[i] = 4;
                        stringOffs[i] = 0;
                        byte[] s32String = new byte[4];
                        bcsvFile.Read(s32String, 0, 4);
                        Array.Reverse(s32String);
                        data[i] = System.BitConverter.ToInt32(s32String, 0);
                        break;
                    case 2: //Float
                        size[i] = 4;
                        stringOffs[i] = 0;
                        byte[] floatString = new byte[4];
                        bcsvFile.Read(floatString, 0, 4);
                        Array.Reverse(floatString);
                        data[i] = System.BitConverter.ToSingle(floatString, 0);
                        break;
                    case 3: //S32
                        size[i] = 4;
                        stringOffs[i] = 0;
                        byte[] s32String2 = new byte[4];
                        bcsvFile.Read(s32String2, 0, 4);
                        Array.Reverse(s32String2);
                        data[i] = System.BitConverter.ToInt32(s32String2, 0);
                        break;
                    case 4: //S16
                        size[i] = 2;
                        stringOffs[i] = 0;
                        byte[] s16String = new byte[4];
                        bcsvFile.Read(s16String, 0, 4);
                        Array.Reverse(s16String);
                        data[i] = System.BitConverter.ToInt16(s16String, 0);
                        break;
                    case 5: //S8
                        size[i] = 1;
                        stringOffs[i] = 0;
                        byte[] s8String = new byte[1];
                        bcsvFile.Read(s8String, 0, 1);
                        //Array.Reverse(s8String);
                        data[i] = s8String[0];
                        break;
                    case 6: //String
                        uint strCount = 0;
                        byte[] strOffsString = new byte[4];
                        bcsvFile.Read(strOffsString, 0, 4);
                        Array.Reverse(strOffsString);
                        uint strOffs = new uint();
                        strOffs = System.BitConverter.ToUInt32(strOffsString, 0);
                        stringOffs[i] = strOffs;

                        bcsvFile.Seek(stringOffset + strOffs, SeekOrigin.Begin);

                        data[i] = bcsvFile.ReadString();
                        size[i] = (byte)strCount;
                        break;
                }
            }
        }
    }

    public class BCSV
    {
        public BCSVHeader header;
        public BCSVField[] fieldList = new BCSVField[1];
        public BCSVEntry[] entryList = new BCSVEntry[1];
        public string FileName = new string((char)0, 1);
        public byte[] rawStartData;
        
        public BCSV()
        {
        }

        /// <summary>
        /// Makes a new BCSV Object
        /// </summary>
        /// <param name="fileName">Input BCSV file</param>
        public BCSV(string fileName)
        {
            uint i;

            FileStream bcsvFile = new FileStream(fileName, FileMode.Open);
            FileName = fileName;
                                     
            header = new BCSVHeader(bcsvFile, 0);
            Array.Resize(ref fieldList, (int)header.fieldCount);

            for (i = 0; i < header.fieldCount; i++)
                fieldList[i] = new BCSVField(bcsvFile, 16 + (i * 12), 0);

            bcsvFile.Seek(16, SeekOrigin.Begin);

            rawStartData = new byte[(12 * (header.fieldCount))];
            bcsvFile.Read(rawStartData, 0, (int)(12 * (header.fieldCount)));

            Array.Resize(ref entryList, (int)header.entryCount);
            uint dataOffset = header.dataOffset;

            uint stringOffset = header.dataOffset + (header.entryCount * header.entryDataSize);

            for (i = 0; i < header.entryCount; i++)
            {
                entryList[i] = new BCSVEntry(bcsvFile, dataOffset, i, fieldList, header.fieldCount, header.entryDataSize, stringOffset, 0);
                dataOffset += header.entryDataSize;
            }
            
            bcsvFile.Close();
            
        }

        /// <summary>
        /// Writes the BCSV Object to a file
        /// </summary>
        public void Write(List<string> CameraTypeList, List<string> CameraIDList, string File = "")
        {
            uint i, j, k;
            byte[] tempData;
            if (File=="")
                File = FileName;

            FileStream bcsvFile;

            try
            {
                bcsvFile = new FileStream(File, FileMode.Create);
            }
            catch (Exception e)
            {
                throw new IOException("The BCSV could not be written to. "+e);
            }

            #region Write the Header
            bcsvFile.WriteReverse(BitConverter.GetBytes(header.entryCount), 0, 4);
            bcsvFile.WriteReverse(BitConverter.GetBytes(header.fieldCount), 0, 4);
            bcsvFile.WriteReverse(BitConverter.GetBytes(header.dataOffset), 0, 4);
            bcsvFile.WriteReverse(BitConverter.GetBytes(header.entryDataSize), 0, 4);
            #endregion

            byte[] Tempclomp;
            #region Write the Fields
            for (int L = 0; L < 52; L++)
            {
                bcsvFile.WriteReverse(BitConverter.GetBytes(fieldList[L].nameHash), 0, 4);
                bcsvFile.WriteReverse(BitConverter.GetBytes(fieldList[L].mask), 0, 4);

                Tempclomp = new byte[4];

                tempData = new byte[4];
                tempData = System.BitConverter.GetBytes((int)fieldList[L].dataOffset);
                Array.Reverse(tempData);
                Tempclomp[0] = tempData[2];
                Tempclomp[1] = tempData[3];

                tempData = new byte[4];
                tempData = System.BitConverter.GetBytes((int)fieldList[L].shiftVal);
                Array.Reverse(tempData);
                Tempclomp[2] = tempData[3];

                tempData = new byte[4];
                tempData = System.BitConverter.GetBytes((int)fieldList[L].dataType);
                Array.Reverse(tempData);
                Tempclomp[3] = tempData[3];

                bcsvFile.Write(Tempclomp, 0, 4);
            }



            //bcsvFile.Write(this.rawStartData, 0, (Int32)(12 * (this.header.fieldCount)));
            //bcsvFile.Seek((Int32)(16 + (12 * (this.header.fieldCount))), SeekOrigin.Begin);
            #endregion

            for (i = 0; i < header.entryCount; i++)
            {
                byte[] entryBuffer = new byte[header.entryDataSize];
                for (j = 0; j < header.fieldCount; j++)
                {
                    switch (entryList[i].dataType[j])
                    {
                        case 0: //S32
                            tempData = new byte[entryList[i].size[j]];
                            tempData = System.BitConverter.GetBytes((int)entryList[i].data[j]);
                            Array.Reverse(tempData);
                            for (k = 0; k < 4; k++)
                                Buffer.SetByte(entryBuffer, fieldList[j].dataOffset + (int)k, tempData[k]);
                            break;
                        case 2: //Float
                            tempData = new byte[entryList[i].size[j]];
                            tempData = System.BitConverter.GetBytes(Convert.ToSingle(entryList[i].data[j]));
                            Array.Reverse(tempData);
                            for (k = 0; k < 4; k++)
                                Buffer.SetByte(entryBuffer, fieldList[j].dataOffset + (int)k, tempData[k]);
                            break;
                        case 3: //S32
                            tempData = new byte[entryList[i].size[j]];
                            tempData = System.BitConverter.GetBytes((int)entryList[i].data[j]);
                            Array.Reverse(tempData);
                            for (k = 0; k < 4; k++)
                                Buffer.SetByte(entryBuffer, fieldList[j].dataOffset + (int)k, tempData[k]);
                            break;
                        case 4: //S16
                            tempData = new byte[entryList[i].size[j]];
                            tempData = System.BitConverter.GetBytes((short)entryList[i].data[j]);
                            Array.Reverse(tempData);
                            for (k = 0; k < 2; k++)
                                Buffer.SetByte(entryBuffer, fieldList[j].dataOffset + (int)k, tempData[k]);
                            break;
                        case 5: //Byte
                            Buffer.SetByte(entryBuffer, fieldList[j].dataOffset, (byte)entryList[i].data[j]);
                            break;
                        case 6: //String
                            tempData = new byte[4];
                            tempData = System.BitConverter.GetBytes(entryList[i].stringOffs[j]);
                            Array.Reverse(tempData);
                            for (k = 0; k < 4; k++)
                                Buffer.SetByte(entryBuffer, fieldList[j].dataOffset + (int)k, tempData[k]);
                            break;
                    }
                }
                bcsvFile.Write(entryBuffer, 0, (int)header.entryDataSize);
                
            } //Write the Data

            #region Write Strings
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding(932);

            foreach (string s in CameraTypeList)
            {
                bcsvFile.Write(enc.GetBytes(s), 0, s.Length);
                bcsvFile.Write(enc.GetBytes("\0"), 0, 1);
            }
            foreach (string s in CameraIDList)
            {
                string[] sa = s.Split(':');
                for (int si = 0; si < sa.Length; si++)
                {
                    bcsvFile.Write(enc.GetBytes(sa[si]), 0, enc.GetBytes(sa[si]).Length);
                    if (si != sa.Length -1)
                        bcsvFile.WriteByte(Convert.ToByte(':'));
                }
                bcsvFile.WriteByte(0x00);
            }
            #endregion

            uint numPadding = 16 - (uint)(bcsvFile.Position % 16);
            byte[] padding = new byte[numPadding];
            for (i = 0; i < numPadding; i++)
                padding[i] = 64;
            bcsvFile.Write(padding, 0, (int)numPadding);

            bcsvFile.Close();
        }
    }
}