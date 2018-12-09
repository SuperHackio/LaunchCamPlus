using System;
using System.Collections.Generic;
using System.IO;

namespace BCSV_Editor
{
    public class BCSVHeader
    {
        public UInt32 entryCount;
        public UInt32 fieldCount;
        public UInt32 dataOffset;
        public UInt32 entryDataSize;

        public BCSVHeader()
        {

        }

        public BCSVHeader(FileStream bcsvFile, Byte mode)
        {
            if (mode == 0) /* Read */
            {
                this.Read(bcsvFile);
            }
        }

        /// <summary>
        /// Reads a BCSV File
        /// </summary>
        /// <param name="bcsvFile">The BCSV file's Header</param>
        public void Read(FileStream bcsvFile)
        {
            //FileStream bcsvFile = new FileStream(fileName, FileMode.Open);

            Byte[] entryCountString = new Byte[4];
            bcsvFile.Read(entryCountString, 0, 4);
            Array.Reverse(entryCountString);
            this.entryCount = System.BitConverter.ToUInt32(entryCountString, 0);

            Byte[] fieldCountString = new Byte[4];
            bcsvFile.Seek(4, SeekOrigin.Begin);
            bcsvFile.Read(fieldCountString, 0, 4);
            Array.Reverse(fieldCountString);
            this.fieldCount = System.BitConverter.ToUInt32(fieldCountString, 0);

            Byte[] dataOffsetString = new Byte[4];
            bcsvFile.Seek(8, SeekOrigin.Begin);
            bcsvFile.Read(dataOffsetString, 0, 4);
            Array.Reverse(dataOffsetString);
            this.dataOffset = System.BitConverter.ToUInt32(dataOffsetString, 0);

            Byte[] entryDataSizeString = new Byte[4];
            bcsvFile.Seek(12, SeekOrigin.Begin);
            bcsvFile.Read(entryDataSizeString, 0, 4);
            Array.Reverse(entryDataSizeString);
            this.entryDataSize = System.BitConverter.ToUInt32(entryDataSizeString, 0);

            //bcsvFile.Close();
        }

    }

    public class BCSVField
    {
        public UInt32 nameHash;
        public UInt32 mask;
        public UInt16 dataOffset;
        public Byte shiftVal;
        public Byte dataType;

        public BCSVField(FileStream bcsvFile, UInt32 offs, Byte mode)
        {
            if (mode == 0)
            {
                this.Read(bcsvFile, offs);
            }
        }

        public BCSVField()
        {
        }

        /// <summary>
        /// Reads a BCSV File
        /// </summary>
        /// <param name="bcsvFile">The BCSV file's Fields</param>
        public void Read(FileStream bcsvFile, UInt32 offs)
        {
            //FileStream bcsvFile = new FileStream(fileName, FileMode.Open);

            Byte[] nameHashString = new Byte[4];
            bcsvFile.Seek(offs, SeekOrigin.Begin);
            bcsvFile.Read(nameHashString, 0, 4);
            Array.Reverse(nameHashString);
            this.nameHash = System.BitConverter.ToUInt32(nameHashString, 0);

            Byte[] maskString = new Byte[4];
            bcsvFile.Seek(offs + 4, SeekOrigin.Begin);
            bcsvFile.Read(maskString, 0, 4);
            Array.Reverse(maskString);
            this.mask = System.BitConverter.ToUInt32(maskString, 0);

            Byte[] dataOffsetString = new Byte[2];
            bcsvFile.Seek(offs + 8, SeekOrigin.Begin);
            bcsvFile.Read(dataOffsetString, 0, 2);
            Array.Reverse(dataOffsetString);
            this.dataOffset = System.BitConverter.ToUInt16(dataOffsetString, 0);

            Byte[] shiftValString = new Byte[1];
            bcsvFile.Seek(offs + 10, SeekOrigin.Begin);
            bcsvFile.Read(shiftValString, 0, 1);
            this.shiftVal = shiftValString[0];

            Byte[] dataTypeString = new Byte[1];
            bcsvFile.Seek(offs + 11, SeekOrigin.Begin);
            bcsvFile.Read(dataTypeString, 0, 1);
            this.dataType = dataTypeString[0];

            //bcsvFile.Close();
        }
    }

    public class BCSVEntry
    {
        public Object[] data;
        public Byte[] dataType;
        public Byte[] changed; //0: Unchanged, 1: Changed
        public UInt32[] offset; //Offset within file, relative to start of file
        public Byte[] size;
        public UInt32[] stringOffs;

        public BCSVEntry(FileStream bcsvFile, UInt32 dataOffset, UInt32 entryNum, BCSVField[] fieldList, UInt32 fieldCount, UInt32 entryDataSize, UInt32 stringOffset, Byte mode)
        {
            if (mode == 0)
            {
                this.Read(bcsvFile, dataOffset, entryNum, fieldList, fieldCount, entryDataSize, stringOffset);
            }
        }

        public BCSVEntry()
        {
        }

        /// <summary>
        /// Reads a BCSV File
        /// </summary>
        /// <param name="bcsvFile">The BCSV file's Entries</param>
        public void Read(FileStream bcsvFile, UInt32 dataOffset, UInt32 entryNum, BCSVField[] fieldList, UInt32 fieldCount, UInt32 entryDataSize, UInt32 stringOffset)
        {
            UInt32 i;

            //FileStream bcsvFile = new FileStream(fileName, FileMode.Open);
            this.data = new Object[fieldCount];
            this.dataType = new Byte[fieldCount];
            this.changed = new Byte[fieldCount];
            this.offset = new UInt32[fieldCount];
            this.size = new Byte[fieldCount];
            this.stringOffs = new UInt32[fieldCount];

            //bcsvFile.Seek(((entryNum + 1) * dataOffset), SeekOrigin.Begin);
                       

            for (i = 0; i < fieldCount; i++)
            {
                //MessageBox.Show(Convert.ToString(dataOffset + fieldList[i].dataOffset));
                this.offset[i] = dataOffset + fieldList[i].dataOffset;
                bcsvFile.Seek(dataOffset + fieldList[i].dataOffset, SeekOrigin.Begin);
                this.dataType[i] = fieldList[i].dataType;
                this.changed[i] = 0;
                switch (fieldList[i].dataType)
                {
                    case 0: //S32
                        size[i] = 4;
                        stringOffs[i] = 0;
                        Byte[] s32String = new Byte[4];
                        bcsvFile.Read(s32String, 0, 4);
                        Array.Reverse(s32String);
                        this.data[i] = System.BitConverter.ToInt32(s32String, 0);
                        break;
                    case 2: //Float
                        size[i] = 4;
                        stringOffs[i] = 0;
                        Byte[] floatString = new Byte[4];
                        bcsvFile.Read(floatString, 0, 4);
                        Array.Reverse(floatString);
                        this.data[i] = System.BitConverter.ToSingle(floatString, 0);
                        break;
                    case 3: //S32
                        size[i] = 4;
                        stringOffs[i] = 0;
                        Byte[] s32String2 = new Byte[4];
                        bcsvFile.Read(s32String2, 0, 4);
                        Array.Reverse(s32String2);
                        this.data[i] = System.BitConverter.ToInt32(s32String2, 0);
                        break;
                    case 4: //S16
                        size[i] = 2;
                        stringOffs[i] = 0;
                        Byte[] s16String = new Byte[4];
                        bcsvFile.Read(s16String, 0, 4);
                        Array.Reverse(s16String);
                        this.data[i] = System.BitConverter.ToInt16(s16String, 0);
                        break;
                    case 5: //S8
                        size[i] = 1;
                        stringOffs[i] = 0;
                        Byte[] s8String = new Byte[1];
                        bcsvFile.Read(s8String, 0, 1);
                        //Array.Reverse(s8String);
                        this.data[i] = s8String[0];
                        break;
                    case 6: //String
                        UInt32 strCount = 0;
                        Byte[] strOffsString = new Byte[4];
                        bcsvFile.Read(strOffsString, 0, 4);
                        Array.Reverse(strOffsString);
                        UInt32 strOffs = new UInt32();
                        strOffs = System.BitConverter.ToUInt32(strOffsString, 0);
                        this.stringOffs[i] = strOffs;

                        bcsvFile.Seek(stringOffset + strOffs, SeekOrigin.Begin);

                        //MessageBox.Show(Convert.ToString(stringOffset + strOffs));

                        List<SByte> bytes = new List<SByte>();
                        String str;
                        //Byte[] b = new Byte[1];
                        //bcsvFile.Read(
                        //Int32 bval; 
                        
                        while (bcsvFile.ReadByte() != 0)
                        {
                            bcsvFile.Seek(stringOffset + strOffs + strCount, SeekOrigin.Begin);
                            bytes.Add((SByte)bcsvFile.ReadByte());
                            //MessageBox.Show(Convert.ToString(b[0]));
                            //String tmpString = System.Text.Encoding.ASCII.GetString(b, 0, 1);
                            //b = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(tmpString);
                            //str = string.Concat(str, System.Text.Encoding.ASCII.GetString(b));
                            //bval = bcsvFile.ReadByte();
                            //MessageBox.Show(Convert.ToString(bval));
                            strCount++;
                            if (strCount > 1000)
                            {
                                throw new IOException("An error has occurred while reading the BCSV");
                            }
                        }
                        /*Byte[] zero = new Byte[1];
                        zero[0] = 0;
                        str = string.Concat(str, System.Text.Encoding.ASCII.GetString(zero));*/
                        //MessageBox.Show(Convert.ToString(strCount));
                        //MessageBox.Show(bytes.ToArray()[0].ToString());
                        unsafe
                        {
                            fixed (SByte* strData = bytes.ToArray())
                            {
                                str = new String(strData, 0, bytes.ToArray().Length, System.Text.Encoding.GetEncoding("Shift-JIS"));
                            }
                        }
                        //str = System.Text.Encoding.GetEncoding("Shift-JIS").GetString(bytes.ToArray());
                        this.data[i] = str;
                        this.size[i] = (Byte)strCount;
                        break;
                }
                //System.Windows.Forms.MessageBox.Show(Convert.ToString(dataOffset));
                //dataOffset += entryDataSize;
                //System.Windows.Forms.MessageBox.Show(Convert.ToString(dataOffset));
            }
            //bcsvFile.Close();
        }


    }

    public class BCSV
    {
        public BCSVHeader header;
        public BCSVField[] fieldList = new BCSVField[1];
        public BCSVEntry[] entryList = new BCSVEntry[1];
        public String fileName = new String((Char)0, 1);
        public Byte[] rawStartData;
        public String rawEndDataString;
        public Byte[] rawEndData;
        public UInt32 rawEndDataSize;
        public UInt32 oldI;
        public UInt32 oldJ;
        
        public BCSV()
        {
        }

        public BCSV(String fileName, Byte mode)
        {
            if (mode == 0)
            {
                this.Read(fileName);
            }
        }

        /// <summary>
        /// Makes a new BCSV Object
        /// </summary>
        /// <param name="fileName">Input BCSV file</param>
        public void Read(String fileName)
        {
            UInt32 i;
            UInt32 j;

            FileStream bcsvFile = new FileStream(fileName, FileMode.Open);
            this.fileName = fileName;
                                     
            this.header = new BCSVHeader(bcsvFile, 0);
            Array.Resize(ref this.fieldList, (Int32)header.fieldCount);

            for (i = 0; i < this.header.fieldCount; i++)
            {                    
                this.fieldList[i] = new BCSVField(bcsvFile, 16 + (i * 12), 0);
            }

            bcsvFile.Seek(16, SeekOrigin.Begin);

            this.rawStartData = new Byte[(12 * (this.header.fieldCount))];
            bcsvFile.Read(this.rawStartData, 0, (Int32)(12 * (this.header.fieldCount)));

            Array.Resize(ref this.entryList, (Int32)header.entryCount);
            UInt32 dataOffset = this.header.dataOffset;

            UInt32 stringOffset = this.header.dataOffset + (this.header.entryCount * this.header.entryDataSize);

            for (i = 0; i < header.entryCount; i++)
            {
                this.entryList[i] = new BCSVEntry(bcsvFile, dataOffset, i, this.fieldList, this.header.fieldCount, this.header.entryDataSize, stringOffset, 0);
                dataOffset += this.header.entryDataSize;
                //dataOffset += 8;
            }

            for (i = 0; i < header.entryCount; i++)
            {
                for (j = 0; j < header.fieldCount; j++)
                {
                    if (this.entryList[i].dataType[j] == 6)
                    {
                        rawEndDataSize += (UInt32)Convert.ToString(this.entryList[i].data[j]).Length;
                    }
                }
            }
            
            bcsvFile.Close();
            
        }

        /// <summary>
        /// Writes the BCSV Object to a file
        /// </summary>
        public void Write(List<string> CameraTypeList, List<string> CameraIDList, string File = "")
        {
            UInt32 i, j, k;
            Byte[] tempData;
            if (File=="")
            {
                File = this.fileName;
            }

            FileStream bcsvFile;

            try
            {
                bcsvFile = new FileStream(File, FileMode.Create);
            }
            catch (Exception)
            {
                throw new System.IO.IOException("The file could not be written. This could be caused by the fact that the file is open in another program.");
            }

            #region Write the Header
            tempData = new Byte[4];
            tempData = System.BitConverter.GetBytes((Int32)this.header.entryCount);
            Array.Reverse(tempData);
            bcsvFile.Write(tempData, 0, 4);

            tempData = new Byte[4];
            tempData = System.BitConverter.GetBytes((Int32)this.header.fieldCount);
            Array.Reverse(tempData);
            bcsvFile.Write(tempData, 0, 4);

            tempData = new Byte[4];
            tempData = System.BitConverter.GetBytes((Int32)this.header.dataOffset);
            Array.Reverse(tempData);
            bcsvFile.Write(tempData, 0, 4);

            tempData = new Byte[4];
            tempData = System.BitConverter.GetBytes((Int32)this.header.entryDataSize);
            Array.Reverse(tempData);
            bcsvFile.Write(tempData, 0, 4);
            #endregion

            Byte[] Tempclomp;
            #region Write the Fields
            for (int L = 0; L < 52; L++)
            {
                tempData = new Byte[4];
                tempData = System.BitConverter.GetBytes((Int32)this.fieldList[L].nameHash);
                Array.Reverse(tempData);
                bcsvFile.Write(tempData, 0, 4);

                tempData = new Byte[4];
                tempData = System.BitConverter.GetBytes((Int32)this.fieldList[L].mask);
                Array.Reverse(tempData);
                bcsvFile.Write(tempData, 0, 4);

                Tempclomp = new Byte[4];

                tempData = new Byte[4];
                tempData = System.BitConverter.GetBytes((Int32)this.fieldList[L].dataOffset);
                Array.Reverse(tempData);
                Tempclomp[0] = tempData[2];
                Tempclomp[1] = tempData[3];

                tempData = new Byte[4];
                tempData = System.BitConverter.GetBytes((Int32)this.fieldList[L].shiftVal);
                Array.Reverse(tempData);
                Tempclomp[2] = tempData[3];

                tempData = new Byte[4];
                tempData = System.BitConverter.GetBytes((Int32)this.fieldList[L].dataType);
                Array.Reverse(tempData);
                Tempclomp[3] = tempData[3];

                bcsvFile.Write(Tempclomp, 0, 4);
            }



            //bcsvFile.Write(this.rawStartData, 0, (Int32)(12 * (this.header.fieldCount)));
            //bcsvFile.Seek((Int32)(16 + (12 * (this.header.fieldCount))), SeekOrigin.Begin);
            #endregion

            for (i = 0; i < this.header.entryCount; i++)
            {
                Byte[] entryBuffer = new Byte[this.header.entryDataSize];
                for (j = 0; j < this.header.fieldCount; j++)
                {
                    switch (this.entryList[i].dataType[j])
                    {
                        case 0: //S32
                            tempData = new Byte[this.entryList[i].size[j]];
                            tempData = System.BitConverter.GetBytes((Int32)this.entryList[i].data[j]);
                            Array.Reverse(tempData);
                            //bcsvFile.Write(System.BitConverter.GetBytes(System.BitConverter.ToInt32(tempData, 0)), 0, this.entryList[i].size[j]);
                            for (k = 0; k < 4; k++) 
                            {
                                Buffer.SetByte(entryBuffer, (Int32)this.fieldList[j].dataOffset + (Int32)k, tempData[k]);
                            }
                            break;
                        case 2: //Float
                            tempData = new Byte[this.entryList[i].size[j]];
                            tempData = System.BitConverter.GetBytes(Convert.ToSingle(this.entryList[i].data[j]));
                            Array.Reverse(tempData);
                            //bcsvFile.Write(System.BitConverter.GetBytes(System.BitConverter.ToSingle(tempData, 0)), 0, this.entryList[i].size[j]);
                            for (k = 0; k < 4; k++)
                            {
                                Buffer.SetByte(entryBuffer, (Int32)this.fieldList[j].dataOffset + (Int32)k, tempData[k]);
                            }
                            break;
                        case 3: //S32
                            tempData = new Byte[this.entryList[i].size[j]];
                            tempData = System.BitConverter.GetBytes((Int32)this.entryList[i].data[j]);
                            Array.Reverse(tempData);
                            //bcsvFile.Write(System.BitConverter.GetBytes(System.BitConverter.ToInt32(tempData, 0)), 0, this.entryList[i].size[j]);
                            for (k = 0; k < 4; k++)
                            {
                                Buffer.SetByte(entryBuffer, (Int32)this.fieldList[j].dataOffset + (Int32)k, tempData[k]);
                            }
                            break;
                        case 4: //S16
                            tempData = new Byte[this.entryList[i].size[j]];
                            tempData = System.BitConverter.GetBytes((Int16)this.entryList[i].data[j]);
                            Array.Reverse(tempData);
                            //bcsvFile.Write(System.BitConverter.GetBytes(System.BitConverter.ToInt16(tempData, 0)), 0, this.entryList[i].size[j]);
                            for (k = 0; k < 2; k++)
                            {
                                Buffer.SetByte(entryBuffer, (Int32)this.fieldList[j].dataOffset + (Int32)k, tempData[k]);
                            }
                            break;
                        case 5: //Byte
                            tempData = new Byte[this.entryList[i].size[j]];
                            tempData = System.BitConverter.GetBytes((Byte)this.entryList[i].data[j]);
                            Array.Reverse(tempData);
                            //bcsvFile.Write(System.BitConverter.GetBytes(tempData[0]), 0, this.entryList[i].size[j]);
                            Buffer.SetByte(entryBuffer, (Int32)this.fieldList[j].dataOffset, tempData[0]);
                            break;
                        case 6: //String
                            tempData = new Byte[4];
                            tempData = System.BitConverter.GetBytes((UInt32)this.entryList[i].stringOffs[j]);
                            Array.Reverse(tempData);
                            //MessageBox.Show(Convert.ToString(this.entryList[i].size[j]));
                            //bcsvFile.Write(System.BitConverter.GetBytes(System.BitConverter.ToUInt32(tempData, 0)), 0, 4);
                            for (k = 0; k < 4; k++)
                            {
                                Buffer.SetByte(entryBuffer, (Int32)this.fieldList[j].dataOffset + (Int32)k, tempData[k]);
                            }
                            break;
                    }
                }
                bcsvFile.Write(entryBuffer, 0, (Int32)this.header.entryDataSize);
                /*for (k = 0; k < this.header.entryDataSize; k++)
                {
                    MessageBox.Show(Convert.ToString(entryBuffer[k]));
                }*/
                
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
                    {
                        bcsvFile.WriteByte(Convert.ToByte(':'));
                    }
                }
                //bcsvFile.Write(enc.GetBytes(s), 0, s.Length);
                //bcsvFile.Write(enc.GetBytes("\0"), 0, 1);
                bcsvFile.WriteByte(0x00);
            }



            //for (i = 0; i < this.header.entryCount; i++)
            //{
            //    for (j = 0; j < this.header.fieldCount; j++)
            //    {
            //        if (this.entryList[i].dataType[j] == 6)
            //        {
            //            //MessageBox.Show(this.entryList[i].data[j].ToString().Length.ToString());
            //            
             //           bcsvFile.Write(enc.GetBytes(this.entryList[i].data[j].ToString()), 0, (Int32)this.entryList[i].data[j].ToString().Length);
             //           bcsvFile.Write(enc.GetBytes("\0"), 0, 1);
            //        }
            //    }
            //}
            #endregion

            UInt32 numPadding = (UInt32)16-(UInt32)(bcsvFile.Position % 16);
            Byte[] padding = new Byte[numPadding];
            for (i = 0; i < numPadding; i++)
            {
                padding[i] = 64;
            }
            bcsvFile.Write(padding, 0, (Int32)numPadding);

            bcsvFile.Close();
        }
    }
}