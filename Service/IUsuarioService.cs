using Microsoft.AspNetCore.Mvc.Rendering;
using Models;


namespace Service
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ObtenerUsuarioTodos();
        void AgregarUsuario(Usuario usuario);
        List<SelectListItem> Generos();
        Task<Usuario> ObtenerUsuariosPorId(int id);
        Task<Usuario> ActualizarUsuario(Usuario usuario);
        void AgregarUsuarioSP(Usuario usuario);
        void EliminarUsuarioSP(int id);
        void ActualizarUsuarioSP(Usuario usuario);
    }
}
