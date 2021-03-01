using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Models.Base
{
    public class MensagemModel
    {

        public enum Tipos
        {
            Sucesso = 0,
            Erro = 1
        }

        public Tipos tipo { get; set; }
        public string descricao { get; set; }

        public MensagemModel(Tipos _tipo, string _descricao)
        {
            this.tipo = tipo;
            this.descricao = descricao;
        }

    }
}
