using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IMC
{
    internal class Funcoes
    {
        public static bool ValidaNome(string nome)
        {
            //Validação com o Regex(expressão regular - procurar de forma mais expecifica um padrão
            //(muito usado em validação de CEP, telefone, email etc....)
            Regex regex = new Regex(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$");
            return regex.IsMatch(nome);
        }

        public static string ValidaSexo(string sexo)
        {
            Regex regex = new Regex(@"^[F-Mf-m]$");
            bool result = regex.IsMatch(sexo);
            if (result)
            {
                if (sexo.ToLower() == "f")
                {
                    return "Feminino";
                }
                if (sexo.ToLower() == "m")
                {
                    return "Masculino";
                }
                
            }
            return "Erro";
        }

        public static bool ValidaIdade(string idade)
        {
            Regex regex = new Regex(@"^\d{0,3}$");
            bool result= regex.IsMatch(idade);
            if (result)
            {
                if (int.Parse(idade) <= 130 && int.Parse(idade) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ValidaAltura(string altura)
        {
            Regex regex = new Regex(@"^\d{0,1},\d{0,2}$");
            bool result = regex.IsMatch(altura);
            if (result)
            {
                if (double.Parse(altura) <= 2.50 && double.Parse(altura) > 0)
                {

                    return true;
                }
            }
            return false;
        }

        public static bool ValidaPeso(string peso)
        {
            Regex r = new Regex(@"^\d{0,3},\d{0,2}$");
            bool result = r.IsMatch(peso);
            if (result)
            {
                if (double.Parse(peso) <= 500 && double.Parse(peso) >= 1)
                {
                    return true;
                }
            }
            return false;
        }

        public static double CalculoImc(double peso, double altura)
        {
            double imc = peso / (altura * altura);
            return imc;
        }

        /// <summary>
        /// Retorna o indice para o campo categoria
        /// </summary>
        /// <param name="idade">idade</param>
        /// <returns></returns>
        public static int VerificarCategoria(int idade)
        {            
            if (idade <= 12)
            {
                return 0;
            }
            else if (idade >= 13 && idade <= 20)
            {
                return 1;
            }
            else if (idade >= 21 && idade <= 65)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public static string MostrarRiscos(double imc)
        {
            if (imc <= 19.99)
            {
                return "Muitas complicações de saúde como doenças '\n' pulmonares e cardiovasculares podem estar '\n' associadas ao baixo peso. ";
            }
            else if (imc >= 20.00 && imc <= 24.99)
            {
                return "Seu peso está ideal para suas referências.";
            }
            else if (imc >= 25.00 && imc <= 29.99)
            {
                return "Aumento de peso apresenta risco moderado '\n' para outras doenças crônicas '\n' e cardiovasculares.";
            }
            else if (imc >= 30.00 && imc <= 35.99)
            {
                return "Quem tem obesidade vai estar mais '\n' exposto a doenças graves e ao risco de mortalidade.";
            }
            else
            {
                return "O obeso mórbido vive menos, tem alto risco de '\n' mortalidade geral por diversas causas.";
            }
        }

        public static string MostrarRecomendacoes(double imc)
        {
            if (imc <= 19.99)
            {
                return "Inclua carboidratos simples em sua dieta, '\n' além de proteínas - indispensáveis para ganho '\n' de massa magra. Procure um profissional.";
            }
            else if (imc >= 20.00 && imc <= 24.99)
            {
                return "Mantenha uma dieta saudável e '\n' faça seus exames periódicos.";
            }
            else if (imc >= 25.00 && imc <= 29.99)
            {
                return "Adote um tratamento baseado em dieta '\n' balanceada, exercício físico e medicação. '\n' A ajuda de um profissional pode ser interessante";
            }
            else if (imc >= 30.00 && imc <= 35.99)
            {
                return "Adote uma dieta alimentar rigorosa, com o acompanhamento de '\n' um nutricionista e um médico especialista(endócrino).";
            }
            else
            {
                return "Procure com urgência o acompanhamento de'\n' um nutricionista para realizar reeducação alimentar, um psicólogo e '\n' um médico especialista(endócrino).";
            }
        }
    }
}
