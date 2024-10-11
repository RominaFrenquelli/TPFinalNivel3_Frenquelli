using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Business
{
    public static class Seguridad
    {
        public static bool SesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if(usuario != null && usuario.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool EsAdmin(object user)
        {
            Usuario usuario = user !=null ? (Usuario)user : null;
            return usuario != null ? usuario.Admin : false;
        }
    }
}
