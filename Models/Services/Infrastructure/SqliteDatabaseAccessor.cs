using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using TestWeb1.Models.Services.Infrastructure;

namespace TestWeb1
{
    public class SqliteDatabaseAccessor:IDatabaseAccessor
    {
         public DataSet Query(FormattableString formattableQuery){

             var queryArguments = formattableQuery.GetArguments();
             var sqliteParameters = new List<SqliteParameter>();
             for (var i = 0; i < queryArguments.Length; i++)
             {
                 var parameter = new SqliteParameter(i.ToString(), queryArguments[i]);
                 sqliteParameters.Add(parameter);
                 queryArguments[i] = "@" + i;
             }
             string query = formattableQuery.ToString();

             using(var conn = new SqliteConnection("DataSource=Data/MyCourse.db")){
                 conn.Open();
                 using (var cmd = new SqliteCommand(query, conn))
                 {
                     cmd.Parameters.AddRange(sqliteParameters);
                     using (var reader = cmd.ExecuteReader())
                     {
                         var dataSet = new DataSet();
                         dataSet.EnforceConstraints = false;

                         do{
                            var dataTable = new DataTable();
                            dataSet.Tables.Add(dataTable);
                            dataTable.Load(reader);
                         } while(!reader.IsClosed);

                         return dataSet;
                     }
                 }
             }

         }
    }
}
