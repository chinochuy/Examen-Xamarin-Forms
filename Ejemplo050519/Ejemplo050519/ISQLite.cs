using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejemplo050519
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
