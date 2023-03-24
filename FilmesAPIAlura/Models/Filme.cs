using System.ComponentModel.DataAnnotations;

namespace FilmesAPIAlura.Models
{
    public class Filme
    {
        [Required(ErrorMessage = "O Id do filme é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Titulo do filme é obrigatório")]
        [MaxLength(50, ErrorMessage = "O título do filme não pode exceder 50 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
        [MaxLength(50, ErrorMessage = "O Gênero do filme é obrigatório")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "A Duracao do filme é obrigatório")]
        [Range(70, 600, ErrorMessage = "A duração do filme não pode ser menor que 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
