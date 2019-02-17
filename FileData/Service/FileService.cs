using System;

using FileData.Interfaces;
using ThirdPartyTools;

namespace FileData
{
    public class FileService
        : IFileService
    {
        public int ReadFileSize(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var fileDetails = new FileDetails();
            return fileDetails.Size(filePath);
        }

        public Version ReadFileVersion(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var fileDetails = new FileDetails();
            var versionString = fileDetails.Version(filePath);
            return Version.Parse(versionString);
        }
    }
}
