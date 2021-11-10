using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    //Interface para os metodos das Mutations
    public interface IUsuariosRepository
    {
        Task<List<Usuarios>> GetUsuarios();
        public Usuarios GetUserById(int id);
        public Usuarios InsertUsuario(Usuarios usuarios);
        public Usuarios UpdateUsuario(Usuarios dbUsuario, Usuarios usuario);
        public void RemoveUser(Usuarios usuarios);


    }
}
