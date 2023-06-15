using Aluguel.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.API.Services
{
    public static class CiclistaService
    {
        public static CiclistaViewModel GetCiclista()
        {
            return new CiclistaViewModel
            {
                Id = 0,
                Nome = "Joao Silva",
                DataNascimento = "01/01/2001",
                CPF = "201.902.910-36",
                Passaporte = new PassaporteViewModel
                {
                    Numero = "11111111",
                    Pais = "Pais",
                    Validade = "01/01/2001"
                },
                Nacionalidade = "Brasileiro",
                Email = "joaosilva@email.com",
                UrlFotoDocumento = "imagem.com",
                Senha = "123456",
                MeioDePagamento = new MeioDePagamentoViewModel
                {
                    NomeTitular = "Joao Silva",
                    Numero = "4111111111111111",
                    Validade = "01/01/2001",
                    CVV = "999"
                },
                EmailConfirmado = false
            };
        }

    }
}
