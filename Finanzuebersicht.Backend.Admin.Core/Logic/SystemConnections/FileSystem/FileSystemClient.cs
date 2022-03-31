using Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.FileSystem;
using System.IO;
using System.Text;

namespace Finanzuebersicht.Backend.Admin.Core.Logic.SystemConnections.FileSystem
{
    internal class FileSystemClient : IFileSystemClient
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public string ReadAllText(string path, Encoding encoding)
        {
            return File.ReadAllText(path, encoding);
        }
    }
}