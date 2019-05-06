using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ejemplo050519.iOS;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSSQLiteConnection))]
namespace Ejemplo050519.iOS
{
    public class iOSSQLiteConnection : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Examen.db3";
            // Documents folder
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            // Library folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library");

            var path = Path.Combine(libraryPath, sqliteFilename);

            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection
            return conn;
        }
    }
}