using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FileData;

namespace FileDataTests
{
    [TestClass]
    public class FileServiceTests
    {
        [TestMethod]
        public void CanReadVersion()
        {
            var filePath = "test.txt";

            var fileService = new FileService();
            var version = fileService.ReadFileVersion(filePath);

            Assert.IsNotNull(version);

            // Test version is correct, etc. Can't do this since return value is random :)
        }

        [TestMethod]
        public void CanReadSize()
        {
            var filePath = "test.txt";

            var fileService = new FileService();
            var size = fileService.ReadFileSize(filePath);
            
            Assert.IsTrue(size >= 0);

            // Test size is correct, etc. Can't do this since return value is random :)
        }

        [TestMethod]
        public void DoesNotAllowEmptyPath()
        {
            var fileService = new FileService();

            Assert.ThrowsException<ArgumentNullException>(() => fileService.ReadFileSize(null));
            Assert.ThrowsException<ArgumentNullException>(() => fileService.ReadFileSize(string.Empty));
            Assert.ThrowsException<ArgumentNullException>(() => fileService.ReadFileSize(" "));
            Assert.ThrowsException<ArgumentNullException>(() => fileService.ReadFileSize("\t"));

            Assert.ThrowsException<ArgumentNullException>(() => fileService.ReadFileVersion(null));
            Assert.ThrowsException<ArgumentNullException>(() => fileService.ReadFileVersion(string.Empty));
            Assert.ThrowsException<ArgumentNullException>(() => fileService.ReadFileVersion(" "));
            Assert.ThrowsException<ArgumentNullException>(() => fileService.ReadFileVersion("\t"));
        }
    }
}
