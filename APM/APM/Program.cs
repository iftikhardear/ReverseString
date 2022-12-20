using System;
using System.IO;

namespace APM
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Service class that exposes all the interface methods.
            Service service = new Service(new ReadFile(), new ReverseContent(), new WriteToFile());

            //Read the file content
            var fileContent = service.GetFileContent();
            Console.WriteLine("File Content: " +fileContent);
            
            //Reverse the file content
            var reversedContents = service.ReverseFileContent(fileContent);
            Console.WriteLine("Reversed Content: " + reversedContents);

            //Write to file reversed content
            Console.WriteLine("Is content has been written to file: " + service.WriteToFileContent(reversedContents));
        }

    }
}
