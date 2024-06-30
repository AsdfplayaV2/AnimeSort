using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeSort.Parsing
{
    public static class Generics
    {
        public static string CleanUp(string name)
        {
            string result = name;

            result = RemovePath(result);
            result = RemoveFileEnding(result);
            result = RemoveSquareBrackets(result);
            result = result.Trim();
            result = RemoveEpisodeNumber(result);
            result = ReplaceUndeDots(result);
            result = result.Trim();

            return result;
        }

        private static string ReplaceUndeDots(string name)
        {
            string result = name;

            result = result.Replace('.', ' ').Replace('_', ' ');

            return result;
        }

        private static string RemovePath(string name)
        {
            string result = name;

            if (name.Contains('\\'))
            {
                result = name.Split('\\').Last();
            }

            return result;
        }

        private static string RemoveSquareBrackets(string name)
        {
            string result = "";

            for (int a = 0; a < name.Length; a++)
            {
                char currChar = name[a];
                if (currChar == '[')
                {
                    for (int b = a; b < name.Length; b++)
                    {
                        char nextChar = name[b];
                        if (nextChar == ']')
                        {
                            a = b;
                            break;
                        }
                    }
                    continue;
                }

                if (currChar == '(')
                {
                    for (int b = a; b < name.Length; b++)
                    {
                        char nextChar = name[b];
                        if (nextChar == ')')
                        {
                            a = b;
                            break;
                        }
                    }
                    continue;
                }

                result += currChar;
            }

            return result;
        }

        private static string RemoveFileEnding(string name)
        {
            string result = "";

            if (name.Contains('.'))
            {
                result = name[0..name.LastIndexOf('.')];
            }

            return result;
        }

        private static string RemoveEpisodeNumber(string name)
        {
            string result = name;

            if (name.Contains('-'))
            {
                string toCheck = name.Split('-').Last();
                if (CheckIfEpisodeNumber(toCheck))
                {
                    result = name[0..name.LastIndexOf('-')];
                }
            }
            else if (CheckIfEpisodeNumber(name.Split(' ').Last()))
            {
                result = name[0..name.LastIndexOf(' ')];
            }

            return result;
        }

        private static bool CheckIfEpisodeNumber(string name)
        {
            bool result = true;

            foreach (var item in name)
            {
                if (item > 'a' && item < 'z' && item != 'v')
                {
                    result = false;
                }

                if (item > 'A' && item < 'Z')
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
