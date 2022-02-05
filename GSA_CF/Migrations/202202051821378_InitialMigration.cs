namespace GSA_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Classificacaos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        id_aluno = c.Int(nullable: false),
                        id_uc = c.Int(nullable: false),
                        id_epoca = c.Int(nullable: false),
                        nota = c.Int(nullable: false),
                        obs = c.String(),
                        Aluno_id = c.Int(),
                        Epoca_id = c.Int(),
                        UC_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Alunoes", t => t.Aluno_id)
                .ForeignKey("dbo.Epocas", t => t.Epoca_id)
                .ForeignKey("dbo.UCs", t => t.UC_id)
                .Index(t => t.Aluno_id)
                .Index(t => t.Epoca_id)
                .Index(t => t.UC_id);
            
            CreateTable(
                "dbo.Epocas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UCs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classificacaos", "UC_id", "dbo.UCs");
            DropForeignKey("dbo.Classificacaos", "Epoca_id", "dbo.Epocas");
            DropForeignKey("dbo.Classificacaos", "Aluno_id", "dbo.Alunoes");
            DropIndex("dbo.Classificacaos", new[] { "UC_id" });
            DropIndex("dbo.Classificacaos", new[] { "Epoca_id" });
            DropIndex("dbo.Classificacaos", new[] { "Aluno_id" });
            DropTable("dbo.UCs");
            DropTable("dbo.Epocas");
            DropTable("dbo.Classificacaos");
            DropTable("dbo.Alunoes");
        }
    }
}
