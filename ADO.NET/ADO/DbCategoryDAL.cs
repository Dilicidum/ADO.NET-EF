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
    public class DbCategoryDAL:DAL,IDataGateway<CategoryOfGoods>
    {
        public void Insert(CategoryOfGoods category)
        {
            OpenConnection();
            string StrSqlCommand = "INSERT into Category " + "(Name) values" + "(@Name)";
            using (SqlCommand sqlCommand = new SqlCommand(StrSqlCommand, _sqlConnetion))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = category.CategoryName
                };
                sqlCommand.Parameters.Add(parameter);
                sqlCommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void Update(CategoryOfGoods category)
        {
            OpenConnection();

            string StrSqlCommand = @"UPDate Goods
                SEt Name = @Name
                where id = @id";

            using (SqlCommand sqlCommand = new SqlCommand(StrSqlCommand, _sqlConnetion))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = category.CategoryName
                };
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public void Delete(CategoryOfGoods category)
        {
            OpenConnection();

            string StrSqlCommand = "Delete from Category where Category.Id = @id";
                                          
            using (SqlCommand sqlCommand = new SqlCommand(StrSqlCommand, _sqlConnetion))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = category.CategoryName
                };
                sqlCommand.Parameters.Add(parameter);
                sqlCommand.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public IEnumerable<CategoryOfGoods> GetAll()
        {
            OpenConnection();
            List<CategoryOfGoods> categories = new List<CategoryOfGoods>();
            string StrSql = "SELECT * FROM Category";

            using (SqlCommand sqlCommand = new SqlCommand(StrSql, _sqlConnetion))
            {
                sqlCommand.CommandType = CommandType.Text;

                SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    categories.Add(new CategoryOfGoods
                    {
                        CategoryId = (int)dataReader["Id"],
                        CategoryName = (string)dataReader["Name"],
                        
                    });
                }
                dataReader.Close();
            }
            return categories;
        }

        public CategoryOfGoods GetById(int id)
        {
            OpenConnection();
            CategoryOfGoods category = null;
            string SqlStrCommand = "Categories_FindById";
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
                    category = new CategoryOfGoods
                    {
                        CategoryId = (int)reader["id"],
                        CategoryName = (string)reader["Name"],
                    };
                }
            }
            return category;
        }
    }
}
