using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public class ClasseAuxiliarBD
    {
       

        public static Paciente getPacienteByNif(Double nif) {
            SqlConnection conn = new SqlConnection();
            SqlCommand com = new SqlCommand();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Paciente WHERE Nif =  " + nif, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            Paciente paciente = null;

            if (reader.Read())
            {
                paciente = new Paciente
                {
                    IdPaciente = (int)reader["IdPaciente"],
                    Nome = (string)reader["nome"],
                    DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                    Email = (string)reader["email"],
                    Contacto = Convert.ToDouble(reader["contacto"]),
                    Nif = Convert.ToDouble(reader["nif"]),
                    Profissao = (string)reader["Profissao"],
                    Rua = (string)reader["Rua"],
                    NumeroCasa = (int)reader["NumeroCasa"],
                    Andar = (string)reader["Andar"],
                    codPostalPrefixo = Convert.ToDouble(reader["codPostalPrefixo"]),
                    codPostalSufixo = Convert.ToDouble(reader["codPostalSufixo"]),
                    localidade = (string)reader["localidade"],
                    IdEnfermeiro = (int)reader["IdEnfermeiro"],
                };
            }

            conn.Close();
            return paciente;
        }
    }
}
