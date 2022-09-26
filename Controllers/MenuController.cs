using MovieCharactersEFCodeFirst.Data;
using MovieCharactersEFCodeFirst.Models;
using System;
using System.Configuration;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using MovieCharactersEFCodeFirst.Data;
using MovieCharactersEFCodeFirst.Models;
using MovieCharactersEFCodeFirst.Tools;

namespace MovieCharactersEFCodeFirst.Controllers
{
    public class MenuController
    {
        readonly StringBuilder _sb = new();

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
                          "1. Insert a new character\n" +
                          "2. Show character\n" +
                          "3. Update character\n" +
                          "4. Delete character\n\n" +
                          "Esc. Return");
                
                Console.WriteLine(_sb.ToString());
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        ShowCharacterInsertPrompt();
                        break;
                    case ConsoleKey.D2:
                        // Character read prompt
                        break;
                    case ConsoleKey.D3:
                        // Character update prompt
                        break;
                    case ConsoleKey.D4:
                        // Character delete prompt
                        break;
                    case ConsoleKey.Escape:
                        returnToMainMenu = true;
                        break;
                }
            }
        }

        void ShowCharacterInsertPrompt()
        {
            string? name = "";
            while (name.IsNullOrEmpty() || name?.Length < 1)
            {
                Console.Clear();
                Console.Write("Insert name (required):\n");
                name = Console.ReadLine();
            }
            
            Console.Clear();
            Console.Write($"Name: {name}\n\nInsert alias (optional):\n");
            string? aliasInput = Console.ReadLine();
            string? alias = aliasInput.IsNullOrEmpty() ? null : aliasInput;

            int? age = null;
            Console.Clear();
            Console.Write($"Name: {name}\nAlias: {alias}\n\nInsert age (optional):\n");
            if(int.TryParse(Console.ReadLine(), out int inputAge))
            {
                age = inputAge;
            }

            Console.Clear();
            Console.Write($"Name: {name}\nAlias: {alias}\nAge: {age}\n\nInsert gender (optional):\n");
            string? genderInput = Console.ReadLine();
            string? gender = genderInput.IsNullOrEmpty() ? null : genderInput;
            
            Console.Clear();
            Console.Write($"Name: {name}\nAlias: {alias}\nAge: {age}\nGender: {gender}\n\nInsert picture URL (optional):\n");
            string? pictureInput = Console.ReadLine();
            string? picture = pictureInput.IsNullOrEmpty() ? null : pictureInput;

            Console.Clear();
            Console.Write($"Name: {name}\nAlias: {alias}\nAge: {age}\nGender: {gender}\nPicture: {picture}");
            
            var cc = new CrudController();
            Character c = new Character()
                { FullName = name, Age = age, Alias = alias, Gender = gender, Picture = picture };

            Console.WriteLine("\n\nInserting...");
            
            (bool succeeded, string errorMessage) = cc.InsertEntry(c).GetAwaiter().GetResult();
            if (succeeded)
            {
                Console.WriteLine("\nInsert succeeded!");
                Thread.Sleep(2000);
            }
            else
            {
                TextColorManager.Warning($"\nInsert failed!" +
                                         $"\nError: {errorMessage}" +
                                         $"\n\nPress any key to continue...");
                Console.ReadLine();
            }
        }
    }
}