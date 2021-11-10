using API.Data;
using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    //Implementação da Interface e programado os metodos das Mutations
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AppDbContext _context;
        public UsuariosRepository(AppDbContext context)
        {
            _context = context;
        }

        public Usuarios GetUserById(int id)
        {
            return _context.Usuarios.FirstOrDefault(f => f.Id == id);
        }

        public Task<List<Usuarios>> GetUsuarios()
        {
            return _context.Usuarios.ToListAsync();
        }

        public Usuarios InsertUsuario(Usuarios usuarios)
        {
            _context.Add(usuarios);
            _context.SaveChanges();
            return usuarios;
        }

        public void RemoveUser(Usuarios usuarios)
        {
            _context.Remove(usuarios);
            _context.SaveChanges();
        }

        public Usuarios UpdateUsuario(Usuarios dbUsuario, Usuarios usuario)
        {
            dbUsuario.Nome = usuario.Nome;
            dbUsuario.Idade = usuario.Idade;
            dbUsuario.Email = usuario.Email;

            _context.SaveChanges();

            return dbUsuario;
        }
    }
}