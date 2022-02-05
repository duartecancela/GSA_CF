namespace GSA_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classificacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        AlunoId = c.Int(nullable: false),
                        UcId = c.Int(nullable: false),
                        EpocaId = c.Int(nullable: false),
                        Nota = c.Int(nullable: false),
                        Obs = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alunoes", t => t.AlunoId, cascadeDelete: true)
                .ForeignKey("dbo.Epocas", t => t.EpocaId, cascadeDelete: true)
                .ForeignKey("dbo.UCs", t => t.UcId, cascadeDelete: true)
                .Index(t => t.AlunoId)
                .Index(t => t.UcId)
                .Index(t => t.EpocaId);
            
            CreateTable(
                "dbo.Epocas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UCs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classificacaos", "UcId", "dbo.UCs");
            DropForeignKey("dbo.Classificacaos", "EpocaId", "dbo.Epocas");
            DropForeignKey("dbo.Classificacaos", "AlunoId", "dbo.Alunoes");
            DropIndex("dbo.Classificacaos", new[] { "EpocaId" });
            DropIndex("dbo.Classificacaos", new[] { "UcId" });
            DropIndex("dbo.Classificacaos", new[] { "AlunoId" });
            DropTable("dbo.UCs");
            DropTable("dbo.Epocas");
            DropTable("dbo.Classificacaos");
            DropTable("dbo.Alunoes");
        }
    }
}
