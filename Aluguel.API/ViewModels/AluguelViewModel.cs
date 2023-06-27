namespace Aluguel.API.ViewModels
{
    public class AluguelViewModel
    {
        public int Id { get; set; }
        public int? CiclistaId { get; set; }
        public int? BicicletaId { get; set; }
        public DateTime? DataAluguel { get; set; } = DateTime.UtcNow;
        public DateTime? DataDevolucao { get; set; }
        public int? TrancaInicio { get; set; }
        public int? TrancaFim { get; set; }
       
    }

    public class AluguelInsertViewModel
    {
        public int CiclistaId { get; set; }
        public int TrancaId { get; set; }
    }

    public class TrancaViewModel
    {
        public int Id { get; set; }
        public int? BicicletaId { get; set; }
        public int? Numero { get; set; }
        public string? Localizacao { get; set; }
        public string? AnoDeFabricacao { get; set; }
        public string? Modelo { get; set; }
        public string? Status { get; set; }

    }

}