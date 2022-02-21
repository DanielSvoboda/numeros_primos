using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace primos
{
    class numerosPrimos
    {
        static string linha = "________________________________________________________";

        static string opcoes;

        static Double entrada;
        static Double entrada2;

        static bool verCalculosCompletos;
        static bool verCalculos;

        static bool virgula;

        static bool apenasPrimos;

        static bool inteiro;


        static void Main()
        {
            while (0 == 0)
            {
                verCalculosCompletos = false;
                apenasPrimos = false;
                verCalculos = false;
                virgula = false;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(linha + "\n" +
                                  "Escolha uma das opções:         github.com/DanielSvoboda\n" +
                                  linha + "\n") ;
                Console.ResetColor();

                Console.Write("1- Verificar 1 número\n" +
                                  "2- Verificar 1 número (ver os calculos só até descobrir)\n" +
                                  "3- Verificar 1 número (ver os calculos completos)\n" +
                                  "4- Verificar de um número até outro\n" +
                                  "5- Verificar de um número até outro (ver apenas primos)\n" +
                                  linha + "\n" +
                                  "Escreva o número da opção: ");

                opcoes = Console.ReadLine();
                Console.Write(linha + "\n");
                Console.Clear();
                switch (opcoes)
                {
                    case "1":
                        Console.WriteLine("1- Verificar 1 número.");
                        Console.Write("Escreva o número: ");
                        entrada = Convert.ToDouble(Console.ReadLine());
                        verificaNumeroPrimo(entrada);
                        break;

                    case "2":
                        Console.WriteLine("2- Verificar 1 número (ver os calculos só até descobrir).");
                        Console.Write("Escreva o número: ");
                        entrada = Convert.ToDouble(Console.ReadLine());
                        verCalculos = true;
                        verificaNumeroPrimo(entrada);
                        break;

                    case "3":
                        Console.WriteLine("3- Verificar 1 número (ver os calculos completos.)");
                        Console.Write("Escreva o número: ");
                        entrada = Convert.ToDouble(Console.ReadLine());
                        verCalculos = true;
                        verCalculosCompletos = true;
                        verificaNumeroPrimo(entrada);

                        break;

                    case "4":
                        Console.WriteLine("4 - Verificar de um número até outro.");
                        Console.Write("Apartir do número: ");
                        entrada = Convert.ToDouble(Console.ReadLine());
                        Console.Write("     Até o número: ");
                        entrada2 = Convert.ToDouble(Console.ReadLine());
                        virgula = true;
                        apenasPrimos = false;
                        opcao_ate(entrada, entrada2);
                        break;

                    case "5":
                        Console.WriteLine("5- Verificar de um número até outro. (ver apenas primos).");
                        Console.Write("Apartir do número: ");
                        entrada = Convert.ToDouble(Console.ReadLine());
                        Console.Write("     Até o número: ");
                        entrada2 = Convert.ToDouble(Console.ReadLine());
                        virgula = true;
                        apenasPrimos = true;
                        opcao_ate(entrada, entrada2);
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Escreva apenas o número da opção!");
                        Console.ResetColor();
                        break;
                }
                Console.Write("\n\n\n");
            }
        }


        static public void opcao_ate(double inicio, double fim)
        {
            for (double i = inicio; i <= fim; i++)
            {
                entrada = i;
                verificaNumeroPrimo(entrada);
            }
        }


        static public void verificaNumeroPrimo(Double numero)
        {
            inteiro = false;

            for (Double i = 2; i < numero; i++)     //Loop do 2 até o numero-1
            {
                if (verCalculosCompletos == true)
                {
                    inteiros((numero / i).ToString(), i);
                }
                else
                {
                    if (inteiro == false)           //Parar de calcular se localizar um interno
                    {
                        inteiros((numero / i).ToString(), i);
                    }
                }
            }


            if (verCalculos == true)
            {
                Console.Write("\n");
                if (inteiro == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("O número " + numero + " NÃO é Primo");
                }
                else
                {
                    Console.Write("O número " + numero + " é Primo!!!");
                }
            }
            else
            {
                if (inteiro == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (apenasPrimos == false)
                    {
                        Console.Write(numero);
                        if (virgula == true)
                        {
                            Console.Write(",");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(numero);
                    if (virgula == true)
                    {
                        Console.Write(",");
                    }
                }
            }
            Console.ResetColor();
        }


        static public void verificaNumeroPrimo_ComCalculos(Double numero)
        {
            inteiro = false;

            for (Double i = 2; i < numero; i++)     //Loop do 2 até o numero-1
            {
                if (inteiro == false)               //Parar de calcular se localizar um interno
                {
                    inteiros_ComCalculos((numero / i).ToString(), i);
                }
            }

            if (inteiro == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write(numero);
            Console.ResetColor();
        }


        static public void inteiros(string numero, double i)
        {
            int saida;

            if (int.TryParse(numero, out saida))
            {
                inteiro = true;

                if (verCalculos == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(entrada + "/" + i + "\t = \t" + saida + "\t\t\tInteiro");
                }
            }
            else
            {
                if (verCalculos == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(entrada + "/" + i + "\t = \t" + numero.PadRight(16, '0') + "\tDecimal");
                }
            }
                Console.ResetColor();
        }


        static public void inteiros_ComCalculos(string numero, double i)
        {
            int saida;

            if (int.TryParse(numero, out saida))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(entrada + "/" + i + "\t = \t" + saida + "\t\t\tInteiro");
                inteiro = true;

                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(entrada + "/" + i + "\t = \t" + numero.PadRight(16, '0') + "\tDecimal");
            }
        }
    }
}