using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace UnDeadSchool
{
    public static class ResourceManager<T>
    {
        static Dictionary<string, T> resources;

        public static T Find(string key)
        {
            return resources[key];
        }

        static ResourceManager()
        {
            resources = new Dictionary<string, T>();
        }

        public static void LoadDirectory(ContentManager content, string path)
        {
            string[] filesNames = Directory.GetFiles(content.RootDirectory + "/" + path, "*.xnb");
            for (int cptFiles = 0; cptFiles < filesNames.Length; cptFiles++)
            {
                FileInfo file = new FileInfo(filesNames[cptFiles]);
                string name = file.Name;
                name = name.Remove(name.IndexOf(file.Extension));
                try
                {
                    resources.Add(name, content.Load<T>(path + name));
                }
                finally
                {

                }
            }
            
        }

        public static void Clear()
        {
            resources.Clear();
        }
    }
}