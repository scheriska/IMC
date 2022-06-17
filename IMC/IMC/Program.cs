using System;
using System.Text.RegularExpressions;

namespace IMC
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(String.Format("|{0,50}|", "**********************************************"));
            Console.WriteLine(String.Format("|{0,50}|", "*          Vamos calcular seu IMC ?!?        *"));
            Console.WriteLine(String.Format("|{0,50}|", "**********************************************"));

            //Declaração da classe pessoa
            Pessoa pessoa = new Pessoa();

            //NOME
            bool validaNome = true;
            string nome = "";
            while (validaNome)
            {
                Console.WriteLine("Informe seu NOME: ");
                //validação só para letras e espaços,
                //com o Regex(expressão regular - procurar de forma mais expecifica um padrão (muito usado em validação de CEP, telefone etc....)
                nome = Console.ReadLine();
                if (Funcoes.ValidaNome(nome))
                {
                    pessoa.Nome = nome;
                    validaNome = false;
                }
                else
                {
                    Console.WriteLine("Nome invalido, tente novamente");
                }
            }

            //SEXO
            bool validadeSexo = true;
            while (validadeSexo)
            {
                Console.WriteLine("Informe seu SEXO: F para FEMININO e M para MASCULINO");
                //valida o que foi digita
                string validaSexo = Funcoes.ValidaSexo(Console.ReadLine());
                if (validaSexo == "Erro")
                {
                    Console.WriteLine("Sexo informado invalido, tente novamente: ");
                }
                else
                {
                    pessoa.Sexo = validaSexo;
                    validadeSexo = false;
                }
            }

            //IDADE
            bool validadeIdade = true;
            string idade = "";
            while (validadeIdade)
            {
                Console.WriteLine("Informe sua idade: (Padrão 000)");
                idade = Console.ReadLine();
                if (Funcoes.ValidaIdade(idade))
                {
                    pessoa.Idade = int.Parse(idade);
                    validadeIdade = false;
                }
                else
                {
                    Console.WriteLine("Idade invalida (Digite uma idade entre 1 e 130 anos) ");
                }
            }

            //ALTURA
            bool validadadeAltura = true;
            string altura = "";
            while (validadadeAltura)
            {
                Console.WriteLine("Informe sua altura em metros: (Padrão 0,00)");
                altura = Console.ReadLine();
                if (Funcoes.ValidaAltura(altura))
                {
                    pessoa.Altura = double.Parse(altura);
                    validadadeAltura = false;
                }
                else
                {
                    Console.WriteLine("Altura invalida (Digite uma altura entre 0,00 e 2,50 metros): ");
                }
            }

            //PESO
            bool validadePeso = true;
            string peso = "";
            while (validadePeso)
            {
                Console.WriteLine("Informe seu peso: (Padrão 00,00)");
                peso = Console.ReadLine();
                if (Funcoes.ValidaPeso(peso))
                {
                    pessoa.Peso = double.Parse(peso);
                    validadePeso = false;
                }
                else
                {
                    Console.WriteLine("Peso invalido, informe um peso entre 0,00 e 500,00 kilos");
                }
            }

            //verificar a categoria da pessoa
            string categoria = pessoa.Categoria[Funcoes.VerificarCategoria(pessoa.Idade)];



            //informações coletadas - começar os Calculos/Apresentação
            
            Console.WriteLine(String.Format("|{0,60} |", "____________________________________________________________"));
            Console.WriteLine(String.Format("|{0,60} |", "DIAGNÓSTICO PRÉVIO       "));
            Console.WriteLine(String.Format("|{0,60} |", " "));
            Console.WriteLine(String.Format("|{0,10} {1,50}|", " Nome:", pessoa.Nome));
            Console.WriteLine(String.Format("|{0,10} {1,50}|", " Sexo:", pessoa.Sexo));
            Console.WriteLine(String.Format("|{0,10} {1,50}|", " Idade:", pessoa.Idade));
            Console.WriteLine(String.Format("|{0,10} {1,50}|", " Altura:", pessoa.Altura));
            Console.WriteLine(String.Format("|{0,10} {1,50}|", " Peso:", pessoa.Peso));
            Console.WriteLine(String.Format("|{0,10} {1,50}|", " Categoria:", categoria));
            Console.WriteLine(String.Format("|{0,60} |", "   "));
            Console.WriteLine(String.Format("|{0,60} |", "   "));
            Console.WriteLine(String.Format("|{0,60} |", "IMC Desejável: entre 20 e 24 "));
            Console.WriteLine(String.Format("|{0,60} |", " "));
            Console.WriteLine(String.Format("|{0,10} {1,30}|", "Resultado IMC:", Funcoes.CalculoImc(pessoa.Peso, pessoa.Altura).ToString("F")));
            Console.WriteLine(String.Format("|{0,60} |", " "));
            Console.WriteLine(String.Format("|{0,10} {1,10}|", "Riscos:", Funcoes.MostrarRiscos(Funcoes.CalculoImc(pessoa.Peso, pessoa.Altura))));
            Console.WriteLine(String.Format("|{0,60} |", " "));
            Console.WriteLine(String.Format("|{0,10} {1,10}|", "Recomendações:", Funcoes.MostrarRecomendacoes(Funcoes.CalculoImc(pessoa.Peso, pessoa.Altura))));
            Console.WriteLine(String.Format("|{0,60} |", "____________________________________________________________"));


            ////apresentação dos dados
            //Console.WriteLine("---------------------------------------------------------------------------------");
            //Console.WriteLine("|                               DIAGNÓSTICO PRÉVIO                              |");
            //Console.WriteLine("|                                                                               |");
            //Console.WriteLine("| Nome: " + pessoa.Nome + "                                                                    |");
            //Console.WriteLine("| Sexo: " + pessoa.Sexo + "                                                                    |");
            //Console.WriteLine("| Idade: " + pessoa.Idade + "                                                                  |");
            //Console.WriteLine("| Altura: " + pessoa.Altura + "                                                                |");
            //Console.WriteLine("| Peso: " + pessoa.Peso + "                                                                    |");
            //Console.WriteLine("| Categoria: " + categoria + "                                                     |");
            //Console.WriteLine("|                                                                               | ");
            //Console.WriteLine("|                                                                               | ");
            //Console.WriteLine("| IMC Desejável: " + "                                                           |");
            //Console.WriteLine("|                                                                                |");
            //Console.WriteLine("| Resultado IMC: " + Funcoes.CalculoImc(pessoa.Peso, pessoa.Altura).ToString("F") + "                                                     |");
            //Console.WriteLine("|                                                                                |");
            //Console.WriteLine("| Riscos: " + Funcoes.MostrarRiscos(Funcoes.CalculoImc(pessoa.Peso, pessoa.Altura)));
            //Console.WriteLine("|                                                                                |");
            //Console.WriteLine("| Recomendações: " + Funcoes.MostrarRiscos(Funcoes.CalculoImc(pessoa.Peso, pessoa.Altura)));

        }


    }


}
