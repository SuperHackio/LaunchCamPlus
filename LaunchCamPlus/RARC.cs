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
/// Implemented in LCP 2.0.0.0
/// </summary>
namespace RARCManagment
{
    public class RARC
    {
        public string originalpath = "";
        public string rootpath = "";
        public string name = "";
        public string ext = "";
        public FileInfo Selfinfo;

        /// <summary>
        /// Read a RARC
        /// </summary>
        /// <param name="rarcFile">string</param>
        public RARC(FileStream rarcFile,FileInfo rarcInfo)
        {
            Selfinfo = rarcInfo;
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
                File.Copy(rarcInfo.FullName, @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + rarcInfo.Name);
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
                    cmd.StandardInput.WriteLine("\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Yaz0Dec.exe\"" + " \"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + rarcInfo.Name + "\"");
                    cmd.StandardInput.WriteLine("\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\RarcDump.exe\"" + " \"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + rarcInfo.Name + " 0.rarc\"");
                    cmd.StandardInput.WriteLine("exit");
                    //cmd.StandardInput.WriteLine("del /q \"" + rarcInfo.FullName + " 0.rarc\"");
                    //cmd.StandardInput.WriteLine("move /y \"" + rarcInfo.Directory.FullName + "\\" + rarcInfo.Name + " 0.rarc_dir\" "+"\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\"");
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    File.WriteAllText(@AppDomain.CurrentDomain.BaseDirectory + "SuperBMDLog.txt", cmd.StandardOutput.ReadToEnd());// (This line of code copied from SuperJSON lol)
                    cmd.WaitForExit();
                    
                    File.Delete(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + rarcInfo.Name + " 0.rarc");
                    //Directory.Move(rarcInfo.Directory.FullName + "\\" + rarcInfo.Name + " 0.rarc_dir", @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\"+rarcInfo.Name+ " 0.rarc_dir");
                    rootpath = @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Stage";
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

                    cmd.StandardInput.WriteLine("\""+@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\RarcDump.exe\""+" \""+ @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + rarcInfo.Name + "\"");
                    //cmd.StandardInput.WriteLine("move \"" + rarcInfo.Directory.FullName + "\\" + rarcInfo.Name + "_dir\" " + "\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\"");
                    //cmd.StandardInput.WriteLine("All");
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    cmd.WaitForExit();
                    //System.Windows.Forms.MessageBox.Show(cmd.StandardOutput.ReadToEnd());
                    rootpath = @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Stage";
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

        public void Return(bool Encode = false)
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
                //cmd.StandardInput.WriteLine("rename "+ "\"" + rootpath + "\" " + "Stage");
                cmd.StandardInput.WriteLine("\""+@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\ArcPack.exe\" \""+ @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + "Stage" +"\"");

                if (Encode)
                {
                    cmd.StandardInput.WriteLine("\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Yaz0Enc.exe\" \"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + "Stage.arc" + "\"");
                }

                cmd.StandardInput.WriteLine("exit");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                File.WriteAllText(@AppDomain.CurrentDomain.BaseDirectory + "SuperBMDLog.txt", cmd.StandardOutput.ReadToEnd());// (This like of code copied from SuperJSON lol)
                cmd.WaitForExit();

                File.Delete(originalpath);
                if (Encode)
                {
                    File.Move(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + "Stage.arc.yaz0", originalpath);
                    File.Delete(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + "Stage.arc");
                }
                else
                {
                    File.Move(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + "Stage.arc", originalpath);
                }
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