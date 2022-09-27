using MovieCharactersEFCodeFirst.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MovieCharactersEFCodeFirst.Models.Domain;
using MovieCharactersEFCodeFirst.Tools;

namespace MovieCharactersEFCodeFirst.Controllers
{
    public class MenuController
    {
        readonly StringBuilder _sb = new();
        // readonly CrudController _cc = new();

        public void MenuInit()
        {
            TextColorManager.ResetColor();

            while (true)
            {
                Console.Clear();
                _sb.Clear();
                _sb.Append("Movie Database\n\n" +
                           "1. Characters\n" +
                           "2. Movies\n" +
                           "3. Franchises");

                Console.WriteLine(_sb.ToString());

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        ShowCharacterSubmenu();
                        break;
                    case ConsoleKey.D2:
                        // Movies submenu
                        break;
                    case ConsoleKey.D3:
                        // Franchises submenu
                        break;
                }
            }
        }

        void ShowCharacterSubmenu()
        {
            bool returnToMainMenu = false;
            while (!returnToMainMenu)
            {
                Console.Clear();
                _sb.Clear();
                _sb.Append("Characters\n\n" +
                           "1. Show all\n" +
                           "2. Insert a new character\n" +
                           "3. Show character\n" +
                           "4. Update character\n" +
                           "5. Delete character\n\n" +
                           "Esc. Return");

                Console.WriteLine(_sb.ToString());
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        DisplayAllCharacters();
                        break;
                    case ConsoleKey.D2:
                        ShowCharacterInsertPrompt();
                        break;
                    case ConsoleKey.D3:
                        // Character read prompt
                        break;
                    case ConsoleKey.D4:
                        // Character update prompt
                        break;
                    case ConsoleKey.D5:
                        DeleteEntryById(Datatypes.Character, IdPrompt());
                        break;
                    case ConsoleKey.Escape:
                        returnToMainMenu = true;
                        break;
                }
            }
        }

        void DisplayAllCharacters()
        {
            // (List<Character>? characters, string errorMessage) = _cc.FetchAllCharacters();
            //
            // Console.Clear();
            // if (characters != null)
            // {
            //     _sb.Clear();
            //
            //     _sb.Append(
            //         $" {"ID",-5}| {"NAME",-30}| {"ALIAS",-30}| {"AGE",-7}| {"GENDER",-15}|\n");
            //
            //     foreach (Character c in characters)
            //     {
            //         _sb.Append(GetCharacterDetailsDisplayFormat(c));
            //     }
            //
            //     TextColorManager.SetColor(ConsoleColor.DarkGreen);
            //     Console.WriteLine(_sb.ToString());
            //     TextColorManager.ResetColor();
            //     Console.WriteLine("Press any key to continue...");
            //     Console.ReadLine();
            // }
            // else
            // {
            //     TextColorManager.Warning($"\nFetch characters failed!" +
            //                              $"\nError: {errorMessage}" +
            //                              $"\n\nPress any key to continue...");
            //     Console.ReadLine();
            // }
        }

        void ShowCharacterInsertPrompt()
        {
            // string? name = "";
            // while (name.IsNullOrEmpty() || name?.Length < 1)
            // {
            //     Console.Clear();
            //     Console.Write("Insert name (required):\n");
            //     name = Console.ReadLine();
            // }
            //
            // Console.Clear();
            // TextColorManager.WriteInColor($"Name: {name}", ConsoleColor.DarkGreen);
            // Console.WriteLine("\nInsert alias (optional):\n");
            // string? aliasInput = Console.ReadLine();
            // string? alias = aliasInput.IsNullOrEmpty() ? null : aliasInput;
            //
            // int? age = null;
            // Console.Clear();
            // TextColorManager.WriteInColor($"Name: {name}\nAlias: {alias}", ConsoleColor.DarkGreen);
            // Console.WriteLine("\nInsert age (optional):\n");
            // if (int.TryParse(Console.ReadLine(), out int inputAge))
            // {
            //     age = inputAge;
            // }
            //
            // Console.Clear();
            // TextColorManager.WriteInColor($"Name: {name}\nAlias: {alias}\nAge: {age}", ConsoleColor.DarkGreen);
            // Console.WriteLine("\nInsert gender (optional):\n");
            // string? genderInput = Console.ReadLine();
            // string? gender = genderInput.IsNullOrEmpty() ? null : genderInput;
            //
            // Console.Clear();
            // TextColorManager.WriteInColor($"Name: {name}\nAlias: {alias}\nAge: {age}\nGender: {gender}", ConsoleColor.DarkGreen);
            // Console.WriteLine("\nInsert picture URL (optional):\n");
            // string? pictureInput = Console.ReadLine();
            // string? picture = pictureInput.IsNullOrEmpty() ? null : pictureInput;
            //
            // Console.Clear();
            // TextColorManager.WriteInColor($"Name: {name}\nAlias: {alias}\nAge: {age}\nGender: {gender}\nPicture: {picture}", ConsoleColor.DarkGreen);
            //
            // Character c = new Character()
            //     { FullName = name, Age = age, Alias = alias, Gender = gender, Picture = picture };
            //
            // Console.WriteLine("\nInserting...");
            //
            // (bool succeeded, string errorMessage) = _cc.InsertEntry(c).GetAwaiter().GetResult();
            // if (succeeded)
            // {
            //     Console.WriteLine("Insert succeeded!");
            //     Thread.Sleep(2000);
            // }
            // else
            // {
            //     TextColorManager.Warning($"\nInsert failed!" +
            //                              $"\nError: {errorMessage}" +
            //                              $"\n\nPress any key to continue...");
            //     Console.ReadLine();
            // }
        }

        int IdPrompt()
        {
            Console.Clear();
            Console.WriteLine("Insert ID:");
            bool proceed = false;
            int selectedId = 0;
            while (!proceed)
            {
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    selectedId = id;
                    proceed = true;
                }
            }

            return selectedId;
        }

        void DeleteEntryById(Datatypes datatype, int id)
        {
            // Console.Clear();
            // Console.WriteLine("Deleting...");
            // (bool succeeded, string errorMessage) = _cc.DeleteEntry(datatype, id).GetAwaiter().GetResult();
            // if (succeeded)
            // {
            //     Console.WriteLine("Delete succeeded!");
            //     Thread.Sleep(2000);
            // }
            // else
            // {
            //     TextColorManager.Warning($"\nDelete failed!" +
            //                              $"\nError: {errorMessage}" +
            //                              $"\n\nPress any key to continue...");
            //     Console.ReadLine();
            // }
        }

        string GetCharacterDetailsDisplayFormat(Character c)
        {
            return($" {c.Id,-5}| {c.FullName,-30}|" +
                       $" {c.Alias,-30}| {c.Age,-7}| {c.Gender,-15}|\n");
        }
    }
}