using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using Guna.UI2.WinForms;

namespace Holly_View
{
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KNJIE9E;Initial Catalog=HVcinemas;Integrated Security=True");

        public Admin()
        {
            InitializeComponent();
        }

        private string selectedValue;


        public string SelectedValue
        {
            get { return selectedValue; }
            set { selectedValue = value; }
        }


        private string selectedValue2;


        public string SelectedValue2
        {
            get { return selectedValue2; }
            set { selectedValue2 = value; }
        }

        private string selectedValue3;


        public string SelectedValue3
        {
            get { return selectedValue3; }
            set { selectedValue3 = value; }
        }

        private string selectedValue4;


        public string SelectedValue4
        {
            get { return selectedValue4; }
            set { selectedValue4 = value; }
        }

        private string selectedValue5;
        public string SelectedValue5
        {
            get { return selectedValue5; }
            set { selectedValue5 = value; }
        }


        private string selectedValue6;
        public string SelectedValue6
        {
            get { return selectedValue6; }
            set { selectedValue6 = value; }
        }






        private void Admin_Load(object sender, EventArgs e)
        {
            string valueFromLogin = SelectedValue;
            string valueFromLogin2 = SelectedValue2;
            string branch_id = SelectedValue6;

            label1.Text = valueFromLogin + " " + valueFromLogin2;



            con.Open();

            SqlCommand cmd = new SqlCommand(" select* from Movie where Branch_id = '" + branch_id+"'; ", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["Movie_id"].ToString());
                item.SubItems.Add(reader["Branch_id"].ToString());
                item.SubItems.Add(reader["name"].ToString());
                item.SubItems.Add(reader["year"].ToString());
                item.SubItems.Add(reader["director"].ToString());
                item.SubItems.Add(reader["language"].ToString());
                item.SubItems.Add(reader["State"].ToString());
                item.SubItems.Add(reader["playtime"].ToString());


                listView1.Items.Add(item);
            }

            con.Close();

            con.Open();

            SqlCommand cmd2 = new SqlCommand(" select* from Employee1 ; ", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                ListViewItem item = new ListViewItem(reader2["employee_id"].ToString());
                item.SubItems.Add(reader2["Branch_id"].ToString());
                item.SubItems.Add(reader2["Fname"].ToString());
                item.SubItems.Add(reader2["Lname"].ToString());
                item.SubItems.Add(reader2["email"].ToString());
                item.SubItems.Add(reader2["password"].ToString());


                listView2.Items.Add(item);

            }

            con.Close();

        }






        private void page_btn_Click(object sender, EventArgs e)
        {
            guna2ComboBox1.DroppedDown = true;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 4;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                Tab.SelectedIndex = 3;
                guna2Button2.Visible = false;
                guna2Button5.Visible = true;
            }
            if (guna2ComboBox1.SelectedIndex == 1)
            {
                Tab.SelectedIndex = 2;
            }
        }














        //************************************* Catalog page ***************************************//

        private void catalog_btn_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 0;

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {


            if (listView1.SelectedItems.Count > 0)
            {
                string key = listView1.SelectedItems[0].Text;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this movie?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    listView1.SelectedItems[0].Remove();

                    con.Open();


                    SqlCommand cmm = new SqlCommand(" select* from  Screening where Movie_id= '" + key + "';   ", con);
                    SqlDataReader dd = cmm.ExecuteReader();
                    if (dd.HasRows)
                    {
                        con.Close();
                        con.Open();
                        SqlCommand cm = new SqlCommand("  delete from Screening where Movie_id= '" + key + "'  ", con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlCommand cmd = new SqlCommand(" delete from [dbo].[Movie] where movie_id='" + key + "' ", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        MessageBox.Show("deleted  successfully", "Information", MessageBoxButtons.OK);
                        con.Close();

                    }
                    else
                    {

                        con.Close();
                        con.Open();
                        SqlCommand cm2 = new SqlCommand(" delete from [dbo].[Movie] where movie_id='" + key + "' ", con);
                        cm2.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("deleted  successfully", "Information", MessageBoxButtons.OK);
                        con.Close();
                        con.Close();
                    }

                    con.Close();
                    con.Close();
                }


            }


        }

        private void modify_btn_Click(object sender, EventArgs e)
        {
            //  modify

            con.Open();

            if (listView1.SelectedItems.Count > 0)
            {
                string key2 = listView1.SelectedItems[0].Text;

                Tab.SelectedIndex = 3;
                //  con.Close();
                //  con.Open();


                SqlCommand cm3 = new SqlCommand("select* from Movie where Movie_id='" + key2 + "';  ", con);
                SqlDataReader eer = cm3.ExecuteReader();
                //  con.Open();
                //  con.Close();
                if (eer.Read())
                {
                    //  con.Close();


                    // description//
                    string dataa1 = eer.GetString(14);
                    guna2TextBox23.Text = dataa1;



                    //branch id //
                    int dataa2 = eer.GetInt32(1);
                    guna2TextBox15.Text = dataa2.ToString();


                    // state//
                    string dataa3 = eer.GetString(21);
                    guna2TextBox16.Text = dataa3;


                    // name//
                    string dataa4 = eer.GetString(2);
                    guna2TextBox13.Text = dataa4;


                    //year//
                    int dataa5 = eer.GetInt32(22);
                    guna2TextBox17.Text = dataa5.ToString();

                    //play time//
                    string dataa6 = eer.GetString(7);
                    guna2TextBox26.Text = dataa6;


                    // language//
                    string dataa7 = eer.GetString(21);
                    guna2TextBox18.Text = dataa7;

                    //parent guide//
                    string dataa8 = eer.GetString(3);
                    guna2TextBox24.Text = dataa8;

                    // director//
                    string dataa9 = eer.GetString(8);
                    guna2TextBox14.Text = dataa9;


                    //genre 1//
                    string dataa10 = eer.GetString(4);
                    guna2ComboBox2.Text = dataa10;


                    //genre 2//
                    string dataa11 = eer.GetString(5);
                    guna2ComboBox3.Text = dataa11;


                    //genre 3//
                    string dataa12 = eer.GetString(6);
                    guna2ComboBox4.Text = dataa12;


                    // trailer link//
                    string dataa13 = eer.GetString(13);
                    guna2TextBox25.Text = dataa13;

                    //first actor//
                    string dataa14 = eer.GetString(9);
                    guna2TextBox19.Text = dataa14;


                    // second actor//
                    string dataa15 = eer.GetString(10);
                    guna2TextBox21.Text = dataa15;


                    //third  actor//
                    string dataa16 = eer.GetString(11);
                    guna2TextBox22.Text = dataa16;


                    //fourth actor//
                    string dataa17 = eer.GetString(12);
                    guna2TextBox20.Text = dataa17;

                    // poster//
                    string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + eer["name"].ToString() + @"\" + eer["poster"].ToString();
                    Image image = Image.FromFile(imagePath);
                    guna2PictureBox2.Image = image;
                    guna2PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;


                    // first actor img //
                    string imagePath1 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + eer["name"].ToString() + @"\" + eer["actor1_img"].ToString();
                    Image image1 = Image.FromFile(imagePath1);
                    guna2PictureBox3.Image = image1;
                    guna2PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;


                    // second actor img // 

                    string imagePath2 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + eer["name"].ToString() + @"\" + eer["actor2_img"].ToString();
                    Image image2 = Image.FromFile(imagePath2);
                    guna2PictureBox5.Image = image2;
                    guna2PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;


                    // third actor img //

                    string imagePath3 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + eer["name"].ToString() + @"\" + eer["actor3_img"].ToString();
                    Image image3 = Image.FromFile(imagePath3);
                    guna2PictureBox4.Image = image3;
                    guna2PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;


                    // forth actor img //

                    string imagePath4 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + eer["name"].ToString() + @"\" + eer["actor4_img"].ToString();
                    Image image4 = Image.FromFile(imagePath4);
                    guna2PictureBox6.Image = image4;
                    guna2PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;


                }

                guna2Button2.Visible = true;




            }
            else
            {

                MessageBox.Show("select movie ", "Information", MessageBoxButtons.OK);

            }



            con.Close();

        }



        //********************************** Employee page *********************************//

        private void employee_btn_Click(object sender, EventArgs e)
        {
            Tab.SelectedIndex = 1;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            if (listView2.SelectedItems.Count > 0)
            {
                string key = listView2.SelectedItems[0].Text;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this Emlpoyee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    listView2.SelectedItems[0].Remove();


                    con.Open();

                    SqlCommand cmd = new SqlCommand(" delete from Employee1 where employee_id ='" + key + "' ", con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("deleted  successfully", "Information", MessageBoxButtons.OK);

                    con.Close();
                }


            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            

            // mod emp

            con.Open();


            if (listView2.SelectedItems.Count > 0)
            {
                string key3 = listView2.SelectedItems[0].Text;

                Tab.SelectedIndex = 2;

                SqlCommand cmd = new SqlCommand("  select * from Employee1 where employee_id ='" + key3 + "';     ", con);
                SqlDataReader aar = cmd.ExecuteReader();
                if (aar.Read())
                {
                    //maneger_id//
                    int datta1 = aar.GetInt32(2);
                    guna2TextBox6.Text = datta1.ToString();

                    // first name//
                    string datta2 = aar.GetString(3);
                    guna2TextBox1.Text = datta2;

                    // last name//
                    string datta3 = aar.GetString(4);
                    guna2TextBox2.Text = datta3;

                    // email//
                    string datta4 = aar.GetString(5);
                    guna2TextBox3.Text = datta4;

                    // password//
                    string datta5 = aar.GetString(6);
                    guna2TextBox4.Text = datta5;

                    // branch id//
                    int datta6 = aar.GetInt32(1);
                    guna2TextBox5.Text = datta6.ToString();





                }


            }
            else
            {
                MessageBox.Show(" select employee", "Information", MessageBoxButtons.OK);
            }







            con.Close();
        }



        //************************************* Edit and Add page ****************************//

        private void edit_btn_Click(object sender, EventArgs e)
        {


            con.Open();

            string key3 = listView2.SelectedItems[0].Text;

            SqlCommand cmd = new SqlCommand("update Employee1 set Fname='" + guna2TextBox1.Text + "' ,Lname='" + guna2TextBox2.Text + "',email='" + guna2TextBox3.Text + "',password='" + guna2TextBox4.Text + "',Branch_id='" + guna2TextBox5.Text + "'  where employee_id='" + key3 + "'  ", con);
            cmd.ExecuteNonQuery();

            guna2TextBox1.Text = guna2TextBox2.Text = guna2TextBox3.Text = guna2TextBox4.Text = guna2TextBox5.Text = guna2TextBox6.Text = null;

            MessageBox.Show("updated successfully", "Information", MessageBoxButtons.OK);

            con.Close();


        }

        private void add_btn_Click(object sender, EventArgs e)
        {



                con.Close();
                con.Open();
                if (guna2TextBox7.Text != string.Empty && guna2TextBox8.Text != string.Empty && guna2TextBox9.Text != string.Empty && guna2TextBox10.Text != string.Empty && guna2TextBox11.Text != string.Empty && guna2TextBox12.Text != string.Empty)
                {
                    SqlCommand cmd = new SqlCommand(" insert into Employee1 (Branch_id,manager_id,Fname,Lname,email,password) values('" + guna2TextBox8.Text + "','" + guna2TextBox7.Text + "','" + guna2TextBox12.Text + "','" + guna2TextBox11.Text + "','" + guna2TextBox10.Text + "','" + guna2TextBox9.Text + "' ) ", con);
                    cmd.ExecuteNonQuery();

                    guna2TextBox7.Text = guna2TextBox12.Text = guna2TextBox11.Text = guna2TextBox10.Text = guna2TextBox9.Text = guna2TextBox8.Text = guna2TextBox6.Text = null;

                    MessageBox.Show("added successfully", "Information", MessageBoxButtons.OK);
                    con.Close();
                }

                else 
                {
                    MessageBox.Show("please add all info first");
                }
            


                 con.Close();


        }



        //*********************************** Add item **************************************//

        // poster img //
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            OpenFileDialog o = new OpenFileDialog();


            if (o.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(o.FileName);
                guna2PictureBox2.Image = Image.FromFile(o.FileName);
                guna2PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                poster.Text = fileName;
            }



            //MemoryStream ms = new MemoryStream();
            //{
            //    // Convert the image to a byte array
            //    guna2PictureBox2.Image.Save(ms, guna2PictureBox2.Image.RawFormat);
            //    byte[] imageData = ms.ToArray();
            //}


        }



        // actor1 img //
        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(o.FileName);
                guna2PictureBox3.Image = Image.FromFile(o.FileName);
                guna2PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                actor1_img.Text = fileName;

            }


            //MemoryStream ms = new MemoryStream();
            //{
            //    // Convert the image to a byte array
            //    guna2PictureBox3.Image.Save(ms, pictureBox1.Image.RawFormat);
            //    byte[] imageData = ms.ToArray();
            //}
        }



        // actor2 img//
        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(o.FileName);
                guna2PictureBox5.Image = Image.FromFile(o.FileName);
                guna2PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;

                actor2_img.Text = fileName;
            }


            //MemoryStream ms = new MemoryStream();
            //{
            //    // Convert the image to a byte array
            //    guna2PictureBox5.Image.Save(ms, pictureBox1.Image.RawFormat);
            //    byte[] imageData = ms.ToArray();
            //}
        }



        // actor3 img//
        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(o.FileName);
                guna2PictureBox4.Image = Image.FromFile(o.FileName);
                guna2PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                actor3_img.Text = fileName;
            }


            //MemoryStream ms = new MemoryStream();
            //{
            //    // Convert the image to a byte array
            //    guna2PictureBox4.Image.Save(ms, pictureBox1.Image.RawFormat);
            //    byte[] imageData = ms.ToArray();
            //}


        }


        // actor4 img//
        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {

            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(o.FileName);
                guna2PictureBox6.Image = Image.FromFile(o.FileName);
                guna2PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;

                actor4_img.Text = fileName;
            }


            //MemoryStream ms = new MemoryStream();
            //{
            //    // Convert the image to a byte array
            //    guna2PictureBox6.Image.Save(ms, pictureBox1.Image.RawFormat);
            //    byte[] imageData = ms.ToArray();
            //}


        }




        private void guna2Button5_Click_1(object sender, EventArgs e)
        {

            con.Open();

            if (guna2PictureBox2.Image == null || guna2PictureBox3.Image == null || guna2PictureBox4.Image == null || guna2PictureBox5.Image == null || guna2PictureBox6.Image == null || guna2TextBox13.Text == null || guna2TextBox15.Text == null || guna2TextBox14.Text == null)
            {
                MessageBox.Show(" you shuold add a poster and 4 photo for actors and title,branch_id,director", "Information", MessageBoxButtons.OK);

            }
            else
            {

                SqlCommand cmmd = new SqlCommand("insert into Movie (State,name,parent_guide,genre1,genre2,genre3,playtime,director,actor1,actor2,actor3,actor4,trailer_link,discerption,poster,actor1_img,actor2_img,actor3_img,actor4_img,language,branch_id,year) values('" + guna2TextBox16.Text + "','" + guna2TextBox13.Text + "','" + guna2TextBox24.Text + "','" + guna2ComboBox2.Text + "','" + guna2ComboBox3.Text + "','" + guna2ComboBox4.Text + "','" + guna2TextBox26.Text + "','" + guna2TextBox14.Text + "','" + guna2TextBox19.Text + "','" + guna2TextBox21.Text + "','" + guna2TextBox22.Text + "','" + guna2TextBox20.Text + "','" + guna2TextBox25.Text + "','" + guna2TextBox23.Text + "','" + poster.Text + "','" + actor1_img.Text + "','" + actor2_img.Text + "','" + actor3_img.Text + "','" + actor4_img.Text + "','" + guna2TextBox18.Text + "','" + guna2TextBox15.Text + "','" + guna2TextBox17.Text + "'); ", con);
                cmmd.ExecuteNonQuery();
                // it should be the id not the NNNAAAAMEE
                SqlCommand cmd = new SqlCommand(" select * from Movie where name='" + guna2TextBox13.Text + "';  ", con);
                SqlDataReader reader3 = cmd.ExecuteReader();
                if (reader3.Read())
                {
                    int data = reader3.GetInt32(0);
                    guna2TextBox32.Text = data.ToString();

                }

                guna2TextBox16.Text = guna2TextBox13.Text = guna2TextBox24.Text = guna2ComboBox2.Text = guna2ComboBox3.Text = guna2ComboBox4.Text = guna2TextBox26.Text = guna2TextBox14.Text = guna2TextBox19.Text = guna2TextBox21.Text = guna2TextBox22.Text = guna2TextBox20.Text = guna2TextBox25.Text = guna2TextBox23.Text = guna2TextBox18.Text = guna2TextBox15.Text = guna2TextBox17.Text = null;
                guna2PictureBox2.Image = guna2PictureBox3.Image = guna2PictureBox5.Image = guna2PictureBox4.Image = guna2PictureBox6.Image = null;


                Tab.SelectedIndex = 4;
            }

            con.Close();



        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //update btn//

           

                con.Open();

                string key2 = listView1.SelectedItems[0].Text;


                SqlCommand cmd = new SqlCommand("  update [dbo].[Movie] set Branch_id='" + guna2TextBox15.Text + "', State= '" + guna2TextBox16.Text + "', name='" + guna2TextBox13.Text + "', year='" + guna2TextBox17.Text + "', playtime='" + guna2TextBox26.Text + "', language= '" + guna2TextBox18.Text + "', parent_guide='" + guna2TextBox24.Text + "' , director='" + guna2TextBox14.Text + "', genre1='" + guna2ComboBox2.Text + "' ,genre2='" + guna2ComboBox3.Text + "' , genre3= '" + guna2ComboBox4.Text + "' , trailer_link='" + guna2TextBox25.Text + "' , actor1='" + guna2TextBox19.Text + "', actor2='" + guna2TextBox21.Text + "' ,actor3=' " + guna2TextBox22.Text + "' ,actor4='" + guna2TextBox20.Text + "'  where Movie_id= '" + key2 + "'   ", con);
                cmd.ExecuteNonQuery();

                

                MessageBox.Show("updated successfully", "Information", MessageBoxButtons.OK);

                guna2TextBox15.Text = guna2TextBox16.Text = guna2TextBox13.Text = guna2TextBox17.Text = guna2TextBox26.Text = guna2TextBox18.Text = guna2TextBox24.Text = guna2TextBox14.Text = guna2TextBox20.Text = guna2TextBox22.Text = guna2TextBox21.Text = guna2TextBox19.Text = guna2TextBox25.Text = null;
                guna2ComboBox2.Text = guna2ComboBox3.Text = guna2ComboBox4.Text = guna2TextBox23.Text = null;
                guna2PictureBox2.Image = null;
                guna2PictureBox3.Image = null;
                guna2PictureBox4.Image = null;
                guna2PictureBox5.Image = null;
                guna2PictureBox6.Image = null;





            con.Close();

            
        }






        //********************************** Screen page ****************************//


        private void guna2Button6_Click(object sender, EventArgs e)
        {


            try
            {
                con.Open();

                string txt = guna2TextBox29.Text;
                if (txt == "3:00:00" || txt == "6:00:00" || txt == "9:00:00" || txt == "12:00:00" || txt == "15:00:00" || txt == "18:00:00" || txt == "21:00:00" || txt == "00:00:00")
                {

                    SqlCommand cmd = new SqlCommand("select* from Screening where Auditorium_id='" + guna2TextBox30.Text + "' and screening_start ='" + guna2TextBox29.Text + "' and date1='" + guna2TextBox28.Text + "'; ", con);
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    if (reader1.HasRows == true)
                    {
                        MessageBox.Show(" There is a  conflict. Please choose a different or auditorium or date", "Information", MessageBoxButtons.OK);

                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand(" insert into Screening(Movie_id,Auditorium_id,screening_start,date1)values ('" + guna2TextBox32.Text + "','" + guna2TextBox30.Text + "','" + guna2TextBox29.Text + "','" + guna2TextBox28.Text + "'  )     ", con);
                        cmd1.ExecuteNonQuery();
                        guna2TextBox32.Text = guna2TextBox30.Text = guna2TextBox29.Text = guna2TextBox28.Text = null;

                        MessageBox.Show("added and screen movie done ", "Information", MessageBoxButtons.OK);
                        con.Close();
                    }

                    con.Close();
                }


                else
                {

                    MessageBox.Show("this timeshow is not avaliable the screen time you can choose(3:00:00 ,6:00:00,9:00:00,12:00:00,15:00:00,18:00:00,21:00:00,00:00:00) ", "Information", MessageBoxButtons.OK);

                }

                con.Close();
            }

            catch (Exception ex)
            {
                con.Close();
                con.Open();
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            con.Close();





        }



        //******************* home btn*****************//

        private void home_btn_Click(object sender, EventArgs e)
        {
            string valueFromLogin = SelectedValue;
            string valueFromLogin2 = SelectedValue2;
            string branch_id = SelectedValue6;
            string email = SelectedValue3;
            string id = SelectedValue4;


            
            Form1 form1 = new Form1();
            form1.SelectedValue = valueFromLogin;
            form1.SelectedValue2 = valueFromLogin2;
            form1.SelectedValue3 = email;
            form1.SelectedValue4 = id;
            form1.SelectedValue6 = branch_id;
            form1.Show();

        }





        //************************* log ou btn****************************//
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login ll = new Login();
            ll.Show();
        }

        
    }
}
