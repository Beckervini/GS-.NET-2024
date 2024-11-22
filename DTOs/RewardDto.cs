namespace GreenFundGS.DTOs
{
    /// <summary>
    /// Representa os dados transferidos para a recompensa.
    /// </summary>
    public class RewardDto
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
