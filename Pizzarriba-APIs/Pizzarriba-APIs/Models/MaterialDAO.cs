using Pizzarriba_APIs.Database;
using MySql.Data.MySqlClient;
namespace MaterialApi.Models

{
    public class MaterialDAO
    {
        private static ConnectionMysql conn;

        public MaterialDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Material item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "insert into Material (id_mat, codigo_mat, nome_mat, medida_mat, quantidade_mat) values (@id, @nome, @medida, @quantidade);";

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

        public List<Material> List()
        {
            try
            {
                List<Material> list = new List<Material>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM material";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Material()
                    {
                        Id = reader.GetInt32("id_mat"),
                        Codigo = reader.GetInt32("codigo_mat"),
                        Nome = reader.GetString("nome_mat"),
                        Medida = reader.GetString("medida_mat"),
                        Quantidade = reader.GetDouble("quantidade_mat")
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

        public Material GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Material Update(Material item)
        {
            throw new NotImplementedException();
        }

        public Material Delete(Material item)
        {
            throw new NotImplementedException();

        }
    }
}
