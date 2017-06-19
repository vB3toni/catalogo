using System;

namespace MeusPedidos.Catalogo.Core.Domain.Validacoes
{
    public class ValidacaoResult
    {
        public ValidacaoResult()
        {
            Mensagem = string.Empty;

            IsValid = true;
        }

        public ValidacaoResult(string mensagem)
        {
            Mensagem = mensagem;

            IsValid = true;
        }

        public ValidacaoResult(bool result, string mensagem)
        {
            Mensagem = mensagem;

            IsValid = result;
        }

        public ValidacaoResult(bool result, params string[] mensagens)
        {
            IsValid = result;

            foreach (var mensagen in mensagens)
            {
                Mensagem += mensagen + Environment.NewLine;
            }
        }

        public bool IsValid { get; }

        public string Mensagem { get; }
    }
}