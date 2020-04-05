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
    public class GoodsDAL:DAL,IDataGateway<Good>
    {
        public IEnumerable<Good> GetAll()
        {
            OpenConnection();
            List<Good> goods = new List<Good>();
            string StrSql = "Goods_GetAll";

            using (SqlCommand sqlCommand = new SqlCommand(StrSql, _sqlConnetion))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                
                SqlDataReader dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    goods.Add(new Good
                    {
                        Id = (int)dataReader["Id"],
                        Name=(string)dataReader["Name"],
                        Amount=(int)dataReader["Amount"],
                        PriceRetail=(decimal)dataReader["PriceForRetail"],
                        PriceWholeSale=(decimal)dataReader["PriceForWholeSale"],
                        CategoryId=(int)dataReader["CategoryId"],
                        SupplierId=(int)dataReader["SupplierId"],
                    });
                }
                dataReader.Close();
            }
            return goods;
        }

        public void Insert(Good good)
        {
            OpenConnection();
            string StrSqlCommand = "INSERT into Goods "+ "(Name,Amount,PriceForRetail,PriceForWholeSale,SupplierId,CategoryId) values" + "(@Name,@Amount,@PriceForRetail,@PriceForWholeSale,@SupplierId,@CategoryId)";
            using (SqlCommand sqlCommand = new SqlCommand(StrSqlCommand,_sqlConnetion))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value=good.Name
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName="@Amount",
                    Value=good.Amount
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName="@PriceForRetail",
                    Value=good.PriceRetail
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName="@PriceForWholeSale",
                    Value=good.PriceWholeSale
                };

                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter()
                {
                    ParameterName="@SupplierId",
                    Value=good.SupplierId
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName="@CategoryId",
                    Value = good.CategoryId
                };
                sqlCommand.Parameters.Add(parameter);

                sqlCommand.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void Update(Good good)
        {
            OpenConnection();

            string StrSqlCommand = @"UPDate Goods
                SEt Name = @Name, Amount = @Amount, PriceForRetail = @PriceForRetail, PriceForWholeSale = @PriceForWholeSale, CategoryId = @CategoryId,
                SupplierId = @SupplierId
                where id = @id";

            using (SqlCommand sqlCommand = new SqlCommand(StrSqlCommand, _sqlConnetion))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = good.Name
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Amount",
                    Value = good.Amount
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@PriceForRetail",
                    Value = good.PriceRetail
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@PriceForWholeSale",
                    Value = good.PriceWholeSale
                };

                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter()
                {
                    ParameterName = "@SupplierId",
                    Value = good.SupplierId
                };

                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@CategoryId",
                    Value = good.CategoryId
                };
                sqlCommand.Parameters.Add(parameter);

                parameter = new SqlParameter()
                {
                    ParameterName = "Id",
                    Value = good.Id
                };
                sqlCommand.Parameters.Add(parameter);
                sqlCommand.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public void Delete(Good good)
        {
            OpenConnection();
            string SqlExpression = "Goods_Delete";
            using (SqlCommand sqlCommand = new SqlCommand(SqlExpression, _sqlConnetion))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void GetGoodsByCategory(string CategoryName)
        {
            OpenConnection();

            string StrSqlCommand = $"SELECT NAME,CategoryName FROM Good WHERE Category = {CategoryName} ";

            using(SqlCommand command = new SqlCommand(StrSqlCommand,_sqlConnetion))
            { 
                SqlDataReader reader = command.ExecuteReader();
            }

        }

        public Good GetById(int id)
        {
            OpenConnection();
            Good good = null;
            string SqlStrCommand = "Goods_FindById";
            using (SqlCommand command = new SqlCommand(SqlStrCommand, _sqlConnetion))
            {
                SqlParameter parametr = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(parametr);

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    good = new Good
                    {
                        Id=(int)reader["id"],
                        Name=(string)reader["Name"],
                        Amount=(int)reader["Amount"],
                        PriceRetail=(decimal)reader["PriceForRetail"],
                        PriceWholeSale=(decimal)reader["PriceForWholeSale"],
                        CategoryId = (int)reader["CategoryId"],
                        SupplierId=(int)reader["SupplierId"],
                    };
                }
            }
            return good;
            
            
        }

       
    }
}
