using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace APM.Test
{
    public class TestBase
    {
       public Mock<IReadFile> ReadFileMock { get; private set; }
       public Mock<IReverseContent> ReverseContentMock { get; private set; }
       public Mock<IWriteToFile> WriteToFileMock { get; private set; }
        
       public Mock<Service> ServiceMock { get; private set; }

        public void Initialise()
       {
           this.ReadFileMock = new Mock<IReadFile>();
           this.ReverseContentMock = new Mock<IReverseContent>();
           this.WriteToFileMock = new Mock<IWriteToFile>();
           this.ServiceMock = new Mock<Service>();
       }


        public Service GetService()
        {
            return  new Service(ReadFileMock.Object, ReverseContentMock.Object, WriteToFileMock.Object);
        }
    
    }
}
