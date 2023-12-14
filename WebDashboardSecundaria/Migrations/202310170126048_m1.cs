namespace WebDashboardSecundaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Correo = c.String(),
                        Contraseña = c.String(),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Escuelas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Estatus = c.Boolean(nullable: false),
                        AdministradorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Administradors", t => t.AdministradorID, cascadeDelete: true)
                .Index(t => t.AdministradorID);
            
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Matricula = c.Long(nullable: false),
                        Nombre = c.String(),
                        Estatus = c.Boolean(nullable: false),
                        EscuelasID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escuelas", t => t.EscuelasID, cascadeDelete: true)
                .Index(t => t.EscuelasID);
            
            CreateTable(
                "dbo.Asistencias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fecha = c.Int(nullable: false),
                        AlumnoesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alumnoes", t => t.AlumnoesID, cascadeDelete: true)
                .Index(t => t.AlumnoesID);
            
            CreateTable(
                "dbo.GrupoAlumnoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GrupoesID = c.Int(nullable: false),
                        AlumnoesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alumnoes", t => t.AlumnoesID, cascadeDelete: true)
                .ForeignKey("dbo.Grupoes", t => t.GrupoesID, cascadeDelete: true)
                .Index(t => t.GrupoesID)
                .Index(t => t.AlumnoesID);
            
            CreateTable(
                "dbo.Grupoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estatus = c.Boolean(nullable: false),
                        EscuelasID = c.Int(nullable: false),
                        GradoesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escuelas", t => t.EscuelasID, cascadeDelete: false)
                .ForeignKey("dbo.Gradoes", t => t.GradoesID, cascadeDelete: true)
                .Index(t => t.EscuelasID)
                .Index(t => t.GradoesID);
            
            CreateTable(
                "dbo.Gradoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MateriaGradoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MateriasID = c.Int(nullable: false),
                        GradoesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gradoes", t => t.GradoesID, cascadeDelete: true)
                .ForeignKey("dbo.Materias", t => t.MateriasID, cascadeDelete: true)
                .Index(t => t.MateriasID)
                .Index(t => t.GradoesID);
            
            CreateTable(
                "dbo.GrupoProfesorMateriaGradoOrientadorReportes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GrupoesID = c.Int(nullable: false),
                        ProfesorsID = c.Int(nullable: false),
                        MateriaGradoesID = c.Int(nullable: false),
                        OrientadorsID = c.Int(nullable: false),
                        CicloEscolarsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CicloEscolars", t => t.CicloEscolarsID, cascadeDelete: true)
                .ForeignKey("dbo.Grupoes", t => t.GrupoesID, cascadeDelete: true)
                .ForeignKey("dbo.MateriaGradoes", t => t.MateriaGradoesID, cascadeDelete: false)
                .ForeignKey("dbo.Orientadors", t => t.OrientadorsID, cascadeDelete: true)
                .ForeignKey("dbo.Profesors", t => t.ProfesorsID, cascadeDelete: true)
                .Index(t => t.GrupoesID)
                .Index(t => t.ProfesorsID)
                .Index(t => t.MateriaGradoesID)
                .Index(t => t.OrientadorsID)
                .Index(t => t.CicloEscolarsID);
            
            CreateTable(
                "dbo.CicloEscolars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orientadors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Matricula = c.Long(nullable: false),
                        Nombre = c.String(),
                        Correo = c.String(),
                        Contraseña = c.String(),
                        Estatus = c.Boolean(nullable: false),
                        EscuelasID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escuelas", t => t.EscuelasID, cascadeDelete: true)
                .Index(t => t.EscuelasID);
            
            CreateTable(
                "dbo.Profesors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Correo = c.String(),
                        Contraseña = c.String(),
                        Matricula = c.Long(nullable: false),
                        Nombre = c.String(),
                        Estatus = c.Boolean(nullable: false),
                        EscuelasID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escuelas", t => t.EscuelasID, cascadeDelete: false)
                .Index(t => t.EscuelasID);
            
            CreateTable(
                "dbo.Reportes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contenido = c.String(),
                        Importancia = c.String(),
                        ValidadoOrientador = c.Boolean(nullable: false),
                        ValidadoTutor = c.Boolean(nullable: false),
                        AlumnoesID = c.Int(nullable: false),
                        GrupoProfesorMateriaGradoOrientadorReportesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alumnoes", t => t.AlumnoesID, cascadeDelete: true)
                .ForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", t => t.GrupoProfesorMateriaGradoOrientadorReportesID, cascadeDelete: false)
                .Index(t => t.AlumnoesID)
                .Index(t => t.GrupoProfesorMateriaGradoOrientadorReportesID);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estatus = c.Boolean(nullable: false),
                        EscuelasID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escuelas", t => t.EscuelasID, cascadeDelete: true)
                .Index(t => t.EscuelasID);
            
            CreateTable(
                "dbo.TutorAlumnoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TutorsID = c.Int(nullable: false),
                        AlumnoesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alumnoes", t => t.AlumnoesID, cascadeDelete: true)
                .ForeignKey("dbo.Tutors", t => t.TutorsID, cascadeDelete: true)
                .Index(t => t.TutorsID)
                .Index(t => t.AlumnoesID);
            
            CreateTable(
                "dbo.Tutors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Correo = c.String(),
                        Contraseña = c.String(),
                        Nombre = c.String(),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TutorAlumnoes", "TutorsID", "dbo.Tutors");
            DropForeignKey("dbo.TutorAlumnoes", "AlumnoesID", "dbo.Alumnoes");
            DropForeignKey("dbo.GrupoAlumnoes", "GrupoesID", "dbo.Grupoes");
            DropForeignKey("dbo.MateriaGradoes", "MateriasID", "dbo.Materias");
            DropForeignKey("dbo.Materias", "EscuelasID", "dbo.Escuelas");
            DropForeignKey("dbo.Reportes", "GrupoProfesorMateriaGradoOrientadorReportesID", "dbo.GrupoProfesorMateriaGradoOrientadorReportes");
            DropForeignKey("dbo.Reportes", "AlumnoesID", "dbo.Alumnoes");
            DropForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", "ProfesorsID", "dbo.Profesors");
            DropForeignKey("dbo.Profesors", "EscuelasID", "dbo.Escuelas");
            DropForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", "OrientadorsID", "dbo.Orientadors");
            DropForeignKey("dbo.Orientadors", "EscuelasID", "dbo.Escuelas");
            DropForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", "MateriaGradoesID", "dbo.MateriaGradoes");
            DropForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", "GrupoesID", "dbo.Grupoes");
            DropForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", "CicloEscolarsID", "dbo.CicloEscolars");
            DropForeignKey("dbo.MateriaGradoes", "GradoesID", "dbo.Gradoes");
            DropForeignKey("dbo.Grupoes", "GradoesID", "dbo.Gradoes");
            DropForeignKey("dbo.Grupoes", "EscuelasID", "dbo.Escuelas");
            DropForeignKey("dbo.GrupoAlumnoes", "AlumnoesID", "dbo.Alumnoes");
            DropForeignKey("dbo.Alumnoes", "EscuelasID", "dbo.Escuelas");
            DropForeignKey("dbo.Asistencias", "AlumnoesID", "dbo.Alumnoes");
            DropForeignKey("dbo.Escuelas", "AdministradorID", "dbo.Administradors");
            DropIndex("dbo.TutorAlumnoes", new[] { "AlumnoesID" });
            DropIndex("dbo.TutorAlumnoes", new[] { "TutorsID" });
            DropIndex("dbo.Materias", new[] { "EscuelasID" });
            DropIndex("dbo.Reportes", new[] { "GrupoProfesorMateriaGradoOrientadorReportesID" });
            DropIndex("dbo.Reportes", new[] { "AlumnoesID" });
            DropIndex("dbo.Profesors", new[] { "EscuelasID" });
            DropIndex("dbo.Orientadors", new[] { "EscuelasID" });
            DropIndex("dbo.GrupoProfesorMateriaGradoOrientadorReportes", new[] { "CicloEscolarsID" });
            DropIndex("dbo.GrupoProfesorMateriaGradoOrientadorReportes", new[] { "OrientadorsID" });
            DropIndex("dbo.GrupoProfesorMateriaGradoOrientadorReportes", new[] { "MateriaGradoesID" });
            DropIndex("dbo.GrupoProfesorMateriaGradoOrientadorReportes", new[] { "ProfesorsID" });
            DropIndex("dbo.GrupoProfesorMateriaGradoOrientadorReportes", new[] { "GrupoesID" });
            DropIndex("dbo.MateriaGradoes", new[] { "GradoesID" });
            DropIndex("dbo.MateriaGradoes", new[] { "MateriasID" });
            DropIndex("dbo.Grupoes", new[] { "GradoesID" });
            DropIndex("dbo.Grupoes", new[] { "EscuelasID" });
            DropIndex("dbo.GrupoAlumnoes", new[] { "AlumnoesID" });
            DropIndex("dbo.GrupoAlumnoes", new[] { "GrupoesID" });
            DropIndex("dbo.Asistencias", new[] { "AlumnoesID" });
            DropIndex("dbo.Alumnoes", new[] { "EscuelasID" });
            DropIndex("dbo.Escuelas", new[] { "AdministradorID" });
            DropTable("dbo.Tutors");
            DropTable("dbo.TutorAlumnoes");
            DropTable("dbo.Materias");
            DropTable("dbo.Reportes");
            DropTable("dbo.Profesors");
            DropTable("dbo.Orientadors");
            DropTable("dbo.CicloEscolars");
            DropTable("dbo.GrupoProfesorMateriaGradoOrientadorReportes");
            DropTable("dbo.MateriaGradoes");
            DropTable("dbo.Gradoes");
            DropTable("dbo.Grupoes");
            DropTable("dbo.GrupoAlumnoes");
            DropTable("dbo.Asistencias");
            DropTable("dbo.Alumnoes");
            DropTable("dbo.Escuelas");
            DropTable("dbo.Administradors");
        }
    }
}
