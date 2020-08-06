// using System.Data;
// using System.Threading.Tasks;
// using HourDollar.DataLayer;
// using MySqlConnector;

// namespace HourDollar.Api.Models
// {
//     public class ArtistInformation
//     {
//         public int artistId { get; set; }
//         public string artistName { get; set; }

//         internal DatabaseSettings Db { get; set; }

//         public ArtistInformation()
//         {
//         }

//         internal ArtistInformation(DatabaseSettings db)
//         {
//             Db = db;
//         }

//         public async Task InsertAsync()
//         {
//             using var cmd = Db.Connection.CreateCommand();
//             cmd.CommandText = @"INSERT INTO `BlogPost` (`Title`, `Content`) VALUES (@title, @content);";
//             BindParams(cmd);
//             await cmd.ExecuteNonQueryAsync();
//             artistId = (int) cmd.LastInsertedId;
//         }

//         public async Task UpdateAsync()
//         {
//             using var cmd = Db.Connection.CreateCommand();
//             cmd.CommandText = @"UPDATE `BlogPost` SET `Title` = @title, `Content` = @content WHERE `Id` = @id;";
//             BindParams(cmd);
//             BindId(cmd);
//             await cmd.ExecuteNonQueryAsync();
//         }

//         public async Task DeleteAsync()
//         {
//             using var cmd = Db.Connection.CreateCommand();
//             cmd.CommandText = @"DELETE FROM `BlogPost` WHERE `Id` = @id;";
//             BindId(cmd);
//             await cmd.ExecuteNonQueryAsync();
//         }

//         private void BindId(MySqlCommand cmd)
//         {
//             cmd.Parameters.Add(new MySqlParameter
//             {
//                 ParameterName = "@id",
//                 DbType = DbType.Int32,
//                 Value = artistId,
//             });
//         }

//         private void BindParams(MySqlCommand cmd)
//         {
//             cmd.Parameters.Add(new MySqlParameter
//             {
//                 ParameterName = "@title",
//                 DbType = DbType.String,
//                 Value = artistName,
//             });
//         }
//     }
// }