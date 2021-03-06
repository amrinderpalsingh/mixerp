﻿using System.Collections.Generic;
using System.Configuration;
using MixERP.Net.Common;
using MixERP.Net.Common.Helpers;
using Npgsql;
using PetaPoco;

namespace MixERP.Net.Entities
{
    public sealed class Factory
    {
        private const string ProviderName = "Npgsql";

        public static IEnumerable<T> Get<T>(string sql, params object[] args)
        {
            using (Database db = new Database(GetConnectionString()))
            {
                return db.Query<T>(sql, args);
            }
        }

        public static T Scalar<T>(string sql, params object[] args)
        {
            using (Database db = new Database(GetConnectionString()))
            {
                return db.ExecuteScalar<T>(sql, args);
            }
        }

        public static void NonQuery(string sql, params object[] args)
        {
            using (Database db = new Database(GetConnectionString()))
            {
                db.Execute(sql, args);
            }
        }

        private static string GetConnectionString()
        {
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = ConfigurationHelper.GetDbServerParameter("Server"),
                Database = ConfigurationHelper.GetDbServerParameter("Database"),
                UserName = ConfigurationHelper.GetDbServerParameter("UserId"),
                Password = ConfigurationHelper.GetDbServerParameter("Password"),
                Port = Conversion.TryCastInteger(ConfigurationHelper.GetDbServerParameter("Port")),
                SyncNotification = true,
                Pooling = true,
                SSL = true,
                SslMode = SslMode.Prefer,
                MinPoolSize = 10,
                MaxPoolSize = 100,
                ApplicationName = "MixERP"
            };

            //connectionStringBuilder.ApplicationName = "MixERP";
            return connectionStringBuilder.ConnectionString;
        }
    }
}