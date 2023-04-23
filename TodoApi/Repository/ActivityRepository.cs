using Dapper;
using Microsoft.OpenApi.Validations;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        public async Task<IEnumerable<ActivityModel>> GetAll()
        {
            var connectionDataBase = new Constants();
            string connection = connectionDataBase.connectionDataBase;

            using (var sqlConnection = new SqlConnection(connection)) 
            {
                var sql = "SELECT * FROM TbActivity";

                var Activitys = await sqlConnection.QueryAsync<ActivityModel>(sql) as IEnumerable<ActivityModel>;
                return Activitys;
            }
        }

        public async void Add(ActivityModel activity)
        {
            var connectionDataBase = new Constants();
            string connection = connectionDataBase.connectionDataBase;
            using (var sqlConnection = new SqlConnection(connection))
            {
                var sql = "INSERT into TbActivity (title, description, priority, status, dataStart, dataEnd) VALUES (@title, @description, @priority, @status, @dataStart, @dataEnd)";
                var parameters = new DynamicParameters();
                parameters.Add("@title", activity.title);
                parameters.Add("@description", activity.description);
                parameters.Add("@priority", activity.priority);
                parameters.Add("@status", activity.status);
                parameters.Add("@dataStart", activity.dataStart);
                parameters.Add("@dataEnd", activity.dataEnd);

                await sqlConnection.ExecuteScalarAsync(sql, parameters);
            }
        }

        public async void Update(ActivityModel activity)
        {
            var connectionDataBase = new Constants();
            string connection = connectionDataBase.connectionDataBase;
            using (var sqlConnection = new SqlConnection(connection))
            {
                var sql = "UPDATE TbActivity SET " +
                    "title = @title, " +
                    "description = @description, " +
                    "priority = @priority, " +
                    "status = @status, " +
                    "dataStart = @dataStart, " +
                    "dataEnd = @dataEnd " +
                    "WHERE id = @id";
                var parameters = new DynamicParameters();
                parameters.Add("@id", activity.id);
                parameters.Add("@title", activity.title);
                parameters.Add("@description", activity.description);
                parameters.Add("@priority", activity.priority);
                parameters.Add("@status", activity.status);
                parameters.Add("@dataStart", activity.dataStart);
                parameters.Add("@dataEnd", activity.dataEnd);

                await sqlConnection.ExecuteAsync(sql, parameters);
            }
        }

        public async void Delete(string activityId)
        {
            var connectionDataBase = new Constants();
            string connection = connectionDataBase.connectionDataBase;
            using (var sqlConnection = new SqlConnection(connection)) 
            {
                var sql = "DELETE from TbActivity " +
                    "where id = @id";
                var parameters = new DynamicParameters();
                parameters.Add("@id", activityId);

                await sqlConnection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
