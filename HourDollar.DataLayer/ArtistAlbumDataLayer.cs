using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;
using MySqlConnector;

namespace HourDollar.DataLayer
{
    public class ArtistAlbumDataLayer : IArtistAlbumDataLayer
    {
        private DatabaseSettings Db {get;}
        public ArtistAlbumDataLayer(DatabaseSettings db)
        {
            Db = db;
        }
        public Task DeleteArtistAlbumAsync(int artistAlbumId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ArtistAlbum>> GetAllAlbumsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL hourdollar.artistAlbums_Get()";
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            await cmd.Connection.CloseAsync();
            return result.Count > 0 ? result : null;
        }

        public async Task<ArtistAlbum> GetArtistAlbumsByAlbumId(int albumId)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL hourdollar.artistAlbums_GetByAlbumId(@albumId)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@albumId",
                DbType = DbType.Int32,
                Value = albumId,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            await cmd.Connection.CloseAsync();
            return result.Count > 0 ? result[0] : null;
        }


        public async Task<List<ArtistAlbum>> GetArtistAlbumsByArtistIdAsync(int artistId)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL hourdollar.artistAlbums_GetByArtistId(@id)";
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

        public async Task SaveArtistAlbumAsync(ArtistAlbum artistAlbum)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL hourdollar.artistAlbums_Save(@id,@embedUrl,@art,@releaseDate,@title,@isActive,@isSingle);";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = artistAlbum.artistId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@embedUrl",
                DbType = DbType.AnsiString,
                Value = artistAlbum.albumEmbedUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@art",
                DbType = DbType.AnsiString,
                Value = artistAlbum.albumArt,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@releaseDate",
                DbType = DbType.DateTime,
                Value = artistAlbum.albumReleaseDate,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@title",
                DbType = DbType.AnsiString,
                Value = artistAlbum.albumTitle,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@isActive",
                DbType = DbType.Boolean,
                Value = artistAlbum.isActive,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@isSingle",
                DbType = DbType.Boolean,
                Value = artistAlbum.isSingle,
            });
            await cmd.ExecuteNonQueryAsync();
            await cmd.Connection.CloseAsync();
        }

        public async Task UpdateArtistAlbumAsync(ArtistAlbum artistAlbum)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL hourdollar.artistAlbums_Update(@albumId,@id,@embedUrl,@art,@releaseDate,@title,@isActive,@isSingle);";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@albumId",
                DbType = DbType.Int32,
                Value = artistAlbum.artistAlbumId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = artistAlbum.artistId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@embedUrl",
                DbType = DbType.AnsiString,
                Value = artistAlbum.albumEmbedUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@art",
                DbType = DbType.AnsiString,
                Value = artistAlbum.albumArt,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@releaseDate",
                DbType = DbType.DateTime,
                Value = artistAlbum.albumReleaseDate,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@title",
                DbType = DbType.AnsiString,
                Value = artistAlbum.albumTitle,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@isActive",
                DbType = DbType.Boolean,
                Value = artistAlbum.isActive,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@isSingle",
                DbType = DbType.Boolean,
                Value = artistAlbum.isSingle,
            });
            await cmd.ExecuteNonQueryAsync();
            await cmd.Connection.CloseAsync();
        }

        private async Task<List<ArtistAlbum>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<ArtistAlbum>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new ArtistAlbum
                    {
                        artistAlbumId = reader.GetInt32(0),
                        artistId = !reader.IsDBNull(1) ? reader.GetInt32(1) : 0,
                        albumEmbedUrl = !reader.IsDBNull(2) ? reader.GetString(2) : "null",
                        albumArt = !reader.IsDBNull(3) ? reader.GetString(3) : "null",
                        albumReleaseDate = reader.GetDateTime(4),
                        albumTitle = !reader.IsDBNull(5) ? reader.GetString(5) : "null",
                        isActive = reader.GetBoolean(6),
                        isSingle = reader.GetBoolean(7)
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}