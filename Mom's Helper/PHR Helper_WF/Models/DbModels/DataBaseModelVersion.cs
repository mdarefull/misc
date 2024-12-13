
namespace PHR_Helper_WF.Models.DbModels
{
    public class DataBaseModelVersion
    {
        private readonly string _displayName;
        public string DisplayName { get { return _displayName; } }

        private readonly string _instanceName;
        public string InstanceName { get { return _instanceName; } }

        private readonly string _serviceName;
        public string ServiceName { get { return _serviceName; } }

        public DataBaseModelVersion(string displayName, string instanceName, string serviceName)
        {
            _displayName = displayName;
            _instanceName = instanceName;
            _serviceName = serviceName;
        }
    }
}