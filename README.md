# Financial.Framework
__Em Construção__

Este repositorio inicialmente contém uma serie de facilitadores para ser usado na construção dos microservices para o sistema de finanças pessoal.


Aqui é possivel encontrar facilitadores para

__API__
- Abstrações para injeção de dependência

__Dominio__
- Abstrações para envio de eventos
- Abstrações de modelos base

__Infraestrutura Banco de Dados__
- Abstração Integração Banco não relacional (Inicialmente usando MongoDb)

__Infraestrutura Servicos__
- API Rest
- Abstração para integração com Mensageria (Inicialmente usando RabbitMq)

__Infraestrutura Integrações__
- Abstração para integração com App de Mensagens (Inicialmente usando Telegram)

__Futuras features__
- Log
- Configuração Swagger

Este projeto está fazendo uso do github actions para realizar o deploy continuo dos artefatos no nuget.
A explicação de como o deploy está sendo feito está no próprio arquivo yaml disponivel aqui [artifact-deploy](https://github.com/PauloDerney/Financial.Framework/blob/main/.github/workflows/artifact-deploy.yml)


Essa solução foi criada e inicialmente versionado no azure e devido a limitação da conta gratuita foi necessário criar todos projetos em uma única solução, agora que foi migrado para o github em breve analisarei a possibilidade de realizar a separação desses projetos em mais repositorios.

