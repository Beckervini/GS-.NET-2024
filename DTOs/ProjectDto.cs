namespace GreenFundGS.DTOs
{
    public class ProjectDto
    {
        public int ProjectId { get; set; } 

        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public int Progresso { get; set; }
        public string ImpactoEstimado { get; set; }
    }
}
