using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;
using MySqlConnector;

namespace HourDollar.DataLayer
{
    public class ArtistPlatformDataLayer : IArtistPlatformDataLayer
    {
        private DatabaseSettings databaseSettings { get;}
        public ArtistPlatformDataLayer(DatabaseSettings databaseSettings)
        {
            this.databaseSettings = databaseSettings;
        }

        public async Task SaveArtistPlatform(PlatformArtist platformArtist)
        {
            using var cmd = databaseSettings.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL artistPlatform_Save(@artistId,@platformId,@platformUrl,@isActive);";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@artistId",
                DbType = DbType.Int32,
                Value = platformArtist.artistId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@platformId",
                DbType = DbType.Int32,
                Value = platformArtist.platformId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@platformUrl",
                DbType = DbType.AnsiString,
                Value = platformArtist.platformUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@isActive",
                DbType = DbType.Boolean,
                Value = platformArtist.isActive,
            });
            await cmd.ExecuteNonQueryAsync();
            await cmd.Connection.CloseAsync();
        }

        public async Task<List<PlatformArtist>> GetArtistPlatformByArtistId(int artistId)
        {
            using var cmd = databaseSettings.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL artistPlatform_GetByArtistId(@artistId)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@artistId",
                DbType = DbType.Int32,
                Value = artistId,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            await cmd.Connection.CloseAsync();
            return result.Count > 0 ? result : null;
        }

        private async Task<List<PlatformArtist>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<PlatformArtist>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new PlatformArtist
                    {
                        artistPlatformId = reader.GetInt32(0),
                        artistId = reader.GetInt32(1),
                        platformId = (Platform)reader.GetInt32(2),
                        platformUrl = reader.GetString(3),
                        isActive = reader.GetBoolean(4)
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}