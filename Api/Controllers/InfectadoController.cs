using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    // Informamos que é uma API Controller
    [ApiController]
    // Desse jeito, ele desconsidera o "controller" do nome da rota, fica "Infectado" mesmo.
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        // Declaramos um mongo pra gente.
        Data.MongoDB _mongoDB;
        // Declaramos uma coleção do mongo pra gente também.
        IMongoCollection<Infectado> _infectadosCollection;

        // E na instancia desse Controller, recebemos por injeção de dependencia, uma instancia do mongo ( no Startup.cs ).
        public InfectadoController(Data.MongoDB mongoDB)
        {
            // Iniciamos o Mongo
            _mongoDB = mongoDB;
            // E dizemos com qual coleção ele vai trabalhar, a Collection.Infectado ...
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        // Daqui pra baixo é REST
        [HttpPost]
        // Vai receber um objeto com a estrutura daquela DTO
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            // Instanciamos o que será o documento.
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);
            // E adicionamos na nossa coleção ali de cima.
            _infectadosCollection.InsertOne(infectado);
            // Retornamos essa ação
            return StatusCode(201, "Adicionado com sucesso");

            // Feito muleque. 
            // Se você gosta de gatos, e quiser saber mais sobre esse tipo de retorno: https://http.cat/201
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }
        
        [HttpPut]
        // Vai receber um objeto com a estrutura daquela DTO
        public ActionResult AtualizarInfectado([FromBody] InfectadoDto dto)
        {        
            // Editamos, filtrando por Data.
            _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.DataNascimento == dto.DataNascimento), Builders<Infectado>.Update.Set("sexo",dto.Sexo));
            // Retornamos essa ação
            return Ok("Atualizado com Sucesso");
            // Feito também
        }

        [HttpDelete("{dataNasc}")]
        // Vai receber um objeto com a estrutura daquela DTO
        public ActionResult DeleteInfectado(dataNasc)
        {        
            // Vamos procurar por data por enquanto.
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.DataNascimento == dto.dataNasc);
            return Ok("Atualizado com Sucesso");
            // Feito também
        }
    }
}
