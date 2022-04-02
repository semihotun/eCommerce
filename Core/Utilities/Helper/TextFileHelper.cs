using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public static class TextFileHelper
    {
        public static void CreateFile(string DirectoryName, string WriteText)
        {
            FileStream fileStream = new FileStream(DirectoryName, FileMode.OpenOrCreate, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine(WriteText);
                writer.Close();
            }
            fileStream.Close();
        }
    }
}
