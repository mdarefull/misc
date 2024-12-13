using System.Collections.Generic;
using System.Linq;

namespace PHR_Helper_WF.Models
{
    public class Mode
    {
        private readonly string _name;
        public string Name { get { return _name; } }

        private readonly string _startBatPath;
        public string StartBatPath { get { return _startBatPath; } }

        private readonly string _stopBatPath;
        public string StopBatPath { get { return _stopBatPath; } }

        private readonly string _jdbcPath;
        public string JdbcPath { get { return _jdbcPath; } }

        private readonly Company[] _companies;
        public Company[] Companies { get { return _companies; } }

        private readonly string _userName;
        public string UserName { get { return _userName; } }

        private readonly string _password;
        public string Password { get { return _password; } }

        private readonly string _otherSettings;
        public string OtherSettings { get { return _otherSettings; } }

        public Mode(string name, string startBatPath, string stopBatPath, string jdbcPath, IEnumerable<Company> companies,
            string userName, string password, string otherSettings)
        {
            _name = name;
            _startBatPath = startBatPath;
            _stopBatPath = stopBatPath;
            _jdbcPath = jdbcPath;
            _companies = companies.ToArray();
            _userName = userName;
            _password = password;
            _otherSettings = otherSettings;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}