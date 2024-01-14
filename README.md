# UserNotifications
Introdução
Este repositório contém a implementação de uma API para gerenciamento de assinaturas de usuários, desenvolvida em .NET 6, utilizando o SQL Server para a persistência de dados, e acesso a criação e configurações do banco de dados pelo Entity Framework, o RabbitMQ para a criação de filas, e as ferramentas SpecFlow e xUnit para testes automatizados e unitários, respectivamente.

**Funcionalidades**
A API é projetada para processar notificações relacionadas às assinaturas dos usuários, com os seguintes tipos de notificações suportados:

- SUBSCRIPTION_PURCHASED: Indica que uma compra foi realizada, e a assinatura deve ser marcada como ativa.
- SUBSCRIPTION_CANCELED: Informa que uma compra foi cancelada, e a assinatura deve ser marcada como cancelada.
- SUBSCRIPTION_RESTARTED: Sinaliza que uma compra foi recuperada, e a assinatura deve ser marcada como ativa.

O fluxo de execução da aplicação segue os passos abaixo:
- Recebimento da Notificação HTTP: A API é notificada por meio de requisições HTTP contendo as informações relevantes da assinatura.
- Enfileiramento: As notificações são enfileiradas no RabbitMQ, garantindo uma comunicação assíncrona e desacoplada.
- Processamento e Persistência: As notificações são processadas em segundo plano, garantindo eficiência e escalabilidade. O status das assinaturas é atualizado de acordo com o tipo de notificação recebida.

**Configuração**

Clone o repositório:

git clone https://github.com/vivibz/UserNotifications_microservice.git

Certifique-se de ter os seguintes componentes instalados antes de executar a aplicação:
- **.NET 6 SDK**:
  
  https://dotnet.microsoft.com/pt-br/download/dotnet/6.0
  
- **Docker**:
  Para acessar os containers a pasta Docker/compose.yml.
  Nele estará o container **RabbitMQ Server**,
  **SQL Server** e a apliacação **user_notification**

  Abra seu terminal e execute o comando:

  _docker run compose.yml_

- **IDE recomendada: Visual Studio**- Na IDE vá em Ferramentas/tools parte superior da IDE -> vá em _Gerenciador de pacotes do NuGet/NuGet Package Manager_  -> clique em _Gerenciador Pacotes do NuGet para a Solução/NuGet Package Manager for Solution_... 

Baixe: o Microsoft.EntityFrameworkCore.Design (v7.0.9); [...].EntityFrameworkCore.InMemory (v7.0.11); [...].EntityFrameworkCore.SqlServer (v7.0.9); [...].EntityFrameworkCore.Tools (v7.0.9); 
        
        RabbitMQ.Client (v6.6.0);
        
        SpecFlow (v3.9.40);
        
        xunit; xunit.assert; xunit.core e xunit.runner.visualstudio, todos com a (v2.5.1).

**Arquitetura**

![Arq UserNotification drawio](https://github.com/vivibz/UserNotifications_microservice/assets/87588852/8e48b376-ede5-4aba-b17f-1090c6041cd1)

- **Testes Automatizados**

A pasta UserNotificationApi.TestAuto contém os cenários de teste escritos com SpecFlow, 

- **Testes Unitários**

A pasta UserNotificationTests contém os testes unitários escritos com xUnit.

Execute os testes automatizados usando o seguinte comando:

Contribuição
Sinta-se à vontade para contribuir, relatar problemas ou propor melhorias. Abra uma issue ou envie um pull request.
