using PHR_Helper_WF.Models.DbModels;

namespace PHR_Helper_WF.Models
{
    public class Company
    {
        private readonly string _name;
        public string Name { get { return _name; } }

        private readonly DataBaseModel _dataBase;
        public DataBaseModel DataBase { get { return _dataBase; } }

        public Company(string name, DataBaseModel dataBase)
        {
            _name = name;
            _dataBase = dataBase;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}