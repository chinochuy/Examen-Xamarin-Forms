using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ejemplo050519.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidSQLiteConnection))]
namespace Ejemplo050519.Droid
{
    public class DroidSQLiteConnection : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Examen.db3";
            // Documents folder
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            // Path database
            var path = Path.Combine(documentsPath, sqliteFilename);

            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection
            return conn;
        }
    }
}