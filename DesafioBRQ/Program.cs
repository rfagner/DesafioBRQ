using System;
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
            #endregion

            // Chamada da função que apresenta o programa para o usuário
            Apresentacao();

            #region Entrada de Dados
            // Solicita o nome do usuário
            Console.Write("Digite o seu nome: ");
            nome = Console.ReadLine();

            // Validação que verifica se a string especificada é null ou consiste somente de espaço em branco
            // Isso garante que o campo "Nome" não pode estar em branco
            while (string.IsNullOrWhiteSpace(nome))
            {
                // Mensagem que será retornada ao usuário enquanto o teste condicional for igual a verdadeiro (true) 
                Console.Clear(); // Para evitar que a tela fique poluída quando o usuário digitar dados inválidos
                Console.WriteLine("\nEssa etapa é muito importante para te conhecermos e não pode ficar em branco!\n");
                Console.Write("\nPor favor, digite o seu nome: ");
                nome = Console.ReadLine();
            }


            // Solicita a informação do sexo da pessoa
            Console.Write("\nQual é o seu sexo (M/F): ");
            sexo = Console.ReadLine();
            // Após receber o sexo da pessoa o teste condicional verifica se é um sexo válido.        
            while (sexo.ToLower() != "m" || sexo.ToLower() != "f")
            {

                if (sexo.ToLower() == "m") // Verifica a entrada e converte a string para minúsculo
                {
                    sexo = "Masculino";
                    break; // Comando que interrompe o laço assim que a condição desejada é atendida
                }
                if (sexo.ToLower() == "f")
                {
                    sexo = "Feminino";
                    break;
                }
                // Mensagem que será retornada ao usuário enquanto o teste condicional for igual a verdadeiro (true) 
                Console.Clear(); // Para evitar que a tela fique poluída quando o usuário digitar dados inválidos
                Console.WriteLine("\nDados inválidos. Apenas são aceitos os caracteres 'M' para 'Masculino' e 'F' para 'Feminino'.");
                Console.Write("\nQual é o seu sexo (M/F): ");
                sexo = Console.ReadLine();
            }


            do
            {
                // Solicita a idade da pessoa e verifica se é um valor inteiro válido (positivo e sem casas decimais).
                Console.Write("\nDigite sua idade (Ex. 28): ");
                if (int.TryParse(Console.ReadLine(), out idade))
                {
                    // Verifica se o valor é negativo considerando o zero
                    if (idade <= 0)
                    {
                        Console.WriteLine("\nNão existe pessoas com idade negativas!");
                    }
                    if (idade > 119) // Verifica se o valor é superior ao valor do teste condicional
                    {
                        Console.WriteLine($"\nCom certeza você não tem {idade} anos!");
                        Console.WriteLine("A pessoa mais velha do mundo, era a japonesa Kane Tanaka, de 119 anos.");
                        Console.WriteLine("##Fonte Guinnes Book");
                    }
                }
                else
                {
                    // Mesagem que será retornada ao usuário caso os dados sejam inválidos
                    Console.Clear(); // Para evitar que a tela fique poluída quando o usuário digitar dados inválidos
                    Console.WriteLine("\nDados inválidos! Digite apenas números inteiros e sem casas decimais!");
                }

            } while (idade <= 0 || idade > 119); // O programa só sairá do laço quando a condição for atendida



            do
            {
                // Solicita a altura da pessoa

                Console.Write("\nDigite a sua altura (Ex. 1,70): ");
                // Condição que verifica se o valor contém ponto ou vírgula e retorna um double para a variável altura
                // e verifica se a altura é válida. 
                if (double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out altura))
                {
                    // Verifica se o valor é negativo considerando o zero
                    if (altura <= 0)
                    {
                        Console.WriteLine("\nNão existe pessoas com altura negativa!");
                    }
                    if (altura > 2.51) // Verifica se o valor é superior ao valor do teste condicional
                    {
                        Console.WriteLine($"\nCom certeza você não tem {altura} de altura!");
                        Console.WriteLine("O homem vivo mais alto do mundo, Sultan Kösen, da Túrquia, tem 2,51 metros de altura.");
                        Console.WriteLine("##Fonte Guinnes Book");
                    }
                }
                else
                {
                    // Caso seja um valor negativo, letra ou espaço em branco será retornado ao usuário que digite apenas números naturais
                    Console.Clear(); // Para evitar que a tela fique poluída quando o usuário digitar dados inválidos
                    Console.WriteLine("\nDigite apenas números naturais!");
                }
            } while (altura <= 0 || altura > 2.51); // O programa só sairá do laço quando a condição for atendida

            // Solicita o peso do usuário
            do
            {
                // Solicita o peso do usuário
                Console.Write("\nDigite seu peso (Ex. 54,5): ");
                // Condição que verifica se o valor contém ponto ou vírgula e retorna um double para a variável peso
                // e verifica se o peso é válido. 
                if (double.TryParse(Console.ReadLine().Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out peso))
                {
                    // Verifica se o valor é negativo considerando o zero
                    if (peso <= 0)
                    {
                        Console.WriteLine("\nNão existe pessoas com peso negativo!");
                    }
                    if (peso > 595.0) // Verifica se o valor é superior ao valor do teste condicional
                    {
                        Console.WriteLine($"\nCom certeza você não tem {peso} kg!");
                        Console.WriteLine("O homem mais pesado do mundo - o mexicano Juan Pedro Franco - chegou a ter 595 quilos");
                        Console.WriteLine("##Fonte Guinnes Book");
                    }
                }
                else
                {
                    // Caso seja um valor negativo, letra ou espaço em branco será retornado ao usuário que digite apenas números naturais
                    Console.Clear(); // Para evitar que a tela fique poluída quando o usuário digitar dados inválidos
                    Console.WriteLine("\nDados inválidos. Digite apenas números naturais!");
                }
            } while (peso <= 0 || peso > 595.0); // O programa só sairá do laço quando a condição for atendida
            #endregion

            // Variável que recebe o resultado da Função do Cálculo do IMC
            // A mesma será usada para operações matemáticas em outras funções
            double totalIMC = CalculoIMC(peso, altura);

            // Apresentação do resultado do Diagnóstico
            Diagnostico(nome, sexo, idade, altura, peso, totalIMC);
        }


        /// <summary>
        /// Função que exibe a tela inicial do programa
        /// </summary>
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

        }

        /// <summary>
        /// Função que exibe a tela de Diagóstico Prévio da pessoa com base no IMC 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="sexo"></param>
        /// <param name="idade"></param>
        /// <param name="altura"></param>
        /// <param name="peso"></param>
        /// <param name="totalIMC"></param>
        static void Diagnostico(string nome, string sexo, int idade, double altura, double peso, double totalIMC)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("DIAGNÓSTICO PRÉVIO\n");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Sexo: {sexo}");
            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Altura: {altura.ToString("F2")}");
            Console.WriteLine($"Peso: {peso}");
            Console.WriteLine($"Categoria: {Categoria(idade)}\n\n");
            Console.WriteLine($"IMC Desejável: {ClassificacaoIMC(totalIMC)}\n");
            Console.WriteLine($"Resultado IMC: {totalIMC.ToString("F2", CultureInfo.GetCultureInfo("pt-br"))}\n");
            Console.WriteLine($"Riscos: {ClassificacaoRiscos(totalIMC)}\n");
            Console.WriteLine($"Recomendação inicial: {RecomendacaoInicial(totalIMC)}\n");
            Console.WriteLine("****************************************************************\n");
            Console.WriteLine("Obrigado por utilizar o nosso sistema! A BRQ agradece pela preferência.\n");
            Console.WriteLine("Pressione uma tecla para sair. Até mais!");
            Console.ReadKey(); // Aguarda o usuário pressionar uma tecla e encerra o programa.

        }


        /// <summary>
        /// Função que recebe por parâmetro a "idade" da pessoa e classifica a sua categoria
        /// </summary>
        /// <param name="idadePessoa"></param>
        /// <returns>Retorna uma string com a categoria da pessoa de acorco com a sua idade</returns>
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

        /// <summary>
        /// Recebe os parâmetros "peso" e "altura" da pessoa para realizar o cálculo do IMC
        /// </summary>
        /// <param name="pesoPessoa"></param>
        /// <param name="alturaPessoa"></param>
        /// <returns>Retorna o resultado do IMC da pessoa</returns>
        static double CalculoIMC(double pesoPessoa, double alturaPessoa)
        {
            // Função que calcula o IMC e que recebe por parâmetro o peso e a idade do usuário
            double resultadoIMC = (pesoPessoa / (alturaPessoa * alturaPessoa));
            return resultadoIMC;
        }


        /// <summary>
        /// Função que recebe por parâmetro o total do IMC da pessoa para verificar em que classificação ela se encontra.
        /// </summary>
        /// <param name="classificacaoIMC"></param>
        /// <returns>Retorna a classificação da pessoa de acordo com o resultado do IMC</returns>
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

        /// <summary>
        /// Função que recebe por parâmetro o total do IMC da pessoa para verificar em que classificação de riscos ela se encontra.
        /// </summary>
        /// <param name="riscosIMC"></param>
        /// <returns>Retorna uma string que classifica possíveis riscos à saúde da pessoa de acordo com o resultado do IMC</returns>
        static string ClassificacaoRiscos(double riscosIMC)
        {

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

        /// <summary>
        /// Função que recebe por parâmetro o total do IMC da pessoa e verifica em qual risco a pessoa se encontra e calcula uma possível recomendação de acordo com o resultado do IMC.
        /// </summary>
        /// <param name="recomendacaoIMC"></param>
        /// <returns>Retorna uma string com uma possível recomendação de acordo com o resultado do IMC da pessoa</returns>
        static string RecomendacaoInicial(double recomendacaoIMC)
        {

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
