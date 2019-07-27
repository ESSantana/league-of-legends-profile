using LoLStats.Controllers.model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoLStats.Models
{
    [Table("perfil")]
    public class Perfil
    {
        [Key]
        [Column("perfil_id", TypeName = "nvarchar(100)")]
        [Required]
        public string AccountId { get; set; }

        [Column("nome", TypeName = "nvarchar(25)")]
        [Required]
        public string Name { get; set; }

        [Column("fila_ranqueada", TypeName = "nvarchar(25)")]
        public string QueueType { get; set; }

        [Column("elo", TypeName = "nvarchar(20)")]
        public string Tier { get; set; }

        [Column("divisao", TypeName = "nvarchar(4)")]
        public string Rank { get; set; }

        [Column("pontos_liga")]
        public int LeaguePoints { get; set; }

        [Column("vitorias")]
        public int Wins { get; set; }

        [Column("derrotas")]
        public int Losses { get; set; }

        [Column("regiao",TypeName ="nvarchar(30)")]
        public string Regiao { get; set; }
    }
}
