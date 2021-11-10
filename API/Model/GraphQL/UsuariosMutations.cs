using API.Repository;
using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.GraphQL
{
    //Classe de Mutação do GraphQL
    public class UsuariosMutations : ObjectGraphType
    {

        public UsuariosMutations(IUsuariosRepository repository)
        {
            
                 //Campo de mutação para se criar um Usuario   
                 Name = "Mutation";
                //campo tipo UsuarioType que será retornado na confirmação/sucesso da mutação
                Field<UsuariosType>("createUser",
                    arguments: new QueryArguments(
                    //parametro/argumento do tipo UsuarioInputType
                    new QueryArgument<NonNullGraphType<UsuariosInputType>> { Name = "usuario" }
                    ),
                    resolve: context =>
                    {
                    //ao obter argumento salvar dados na base de dados
                    var usuario = context.GetArgument<Usuarios>("usuario");
                        return repository.InsertUsuario(usuario);
                    });

            //Campo de Mutação para Atualizar um Usuário
            Field<UsuariosType>("updateUsuario",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UsuariosInputType>> { Name = "usuario" },
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "usuarioId" }
                ),
                resolve: context =>
                {
                    var usuario = context.GetArgument<Usuarios>("usuario");
                    var id = context.GetArgument<int>("usuarioId");

                    var dbUsuario = repository.GetUserById(id);
                    if (dbUsuario == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar usuário na base de dados."));
                        return null;
                    }
                    return repository.UpdateUsuario(dbUsuario, usuario);
                });

            //Campo de mutaação para Remover um Usuario
            Field<StringGraphType>("removeUser",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "usuarioId" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("usuarioId");
                    var dbUsuario = repository.GetUserById(id);
                    if (dbUsuario == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar usuário na base de dados."));
                        return null;
                    }
                    repository.RemoveUser(dbUsuario);
                    return $"O usuario com id {id} foi removido";
                });

        }
    }
}