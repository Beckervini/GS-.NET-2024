namespace GreenFundGS.Models
{
    /// <summary>
    /// Representa a entidade Donation.
    /// </summary>
    public class Donation
    {
        /// <summary>
        /// ID único da doação.
        /// </summary>
        public int DonationId { get; set; }

        /// <summary>
        /// Valor doado.
        /// </summary>
        public decimal ValorDoado { get; set; }

        /// <summary>
        /// Data em que a doação foi feita.
        /// </summary>
        public DateTime DataDoacao { get; set; } = DateTime.Now;

        /// <summary>
        /// Usuário que fez a doação.
        /// </summary>
        public Usuario User { get; set; } = new Usuario();

        /// <summary>
        /// ID do usuário que fez a doação.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Projeto para o qual a doação foi feita.
        /// </summary>
        public Project Project { get; set; } = new Project();

        /// <summary>
        /// ID do projeto relacionado à doação.
        /// </summary>
        public int ProjectId { get; set; }
    }
}
