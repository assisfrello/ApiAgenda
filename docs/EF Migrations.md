1. Executar com perfil de build "Debug";

2. Comandos EF Migrations:
    1. 
        ```bash
        dotnet ef migrations add MigrationX_NomeTabela_Acao --project ApiAgenda.Data --startup-project ApiAgenda.Api --verbose

        dotnet ef migrations remove --project ApiAgenda.Data --startup-project ApiAgenda.Api --verbose
       
        dotnet ef migrations script --project ApiAgenda.Data --startup-project ApiAgenda.Api MIGRATION_ORIGEM MIGRATION DESTINO
       
        dotnet ef database update --project ApiAgenda.Data --startup-project ApiAgenda.Api --verbose
       ```
    