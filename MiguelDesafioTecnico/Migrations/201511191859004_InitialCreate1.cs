namespace MiguelDesafioTecnico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Despesas",
                c => new
                    {
                        DespesaId = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Categoria = c.String(),
                        Data = c.String(),
                        Observacao = c.String(),
                        Relatorio_RelatorioId = c.Int(),
                    })
                .PrimaryKey(t => t.DespesaId)
                .ForeignKey("dbo.Relatorios", t => t.Relatorio_RelatorioId)
                .Index(t => t.Relatorio_RelatorioId);
            
            CreateTable(
                "dbo.GeraPdfs",
                c => new
                    {
                        GeraPdfId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.GeraPdfId);
            
            CreateTable(
                "dbo.Relatorios",
                c => new
                    {
                        RelatorioId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RelatorioId);
            
            AddColumn("dbo.Receitas", "Relatorio_RelatorioId", c => c.Int());
            CreateIndex("dbo.Receitas", "Relatorio_RelatorioId");
            AddForeignKey("dbo.Receitas", "Relatorio_RelatorioId", "dbo.Relatorios", "RelatorioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receitas", "Relatorio_RelatorioId", "dbo.Relatorios");
            DropForeignKey("dbo.Despesas", "Relatorio_RelatorioId", "dbo.Relatorios");
            DropIndex("dbo.Receitas", new[] { "Relatorio_RelatorioId" });
            DropIndex("dbo.Despesas", new[] { "Relatorio_RelatorioId" });
            DropColumn("dbo.Receitas", "Relatorio_RelatorioId");
            DropTable("dbo.Relatorios");
            DropTable("dbo.GeraPdfs");
            DropTable("dbo.Despesas");
        }
    }
}
