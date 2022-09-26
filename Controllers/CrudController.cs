using MovieCharactersEFCodeFirst.Data;
using MovieCharactersEFCodeFirst.Models;

namespace MovieCharactersEFCodeFirst.Controllers
{
    public class CrudController
    {
        public async Task<(bool, string)> InsertEntry<T>(T entryType)
        {
            using (var db = new MovieManagerDbContext())
            {
                if (entryType is Character c)
                {
                    db.Character.Add(c);
                }
                else if (entryType is Movie m)
                {
                    db.Movie.Add(m);
                }
                else if (entryType is Franchise f)
                {
                    db.Franchise.Add(f);
                }

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    string message = e.InnerException != null ? e.InnerException.Message : e.Message;
                    return (false, message);
                }

                return (true, "");
            }
        }
        
        public (List<Character>?, string) FetchAllCharacters()
        {
            using (var db = new MovieManagerDbContext())
            {
                List<Character>? characters;
                try
                {
                    characters = db.Character.ToList();
                }
                catch (Exception e)
                {
                    string message = e.InnerException != null ? e.InnerException.Message : e.Message;
                    return (null, message);
                }

                return (characters, "");
            }
        }
    }
}