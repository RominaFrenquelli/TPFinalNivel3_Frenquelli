using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Business
{
    public class FavoritoBusiness
    {
        public void AgregarFav(int userId, int artId)
        {
            ConectarDB datos = new ConectarDB();
            try
            {
                datos.SetearConsulta("insert into FAVORITOS (IdUser, IdArticulo) values (@UserId, @ArticuloId)");
                datos.SetearParametro("@UserId", userId);
                datos.SetearParametro("@ArticuloId", artId);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar el artículo a favoritos.", ex);
            }
            finally 
            { 
                datos.CerrarConexion(); 
            }
        }

        public List<Articulo> ListarFav(int usuarioId)
        {
            List<Articulo> listaFav = new List<Articulo>();
            ConectarDB datos = new ConectarDB();

            try
            {

                datos.SetearConsulta("SELECT A.*, C.Descripcion Categoria, M.Descripcion Marca FROM ARTICULOS A INNER JOIN FAVORITOS F ON A.Id = F.IdArticulo INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id WHERE F.IdUser = @UsuarioId");
                datos.SetearParametro("@UsuarioId", usuarioId);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = (string)datos.Lector["Codigo"];
                    art.Nombre = (string)datos.Lector["Nombre"];
                    art.Descripcion = (string)datos.Lector["Descripcion"];
                    art.Marca = new Marca();
                    art.Marca.Id = (int)datos.Lector["IdMarca"];
                    art.Marca.Descripcion = (string)datos.Lector["Marca"];
                    art.Categoria = new Categoria();
                    art.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    art.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        art.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }
                    art.Precio = (decimal)datos.Lector["Precio"];

                    listaFav.Add(art);
                }
                return listaFav;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar los artículos favoritos.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void QuitarFav(int userId, int artId)
        {
            ConectarDB datos = new ConectarDB();
            try
            {               
                datos.SetearConsulta("delete from FAVORITOS where IdArticulo = @idArticulo and IdUser = @userId");
                datos.SetearParametro("@idArticulo", artId);
                datos.SetearParametro("@userId", userId);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar el artículo favorito.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public bool EsFavorito(string articuloId, int userId)
        {
            ConectarDB datos = new ConectarDB();
            try
            {
                datos.SetearConsulta("select Id from FAVORITOS where IdArticulo = @articuloId and IdUser = @userId");
                datos.SetearParametro("@articuloId", articuloId);
                datos.SetearParametro("@userId", userId);
                datos.EjecutarLectura();
                return datos.Lector.Read();               
                    
            }
            catch (Exception ex)
            {

                throw new Exception("Error al verificar si el artículo es favorito.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}
