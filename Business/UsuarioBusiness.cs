using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Business
{
    public class UsuarioBusiness
    {
        public int CrearUsuario(Usuario nuevo)
        {
            ConectarDB datos = new ConectarDB();
            try
            {
                datos.SetearConsulta("insert into USERS (email, pass, admin) output inserted.id values (@email, @pass, 0)");
                datos.SetearParametro("@email", nuevo.Email);
                datos.SetearParametro("@pass", nuevo.Pass);
                return datos.EjecutarScalar();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public bool ExisteEmail(string email)
        {
            ConectarDB datos = new ConectarDB();
            try
            {
                datos.SetearConsulta("select id from USERS where email = @email");
                datos.SetearParametro("@email", email);
                datos.EjecutarLectura();
                
                    
                return datos.Lector.Read();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public bool Login(Usuario user)
        {
            ConectarDB datos = new ConectarDB();
            try
            {
                datos.SetearConsulta("select id, email, pass, admin, urlImagenPerfil, nombre, apellido from USERS where email = @email and pass = @pass");
                datos.SetearParametro("@email", user.Email);
                datos.SetearParametro("@pass", user.Pass);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["id"];
                    user.Admin = (bool)datos.Lector["admin"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Actualizar(Usuario user)
        {
            ConectarDB datos = new ConectarDB();
            try
            {
                datos.SetearConsulta("update USERS set urlImagenPerfil = @imagen, nombre = @nombre, apellido = @apellido where Id = @id");
                datos.SetearParametro("@imagen", (object)user.UrlImagenPerfil ?? DBNull.Value);
                datos.SetearParametro("@nombre", user.Nombre);
                datos.SetearParametro("@apellido", user.Apellido);
                datos.SetearParametro("@id", user.Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
