using Jonatha_ASP_Postagem_Domain;

namespace Jonatha_ASP_Postagem_Repositories.Interface
{
    public interface IPostagem
    {
        Task Registro(Postagem model_postagem);
        Task Alterar(Postagem model_postagem);
        Task<IEnumerable<Postagem>> Coletar_Dados_Postagem();
        Task<Postagem> Coletar_Dados_Postagem_ID(int Id);
        void Deletar(int Id);
    }
}
 