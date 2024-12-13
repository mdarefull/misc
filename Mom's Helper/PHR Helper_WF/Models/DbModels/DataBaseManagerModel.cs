
namespace PHR_Helper_WF.Models.DbModels
{
    public class DataBaseManagerModel
    {
        private readonly string _host;
        public string Host { get { return _host; } }

        private readonly DataBaseModelVersion _version;
        public DataBaseModelVersion Version { get { return _version; } }

        public DataBaseManagerModel(string host, DataBaseModelVersion version)
        {
            _host = host;
            _version = version;
        }
    }
}
