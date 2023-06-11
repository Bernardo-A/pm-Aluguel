namespace Aluguel.API.ViewModels
{
    public class CiclistaViewModel
    {
        public int id;
        public string nome;
        public string dataNascimento;
        public string cpf;

        public class Passaporte
        {
            public string numero;
            public string validade;
            public string pais;
        }

        public string nacionalidade;
        public string email;
        public string urlFotoDocumento;
        public string senha;

        public class MeioDePagamento
        {
            public string nomeTitular;
            public string numero;
            public string validade;
            public string cvv;
        }

        public bool emailConfirmado;
    }
    public class CiclistaInsertViewModel
    {
        public string nome;
        public string dataNascimento;
        public string cpf;

        public class Passaporte
        {
            public string numero;
            public string validade;
            public string pais;
        }

        public string nacionalidade;
        public string email;
        public string urlFotoDocumento;
        public string senha;

        public class MeioDePagamento
        {
            public string nomeTitular;
            public string numero;
            public string validade;
            public string cvv;
        }
    }
}