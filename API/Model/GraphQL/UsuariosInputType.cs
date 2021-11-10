using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.GraphQL
{
    //Classe chamada na Mutations para pegar os dados que são inseridos/atualizados ou deletados
    public class UsuariosInputType : InputObjectGraphType<Usuarios>
    {
        public UsuariosInputType()
        {
            Name = "UsuarioInput";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id usuário");
            Field(x => x.Idade).Description("Idade do usuário");
            Field(x => x.Nome).Description("Nome do usuário");
            Field(x => x.Email).Description("Email do usuario");
        }
    }
}