using Ejemplo050519;
using Ejemplo050519.Interfaces;
using Ejemplo050519.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteLocalDBService))]
namespace Ejemplo050519
{
    public class SQLiteLocalDBService : ILocalDBService
    {
        private readonly SQLiteConnection connection = null;

        public SQLiteLocalDBService(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        public SQLiteLocalDBService()
        {
            connection = DependencyService.Get<ISQLite>().GetConnection();
            CreateTables();
        }

        private void CreateTableIfDontExist<T>(string tableName)
        {
            if (!connection.GetTableInfo(tableName).Any())
            {
                connection.DropTable<T>();
                connection.CreateTable<T>();
            }
        }

        private void CreateTables()
        {
            CreateTableIfDontExist<UsuariosLista>(nameof(UsuariosLista));
        }

        public Task<IEnumerable<UsuariosLista>> GetUsuarioList()
        {
            return Task.Run(() => (IEnumerable<UsuariosLista>)connection.Table<UsuariosLista>());
        }

        public Task<bool> SaveAsync(IEnumerable<UsuariosLista> saveUsuariolist)
        {
            connection.DeleteAll<UsuariosLista>();
            return Task.Run(() => connection.InsertAll(saveUsuariolist) > 0);
        }
    }
}
