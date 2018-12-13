using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// 
/// </summary>
namespace RARCFiles
{
    public class RARC
    {
        public Header Header;
        public List<Directory> Directories = new List<Directory>();
        public List<FileEntry> Files = new List<FileEntry>();
        public StringTable StringTable; //Note: each string is seperated by 0x00
        public List<FileData> Data = new List<FileData>();

        public RARC(System.IO.FileStream rarcFile)
        {
            rarcFile.Position = 0;
            Header = new Header(rarcFile);
            if (Header.Format == "YAZ0")
            {
                return;
            }
            for (int i = 0; i < Header.NumberOfDirectoryNodes; i++)
            {
                Directories.Add(new Directory(rarcFile, Header));
            }
            //------------------------------------------------------------------------------>
            byte[] Trash = new byte[16];
            rarcFile.Read(Trash,0,16);
            //------------------------------------------------------------------------------>
            for (int i = 0; i < Header.NumberOfFiles; i++)
            {
                Files.Add(new FileEntry(rarcFile));
            }
            Trash = new byte[4];
            rarcFile.Seek(Header.OffsetToStrings, System.IO.SeekOrigin.Begin);
            //------------------------------------------------------------------------------>
            //String time
            byte[] stringbytes = new byte[Header.StringTableSize];
            rarcFile.Read(stringbytes, 0, Header.StringTableSize);
            string t = Encoding.ASCII.GetString(stringbytes);
            string[] strung = t.Split('\0');
            StringTable = new StringTable(strung);
            //Ok that wasn't too bad actually...
            //------------------------------------------------------------------------------>
            foreach (FileEntry FE in this.Files)
            {
                if (FE.Type[1]!=0x02)
                {
                    Data.Add(new FileData(rarcFile, FE, Header));
                }
            }
        }

        public RARC() { }

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

        public void WriteToFile(FileStream rarcFile,byte[] replacement)
        {
            List<long> offsetlist = new List<long>();

            rarcFile.Write(new byte[4] { 52, 41, 52, 43 }, 0, 4);//Magic
            offsetlist.Add(rarcFile.Position);
            rarcFile.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4);//File Size (temporary)
            rarcFile.Write(new byte[4] { 0x00, 0x00, 0x00, 0x20 }, 0, 4);//Unknown

            byte[] WriteMe = new byte[4];

            offsetlist.Add(rarcFile.Position);
            rarcFile.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4);//File Data offset

            offsetlist.Add(rarcFile.Position);
            rarcFile.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4);//File Data Size (temporary)
            offsetlist.Add(rarcFile.Position);
            rarcFile.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4);//File Data Size (temporary)

            rarcFile.Write(new byte[4] { 0x00, 0x00, 0x00, 0x00 }, 0, 4);//Unknown
            rarcFile.Write(new byte[4] { 0x00, 0x00, 0x00, 0x00 }, 0, 4);//Unknown

            WriteMe = new byte[4];
            WriteMe = BitConverter.GetBytes(Header.NumberOfDirectoryNodes); //Directory count
            Array.Reverse(WriteMe);
            rarcFile.Write(WriteMe, 0, 4);

            WriteMe = new byte[4];
            WriteMe = BitConverter.GetBytes(Header.OffsetToDirectoryNodes - 0x20); //Offset to directories
            Array.Reverse(WriteMe);
            rarcFile.Write(WriteMe, 0, 4);

            WriteMe = new byte[4];
            WriteMe = BitConverter.GetBytes(Header.NumberOfFiles); //Number of files
            Array.Reverse(WriteMe);
            rarcFile.Write(WriteMe, 0, 4);

            offsetlist.Add(rarcFile.Position);
            rarcFile.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4); //offset to files

            offsetlist.Add(rarcFile.Position);
            rarcFile.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4); //String list Size (temporary)
            offsetlist.Add(rarcFile.Position);
            rarcFile.Write(new byte[4] { 0xFF, 0xFF, 0xFF, 0xFF }, 0, 4); //String list offset (temporary)

            rarcFile.Write(new byte[4] { 0x00, 0x00, 0x00, 0x00 }, 0, 4);//Unknown
            rarcFile.Write(new byte[4] { 0x00, 0x00, 0x00, 0x00 }, 0, 4);//PADDING

            WriteMe = new byte[4];
            string shnm = "";
            int count = 0;
            int offsetcount = 5;
            foreach (Directory DIR in Directories)
            {
                shnm = "";
                if (count == 0)
                {
                    WriteMe = Encoding.ASCII.GetBytes("ROOT");
                }
                else
                {
                    try { shnm += DIR.Longname[0]; } catch (Exception) { shnm += ' '; }
                    try { shnm += DIR.Longname[1]; } catch (Exception) { shnm += ' '; }
                    try { shnm += DIR.Longname[2]; } catch (Exception) { shnm += ' '; }
                    try { shnm += DIR.Longname[3]; } catch (Exception) { shnm += ' '; }
                    WriteMe = Encoding.ASCII.GetBytes(shnm.ToUpper());
                }
                rarcFile.Write(WriteMe, 0, 4);//Write shortname

                WriteMe = BitConverter.GetBytes(offsetcount);
                Array.Reverse(WriteMe);
                offsetcount += DIR.Longname.Length + 1;
                rarcFile.Write(WriteMe, 0, 4);

                WriteMe = new byte[2];
                WriteMe = BitConverter.GetBytes(FieldNameToHash(shnm));
                Array.Reverse(WriteMe);
                rarcFile.Write(WriteMe, 0, 2);

                WriteMe = BitConverter.GetBytes(DIR.FileCount);
                Array.Reverse(WriteMe);
                rarcFile.Write(WriteMe, 0, 2);

                WriteMe = new byte[4];
                WriteMe = BitConverter.GetBytes(DIR.OffsetToFirstFile);
                Array.Reverse(WriteMe);
                rarcFile.Write(WriteMe, 0, 4);

                count++;
            }
        }
    }

    public class Header
    {
        public string Format = "RARC";
        public int Filesize;
        public int Unknown1;// (always 0x00000020)
        public int OffsetToFileData;// Minus 0x20 (32)
        public int FileSectionOffset1;
        public int FileSectionOffset2;
        public int Unknown2;// (always 0x00000000)
        public int Unknown3;// (always 0x00000000)
        public int NumberOfDirectoryNodes; 
        public int OffsetToDirectoryNodes;// (always 0x20)
        public int NumberOfFiles;
        public int OffsetToFiles; // Minus 0x20 (32)
        public int StringTableSize;
        public int OffsetToStrings; // Minus 0x20 (32)
        public int Unknown4;
        public byte[] Padding = new byte[4] {0,0,0,0};

        public Header() { }

        /// <summary>
        /// Reads the .rarc
        /// </summary>
        /// <param name="rarcFile">FileStream</param>
        public Header(System.IO.FileStream rarcFile)
        {
            byte[] ReadBytes = new byte[4];
            rarcFile.Read(ReadBytes,0,4);
            if (Encoding.ASCII.GetString(ReadBytes) == "Yaz0")
            {
                Format = "YAZ0";
                return;
            }
            ReadBytes = new byte[4];
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            Filesize = BitConverter.ToInt32(ReadBytes,0);
            ReadBytes = new byte[4];
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            Unknown1 = BitConverter.ToInt32(ReadBytes, 0);
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            OffsetToFileData = BitConverter.ToInt32(ReadBytes, 0);
            OffsetToFileData += 0x20;
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            FileSectionOffset1 = BitConverter.ToInt32(ReadBytes, 0);
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            FileSectionOffset2 = BitConverter.ToInt32(ReadBytes, 0);
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            Unknown2 = BitConverter.ToInt32(ReadBytes, 0);
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            Unknown3 = BitConverter.ToInt32(ReadBytes, 0);
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            NumberOfDirectoryNodes = BitConverter.ToInt32(ReadBytes, 0);
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            OffsetToDirectoryNodes = BitConverter.ToInt32(ReadBytes, 0);
            OffsetToDirectoryNodes += 0x20;
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            NumberOfFiles = BitConverter.ToInt32(ReadBytes, 0);
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            OffsetToFiles = BitConverter.ToInt32(ReadBytes, 0);
            OffsetToFiles += 0x20;
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            StringTableSize = BitConverter.ToInt32(ReadBytes, 0);
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            OffsetToStrings = BitConverter.ToInt32(ReadBytes, 0);
            OffsetToStrings += 0x20;
            rarcFile.Read(ReadBytes, 0, 4);
            Array.Reverse(ReadBytes);
            Unknown4 = BitConverter.ToInt32(ReadBytes, 0);
            rarcFile.Read(ReadBytes, 0, 4);
        }
    }

    public class Directory
    {
        public string ShortName;
        public int OffsetToName;
        public int NameHash;
        public int FileCount;
        public int OffsetToFirstFile;
        public string Longname;

        public Directory(System.IO.FileStream rarcFile, Header head)
        {
            byte[] Read4Bytes = new byte[4];
            byte[] Read2Bytes = new byte[2];
            rarcFile.Read(Read4Bytes, 0, 4);
            ShortName = Encoding.ASCII.GetString(Read4Bytes);
            rarcFile.Read(Read4Bytes, 0, 4);
            Array.Reverse(Read4Bytes);
            OffsetToName = BitConverter.ToInt32(Read4Bytes, 0);
            rarcFile.Read(Read2Bytes, 0, 2);
            Array.Reverse(Read2Bytes);
            NameHash = BitConverter.ToInt16(Read2Bytes, 0);
            rarcFile.Read(Read2Bytes, 0, 2);
            Array.Reverse(Read2Bytes);
            FileCount = BitConverter.ToInt16(Read2Bytes, 0);
            rarcFile.Read(Read4Bytes, 0, 4);
            Array.Reverse(Read4Bytes);
            OffsetToFirstFile = BitConverter.ToInt32(Read4Bytes, 0);

            long savepos = rarcFile.Position;

            rarcFile.Seek(head.OffsetToStrings + OffsetToName, System.IO.SeekOrigin.Begin);
            byte[] tmp = new byte[1];
            while (rarcFile.ReadByte() != 0x00)
            {
                rarcFile.Seek(-1, System.IO.SeekOrigin.Current);
                rarcFile.Read(tmp, 0, 1);
                Longname += Encoding.ASCII.GetString(tmp);
            }

            rarcFile.Position = savepos;
        }
    }

    public class FileEntry
    {
        public int FileID;
        public int FilenameHash;
        public byte[] Type= new byte[2]; // new byte[2] {0x02,0x00} (Subdirectories) | new byte[2] {0x11,0x00} (Files)
        public int FileNameOffset;

        //----------------------------- If this is a file
        public int OffsetToFileData;
        //----------------------------- If this is a directory
        public int FolderIndex;

        //----------------------------- If this is a file
        public int Filesize;
        //----------------------------- If this is a directory
        public byte NodeSize = 0x10;

        public int Unknown;// (0x00000000)

        public FileEntry(System.IO.FileStream rarcFile)
        {
            byte[] Read4Bytes = new byte[4];
            byte[] Read2Bytes = new byte[2];

            rarcFile.Read(Read2Bytes, 0, 2);
            Array.Reverse(Read2Bytes);
            FileID = BitConverter.ToInt16(Read2Bytes,0);
            rarcFile.Read(Read2Bytes, 0, 2);
            Array.Reverse(Read2Bytes);
            FilenameHash = BitConverter.ToInt16(Read2Bytes, 0);
            rarcFile.Read(Read2Bytes, 0, 2);
            Array.Reverse(Read2Bytes);
            Array.Copy(Read2Bytes,Type,2);
            rarcFile.Read(Read2Bytes, 0, 2);
            Array.Reverse(Read2Bytes);
            FileNameOffset = BitConverter.ToInt16(Read2Bytes, 0);
            if ((Type[0] == 0x00)&&(Type[1] == 0x02))
            {
                rarcFile.Read(Read4Bytes, 0, 4);
                Array.Reverse(Read4Bytes);
                FolderIndex = BitConverter.ToInt32(Read4Bytes, 0);
                rarcFile.Read(Read4Bytes, 0, 4);
            }
            else
            {
                rarcFile.Read(Read4Bytes, 0, 4);
                Array.Reverse(Read4Bytes);
                OffsetToFileData = BitConverter.ToInt32(Read4Bytes, 0);
                rarcFile.Read(Read4Bytes, 0, 4);
                Array.Reverse(Read4Bytes);
                Filesize = BitConverter.ToInt32(Read4Bytes, 0);
            }
            byte[] Trash = new byte[4];
            rarcFile.Read(Trash, 0, 4);
        }
    }

    public class StringTable
    {
        public List<string> StringList = new List<string>();
        public List<int> IDList = new List<int>();

        public StringTable(string[] vs)
        {
            for (int i = 0; i < vs.Length; i++)
            {
                StringList.Add(vs[i]);
            }
        }
    }

    public class FileData
    {
        public byte[] Data;
        public string Name = "";
        public string Path = "";
        public int Size = 0;

        public FileData(System.IO.FileStream rarcFile, FileEntry FE, Header head)
        {
            rarcFile.Seek(head.OffsetToFileData + FE.OffsetToFileData, System.IO.SeekOrigin.Begin);
            if (FE.Filesize < 0)
            {
                return;
            }
            Data = new byte[FE.Filesize];
            rarcFile.Read(Data, 0, FE.Filesize);

            rarcFile.Seek(head.OffsetToStrings+FE.FileNameOffset, System.IO.SeekOrigin.Begin);
            byte[] tmp = new byte[1];
            while (rarcFile.ReadByte()!=0x00)
            {
                rarcFile.Seek(-1, System.IO.SeekOrigin.Current);
                rarcFile.Read(tmp, 0, 1);
                Name += Encoding.ASCII.GetString(tmp);
            }
            Size = Data.Length;
        }
    }
}

/// <summary>
/// 
/// </summary>
namespace RARCManagment
{
    public class RARC
    {
        public string originalpath = "";
        public string rootpath = "";
        public string name = "";
        public string ext = "";

        /// <summary>
        /// Read a RARC
        /// </summary>
        /// <param name="rarcFile">string</param>
        public RARC(FileStream rarcFile,FileInfo rarcInfo)
        {
            originalpath = rarcInfo.FullName;
            string[] s = rarcInfo.Name.Split('.');
            name = s[0];
            ext = s[1];
            if (File.Exists(@AppDomain.CurrentDomain.BaseDirectory+ "External Rarc Managment\\RarcDump.exe") && File.Exists(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Yaz0Dec.exe"))
            {
                rarcFile.Position = 0;
                byte[] tmp = new byte[4];
                rarcFile.Read(tmp, 0, 4);
                string type = Encoding.ASCII.GetString(tmp);
                type = type.ToUpper();
                Process cmd;
                if (type == "YAZ0")
                {
                    cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();

                    //cmd.StandardInput.WriteLine("@echo OFF");
                    cmd.StandardInput.WriteLine("\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Yaz0Dec.exe\"" + " \"" + rarcInfo.FullName + "\"");
                    cmd.StandardInput.WriteLine("\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\RarcDump.exe\"" + " \"" + rarcInfo.FullName + " 0.rarc\"");
                    cmd.StandardInput.WriteLine("exit");
                    //cmd.StandardInput.WriteLine("del /q \"" + rarcInfo.FullName + " 0.rarc\"");
                    //cmd.StandardInput.WriteLine("move /y \"" + rarcInfo.Directory.FullName + "\\" + rarcInfo.Name + " 0.rarc_dir\" "+"\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\"");
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    File.WriteAllText(@AppDomain.CurrentDomain.BaseDirectory + "SuperBMDLog.txt", cmd.StandardOutput.ReadToEnd());// (This like of code copied from SuperJSON lol)
                    cmd.WaitForExit();
                    
                    File.Delete(rarcInfo.FullName + " 0.rarc");
                    Directory.Move(rarcInfo.Directory.FullName + "\\" + rarcInfo.Name + " 0.rarc_dir", @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\"+rarcInfo.Name+ " 0.rarc_dir");
                    rootpath = @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment" + "\\" + rarcInfo.Name + " 0.rarc_dir";
                }
                else if (type == "RARC")
                {
                    cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();

                    cmd.StandardInput.WriteLine("\""+@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\RarcDump.exe\""+" \""+rarcInfo.FullName+"\"");
                    cmd.StandardInput.WriteLine("move \"" + rarcInfo.Directory.FullName + "\\" + rarcInfo.Name + "_dir\" " + "\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\"");
                    cmd.StandardInput.WriteLine("All");
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    cmd.WaitForExit();
                    //System.Windows.Forms.MessageBox.Show(cmd.StandardOutput.ReadToEnd());
                    rootpath = @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment" + "\\" + rarcInfo.Name + "_dir";
                }
                else
                {
                    rootpath = null;
                    return;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Something is missing...\nRun the automatic fixer?","Oh no...",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(5000);
                System.Windows.Forms.MessageBox.Show("Oh wait, we don't have an automatic fixer", "This is embarassing...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(5000);
                System.Windows.Forms.MessageBox.Show("Well... This is awkward...", "So...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(5000);
                System.Windows.Forms.MessageBox.Show("So uh, I guess you could try re-dowloading me.", "Yeah, ok.", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(5000);
                System.Windows.Forms.MessageBox.Show("You could also put RarcDump.exe and Yaz0Dec.exe back into the folder?", "Or maybe...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                rootpath = originalpath = null;
                throw new Exception("RarcDump.exe or Yaz0Dec.exe is missing from \""+ @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\"");
            }
        }

        public FileInfo FindFile(string filename)
        {
            string file = "";
            string[] files = Directory.GetFiles(rootpath, "*" + filename, SearchOption.AllDirectories);
            file = files[0];

            return new FileInfo(file);
        }

        public void Return()
        {
            if (File.Exists(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\ArcPack.exe") && File.Exists(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Yaz0Enc.exe"))
            {
                Process cmd;
                cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("@echo off");
                cmd.StandardInput.WriteLine("rename "+ "\"" + rootpath + "\" " + name);
                cmd.StandardInput.WriteLine("\""+@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\ArcPack.exe\" \""+ @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\"+name+"\\stage\"");
                cmd.StandardInput.WriteLine("move \"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + name + "\\stage.arc\" \""+@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\"");
                //File.Move(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + name + "\\stage.arc", @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + name);
                cmd.StandardInput.WriteLine("\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Yaz0Enc.exe\" \"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + "stage.arc\"");
                //cmd.StandardInput.WriteLine("del /q \""+ @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + name + ".arc\"");
                //cmd.StandardInput.WriteLine("rename \""+ @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + name + ".arc.yaz0\" "+name+".arc");
                cmd.StandardInput.WriteLine("exit");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                File.WriteAllText(@AppDomain.CurrentDomain.BaseDirectory + "SuperBMDLog.txt", cmd.StandardOutput.ReadToEnd());// (This like of code copied from SuperJSON lol)
                cmd.WaitForExit();
                File.Delete(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + "stage.arc");
                File.Move(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + "stage" + ".arc.yaz0", @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + name + ".arc");
                File.Delete(originalpath);
                File.Move(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + name + ".arc",originalpath);
                Directory.Move(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + name,rootpath);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Something is missing...\nRun the automatic fixer?", "Oh no...", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(5000);
                System.Windows.Forms.MessageBox.Show("Oh wait, we don't have an automatic fixer", "This is embarassing...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(5000);
                System.Windows.Forms.MessageBox.Show("Well... This is awkward...", "So...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(5000);
                System.Windows.Forms.MessageBox.Show("So uh, I guess you could try re-dowloading me.", "Yeah, ok.", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                System.Threading.Thread.Sleep(5000);
                System.Windows.Forms.MessageBox.Show("You could also put ArcPack.exe and Yaz0Enc.exe back into the folder?", "Or maybe...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                rootpath = originalpath = null;
                throw new Exception("ArcPack.exe or Yaz0Enc.exe is missing from \"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\"");
            }
        }
    }
}

/// <summary>
/// 
/// </summary>
namespace MilkyEditor.Filesystem
{
    public class BinaryReaderBE : BinaryReader
    {
        public BinaryReaderBE(Stream s)
            : base(s)
        { }

        public BinaryReaderBE(Stream s, Encoding e)
            : base(s, e)
        { }


        public override short ReadInt16()
        {
            UInt16 val = base.ReadUInt16();
            return (Int16)((val >> 8) | (val << 8));
        }

        public override int ReadInt32()
        {
            UInt32 val = base.ReadUInt32();
            return (Int32)((val >> 24) | ((val & 0xFF0000) >> 8) | ((val & 0xFF00) << 8) | (val << 24));
        }


        public override ushort ReadUInt16()
        {
            UInt16 val = base.ReadUInt16();
            return (UInt16)((val >> 8) | (val << 8));
        }

        public override uint ReadUInt32()
        {
            UInt32 val = base.ReadUInt32();
            return (UInt32)((val >> 24) | ((val & 0xFF0000) >> 8) | ((val & 0xFF00) << 8) | (val << 24));
        }


        public override float ReadSingle()
        {
            byte[] stuff = base.ReadBytes(4);
            if (BitConverter.IsLittleEndian) Array.Reverse(stuff);
            float val = BitConverter.ToSingle(stuff, 0);
            return val;
        }

        public override double ReadDouble()
        {
            byte[] stuff = base.ReadBytes(8);
            if (BitConverter.IsLittleEndian) Array.Reverse(stuff);
            double val = BitConverter.ToDouble(stuff, 0);
            return val;
        }
    }


    public class BinaryWriterBE : BinaryWriter
    {
        public BinaryWriterBE(Stream s)
            : base(s)
        { }

        public BinaryWriterBE(Stream s, Encoding e)
            : base(s, e)
        { }


        public override void Write(short value)
        {
            ushort val = (ushort)value;
            base.Write((short)((val >> 8) | (val << 8)));
        }

        public override void Write(int value)
        {
            uint val = (uint)value;
            base.Write((int)((val >> 24) | ((val & 0xFF0000) >> 8) | ((val & 0xFF00) << 8) | (val << 24)));
        }


        public override void Write(ushort value)
        {
            base.Write((ushort)((value >> 8) | (value << 8)));
        }

        public override void Write(uint value)
        {
            base.Write((uint)((value >> 24) | ((value & 0xFF0000) >> 8) | ((value & 0xFF00) << 8) | (value << 24)));
        }


        public override void Write(float value)
        {
            byte[] stuff = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(stuff);
            base.Write(stuff);
        }

        public override void Write(double value)
        {
            byte[] stuff = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(stuff);
            base.Write(stuff);
        }
    }
    //----------------------------------------------------------------------------------------------
    public class FilesystemBase
    {
        public virtual void Close() { }

        public virtual string[] GetDirectories(string directory)
        { throw new NotImplementedException("FilesystemBase.GetDirectories()"); }

        public virtual bool DirectoryExists(string directory)
        { throw new NotImplementedException("FilesystemBase.DirectoryExists()"); }


        public virtual string[] GetFiles(string directory)
        { throw new NotImplementedException("FilesystemBase.GetFiles()"); }

        public virtual bool FileExists(string filename)
        { throw new NotImplementedException("FilesystemBase.FileExists()"); }

        public virtual FileBase OpenFile(string filename)
        { throw new NotImplementedException("FilesystemBase.OpenFile()"); }
    }

    public class FileBase
    {
        public Stream Stream
        {
            get { return m_Stream; }
            set
            {
                m_Stream = value;
                InitRW();
            }
        }

        public bool BigEndian
        {
            get { return m_BigEndian; }
            set
            {
                m_BigEndian = value;
                InitRW();
            }
        }

        public Encoding Encoding
        {
            get { return m_Encoding; }
            set
            {
                m_Encoding = value;
                InitRW();
            }
        }

        public BinaryReader Reader;
        public BinaryWriter Writer;

        private Stream m_Stream;
        private bool m_BigEndian;
        private Encoding m_Encoding = Encoding.ASCII;

        private void InitRW()
        {
            Reader = m_BigEndian ? new BinaryReaderBE(m_Stream, m_Encoding) : new BinaryReader(m_Stream, m_Encoding);
            Writer = m_BigEndian ? new BinaryWriterBE(m_Stream, m_Encoding) : new BinaryWriter(m_Stream, m_Encoding);
        }


        public string ReadString()
        {
            string ret = "";
            char c;
            while ((c = Reader.ReadChar()) != '\0')
                ret += c;
            return ret;
        }

        public int WriteString(string str)
        {
            int oldpos = (int)Stream.Position;

            foreach (char c in str)
                Writer.Write(c);
            Writer.Write('\0');

            return (int)(Stream.Position - oldpos);
        }


        public virtual void Flush()
        {
            m_Stream.Flush();
        }

        public virtual void Close()
        {
            m_Stream.Close();
        }
    }
    //----------------------------------------------------------------------------------------------------------------
    public class RarcFilesystem : FilesystemBase
    {
        public RarcFilesystem(FileBase file)
        {
            m_File = file;
            m_File.Stream = new Yaz0Stream(m_File.Stream);
            m_File.BigEndian = true;

            m_File.Stream.Position = 0;
            uint tag = m_File.Reader.ReadUInt32();
            if (tag != 0x52415243) throw new Exception("File isn't a RARC (tag 0x" + tag.ToString("X8") + ", expected 0x52415243)");

            m_File.Stream.Position = 0xC;
            m_FileDataOffset = m_File.Reader.ReadUInt32() + 0x20;
            m_File.Stream.Position = 0x20;
            m_NumDirNodes = m_File.Reader.ReadUInt32();
            m_DirNodesOffset = m_File.Reader.ReadUInt32() + 0x20;
            m_File.Stream.Position += 0x4;
            m_FileEntriesOffset = m_File.Reader.ReadUInt32() + 0x20;
            m_File.Stream.Position += 0x4;
            m_StringTableOffset = m_File.Reader.ReadUInt32() + 0x20;

            m_DirEntries = new Dictionary<uint, DirEntry>();
            m_FileEntries = new Dictionary<uint, FileEntry>();

            DirEntry root = new DirEntry();
            root.ID = 0;
            root.ParentDir = 0xFFFFFFFF;

            m_File.Stream.Position = m_DirNodesOffset + 0x6;
            uint rnoffset = m_File.Reader.ReadUInt16();
            m_File.Stream.Position = m_StringTableOffset + rnoffset;
            root.Name = m_File.ReadString();
            root.FullName = "/" + root.Name;

            m_DirEntries.Add(0, root);

            for (uint i = 0; i < m_NumDirNodes; i++)
            {
                DirEntry parentdir = m_DirEntries[i];

                m_File.Stream.Position = m_DirNodesOffset + (i * 0x10) + 10;

                ushort numentries = m_File.Reader.ReadUInt16();
                uint firstentry = m_File.Reader.ReadUInt32();

                for (uint j = 0; j < numentries; j++)
                {
                    uint entryoffset = m_FileEntriesOffset + ((j + firstentry) * 0x14);
                    m_File.Stream.Position = entryoffset;

                    uint fileid = m_File.Reader.ReadUInt16();
                    m_File.Stream.Position += 4;
                    uint nameoffset = m_File.Reader.ReadUInt16();
                    uint dataoffset = m_File.Reader.ReadUInt32();
                    uint datasize = m_File.Reader.ReadUInt32();

                    m_File.Stream.Position = m_StringTableOffset + nameoffset;
                    string name = m_File.ReadString();
                    if (name == "." || name == "..") continue;

                    string fullname = parentdir.FullName + "/" + name;

                    if (fileid == 0xFFFF)
                    {
                        DirEntry d = new DirEntry();
                        d.EntryOffset = entryoffset;
                        d.ID = dataoffset;
                        d.ParentDir = i;
                        d.NameOffset = nameoffset;
                        d.Name = name;
                        d.FullName = fullname;

                        m_DirEntries.Add(dataoffset, d);
                    }
                    else
                    {
                        FileEntry f = new FileEntry();
                        f.EntryOffset = entryoffset;
                        f.ID = fileid;
                        f.ParentDir = i;
                        f.NameOffset = nameoffset;
                        f.DataOffset = dataoffset;
                        f.DataSize = datasize;
                        f.Name = name;
                        f.FullName = fullname;

                        m_FileEntries.Add(fileid, f);
                    }
                }
            }
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

        public override void Close()
        {
            m_File.Close();
        }


        public override bool DirectoryExists(string directory)
        {
            DirEntry dir = m_DirEntries.Values.FirstOrDefault(de => de.FullName.ToLower() == directory.ToLower());
            return dir != null;
        }

        public override string[] GetDirectories(string directory)
        {
            DirEntry dir = m_DirEntries.Values.FirstOrDefault(de => de.FullName.ToLower() == directory.ToLower());
            if (dir == null) return null;
            IEnumerable<DirEntry> subdirs = m_DirEntries.Values.Where(de => de.ParentDir == dir.ID);

            List<string> ret = new List<string>();
            foreach (DirEntry de in subdirs) ret.Add(de.Name);
            return ret.ToArray();
        }

        public void ReplaceFile(byte[] filebytes, RarcFile file, string filepath)
        {
            FileEntry fe = m_FileEntries[file.ID];
            fe.DataSize = (uint)filebytes.Length;
            List<byte> Firstbtlst = new List<byte>();
            m_File.Stream.Position = 0;
            for (int i = 0; i < m_FileDataOffset + fe.DataOffset; i++)
            {
                Firstbtlst.Add(m_File.Reader.ReadByte());
            }
            List<byte> Currentbtlst = new List<byte>();
            for (int i = 0; i < (int)fe.DataSize; i++)
            {
                Currentbtlst.Add(m_File.Reader.ReadByte());
            }
            byte[] Lastbytes = m_File.Reader.ReadBytes((int)m_File.Reader.BaseStream.Length);
            //we got the bytes. Replacement time
            FileStream fs = new FileStream(filepath,FileMode.Create);
            foreach (byte b in Firstbtlst)
            {
                fs.WriteByte(b);
            }
            foreach (byte b in filebytes)
            {
                fs.WriteByte(b);
            }
            foreach (byte b in Lastbytes)
            {
                fs.WriteByte(b);
            }
            fs.Close();
        }

        public uint GetStartPoint()
        {
            return m_FileEntriesOffset;
        }

        public override bool FileExists(string filename)
        {
            FileEntry file = m_FileEntries.Values.FirstOrDefault(fe => fe.FullName.ToLower() == filename.ToLower());
            return file != null;
        }

        public override string[] GetFiles(string directory)
        {
            DirEntry dir = m_DirEntries.Values.FirstOrDefault(de => de.FullName.ToLower() == directory.ToLower());
            if (dir == null) return null;
            IEnumerable<FileEntry> files = m_FileEntries.Values.Where(fe => fe.ParentDir == dir.ID);

            List<string> ret = new List<string>();
            foreach (FileEntry fe in files) ret.Add(fe.Name);
            return ret.ToArray();
        }

        public override FileBase OpenFile(string filename)
        {
            FileEntry file = m_FileEntries.Values.FirstOrDefault(fe => fe.FullName.ToLower() == filename.ToLower());
            if (file == null) return null;

            return new RarcFile(this, file.ID);
        }


        // support functions for RarcFile
        public byte[] GetFileContents(RarcFile file)
        {
            FileEntry fe = m_FileEntries[file.ID];

            m_File.Stream.Position = m_FileDataOffset + fe.DataOffset;
            return m_File.Reader.ReadBytes((int)fe.DataSize);
        }

        public void ReinsertFile(RarcFile file)
        {
            FileEntry fe = m_FileEntries[file.ID];

            uint fileoffset = m_FileDataOffset + fe.DataOffset;
            int oldlength = (int)fe.DataSize;
            int newlength = (int)file.Stream.Length;
            int delta = newlength - oldlength;

            if (newlength != oldlength)
            {
                m_File.Stream.Position = fileoffset + oldlength;
                byte[] tomove = m_File.Reader.ReadBytes((int)(m_File.Stream.Length - m_File.Stream.Position));

                m_File.Stream.Position = fileoffset + newlength;
                m_File.Stream.SetLength(m_File.Stream.Length + delta);
                m_File.Writer.Write(tomove);

                fe.DataSize = (uint)newlength;
                m_File.Stream.Position = fe.EntryOffset + 0xC;
                m_File.Writer.Write(fe.DataSize);

                foreach (FileEntry tofix in m_FileEntries.Values)
                {
                    if (tofix.ID == fe.ID) continue;
                    if (tofix.DataOffset < (fe.DataOffset + oldlength)) continue;

                    tofix.DataOffset = (uint)(tofix.DataOffset + delta);
                    m_File.Stream.Position = tofix.EntryOffset + 0x8;
                    m_File.Writer.Write(tofix.DataOffset);
                }
            }

            m_File.Stream.Position = fileoffset;
            file.Stream.Position = 0;
            byte[] data = file.Reader.ReadBytes(newlength);
            m_File.Writer.Write(data);

            m_File.Flush();
        }


        private class FileEntry
        {
            public uint EntryOffset;

            public uint ID;
            public uint NameOffset;
            public uint DataOffset;
            public uint DataSize;

            public uint ParentDir;

            public string Name;
            public string FullName;
        }

        private class DirEntry
        {
            public uint EntryOffset;

            public uint ID;
            public uint NameOffset;

            public uint ParentDir;

            public string Name;
            public string FullName;
        }


        private FileBase m_File;

        private uint m_FileDataOffset;
        private uint m_NumDirNodes;
        private uint m_DirNodesOffset;
        private uint m_FileEntriesOffset;
        private uint m_StringTableOffset;

        private Dictionary<uint, FileEntry> m_FileEntries;
        private Dictionary<uint, DirEntry> m_DirEntries;
    }


    public class RarcFile : FileBase
    {
        public RarcFile(RarcFilesystem fs, uint id)
        {
            m_FS = fs;
            m_ID = id;

            byte[] buffer = m_FS.GetFileContents(this);
            Stream = new MemoryStream(buffer.Length);
            Writer.Write(buffer);
        }

        public override void Flush()
        {
            Stream.Flush();
            m_FS.ReinsertFile(this);
        }

        public void Replace(byte[] b,string d)
        {
            m_FS.ReplaceFile(b,this,d);
        }

        private RarcFilesystem m_FS;
        public uint m_ID;

        public uint ID { get { return m_ID; } }
    }
    //--------------------------------------------------------------------------------------------------------------------
    public class Yaz0Stream : MemoryStream
    {
        public Yaz0Stream(Stream backend)
            : base(1)
        {
            if (backend is Yaz0Stream) throw new Exception("sorry but no");

            m_Backend = backend;

            m_Backend.Position = 0;
            byte[] buffer = new byte[m_Backend.Length];
            m_Backend.Read(buffer, 0, (int)m_Backend.Length);

            Yaz0.Decompress(ref buffer);
            Position = 0;
            Write(buffer, 0, buffer.Length);
        }

        public void Flush(bool recompress)
        {
            byte[] buffer = new byte[Length];
            Position = 0;
            Read(buffer, 0, (int)Length);
            if (recompress) Yaz0.Compress(ref buffer);

            m_Backend.Position = 0;
            m_Backend.SetLength(buffer.Length);
            m_Backend.Write(buffer, 0, buffer.Length);
            m_Backend.Flush();
        }

        public override void Flush()
        {
            Flush(false);
        }

        public override void Close()
        {
            m_Backend.Close();
            base.Close();
        }


        private Stream m_Backend;
    }
    //----------------------------------------------------------------------------------------------------
    public static class Yaz0
    {
        // TODO: put compression in use?
        // note: compression is slow when dealing with large files (eg. 3D models)
        // it should be made optional, and show a progress dialog and all

        private static void FindOccurence(byte[] data, int pos, ref int offset, ref int length)
        {
            offset = -1;
            length = 0;

            if (pos >= data.Length - 2) return;

            Dictionary<int, int> occurences = new Dictionary<int, int>();

            int len = 0;
            int start = (pos > 4096) ? pos - 4096 : 0;
            for (int i = start; i < pos; i++)
            {
                if (i >= data.Length - 2) break;

                if (data[i] != data[pos] || data[i + 1] != data[pos + 1] || data[i + 2] != data[pos + 2])
                    continue;

                len = 3;
                while ((i + len < data.Length) && (pos + len < data.Length) && (data[i + len] == data[pos + len]))
                    len++;

                occurences.Add(i, len);
            }

            foreach (KeyValuePair<int, int> occ in occurences)
            {
                if (occ.Value > length)
                {
                    offset = occ.Key;
                    length = occ.Value;
                }
            }
        }

        public static void Compress(ref byte[] data)
        {
            if (data[0] == 'Y' && data[1] == 'a' && data[2] == 'z' && data[3] == '0')
                return;

            byte[] output = new byte[16 + data.Length + (data.Length / 8)];

            output[0] = (byte)'Y';
            output[1] = (byte)'a';
            output[2] = (byte)'z';
            output[3] = (byte)'0';

            uint fullsize = (uint)data.Length;
            output[4] = (byte)(fullsize >> 24);
            output[5] = (byte)(fullsize >> 16);
            output[6] = (byte)(fullsize >> 8);
            output[7] = (byte)fullsize;

            int inpos = 0, outpos = 16;
            int occ_offset = -1, occ_length = 0;

            while (inpos < fullsize)
            {
                int datastart = outpos + 1;
                byte block = 0;

                for (int i = 0; i < 8; i++)
                {
                    block <<= 1;

                    if (inpos < data.Length)
                    {
                        if (occ_offset == -2)
                            FindOccurence(data, inpos, ref occ_offset, ref occ_length);

                        int next_offset = -1, next_length = 0;
                        FindOccurence(data, inpos + 1, ref next_offset, ref next_length);
                        if (next_length > occ_length + 1) occ_offset = -1;

                        if (occ_offset != -1)
                        {
                            int disp = inpos - occ_offset - 1;
                            if (disp > 4095) throw new Exception("DISP OUT OF RANGE!");

                            if (occ_length > 17)
                            {
                                if (occ_length > 273) occ_length = 273;

                                output[datastart++] = (byte)(disp >> 8);
                                output[datastart++] = (byte)disp;
                                output[datastart++] = (byte)(occ_length - 18);
                            }
                            else
                            {
                                output[datastart++] = (byte)(((occ_length - 2) << 4) | (disp >> 8));
                                output[datastart++] = (byte)disp;
                            }

                            inpos += occ_length;
                            occ_offset = -2;
                        }
                        else
                        {
                            output[datastart++] = data[inpos++];
                            block |= 0x01;
                        }

                        if (occ_offset != -2)
                        {
                            occ_offset = next_offset;
                            occ_length = next_length;
                        }
                    }
                }

                output[outpos] = block;
                outpos = datastart;
            }

            Array.Resize(ref data, outpos);
            Array.Resize(ref output, outpos);
            output.CopyTo(data, 0);
        }

        // inspired from http://www.amnoid.de/gc/yaz0.txt
        public static void Decompress(ref byte[] data)
        {
            if (data[0] != 'Y' || data[1] != 'a' || data[2] != 'z' || data[3] != '0')
                return;

            int fullsize = (data[4] << 24) | (data[5] << 16) | (data[6] << 8) | data[7];
            byte[] output = new byte[fullsize];

            int inpos = 16, outpos = 0;
            while (outpos < fullsize)
            {
                byte block = data[inpos++];

                for (int i = 0; i < 8; i++)
                {
                    if ((block & 0x80) != 0)
                    {
                        // copy one plain byte
                        output[outpos++] = data[inpos++];
                    }
                    else
                    {
                        // copy N compressed bytes
                        byte b1 = data[inpos++];
                        byte b2 = data[inpos++];

                        int dist = ((b1 & 0xF) << 8) | b2;
                        int copysrc = outpos - (dist + 1);

                        int nbytes = b1 >> 4;
                        if (nbytes == 0) nbytes = data[inpos++] + 0x12;
                        else nbytes += 2;

                        for (int j = 0; j < nbytes; j++)
                            output[outpos++] = output[copysrc++];
                    }

                    block <<= 1;
                    if (outpos >= fullsize || inpos >= data.Length)
                        break;
                }
            }

            Array.Resize(ref data, fullsize);
            output.CopyTo(data, 0);
        }
    }
}

