using Pizzarriba_APIs.Database;
using MySql.Data.MySqlClient;
using FuncionarioAPI.Models;

namespace ANP___Atividade___Funcionario.Models
{
    public class FuncionarioDAO
    {
        private static ConnectionMysql conn;

        public FuncionarioDAO()
        {
            conn = new ConnectionMysql();
        }

        public int Insert(Funcionario item)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "insert into Funcionario (nome_fun, id_fun, codigo_fun, email_fun, telefone_fun, cpf_fun, rg_fun, pisniT_fun, " +
                    "orgao_emissor_rg_fun,cargo_fun, endereço_fun, rua_fun, " +
                    "numero_fun cidade_fun, bairro_fun, complemento_fun values (@nome, @id, @codigo, @email, @telefone, " +
                    "@cpf, @rg,@pis_nit @orgao_emissor_rg, @cargo, @endereco, @rua,  @numero, @cidade, @bairro, @complemento);";

                query.Parameters.AddWithValue("@nome", item.Nome);
                query.Parameters.AddWithValue("@id", item.ID);
                query.Parameters.AddWithValue("@codigo", item.Codigo);
                query.Parameters.AddWithValue("@email", item.Email);
                query.Parameters.AddWithValue("@telefone", item.Telefone);
                query.Parameters.AddWithValue("@email", item.CPF);
                query.Parameters.AddWithValue("@cnpj", item.RG);
                query.Parameters.AddWithValue("@cnpj", item.PISNIT);
                query.Parameters.AddWithValue("@cnpj", item.OrgaoEmissorRG);
                query.Parameters.AddWithValue("@cnpj", item.Cargo);
                query.Parameters.AddWithValue("@endereco", item.Endereco);
                query.Parameters.AddWithValue("@bairro", item.Rua);
                query.Parameters.AddWithValue("@cep", item.Numero);
                query.Parameters.AddWithValue("@bairro", item.Cidade);
                query.Parameters.AddWithValue("@bairro", item.Bairro);
                query.Parameters.AddWithValue("@rua", item.Complemento);
                //das
                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro de Funcionario não foi inserido. Verifique e tente novamente");
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

        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM funcionario";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario()
                    {
                        Nome = reader.GetString("nome_fun"),
                        ID = reader.GetInt32("id_fun"),
                        Codigo = reader.GetInt32("codigo_fun"),
                        Email = reader.GetString("email_fun"),
                        Telefone = reader.GetString("telefone_fun"),
                        CPF = reader.GetString("cpf_fun"),
                        RG = reader.GetString("rg_fun"),
                        PISNIT= reader.GetString("pis_nit_fun"),
                        OrgaoEmissorRG = reader.GetString("orgao_emissor_rg_fun"),
                        Cargo = reader.GetString("cargo_fun"),
                        Endereco = reader.GetString("endereco_fun"),
                        Rua = reader.GetString("rua_fun"),
                        Numero = reader.GetString("numero_fun"),
                        Cidade = reader.GetString("cidade_fun"),
                        Bairro = reader.GetString("bairro_fun"),
                        Complemento = reader.GetString("complemento_fun"),

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

        public Funcionario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Funcionario Update(Funcionario item)
        {
            throw new NotImplementedException();
        }

        public Funcionario Delete(Funcionario item)
        {
            throw new NotImplementedException();

        }
    }

}

