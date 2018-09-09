# InitialWebApi

Web Api em aspnet Core 2.1 com as seguintes features:
- Swagger;
- Fluent Validation;
- CRUD básico de uma entidade no mongo DB;
- Log de requisições em mongo DB;

Requisitos:
Docker para subida do container MongoDb.
> cd <seu diretório>\InitialWebApi\InitialWebApi.MongoDb
> docker build -t mongo .
> docker run -it -p 27017:27017 mongo
