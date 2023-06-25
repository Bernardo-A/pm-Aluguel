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
    
}