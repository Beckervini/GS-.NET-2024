namespace GreenFundGS.DTOs
{
    /// <summary>
    /// DTO para criar uma nova doação.
    /// </summary>
    public class DonationDto
    {
        /// <summary>
        /// ID da doação.
        /// </summary>
        public int DonationId { get; set; }

        /// <summary>
        /// Valor doado.
        /// </summary>
        public decimal ValorDoado { get; set; }

        /// <summary>
        /// ID do usuário que fez a doação.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// ID do projeto relacionado à doação.
        /// </summary>
        public int ProjectId { get; set; }
    }
}
