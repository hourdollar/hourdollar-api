using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;
using MySqlConnector;

namespace HourDollar.DataLayer
{
    public class AlbumPlatformDataLayer : IAlbumPlatformDataLayer
    {
        private DatabaseSettings Db {get;}
        public AlbumPlatformDataLayer(DatabaseSettings db)
        {
            Db = db;
        }
        public async Task SaveAlbumPlatform(PlatformAlbum platformAlbum)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL hourdollar.albumPlatform_Save(@albumId,@platformId,@directUrl,@isActive);";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@albumId",
                DbType = DbType.Int32,
                Value = platformAlbum.artistAlbumId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@platformId",
                DbType = DbType.Int32,
                Value = platformAlbum.platformId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@directUrl",
                DbType = DbType.AnsiString,
                Value = platformAlbum.albumDirectUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@isActive",
                DbType = DbType.Boolean,
                Value = platformAlbum.isActive,
            });
            await cmd.ExecuteNonQueryAsync();
            await cmd.Connection.CloseAsync();
        }

        public async Task<List<PlatformAlbum>> GetAlbumPlatformByAlbumId(int albumId)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL albumPlatform_GetByAlbumId(@albumId)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@albumId",
                DbType = DbType.Int32,
                Value = albumId,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            await cmd.Connection.CloseAsync();
            return result.Count > 0 ? result : null;
        }

        private async Task<List<PlatformAlbum>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<PlatformAlbum>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new PlatformAlbum
                    {
                        albumPlatformId = reader.GetInt32(0),
                        artistAlbumId = reader.GetInt32(1),
                        platformId = (Platform)reader.GetInt32(2),
                        albumDirectUrl = reader.GetString(3),
                        isActive = reader.GetBoolean(4)
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}

// YourEnum foo = (YourEnum)yourInt;