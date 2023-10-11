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
                        EscuelaID = c.Int(nullable: false),
                        Escuelas_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escuelas", t => t.Escuelas_ID)
                .Index(t => t.Escuelas_ID);
            
            CreateTable(
                "dbo.Asistencias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fecha = c.Int(nullable: false),
                        AlumnoID = c.Int(nullable: false),
                        Alumnoes_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alumnoes", t => t.Alumnoes_ID)
                .Index(t => t.Alumnoes_ID);
            
            CreateTable(
                "dbo.GrupoAlumnoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GrupoID = c.Int(nullable: false),
                        AlumnoID = c.Int(nullable: false),
                        Alumnoes_ID = c.Int(),
                        Grupoes_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alumnoes", t => t.Alumnoes_ID)
                .ForeignKey("dbo.Grupoes", t => t.Grupoes_ID)
                .Index(t => t.Alumnoes_ID)
                .Index(t => t.Grupoes_ID);
            
            CreateTable(
                "dbo.Grupoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estatus = c.Boolean(nullable: false),
                        EscuelaID = c.Int(nullable: false),
                        GradoID = c.Int(nullable: false),
                        Escuelas_ID = c.Int(),
                        Gradoes_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escuelas", t => t.Escuelas_ID)
                .ForeignKey("dbo.Gradoes", t => t.Gradoes_ID)
                .Index(t => t.Escuelas_ID)
                .Index(t => t.Gradoes_ID);
            
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
                        MateriaID = c.Int(nullable: false),
                        GradoID = c.Int(nullable: false),
                        Gradoes_ID = c.Int(),
                        Materias_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gradoes", t => t.Gradoes_ID)
                .ForeignKey("dbo.Materias", t => t.Materias_ID)
                .Index(t => t.Gradoes_ID)
                .Index(t => t.Materias_ID);
            
            CreateTable(
                "dbo.GrupoProfesorMateriaGradoOrientadorReportes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GrupoID = c.Int(nullable: false),
                        ProfesorID = c.Int(nullable: false),
                        MateriaGradoID = c.Int(nullable: false),
                        OrientadorID = c.Int(nullable: false),
                        CicloEscolarID = c.Int(nullable: false),
                        CicloEscolars_ID = c.Int(),
                        Grupoes_ID = c.Int(),
                        MateriaGradoes_ID = c.Int(),
                        Orientadors_ID = c.Int(),
                        Profesors_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CicloEscolars", t => t.CicloEscolars_ID)
                .ForeignKey("dbo.Grupoes", t => t.Grupoes_ID)
                .ForeignKey("dbo.MateriaGradoes", t => t.MateriaGradoes_ID)
                .ForeignKey("dbo.Orientadors", t => t.Orientadors_ID)
                .ForeignKey("dbo.Profesors", t => t.Profesors_ID)
                .Index(t => t.CicloEscolars_ID)
                .Index(t => t.Grupoes_ID)
                .Index(t => t.MateriaGradoes_ID)
                .Index(t => t.Orientadors_ID)
                .Index(t => t.Profesors_ID);
            
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
                        EscuelaID = c.Int(nullable: false),
                        Escuelas_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escuelas", t => t.Escuelas_ID)
                .Index(t => t.Escuelas_ID);
            
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
                        EscuelaID = c.Int(nullable: false),
                        Escuelas_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escuelas", t => t.Escuelas_ID)
                .Index(t => t.Escuelas_ID);
            
            CreateTable(
                "dbo.Reportes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Contenido = c.String(),
                        Importancia = c.String(),
                        ValidadoOrientador = c.Boolean(nullable: false),
                        ValidadoTutor = c.Boolean(nullable: false),
                        AlumnoID = c.Int(nullable: false),
                        GrupoProfesorMateriaGradoOrientadorReporteID = c.Int(nullable: false),
                        Alumnoes_ID = c.Int(),
                        GrupoProfesorMateriaGradoOrientadorReportes_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alumnoes", t => t.Alumnoes_ID)
                .ForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", t => t.GrupoProfesorMateriaGradoOrientadorReportes_ID)
                .Index(t => t.Alumnoes_ID)
                .Index(t => t.GrupoProfesorMateriaGradoOrientadorReportes_ID);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estatus = c.Boolean(nullable: false),
                        EscuelaID = c.Int(nullable: false),
                        Escuelas_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Escuelas", t => t.Escuelas_ID)
                .Index(t => t.Escuelas_ID);
            
            CreateTable(
                "dbo.TutorAlumnoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TutorID = c.Int(nullable: false),
                        AlumnoID = c.Int(nullable: false),
                        Alumnoes_ID = c.Int(),
                        Tutors_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Alumnoes", t => t.Alumnoes_ID)
                .ForeignKey("dbo.Tutors", t => t.Tutors_ID)
                .Index(t => t.Alumnoes_ID)
                .Index(t => t.Tutors_ID);
            
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
            DropForeignKey("dbo.TutorAlumnoes", "Tutors_ID", "dbo.Tutors");
            DropForeignKey("dbo.TutorAlumnoes", "Alumnoes_ID", "dbo.Alumnoes");
            DropForeignKey("dbo.GrupoAlumnoes", "Grupoes_ID", "dbo.Grupoes");
            DropForeignKey("dbo.MateriaGradoes", "Materias_ID", "dbo.Materias");
            DropForeignKey("dbo.Materias", "Escuelas_ID", "dbo.Escuelas");
            DropForeignKey("dbo.Reportes", "GrupoProfesorMateriaGradoOrientadorReportes_ID", "dbo.GrupoProfesorMateriaGradoOrientadorReportes");
            DropForeignKey("dbo.Reportes", "Alumnoes_ID", "dbo.Alumnoes");
            DropForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", "Profesors_ID", "dbo.Profesors");
            DropForeignKey("dbo.Profesors", "Escuelas_ID", "dbo.Escuelas");
            DropForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", "Orientadors_ID", "dbo.Orientadors");
            DropForeignKey("dbo.Orientadors", "Escuelas_ID", "dbo.Escuelas");
            DropForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", "MateriaGradoes_ID", "dbo.MateriaGradoes");
            DropForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", "Grupoes_ID", "dbo.Grupoes");
            DropForeignKey("dbo.GrupoProfesorMateriaGradoOrientadorReportes", "CicloEscolars_ID", "dbo.CicloEscolars");
            DropForeignKey("dbo.MateriaGradoes", "Gradoes_ID", "dbo.Gradoes");
            DropForeignKey("dbo.Grupoes", "Gradoes_ID", "dbo.Gradoes");
            DropForeignKey("dbo.Grupoes", "Escuelas_ID", "dbo.Escuelas");
            DropForeignKey("dbo.GrupoAlumnoes", "Alumnoes_ID", "dbo.Alumnoes");
            DropForeignKey("dbo.Alumnoes", "Escuelas_ID", "dbo.Escuelas");
            DropForeignKey("dbo.Asistencias", "Alumnoes_ID", "dbo.Alumnoes");
            DropForeignKey("dbo.Escuelas", "AdministradorID", "dbo.Administradors");
            DropIndex("dbo.TutorAlumnoes", new[] { "Tutors_ID" });
            DropIndex("dbo.TutorAlumnoes", new[] { "Alumnoes_ID" });
            DropIndex("dbo.Materias", new[] { "Escuelas_ID" });
            DropIndex("dbo.Reportes", new[] { "GrupoProfesorMateriaGradoOrientadorReportes_ID" });
            DropIndex("dbo.Reportes", new[] { "Alumnoes_ID" });
            DropIndex("dbo.Profesors", new[] { "Escuelas_ID" });
            DropIndex("dbo.Orientadors", new[] { "Escuelas_ID" });
            DropIndex("dbo.GrupoProfesorMateriaGradoOrientadorReportes", new[] { "Profesors_ID" });
            DropIndex("dbo.GrupoProfesorMateriaGradoOrientadorReportes", new[] { "Orientadors_ID" });
            DropIndex("dbo.GrupoProfesorMateriaGradoOrientadorReportes", new[] { "MateriaGradoes_ID" });
            DropIndex("dbo.GrupoProfesorMateriaGradoOrientadorReportes", new[] { "Grupoes_ID" });
            DropIndex("dbo.GrupoProfesorMateriaGradoOrientadorReportes", new[] { "CicloEscolars_ID" });
            DropIndex("dbo.MateriaGradoes", new[] { "Materias_ID" });
            DropIndex("dbo.MateriaGradoes", new[] { "Gradoes_ID" });
            DropIndex("dbo.Grupoes", new[] { "Gradoes_ID" });
            DropIndex("dbo.Grupoes", new[] { "Escuelas_ID" });
            DropIndex("dbo.GrupoAlumnoes", new[] { "Grupoes_ID" });
            DropIndex("dbo.GrupoAlumnoes", new[] { "Alumnoes_ID" });
            DropIndex("dbo.Asistencias", new[] { "Alumnoes_ID" });
            DropIndex("dbo.Alumnoes", new[] { "Escuelas_ID" });
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
