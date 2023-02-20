using Jonatha_ASP_Postagem_Domain;
using Jonatha_ASP_Postagem_Repositories.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Jonatha_ASP_Postagem_Repositories.Repositorie
{
    public class PostagemRepository : IPostagem
    {
        private SqlConnection PROJETOS01 = new SqlConnection("data source=seu_servidor;initial catalog=PROJETOS;user id=seu_usuario;password=sua_senha;Connect Timeout=5;Max Pool Size=400");
        private SqlCommand? selecionar, inserir, deleta, atualizar;
        private SqlDataReader? leitura;

        public async Task Registro(Postagem model_postagem)
        {
            try
            {
                using (PROJETOS01)
                {
                    if (PROJETOS01.State == ConnectionState.Closed)
                    {
                        PROJETOS01.Open();
                    }

                    using (inserir = new SqlCommand("INSERT INTO POSTAGEM " +
                    "(DATA_REGISTRO, USUARIO, TITULO, ARQUIVO, CURTIDA, DESCRICAO, TIPO) " +
                    "VALUES (FORMAT (GETDATE(), 'dd-MM-yy'), @USUARIO, @TITULO, @ARQUIVO, @CURTIDA, @DESCRICAO, @TIPO)", PROJETOS01))
                    {
                        inserir.Parameters.AddWithValue("@USUARIO", model_postagem.USUARIO);
                        inserir.Parameters.AddWithValue("@TITULO", model_postagem.TITULO);
                        inserir.Parameters.AddWithValue("@ARQUIVO", model_postagem.ARQUIVO);
                        inserir.Parameters.AddWithValue("@CURTIDA", model_postagem.CURTIDA);
                        inserir.Parameters.AddWithValue("@DESCRICAO", model_postagem.DESCRICAO);
                        inserir.Parameters.AddWithValue("@TIPO", model_postagem.TIPO);
                        await inserir.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Alterar(Postagem model_postagem)
        {
            try
            {
                using (PROJETOS01)
                {
                    if (PROJETOS01.State == ConnectionState.Closed)
                    {
                        PROJETOS01.Open();
                    }

                    using (atualizar = new SqlCommand("UPDATE POSTAGEM SET TITULO = @TITULO, " +
                    "DESCRICAO = @DESCRICAO, TIPO = @TIPO WHERE ID = @ID", PROJETOS01))
                    {
                        atualizar.Parameters.AddWithValue("@TITULO", model_postagem.TITULO);
                        atualizar.Parameters.AddWithValue("@DESCRICAO", model_postagem.DESCRICAO);
                        atualizar.Parameters.AddWithValue("@TIPO", model_postagem.TIPO);
                        atualizar.Parameters.AddWithValue("@ID", model_postagem.ID);
                        await atualizar.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int Id)
        {
            using (PROJETOS01)
            {
                if (PROJETOS01.State == ConnectionState.Closed)
                {
                    PROJETOS01.Open();
                }

                using (deleta = new SqlCommand("DELETE FROM POSTAGEM WHERE ID = @ID", PROJETOS01))
                {
                    deleta.Parameters.AddWithValue("@ID", Id);
                    deleta.ExecuteNonQueryAsync();
                }
            }

        }

        public async Task<IEnumerable<Postagem>> Coletar_Dados_Postagem()
        {
            try
            {
                using (PROJETOS01)
                {
                    if (PROJETOS01.State == ConnectionState.Closed)
                    {
                        PROJETOS01.Open();
                    }

                    List<Postagem> lista_postagem = new List<Postagem>();
                    using (selecionar = new SqlCommand("SELECT ID, DATA_REGISTRO, USUARIO, TITULO, ARQUIVO, " +
                    "CURTIDA, DESCRICAO, TIPO FROM POSTAGEM", PROJETOS01))
                    {
                        using (leitura = await selecionar.ExecuteReaderAsync())
                        {
                            Postagem modelo_postagem = null;
                            while (await leitura.ReadAsync())
                            {
                                modelo_postagem = new Postagem();
                                modelo_postagem.ID = Convert.ToInt32(leitura[0]);
                                modelo_postagem.DATA_REGISTRO = Convert.ToDateTime(leitura[1]);
                                modelo_postagem.USUARIO = Convert.ToString(leitura[2]);
                                modelo_postagem.TITULO = Convert.ToString(leitura[3]);
                                if (Convert.ToString(leitura[7]) == "YOUTUBE")
                                {
                                    modelo_postagem.ARQUIVO = "https://www.youtube.com/embed/" + Convert.ToString(leitura[4]).Substring(Convert.ToString(leitura[4]).IndexOf("?v=") + 3, (Convert.ToString(leitura[4]).Length - Convert.ToString(leitura[4]).IndexOf("?v=")) - 3);
                                }
                                else
                                {
                                    modelo_postagem.ARQUIVO = Convert.ToString(leitura[4]);
                                }
                                modelo_postagem.CURTIDA = Convert.ToInt32(leitura[5]);
                                modelo_postagem.DESCRICAO = Convert.ToString(leitura[6]);
                                modelo_postagem.TIPO = Convert.ToString(leitura[7]);
                                lista_postagem.Add(modelo_postagem);
                            }
                            return lista_postagem;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Postagem> Coletar_Dados_Postagem_ID(int ID)
        {
            try
            {
                using (PROJETOS01)
                {
                    if (PROJETOS01.State == ConnectionState.Closed)
                    {
                        PROJETOS01.Open();
                    }

                    using (selecionar = new SqlCommand("SELECT ID, DATA_REGISTRO, USUARIO, TITULO, ARQUIVO, " +
                    "CURTIDA, DESCRICAO, TIPO FROM POSTAGEM WHERE ID = @ID", PROJETOS01))
                    {
                        selecionar.Parameters.AddWithValue("@ID", ID);

                        using (leitura = await selecionar.ExecuteReaderAsync())
                        {
                            Postagem modelo_postagem = null;
                            while (await leitura.ReadAsync())
                            {
                                modelo_postagem = new Postagem();
                                modelo_postagem.ID = Convert.ToInt32(leitura[0]);
                                modelo_postagem.DATA_REGISTRO = Convert.ToDateTime(leitura[1]);
                                modelo_postagem.USUARIO = Convert.ToString(leitura[2]);
                                modelo_postagem.TITULO = Convert.ToString(leitura[3]);
                                if (Convert.ToString(leitura[7]) == "YOUTUBE")
                                {
                                    modelo_postagem.ARQUIVO = "https://www.youtube.com/embed/" + Convert.ToString(leitura[4]).Substring(Convert.ToString(leitura[4]).IndexOf("?v=") + 3, (Convert.ToString(leitura[4]).Length - Convert.ToString(leitura[4]).IndexOf("?v=")) - 3);
                                }
                                else
                                {
                                    modelo_postagem.ARQUIVO = Convert.ToString(leitura[4]);
                                }
                                modelo_postagem.CURTIDA = Convert.ToInt32(leitura[5]);
                                modelo_postagem.DESCRICAO = Convert.ToString(leitura[6]);
                                modelo_postagem.TIPO = Convert.ToString(leitura[7]);
                            }
                            return modelo_postagem;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
