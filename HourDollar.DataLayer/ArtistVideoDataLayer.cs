using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;
using MySqlConnector;

namespace HourDollar.DataLayer
{
    public class ArtistVideoDataLayer : IArtistVideoDataLayer
    {
        private DatabaseSettings databaseSettings {get;}
        public ArtistVideoDataLayer(DatabaseSettings databaseSettings)
        {
            this.databaseSettings = databaseSettings;
        }
        public async Task<List<ArtistVideo>> GetAllArtistVideos()
        {
            using var cmd = databaseSettings.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL hourdollar.artistVideos_Get()";
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            await cmd.Connection.CloseAsync();
            return result.Count > 0 ? result : null;
        }

        public async Task<List<ArtistVideo>> GetArtistVideosByArtistId(int artistId)
        {
            using var cmd = databaseSettings.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL artistVideos_GetByArtistId(@artistId)";
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

        public async Task SaveArtistVideo(ArtistVideo artistVideo)
        {
            using var cmd = databaseSettings.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL artistVideos_Save(@artistId,@platformId,@videoUrl,@isActive);";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@artistId",
                DbType = DbType.Int32,
                Value = artistVideo.artistId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@platformId",
                DbType = DbType.Int32,
                Value = artistVideo.platformId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@videoUrl",
                DbType = DbType.AnsiString,
                Value = artistVideo.videoUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@isActive",
                DbType = DbType.Boolean,
                Value = artistVideo.isActive,
            });
            await cmd.ExecuteNonQueryAsync();
            await cmd.Connection.CloseAsync();
        }

        public async Task UpdateArtistVideo(ArtistVideo artistVideo)
        {
            using var cmd = databaseSettings.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL artistVideos_Update(@artistVideoId,@artistId,@platformId,@videoUrl,@isActive);";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@artistVideoId",
                DbType = DbType.Int32,
                Value = artistVideo.artistVideoId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@artistId",
                DbType = DbType.Int32,
                Value = artistVideo.artistId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@platformId",
                DbType = DbType.Int32,
                Value = artistVideo.platformId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@videoUrl",
                DbType = DbType.AnsiString,
                Value = artistVideo.videoUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@isActive",
                DbType = DbType.Boolean,
                Value = artistVideo.isActive,
            });
            await cmd.ExecuteNonQueryAsync();
            await cmd.Connection.CloseAsync();
        }

        private async Task<List<ArtistVideo>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<ArtistVideo>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new ArtistVideo
                    {
                        artistVideoId = reader.GetInt32(0),
                        artistId = reader.GetInt32(1),
                        platformId = (Platform)reader.GetInt32(2),
                        videoUrl = reader.GetString(3),
                        isActive = reader.GetBoolean(4)
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}