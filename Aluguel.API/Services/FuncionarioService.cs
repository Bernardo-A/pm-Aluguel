using Aluguel.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluguel.API.Services
{
    public class FuncionarioService
    {
        public static FuncionarioViewModel GetFuncionario()
        {
            return new FuncionarioViewModel
            {
                Id = 0,
                Nome = "Joao Silva",
                DataNascimento = "01/01/2001",
                CPF = "201.902.910-36",
                Email = "joaosilva@email.com",
                Senha = "123456",
                Habilitado = true,
                Funcao = "Reparador"
            };
        }

    }
}
