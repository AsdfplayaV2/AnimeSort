using AnimeSort.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AnimeSort.Logic
{
    public class Sorter
    {
        private string WorkingDirectory = "";
        private List<string> Files = new();
        private List<Tuple<string, string>> DirectoryName = new();
        private Dictionary<string, List<string>> NameFiles = new();
        public Action<string>? WriteLog;

        #region Constructors
        private Sorter()
        {

        }
        public Sorter(string? dir)
        {
            if (string.IsNullOrWhiteSpace(dir))
            {
                WorkingDirectory = "";
            }
            else
            {
                WorkingDirectory = dir;
            }
        }
        #endregion

        public bool GetFiles()
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Log("Directory does not exist");
                return false;
            }

            Files = new();
            foreach (var item in Directory.GetFiles(WorkingDirectory, "*.mkv"))
            {
                Files.Add(item);
            }
            return true;
        }

        public bool GetGroups()
        {
            try
            {
                DirectoryName = new();
                for (int first = 0; first < Files.Count; first++)
                {
                    string firstFile = Generics.CleanUp(Files[first]);
                    if (!NameFiles.ContainsKey(firstFile))
                    {
                        NameFiles[firstFile] = new();
                    }
                    NameFiles[firstFile].Add(Files[first]);
                }
                Log(NameFiles.Keys.Count + " Groups found, containing " + NameFiles.Values.Count + " Files.");
                return true;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return false;
            }
        }

        public bool MoveFiles(bool MoveSingleFiles = false)
        {
            try
            {
                foreach (var item in NameFiles)
                {
                    if (item.Value.Count > 1 || MoveSingleFiles)
                    {
                        string newDirectory = Path.Combine(WorkingDirectory, item.Key);
                        if (!Directory.Exists(newDirectory))
                        {
                            Directory.CreateDirectory(newDirectory);
                        }
                        foreach (var file in item.Value)
                        {
                            string Filename = file.Split('\\').Last();
                            string newFile = Path.Combine(newDirectory, Filename);
                            File.Move(file, newFile);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                return false;
            }
        }

        public void SetLogger(Action<string> action)
        {
            WriteLog = action;
        }
        public void Log(string s)
        {
            if (WriteLog != null)
            {
                WriteLog(s);
            }
        }
    }
}
