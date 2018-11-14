using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TeacherGUI
{
    public partial class AdminScreen : Form
    {
        public AdminScreen()
        {
            InitializeComponent();
        }

        private void SubmitProfessor_Click(object sender, EventArgs e)
        {

        }

        private void SubmitClass_Click(object sender, EventArgs e)
        {
            
        }

        //on load
        private void AdminScreen_Load(object sender, EventArgs e)
        {

            //populate dataGridView
            databaseController.dbConnect();
            databaseController.sqlQuery = "SELECT CONCAT(t.first_name, ' ', t.last_name) AS 'Professor', " +
                                                  "c.name 'Class Name', co.course_day 'Class Day', c.startTime 'Start Time' " +
                                                  "FROM course c " +
                                                  "JOIN course_occurrence co ON c.id = co.course_id " +
                                                  "JOIN teacher t ON c.teacher_id = t.id;";
            MySqlCommand cmd = new MySqlCommand(databaseController.sqlQuery, databaseController.conn);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable dgvDataTable = new DataTable();
            myAdapter.Fill(dgvDataTable);
            dataGridView1.DataSource = dgvDataTable;



            //populate professor dropdown
            databaseController.sqlQuery = "SELECT CONCAT(first_name, ' ', last_name) AS 'Professor'" +
                                          "FROM teacher";
            cmd = new MySqlCommand(databaseController.sqlQuery, databaseController.conn);
            MySqlDataReader reader;

            reader = cmd.ExecuteReader();
            DataTable profDataTable = new DataTable();
            profDataTable.Columns.Add("teacher_ID", typeof(int));
            profDataTable.Columns.Add("Professor", typeof(string));
            profDataTable.Load(reader);

            comboBox1.ValueMember = "teacher_ID";
            comboBox1.DisplayMember = "Professor";
            comboBox1.DataSource = profDataTable;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            //Class Name textbox
            textBox1.Enter += new EventHandler(textBox1_Enter);
            textBox1.Leave += new EventHandler(textBox1_Leave);
            textBox1_SetText();

            //populate class day dropdown
            var dataSource = new List<DayOfWeek>();
            dataSource.Add(new DayOfWeek() { Value = "1", Name = "Monday" });
            dataSource.Add(new DayOfWeek() { Value = "2", Name = "Tuesday" });
            dataSource.Add(new DayOfWeek() { Value = "3", Name = "Wednesday" });
            dataSource.Add(new DayOfWeek() { Value = "4", Name = "Thursday" });
            dataSource.Add(new DayOfWeek() { Value = "5", Name = "Friday" });
            dataSource.Add(new DayOfWeek() { Value = "6", Name = "Saturday" });
            dataSource.Add(new DayOfWeek() { Value = "7", Name = "Sunday" });

            //Setup data binding
            comboBox3.DataSource    = dataSource;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember   = "Value";

            // make it readonly
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //code from https://stackoverflow.com/questions/14544135/how-to-gray-out-default-text-in-textbox
        protected void textBox1_SetText()
        {
            this.textBox1.Text = "Class Name";
            textBox1.ForeColor = Color.Gray;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.ForeColor == Color.Black)
                return;
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                textBox1_SetText();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public class DayOfWeek
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
