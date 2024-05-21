## "Continuação" do projeto SeviceSystem, agora com criação de front e integração do front com a api criada.

- Em construção 🔧🔨


https://getbootstrap.com/docs/5.3/getting-started/introduction/


# ServiceSystem

Serviço de Restaurante desenvolvido em .NET 5.0 com Entity Framework utilizando SQLite (banco armazenado em cache) e estrutura MVC.

## Final da Solução

![Final da Solução](https://github.com/DiegoViana90/ServiceSystem/assets/77411511/ff0676d0-27b0-4b12-b642-d2f3bddefdca)

## Estrutura Inicial do Banco

![Estrutura Inicial do Banco](https://github.com/DiegoViana90/ServiceSystem/assets/77411511/91b4459c-67e3-4db2-877a-c3ac4e5c15da)

## Anotações de Ideia

- Futuramente, irei criar uma nova tabela para separar os pedidos da conta final, vinculando cada atendimento a uma 'fatura final'.
- adicionar tempo de prepararo das comidas, para retornar essa informação para o cliente.


Branch feature/0006 da início ao frontEnd

## Guia de Execução

Este guia fornece instruções passo a passo para executar o ServiceSystem em seu ambiente local.

### Pré-requisitos

Antes de começar, certifique-se de ter o seguinte instalado em seu sistema:

- .NET 5.0 SDK
- SQLite

## **Passo 1: Clonar o Repositório**

Clone o repositório do ServiceSystem para o seu sistema local. Você pode fazer isso executando o seguinte comando no terminal:

``bash
git clone https://github.com/DiegoViana90/ServiceSystem.git

## **Passo 2: Navegar até o Diretório do Projeto**

Navegue até o diretório do projeto clonado usando o seguinte comando:
cd ServiceSystem

## **Passo 3: Executar o Aplicativo**

Execute o aplicativo usando o comando dotnet run ou F5, usando Visual Studio OU Visual Studio Code;

dotnet run

## **Passo 4: Acessar o Swagger**

Abra o seu navegador da web e vá para o seguinte URL:

http://localhost:5000/swagger/index.html

Isso abrirá a interface do Swagger, onde você pode interagir com os endpoints da API.

## **Passo 5: Interagir com a Aplicação**

Agora que o aplicativo está em execução e o Swagger está aberto, você pode explorar os diferentes endpoints e testar a funcionalidade da aplicação.

## **Passo 6: Parar o Aplicativo**

Quando terminar de usar o aplicativo, você pode interrompê-lo pressionando Ctrl + C no terminal onde ele está sendo executado.






## **Direcionamento no uso da API:**

- Método: **InsertOrder**

use a requisição para solicitar atendimento para mesa específica; (Inicialmente adicionei 3 mesas ao restaurante)

{
  "tableNumber": 0,
  "orderItems": [
    {
      "menuItemId": 0,
      "quantity": 0
    }
  ]
}

- Método: **CloseOrder**

use a requisição para solicitar o **encerramento** para mesa específica;


{
  "tableNumber": 0
}


- Método: **InsertMenuItem** 

use a requisição para **incluir** na tabela MenuItem um novo item ao cardápio (OrderItemType: usar 1 para comida e 2 para bebida);


{
  "name": "string",
  "price": 0,
  "orderItemType": 1
}

- Método: **UpdateMenuItem**

 use a requisição para **atualizar** nome, preço ou tipo na tabela MenuItem de um item já existente (OrderItemType: usar 1 para comida e 2 para bebida);


{
  "name": "string",
  "price": 0,
  "orderItemType": 1
}

- Método: **GetMenuItems**

 use a requisição para **Buscar** "Cardápio" do restaurante;
