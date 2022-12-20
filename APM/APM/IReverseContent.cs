using System;
using System.Collections.Generic;
using System.Text;

namespace APM
{
    public interface IReverseContent
    {
        string ReverseFileData(string content);
    }


    public class ReverseContent :IReverseContent
    {
        public string ReverseFileData(string content)
        {
            char[] charArray = content.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
