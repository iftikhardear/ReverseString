using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APM
{
    public class ReadFile :IReadFile
    {
        public string ReadFileData()
        {
            string textFile = @"D:\APM\source.txt";
            var result = string.Empty;
            if (File.Exists(textFile))
            {
                // Read entire text file content in one string    
                result = File.ReadAllText(textFile);
            }

            return result;
        }

    }
}
