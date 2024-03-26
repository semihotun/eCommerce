using System.IO;
namespace Core.Utilities.Helper
{
    public static class TextFileHelper
    {
        public static void CreateFile(string DirectoryName, string WriteText)
        {
            FileStream fileStream = new(DirectoryName, FileMode.OpenOrCreate, FileAccess.Write);
            using (StreamWriter writer = new(fileStream))
            {
                writer.WriteLine(WriteText);
                writer.Close();
            }
            fileStream.Close();
        }
    }
}
