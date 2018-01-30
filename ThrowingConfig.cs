using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ThrowingClass
{
    public static class ThrowingConfig
    {
        public static bool InfiniteJavelins = true;
        const string InfiniteJavelinsKey = "Infinite Javelins";
        public static bool InfiniteShurikens = true;
        const string InfiniteShurikensKey = "Infinite Shurikens";
        public static bool InfiniteKnives = true;
        const string InfiniteKnivesKey = "Infinite Knives";
        public static bool InfiniteElse = true;
        const string InfiniteElseKey = "Infinite Else";

        //The file will be stored in "Terraria/ModLoader/Mod Configs/Example Mod.json"
        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "ThrowingClass.json");
        static Preferences Configuration = new Preferences(ConfigPath);

        public static void Load()
        {
            //Reading the config file
            bool success = ReadConfig();

            if (!success)
            {
                ErrorLogger.Log("Failed to read Example Mod's config file! Recreating config...");
                CreateConfig();
            }
        }

        //Returns "true" if the config file was found and successfully loaded.
        static bool ReadConfig()
        {
            if (Configuration.Load())
            {
                Configuration.Get("InfiniteJavelins", ref InfiniteJavelins);
                Configuration.Get("InfiniteShurikens", ref InfiniteShurikens);
                Configuration.Get("InfiniteKnives", ref InfiniteKnives);
                Configuration.Get("InfiniteElse", ref InfiniteElse);
            }
            return false;
        }

        //Creates a config file. This will only be called if the config file doesn't exist yet or it's invalid. 
        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("InfiniteJavelins", InfiniteJavelins);
            Configuration.Put("InfiniteShurikens", InfiniteShurikens);
            Configuration.Put("InfiniteKnives", InfiniteKnives);
            Configuration.Put("InfiniteElse", InfiniteElse);
            Configuration.Save();
        }
    }
}
