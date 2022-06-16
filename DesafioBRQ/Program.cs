using System;
using System.Globalization;

namespace DesafioBRQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaração de variáveis
            string nome;
            string sexo;
            int idade;
            double altura, peso;


            // Apresentação do programa para o usuário
            Console.WriteLine("****************************************************************");
            Console.WriteLine("************   Programa de Emagrecimento Saudável   ************");
            Console.WriteLine("*                                                              *");
            Console.WriteLine("*   Sistema que oferece um diagnóstico prévio baseado no IMC   *");
            Console.WriteLine("*                                                              *");
            Console.WriteLine("************    (IMC - Índice de Massa Corpórea)    ************");
            Console.WriteLine("****************************************************************");
            Console.WriteLine("");
            Console.WriteLine("Por favor, insira seus dados abaixo: ");
            Console.WriteLine("");

            // Entrada dos dados
            Console.Write("Qual é o seu nome: ");
            nome = Console.ReadLine();

            Console.Write("Qual é o seu sexo (M/F): ");
            sexo = Console.ReadLine();

            Console.Write("Qual é a sua idade: ");
            idade = int.Parse(Console.ReadLine());

            Console.Write("Digite a sua altura: ");
            altura = double.Parse(Console.ReadLine(), CultureInfo.GetCultureInfo("pt-br"));

            Console.Write("Digite seu peso: ");
            peso = double.Parse(Console.ReadLine(), CultureInfo.GetCultureInfo("pt-br"));
            double totalIMC = CalculoIMC(peso, altura);
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("DIAGNÓSTICO PRÉVIO");
            Console.WriteLine("");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Sexo: {sexo}");
            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Altura: {altura}");
            Console.WriteLine($"Peso: {peso}");
            Console.WriteLine($"Categoria: {Categoria(idade)}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"IMC Desejável: {ClassificacaoIMC(totalIMC)}");
            Console.WriteLine("");
            Console.WriteLine($"Resultado IMC: {totalIMC.ToString("F2", CultureInfo.GetCultureInfo("pt-br"))}");
            Console.WriteLine("");
            Console.WriteLine($"Riscos: {ClassificarRiscos(totalIMC)}");
            Console.WriteLine("");
            Console.WriteLine($"Recomendação inicial: {RecomendacaoInicial(totalIMC)}");
            Console.ReadKey();
        }

        static string Categoria(int idadePessoa)
        {
            // Função que retorna a categoria que recebe por parâmetro a idade do usuário
            if (idadePessoa < 12)
            {
                return "Infantil";
            }
            else if (idadePessoa >= 12 && idadePessoa <= 20)
            {
                return "Juvenil";
            }
            else if (idadePessoa >= 21 && idadePessoa <= 65)
            {
                return "Adulto";
            }
            else
            {
                return "Idoso";
            }
        }

        #region Calculo do IMC
        static double CalculoIMC(double pesoPessoa, double alturaPessoa)
        {
            // Função que calcula o IMC e que recebe por parâmetro o peso e a idade do usuário
            double resultadoIMC = (pesoPessoa / (alturaPessoa * alturaPessoa));
            return resultadoIMC;
        }

        #endregion

        static string ClassificacaoIMC(double classificacaoIMC)
        {
            // Função que retorna a classificação do IMC que recebe por parâmetro o total do IMC
            if (classificacaoIMC < 20)
            {
                return "abaixo de 20";
            }
            else if (classificacaoIMC >= 20 && classificacaoIMC <= 24)
            {
                return "entre 20 e 24 ";
            }
            else if (classificacaoIMC >= 25 && classificacaoIMC <= 29)
            {
                return "entre 25 e 29 ";
            }
            else if (classificacaoIMC >= 30 && classificacaoIMC <= 35)
            {
                return "entre 30 e 35 ";
            }
            else
            {
                return "acima de 35 ";
            }
        }

        static string ClassificarRiscos(double riscosIMC)
        {
            // Função que retorna a Classificação de Risco que recebe por parâmetro o total do IMC
            if (riscosIMC < 20)
            {
                return "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar associadas ao baixo peso.";
            }
            else if (riscosIMC >= 20 && riscosIMC <= 24)
            {
                return "Seu peso está ideal para suas referências.";
            }
            else if (riscosIMC >= 25 && riscosIMC <= 29)
            {
                return "Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares.";
            }
            else if (riscosIMC >= 30 && riscosIMC <= 35)
            {
                return "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade.";
            }
            else
            {
                return "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas.";
            }
        }

        static string RecomendacaoInicial(double recomendacaoIMC)
        {
            // Função que retorna a Recomendação Inicial que recebe por parâmetro o total do IMC
            if (recomendacaoIMC < 20)
            {
                return "Inclua carboidratos simples em sua dieta, além de proteínas - indispensáveis para ganho de massa magra. Procure um profissional .";
            }
            else if (recomendacaoIMC >= 20 && recomendacaoIMC <= 24)
            {
                return "Mantenha uma dieta saudável e faça seus exames periódicos.";
            }
            else if (recomendacaoIMC >= 25 && recomendacaoIMC <= 29)
            {
                return "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. A ajuda de um profissional pode ser interessante";
            }
            else if (recomendacaoIMC >= 30 && recomendacaoIMC <= 35)
            {
                return "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista e um médico especialista (endócrino).";
            }
            else
            {
                return "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar, um psicólogo e um médico especialista endócrino).";
            }
        }

    }
}
