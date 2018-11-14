using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherGUI
{

    public partial class Login_Screen : Form
    {
        
        //serverAddress = "127.0.0.0";
        //port = "8888";
        
        public Login_Screen()
        {
            InitializeComponent();
        }

        //loginButton
        private void button1_Click(object sender, EventArgs e)
        {
            //check what course that teacher teachs
            /*g.outStream = Encoding.ASCII.GetBytes(usernameTextBox.Text + "#" + passwordTextBox.Text);
            g.serverStream.Write(g.outStream, 0, g.outStream.Length);
            g.serverStream.Flush();
            
            g.serverStream.Read(g.inStream, 0, (int)g.clientSocket.ReceiveBufferSize);
            string returndata = Encoding.ASCII.GetString(g.inStream);
            if (returndata == "teacher ")
            {
                new TeacherHome().Show();
                Hide();
            }else if (returndata == "admin")
            {
                new AdminScreen().Show();
                Hide();
            }
            else Console.WriteLine(returndata);*/
            new TeacherHome().Show();
        }

        private void Login_Screen_Load(object sender, EventArgs e)
        {
            /*g.clientSocket.Connect("10.40.43.43", 61600);
            g.serverStream.Read(g.inStream, 0, (int)g.clientSocket.ReceiveBufferSize);
            string returndata = Encoding.ASCII.GetString(g.inStream);
            if (returndata == ";")
            {
                Console.WriteLine("hello");
            }*/
        }


        //adminButton
        private void button2_Click(object sender, EventArgs e)
        {
            new AdminScreen().Show();
            Hide();
        }
    }
}
