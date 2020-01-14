using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace REQUERIMIENTO_UNO
{
    class ClassConexion
    {
        private static string scn = "Data Source=localhost; Database=cacao_prueba;User ID=root; Password=45218450;";
        public static MySqlConnection cn = new MySqlConnection(scn);
    }
}
