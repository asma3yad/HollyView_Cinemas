using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Holly_View
{
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-KNJIE9E;Initial Catalog=HVcinemas;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            password_txt.UseSystemPasswordChar = true;
        }

        private void password_txt_IconRightClick(object sender, EventArgs e)
        {
            if (password_txt.UseSystemPasswordChar)
            {
                password_txt.UseSystemPasswordChar = false;
                password_txt.IconRight = Properties.Resources.Eye;
            }
            else
            {
                password_txt.UseSystemPasswordChar = true;
                password_txt.IconRight = Properties.Resources.Invisible;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string branch_id;

            if (login_type.SelectedIndex == 0 && (branch_num.SelectedIndex == 0 || branch_num.SelectedIndex == 1 || branch_num.SelectedIndex == 2))
            {
                MessageBox.Show("we still don`t have a maneger");

            }
            else if (login_type.SelectedIndex == 1 && branch_num.SelectedIndex == 0 )
            {
                //MessageBox.Show("we still don`t have Admin");
                branch_id = "1";
                if (email_txt.Text != null && password_txt.Text != null)
                {
                    cn.Close();
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select* from Admin where Branch_id = '" + branch_id + "' and email = '" + email_txt.Text + "' and password = '" + password_txt.Text + "' ", cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        user_id.Text = reader["admin_id"].ToString();
                        Fname.Text = reader["Fname"].ToString();
                        Lname.Text = reader["Lname"].ToString();
                        string selectedValue = Fname.Text;
                        string selectedValue2 = Lname.Text;
                        string selectedValue4 = user_id.Text;
                        string selectedValue5 = password_txt.Text;

                        Form1 form1 = new Form1();
                        form1.SelectedValue = selectedValue;
                        form1.SelectedValue2 = selectedValue2;
                        form1.SelectedValue3 = email_txt.Text;
                        form1.SelectedValue4 = user_id.Text;
                        form1.SelectedValue5 = password_txt.Text;
                        form1.SelectedValue6 = branch_id;

                        Admin admin = new Admin();
                        admin.SelectedValue = selectedValue;
                        admin.SelectedValue2 = selectedValue2;
                        admin.SelectedValue3 = email_txt.Text;
                        admin.SelectedValue4 = user_id.Text;
                        admin.SelectedValue5 = password_txt.Text;
                        admin.SelectedValue6 = branch_id;


                        admin.Show();
                        this.Hide();
                        //Process.Start(@"C:\Users\assma\OneDrive\Desktop\HHvv\AdminPage.sln");


                    }
                    else
                    {
                        MessageBox.Show("wrong email or password");
                    }
                }
                else
                {
                    MessageBox.Show("please enter both the email and password first");
                }

                cn.Close();
            }

            else if (login_type.SelectedIndex == 1 && branch_num.SelectedIndex == 1)
            {
                //MessageBox.Show("we still don`t have Admin");
                branch_id = "2";
                if (email_txt.Text != null && password_txt.Text != null)
                {
                    cn.Close();
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select* from Admin where Branch_id = '" + branch_id + "' and email = '" + email_txt.Text + "' and password = '" + password_txt.Text + "' ", cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        user_id.Text = reader["admin_id"].ToString();
                        Fname.Text = reader["Fname"].ToString();
                        Lname.Text = reader["Lname"].ToString();
                        string selectedValue = Fname.Text;
                        string selectedValue2 = Lname.Text;
                        string selectedValue4 = user_id.Text;
                        string selectedValue5 = password_txt.Text;

                        Form1 form1 = new Form1();
                        form1.SelectedValue = selectedValue;
                        form1.SelectedValue2 = selectedValue2;
                        form1.SelectedValue3 = email_txt.Text;
                        form1.SelectedValue4 = user_id.Text;
                        form1.SelectedValue5 = password_txt.Text;
                        form1.SelectedValue6 = branch_id;

                        Admin admin = new Admin();
                        admin.SelectedValue = selectedValue;
                        admin.SelectedValue2 = selectedValue2;
                        admin.SelectedValue3 = email_txt.Text;
                        admin.SelectedValue4 = user_id.Text;
                        admin.SelectedValue5 = password_txt.Text;
                        admin.SelectedValue6 = branch_id;


                        admin.Show();
                        this.Hide();
                        //Process.Start(@"C:\Users\assma\OneDrive\Desktop\HHvv\AdminPage.sln");


                    }
                    else
                    {
                        MessageBox.Show("wrong email or password");
                    }
                }
                else
                {
                    MessageBox.Show("please enter both the email and password first");
                }

                cn.Close();
            }

            else if (login_type.SelectedIndex == 1 && branch_num.SelectedIndex == 2)
            {
                //MessageBox.Show("we still don`t have Admin");
                branch_id = "3";
                if (email_txt.Text != null && password_txt.Text != null)
                {
                    cn.Close();
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select* from Admin where Branch_id = '" + branch_id + "' and email = '" + email_txt.Text + "' and password = '" + password_txt.Text + "' ", cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        user_id.Text = reader["admin_id"].ToString();
                        Fname.Text = reader["Fname"].ToString();
                        Lname.Text = reader["Lname"].ToString();
                        string selectedValue = Fname.Text;
                        string selectedValue2 = Lname.Text;
                        string selectedValue4 = user_id.Text;
                        string selectedValue5 = password_txt.Text;

                        Form1 form1 = new Form1();
                        form1.SelectedValue = selectedValue;
                        form1.SelectedValue2 = selectedValue2;
                        form1.SelectedValue3 = email_txt.Text;
                        form1.SelectedValue4 = user_id.Text;
                        form1.SelectedValue5 = password_txt.Text;
                        form1.SelectedValue6 = branch_id;

                        Admin admin = new Admin();
                        admin.SelectedValue = selectedValue;
                        admin.SelectedValue2 = selectedValue2;
                        admin.SelectedValue3 = email_txt.Text;
                        admin.SelectedValue4 = user_id.Text;
                        admin.SelectedValue5 = password_txt.Text;
                        admin.SelectedValue6 = branch_id;


                        admin.Show();
                        this.Hide();
                        //Process.Start(@"C:\Users\assma\OneDrive\Desktop\HHvv\AdminPage.sln");


                    }
                    else
                    {
                        MessageBox.Show("wrong email or password");
                    }
                }
                else
                {
                    MessageBox.Show("please enter both the email and password first");
                }

                cn.Close();
            }
            else if (login_type.SelectedIndex == 2 && branch_num.SelectedIndex == 0)
            {
                branch_id = "1";
                if (email_txt.Text != null && password_txt.Text != null)
                {
                    cn.Close();
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select* from Employee1 where Branch_id = '" + branch_id + "' and email = '" + email_txt.Text + "' and password = '" + password_txt.Text + "' ", cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        user_id.Text = reader["employee_id"].ToString();
                        Fname.Text = reader["Fname"].ToString();
                        Lname.Text = reader["Lname"].ToString();
                        string selectedValue = Fname.Text;
                        string selectedValue2 = Lname.Text;
                        string selectedValue4 = user_id.Text;
                        string selectedValue5 = password_txt.Text;

                        Form1 form1 = new Form1();
                        form1.SelectedValue = selectedValue;
                        form1.SelectedValue2 = selectedValue2;
                        form1.SelectedValue3 = email_txt.Text;
                        form1.SelectedValue4 = user_id.Text;
                        form1.SelectedValue5 = password_txt.Text;
                        form1.SelectedValue6 = branch_id;
                        form1.Show();
                        this.Hide();




                    }
                    else
                    {
                        MessageBox.Show("wrong email or password");
                    }


                }
                else
                {
                    MessageBox.Show("please enter both the email and password first");
                }

                cn.Close();
            }

            else if (login_type.SelectedIndex == 2 && branch_num.SelectedIndex == 1)
            {
                branch_id = "2";
                if (email_txt.Text != null && password_txt.Text != null)
                {
                    cn.Close();
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select* from Employee1 where Branch_id = '" + branch_id + "' and email = '" + email_txt.Text + "' and password = '" + password_txt.Text + "' ", cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        user_id.Text = reader["employee_id"].ToString();
                        Fname.Text = reader["Fname"].ToString();
                        Lname.Text = reader["Lname"].ToString();
                        string selectedValue = Fname.Text;
                        string selectedValue2 = Lname.Text;
                        string selectedValue4 = user_id.Text;
                        string selectedValue5 = password_txt.Text;

                        Form1 form1 = new Form1();
                        form1.SelectedValue = selectedValue;
                        form1.SelectedValue2 = selectedValue2;
                        form1.SelectedValue3 = email_txt.Text;
                        form1.SelectedValue4 = user_id.Text;
                        form1.SelectedValue5 = password_txt.Text;
                        form1.SelectedValue6 = branch_id;
                        form1.Show();
                        this.Hide();




                    }
                    else
                    {
                        MessageBox.Show("wrong email or password");
                    }


                }
                else
                {
                    MessageBox.Show("please enter both the email and password first");
                }

                cn.Close();
            }

            else if (login_type.SelectedIndex == 2 && branch_num.SelectedIndex == 2)
            {
                branch_id = "3";
                if (email_txt.Text != null && password_txt.Text != null)
                {
                    cn.Close();
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("select* from Employee1 where Branch_id = '" + branch_id + "' and email = '" + email_txt.Text + "' and password = '" + password_txt.Text + "' ", cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        user_id.Text = reader["employee_id"].ToString();
                        Fname.Text = reader["Fname"].ToString();
                        Lname.Text = reader["Lname"].ToString();
                        string selectedValue = Fname.Text;
                        string selectedValue2 = Lname.Text;
                        string selectedValue4 = user_id.Text;
                        string selectedValue5 = password_txt.Text;

                        Form1 form1 = new Form1();
                        form1.SelectedValue = selectedValue;
                        form1.SelectedValue2 = selectedValue2;
                        form1.SelectedValue3 = email_txt.Text;
                        form1.SelectedValue4 = user_id.Text;
                        form1.SelectedValue5 = password_txt.Text;
                        form1.SelectedValue6 = branch_id;
                        form1.Show();
                        this.Hide();




                    }
                    else
                    {
                        MessageBox.Show("wrong email or password");
                    }


                }
                else
                {
                    MessageBox.Show("please enter both the email and password first");
                }

                cn.Close();
            }
            else
            {
                MessageBox.Show("please check the branch and the job again");
            }

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
