using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ADO.NET.Models;

namespace ADO.NET.ADO
{
    public class SupplierDAL:DAL,IDataGateway<Supplier>
    {
        public void Insert(Supplier supplier)
        {
            OpenConnection();
            string StrSqlCommand = "Supplier_Insert";
            using (SqlCommand sqlCommand = new SqlCommand(StrSqlCommand, _sqlConnetion))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = supplier.NameOfCompany
                };
                sqlCommand.Parameters.Add(parameter);
                sqlCommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void Update(Supplier supplier)
        {
            OpenConnection();

            string StrSqlCommand = "Supplier_Update";

            using (SqlCommand sqlCommand = new SqlCommand(StrSqlCommand, _sqlConnetion))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = supplier.NameOfCompany
                };
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public void Delete(Supplier supplier)
        {
            OpenConnection();

            string StrSqlCommand = "Supplier_Delete";

            using (SqlCommand sqlCommand = new SqlCommand(StrSqlCommand, _sqlConnetion))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = supplier.NameOfCompany
                };
                sqlCommand.Parameters.Add(parameter);
                sqlCommand.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public IEnumerable<Supplier> GetAll()
        {
            OpenConnection();
            List<Supplier> suppliers = new List<Supplier>();
            string StrSql = "Supplier_GetALL";

            using (SqlCommand sqlCommand = new SqlCommand(StrSql, _sqlConnetion))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    suppliers.Add(new Supplier
                    {
                        Id = (int)dataReader["Id"],
                        NameOfCompany = (string)dataReader["Name"],
                        CountryOfCompany = (string)dataReader["Country"],
                    });
                }
                dataReader.Close();
            }
            return suppliers;
        }

        public Supplier GetById(int id)
        {
            OpenConnection();
            Supplier supplier = null;
            string SqlStrCommand = "Supplier_FindById";
            using (SqlCommand command = new SqlCommand(SqlStrCommand, _sqlConnetion))
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parametr = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(parametr);

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    supplier = new Supplier
                    {
                        Id = (int)reader["id"],
                        NameOfCompany = (string)reader["Name"],
                        CountryOfCompany =(string)reader["Country"],
                    };
                }
            }
            return supplier;
        }

    }
}
