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
        }
    }
}
