﻿using System;
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
            Regex regex = new Regex(@"^[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ'\s]+$");
            return regex.IsMatch(nome);
        }

        public static string ValidaSexo(string sexo)
        {
            Regex regex = new Regex(@"^[F-Mf-m]$");
            bool result = regex.IsMatch(sexo);
            if (result)
            {
                if (sexo.ToLower() == "f" || sexo.ToLower() == "m")
                {
                    if (sexo.ToLower() == "f")
                    {
                        return "Feminino";
                    }
                    return "Masculino";
                }
                return "Erro";
            }
            else
            {
                return "Erro";
            }
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
            Regex regex = new Regex(@"^\d{0,1},{0,2}$");
            bool result = regex.IsMatch(altura);
            if (result)
            {
                if (double.Parse(altura) <= 2.30 && double.Parse(altura) > 0)
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
            if (imc < 20)
            {
                return "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar associadas ao baixo peso. ";
            }
            else if (imc > 20 && imc < 24)
            {
                return "Seu peso está ideal para suas referências.";
            }
            else if (imc > 25 && imc < 29)
            {
                return "Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares.";
            }
            else if (imc > 30 && imc < 35)
            {
                return "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade.";
            }
            else
            {
                return "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas.";
            }
        }

        public static string MostrarRecomendacoes(double imc)
        {
            if (imc < 20)
            {
                return "Inclua carboidratos simples em sua dieta, além de proteínas - indispensáveis para ganho de massa magra. Procure um profissional.";
            }
            else if (imc > 20 && imc < 24)
            {
                return "Mantenha uma dieta saudável e faça seus exames periódicos.";
            }
            else if (imc > 25 && imc < 29)
            {
                return "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. A ajuda de um profissional pode ser interessante";
            }
            else if (imc > 30 && imc < 35)
            {
                return "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista e um médico especialista(endócrino).";
            }
            else
            {
                return "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar, um psicólogo e um médico especialista(endócrino).";
            }
        }
    }
}