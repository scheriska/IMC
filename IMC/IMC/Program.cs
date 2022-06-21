using System;
using System.Text.RegularExpressions;

namespace IMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inicio();

            Pessoa pessoa = new Pessoa();

            pessoa.Nome = PerguntarNome();

            pessoa.Sexo = PerguntarSexo();

            pessoa.Idade = PerguntarIdade();

            pessoa.Altura = PerguntarAltura();

            pessoa.Peso = PerguntarPeso();

            Apresentacao(pessoa);

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void Inicio()
        {
            //layout
            Console.BackgroundColor = ConsoleColor.Magenta; //muda a cor do fundo
            Console.ForegroundColor = ConsoleColor.White; //muda a cor das letras

            Console.WriteLine(String.Format("|{0,40}|", "**********************************************"));
            Console.WriteLine(String.Format("|{0,40}|", "*          Vamos calcular seu IMC ?!?        *"));
            Console.WriteLine(String.Format("|{0,40}|", "**********************************************"));

            Console.WriteLine("");
            Console.WriteLine("");
            Console.ResetColor(); //volta ao original
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Pergunta o nome e faz uma validação para verificar se os caracteres estão dentro 
        /// do esperado e enquanto não estiver "pede" para o usuario digitar novamente
        /// </summary>
        /// <returns></returns>
        public static string PerguntarNome()
        {
            bool validaNome = true;
            string nome = "";
            while (validaNome)
            {
                Console.WriteLine("Informe seu NOME: ");
                //validação só para letras e espaços                
                nome = Console.ReadLine();
                if (Funcoes.ValidaNome(nome))
                {
                    validaNome = false;
                    return nome;
                }
                Console.WriteLine("Nome invalido, tente novamente: ");

            }
            return nome;
        }

        public static string PerguntarSexo()
        {
            bool validadeSexo = true;
            while (validadeSexo)
            {
                Console.WriteLine("Informe seu SEXO: F para FEMININO e M para MASCULINO");
                //valida o que foi digitado
                string validaSexo = Funcoes.ValidaSexo(Console.ReadLine());
                if (validaSexo == "Erro")
                {
                    Console.WriteLine("Sexo informado invalido, tente novamente: ");
                }
                else
                {
                    validadeSexo = false;
                    return validaSexo;
                }
            }
            return "";
        }

        public static int PerguntarIdade()
        {
            bool validadeIdade = true;
            string idade = "";
            while (validadeIdade)
            {
                Console.WriteLine("Informe sua idade: (Padrão 000)");
                idade = Console.ReadLine();
                if (Funcoes.ValidaIdade(idade))
                {
                    validadeIdade = false;
                    return int.Parse(idade);
                }
                else
                {
                    Console.WriteLine("Idade invalida (Digite uma idade entre 1 e 130 anos) ");
                }
            }
            return 0;
        }

        public static double PerguntarAltura()
        {
            bool validadadeAltura = true;
            string altura = "";
            while (validadadeAltura)
            {
                Console.WriteLine("Informe sua altura em metros: (Padrão 0,00)");
                altura = Console.ReadLine();
                if (Funcoes.ValidaAltura(altura))
                {
                    validadadeAltura = false;
                    return double.Parse(altura);

                }
                else
                {
                    Console.WriteLine("Altura invalida (Digite uma altura entre 0,00 e 2,50 metros): ");
                }
            }
            return 0.00;
        }

        public static double PerguntarPeso()
        {
            bool validadePeso = true;
            string peso = "";
            while (validadePeso)
            {
                Console.WriteLine("Informe seu peso: (Padrão 00,00)");
                peso = Console.ReadLine();
                if (Funcoes.ValidaPeso(peso))
                {
                    validadePeso = false;
                    return double.Parse(peso);

                }
                else
                {
                    Console.WriteLine("Peso invalido, informe um peso entre 1,00 e 500,00 kilos");
                }
            }
            return 0.00;
        }

        public static void Apresentacao(Pessoa pessoa)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(String.Format("|{0,60}|", "*************************************************************"));
            Console.WriteLine(String.Format("|{0,60} |", "DIAGNÓSTICO PRÉVIO                                     "));
            Console.WriteLine(String.Format("|{0,60} |", " "));
            Console.WriteLine(String.Format("|{0,10}:{1,50}|", "Nome", pessoa.Nome));
            Console.WriteLine(String.Format("|{0,10}:{1,50}|", "Sexo", pessoa.Sexo));
            Console.WriteLine(String.Format("|{0,10}:{1,50}|", "Idade", pessoa.Idade));
            Console.WriteLine(String.Format("|{0,10}:{1,50}|", "Altura", pessoa.Altura.ToString("F")));
            Console.WriteLine(String.Format("|{0,10}:{1,50}|", "Peso", pessoa.Peso.ToString("F")));
            Console.WriteLine(String.Format("|{0,10}:{1,50}|", "Categoria", pessoa.Categoria[Funcoes.VerificarCategoria(pessoa.Idade)]));
            Console.WriteLine(String.Format("|{0,60} |", "   "));
            Console.WriteLine(String.Format("|{0,60} |", "   "));
            Console.WriteLine(String.Format("|{0,60} |", "IMC Desejável: entre 20 e 24                                "));
            Console.WriteLine(String.Format("|{0,60} |", " "));
            Console.WriteLine(String.Format("|{0,10}:{1,46}|", "Resultado IMC ", Funcoes.CalculoImc(pessoa.Peso, pessoa.Altura).ToString("F")));
            Console.WriteLine(String.Format("|{0,60} |", " "));
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(String.Format("|{0,10}:{1,50}|", "Riscos", Funcoes.MostrarRiscos(Funcoes.CalculoImc(pessoa.Peso, pessoa.Altura))));
            Console.WriteLine(String.Format("|{0,60} |", " "));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("|{0,10}:{1,50}|", "Recomendações", Funcoes.MostrarRecomendacoes(Funcoes.CalculoImc(pessoa.Peso, pessoa.Altura))));
            Console.WriteLine(String.Format("|{0,60}|", "*************************************************************"));
        }
    }
}
