# RifaCasa
RifaCasa é um projeto pessoal desenvolvido com o objetivo de realizar um grande sonho: sair do aluguel e conquistar minha casa própria.
Através do site, é possível participar da rifa solidária, visualizar os detalhes dos prêmios, valores, regras, e — em breve — realizar o pagamento via MercadoPago.

# Pré-visualização
O projeto está disponível para visualização no Render:

https://rifa-casa.onrender.com/

# Funcionalidades
- Página com informações principais (descrição, regras, valores)
- Exibição do número de rifas disponíveis e vendidos
- Pagamento via MercadoPago (em desenvolvimento)
- Responsividade para celulares

# Como rodar o projeto localmente
### Pré-Requisitos
- .NET 6 ou superior
- PostgreSQL

### Passo a passo
Clonar o repo
```
git clone https://github.com/JoaoVicDS/Rifa-Casa.git
cd Rifa-Casa
```
Configurar o banco de dados

Edite o arquivo appsettings.json com sua string de conexão PostgreSQL
```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=rifacasa_database;Username=user;Password=password"
}
```
Aplicar as migrations
```
dotnet ef database update
```
Caso ainda não tenha o EF Core CLI
```
dotnet tool install --global dotnet-ef
```
Executar o projeto
```
dotnet run
```
Acesse no navegador

- https://localhost:5001
- http://localhost:5000

# Como contribuir
Esse é um projeto pessoal com um objetivo muito importante para mim. Se você quiser apoiar de forma técnica ou divulgar, sinta-se à vontade para abrir uma issue ou contribuir com sugestões e melhorias!
