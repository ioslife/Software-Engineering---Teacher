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
            databaseController.sqlQuery = "SELECT * FROM student;";
            MySqlCommand cmd = new MySqlCommand(databaseController.sqlQuery, databaseController.conn);
            MySqlDataAdapter myAdapter = new MySqlDataAdapter();
            myAdapter.SelectCommand = cmd;
            DataTable dTable = new DataTable();
            myAdapter.Fill(dTable);
            dataGridView1.DataSource = dTable;
        }
    }
}
