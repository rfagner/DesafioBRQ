﻿using System;
using System.Globalization;

namespace DesafioBRQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variáveis
            // Declaração de variáveis
            string nome;
            string sexo;
            int idade;
            double altura, peso;
            bool validaNome = false;
            bool validaSexo = false;
            bool validaIdade = false;

            #endregion

            // Apresentação do programa para o usuário
            Apresentacao();

            #region Entrada de Dados
            
            // Solicita o nome do usuário
            do
            {
                Console.Write("Por favor, digite o seu nome: ");
                nome = Console.ReadLine();
                // Valida o nome do usuário
                if (string.IsNullOrEmpty(nome))
                {                    
                    Console.WriteLine("\nEssa etapa é muito importante para te conhecermos e não pode ficar em branco!\n");
                    validaNome = false;
                }
                else
                {
                    validaNome = true;
                }
            } while (validaNome == false);

            // Solicita a informação do sexo do usuário
            
            do
            {
                Console.Write("\nQual é o seu sexo (M/F): ");
                sexo = Console.ReadLine();
                // Valida o campo sexo
                if (sexo.ToLower() == "m")
                {
                    sexo = "Masculino";
                    validaSexo = true;
                }
                else if (sexo.ToLower() == "f")
                {
                    sexo = "Feminino";
                    validaSexo = true;
                }
                else
                {                    
                    Console.WriteLine("\nInsira apenas 'M' para Masculino e 'F' para Feminino.");
                }
            } while (validaSexo == false);

            // Solicita a idade do usuário
            do
            {
                Console.Write("\nQual é a sua idade: ");
                int.TryParse(Console.ReadLine(), out idade);

                if (idade > 0 && idade <= 150)
                {
                    validaIdade = true;
                }
                else if (idade > 150)
                {
                    
                    Console.WriteLine("\nSegundo o Guinness Book, a pessoa mais velha do mundo morreu aos 119 anos de idade.");
                    Console.WriteLine($"\nCom certeza você não que tem {idade} anos!");
                    validaIdade = false;
                }
                else if (idade == 0)
                {
                    Console.WriteLine("\nDigite apenas núneros positivos!");
                    validaIdade = false;
                }
                else
                {
                    Console.WriteLine("\nNão existe ninguém com idade negativa!");
                }
            } while (validaIdade == false);

            // Solicita a altura em metros do usuário
            Console.Write("\nDigite a sua altura: ");
            double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura);

            // Solicita o peso do usuário
            Console.Write("\nDigite seu peso: ");
            double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso);

            #endregion

            double totalIMC = CalculoIMC(peso, altura);

            // Apresentação do Diagnóstico
            Diagnostico(nome, sexo, idade, altura, peso, totalIMC);
        }

        static void Apresentacao()
        {
            Console.WriteLine("****************************************************************");
            Console.WriteLine("************   Programa de Emagrecimento Saudável   ************");
            Console.WriteLine("*                                                              *");
            Console.WriteLine("*   Sistema que oferece um diagnóstico prévio baseado no IMC   *");
            Console.WriteLine("*                                                              *");
            Console.WriteLine("************    (IMC - Índice de Massa Corpórea)    ************");
            Console.WriteLine("****************************************************************\n");            
            Console.WriteLine("Para começar, vamos precisar de algumas informações.\n");            
            Console.WriteLine("Pode ficar tranquilo(a), trataremos os seus dados de acordo com a LGPD\n");            
            Console.WriteLine("Lei Geral de Proteção de Dados · Lei nº 13.853, de 8 de julho de 2019\n\n");
            
        }

        static void Diagnostico(string nome, string sexo, int idade, double altura, double peso, double totalIMC)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("DIAGNÓSTICO PRÉVIO\n");            
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Sexo: {sexo}");
            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Altura: {altura}");
            Console.WriteLine($"Peso: {peso}");
            Console.WriteLine($"Categoria: {Categoria(idade)}\n\n");            
            Console.WriteLine($"IMC Desejável: {ClassificacaoIMC(totalIMC)}\n");            
            Console.WriteLine($"Resultado IMC: {totalIMC.ToString("F2", CultureInfo.GetCultureInfo("pt-br"))}\n");            
            Console.WriteLine($"Riscos: {ClassificarRiscos(totalIMC)}\n");            
            Console.WriteLine($"Recomendação inicial: {RecomendacaoInicial(totalIMC)}\n");
            
            Console.ReadKey();            

        }

        // Função que retorna a categoria que recebe por parâmetro a idade do usuário
        static string Categoria(int idadePessoa)
        {
            
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


        static double CalculoIMC(double pesoPessoa, double alturaPessoa)
        {
            // Função que calcula o IMC e que recebe por parâmetro o peso e a idade do usuário
            double resultadoIMC = (pesoPessoa / (alturaPessoa * alturaPessoa));
            return resultadoIMC;
        }



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
                return "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar\n associadas ao baixo peso.";
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
                return "Inclua carboidratos simples em sua dieta, além de proteínas - indispensáveis para ganho de massa magra.\n Procure um profissional .";
            }

            else if (recomendacaoIMC >= 20 && recomendacaoIMC <= 24)
            {
                return "Mantenha uma dieta saudável e faça seus exames periódicos.";
            }

            else if (recomendacaoIMC >= 25 && recomendacaoIMC <= 29)
            {
                return "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. \nA ajuda de um profissional pode ser interessante";
            }

            else if (recomendacaoIMC >= 30 && recomendacaoIMC <= 35)
            {
                return "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista \ne um médico especialista (endócrino).";
            }

            else
            {
                return "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar, \num psicólogo e um médico especialista endócrino.";
            }
        }

    }
}
