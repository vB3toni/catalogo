using System.Globalization;
using System.Linq;
using Acr.UserDialogs;
using MeusPedidos.Catalogo.Core.Application.Dtos;
using MeusPedidos.Catalogo.Core.Application.Mappers.Converter;
using MeusPedidos.Catalogo.Core.Domain.Interfaces.Application;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using SimpleInjector;

namespace MeusPedidos.Catalogo.Core.Application.ViewModels
{
    public class CarrinhoCompraViewModel : MvxViewModel
    {
        #region Variaveis

        private readonly ICatalogoPromocaoApplication _catalogoPromocaoApplication;
        private readonly IItensPedidoApplication _itensPedidoApplication;

        private MvxCommand _finalizarCompra;
        private MvxObservableCollection<ItensPedidoDto> _listaItensPedido;

        #endregion

        public CarrinhoCompraViewModel()
        {
            _catalogoPromocaoApplication = Mvx.Resolve<Container>().GetInstance<ICatalogoPromocaoApplication>();

            _itensPedidoApplication = Mvx.Resolve<Container>().GetInstance<IItensPedidoApplication>();

            AtualizarListaCarrinhoCompra();
        }

        private void AtualizarListaCarrinhoCompra()
        {
            _listaItensPedido = _listaItensPedido ?? new MvxObservableCollection<ItensPedidoDto>(_itensPedidoApplication.BuscarTodosItens().ToDtos());
        }

        public MvxObservableCollection<ItensPedidoDto> ListaCarrinho
        {
            get => _listaItensPedido;
            set
            {
                _listaItensPedido = value;

                RaisePropertyChanged(() => ListaCarrinho);
            }
        }

        public string ValorTotalPedido => _catalogoPromocaoApplication.SomarTotalVendido(_listaItensPedido.ToList().ToEntities()).ToString("C2", new CultureInfo("pt-br"));

        public string QtdeTotalItens => _catalogoPromocaoApplication.SomarTotalItensVendidos(_listaItensPedido.ToList().ToEntities()) + " UN";

        public MvxCommand FinalizarCompra => _finalizarCompra = _finalizarCompra ?? new MvxCommand(() =>
        {
            var confirm = new ConfirmConfig
            {
                CancelText = "Cancelar",
                OkText = "Gravar Pedido",
                Message = "Deseja gravar o pedido?",
                OnAction = retorno =>
                {
                    if (retorno)
                    {
                        Mvx.Resolve<IUserDialogs>().Alert("Pedido Gravado com sucesso", "Gravar Pedido", "Ok");
                    }

                    Close(this);
                }
            };

            Mvx.Resolve<IUserDialogs>().Confirm(confirm);
        });
    }
}