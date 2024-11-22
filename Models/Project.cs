namespace GreenFundGS.Models
{
    /// <summary>
    /// Representa a entidade Project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// ID do projeto.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Nome do projeto.
        /// </summary>
        public string NomeProjeto { get; set; } = string.Empty;

        /// <summary>
        /// Descrição do projeto.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Progresso do projeto.
        /// </summary>
        public int Progresso { get; set; } // Adicionada para refletir o progresso

        /// <summary>
        /// Impacto estimado do projeto.
        /// </summary>
        public string ImpactoEstimado { get; set; } = string.Empty;
    }
}
