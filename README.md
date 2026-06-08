# iShoppingProject

## Descrição
O iShopping é uma aplicação desktop desenvolvida no âmbito de um projeto académico de um curso TeSP. A aplicação tem como objetivo apoiar a gestão de compras, permitindo ao utilizador organizar artigos, planear compras, registar produtos adquiridos, controlar orçamentos mensais e consultar estatísticas relacionadas com os seus gastos.

## Funcionalidades
- Autenticação de utilizadores.
- Registo de novos utilizadores.
- Gestão de utilizadores.
- Gestão de tipos/categorias de artigos.
- Gestão de artigos.
- Criação e gestão de orçamentos mensais.
- Planeamento de compras.
- Adição de artigos previstos às compras planeadas.
- Execução de compras em modo compra.
- Registo de quantidades adquiridas e preços unitários.
- Adição de artigos não previstos durante a compra.
- Fecho de compras, impedindo alterações posteriores.
- Consulta de compras abertas e fechadas.
- Consulta de estatísticas mensais.
- Sugestão de orçamento com base no histórico de compras.
- Sugestão de lista de compras.
- Exportação de compras fechadas para ficheiro CSV.

## Tecnologias Utilizadas
- C#.
- Windows Forms.
- .NET Framework 4.7.2.
- Entity Framework 6.
- SQL Server LocalDB.
- LINQ.
- Visual Studio.
- NuGet.

## Requisitos
Para executar a aplicação é necessário ter instalado:

- Sistema operativo Windows.
- Visual Studio 2019 ou Visual Studio 2022.
- .NET Framework 4.7.2 Developer Pack.
- SQL Server Express LocalDB.
- NuGet Package Restore ativo no Visual Studio.

## Instalação e Execução
1. Extrair o projeto para uma pasta local.
2. Abrir o ficheiro da solução `iShopping.sln` no Visual Studio.
3. Restaurar os pacotes NuGet, caso o Visual Studio não o faça automaticamente.
4. Confirmar que a ligação à base de dados está configurada no ficheiro `App.config`.
5. Compilar o projeto através da opção **Build Solution**.
6. Executar a aplicação através do botão **Start** ou da tecla **F5**.
7. Efetuar login ou criar um novo utilizador.

Credenciais de teste disponíveis:

```text
Utilizador: abc
Password: 123
```

## Estrutura do Projeto
- `Controller/` — contém os controladores responsáveis pela lógica da aplicação e pela comunicação entre a interface gráfica e os dados.
- `Model/` — contém as classes do modelo de dados, o contexto da base de dados e a configuração inicial da aplicação.
- `Views/` — contém os formulários Windows Forms utilizados na interface gráfica da aplicação.
- `Properties/` — contém ficheiros de configuração e recursos gerados pelo Visual Studio.
- `App.config` — contém a configuração da ligação à base de dados.
- `Program.cs` — contém o ponto de entrada da aplicação.
- `packages.config` — contém a referência aos pacotes NuGet utilizados no projeto.

## Autores
- Eduardo Santos - nº2241535
- Miguel Henriques - nº2241863
- Sardor Uktamov - nº2241538

## Unidade Curricular
- Unidade Curricular: Desenvolvimento de Aplicações
- Curso: TeSP em Programação de Sistemas de Informação
- Ano letivo: 2025/2026
