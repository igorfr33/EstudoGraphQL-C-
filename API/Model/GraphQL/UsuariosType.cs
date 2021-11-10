using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.GraphQL
{
    //Classe responsável por capturar os valores e mandar para a Query
    public class UsuariosType : ObjectGraphType<Usuarios>
    {
        public UsuariosType()
        {
            Name = "Usuario";

            Field(x => x.Id).Description("Id");
            Field(x => x.Nome).Description("Nome do Usuario");
            Field(x => x.Idade).Description("Idade do Usuario");
            Field(x => x.Email).Description("Email do Usuario");
        }
    }

}
