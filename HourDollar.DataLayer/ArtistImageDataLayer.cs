using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;
using MySqlConnector;

namespace HourDollar.DataLayer
{
    public class ArtistImageDataLayer : IArtistImageDataLayer
    {
        public DatabaseSettings Db { get; }

        public ArtistImageDataLayer(DatabaseSettings db)
        {
            Db = db;
        }
        public async Task<List<ArtistImage>> GetArtistImagesByArtistId(int artistId)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL artistImages_GetByArtistId(@id)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = artistId,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            await cmd.Connection.CloseAsync();
            return result.Count > 0 ? result : null;
        }

        public async Task DeleteImageAsync(int artistImageId)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"DELETE FROM hourdollar.artistImages WHERE artistImageId = @id;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = artistImageId
            });
            await cmd.ExecuteNonQueryAsync();
            await cmd.Connection.CloseAsync();
        }

        private async Task<List<ArtistImage>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<ArtistImage>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new ArtistImage
                    {
                        artistImageId = reader.GetInt32(0),
                        artistId = reader.GetInt32(1),
                        imageUrl = reader.GetString(2)
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}