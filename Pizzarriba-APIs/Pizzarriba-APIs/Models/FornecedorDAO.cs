using Pizzarriba_APIs.Database;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MySql.Data.MySqlClient;
using Fornecedores;

namespace ANP___Atividade___Cliente.Models
{
    public class FornecedorDAO
    {
        private static ConnectionMysql conn;

        public FornecedorDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Fornecedor item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "insert into Fornecedor (id_for, codigo_for, nome_for, telefone_for, email_for, cnpj_for, endereco_for, cep_for, rua_for, bairro_for, numero_for values (@id, @codigo, @nome, @telefone, @email, @cnpj, @endereco, @cep, @rua, @bairro, @numero);";

                query.Parameters.AddWithValue("@id", item.Id);
                query.Parameters.AddWithValue("@codigo", item.Codigo);
                query.Parameters.AddWithValue("@nome", item.Nome);
                query.Parameters.AddWithValue("@telefone", item.Telefone);
                query.Parameters.AddWithValue("@email", item.Email);
                query.Parameters.AddWithValue("@cnpj", item.CNPJ);
                query.Parameters.AddWithValue("@endereco", item.Endereco);
                query.Parameters.AddWithValue("@cep", item.Cep);
                query.Parameters.AddWithValue("@rua", item.Rua);
                query.Parameters.AddWithValue("@bairro", item.Bairro);
                query.Parameters.AddWithValue("@numero", item.Numero);
                //das
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

        public List<Fornecedor> List()
        {
            try
            {
                List<Fornecedor> list = new List<Fornecedor>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Fornecedor()
                    {
                        Id = reader.GetInt32("id_for"),
                        Codigo = reader.GetInt32("codigo_for"),
                        Nome = reader.GetString("nome_for"),
                        Telefone = reader.GetString("telefone_for"),
                        Email = reader.GetString("email_for"),
                        CNPJ = reader.GetString("cnpj_for"),
                        Endereco = reader.GetString("endereco_for"),
                        Cep = reader.GetString("cep_for"),
                        Rua = reader.GetString("rua_for"),
                        Bairro = reader.GetString("bairro_for"),
                        Numero = reader.GetString("numero_for"),

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

        public Fornecedor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Fornecedor Update(Fornecedor item)
        {
            throw new NotImplementedException();
        }

        public Fornecedor Delete(Fornecedor item)
        {
            throw new NotImplementedException();

        }
    }
}
