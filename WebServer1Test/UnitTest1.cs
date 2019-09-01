using System;
using Xunit;
using WebServerUsingSocket;
using System.IO;

namespace WebServerUsingSocketTest
{
    public class UnitTest1
    {
        LocalFileSystem _localFileSystem = new LocalFileSystem();
        [Fact]
        public void File_Exists_Test()
        {
            string physicalPath = @"C:\Users\gsanap\Desktop\"+"index.html";
            //@ can be used to avoid using \\ .
            FileInfo fileInfo;
            bool exists = _localFileSystem.TryGetFile(physicalPath,out fileInfo);
            //var buffer = FileReader.GetFileStream(fileInfo);
            Assert.True(exists);
        }

        
    }
}
