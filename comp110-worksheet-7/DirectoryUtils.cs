using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_7
{
	public static class DirectoryUtils
	{
		// Return the size, in bytes, of the given file
		public static long GetFileSize(string filePath)
		{
			return new FileInfo(filePath).Length;
		}

		// Return true if the given path points to a directory, false if it points to a file
		public static bool IsDirectory(string path)
		{
			return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
		}

		// Return the total size, in bytes, of all the files below the given directory
		public static long GetTotalSize(string directory)
		{
            long sizeOfFiles;

            string[] fileNum = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            foreach (string file in fileNum)
            {
                sizeOfFiles += GetFileSize(file);
            }
            return sizeOfFiles;
		}

		// Return the number of files (not counting directories) below the given directory
		public static int CountFiles(string directory)
		{
            string[] fileNum = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);

            return fileNum.Length;
		}

		// Return the nesting depth of the given directory. A directory containing only files (no subdirectories) has a depth of 0.
		public static int GetDepth(string directory)
		{
            int directDepth;
            string[] directoryDepth = Directory.GetDirectories(directory);
			
            foreach(string i in directory)
            {
                directDepth += directDepth; 
            }

            return directDepth;
		}

		// Get the path and size (in bytes) of the smallest file below the given directory
		public static Tuple<string, long> GetSmallestFile(string directory)
		{
            var fileList = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
            string smallestFilePath;
            long smallestFile;

            smallestFilePath = ListOfFiles[0];
            smallestFile = GetFileSize(smallestFilePath);

            foreach ( var i in fileList)
            {
                if (GetFileSize(i) < smallestFile)
                {
                    smallestFile = GetFileSize(i);
                    smallestFish = i;
                }
            }
            return new Tuple<sting, long>(smallestFilePath, smallestFile);

            
		}

		// Get the path and size (in bytes) of the largest file below the given directory
		public static Tuple<string, long> GetLargestFile(string directory)
		{
            var fileList = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
            string largestFilePath;
            long largestFile;

            largestFilePath = ListOfFiles[0];
            largestFile = GetFileSize(largestFilePath);

            foreach (var i in fileList)
            {
                if (GetFileSize(i) > largestFile)
                {
                    smallestFile = GetFileSize(i);
                    smallestFish = i;
                }
            }
            return new Tuple<sting, long>(largestFilePath, largestFile);
        }

		// Get all files whose size is equal to the given value (in bytes) below the given directory
		public static IEnumerable<string> GetFilesOfSize(string directory, long size)
        {
        }	
	}
}
