using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.ADO
{
    public abstract class DAL
    {
        protected readonly string _connectionString;
        protected SqlConnection _sqlConnetion = null;

        public DAL() : this(@"Data Source = DESKTOP-9V2E2NB\SQLEXPRESS;
            Integrated Security=true;Initial Catalog=EPAM_5") { Console.WriteLine("Created"); }

        public DAL(string connectionString) => _connectionString = connectionString;

        public virtual void OpenConnection()
        {
            _sqlConnetion = new SqlConnection(_connectionString);
            _sqlConnetion.Open();
        }

        public virtual void CloseConnection()
        {
            if (_sqlConnetion?.State != ConnectionState.Closed)
            {
                _sqlConnetion.Close();
            }
        }


    }
}
