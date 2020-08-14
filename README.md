# dotnet-mongo

Fork de um curso da Digital innovation one, lecionado pelo Gabriel Faradai, para criação de uma API dotnet com MongoDB, para guardar estatisticas de pessoas infectadas com Covid19 e potencialmente uma posterior tratativa dessas informações.

## What did I do:
  - Adicionei o BsonID para os objetos.
  - Dockerizei o ambiente.
  
Um primeiro json para você:

```json
{
	"dataNascimento": "1990-03-01",
	"sexo": "M",
	"latitude": -23.5630994,
	"longitude": -46.6565712
}
```
## OBS: 
### Rode o docker-compose para subir um mongo standalone ( eu te desencorajo a fazer uma instalação do mongo standalone para produção, faremos aqui somente para estudo ), e descomente o serviço app, caso queira subir a api em um container, mas sem debug ( a menos que você configure ), e na porta 80 ( então, deve ser trocar na string de conexão. )

## Links Uteis:

- postman - https://www.postman.com/downloads/
- docker - https://docs.docker.com/

## Referências:
Claro que não poderia faltar a DIO !
https://digitalinnovation.one/

https://docs.mongodb.com/

https://docs.mongodb.com/manual/

https://docs.mongodb.com/ecosystem/drivers/csharp/
