using Pizzarriba_APIs.Database;
using MySql.Data.MySqlClient;

namespace Pizzarriba_APIs.Models
{
    public class ProdutoDAO
    {
        private static ConnectionMysql conn;

        public ProdutoDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Produto item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Produto (id_pro, codigo_pro, nome_pro, preco_pro, descricao_pro) VALUES (@id, @nome, @preco, @descricao);";

                query.Parameters.AddWithValue("@id", item.Id);
                query.Parameters.AddWithValue("@codigo", item.Codigo);
                query.Parameters.AddWithValue("@nome", item.Nome);
                query.Parameters.AddWithValue("@preco", item.Preco);
                query.Parameters.AddWithValue("@descricao", item.Descricao);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente.");
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

        public List<Produto> List()
        {
            try
            {
                List<Produto> list = new List<Produto>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produto()
                    {
                        Id = reader.GetInt32("id_pro"),
                        Codigo = reader.GetInt32("codigo_pro"),
                        Nome = reader.GetString("nome_pro"),
                        Preco = reader.GetDecimal("preco_pro"),
                        Descricao = reader.GetString("descricao_pro")
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

        public Produto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Produto Update(Produto item)
        {
            throw new NotImplementedException();
        }

        public Produto Delete(Produto item)
        {
            throw new NotImplementedException();
        }
    }
}
