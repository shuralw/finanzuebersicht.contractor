using System.Text;

namespace Finanzuebersicht.Backend.Admin.Core.Contract.Logic.SystemConnections.FileSystem
{
    public interface IFileSystemClient
    {
        string ReadAllText(string path);

        string ReadAllText(string path, Encoding encoding);
    }
}