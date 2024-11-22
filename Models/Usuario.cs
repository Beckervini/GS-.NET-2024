using System.ComponentModel.DataAnnotations;

namespace GreenFundGS.Models
{
    /// <summary>
    /// Representa a entidade Usuario.
    /// </summary>
    public class Usuario
    {
        [Key]
        /// <summary>
        /// ID do usuário.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        public string NomeCompleto { get; set; } = string.Empty;

        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string Senha { get; set; } = string.Empty;

        /// <summary>
        /// Nível do usuário (ex.: Iniciante, Avançado).
        /// </summary>
        public string Nivel { get; private set; } = "Iniciante";

        /// <summary>
        /// Atualiza o nível do usuário.
        /// </summary>
        /// <param name="novoNivel">Novo nível a ser atribuído</param>
        public void AtualizarNivel(string novoNivel)
        {
            Nivel = novoNivel;
        }
    }
}
