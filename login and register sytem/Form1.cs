using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace login_and_register_sytem
{
    public partial class frmRegister : Form
    {
        // Connection string to your Access database
        // private OleDbConnection con;

        public frmRegister()
        {
            InitializeComponent();

            // Initialize the connection string
            // con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");

        }
        //Provider=Microsoft.ACE.OLEDB.12.0
        //Provider=Microsoft.Jet.OLEDB.4.0
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Example of how to register a user
            string username = txtUsername.Text;
            string password = txtPassword.Text; // Assume you have a txtPassword TextBox

            try
            {
                con.Open();
                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    // Use parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int result = cmd.ExecuteNonQuery(); // Execute the command

                    // Check if the insert was successful
                    if (result > 0)
                    {
                        MessageBox.Show("User registered successfully!");
                    }
                    else
                    {
                        MessageBox.Show("User registration failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Your existing code
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Your existing code
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // Your existing code
        }

                private void button1_Click(object sender, EventArgs e)
                {
                    if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
                    {
                        MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtPassword.Text == txtComPassword.Text)
                    {
                        con.Open();

                        string register = "INSERT INTO tbl_users VALUES ('" + txtUsername.Text + "', '" + txtPassword.Text + "') ";
                            cmd = new OleDbCommand(register, con);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtComPassword.Text = "";

                        MessageBox.Show("your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Password does not match", "Please Re-enter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Text = "";
                        txtComPassword.Text = "";
                        txtPassword.Focus();
                    }
                }

        private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtPassword.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
             new frmLogin().Show();
            this.Hide();
        }
    }
}
