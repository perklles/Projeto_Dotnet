using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {

            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "0")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        // Add Aluno
                        Console.WriteLine("Informe o Nome do Aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a Nota do Aluno:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArithmeticException ("Valor da Nota deve ser Decimal!");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;

                    case "2":
                        // Listar Alunos
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                            Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            Console.WriteLine();
                            }
                        }
                        break;

                    case "3":
                        // Calcular Média Geral
                        decimal notaTotal = 0;
                        var nrAlunos  = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;

                        Conceito conceitoGeral;

                        if  (mediaGeral < 2 )
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4 )
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6 )
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8 )
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
                        Console.WriteLine();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a Opção Desejada:");
            Console.WriteLine("[1] - Inserir Novo Aluno.");
            Console.WriteLine("[2] - Listar Alunos.");
            Console.WriteLine("[3] - Listar Média Geral.");
            Console.WriteLine("[0] - Sair do Programa!");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
