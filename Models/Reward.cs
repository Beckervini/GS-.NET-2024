namespace GreenFundGS.Models
{
    /// <summary>
    /// Representa uma recompensa no sistema.
    /// </summary>
    public class Reward
    {
        /// <summary>
        /// ID da recompensa.
        /// </summary>
        public int RewardId { get; set; }

        /// <summary>
        /// Descrição da recompensa.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Tipo da recompensa.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Pontos necessários para obter a recompensa.
        /// </summary>
        public int Points { get; set; }
    }
}
