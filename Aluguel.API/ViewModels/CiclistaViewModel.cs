namespace Aluguel.API.ViewModels
{
    public class CiclistaViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? DataNascimento { get; set; }
        public string? CPF { get; set; }

        public PassaporteViewModel? Passaporte { get; set; }

        public string? Nacionalidade { get; set; }
        public string? Email { get; set; }
        public string? UrlFotoDocumento { get; set; }
        public string? Senha { get; set; }

        public  MeioDePagamentoViewModel? MeioDePagamento { get; set; }

        public bool EmailConfirmado { get; set; } = false;
    }
    public class CiclistaInsertViewModel
    {
        public string? Nome { get; set; }
        public string? DataNascimento { get; set; }
        public string? CPF { get; set; }

        public PassaporteViewModel? Passaporte { get; set; }

        public string? Nacionalidade { get; set; }
        public string? Email { get; set; }
        public string? UrlFotoDocumento { get; set; }
        public string? Senha { get; set; }

        public  MeioDePagamentoViewModel? MeioDePagamento { get; set; }
    }

    public class CiclistaEditViewModel
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }

        public PassaporteViewModel? Passaporte { get; set; }

        public string? Nacionalidade { get; set; }
        public string? Senha { get; set; }
        public string? UrlFotoDocumento { get; set; }

    }
}