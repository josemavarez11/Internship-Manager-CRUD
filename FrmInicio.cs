using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Npgsql;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace GestorPasantias
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //Para el boton de limpiar
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            numericUpDown1.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now;
            label15.Hide();
        }

        private void setFieldsUpdatePasantias()
        {
            textBox9.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox7.Text = string.Empty;
            label22.Text = "C.I. Pasante";
            textBox9.Width = 90;
            label21.Show();
            label21.Text = "C.I. T. Académico";
            label20.Show();
            textBox8.Show();
            label20.Text = "C.I. T. Académico";
            label19.Show();
            label19.Text = "I.D. Empresa";
            numericUpDown3.Show();
            textBox7.Show();
            label18.Show();
            label18.Text = "Contratación";
            dateTimePicker7.Show();
            label17.Show();
            label17.Text = "Inicio";
            dateTimePicker8.Show();
            label16.Show();
            label16.Text = "Culminación";
            dateTimePicker9.Show();
            label24.Show();
            numericUpDown4.Show();
            numericUpDown4.Value = 0;
            label24.Text = "I.D. Pasantía";
        }
        private void setFieldsReportesPasantias()
        {
            numericUpDown2.Value = 0;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            label8.Text = "C.I. Pasante";
            textBox4.Width = 90;
            label9.Show();
            label9.Text = "C.I. T. Académico";
            label10.Show();
            textBox5.Show();
            label10.Text = "C.I. T. Académico";
            label11.Show();
            label11.Text = "I.D. Empresa";
            numericUpDown2.Show();
            textBox6.Show();
            label12.Show();
            label12.Text = "Contratación";
            dateTimePicker6.Show();
            label13.Show();
            label13.Text = "Inicio";
            dateTimePicker5.Show();
            label14.Show();
            label14.Text = "Culminación";
            dateTimePicker4.Show();
        }

        private void setFieldsUpdatePasantes()
        {
            textBox9.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox9.Width = 90;
            textBox8.Show();
            textBox7.Show();
            label22.Text = "C.I. Pasante";
            label21.Text = "Nombre";
            label21.Show();
            label20.Text = "Apellido";
            label20.Show();
            label19.Hide();
            label18.Hide();
            label17.Hide();
            label16.Hide();
            numericUpDown3.Hide();
            dateTimePicker7.Hide();
            dateTimePicker9.Hide();
            dateTimePicker8.Hide();
            label24.Hide();
            numericUpDown4.Hide();
        }
        private void setFieldsReportesPasantes()
        {
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox4.Width = 90;
            textBox5.Show();
            textBox6.Show();
            label8.Text = "C.I. Pasante";
            label9.Text = "Nombre";
            label9.Show();
            label10.Text = "Apellido";
            label10.Show();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            numericUpDown2.Hide();
            dateTimePicker6.Hide();
            dateTimePicker4.Hide();
            dateTimePicker5.Hide();
        }

        private void setFieldsUpdateTutores()
        {
            textBox9.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox9.Width = 90;
            textBox8.Show();
            textBox7.Show();
            label22.Text = "C.I. Tutor";
            label21.Text = "Nombre";
            label21.Show();
            label20.Text = "Apellido";
            label20.Show();
            numericUpDown3.Show();
            label19.Hide();  
            label18.Hide();
            label17.Hide();
            label16.Hide();
            dateTimePicker9.Hide();
            dateTimePicker8.Hide();
            dateTimePicker7.Hide();
            label24.Show();
            label24.Text = "Tipo de Tutor";
            numericUpDown4.Show();
            numericUpDown4.Value = 0;
            numericUpDown3.Hide();
        }
        private void setFieldsReportesTutores()
        {
            numericUpDown2.Value = 0;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox4.Width = 90;
            textBox5.Show();
            textBox6.Show();
            label8.Text = "C.I. Tutor";
            label9.Text = "Nombre";
            label9.Show();
            label10.Text = "Apellido";
            label10.Show();
            numericUpDown2.Show();
            label11.Text = "Tipo de Tutor";
            label11.Show();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            dateTimePicker4.Hide();
            dateTimePicker5.Hide();
            dateTimePicker6.Hide();
        }

        private void setFieldsUpdateEmpresas()
        {
            textBox9.Text = string.Empty;
            label22.Text = "Nombre de Empresa";
            textBox9.Width = 150;
            textBox8.Hide();
            textBox7.Hide();
            label21.Hide();
            label20.Hide();
            label19.Hide();
            label18.Hide();
            label17.Hide();
            label16.Hide();
            numericUpDown3.Hide();
            dateTimePicker7.Hide();
            dateTimePicker9.Hide();
            dateTimePicker8.Hide();
            label24.Text = "I.D. Empresa";
            label24.Show();
            numericUpDown4.Show();
        }
        private void setFieldsReportesEmpresas()
        {
            textBox4.Text = string.Empty;
            label8.Text = "Nombre de Empresa";
            textBox4.Width = 150;
            textBox5.Hide();
            textBox6.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            numericUpDown2.Hide();
            dateTimePicker6.Hide();
            dateTimePicker4.Hide();
            dateTimePicker5.Hide();
        }

        private void setInsertFailed()
        {
            label15.Text = "¡Error al registrar la pasantía!";
            label15.ForeColor = Color.Red;
            label15.Show();
        }
        private void setInsertSuccess()
        {
            label15.Text = "¡Pasantía registrada exitosamente!";
            label15.ForeColor = Color.White;
            label15.Show();
        }

        private void setUpdateFailed()
        {
            label23.Text = "¡Error al actualizar el registro!";
            label23.ForeColor = Color.Red;
            label23.Show();
        }
        private void setUpdateSuccess()
        {
            label23.Text = "¡Registro actualizado exitosamente!";
            label23.ForeColor = Color.White;
            label23.Show();
        }

        private void setDeleteSuccess()
        {
            label23.Text = "¡Registro eliminado exitosamente!";
            label23.ForeColor = Color.White;
            label23.Show();
        }
        private void setDeleteFailed()
        {
            label23.Text = "¡Error al eliminar el registro!";
            label23.ForeColor = Color.Red;
            label23.Show();
        }

        public static string ConvertDate(DateTime inputDate)
        {
            return inputDate.ToString("yyyy-MM-dd");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Pasantías":
                    setFieldsReportesPasantias();
                    break;
                case "Pasantes":
                    setFieldsReportesPasantes();
                    break;
                case "Tutores":
                    setFieldsReportesTutores();
                    break;
                case "Empresas":
                    setFieldsReportesEmpresas();
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dataTable;
            switch (comboBox1.Text)
            {
                case "Pasantías":
                    if (!string.IsNullOrEmpty(textBox4.Text) || !string.IsNullOrEmpty(textBox5.Text) || !string.IsNullOrEmpty(textBox6.Text) || numericUpDown2.Value != 0 || dateTimePicker4.Value.Date != DateTime.Now.Date || dateTimePicker5.Value.Date != DateTime.Now.Date || dateTimePicker6.Value.Date != DateTime.Now.Date)
                    {
                        dataTable = new DataTable();
                        int ci_pasante = (textBox4.Text == "") ? 0 : Int32.Parse(textBox4.Text);
                        int ci_tacad = (textBox5.Text == "") ? 0 : Int32.Parse(textBox5.Text);
                        int ci_tind = (textBox6.Text == "") ? 0 : Int32.Parse(textBox6.Text);
                        int id_empresa = (numericUpDown2.Value == 0) ? 0 : (int)numericUpDown2.Value;
                        string fe_contrato = ConvertDate(dateTimePicker6.Value);
                        string fe_inicio = ConvertDate(dateTimePicker4.Value);
                        string fe_culm = ConvertDate(dateTimePicker5.Value);
                        NpgsqlDataReader dr = Queries.drPasantias(ci_pasante, ci_tacad, ci_tind, id_empresa, fe_contrato, fe_inicio, fe_culm);
                        dataTable.Load(dr);
                        dataGridView1.DataSource = dataTable;
                        break;
                    }else{
                        dataTable = new DataTable();
                        NpgsqlDataReader dr = Queries.selectAll("SELECT * FROM pasantia");
                        dataTable.Load(dr);
                        dataGridView1.DataSource = dataTable;
                        break;
                    }
                case "Pasantes":
                    if (!string.IsNullOrEmpty(textBox4.Text) || !string.IsNullOrEmpty(textBox5.Text) || !string.IsNullOrEmpty(textBox6.Text))
                    {
                        dataTable = new DataTable();
                        int ci_pasante = (textBox4.Text == "") ? 0 : Int32.Parse(textBox4.Text);
                        string no_pasante = textBox5.Text;
                        string ap_pasante = textBox6.Text;
                        NpgsqlDataReader dr = Queries.drPasantes(ci_pasante, no_pasante, ap_pasante);
                        dataTable.Load(dr);
                        dataGridView1.DataSource = dataTable;
                        break;
                    }else{
                        dataTable = new DataTable();
                        NpgsqlDataReader dr = Queries.selectAll("SELECT * FROM pasante");
                        dataTable.Load(dr);
                        dataGridView1.DataSource = dataTable;
                        break;
                    }
                case "Tutores":
                    if (!string.IsNullOrEmpty(textBox4.Text) || !string.IsNullOrEmpty(textBox5.Text) || !string.IsNullOrEmpty(textBox6.Text) || numericUpDown2.Value != 0)
                    {
                        dataTable = new DataTable();
                        int ci_tutor = (textBox4.Text == "") ? 0 : Int32.Parse(textBox4.Text);
                        string no_tutor = textBox5.Text;
                        string ap_tutor = textBox6.Text;
                        int ti_tutor = (int)numericUpDown2.Value;
                        NpgsqlDataReader dr = Queries.drTutores(ci_tutor, no_tutor, ap_tutor, ti_tutor);
                        dataTable.Load(dr);
                        dataGridView1.DataSource = dataTable;
                        break;
                    }else{
                        dataTable = new DataTable();
                        NpgsqlDataReader dr = Queries.selectAll("SELECT * FROM tutor");
                        dataTable.Load(dr);
                        dataGridView1.DataSource = dataTable;
                        break;
                    }
                case "Empresas":
                    if(!string.IsNullOrEmpty(textBox4.Text))
                    {
                        dataTable = new DataTable();
                        NpgsqlDataReader dr = Queries.drEmpresas(textBox4.Text);
                        dataTable.Load(dr);
                        dataGridView1.DataSource = dataTable;
                        break;
                    }else {
                        dataTable = new DataTable();
                        NpgsqlDataReader dr = Queries.selectAll("SELECT * FROM empresa");
                        dataTable.Load(dr);
                        dataGridView1.DataSource = dataTable;
                        break;
                    }      
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cipasante = Int32.Parse(textBox1.Text);
            int citacad = Int32.Parse(textBox2.Text);
            int citind = Int32.Parse(textBox3.Text);
            int idempresa = (int)numericUpDown1.Value;
            string fcontrat = ConvertDate(dateTimePicker1.Value);
            string finicio = ConvertDate(dateTimePicker2.Value);
            string fculm = ConvertDate(dateTimePicker3.Value);
            
            int rowsAffected = Queries.insertIntoPasantias(cipasante, citacad, citind, idempresa, fcontrat, finicio, fculm);
            if(rowsAffected > 0) setInsertSuccess();
            else setInsertFailed();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "Pasantías":
                    setFieldsUpdatePasantias();
                    break;
                case "Pasantes":
                    setFieldsUpdatePasantes();
                    break;
                case "Tutores":
                    setFieldsUpdateTutores();
                    break;
                case "Empresas":
                    setFieldsUpdateEmpresas();
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int rowsAffected;
            switch (comboBox2.Text)
            {
                case "Pasantías":
                    int idPasantia = (int) numericUpDown4.Value;
                    if(numericUpDown4.Value > 0)
                    {
                        rowsAffected = Queries.deletePasantia(idPasantia);
                        if (rowsAffected > 0) setDeleteSuccess();
                        else setDeleteFailed();
                    }
                    break;
                case "Pasantes":
                    int ciPasante = Int32.Parse(textBox9.Text);
                    if(ciPasante > 0)
                    {
                        rowsAffected = Queries.deletePasante(ciPasante);
                        if (rowsAffected > 0) setDeleteSuccess();
                        else setDeleteFailed();
                    }
                    break;
                case "Tutores":
                    int ciTutor = Int32.Parse(textBox9.Text);
                    if (ciTutor > 0)
                    {
                        rowsAffected = Queries.deleteTutor(ciTutor);
                        if (rowsAffected > 0) setDeleteSuccess();
                        else setDeleteFailed();
                    }
                    break;
                case "Empresas":
                    int idEmpresa = (int) numericUpDown4.Value;
                    if (idEmpresa > 0)
                    {
                        rowsAffected = Queries.deleteEmpresa(idEmpresa);
                        if (rowsAffected > 0) setDeleteSuccess();
                        else setDeleteFailed();
                    }
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int rowsAffected;
            switch (comboBox2.Text)
            {
                case "Pasantías":
                    int cipasante = Int32.Parse(textBox9.Text);
                    int ciTutorA = Int32.Parse(textBox8.Text);
                    int ciTutorT = Int32.Parse(textBox7.Text);
                    int idempresa = (int)numericUpDown3.Value;
                    string feContra = ConvertDate(dateTimePicker7.Value);
                    string feIni = ConvertDate(dateTimePicker9.Value);
                    string feCulm = ConvertDate(dateTimePicker8.Value);
                    int idPasantia = (int)numericUpDown4.Value;
                    if(idPasantia > 0)
                    {
                        rowsAffected = Queries.updatePasantias(cipasante, ciTutorA, ciTutorT, idempresa, feContra, feIni, feCulm, idPasantia);
                        if (rowsAffected > 0) setUpdateSuccess();
                        else setUpdateFailed();
                    }
                    break;
                case "Pasantes":
                    int ciPasante = Int32.Parse(textBox9.Text);
                    string noPasante = textBox8.Text;
                    string apPasante = textBox7.Text;
                    if(ciPasante > 0)
                    {
                        rowsAffected = Queries.updatePasante(noPasante, apPasante, ciPasante);
                        if (rowsAffected > 0) setUpdateSuccess();
                        else setUpdateFailed();
                    }
                    break;
                case "Tutores":
                    int ciTutor = Int32.Parse(textBox9.Text);
                    string noTutor = textBox8.Text;
                    string apTutor = textBox7.Text;
                    int tipoTutor = (int)numericUpDown4.Value;
                    if (ciTutor > 0)
                    {
                        rowsAffected = Queries.updateTutores(noTutor, apTutor, tipoTutor, ciTutor);
                        if (rowsAffected > 0) setUpdateSuccess();
                        else setUpdateFailed();
                    }
                    break;
                case "Empresas":
                    string noEmpresa = textBox9.Text;
                    int idEmpresa = (int)(numericUpDown4.Value);
                    if (idEmpresa > 0)
                    {
                        rowsAffected = Queries.updateEmpresa(noEmpresa, idEmpresa);
                        if (rowsAffected > 0) setUpdateSuccess();
                        else setUpdateFailed();
                    }
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "reporte.pdf";

            string html = "<table border=1><tr><td></td>HOLA MUNDO</tr></table>";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using(FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));
                    using (StringReader sr = new StringReader(html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    fs.Close();
                }
            }*/
        }
    }
}
