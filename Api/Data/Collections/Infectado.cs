using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

/* 
    Aqui, temos o que será mapeado para ser uma Collection ( o que seria uma tabela
nos bancos relacionais ) no mongo. Mas, Porque ?:

    Porque precisamos gravar no mongo, num formato especifico de geolocalização, para 
tratamentos de dados futuros.

    Em suma, essa classe, é a representação da collection, no banco.

    Uma doc que pode ajudar no entendimento: https://docs.mongodb.com/drivers/csharp
*/
namespace Api.Data.Collections
{
    public class Infectado
    {
        public Infectado(DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}