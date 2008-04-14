using System;
using System.Collections;
using System.IO;
using System.Reflection;
using Powerasp.Enterprise.Core.Caching;
using Powerasp.Enterprise.Core.Configuration;

namespace Powerasp.Enterprise.Core.Configuration
{
    public class SettingsFactory
    {
        private static FileCache __checker = FileCache.CreateInstance(30);
        private static Hashtable __settings = Hashtable.Synchronized(new Hashtable());
        private static ArrayList __watchFiles = ArrayList.Synchronized(new ArrayList());
        public const string DefaultFileName = "environment.config";
        private const int IntervalSecond = 30;

        public static ISettings CreateSettings()
        {
            return CreateSettings(Assembly.GetCallingAssembly());
        }

        public static ISettings CreateSettings(Stream inStream)
        {
            if ((inStream == null) || (inStream == Stream.Null))
            {
                throw new ArgumentNullException("inStream");
            }
            if (inStream is FileStream)
            {
                return CreateSettings(((FileStream) inStream).Name);
            }
            Settings settings = new Settings(string.Empty);
            settings.ReadXml(inStream);
            return settings;
        }

        public static ISettings CreateSettings(Assembly assembly)
        {
            FileInfo info = new FileInfo(assembly.CodeBase.Replace("file:///", ""));
            return CreateSettings(string.Format(@"{0}\{1}", info.Directory.FullName, "environment.config"));
        }

        public static ISettings CreateSettings(string fileName)
        {
            return CreateSettings(fileName, true);
        }

        public static ISettings CreateSettings(Type type)
        {
            return CreateSettings(type.Assembly);
        }

        public static ISettings CreateSettings(string fileName, bool watch)
        {
            if ((fileName == null) || (fileName == string.Empty))
            {
                throw new ArgumentException("fileName");
            }
            Settings item = null;
            if (__settings.ContainsKey(fileName))
            {
                return (__settings[fileName] as Settings);
            }
            item = new Settings(fileName);
            item.LoadFrom(fileName);
            if (watch)
            {
                __checker.Add(item);
            }
            return item;
        }

        ~SettingsFactory()
        {
            foreach (Settings settings in __settings.Values)
            {
                try
                {
                    __checker.Remove(settings);
                    continue;
                }
                catch
                {
                    continue;
                }
            }
            __checker = null;
        }
    }
}