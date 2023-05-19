using Models;

namespace DataBase.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ObtenerUsuariosTodos();
        void AgregarUsuario(Usuario usuario);
        Task<Usuario> ObtenerUsuarioPorId(int id);
        Task<Usuario> ActualizarUsuario(Usuario usuario);
        void EjecutarStoredProcedure(Usuario usuario, string parametro);
    }
}
