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

            SqlCommand cmd = new SqlCommand("select * from Paciente p LEFT JOIN Profissao prof ON p.IdProfissao = prof.IdProfissao WHERE Nif =  " + nif, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            Paciente paciente = null;

            if (reader.Read())
            {
                paciente = new Paciente
                {
                    IdPaciente = (int)reader["IdPaciente"],
                    Nome = (string)reader["nome"],
                    DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                    Email = ((reader["email"] == DBNull.Value) ? "" : (string)reader["email"]),
                    Contacto = Convert.ToDouble(reader["contacto"]),
                    Nif = Convert.ToInt32(reader["nif"]),
                    Profissao = ((reader["nomeProfissao"] == DBNull.Value) ? "" : (string)reader["nomeProfissao"]),
                    Rua = (string)reader["Rua"],
                    NumeroCasa = ((reader["NumeroCasa"] == DBNull.Value) ? null : (int?)reader["NumeroCasa"]),
                    Andar = ((reader["Andar"] == DBNull.Value) ? "" : (string)reader["Andar"]),
                    codigoPostal = (reader["codPostalPrefixo"]) + "-" + (reader["codPostalSufixo"]),
                    bairroLocal = ((reader["bairroLocal"] == DBNull.Value) ? "" : (string)reader["bairroLocal"]),
                    designacao = ((reader["designacao"] == DBNull.Value) ? "" : (string)reader["designacao"]),


                    //codPostalPrefixo = Convert.ToDouble(reader["codPostalPrefixo"]),
                    //codPostalSufixo = Convert.ToDouble(reader["codPostalSufixo"]),
                    localidade = (string)reader["localidade"],
                    IdEnfermeiro = (int)reader["IdEnfermeiro"],
                    Acordo = (string)reader["Acordo"],
                    NomeSeguradora = ((reader["NomeSeguradora"] == DBNull.Value) ? "" : (string)reader["NomeSeguradora"]),
                    NumeroApoliceSeguradora = ((reader["NumeroApoliceSeguradora"] == DBNull.Value) ? 0 : (int)reader["NumeroApoliceSeguradora"]),
                    NomeSubsistema = ((reader["NomeSubsistema"] == DBNull.Value) ? "" : (string)reader["NomeSubsistema"]),
                    NumeroSubsistema = ((reader["NumeroSubsistema"] == DBNull.Value) ? 0 : (int)reader["NumeroSubsistema"]),
                    NumeroSNS = ((reader["NumeroSNS"] == DBNull.Value) ? 0 : (int)reader["NumeroSNS"]),
                    Sexo = (string)reader["Sexo"],
                    PlanoVacinacao = (string)reader["PlanoVacinacao"]
                };
            }

            conn.Close();
            return paciente;
        }
    }
}
