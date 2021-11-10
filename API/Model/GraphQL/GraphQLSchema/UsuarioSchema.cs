using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.GraphQL.GraphQLSchema
{
    //Classe Schema do GraphQL ela é responsável por chamar as Query e a Classe de Mutations
    public class UsuarioSchema : Schema
    {
        public UsuarioSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<UsuariosQuery>();
            Mutation = resolver.Resolve<UsuariosMutations>();
        }
    }
}