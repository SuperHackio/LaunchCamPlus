using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hackio.IO
{
    /// <summary>
    /// Extension of the <see cref="FileStream"/> designed for Big Endian
    /// </summary>
    public static class FileStreamEx
    {
        /// <summary>
        /// Reads a block of bytes from the stream and writes the data in a given buffer... but Backwards! (For Big Endian)
        /// </summary>
        /// <param name="FS">This</param>
        /// <param name="Offset">The byte offset in array at which the read bytes will be placed.</param>
        /// <param name="Count">The maximum number of bytes to read.</param>
        /// <returns>The total number of bytes read into the buffer. This might be less than the number of bytes requested if that number of bytes are not currently available, or zero if the end of the stream is reached.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Offset or Count is negative.</exception>
        /// <exception cref="NotSupportedException">The stream does not support reading.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        /// <exception cref="ArgumentException">Offset and Count describe an invalid range in array.</exception>
        /// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
        public static byte[] ReadReverse(this FileStream FS, int Offset, int Count)
        {
            byte[] Final = new byte[Count];
            FS.Read(Final, Offset, Count);
            Array.Reverse(Final);
            return Final;
        }
        /// <summary>
        /// Writes a block of bytes to the file stream... but Backwards! (For Big Endian)
        /// </summary>
        /// <param name="FS">This</param>
        /// <param name="array">The buffer containing data to write to the stream</param>
        /// <param name="offset">The zero-based byte offset in array from which to begin copying bytes to the stream</param>
        /// <param name="count">The maximum number of bytes to write</param>
        /// <exception cref="ArgumentNullException">array is null.</exception>
        /// <exception cref="ArgumentException">offset and count describe an invalid range in array.</exception>
        /// <exception cref="ArgumentOutOfRangeException">offset or count is negative</exception>
        /// <exception cref="IOException">An I/O error occurred, or Another thread may have caused an unexpected change in the position of the operating system's file handle</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed</exception>
        /// <exception cref="NotSupportedException">The current stream instance does not support writing</exception>
        public static void WriteReverse(this FileStream FS, byte[] array, int offset, int count)
        {
            Array.Reverse(array);
            FS.Write(array, offset, count);
        }
        /// <summary>
        /// Reads a String from the file. Strings are terminated by 0x00. <para/> The decoded string is in SHIFT-JIS
        /// </summary>
        /// <param name="FS"></param>
        /// <returns>Complete String</returns>
        public static string ReadString(this FileStream FS)
        {
            List<byte> bytes = new List<byte>();
            int strCount = 0;
            while (FS.ReadByte() != 0)
            {
                FS.Position -= 1;
                bytes.Add((byte)FS.ReadByte());

                strCount++;
                if (strCount > FS.Length)
                    throw new IOException("An error has occurred while reading the string");
            }
            return Encoding.GetEncoding("Shift-JIS").GetString(bytes.ToArray(), 0, bytes.ToArray().Length);
        }
        /// <summary>
        /// Reads a String from the file. String length is determined by the "<paramref name="StringLength"/>" parameter. <para/> The decoded string is in SHIFT-JIS
        /// </summary>
        /// <param name="FS"></param>
        /// <param name="StringLength">Length of the string to read. Cannot be longer than the <see cref="FileStream.Length"/></param>
        /// <returns>Complete String</returns>
        public static string ReadString(this FileStream FS, int StringLength)
        {
            byte[] bytes = new byte[StringLength];
            FS.Read(bytes, 0, StringLength);
            return Encoding.GetEncoding("Shift-JIS").GetString(bytes, 0, StringLength);
        }
        /// <summary>
        /// Reads a String from the file. Strings are terminated by 0x00. <para/> The decoded string is defined by the "<paramref name="Encoding"/>" Parameter.
        /// </summary>
        /// <param name="FS"></param>
        /// <param name="Encoding">Encoding to use when getting the string</param>
        /// <returns>Complete String</returns>
        public static string ReadString(this FileStream FS, Encoding Encoding)
        {
            List<byte> bytes = new List<byte>();
            int strCount = 0;
            while (FS.ReadByte() != 0)
            {
                FS.Position -= 1;
                bytes.Add((byte)FS.ReadByte());

                strCount++;
                if (strCount > FS.Length)
                    throw new IOException("An error has occurred while reading the string");
            }
            return Encoding.GetString(bytes.ToArray(), 0, bytes.ToArray().Length);
        }
        /// <summary>
        /// Reads a String from the file. String length is determined by the "<paramref name="StringLength"/>" parameter. <para/> The decoded string is defined by the "<paramref name="Encoding"/>" Parameter.
        /// </summary>
        /// <param name="FS"></param>
        /// <param name="StringLength">Length of the string to read. Cannot be longer than the <see cref="FileStream.Length"/></param>
        /// <param name="Encoding">Encoding to use when getting the string</param>
        /// <returns>Complete String</returns>
        public static string ReadString(this FileStream FS, int StringLength, Encoding Encoding)
        {
            byte[] bytes = new byte[StringLength];
            FS.Read(bytes, 0, StringLength);
            return Encoding.GetString(bytes, 0, StringLength);
        }
    }
}