using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Business
{
    public static class Validaciones
    {
        public static bool ValidarTextoVacio(object control)
        {
            if(control is TextBox)
            {
                if(string.IsNullOrEmpty(((TextBox)control).Text))
                    return true;
            }
                
            return false;

            
        }
    }
}
