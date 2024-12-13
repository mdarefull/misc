

namespace PHR_Helper_WF.Models.DbModels
{
    public class DataBaseModel
    {
        private readonly string _name;
        public string Name { get { return _name; } }

        private readonly DataBaseManagerModel _dataBaseManager;
        public DataBaseManagerModel DataBaseManager { get { return _dataBaseManager; } }

        public DataBaseModel(string name, DataBaseManagerModel dbm)
        {
            _name = name;
            _dataBaseManager = dbm;
        }
    }
}