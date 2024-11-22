🍃 GreenFund
A GreenFund é uma iniciativa que conecta pessoas dispostas a contribuir com projetos sustentáveis, visando beneficiar tanto comunidades carentes quanto espaços públicos. A plataforma permite que indivíduos façam pequenas doações para financiar soluções de energia limpa, como a instalação de painéis solares em escolas, a modernização da iluminação pública com tecnologias eficientes e a implementação de sistemas de energia renovável em áreas com pouca infraestrutura.

Nosso objetivo é gerar um impacto positivo, não só no meio ambiente, mas também nas comunidades mais vulneráveis, melhorando a qualidade de vida e promovendo um futuro mais sustentável. A cada doação, os usuários podem acompanhar o progresso dos projetos, visualizar os resultados gerados e acumular pontos que podem ser trocados por recompensas simbólicas.

✒️ Desenvolvedores
RM98163 - Júlia Martins Santana Figueiredo - 2TDSA
RM550562 - Larissa Akemi Iwamoto - 2TDSA
RM550858 - Murilo Ribeiro Valério da Silva - 2TDSA
RM94679 - Vinicios Becker Prediger - 2TDSS
RM98570 - Gabriel Souza de Queiroz - 2TDSS

📌 Índice
Introdução
Principais Funcionalidades
Arquitetura e Design Patterns
Documentação da API
Banco de Dados
Testes Automatizados
Endpoints
Expressões de Gratidão
Introdução
A GreenFund foi desenvolvida para promover iniciativas de energia sustentável por meio de uma API em .NET Core. Esta solução segue princípios de arquitetura modular e escalável, aplicando padrões de design e boas práticas de desenvolvimento, garantindo um código limpo e de fácil manutenção.

Principais Funcionalidades
Doações Simples: Contribuições rápidas para apoiar projetos de energia renovável em comunidades carentes e espaços públicos.
Acompanhamento de Metas: Visualização do progresso e metas de cada projeto.
Sistema de Pontos e Recompensas: Incentivos como certificados digitais e atualizações dos impactos gerados.
Impacto Sustentável: Cada doação contribui para a redução de CO₂, economia de energia e benefícios sociais em áreas carentes e no espaço público.
Arquitetura e Design Patterns
Arquitetura
A API segue uma arquitetura em camadas, dividindo a aplicação em:

Camada de Apresentação
Lógica de Negócios
Acesso a Dados
Essa estrutura promove modularidade e separação de responsabilidades.

Design Patterns Implementados
Repository Pattern: Encapsula a lógica de acesso a dados, promovendo uma separação clara de responsabilidades e facilitando a manutenção.
Dependency Injection: Gerencia dependências eficientemente, garantindo que os serviços sejam gerenciados pelo contêiner de injeção de dependência do .NET Core.
Factory Pattern: Implementado para facilitar a criação de instâncias complexas de objetos, como recompensas, com consistência e flexibilidade.
Documentação da API
A documentação da API foi implementada utilizando Swagger, proporcionando uma interface amigável e interativa para explorar e testar os endpoints da API.

Acessando a Documentação
Execute a aplicação e navegue para:
https://localhost:<porta>/swagger
Banco de Dados
O projeto utiliza o Oracle como banco de dados, com suporte total para operações CRUD.
A configuração está localizada na classe GreenFundContext, que mapeia as entidades para as tabelas do banco de dados.
Testes Automatizados
A API é coberta por testes automatizados, utilizando xUnit e Moq para garantir que as funcionalidades sejam testadas de forma eficiente.

xUnit: Framework utilizado para criar testes unitários.
Moq: Biblioteca usada para criar mocks e simular comportamentos durante os testes.
Endpoints
Autenticação
POST /api/auth/register: Registra um novo usuário.
POST /api/auth/login: Realiza o login do usuário.
Projetos
GET /api/projetos: Lista todos os projetos ativos.
POST /api/projetos/doacao: Permite que o usuário doe para um projeto específico.
Sistema de Pontos e Recompensas
GET /api/pontos: Retorna o saldo de pontos do usuário e o histórico de pontos ganhos.
GET /api/recompensas: Retorna as recompensas disponíveis.
POST /api/recompensas/resgatar: Permite que o usuário resgate recompensas.
Perfil do Usuário
GET /api/perfil: Retorna os dados do perfil do usuário.
Relatórios e Impacto
GET /api/impacto: Retorna os dados agregados do impacto das doações.
💚 Expressões de Gratidão
Gostaríamos de expressar nossa sincera gratidão aos professores que contribuíram para o sucesso deste projeto. A dedicação de todos foi essencial para nosso aprendizado e crescimento. Agradecemos pelo apoio, orientação e esforço compartilhado, que foram fundamentais para superarmos desafios e alcançarmos nossos objetivos.