namespace Aluguel.API.ViewModels
{
    public class FuncionarioViewModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? DataNascimento { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Funcao { get; set; }
        public bool Habilitado { get; set; } = true;
    }
    public class FuncionarioInsertViewModel
    {
        public string? Nome { get; set; }
        public string? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Funcao { get; set; }
        public string? CPF { get; set; }
    }

    public class FuncionarioEditViewModel
    {
        public string? Nome { get; set; }
        public string? DataNascimento { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Funcao { get; set; }
    }
}