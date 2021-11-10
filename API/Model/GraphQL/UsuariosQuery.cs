using API.Repository;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.GraphQL
{
    //Classe de Query do GraphQL, responsável pela consuta dos dados.
    public class UsuariosQuery : ObjectGraphType<Usuarios>
    {
       public UsuariosQuery(IUsuariosRepository usuariosRepository)
        {
            Field<ListGraphType<UsuariosType>>("Usuarios", resolve: context => usuariosRepository.GetUsuarios());
        }
    }
}
