using Ejemplo050519.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo050519.Interfaces
{
    public interface ILocalDBService
    {
        //Save
        Task<bool> SaveAsync(IEnumerable<UsuariosLista> saveUsuariolist);

        //Get
        Task<IEnumerable<UsuariosLista>> GetUsuarioList();
    }
}
