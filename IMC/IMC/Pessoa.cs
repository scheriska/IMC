using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC
{
    internal class Pessoa
    {
        string nome;
        string sexo;
        int idade;
        double altura;
        double peso;
        string[] categoria = { "Infantil", "Juvenil", "Adulto", "Idoso"  };

        public Pessoa()
        {
        }

        public string Nome { get => nome; set => nome = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public int Idade { get => idade; set => idade = value; }
        public double Altura { get => altura; set => altura = value; }
        public double Peso { get => peso; set => peso = value; }
        public string[] Categoria { get => categoria; }
    }
}
