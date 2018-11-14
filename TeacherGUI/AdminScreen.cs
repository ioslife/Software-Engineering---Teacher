using System;
using System.Data;
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

        //on load connect to DB and populate admin table
        private void AdminScreen_Load(object sender, EventArgs e)
        {
            databaseController.dbConnect();
            databaseController.sqlQuery = "SELECT CONCAT(t.first_name, ' ', t.last_name) AS 'Professor', " +
                                                  "c.name 'Class Name', co.course_day 'Class Day', c.startTime 'Class Time' " +
                                                  "FROM course c " +
                                                  "JOIN course_occurrence co ON c.id = co.course_id " +
                                                  "JOIN teacher t ON c.teacher_id = t.id;";
            MySqlCommand cmd = new MySqlCommand(databaseController.sqlQuery, databaseController.conn);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            myAdapter.Fill(dTable);
            dataGridView1.DataSource = dTable;
        }
    }
}
