using Pizzarriba_APIs.Database;
using MySql.Data.MySqlClient;
using IngredienteAPI.Models;

namespace Pizzarriba_APIs.Models
{
    public class IngredienteDAO
    {
        private static ConnectionMysql conn;

        public IngredienteDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Ingrediente item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "insert into Ingrediente (id_ing, codigo_ing, nome_ing, medida_ing, quantidade_ing) values (@id, @nome, @medida, @quantidade);";

                query.Parameters.AddWithValue("@id", item.Id);
                query.Parameters.AddWithValue("@codigo", item.Codigo);
                query.Parameters.AddWithValue("@nome", item.Nome);
                query.Parameters.AddWithValue("@medida", item.Medida);
                query.Parameters.AddWithValue("@quantidade", item.Quantidade);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

                return (int)query.LastInsertedId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Ingrediente> List()
        {
            try
            {
                List<Ingrediente> list = new List<Ingrediente>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Ingrediente";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Ingrediente()
                    {
                        Id = reader.GetInt32("id_ing"),
                        Codigo = reader.GetInt32("codigo_ing"),
                        Nome = reader.GetString("nome_ing"),
                        Medida = reader.GetString("medida_ing"),
                        Quantidade = reader.GetDouble("quantidade_ing")
                    });
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public Ingrediente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Ingrediente Update(Ingrediente item)
        {
            throw new NotImplementedException();
        }

        public Ingrediente Delete(Ingrediente item)
        {
            throw new NotImplementedException();

        }
    }
}