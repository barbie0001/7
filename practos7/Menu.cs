using practos7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practos7
{
    public static class Menu
    {
        static public string[] options;
        static public int selectedOption = 0;
        static public void DisplayMenu()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(options[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(options[i]);
                    }
                }

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption = (selectedOption - 1 + options.Length) % options.Length;

                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption = (selectedOption + 1) % options.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (Explorer.dr)
                    {
                        Explorer.path = Explorer.drives[selectedOption].Name;
                        Explorer.dr = false;
                    }
                    else
                    {
                        File.WriteAllText("path.txt", Explorer.paths[selectedOption]);
                        Explorer.path = @Explorer.paths[selectedOption];
                    }
                    Explorer.ReadDirectory();

                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Explorer.ReadDrives();
                }

            } while (true);
        }
    }
}