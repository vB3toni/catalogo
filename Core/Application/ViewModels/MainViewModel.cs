using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Acr.UserDialogs;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Application.Mappers.Converter;
using MeusPedidos.Catalogo.Core.Application.Message;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using SimpleInjector;

namespace MeusPedidos.Catalogo.Core.Application.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        #region Variaveis

        private readonly IPoliticaApplication _politicaPromocaoApplication;

        private readonly IProdutoApplication _produtoApplication;
        private readonly ICategoriaApplication _categoriaApplication;
        private readonly ICatalogoPromocaoApplication _catalogoPromocaoApplication;
        private readonly IItensPedidoApplication _itensPedidoApplication;

        private MvxObservableCollection<CategoriaDto> _listacategoria;
        private CategoriaDto _filtroCategoria;

        private List<PoliticaDto> _listaPolitica;
        
        private MvxCommand<CategoriaDto> _selecionarcategoriacommand;
        private MvxCommand<ItensPedidoMessage> _itenspedidocommand;
        private MvxCommand _prosseguircarrinho;

        #endregion

        public MainViewModel()
        {
            _politicaPromocaoApplication = Mvx.Resolve<Container>().GetInstance<IPoliticaApplication>();

            _produtoApplication = Mvx.Resolve<Container>().GetInstance<IProdutoApplication>();

            _categoriaApplication = Mvx.Resolve<Container>().GetInstance<ICategoriaApplication>();

            _catalogoPromocaoApplication = Mvx.Resolve<Container>().GetInstance<ICatalogoPromocaoApplication>();

            _itensPedidoApplication = Mvx.Resolve<Container>().GetInstance<IItensPedidoApplication>();

            Mvx.Resolve<IMvxMessenger>().Subscribe<ItensPedidoMessage>(message => { ItensPedidoCommand.Execute(message); }, MvxReference.Strong);

            CarregarCatalogoPromocao();

            CarregarFiltroCategoria();

            CarregarPoliticaDesconto();
        }

        public void CarregarFiltroCategoria()
        {
            if (_listacategoria != null && _listacategoria.Count > 0)
            {
                _listacategoria = new MvxObservableCollection<CategoriaDto>(_listacategoria);

                RaisePropertyChanged(() => ListaCategoria);

                return;
            }

            var listacategoria = _categoriaApplication.FindList();
            
            _listacategoria = new MvxObservableCollection<CategoriaDto>(listacategoria.ToDtos().OrderBy(x => x.Id).ToList());
            
            RaisePropertyChanged(() => ListaCategoria);
        }

        public void CarregarCatalogoPromocao(bool filtro = false)
        {
            if (ListaPromocao != null && ListaPromocao.Count > 0 && filtro)
            {
                ListaPromocao = new MvxObservableCollection<CatalogoPromocaoDto>(ListaPromocao.ToList());

                RaisePropertyChanged(() => ListaPromocao);

                return;
            }

            var listacatalogopromocao = _catalogoPromocaoApplication.BuscarTodosCatalogoPromocao(FiltroCategoria?.Id);

            ListaPromocao = new MvxObservableCollection<CatalogoPromocaoDto>(listacatalogopromocao.ToDtos());

            RaisePropertyChanged(() => ListaPromocao);

            RaisePropertyChanged(() => ComprarTotalizador);
        }

        public void CarregarPoliticaDesconto()
        {
            if (_listaPolitica == null)
            {
                var taskpolitica = _politicaPromocaoApplication.FindListAsync().ContinueWith(task =>
                {
                    _listaPolitica = task.Result.ToDtos().ToList();
                });

                taskpolitica.ConfigureAwait(false);
            }
        }

        public MvxObservableCollection<CatalogoPromocaoDto> ListaPromocao { get; private set; }

        public MvxObservableCollection<CategoriaDto> ListaCategoria => _listacategoria;

        public CategoriaDto FiltroCategoria
        {
            get => _filtroCategoria;
            set
            {
                _filtroCategoria = value;

                _filtroCategoria.Selecionado = true;

                foreach (var categoriaDto in _listacategoria)
                {
                    if (categoriaDto.Id != _filtroCategoria.Id)
                    {
                        categoriaDto.Selecionado = false;
                    }
                }

                CarregarCatalogoPromocao();

                CarregarFiltroCategoria();

                RaisePropertyChanged(() => FiltroCategoria);
            }
        }

        public string ComprarTotalizador => "COMPRAR >> " + _catalogoPromocaoApplication.SomarTotalVendido(ListaPromocao.ToList().ToEntities()).ToString("C2", new CultureInfo("pt-br"));

        #region Commands

        public MvxCommand<CategoriaDto> SelecionarCategoria => _selecionarcategoriacommand = _selecionarcategoriacommand ?? new MvxCommand<CategoriaDto>(categoria =>
        {
            FiltroCategoria = categoria;
        });


        public MvxCommand<ItensPedidoMessage> ItensPedidoCommand => _itenspedidocommand = _itenspedidocommand ?? new MvxCommand<ItensPedidoMessage>(itenspedido =>
        {
            if (itenspedido.Acao.Equals("Favorito"))
            {
                itenspedido.ItensPedidoDto.Favorito = !itenspedido.ItensPedidoDto.Favorito;

                itenspedido.ItensPedidoDto.Produto.Favorito = !itenspedido.ItensPedidoDto.Favorito;
                
                _produtoApplication.Update(itenspedido.ItensPedidoDto.Produto.ToEntity());

                CarregarCatalogoPromocao(true);

                return;
            }
            
            if (itenspedido.Acao.Equals("Adicionar"))
            {
                itenspedido.ItensPedidoDto.QtdeVenda += 1;
                itenspedido.ItensPedidoDto.Desconto = 0;
            }

            if (itenspedido.Acao.Equals("Retirar"))
            {
                if (itenspedido.ItensPedidoDto.QtdeVenda > 0)
                {
                    itenspedido.ItensPedidoDto.QtdeVenda -= 1;
                    itenspedido.ItensPedidoDto.Desconto = 0;
                }
            }

            var descontopromocao = _politicaPromocaoApplication.BuscarValorDescontoPoliticaPromocao(_listaPolitica.ToEntities().ToList(), ListaPromocao.ToEntities().ToList(), itenspedido.ItensPedidoDto.Produto.IdCategoria);

            if (descontopromocao != null)
            {
                foreach (var promocao in ListaPromocao.Where(x => x.IdPromocao == descontopromocao.IdPromocao))
                {
                    foreach (var itens in promocao.ItensPedidos.Where(x => x.Produto.IdCategoria == promocao.IdCategoria))
                    {
                        itens.Desconto = (float)descontopromocao.Desconto;
                    }
                }
            }

            RaisePropertyChanged(() => ComprarTotalizador);

            CarregarCatalogoPromocao(true);
        });

        public MvxCommand ProsseguirCarrinho => _prosseguircarrinho = _prosseguircarrinho ?? new MvxCommand(() =>
        {
            var possuiitensvendidos = false;
            foreach (var catalogoPromocaoDto in ListaPromocao)
            {
                if (catalogoPromocaoDto.ItensPedidos.Any(x => x.QtdeVenda > 0))
                {
                    possuiitensvendidos = true;

                    break;
                }
            }

            if (possuiitensvendidos)
            {
                _itensPedidoApplication.InserirItensPedido(ListaPromocao.ToList().ToEntities());

                ShowViewModel<CarrinhoCompraViewModel>();
            }
            else
            {
                Mvx.Resolve<IUserDialogs>().Toast("Sem itens vendidos no pedido");
            }
        });

        #endregion        
    }
}