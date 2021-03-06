﻿using System;
using System.IO;
using System.Reflection;

namespace ARKBreedingStats
{

    public static class FileService
    {
        private const string jsonFolder = "json";

        public const string ValuesFolder = "values";
        public const string ValuesJson = "values.json";
        public const string ValuesServerMultipliers = "serverMultipliers.json";
        public const string TamingFoodData = "tamingFoodData.json";
        public const string ModsManifest = "_manifest.json";
        public const string KibblesJson = "kibbles.json";
        public const string AliasesJson = "aliases.json";
        public const string ArkDataJson = "ark_data.json";
        public const string IgnoreSpeciesClasses = "ignoreSpeciesClasses.json";

        public static readonly string ExeFilePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
        public static readonly string ExeLocation = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

        /// <summary>
        /// Returns a <see cref="FileStream"/> of a file located in the json data folder
        /// </summary>
        /// <param name="fileName">name of file to read; use FileService constants</param>
        /// <returns></returns>
        public static FileStream GetJsonFileStream(string fileName)
        {
            return File.OpenRead(GetJsonPath(fileName));
        }

        /// <summary>
        /// Returns a <see cref="StreamReader"/> of a file located in the json data folder
        /// </summary>
        /// <param name="fileName">name of file to read; use FileService constants</param>
        /// <returns></returns>
        public static StreamReader GetJsonFileReader(string fileName)
        {
            return File.OpenText(GetJsonPath(fileName));
        }

        /// <summary>
        /// Gets the full path for the given filename or the path to the application data folder
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetPath(string fileName = null)
        {
            return Path.Combine(Updater.IsProgramInstalled ? getLocalApplicationDataPath() : ExeLocation, fileName ?? string.Empty);
        }

        /// <summary>
        /// Gets the full path for the given filename or the path to the json folder
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetJsonPath(string fileName = null, string fileName2 = null)
        {
            return Path.Combine(Updater.IsProgramInstalled ? getLocalApplicationDataPath() : ExeLocation, jsonFolder, fileName ?? string.Empty, fileName2 ?? string.Empty);
        }

        private static string getLocalApplicationDataPath()
        {
            return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), // C:\Users\xxx\AppData\Local\
                    Path.GetFileNameWithoutExtension(ExeFilePath) ?? "ARK Smart Breeding"); // ARK Smart Breeding;
        }
    }
}
