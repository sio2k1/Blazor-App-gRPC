using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;


namespace SQLReflectionMapper
{
    public class ParamList : Dictionary<string, object> { }
    public class TableForMapping : DataTable
    {
        public List<T> Map<T>()
        {
            List<T> results = new List<T>();
            foreach (DataRow row in this.Rows)
            {
                T item = Activator.CreateInstance<T>();
                foreach (PropertyInfo property in typeof(T).GetProperties())
                {
                    if (this.Columns.Contains(property.Name))
                    {
                        if (row[property.Name] != DBNull.Value)
                        {
                            Type convertTo =
                                Nullable.GetUnderlyingType(property.PropertyType) ??
                                property.PropertyType;
                            property.SetValue(
                                item,
                                Convert.ChangeType(row[property.Name], convertTo),
                                null);
                        }
                    }
                }
                results.Add(item);
            }
            return results;
        }


        public List<T> MapHierarchy<T>(List<Type> types, string FieldContainingType)
        {
            List<T> results = new List<T>();

            foreach (DataRow row in this.Rows)
            {
                if (this.Columns.Contains(FieldContainingType))
                {
                    string typename = row[FieldContainingType].ToString();

                    if (types.FindAll(t => t.FullName == typename).Count != 0)
                    {
                        Assembly asm = typeof(T).Assembly;
                        Type t = asm.GetType(typename);

                        object o = Activator.CreateInstance(t);
                        T item = (T)o;

                        foreach (PropertyInfo property in t.GetProperties())
                        {
                            if (this.Columns.Contains(property.Name))
                            {
                                if (row[property.Name] != DBNull.Value)
                                {
                                    Type convertTo =
                                        Nullable.GetUnderlyingType(property.PropertyType) ??
                                        property.PropertyType;
                                    property.SetValue(
                                        item,
                                        Convert.ChangeType(row[property.Name], convertTo),
                                        null);
                                }
                            }
                        }
                        results.Add(item);
                    }
                }
            }
            return results;
        }
    }

    public class ConnectionHelper : IDisposable
    {
        private bool isDisposed = false;
        public DbConnection connection;
        private DbParameter ConstructParam(KeyValuePair<string, object> param)
        {
            DbParameter dbParam = ConnectionSettings.data.DBProvider.CreateParameter();
            dbParam.Value = param.Value == null ? DBNull.Value : param.Value;
            dbParam.ParameterName = param.Key;
            return dbParam;
        }
        public ConnectionHelper(string ConnectionStr)
        {
            connection = ConnectionSettings.data.DBProvider.CreateConnection();
            connection.ConnectionString = ConnectionStr;
        }
        public DbCommand MakeCommand(string sql, ParamList paramList, CommandType commandType = CommandType.Text)
        {
            DbCommand command = ConnectionSettings.data.DBProvider.CreateCommand();
            command.Connection = connection;
            command.CommandText = sql;
            command.CommandType = commandType;
            foreach (var entry in paramList)
            {
                command.Parameters.Add(ConstructParam(entry));
            }
            connection.Open();
            return command;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {
                connection.Close();
            }
            isDisposed = true;
        }
    }
    public static class DBExecuter
    {

        public static TableForMapping SQLRequest(string sql, ParamList paramList)
        {
            using (ConnectionHelper ch = new ConnectionHelper(ConnectionSettings.data.ConnectionString))
            {
                TableForMapping myTable = new TableForMapping();
                myTable.Load(ch.MakeCommand(sql, paramList).ExecuteReader());
                return myTable;
            }
        }

        public static TableForMapping SQLRequestSPAutoFillParams(string sql, ParamList paramList)
        {
            using (ConnectionHelper ch = new ConnectionHelper(ConnectionSettings.data.ConnectionString))
            {
                TableForMapping myTable = new TableForMapping();
                myTable.Load(ch.MakeCommand(sql, paramList, CommandType.StoredProcedure).ExecuteReader());
                return myTable;
            }
        }

        public static TableForMapping SQLToReader(string sql)
        {
            return SQLRequest(sql, new ParamList());
        }

        public static int execNonQuerySPAutoFillParams(string sql, ParamList paramList)
        {
            using (ConnectionHelper ch = new ConnectionHelper(ConnectionSettings.data.ConnectionString))
            {
                return ch.MakeCommand(sql, paramList, CommandType.StoredProcedure).ExecuteNonQuery();
            }
        }


        public static int execNonQuery(string sql, ParamList paramList)
        {
            using (ConnectionHelper ch = new ConnectionHelper(ConnectionSettings.data.ConnectionString))
            {
                return ch.MakeCommand(sql, paramList).ExecuteNonQuery();
            }
        }
    }
}



/*public class ParamList : Dictionary<string, object> { }
public class ConnectionHelper:IDisposable
{
    private bool isDisposed=false;
    public DbConnection connection;
    private DbParameter ConstructParam(KeyValuePair<string, object> param)
    {
        DbParameter dbParam = ConnectionSettings.data.DBProvider.CreateParameter();
        dbParam.Value = param.Value == null ? DBNull.Value : param.Value;
        dbParam.ParameterName = param.Key;
        return dbParam;
    }
    public ConnectionHelper(string ConnectionStr)
    {
        connection = ConnectionSettings.data.DBProvider.CreateConnection();
        connection.ConnectionString = ConnectionStr;
    }
    public DbCommand MakeCommand(string sql, ParamList paramList, CommandType commandType=CommandType.Text)
    {
        DbCommand command = ConnectionSettings.data.DBProvider.CreateCommand(); 
        command.Connection = connection;
        command.CommandText = sql;
        command.CommandType = commandType;
        foreach (var entry in paramList)
        {
            command.Parameters.Add(ConstructParam(entry));
        }
        connection.Open();
        return command;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (isDisposed) return;
        if (disposing)
        {
            connection.Close();
        }
        isDisposed = true;
    }
}
public static class DBExecuter
{
    public static List<T> exec<T>(string sql)
    {
        return  exec<T>(sql, new ParamList { });
    }


    public static List<T> execSPAutoFillParams<T>(string sql, ParamList paramList)
    {
        using (ConnectionHelper ch = new ConnectionHelper(ConnectionSettings.data.ConnectionString))
        {
            DbDataReader reader = ch.MakeCommand(sql, paramList, CommandType.StoredProcedure).ExecuteReader();
            List<T> res = DBmapper.Map<T>(reader);
            reader.Close();
            return res;
        }
    }

    public static int execNonQuerySPAutoFillParams(string sql, ParamList paramList)
    {
        using (ConnectionHelper ch = new ConnectionHelper(ConnectionSettings.data.ConnectionString))
        {
            return ch.MakeCommand(sql, paramList, CommandType.StoredProcedure).ExecuteNonQuery();
        }
    }

    public static List<T> exec<T>(string sql, ParamList paramList)
    {
        using (ConnectionHelper ch = new ConnectionHelper(ConnectionSettings.data.ConnectionString))
        {
            DbDataReader reader = ch.MakeCommand(sql, paramList).ExecuteReader();
            List<T> res = DBmapper.Map<T>(reader);
            reader.Close();
            return res;
        }
    }
    public static int execNonQuery(string sql, ParamList paramList)
    {
        using (ConnectionHelper ch = new ConnectionHelper(ConnectionSettings.data.ConnectionString))
        {
            return ch.MakeCommand(sql, paramList).ExecuteNonQuery();
        }       
    }
}*/


