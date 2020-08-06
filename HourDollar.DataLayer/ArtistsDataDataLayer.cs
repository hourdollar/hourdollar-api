using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;
using MySqlConnector;

namespace HourDollar.DataLayer
{
    public class ArtistsDataDataLayer : IArtistsDataDataLayer
    {
        public DatabaseSettings Db { get; }
        public int artistId { get; set; }
        public string artistName { get; set; }

        public ArtistsDataDataLayer(DatabaseSettings db)
        {
            Db = db;
        }

        public async Task<List<ArtistInformation>> GetArtistData()
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL hourdollar.Artists_Get()";
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            await cmd.Connection.CloseAsync();
            return result.Count > 0 ? result : null;
        }

        public async Task<ArtistInformation> GetArtistDataById(int artistId)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL hourdollar.Artists_GetById(@id)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = artistId,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            await cmd.Connection.CloseAsync();
            return result.Count > 0 ? result[0] : null;
        }

        public async Task InsertArtist(ArtistInformation artist)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL hourdollar.Artists_AddArtist(@name,@route,@twitter,@instagram,@facebook,@bio,@calendar,@isActive);";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.AnsiString,
                Value = artist.artistName,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@route",
                DbType = DbType.AnsiString,
                Value = artist.artistRoute,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@twitter",
                DbType = DbType.AnsiString,
                Value = artist.twitterUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@instagram",
                DbType = DbType.AnsiString,
                Value = artist.instagramUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@facebook",
                DbType = DbType.AnsiString,
                Value = artist.facebookUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@bio",
                DbType = DbType.String,
                Value = artist.artistBio,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@calendar",
                DbType = DbType.AnsiString,
                Value = artist.calendarUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@isActive",
                DbType = DbType.Boolean,
                Value = artist.isActive,
            });
            await cmd.ExecuteNonQueryAsync();
            await cmd.Connection.CloseAsync();
        }

        public async Task DeleteArtistAsync(int artistId)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"DELETE FROM hourdollar.artists WHERE artistId = @id;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = artistId
            });
            await cmd.ExecuteNonQueryAsync();
            await cmd.Connection.CloseAsync();
        }

        public async Task UpdateArtistAsync(ArtistInformation artist)
        {
            using var cmd = Db.Connection.CreateCommand();
            await cmd.Connection.OpenAsync();
            cmd.CommandText = @"CALL Artists_UpdateById(@id,@name,@route,@twitter,@instagram,@facebook,@bio,@calendar,@isActive)";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = artist.artistId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.AnsiString,
                Value = artist.artistName,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@route",
                DbType = DbType.AnsiString,
                Value = artist.artistRoute,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@twitter",
                DbType = DbType.AnsiString,
                Value = artist.twitterUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@instagram",
                DbType = DbType.AnsiString,
                Value = artist.instagramUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@facebook",
                DbType = DbType.AnsiString,
                Value = artist.facebookUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@bio",
                DbType = DbType.String,
                Value = artist.artistBio,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@calendar",
                DbType = DbType.AnsiString,
                Value = artist.calendarUrl,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@isActive",
                DbType = DbType.Boolean,
                Value = artist.isActive,
            });
            await cmd.ExecuteNonQueryAsync();
            await cmd.Connection.CloseAsync();
        }


        private async Task<List<ArtistInformation>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<ArtistInformation>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new ArtistInformation
                    {
                        artistId = reader.GetInt32(0),
                        artistName = reader.GetString(1),
                        artistRoute = reader.GetString(2),
                        calendarUrl = !reader.IsDBNull(3) ? reader.GetString(3) : "null",
                        twitterUrl = !reader.IsDBNull(4) ? reader.GetString(4) : "null",
                        instagramUrl = !reader.IsDBNull(5) ? reader.GetString(5) : "null",
                        facebookUrl = !reader.IsDBNull(6) ? reader.GetString(6) : "null",
                        artistBio = !reader.IsDBNull(7) ? reader.GetString(7) : "null",
                        isActive = reader.GetBoolean(8)
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}