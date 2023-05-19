using DataBase.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> ObtenerUsuarioTodos()
        {
            return await usuarioRepository.ObtenerUsuariosTodos();
        }

        public void AgregarUsuario(Usuario usuario)
        {
            this.usuarioRepository.AgregarUsuario(usuario);
        }

        public async Task<Usuario> ObtenerUsuariosPorId(int id)
        {
            return await usuarioRepository.ObtenerUsuarioPorId(id);
        }

        public List<SelectListItem> Generos()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "M", Text = "MASCULINO" },
                new SelectListItem { Value = "F", Text = "FEMENINO" },
            };
        }

        public async Task<Usuario> ActualizarUsuario(Usuario usuario)
        {
            return await usuarioRepository.ActualizarUsuario(usuario);
        }

        public void AgregarUsuarioSP(Usuario usuario)
        {
            const string Parametro = "INSERT";
            usuarioRepository.EjecutarStoredProcedure(usuario, Parametro);
        }

        public void EliminarUsuarioSP(int id)
        {
            const string Parametro = "DELETE";
            var usuario = new Usuario { Id = id };
            usuarioRepository.EjecutarStoredProcedure(usuario, Parametro);
        }

        public void ActualizarUsuarioSP(Usuario usuario)
        {
            const string Parametro = "UPDATE";
            usuarioRepository.EjecutarStoredProcedure(usuario, Parametro);
        }

    }
}
