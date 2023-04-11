# DesafioSbCreditoAPI
Construir uma API em NET6 que forneça um CRUD para um Front de cadastro de Operações.


# # Tecnologias e Arquitetura

Net6
MongoBD 5.0.6
XUnit 2.4
FluentAssertions 6.1
Moq 4.18

Adotada uma arquitetura em camadas com princípios de DDD, o Desing Pattern muito presente 
nesta arquitetura é o Facade, devido a camada Services fornecer metodos de faixada para que 
a controller se comunique com recursos servidos pela infraestrutura.

Utilizado também o padrão Repository desacoplando o acesso a dados e também o deixando genérico 
usando o tipo de dados da Abstração MongoDbDocumentBase qualquer classe que herdeira desta pode 
facilmente implementar um CRUD sem a necessidade de programar nenhuma linha de código.

# # Pre Requisitos deste Software

Abrir no Visual Studio 2022

Instale o MongoDb na versão 5.0.6. a instalação padrão irá instalar o mongo na porta :27017 
caso você use uma configuração diferente, informe o caminho do seu servidor mongo no arquivo appsettings.json.

Caso prefira, instale também o MongoDbCompass, para realizar os acessos aos data bases via interface gráfica.

Crie um data base com nome SbCredito, comando:

use SbCredito

Crie uma collection com o nome OperacaoCollection, comando:
db.createCollection("OperacaoCollection")

É possível também criar o data base e a collection via interface com o MongoDbCompass.

