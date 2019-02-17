using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData.Interfaces
{
    /// <summary>
    /// Allows the service to be mockable. Not needed in this example, but good to have the flexibility.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Obtains the size of the specified file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        int ReadFileSize(string filePath);

        /// <summary>
        /// Obtains the version of the specified file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        Version ReadFileVersion(string filePath);
    }
}
