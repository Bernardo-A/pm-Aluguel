namespace Aluguel.API.ViewModels
{
    public class AluguelViewModel
    {
        public int Id { get; set; }
        public int? CiclistaId { get; set; }
        public int? BicicletaId { get; set; }
        public DateTime DataAluguel { get; set; } = DateTime.Now;
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
        public BicicletaModel? Bicicleta { get; set; }
        public int? Numero { get; set; }
        public string? Localizacao { get; set; }
        public string? AnoDeFabricacao { get; set; }
        public string? Modelo { get; set; }
        public string? Status { get; set; }

    }

    public class BicicletaModel : BicicletaDTO
    {
        public int Id { get; set; }
    }
    public class BicicletaDTO
    {
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Ano { get; set; }
        public string? Numero { get; set; }
        public string? Status { get; set; }
    }

    public class AluguelRetrieveViewModel
    {
        public int TrancaId { get; set; }
        public int BicicletaId { get; set; }

    }

    public class CobrancaDto
    {
        public decimal Valor { get; set; }
        public int Ciclista { get; set; }
    }

    public class CartaoDto
    {
        public string? CardNumber { get; set; }
        public string? Holder { get; set; }
        public string? ExpirationDate { get; set; }
        public string? SecurityCode { get; set; }
    }

}