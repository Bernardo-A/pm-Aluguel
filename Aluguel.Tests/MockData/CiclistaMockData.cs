using Aluguel.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Tests.MockData
{
    public class CiclistaMockData
    {
        public static CiclistaInsertViewModel GetCiclistaMockData()
        {
            return new CiclistaInsertViewModel
            {
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
                }
            };
        }

        public static CiclistaEditViewModel GetCiclistaEditMockData()
        {
            return new CiclistaEditViewModel
            {
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
                UrlFotoDocumento = "imagem.com"
            };
        }

        public static CiclistaViewModel GetCiclistaViewModelMockData()
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

        public static MeioDePagamentoViewModel GetMeiodeDePagamentoMockData()
        {
            return new MeioDePagamentoViewModel
            {
                NomeTitular = "Joao",
                Numero = "000000",
                Validade = "01/01/24",
                CVV = "000"
            };
        }

    }
}
