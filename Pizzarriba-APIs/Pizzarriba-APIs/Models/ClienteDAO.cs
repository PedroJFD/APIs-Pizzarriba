using Pizzarriba_APIs.Database;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MySql.Data.MySqlClient;

namespace ANP___Atividade___Cliente.Models
{
    public class ClienteDAO
    {
        private static ConnectionMysql conn;

        public ClienteDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Cliente item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "insert into Cliente (id_cli, nome_cli, sexo_cli, cpf_cli, telefone_cli, email_cli, rua_cli, bairro_cli, numero_cli, cidade_cli, complemento_cli) values (@id, @nome, @sexo, @sexo, @cpf, @email, @rua, @bairro, @numero, @cidade, @complemento);";

                query.Parameters.AddWithValue("@id", item.Id);
                query.Parameters.AddWithValue("@nome", item.Nome);
                query.Parameters.AddWithValue("@sexo", item.Sexo);
                query.Parameters.AddWithValue("@cpf", item.Cpf);
                query.Parameters.AddWithValue("@telefone", item.Telefone);
                query.Parameters.AddWithValue("@email", item.Email);
                query.Parameters.AddWithValue("@rua", item.Rua);
                query.Parameters.AddWithValue("@bairro", item.Bairro);
                query.Parameters.AddWithValue("@numero", item.Numero);
                query.Parameters.AddWithValue("@cidade", item.Cidade);
                query.Parameters.AddWithValue("@complemento", item.Complemento);

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

        public List<Cliente> List()
        {
            try
            {
                List<Cliente> list = new List<Cliente>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM cliente";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Cliente()
                    {
                        Id = reader.GetInt32("id_cli"),
                        Nome = reader.GetString("nome_cli"),
                        Sexo = reader.GetString("sexo_cli"),
                        Cpf = reader.GetString("cpf_cli"),
                        Telefone = reader.GetString("telefone_cli"),
                        Email = reader.GetString("email_cli"),
                        Rua = reader.GetString("rua_cli"),
                        Bairro = reader.GetString("bairro_cli"),
                        Numero = reader.GetString("numero_cli"),
                        Cidade = reader.GetString("cidade_cli"),
                        Complemento = reader.GetString("complemento_cli")
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

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente Update(Cliente item)
        {
            throw new NotImplementedException();
        }

        public Cliente Delete(Cliente item)
        {
            throw new NotImplementedException();
        }
    }
}
