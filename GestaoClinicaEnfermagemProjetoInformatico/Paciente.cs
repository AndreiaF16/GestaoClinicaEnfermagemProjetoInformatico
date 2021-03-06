﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
   public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public double Contacto { get; set; }
        public int Nif { get; set; }
        public string Profissao { get; set; }
        public string Rua { get; set; }
        public int? NumeroCasa { get; set; }
        public string Andar { get; set; }
        public string localidade { get; set; }
        public string bairroLocal { get; set; }

        public string codigoPostal { get; set; }
        public string designacao { get; set; }

        public int IdEnfermeiro { get; set; }
        public string Acordo { get; set; }
        public string NomeSeguradora { get; set; }
        public int? NumeroApoliceSeguradora { get; set; }
        public string NomeSubsistema { get; set; }
        public int? NumeroSubsistema { get; set; }
        public int? NumeroSNS { get; set; }
        public string Sexo { get; set; }
        public string PlanoVacinacao { get; set; }


    }
}
