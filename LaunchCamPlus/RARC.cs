using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

/// <summary>
/// Depricated in LCP 1.1.0.0
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
/// Implemented in LCP 2.0.0.0. Upgraded in LCP 2.5.5.0
/// </summary>
namespace RARCManagment
{
    public class RARC
    {
        public string OriginalPath = "";
        public string FolderRootPath = "";
        public string OpenedArchive = "";
        public string ArchiveName = "";
        public string Extension = "";
        public FileInfo Selfinfo;
        public FileStream Lock;

        /// <summary>
        /// Creates a new RARC object
        /// </summary>
        /// <param name="rarcFile">Filestream of the Archive</param>
        /// <param name="rarcInfo">FileInfo of the Archive</param>
        /// <param name="ExpectedFoldername">Root Folder of the Archive. Default is the Archive name</param>
        /// <param name="OutputFolderName">Name to Rename the Root Folder to</param>
        public RARC(FileStream rarcFile, FileInfo rarcInfo, string ExpectedFoldername = "", string OutputFolderName = "")
        {
            rarcFile.Close();
            Lock = new FileStream(rarcInfo.FullName,FileMode.Open);
            Selfinfo = rarcInfo;
            OriginalPath = rarcInfo.FullName;
            string[] s = rarcInfo.Name.Split('.');
            ArchiveName = s[0];
            Extension = s[1];
            if (File.Exists(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\RarcDump.exe") && File.Exists(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Yaz0Dec.exe"))
            {
                Lock.Position = 0;
                byte[] tmp = new byte[4];
                Lock.Read(tmp, 0, 4);
                string type = Encoding.ASCII.GetString(tmp);
                type = type.ToUpper();
                Process cmd;

                if (File.Exists(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + rarcInfo.Name))
                    File.Delete(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + rarcInfo.Name);

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
                    File.WriteAllText(@AppDomain.CurrentDomain.BaseDirectory + "UnpackLog.txt", cmd.StandardOutput.ReadToEnd());
                    cmd.WaitForExit();

                    File.Delete(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + rarcInfo.Name + " 0.rarc");
                    //Directory.Move(rarcInfo.Directory.FullName + "\\" + rarcInfo.Name + " 0.rarc_dir", @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\"+rarcInfo.Name+ " 0.rarc_dir");
                    if (Directory.Exists(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + OutputFolderName))
                        Directory.Delete(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + OutputFolderName, true);
                    if (OutputFolderName != "")
                        Directory.Move(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + ExpectedFoldername, @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + OutputFolderName);
                    FolderRootPath = @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + OutputFolderName + (OutputFolderName != "" ? "\\" : (ExpectedFoldername != "" ? ExpectedFoldername + "\\" : rarcInfo.Name.Replace(rarcInfo.Extension, "") + "\\"));
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

                    cmd.StandardInput.WriteLine("\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\RarcDump.exe\"" + " \"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + rarcInfo.Name + "\"");

                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    File.WriteAllText(@AppDomain.CurrentDomain.BaseDirectory + "UnpackLog.txt", cmd.StandardOutput.ReadToEnd());
                    cmd.WaitForExit();
                    
                    if (Directory.Exists(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + OutputFolderName))
                        Directory.Delete(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + OutputFolderName, true);
                    if (OutputFolderName != "")
                        Directory.Move(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + ExpectedFoldername, @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + OutputFolderName);
                    FolderRootPath = @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + OutputFolderName + (OutputFolderName != "" ? "\\" : (ExpectedFoldername != "" ? ExpectedFoldername + "\\" : rarcInfo.Name.Replace(rarcInfo.Extension, "") + "\\"));

                }
                else
                {
                    FolderRootPath = null;
                    return;
                }
            }
            else
            {
                throw new Exception("RarcDump.exe or Yaz0Dec.exe is missing from \"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\"");
            }

            Lock.Lock(0, Lock.Length);
            OpenedArchive = @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\" + rarcInfo.Name;
        }

        /// <summary>
        /// Searches for a File within the Archive Directory.
        /// </summary>
        /// <param name="filename">Filename to search for. Requires the Extension to be included in the string.</param>
        /// <param name="RootExtension">Subpath to search in</param>
        /// <returns>FileInfo containing information on the Input File. "null" if the file can't be found</returns>
        public FileInfo FindFile(string filename, string RootExtension = "")
        {
            string file = "";
            string[] files = new string[1] { "Nope" };
            try
            {
                files = Directory.GetFiles(FolderRootPath + RootExtension, "*" + filename, SearchOption.AllDirectories);
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show(filename + " was not found!",filename);
                return null;
            }

            if (files.Length == 0)
                return null;

            file = files[0];

            return new FileInfo(file);
        }
        /// <summary>
        /// Returns a list of all the files within the Root Directory (+and specified subdirectory)
        /// </summary>
        /// <param name="RootExtension">Subpath to search in</param>
        /// <returns>String[] containing filenames</returns>
        public string[] ListFiles(string RootExtension = "")
        {
            return Directory.GetFiles(FolderRootPath + RootExtension, "*", SearchOption.AllDirectories);
        }

        /// <summary>
        /// Saves the archive
        /// </summary>
        /// <param name="Encode">Yaz0 Encode the Archive?</param>
        /// <param name="RootName">Name the root of the archive</param>
        /// <param name="savepath">New path to save the Archive</param>
        public void Save(bool Encode = false, string RootName = "", string savepath = "")
        {
            Lock.Unlock(0, Lock.Length);
            if (File.Exists(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\ArcPack.exe") && File.Exists(@AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Yaz0Enc.exe"))
            {
                if (RootName != "")
                    Directory.Move(FolderRootPath, FolderRootPath.Replace(ArchiveName, RootName));

                string Folder = RootName == "" ? FolderRootPath.Remove(FolderRootPath.Length - 1, 1) : FolderRootPath.Remove(FolderRootPath.Length - 1, 1).Replace(ArchiveName, RootName);

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
                cmd.StandardInput.WriteLine("\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\ArcPack.exe\" \"" + Folder + "\"");

                if (Encode)
                    cmd.StandardInput.WriteLine("\"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\\Yaz0Enc.exe\" \"" + Folder + ".arc" + "\"");

                cmd.StandardInput.WriteLine("exit");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                File.WriteAllText(@AppDomain.CurrentDomain.BaseDirectory + "PackLog.txt", cmd.StandardOutput.ReadToEnd());
                cmd.WaitForExit();

                if (savepath == "")
                {
                    Lock.Close();
                    File.Delete(OriginalPath);
                }

                if (Encode)
                {
                    File.Move(Folder + ".arc.yaz0", savepath != "" ? (savepath + Selfinfo.Name) : OriginalPath);
                    File.Delete(Folder + ".arc");
                }
                else
                    File.Move(Folder + ".arc", savepath != "" ? (savepath + Selfinfo.Name) : OriginalPath);

                //Directory.Delete(RootName == "" ? FolderRootPath : FolderRootPath.Replace(ArchiveName,RootName),true);
                if (RootName != "")
                    Directory.Move(FolderRootPath.Replace(ArchiveName, RootName), FolderRootPath);
            }
            else
            {
                throw new Exception("ArcPack.exe or Yaz0Enc.exe is missing from \"" + @AppDomain.CurrentDomain.BaseDirectory + "External Rarc Managment\"");
            }

            if (savepath == "")
                Lock = new FileStream(Selfinfo.FullName, FileMode.Open);
            Lock.Lock(0, Lock.Length);
        }

        /// <summary>
        /// Trashes this Archive
        /// </summary>
        /// <param name="ShowTrashAlert">Display if the Archive failed to be trashed fully.</param>
        public void Dispose(bool ShowTrashAlert = false)
        {
            Lock.Unlock(0,Lock.Length);
            Lock.Close();
            File.Delete(OpenedArchive);
            if (ShowTrashAlert && !Directory.Exists(FolderRootPath))
            {
                //System.Windows.Forms.MessageBox.Show("Failed to clean up temporary files.","Garbage alert");
                Console.WriteLine("Failed to clean up temporary files");
                return;
            }
            else if (Directory.Exists(FolderRootPath))
            {
                Directory.Delete(FolderRootPath, true);
            }
        }
    }
}