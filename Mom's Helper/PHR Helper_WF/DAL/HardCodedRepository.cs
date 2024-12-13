using PHR_Helper_WF.Models;
using PHR_Helper_WF.Models.DbModels;
using System.Collections.Generic;

namespace PHR_Helper_WF.DAL
{
    public class HardCodedRepository
    {
        public HardCodedRepository()
        {
            CreateStaticModelsData(ref _modes);
        }
        private void CreateStaticModelsData(ref IEnumerable<Mode> modes)
        {
            // Statically create all the model's data:

            #region DbVersion's Creation
            var dbVersions = new Dictionary<string, DataBaseModelVersion>
            { 
                {"2005", new DataBaseModelVersion("2005", null, "MSSQLSERVER")},
                {"2008", new DataBaseModelVersion("2008", "SQL2008", "MSSQL$SQL2008")},
                {"2008r2", new DataBaseModelVersion("2008 R2", "SQL2008R2", "MSSQL$SQL2008R2")}
            };
            #endregion

            #region DbManager's Creation
            var host = "localhost";
            var dbManagers = new Dictionary<string, DataBaseManagerModel>
            {
                {"2005", new DataBaseManagerModel(host, dbVersions["2005"])},
                {"2008", new DataBaseManagerModel(host, dbVersions["2008"])},
                {"2008r2", new DataBaseManagerModel(host, dbVersions["2008r2"])}
            };
            #endregion

            #region Db's Creation
            var dataBases = new Dictionary<string, DataBaseModel>
            {
                {"alimport", new DataBaseModel("ALIMPORT", dbManagers["2005"])},
                {"asistur", new DataBaseModel("ASISTUR", dbManagers["2008"])},
                {"camaradecomercio", new DataBaseModel("Cámara_de_Comercio", dbManagers["2005"])},
                {"caudal", new DataBaseModel("CAUDAL", dbManagers["2008"])},
                {"ciragarcia", new DataBaseModel("Cira_García", dbManagers["2005"])},
                {"conas", new DataBaseModel("CONAS", dbManagers["2005"])},
                {"coratur", new DataBaseModel("CORATUR", dbManagers["2005"])},
                {"cubaexport", new DataBaseModel("CUBAEXPORT", dbManagers["2005"])},
                {"cubametales", new DataBaseModel("CUBAMETALES", dbManagers["2008r2"])},
                {"cubatecnica", new DataBaseModel("CUBATECNICA", dbManagers["2005"])},
                {"ejemplo", new DataBaseModel("EJEMPLO", dbManagers["2005"])},
                {"emed", new DataBaseModel("EMED", dbManagers["2005"])},
                {"esen", new DataBaseModel("ESEN", dbManagers["2008"])},
                {"expedimar", new DataBaseModel("EXPEDIMAR", dbManagers["2005"])},
                {"gecomex", new DataBaseModel("GECOMEX", dbManagers["2008"])},
                {"gesei", new DataBaseModel("GESEI", dbManagers["2005"])},
                {"interaudit", new DataBaseModel("INTERAUDIT", dbManagers["2008"])},
                {"organismocentral", new DataBaseModel("Organismo_Central", dbManagers["2005"])},
                {"organismocentralmincex", new DataBaseModel("ORGANISMO_CENTRAL_MINCEX", dbManagers["2008"])},
                {"platino", new DataBaseModel("PLATINO", dbManagers["2008"])},
                {"quimimport", new DataBaseModel("QUIMIMPORT", dbManagers["2005"])},
                {"servicex", new DataBaseModel("SERVICEX", dbManagers["2005"])},
            };
            #endregion

            var companies = new Dictionary<string, Company>();
            foreach (var db in dataBases)
                companies.Add(db.Key, new Company(db.Value.Name, db.Value));

            var auxModes = new Mode[3];

            var mode_companies = new Company[4];
            mode_companies[0] = companies["caudal"];
            mode_companies[1] = companies["esen"];
            mode_companies[2] = companies["interaudit"];
            mode_companies[3] = companies["asistur"];

            auxModes[0] = new Mode("PHR 28 de abril 2014",
                    "C:\\Program Files\\Exact\\ModuloNomina28deabril\\start.bat",
                    "C:\\Program Files\\Exact\\ModuloNomina28deabril\\stop.bat",
                    "C:\\Program Files\\Exact\\ModuloNomina28deabril\\common\\classes\\jdbc.properties",
                    mode_companies, "sa", "sa",
                    "jdbc.connectionPool.initialSize=1\r\njdbc.connectionPool.maxActiveConnections=10\r\njdbc.connectionPool.maxIdleConnections=6\r\n\r\n#CONFIGURACI?N DE LA CONEXI?N A LA BD DEL EXACT\r\njdbc.erp.driverClassName=com.microsoft.sqlserver.jdbc.SQLServerDriver\r\n#jdbc.url=jdbc:sqlserver://localhost;instanceName=SQLEXPRESS;databaseName=100\r\njdbc.erp.url=jdbc:sqlserver://;databaseName=\r\njdbc.erp.username=\r\njdbc.erp.password=\r\njdbc.erp.connectionPool.initialSize=1\r\njdbc.erp.connectionPool.maxActiveConnections=10\r\njdbc.erp.connectionPool.maxIdleConnections=6\r\n\r\n#CONFIGURACI?N DE LA CONEXI?N A LA BD HISTORICO\r\njdbc.hs.driverClassName=com.microsoft.sqlserver.jdbc.SQLServerDriver\r\njdbc.hs.url=jdbc:sqlserver://ANIA-PC;instanceName=SQL2008;databaseName=CAUDAL\r\njdbc.hs.username=phr\r\njdbc.hs.password=exact123\r\njdbc.hs.connectionPool.initialSize=1\r\njdbc.hs.connectionPool.maxActiveConnections=10\r\njdbc.hs.connectionPool.maxIdleConnections=6\r\n\r\n#NOMBRE DEl JNDI DE LA CONEXI?N A LA BASE DE DATOS DE PHR y EXACT \r\njdbc.jndi.PHR=\r\njdbc.jndi.ERPFacade=");

            mode_companies = new Company[18];
            mode_companies[0] = companies["platino"];
            mode_companies[1] = companies["cubametales"];
            mode_companies[2] = companies["emed"];
            mode_companies[3] = companies["expedimar"];
            mode_companies[4] = companies["alimport"];
            mode_companies[5] = companies["gesei"];
            mode_companies[6] = companies["camaradecomercio"];
            mode_companies[7] = companies["servicex"];
            mode_companies[8] = companies["conas"];
            mode_companies[9] = companies["ejemplo"];
            mode_companies[10] = companies["quimimport"];
            mode_companies[11] = companies["coratur"];
            mode_companies[12] = companies["cubatecnica"];
            mode_companies[13] = companies["cubaexport"];
            mode_companies[14] = companies["organismocentral"];
            mode_companies[15] = companies["organismocentralmincex"];
            mode_companies[16] = companies["gecomex"];
            mode_companies[17] = companies["caudal"];

            auxModes[1] = new Mode("PHR Client",
                    "C:\\Program Files\\Exact\\ModuloNomina\\start.bat",
                    "C:\\Program Files\\Exact\\ModuloNomina\\stop.bat",
                    "C:\\Program Files\\Exact\\ModuloNomina\\common\\classes\\jdbc.properties",
                    mode_companies, "phr", "exact123",
                    "jdbc.connectionPool.initialSize=1\r\njdbc.connectionPool.maxActiveConnections=10\r\njdbc.connectionPool.maxIdleConnections=6\r\n\r\n#CONFIGURACI?N DE LA CONEXI?N A LA BD DEL EXACT\r\njdbc.erp.driverClassName=com.microsoft.sqlserver.jdbc.SQLServerDriver\r\n#jdbc.url=jdbc:sqlserver://localhost;instanceName=SQLEXPRESS;databaseName=100\r\njdbc.erp.url=jdbc:sqlserver://ANIA-PC;databaseName=200\r\njdbc.erp.username=phr\r\njdbc.erp.password=exact123\r\njdbc.erp.connectionPool.initialSize=1\r\njdbc.erp.connectionPool.maxActiveConnections=10\r\njdbc.erp.connectionPool.maxIdleConnections=6\r\n\r\n#CONFIGURACI?N DE LA CONEXI?N A LA BD HISTORICO\r\njdbc.hs.driverClassName=com.microsoft.sqlserver.jdbc.SQLServerDriver\r\njdbc.hs.url=jdbc:sqlserver://ANIA-PC;instanceName=SQL2008;databaseName=PLATINO\r\njdbc.hs.username=phr\r\njdbc.hs.password=exact123\r\njdbc.hs.connectionPool.initialSize=1\r\njdbc.hs.connectionPool.maxActiveConnections=10\r\njdbc.hs.connectionPool.maxIdleConnections=6\r\n\r\n#NOMBRE DEl JNDI DE LA CONEXI?N A LA BASE DE DATOS DE PHR y EXACT \r\njdbc.jndi.PHR=\r\njdbc.jndi.ERPFacade=\r\n");

            mode_companies = new Company[14];
            mode_companies[0] = companies["platino"];
            mode_companies[1] = companies["caudal"];
            mode_companies[2] = companies["cubametales"];
            mode_companies[3] = companies["emed"];
            mode_companies[4] = companies["alimport"];
            mode_companies[5] = companies["gesei"];
            mode_companies[6] = companies["servicex"];
            mode_companies[7] = companies["conas"];
            mode_companies[8] = companies["quimimport"];
            mode_companies[9] = companies["asistur"];
            mode_companies[10] = companies["camaradecomercio"];
            mode_companies[11] = companies["organismocentral"];
            mode_companies[12] = companies["interaudit"];
            mode_companies[13] = companies["ciragarcia"];

            auxModes[2] = new Mode("PHR Desarrollo",
                    "C:\\Program Files\\Exact\\ModuloNominaDesarrollo\\start.bat",
                    "C:\\Program Files\\Exact\\ModuloNominaDesarrollo\\stop.bat",
                    "C:\\Program Files\\Exact\\ModuloNominaDesarrollo\\common\\classes\\jdbc.properties",
                    mode_companies, "phr", "exact123",
                    "jdbc.connectionPool.initialSize=1\r\njdbc.connectionPool.maxActiveConnections=10\r\njdbc.connectionPool.maxIdleConnections=6\r\n\r\n#CONFIGURACI?N DE LA CONEXI?N A LA BD DEL EXACT\r\njdbc.erp.driverClassName=com.microsoft.sqlserver.jdbc.SQLServerDriver\r\n#jdbc.url=jdbc:sqlserver://localhost;instanceName=SQLEXPRESS;databaseName=100\r\njdbc.erp.url=jdbc:sqlserver://;databaseName=\r\njdbc.erp.username=\r\njdbc.erp.password=\r\njdbc.erp.connectionPool.initialSize=1\r\njdbc.erp.connectionPool.maxActiveConnections=10\r\njdbc.erp.connectionPool.maxIdleConnections=6\r\n\r\n#CONFIGURACI?N DE LA CONEXI?N A LA BD HISTORICO\r\njdbc.hs.driverClassName=com.microsoft.sqlserver.jdbc.SQLServerDriver\r\njdbc.hs.url=jdbc:sqlserver://ANIA-PC;instanceName=SQL2008;databaseName=PLATINO\r\njdbc.hs.username=phr\r\njdbc.hs.password=exact123\r\njdbc.hs.connectionPool.initialSize=1\r\njdbc.hs.connectionPool.maxActiveConnections=10\r\njdbc.hs.connectionPool.maxIdleConnections=6\r\n\r\n\r\n#NOMBRE DEl JNDI DE LA CONEXI?N A LA BASE DE DATOS DE PHR y EXACT \r\njdbc.jndi.PHR=\r\njdbc.jndi.ERPFacade=\r\n");

            modes = auxModes;
        }

        private readonly IEnumerable<Mode> _modes;
        public IEnumerable<Mode> Modes { get { return _modes; } }
    }
}