using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace GestorPasantias
{
    internal class Queries
    {
        static NpgsqlCommand command;
        static NpgsqlDataReader dr;

        public static NpgsqlDataReader selectAll(string query)
        {
            command = new NpgsqlCommand
            {
                Connection = Connection.connect(),
                CommandText = query
            };
            dr = command.ExecuteReader();
            return dr;
        }

        public static int insertIntoPasantias(int cipasante, int citacad, int citind, int idempresa, string fcontrat, string finicio, string fculm)
        {
            int rowsAffected;
            command = new NpgsqlCommand("INSERT INTO pasantia (ci_pasante, ci_tutor_acad, ci_tutor_ind, id_empresa, fe_contratacion, fe_inicio, fe_culminacion) VALUES (@ci_pasante, @ci_tutor_acad, @ci_tutor_ind, @id_empresa, TO_DATE(@fe_contratacion, 'YYYY-MM-DD'), TO_DATE(@fe_inicio, 'YYYY-MM-DD'), TO_DATE(@fe_culminacion, 'YYYY-MM-DD'))", Connection.connect());
            command.Parameters.AddWithValue("@ci_pasante", cipasante);
            command.Parameters.AddWithValue("@ci_tutor_acad", citacad);
            command.Parameters.AddWithValue("@ci_tutor_ind", citind);
            command.Parameters.AddWithValue("@id_empresa", idempresa);
            command.Parameters.AddWithValue("@fe_contratacion", fcontrat);
            command.Parameters.AddWithValue("@fe_inicio", finicio);
            command.Parameters.AddWithValue("@fe_culminacion", fculm);
            try{
                rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }catch(Exception e){
                Console.WriteLine(e.ToString());
                return 0;
            }
        }

        public static NpgsqlDataReader drEmpresas(string no_empresa)
        {
            command = new NpgsqlCommand
            {
                Connection = Connection.connect(),
                CommandText = "SELECT * FROM empresa WHERE no_empresa ILIKE '%' || @no_empresa || '%'"
            };
            command.Parameters.AddWithValue("@no_empresa", no_empresa);
            dr = command.ExecuteReader();
            return dr;
        }
        public static NpgsqlDataReader drTutores(int ci_tutor, string no_tutor, string ap_tutor, int ti_tutor)
        {
            ci_tutor = (ci_tutor == 0) ? -1 : ci_tutor;
            no_tutor = (string.IsNullOrEmpty(no_tutor)) ? "" : no_tutor;
            ap_tutor = (string.IsNullOrEmpty(ap_tutor)) ? "" : ap_tutor;
            ti_tutor = (ti_tutor == 0) ? -1 : ti_tutor;

            command = new NpgsqlCommand
            {
                Connection = Connection.connect(),
                CommandText = "SELECT * FROM tutor WHERE (-1 = @ci_tutor OR ci_tutor = @ci_tutor) AND ('' ILIKE '%' || @no_tutor || '%' OR no_tutor ILIKE '%' || @no_tutor || '%') AND ('' ILIKE '%' || @ap_tutor || '%' OR ap_tutor ILIKE '%' || @ap_tutor || '%') AND (-1 = @ti_tutor OR ti_tutor = @ti_tutor)"
            };
            
            command.Parameters.AddWithValue("@ci_tutor", ci_tutor);
            command.Parameters.AddWithValue("@no_tutor", no_tutor);
            command.Parameters.AddWithValue("@ap_tutor", ap_tutor);
            command.Parameters.AddWithValue("ti_tutor", ti_tutor);

            dr = command.ExecuteReader();
            return dr;
        }
        public static NpgsqlDataReader drPasantes(int ci_pasante, string no_pasante, string ap_pasante)
        {
            ci_pasante = (ci_pasante == 0) ? -1 : ci_pasante;
            no_pasante = (string.IsNullOrEmpty(no_pasante)) ? "" : no_pasante;
            ap_pasante = (string.IsNullOrEmpty(ap_pasante)) ? "" : ap_pasante;

            command = new NpgsqlCommand()
            {
                Connection = Connection.connect(),
                CommandText = "SELECT * FROM pasante WHERE (-1 = @ci_pasante OR ci_pasante = @ci_pasante) AND ('' ILIKE '%' || @no_pasante || '%' OR no_pasante ILIKE '%' || @no_pasante || '%') AND ('' ILIKE '%' || @ap_pasante || '%' OR ap_pasante ILIKE '%' || @ap_pasante || '%')"
            };

            command.Parameters.AddWithValue("@ci_pasante", ci_pasante);
            command.Parameters.AddWithValue("@no_pasante", no_pasante);
            command.Parameters.AddWithValue("@ap_pasante", ap_pasante);

            dr = command.ExecuteReader();
            return dr;
        }

        public static NpgsqlDataReader drPasantias(int ci_pasante, int ci_tacad, int ci_tind, int id_empresa, string fe_contrat, string fe_ini, string fe_culm)
        {
            ci_pasante = (ci_pasante == 0) ? -1 : ci_pasante;
            ci_tacad = (ci_tacad == 0) ? -1 : ci_tacad;
            ci_tind = (ci_tind == 0) ? -1 : ci_tind;
            id_empresa = (id_empresa == 0) ? -1 : id_empresa;
            fe_contrat = (fe_contrat == DateTime.Now.ToString("yyyy-MM-dd")) ? "4713-01-01" : fe_contrat;
            fe_ini = (fe_ini == DateTime.Now.ToString("yyyy-MM-dd")) ? "4713-01-01" : fe_ini;
            fe_culm = (fe_culm == DateTime.Now.ToString("yyyy-MM-dd")) ? "4713-01-01" : fe_culm;

            command = new NpgsqlCommand()
            {
                Connection = Connection.connect(),
                CommandText = "SELECT * FROM pasantia WHERE (-1 = @ci_pasante OR ci_pasante = @ci_pasante) AND (-1 = @ci_tutor_acad OR ci_tutor_acad = @ci_tutor_acad) AND (-1 = @ci_tutor_ind OR ci_tutor_ind = @ci_tutor_ind) AND (-1 = @id_empresa OR id_empresa = @id_empresa) AND ('4713-01-01' = TO_DATE(@fe_contratacion, 'YYYY-MM-DD') OR fe_contratacion = TO_DATE(@fe_contratacion, 'YYYY-MM-DD')) AND ('4713-01-01' = TO_DATE(@fe_inicio, 'YYYY-MM-DD') OR fe_inicio = TO_DATE(@fe_inicio, 'YYYY-MM-DD')) AND ('4713-01-01' = TO_DATE(@fe_culminacion, 'YYYY-MM-DD') OR fe_culminacion = TO_DATE(@fe_culminacion, 'YYYY-MM-DD'))"
            };

            command.Parameters.AddWithValue("@ci_pasante", ci_pasante);
            command.Parameters.AddWithValue("@ci_tutor_acad", ci_tacad);
            command.Parameters.AddWithValue("@ci_tutor_ind", ci_tind);
            command.Parameters.AddWithValue("@id_empresa", id_empresa);
            command.Parameters.AddWithValue("@fe_contratacion", fe_contrat);
            command.Parameters.AddWithValue("@fe_inicio", fe_ini);
            command.Parameters.AddWithValue("@fe_culminacion", fe_culm);

            dr = command.ExecuteReader();
            return dr;
        }

        public static int deletePasantia(int idPasantia)
        {
            int rowsAffected;

            command = new NpgsqlCommand("DELETE FROM pasantia WHERE id_pasantia = @id_pasantia", Connection.connect());
            command.Parameters.AddWithValue("@id_pasantia", idPasantia);
            try{
                rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }catch (Exception e){
                Console.WriteLine(e.ToString());
                return 0;
            }
        }

        public static int deletePasante(int ciPasante)
        {
            int rowsAffected;

            command = new NpgsqlCommand("DELETE FROM pasante WHERE ci_pasante = @id_pasante", Connection.connect());
            command.Parameters.AddWithValue("@id_pasante", ciPasante);
            try{
                rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }catch (Exception e){
                Console.WriteLine(e.ToString());
                return 0;
            }
        }

        public static int deleteTutor(int ciTutor)
        {
            int rowsAffected;

            command = new NpgsqlCommand("DELETE FROM tutor WHERE ci_tutor = @ci_tutor", Connection.connect());
            command.Parameters.AddWithValue("@ci_tutor", ciTutor);
            try{
                rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }catch (Exception e){
                Console.WriteLine(e.ToString());
                return 0;
            }
        }

        public static int deleteEmpresa(int idEmpresa)
        {
            int rowsAffected;

            command = new NpgsqlCommand("DELETE FROM empresa WHERE id_empresa = @id_empresa", Connection.connect());
            command.Parameters.AddWithValue("@id_empresa", idEmpresa);
            try{
                rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }catch (Exception e){
                Console.WriteLine(e.ToString());
                return 0;
            }
        }

        public static int updateEmpresa(string noEmpresa, int idEmpresa)
        {
            int rowsAffected;
            command = new NpgsqlCommand("UPDATE empresa SET no_empresa = @no_empresa WHERE id_empresa = @id_empresa", Connection.connect());
            command.Parameters.AddWithValue("@no_empresa", noEmpresa);
            command.Parameters.AddWithValue("@id_empresa", idEmpresa);
            try{
                rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }catch (Exception e){
                Console.WriteLine(e.ToString());
                return 0;
            }
        }

        public static int updatePasante(string noPasante, string apPasante, int ciPasante)
        {
            int rowsAffected;
            command = new NpgsqlCommand("UPDATE pasante SET no_pasante = @no_pasante, ap_pasante = @ap_pasante WHERE ci_pasante = @ci_pasante", Connection.connect());
            command.Parameters.AddWithValue("@no_pasante", noPasante);
            command.Parameters.AddWithValue("@ap_pasante", apPasante);
            command.Parameters.AddWithValue("@ci_pasante", ciPasante);
            try{
                rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }catch (Exception e){
                Console.WriteLine(e.ToString());
                return 0;
            }
        }

        public static int updateTutores(string noTutor, string apTutor, int tipoTutor, int ciTutor)
        {
            int rowsAffected;
            command = new NpgsqlCommand("UPDATE tutor SET no_tutor = @no_tutor, ap_tutor = @ap_tutor, ti_tutor = @tipo_tutor WHERE ci_tutor = @ci_tutor", Connection.connect());
            command.Parameters.AddWithValue("@no_tutor", noTutor);
            command.Parameters.AddWithValue("@ap_tutor", apTutor);
            command.Parameters.AddWithValue("@tipo_tutor", tipoTutor);
            command.Parameters.AddWithValue("@ci_tutor", ciTutor);
            try
            {
                rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 0;
            }
        }

        public static int updatePasantias(int ciPasante, int ciTutorA, int ciTutorI, int idEmpresa, string feContra, string feIni, string feCulm, int idPasantia)
        {
            int rowsAffected;
            command = new NpgsqlCommand("UPDATE pasantia SET ci_pasante = @ci_pasante, ci_tutor_acad = @ci_tacad, ci_tutor_ind = @ci_tind, id_empresa = @id_empresa, fe_contratacion = TO_DATE(@fe_contr, 'YYYY-MM-DD'), fe_inicio = TO_DATE(@fe_inicio, 'YYYY-MM-DD'), fe_culminacion = TO_DATE(@fe_culm, 'YYYY-MM-DD') WHERE id_pasantia = @id_pasantia", Connection.connect());
            command.Parameters.AddWithValue("@ci_pasante", ciPasante);
            command.Parameters.AddWithValue("@ci_tacad", ciTutorA);
            command.Parameters.AddWithValue("@ci_tind", ciTutorI);
            command.Parameters.AddWithValue("@id_empresa", idEmpresa);
            command.Parameters.AddWithValue("@fe_contr", feContra);
            command.Parameters.AddWithValue("@fe_inicio", feIni);
            command.Parameters.AddWithValue("@fe_culm", feCulm);
            command.Parameters.AddWithValue("@id_pasantia", idPasantia);
            try
            {
                rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 0;
            }
        }
    }
}
