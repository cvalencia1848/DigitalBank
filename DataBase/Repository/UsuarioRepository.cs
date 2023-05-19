using DataBase.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataBase.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GrupoDigitalBankContext grupoDigitalBankContext;

        public UsuarioRepository(GrupoDigitalBankContext grupoDigitalBankContext)
        {
            this.grupoDigitalBankContext = grupoDigitalBankContext;
        }

        public async Task<List<Usuario>> ObtenerUsuariosTodos()
        {
            return await grupoDigitalBankContext.Usuarios.ToListAsync();
        }

        public void AgregarUsuario(Usuario usuario)
        {
            grupoDigitalBankContext.Usuarios.Add(usuario);
            grupoDigitalBankContext.SaveChangesAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            var usuario = await grupoDigitalBankContext.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> ActualizarUsuario(Usuario usuario)
        {
            grupoDigitalBankContext.Entry(usuario).State = EntityState.Modified;
            await grupoDigitalBankContext.SaveChangesAsync();
            return usuario;
        }

        public void EjecutarStoredProcedure(Usuario usuario, string parametro)
        {
            using (SqlConnection conexion = new SqlConnection("Server=.\\SQLExpress;Database=GrupoDigitalBank;Trusted_Connection=True; Encrypt=False;"))
            {
                conexion.Open();
                string querry = "UsuarioCRUD";
                using (SqlCommand comando = new SqlCommand(querry, conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@Parametro", parametro));
                    comando.Parameters.Add(new SqlParameter("@Id", usuario.Id is null ? "" : usuario.Id));
                    comando.Parameters.Add(new SqlParameter("@Nombre", usuario.Nombre is null ? "" : usuario.Nombre));
                    comando.Parameters.Add(new SqlParameter("@FechaNacimiento", usuario.FechaNacimiento is null ? "" : usuario.FechaNacimiento));
                    comando.Parameters.Add(new SqlParameter("@Sexo", usuario.Sexo is null ? "" : usuario.Sexo));

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
