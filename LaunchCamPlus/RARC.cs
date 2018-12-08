using System;
using System.Collections.Generic;
using System.Text;

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
