using System.Collections.Generic;
using GestaoProdutos.Business.Notificacoes;

namespace GestaoProdutos.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}