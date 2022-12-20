using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;

namespace APM.Test
{
    public class UnitTests : TestBase
    {

        [SetUp]
        public void Setup()
        {
            this.Initialise();
        }

        /// <summary>
        /// A Test to read mock data from a file
        /// </summary>
        /// <param name="content"> file data</param>
        [TestCase("Hellow There!")]
        public void ReadContentFromAFileTest(string content)
        {
            var fileData = content;
            this.ReadFileMock.Setup(q => q.ReadFileData()).Returns(fileData);

            var sut = GetService();
            var response = sut.GetFileContent();

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(content, response);
        }

        /// <summary>
        /// A test that reverse the mock data
        /// </summary>
        /// <param name="fileData"> file data</param>
        [TestCase("Hellow There!")]
        public void ReverseFileContentsTest(string fileData)
        {
            var expected = "!erehT wolleH";
            this.ReverseContentMock.Setup(q => q.ReverseFileData(fileData)).Returns(expected);
            var sut = GetService();
            var response = sut.ReverseFileContent(fileData);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(expected, response);
        }

        /// <summary>
        /// A test write reversed mock data into a file 
        /// </summary>
        /// <param name="fileData"></param>
        [TestCase("!erehT wolleH")]
        public void WriteToFileTest(string fileData)
        {
            this.WriteToFileMock.Setup(q => q.ContentWriteToFile(fileData)).Returns(true);
            var sut = GetService();
            var response = sut.WriteToFileContent(fileData);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(true, response);
        }

        /// <summary>
        /// End to end mock test
        /// Read from a file, reverse data and then write back to file
        /// </summary>
        /// <param name="content"></param>
        [TestCase("Hellow There!")]
        public void Read_Reverse_Write_Test(string content)
        {
            var fileData = content;
            // Read file data
            this.ReadFileMock.Setup(q => q.ReadFileData()).Returns(fileData);

            var expected = "!erehT wolleH";
            // reverse data
            this.ReverseContentMock.Setup(q => q.ReverseFileData(fileData)).Returns(expected);

            // write into a file
            this.WriteToFileMock.Setup(q => q.ContentWriteToFile(expected)).Returns(true);
            
            // service instance
            var sut = GetService();
            var fileResponse = sut.GetFileContent();
            var reverseResponse = sut.ReverseFileContent(fileData);
            var writeResponse = sut.WriteToFileContent(expected);

            //Assert
            Assert.IsNotNull(fileResponse);
            Assert.IsNotNull(reverseResponse);
            Assert.IsNotNull(writeResponse);
            Assert.AreEqual(fileData, fileResponse);
            Assert.AreEqual(expected, reverseResponse);
            Assert.AreEqual(true, writeResponse);
        }

    }
}
