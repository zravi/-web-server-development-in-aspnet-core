// using MovieCharactersEFCodeFirst.Data;
// using MovieCharactersEFCodeFirst.Models;
// using MovieCharactersEFCodeFirst.Tools;
//
// namespace MovieCharactersEFCodeFirst.Controllers
// {
//     public class CrudController
//     {
//         public async Task<(bool, string)> InsertEntry<T>(T entryType)
//         {
//             using (var db = new MovieManagerDbContext())
//             {
//                 if (entryType is Character c)
//                 {
//                     db.Character.Add(c);
//                 }
//                 else if (entryType is Movie m)
//                 {
//                     db.Movie.Add(m);
//                 }
//                 else if (entryType is Franchise f)
//                 {
//                     db.Franchise.Add(f);
//                 }
//
//                 try
//                 {
//                     await db.SaveChangesAsync();
//                 }
//                 catch (Exception e)
//                 {
//                     string message = e.InnerException != null ? e.InnerException.Message : e.Message;
//                     return (false, message);
//                 }
//
//                 return (true, "");
//             }
//         }
//
//         public async Task<(bool, string)> DeleteEntry(Datatypes dataType, int id)
//         {
//             using (var db = new MovieManagerDbContext())
//             {
//                 try
//                 {
//                     switch (dataType)
//                     {
//                         case Datatypes.Character:
//                             var character = db.Character.First(p => p.Id == id);
//                             db.Remove(character);
//                             break;
//                         case Datatypes.Movie:
//                             var movie = db.Movie.First(p => p.Id == id);
//                             db.Remove(movie);
//                             break;
//                         case Datatypes.Franchise:
//                             var franchise = db.Franchise.First(p => p.Id == id);
//                             db.Remove(franchise);
//                             break;
//                     }
//
//                     await db.SaveChangesAsync();
//                 }
//                 catch (Exception e)
//                 {
//                     string message = e.InnerException != null ? e.InnerException.Message : e.Message;
//                     return (false, message);
//                 }
//
//                 return (true, "");
//             }
//         }
//
//         public (List<Character>?, string) FetchAllCharacters()
//         {
//             using (var db = new MovieManagerDbContext())
//             {
//                 List<Character>? characters;
//                 try
//                 {
//                     characters = db.Character.ToList();
//                 }
//                 catch (Exception e)
//                 {
//                     string message = e.InnerException != null ? e.InnerException.Message : e.Message;
//                     return (null, message);
//                 }
//
//                 return (characters, "");
//             }
//         }
//     }
// }