using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using MeusPedidos.Catalogo.Core.Domain.Entidades;
using SQLite.Net;
using SQLite.Net.Interop;

namespace MeusPedidos.Catalogo.Core.Data.Configuration
{
    public static class Configuration
    {
        public static string DatabaseFilePath
        {
            get
            {
                var sqliteFilename = "MeusPedidoCatalogo.db";

#if NETFX_CORE
				var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
#else

#if __ANDROID__
// Just use whatever directory SpecialFolder.Personal returns
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
                // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
                // (they don't want non-user-generated data in Documents)
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                //var libraryPath = Path.Combine(documentsPath, "../Library/"); // Library folder
#endif
                var path = Path.Combine(documentsPath, sqliteFilename);
#endif

#endif
                return path;
            }
        }

        public static Dictionary<Type, string> ExtraType => new Dictionary<Type, string>{{typeof(List<Politica>), "text"}};        
    }
}