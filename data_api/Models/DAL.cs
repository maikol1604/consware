using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace data_api.Models
{
    public class DAL
    {
        private prueba_maikolEntities conection = new prueba_maikolEntities();
        private aut_user UserObj;
        private Cliente ClienteObj;
        private Producto ProductoObj;
        private List<aut_user> lstuser;

        public aut_user GetUser(string user, string pswd)
        {
            UserObj = new aut_user();
            lstuser = new List<aut_user>();

            lstuser = conection.aut_user.ToList().
                    Where(w => w.user_aut == user && w.password_aut == pswd && w.estado_aut=="ACT").ToList();
            if (lstuser.Count > 0)
            {
                UserObj = lstuser.FirstOrDefault();
                return UserObj;
            }
            else
            {
                return new aut_user();
            }
        }

        public string GuardarCliente(Cliente cliente) {

            conection.Cliente.Add(cliente);
            var res=conection.SaveChanges();
            return res+"";
        }

        public List<Cliente> allCliente() {

            return conection.Cliente.ToList();
        }
    }
}