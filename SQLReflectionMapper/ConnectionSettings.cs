using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace SQLReflectionMapper
{
    
    public static class ConnectionSettings
    {
        public static CSData data = new CSData();
    }
    public class CSData
    {
        
        public CSData()
        {
            //DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
        }
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
        public DbProviderFactory DBProvider;

        /// <summary>
        /// We have to call it upon settings load, it will create a provider.
        /// </summary>
        public void InitProvider()
        {
            DBProvider = DbProviderFactories.GetFactory(ProviderName);
        }
    }
}
