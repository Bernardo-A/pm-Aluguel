using Aluguel.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.Tests.MockData
{
    public class FuncionarioMockData
    {
        public static FuncionarioInsertViewModel GetFuncionarioMockData()
        {
            return new FuncionarioInsertViewModel
            {
                Nome = "Joao Silva",
                DataNascimento = "01/01/2001",
                CPF = "201.902.910-36",
                Email = "joaosilva@email.com",
                Senha = "123456",
                Funcao = "Reparador"
            };
        }

    }
}
