using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APM
{

    public class WriteToFile : IWriteToFile
    {
        public bool ContentWriteToFile(string content)
        {
            try
            {
                var filePath = @"D:\APM\result.txt";
                File.WriteAllText(filePath, content);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
