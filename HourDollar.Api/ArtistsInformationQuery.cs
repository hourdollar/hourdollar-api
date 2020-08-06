// using System.Collections.Generic;
// using System.Data;
// using System.Data.Common;
// using System.Threading.Tasks;
// using HourDollar.Api.Models;
// using HourDollar.DataLayer;
// using MySqlConnector;

// namespace HourDollar.Api
// {
//     public class ArtistsInformationQuery
//     {
//         public DatabaseSettings Db { get; }

//         public ArtistsInformationQuery(DatabaseSettings db)
//         {
//             Db = db;
//         }

//         public async Task<ArtistInformation> FindOneAsync(int id)
//         {
//             using var cmd = Db.Connection.CreateCommand();
//             cmd.CommandText = @"CALL hourdollar.Artists_GetById(@id)";
//             cmd.Parameters.Add(new MySqlParameter
//             {
//                 ParameterName = "@id",
//                 DbType = DbType.Int32,
//                 Value = id,
//             });
//             var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
//             return result.Count > 0 ? result[0] : null;
//         }

//         public async Task<List<ArtistInformation>> LatestPostsAsync()
//         {
//             using var cmd = Db.Connection.CreateCommand();
//             cmd.CommandText = @"SELECT `Id`, `Title`, `Content` FROM `BlogPost` ORDER BY `Id` DESC LIMIT 10;";
//             return await ReadAllAsync(await cmd.ExecuteReaderAsync());
//         }

//         public async Task DeleteAllAsync()
//         {
//             using var txn = await Db.Connection.BeginTransactionAsync();
//             using var cmd = Db.Connection.CreateCommand();
//             cmd.CommandText = @"DELETE FROM `BlogPost`";
//             await cmd.ExecuteNonQueryAsync();
//             await txn.CommitAsync();
//         }

//         private async Task<List<ArtistInformation>> ReadAllAsync(DbDataReader reader)
//         {
//             var posts = new List<ArtistInformation>();
//             using (reader)
//             {
//                 while (await reader.ReadAsync())
//                 {
//                     var post = new ArtistInformation(Db)
//                     {
//                         artistId = reader.GetInt32(0),
//                         artistName = reader.GetString(1),
//                     };
//                     posts.Add(post);
//                 }
//             }
//             return posts;
//         }
//     }
// }