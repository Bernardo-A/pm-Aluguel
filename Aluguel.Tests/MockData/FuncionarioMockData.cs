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
        public static FuncionarioInsertViewModel GetFuncionarioInsertMockData()
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
        public static FuncionarioViewModel GetFuncionarioViewModelMockData()
        {
            return new FuncionarioViewModel
            {
                Id = 0,
                Nome = "Joao Silva",
                DataNascimento = "01/01/2001",
                CPF = "201.902.910-36",
                Email = "joaosilva@email.com",
                Senha = "123456",
                Funcao = "Reparador",
                Habilitado = true,
            };
        }

        public static FuncionarioEditViewModel GetFuncionarioEditViewModelMockData()
        {
            return new FuncionarioEditViewModel
            {
                Nome = "Joao Silva",
                DataNascimento = "01/01/2001",
                Email = "joaosilva@email.com",
                Senha = "123456",
                Funcao = "Reparador",
            };
        }
    }
}
