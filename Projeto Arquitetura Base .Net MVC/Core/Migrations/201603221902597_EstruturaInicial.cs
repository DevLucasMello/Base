namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstruturaInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Creditos.Compras",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FielID = c.Int(nullable: false),
                        PacoteID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        FormaPagamentoID = c.Int(nullable: false),
                        Creditos = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Usuarios.Fieis", t => t.FielID, cascadeDelete: true)
                .ForeignKey("Creditos.Pacotes", t => t.PacoteID, cascadeDelete: true)
                .Index(t => t.FielID)
                .Index(t => t.PacoteID);
            
            CreateTable(
                "Usuarios.Fieis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Usuarios.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "Igrejas.IgrejaFieis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IgrejaID = c.Int(nullable: false),
                        FielID = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Usuarios.Fieis", t => t.FielID, cascadeDelete: true)
                .ForeignKey("Igrejas.Igrejas", t => t.IgrejaID, cascadeDelete: true)
                .Index(t => t.IgrejaID)
                .Index(t => t.FielID);
            
            CreateTable(
                "Igrejas.Igrejas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150),
                        Publica = c.Boolean(nullable: false),
                        Excluida = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Igrejas.IgrejaPastores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IgrejaID = c.Int(nullable: false),
                        PastorID = c.Int(nullable: false),
                        Administrador = c.Boolean(nullable: false),
                        EnviaMensagens = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Igrejas.Igrejas", t => t.IgrejaID, cascadeDelete: true)
                .ForeignKey("Usuarios.Pastores", t => t.PastorID, cascadeDelete: true)
                .Index(t => t.IgrejaID)
                .Index(t => t.PastorID);
            
            CreateTable(
                "Usuarios.Pastores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        CreditosCobrados = c.Int(nullable: false),
                        RecebePedidos = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Usuarios.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "Usuarios.ContasBancarias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PastorID = c.Int(nullable: false),
                        TipoID = c.Int(nullable: false),
                        BancoNumero = c.String(maxLength: 10),
                        BancoNome = c.String(maxLength: 100),
                        AgenciaNumero = c.String(maxLength: 10),
                        AgenciaDigito = c.String(maxLength: 5),
                        ContaNumero = c.String(maxLength: 10),
                        ContaDigito = c.String(maxLength: 5),
                        CPF = c.String(maxLength: 11),
                        Titular = c.String(maxLength: 100),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Usuarios.Pastores", t => t.PastorID, cascadeDelete: true)
                .Index(t => t.PastorID);
            
            CreateTable(
                "Comunicacao.Mensagens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IgrejaID = c.Int(nullable: false),
                        PastorID = c.Int(nullable: false),
                        ConteudoID = c.Int(nullable: false),
                        Titulo = c.String(maxLength: 200),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Comunicacao.Conteudos", t => t.ConteudoID, cascadeDelete: true)
                .ForeignKey("Usuarios.Pastores", t => t.PastorID, cascadeDelete: true)
                .ForeignKey("Igrejas.Igrejas", t => t.IgrejaID, cascadeDelete: true)
                .Index(t => t.IgrejaID)
                .Index(t => t.PastorID)
                .Index(t => t.ConteudoID);
            
            CreateTable(
                "Comunicacao.Conteudos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TipoID = c.Int(nullable: false),
                        Valor = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Comunicacao.Oracoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FielID = c.Int(nullable: false),
                        PastorID = c.Int(nullable: false),
                        Creditos = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        PedidoID = c.Int(nullable: false),
                        RespostaID = c.Int(),
                        Prioridade = c.Boolean(nullable: false),
                        Titulo = c.String(maxLength: 100),
                        DataResposta = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Usuarios.Fieis", t => t.FielID, cascadeDelete: false)
                .ForeignKey("Usuarios.Pastores", t => t.PastorID, cascadeDelete: false)
                .ForeignKey("Comunicacao.Conteudos", t => t.PedidoID, cascadeDelete: true)
                .ForeignKey("Comunicacao.Conteudos", t => t.RespostaID)
                .Index(t => t.FielID)
                .Index(t => t.PastorID)
                .Index(t => t.PedidoID)
                .Index(t => t.RespostaID);
            
            CreateTable(
                "Financeiro.Saques",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StatusID = c.Int(nullable: false),
                        Creditos = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataPagamento = c.DateTime(),
                        CotacaoID = c.Int(nullable: false),
                        PastorID = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Financeiro.Cotacoes", t => t.CotacaoID, cascadeDelete: true)
                .ForeignKey("Usuarios.Pastores", t => t.PastorID, cascadeDelete: true)
                .Index(t => t.CotacaoID)
                .Index(t => t.PastorID);
            
            CreateTable(
                "Financeiro.Cotacoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Inicio = c.DateTime(nullable: false),
                        Fim = c.DateTime(),
                        Disponivel = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Usuarios.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Codigo = c.Guid(nullable: false),
                        TipoID = c.Int(nullable: false),
                        SaldoCreditos = c.Int(nullable: false),
                        Foto = c.String(maxLength: 100),
                        Nome = c.String(maxLength: 100),
                        Email = c.String(maxLength: 200),
                        Senha = c.String(maxLength: 100),
                        Bloqueado = c.Boolean(nullable: false),
                        UltimoAcesso = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Creditos.Lancamentos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UsuarioID = c.Int(nullable: false),
                        ReferenciaID = c.Int(nullable: false),
                        TipoID = c.Int(nullable: false),
                        Creditos = c.Int(nullable: false),
                        DataLancamento = c.DateTime(nullable: false),
                        Descricao = c.String(maxLength: 100),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Usuarios.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "Comunicacao.Notificacoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TipoID = c.Int(nullable: false),
                        ReferenciaID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                        Excluida = c.Boolean(nullable: false),
                        DataLeitura = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Usuarios.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "Creditos.Pacotes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Creditos = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Disponivel = c.Boolean(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Financeiro.Pagamentos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompraID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        FormaPagamentoID = c.Int(nullable: false),
                        TID = c.String(maxLength: 20),
                        Retorno = c.Int(nullable: false),
                        Mensagem = c.String(),
                        DataPagamento = c.DateTime(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("Creditos.Compras", t => t.CompraID, cascadeDelete: true)
                .Index(t => t.CompraID);
            
            CreateTable(
                "Igrejas.TermosBiblicos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Termo = c.String(maxLength: 150),
                        URL = c.String(maxLength: 500),
                        Descricao = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Financeiro.Pagamentos", "CompraID", "Creditos.Compras");
            DropForeignKey("Creditos.Compras", "PacoteID", "Creditos.Pacotes");
            DropForeignKey("Comunicacao.Mensagens", "IgrejaID", "Igrejas.Igrejas");
            DropForeignKey("Usuarios.Pastores", "UsuarioID", "Usuarios.Usuarios");
            DropForeignKey("Comunicacao.Notificacoes", "UsuarioID", "Usuarios.Usuarios");
            DropForeignKey("Creditos.Lancamentos", "UsuarioID", "Usuarios.Usuarios");
            DropForeignKey("Usuarios.Fieis", "UsuarioID", "Usuarios.Usuarios");
            DropForeignKey("Financeiro.Saques", "PastorID", "Usuarios.Pastores");
            DropForeignKey("Financeiro.Saques", "CotacaoID", "Financeiro.Cotacoes");
            DropForeignKey("Comunicacao.Oracoes", "RespostaID", "Comunicacao.Conteudos");
            DropForeignKey("Comunicacao.Oracoes", "PedidoID", "Comunicacao.Conteudos");
            DropForeignKey("Comunicacao.Oracoes", "PastorID", "Usuarios.Pastores");
            DropForeignKey("Comunicacao.Oracoes", "FielID", "Usuarios.Fieis");
            DropForeignKey("Comunicacao.Mensagens", "PastorID", "Usuarios.Pastores");
            DropForeignKey("Comunicacao.Mensagens", "ConteudoID", "Comunicacao.Conteudos");
            DropForeignKey("Igrejas.IgrejaPastores", "PastorID", "Usuarios.Pastores");
            DropForeignKey("Usuarios.ContasBancarias", "PastorID", "Usuarios.Pastores");
            DropForeignKey("Igrejas.IgrejaPastores", "IgrejaID", "Igrejas.Igrejas");
            DropForeignKey("Igrejas.IgrejaFieis", "IgrejaID", "Igrejas.Igrejas");
            DropForeignKey("Igrejas.IgrejaFieis", "FielID", "Usuarios.Fieis");
            DropForeignKey("Creditos.Compras", "FielID", "Usuarios.Fieis");
            DropIndex("Financeiro.Pagamentos", new[] { "CompraID" });
            DropIndex("Comunicacao.Notificacoes", new[] { "UsuarioID" });
            DropIndex("Creditos.Lancamentos", new[] { "UsuarioID" });
            DropIndex("Financeiro.Saques", new[] { "PastorID" });
            DropIndex("Financeiro.Saques", new[] { "CotacaoID" });
            DropIndex("Comunicacao.Oracoes", new[] { "RespostaID" });
            DropIndex("Comunicacao.Oracoes", new[] { "PedidoID" });
            DropIndex("Comunicacao.Oracoes", new[] { "PastorID" });
            DropIndex("Comunicacao.Oracoes", new[] { "FielID" });
            DropIndex("Comunicacao.Mensagens", new[] { "ConteudoID" });
            DropIndex("Comunicacao.Mensagens", new[] { "PastorID" });
            DropIndex("Comunicacao.Mensagens", new[] { "IgrejaID" });
            DropIndex("Usuarios.ContasBancarias", new[] { "PastorID" });
            DropIndex("Usuarios.Pastores", new[] { "UsuarioID" });
            DropIndex("Igrejas.IgrejaPastores", new[] { "PastorID" });
            DropIndex("Igrejas.IgrejaPastores", new[] { "IgrejaID" });
            DropIndex("Igrejas.IgrejaFieis", new[] { "FielID" });
            DropIndex("Igrejas.IgrejaFieis", new[] { "IgrejaID" });
            DropIndex("Usuarios.Fieis", new[] { "UsuarioID" });
            DropIndex("Creditos.Compras", new[] { "PacoteID" });
            DropIndex("Creditos.Compras", new[] { "FielID" });
            DropTable("Igrejas.TermosBiblicos");
            DropTable("Financeiro.Pagamentos");
            DropTable("Creditos.Pacotes");
            DropTable("Comunicacao.Notificacoes");
            DropTable("Creditos.Lancamentos");
            DropTable("Usuarios.Usuarios");
            DropTable("Financeiro.Cotacoes");
            DropTable("Financeiro.Saques");
            DropTable("Comunicacao.Oracoes");
            DropTable("Comunicacao.Conteudos");
            DropTable("Comunicacao.Mensagens");
            DropTable("Usuarios.ContasBancarias");
            DropTable("Usuarios.Pastores");
            DropTable("Igrejas.IgrejaPastores");
            DropTable("Igrejas.Igrejas");
            DropTable("Igrejas.IgrejaFieis");
            DropTable("Usuarios.Fieis");
            DropTable("Creditos.Compras");
        }
    }
}
