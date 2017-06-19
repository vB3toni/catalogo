using System;
using System.Linq;
using Acr.UserDialogs;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using SimpleInjector;

namespace MeusPedidos.Catalogo.Core.Application.ViewModels
{
    public class ServicoAtualizacaoViewModel : MvxViewModel
    {
        #region Variaveis

        private readonly IProdutoApplication _produtoApplication;
        private readonly ICategoriaApplication _categoriaApplication;
        private readonly IPromocaoApplication _promocaoApplication;
        private readonly IPoliticaApplication _politicaApplication;

        #endregion

        public ServicoAtualizacaoViewModel()
        {
            _produtoApplication = Mvx.Resolve<Container>().GetInstance<IProdutoApplication>();
            _categoriaApplication = Mvx.Resolve<Container>().GetInstance<ICategoriaApplication>();
            _promocaoApplication = Mvx.Resolve<Container>().GetInstance<IPromocaoApplication>();
            _politicaApplication = Mvx.Resolve<Container>().GetInstance<IPoliticaApplication>();
        }

        public Action<NotificacaoDto> Notificacao;

        public void IniciarDownloadDados()
        {
            Mvx.Resolve<IUserDialogs>().Toast("Iniciando atualizacao dos dados, aguarde...");

            RealizarDownloadProdutoInserirBancoDados();

            RealizarDownloadCategoriaInserirBancoDados();

            RealizarDownloadPromocaoInserirBancoDados();
        }

        private async void RealizarDownloadProdutoInserirBancoDados()
        {
            var produtos = _produtoApplication.FindList();

            if (produtos.Count <= 0)
            {
                var listaproduto = await _produtoApplication.BuscaProdutosServidor("http://pastebin.com/raw/W7tdL7NU");

                var inserido = 0;

                foreach (var produto in listaproduto)
                {
                    var result = _produtoApplication.Insert(produto);

                    if (result.IsValid)
                    {
                        inserido += 1;
                    }
                }

                NotificarFinalizadoDownload(inserido, "Produto");
            }            
        }

        private async void RealizarDownloadCategoriaInserirBancoDados()
        {
            var categorias = _categoriaApplication.FindList();

            if (categorias.Count <= 0)
            {
                var listacategoria = await _categoriaApplication.BuscarCategoriaServidor("http://pastebin.com/raw/YNR2rsWe");

                var inserido = 0;

                foreach (var categoria in listacategoria)
                {
                    var result = _categoriaApplication.Insert(categoria);

                    if (result.IsValid)
                    {
                        inserido += 1;
                    }
                }

                NotificarFinalizadoDownload(inserido, "Categorias");
            }            
        }
        
        private async void RealizarDownloadPromocaoInserirBancoDados()
        {
            var promocoes = _promocaoApplication.FindList();

            if (promocoes.Count <= 0)
            {
                var listapromocao = await _promocaoApplication.BuscarPromocaoServidor("https://pastebin.com/raw/R9cJFBtG");

                var inseridosopolitica = 0;
                var inseridospromocao = 0;

                foreach (var promocao in listapromocao)
                {
                    inseridosopolitica += promocao.Politica.Select(politica => _politicaApplication.Insert(politica)).Where(resultpolitica => resultpolitica.IsValid).Sum(resultpolitica => promocao.Politica.Count);

                    var resultpromocao = _promocaoApplication.Insert(promocao);
                    if (resultpromocao.IsValid)
                    {
                        inseridospromocao += 1;
                    }
                }

                NotificarFinalizadoDownload(inseridospromocao, "Promoção");
                NotificarFinalizadoDownload(inseridosopolitica, "Politica Desconto");
            }            
        }

        private void NotificarFinalizadoDownload(int inserido, string descricao)
        {
            Mvx.Resolve<IUserDialogs>().Toast($"Finalizado download de {inserido} {descricao}");

            if (inserido > 0)
            {
                Notificacao.Invoke(new NotificacaoDto
                {
                    Descricao = $"Finalizado download de {inserido} {descricao}",
                    NotificarComLuz = true,
                    NotificarComSom = true,
                    NotificarComVibracao = true,
                    Titulo = "Atualização Dados"
                });
            }
        }
    }
}