using System;
using System.Collections.Generic;
using System.Text;

namespace APM
{
    public class Service
    {
        private readonly IReadFile _readFile;
        private readonly IReverseContent _reverseContent;
        private readonly IWriteToFile _writeToFile;

        public Service(IReadFile readFile, IReverseContent reverseContent, IWriteToFile writeToFile)
        {
            _readFile = readFile;
            _reverseContent = reverseContent;
            _writeToFile = writeToFile;
        }

        public string GetFileContent()
        {
            return _readFile.ReadFileData();
        }

        public string ReverseFileContent(string data)
        {
            return _reverseContent.ReverseFileData(data);
        }

        public bool WriteToFileContent(string data)
        {
            return _writeToFile.ContentWriteToFile(data);
        }

    }
}
