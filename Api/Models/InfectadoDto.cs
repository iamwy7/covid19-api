using System;

namespace Api.Models
{
    public class InfectadoDto
    {
        /*
            O ideal, é termos uma classe que represente o retorno da API.
            Mais ou menos um objeto serealizador...

            Também serve na hora de juntar as collections, já que elas não tem relacionamentos,
            mas você quer trazer as coisas juntas.

            Também proteje seu backend, e não expõe o funcionamento dele, afinal, quem consome
            minha API, não precisa saber que eu uso mongo...
        */
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}