using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Holly_View
{
    public partial class Form1 : Form
    {

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-KNJIE9E;Initial Catalog=HVcinemas;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();

            //hide tabcontrol header
            tabControl1.Appearance = TabAppearance.Normal;
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new System.Drawing.Size(0, 1);

            tabControl2.Appearance = TabAppearance.Normal;
            tabControl2.SizeMode = TabSizeMode.Fixed;
            tabControl2.ItemSize = new System.Drawing.Size(0, 1);


        }

        // passing the name

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



        // evernt for card clicked
        private void MovieCard_CardClicked(object sender, EventArgs e)
        {
            if (sender is movie_card clickedCard)
            {
                int selectedMovieId = clickedCard.MovieId;

                // Use selectedMovieId to fetch and display data in movie_tab
                DisplayMovieDataInTab(selectedMovieId);

                // Switch to the desired tab
                tabControl1.SelectedTab = movie_tab;
                // to make sere that the fisrt button is pink
                guna2Button2.Checked = true;
                guna2Button3.Checked = false;
                guna2Button4.Checked = false;
                // to make sere that the fisrt button is clicked by default
                button2WasClicked = true;
                button3WasClicked = false;
                button4WasClicked = false;
            }
        }



        // method to retrive data by movie id
        private void DisplayMovieDataInTab(int movieId)
        {
            string branch_id = SelectedValue6;
            if (tabControl1.SelectedTab == home_tab)
            {
                



                cn.Close();
                cn.Open();

                


                SqlCommand cmd = new SqlCommand("select* from Movie where Branch_id = '" + branch_id + "' and Movie_id = '" + movieId + "'  and State='current' ", cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id.Text = reader["Movie_id"].ToString();
                    movie_name_lbl1.Text = reader["name"].ToString();
                    parent_guide_lbl.Text = reader["parent_guide"].ToString();

                    string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["poster"].ToString();
                    Image image = Image.FromFile(imagePath);
                    guna2PictureBox6.Image = image;


                    var embed = "<html><head>" +
                    "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
                    "</head><body>" +
                    "<iframe width=\"883\" height=\"581\" src=\"{0}\"" +
                    "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
                    "</body></html>";

                    this.movie_trailer_lbl.DocumentText = string.Format(embed, reader["trailer_link"].ToString());


                    genres_lbl.Text = reader["genre1"].ToString() + ", " + reader["genre2"].ToString() + ", " + reader["genre3"].ToString();
                    label15.Text = reader["discerption"].ToString();
                    playtime_lbl.Text = reader["playtime"].ToString();
                    year_lbl.Text = reader["year"].ToString();
                    language_lbl.Text = reader["language"].ToString();
                    director_lbl.Text = reader["director"].ToString();

                    actor1_name_lbl.Text = reader["actor1"].ToString();
                    string imagePath1 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["actor1_img"].ToString();
                    Image image1 = Image.FromFile(imagePath1);
                    actor1_pic_lbl.Image = image1;

                    actor2_name_lbl.Text = reader["actor2"].ToString();
                    string imagePath2 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["actor2_img"].ToString();
                    Image image2 = Image.FromFile(imagePath2);
                    actor2_pic_lbl.Image = image2;

                    actor3_name_lbl.Text = reader["actor3"].ToString();
                    string imagePath3 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["actor3_img"].ToString();
                    Image image3 = Image.FromFile(imagePath3);
                    actor3_pic_lbl.Image = image3;

                    actor4_name_lbl.Text = reader["actor4"].ToString();
                    string imagePath4 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["actor4_img"].ToString();
                    Image image4 = Image.FromFile(imagePath4);
                    actor4_pic_lbl.Image = image4;

                    // name at show time
                    movie_name_lbl2.Text = reader["name"].ToString() + " - Showtimes";


                    guna2Button2.Visible = true;
                    guna2Button3.Visible = true;
                    guna2Button4.Visible = true;
                    auditorium_1_type.Visible = true;
                    auditorium_2_type.Visible = true;
                    screening_time1.Visible = true;
                    screening_time2.Visible = true;
                    screening_time3.Visible = true;
                    screening_time4.Visible = true;
                    guna2ContainerControl1.Visible = true;
                    guna2ContainerControl2.Visible = true;


                }
                cn.Close();


                
                cn.Close();
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("select DISTINCT top 1 date1 from Screening where Movie_id = '" + movieId + "'", cn);
                reader = cmd1.ExecuteReader();
                while (reader.Read())
                {

                    guna2Button2.Text = reader["date1"].ToString();
                }
                cn.Close();

                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select distinct date1 from Screening where Movie_id ='" + movieId + "' ORDER BY date1 OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
                reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //screen_id2.Text = reader["screen_id"].ToString();
                    guna2Button3.Text = reader["date1"].ToString();
                }

                cn.Close();

                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select distinct date1 from Screening where Movie_id ='" + movieId + "' ORDER BY date1 OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
                reader = cmd3.ExecuteReader();
                while (reader.Read())
                {
                    //screen_id3.Text = reader["screen_id"].ToString();
                    guna2Button4.Text = reader["date1"].ToString();
                }

                cn.Close();



                cn.Open();

                SqlCommand cmd4 = new SqlCommand("select DISTINCT top 1 Auditorium_name from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Movie_id = '" + id.Text + "' ", cn);
                reader = cmd4.ExecuteReader();
                while (reader.Read())
                {
                    auditorium_1_type.Text = reader["Auditorium_name"].ToString();

                }
                cn.Close();


                cn.Open();

                SqlCommand cmd5 = new SqlCommand("select DISTINCT Auditorium_name from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Movie_id = '" + id.Text + "' ORDER BY Auditorium_name OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY  ", cn);
                reader = cmd5.ExecuteReader();
                while (reader.Read())
                {
                    auditorium_2_type.Text = reader["Auditorium_name"].ToString();

                }
                cn.Close();

                cn.Open();

                SqlCommand cmd6 = new SqlCommand("select DISTINCT top 1 screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id='" + branch_id + "' and Auditorium_name = '" + auditorium_1_type.Text + "' and Movie_id = '" + id.Text + "'", cn);
                reader = cmd6.ExecuteReader();
                while (reader.Read())
                {

                    screening_time1.Text = reader["screening_start"].ToString();

                }
                cn.Close();

                cn.Open();

                SqlCommand cmd7 = new SqlCommand("select DISTINCT screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_1_type.Text + "' and Movie_id = '" + id.Text + "'  ORDER BY screening_start OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
                reader = cmd7.ExecuteReader();
                while (reader.Read())
                {

                    screening_time2.Text = reader["screening_start"].ToString();

                }
                cn.Close();


                cn.Open();

                SqlCommand cmd8 = new SqlCommand("select DISTINCT top 1 screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_2_type.Text + "' and Movie_id = '" + id.Text + "'", cn);
                reader = cmd8.ExecuteReader();
                while (reader.Read())
                {

                    screening_time3.Text = reader["screening_start"].ToString();

                }
                cn.Close();


                cn.Open();

                SqlCommand cmd9 = new SqlCommand("select DISTINCT screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_2_type.Text + "' and Movie_id = '" + id.Text + "'  ORDER BY screening_start OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
                reader = cmd9.ExecuteReader();
                while (reader.Read())
                {

                    screening_time4.Text = reader["screening_start"].ToString();

                }
                cn.Close();






                // screen_id for the movie at the first day

                cn.Open();
                SqlCommand cm1 = new SqlCommand("select top 1 screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "'", cn);
                reader = cm1.ExecuteReader();
                while (reader.Read())
                {

                    screen_id1.Text = reader["screen_id"].ToString();

                }
                cn.Close();


                cn.Open();
                SqlCommand cm2 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' ORDER BY screen_id OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY", cn);
                reader = cm2.ExecuteReader();
                while (reader.Read())
                {

                    screen_id2.Text = reader["screen_id"].ToString();

                }
                cn.Close();

                cn.Open();
                SqlCommand cm3 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' ORDER BY screen_id OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY", cn);
                reader = cm3.ExecuteReader();
                while (reader.Read())
                {

                    screen_id3.Text = reader["screen_id"].ToString();

                }
                cn.Close();


                cn.Open();
                SqlCommand cm4 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' ORDER BY screen_id OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY", cn);
                reader = cm4.ExecuteReader();
                while (reader.Read())
                {

                    screen_id4.Text = reader["screen_id"].ToString();

                }
                cn.Close();

                button2WasClicked = true;


            }

            // hide the screening or upcoming
            else if (tabControl1.SelectedTab == upcoming_tab)
            {
                cn.Close();
                cn.Open();

                
                SqlCommand cmd = new SqlCommand("select* from Movie where Branch_id = '" + branch_id + "' and Movie_id = '" + movieId + "'  and State='upcoming' ", cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id.Text = reader["Movie_id"].ToString();
                    movie_name_lbl1.Text = reader["name"].ToString();
                    parent_guide_lbl.Text = reader["parent_guide"].ToString();

                    string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\Upcoming\" + reader["name"].ToString() + @"\" + reader["poster"].ToString();
                    Image image = Image.FromFile(imagePath);
                    guna2PictureBox6.Image = image;


                    var embed = "<html><head>" +
                    "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
                    "</head><body>" +
                    "<iframe width=\"883\" height=\"581\" src=\"{0}\"" +
                    "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
                    "</body></html>";

                    this.movie_trailer_lbl.DocumentText = string.Format(embed, reader["trailer_link"].ToString());


                    genres_lbl.Text = reader["genre1"].ToString() + ", " + reader["genre2"].ToString() + ", " + reader["genre3"].ToString();
                    label15.Text = reader["discerption"].ToString();
                    playtime_lbl.Text = reader["playtime"].ToString();
                    year_lbl.Text = reader["year"].ToString();
                    language_lbl.Text = reader["language"].ToString();
                    director_lbl.Text = reader["director"].ToString();

                    actor1_name_lbl.Text = reader["actor1"].ToString();
                    string imagePath1 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\Upcoming\" + reader["name"].ToString() + @"\" + reader["actor1_img"].ToString();
                    Image image1 = Image.FromFile(imagePath1);
                    actor1_pic_lbl.Image = image1;

                    actor2_name_lbl.Text = reader["actor2"].ToString();
                    string imagePath2 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\Upcoming\" + reader["name"].ToString() + @"\" + reader["actor2_img"].ToString();
                    Image image2 = Image.FromFile(imagePath2);
                    actor2_pic_lbl.Image = image2;

                    actor3_name_lbl.Text = reader["actor3"].ToString();
                    string imagePath3 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\Upcoming\" + reader["name"].ToString() + @"\" + reader["actor3_img"].ToString();
                    Image image3 = Image.FromFile(imagePath3);
                    actor3_pic_lbl.Image = image3;

                    actor4_name_lbl.Text = reader["actor4"].ToString();
                    string imagePath4 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\Upcoming\" + reader["name"].ToString() + @"\" + reader["actor4_img"].ToString();
                    Image image4 = Image.FromFile(imagePath4);
                    actor4_pic_lbl.Image = image4;

                    // hiding show time for upcoming movies

                    guna2Button1.Visible = false;
                    movie_name_lbl2.Visible = false;
                    guna2Button2.Visible = false;
                    guna2Button3.Visible = false;
                    guna2Button4.Visible = false;
                    auditorium_1_type.Visible = false;
                    auditorium_2_type.Visible = false;
                    screening_time1.Visible = false;
                    screening_time2.Visible = false;
                    screening_time3.Visible = false;
                    screening_time4.Visible = false;
                    guna2ContainerControl1.Visible = false;
                    guna2ContainerControl2.Visible = false;


                }
            }

            else if (tabControl1.SelectedTab == search_tab)
            {

                cn.Close();
                cn.Open();

                SqlCommand cmd = new SqlCommand("select* from Movie where Branch_id = '" + branch_id + "' and Movie_id = '" + movieId + "'  and State='current' ", cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id.Text = reader["Movie_id"].ToString();
                    movie_name_lbl1.Text = reader["name"].ToString();
                    parent_guide_lbl.Text = reader["parent_guide"].ToString();

                    string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["poster"].ToString();
                    Image image = Image.FromFile(imagePath);
                    guna2PictureBox6.Image = image;


                    var embed = "<html><head>" +
                    "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
                    "</head><body>" +
                    "<iframe width=\"883\" height=\"581\" src=\"{0}\"" +
                    "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
                    "</body></html>";

                    this.movie_trailer_lbl.DocumentText = string.Format(embed, reader["trailer_link"].ToString());


                    genres_lbl.Text = reader["genre1"].ToString() + ", " + reader["genre2"].ToString() + ", " + reader["genre3"].ToString();
                    label15.Text = reader["discerption"].ToString();
                    playtime_lbl.Text = reader["playtime"].ToString();
                    year_lbl.Text = reader["year"].ToString();
                    language_lbl.Text = reader["language"].ToString();
                    director_lbl.Text = reader["director"].ToString();

                    actor1_name_lbl.Text = reader["actor1"].ToString();
                    string imagePath1 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["actor1_img"].ToString();
                    Image image1 = Image.FromFile(imagePath1);
                    actor1_pic_lbl.Image = image1;

                    actor2_name_lbl.Text = reader["actor2"].ToString();
                    string imagePath2 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["actor2_img"].ToString();
                    Image image2 = Image.FromFile(imagePath2);
                    actor2_pic_lbl.Image = image2;

                    actor3_name_lbl.Text = reader["actor3"].ToString();
                    string imagePath3 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["actor3_img"].ToString();
                    Image image3 = Image.FromFile(imagePath3);
                    actor3_pic_lbl.Image = image3;

                    actor4_name_lbl.Text = reader["actor4"].ToString();
                    string imagePath4 = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["actor4_img"].ToString();
                    Image image4 = Image.FromFile(imagePath4);
                    actor4_pic_lbl.Image = image4;

                    // name at show time
                    movie_name_lbl2.Text = reader["name"].ToString() + " - Showtimes";

                }
                cn.Close();



                guna2Button1.Visible = true;
                movie_name_lbl2.Visible = true;

                guna2Button2.Visible = true;
                guna2Button3.Visible = true;
                guna2Button4.Visible = true;
                auditorium_1_type.Visible = true;
                auditorium_2_type.Visible = true;
                screening_time1.Visible = true;
                screening_time2.Visible = true;
                screening_time3.Visible = true;
                screening_time4.Visible = true;
                guna2ContainerControl1.Visible = true;
                guna2ContainerControl2.Visible = true;
                cn.Close();
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("select DISTINCT top 1 date1 from Screening where Movie_id = '" + movieId + "'", cn);
                reader = cmd1.ExecuteReader();
                while (reader.Read())
                {

                    guna2Button2.Text = reader["date1"].ToString();
                }
                cn.Close();

                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select distinct date1 from Screening where Movie_id ='" + movieId + "' ORDER BY date1 OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
                reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //screen_id2.Text = reader["screen_id"].ToString();
                    guna2Button3.Text = reader["date1"].ToString();
                }

                cn.Close();

                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select distinct date1 from Screening where Movie_id ='" + movieId + "' ORDER BY date1 OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
                reader = cmd3.ExecuteReader();
                while (reader.Read())
                {
                    //screen_id3.Text = reader["screen_id"].ToString();
                    guna2Button4.Text = reader["date1"].ToString();
                }

                cn.Close();



                cn.Open();

                SqlCommand cmd4 = new SqlCommand("select DISTINCT top 1 Auditorium_name from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id='" + branch_id + "' and Movie_id = '" + id.Text + "' ", cn);
                reader = cmd4.ExecuteReader();
                while (reader.Read())
                {
                    auditorium_1_type.Text = reader["Auditorium_name"].ToString();

                }
                cn.Close();


                cn.Open();

                SqlCommand cmd5 = new SqlCommand("select DISTINCT Auditorium_name from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Movie_id = '" + id.Text + "' ORDER BY Auditorium_name OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY  ", cn);
                reader = cmd5.ExecuteReader();
                while (reader.Read())
                {
                    auditorium_2_type.Text = reader["Auditorium_name"].ToString();

                }
                cn.Close();

                cn.Open();

                SqlCommand cmd6 = new SqlCommand("select DISTINCT top 1 screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_1_type.Text + "' and Movie_id = '" + id.Text + "'", cn);
                reader = cmd6.ExecuteReader();
                while (reader.Read())
                {

                    screening_time1.Text = reader["screening_start"].ToString();

                }
                cn.Close();

                cn.Open();

                SqlCommand cmd7 = new SqlCommand("select DISTINCT screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id='" + branch_id + "' and Auditorium_name = '" + auditorium_1_type.Text + "' and Movie_id = '" + id.Text + "'  ORDER BY screening_start OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
                reader = cmd7.ExecuteReader();
                while (reader.Read())
                {

                    screening_time2.Text = reader["screening_start"].ToString();

                }
                cn.Close();


                cn.Open();

                SqlCommand cmd8 = new SqlCommand("select DISTINCT top 1 screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_2_type.Text + "' and Movie_id = '" + id.Text + "'", cn);
                reader = cmd8.ExecuteReader();
                while (reader.Read())
                {

                    screening_time3.Text = reader["screening_start"].ToString();

                }
                cn.Close();


                cn.Open();

                SqlCommand cmd9 = new SqlCommand("select DISTINCT screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_2_type.Text + "' and Movie_id = '" + id.Text + "'  ORDER BY screening_start OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
                reader = cmd9.ExecuteReader();
                while (reader.Read())
                {

                    screening_time4.Text = reader["screening_start"].ToString();

                }
                cn.Close();






                // screen_id for the movie at the first day

                cn.Open();
                SqlCommand cm1 = new SqlCommand("select top 1 screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "'", cn);
                reader = cm1.ExecuteReader();
                while (reader.Read())
                {

                    screen_id1.Text = reader["screen_id"].ToString();

                }
                cn.Close();


                cn.Open();
                SqlCommand cm2 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' ORDER BY screen_id OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY", cn);
                reader = cm2.ExecuteReader();
                while (reader.Read())
                {

                    screen_id2.Text = reader["screen_id"].ToString();

                }
                cn.Close();

                cn.Open();
                SqlCommand cm3 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' ORDER BY screen_id OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY", cn);
                reader = cm3.ExecuteReader();
                while (reader.Read())
                {

                    screen_id3.Text = reader["screen_id"].ToString();

                }
                cn.Close();


                cn.Open();
                SqlCommand cm4 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' ORDER BY screen_id OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY", cn);
                reader = cm4.ExecuteReader();
                while (reader.Read())
                {

                    screen_id4.Text = reader["screen_id"].ToString();

                }
                cn.Close();

                button2WasClicked = true;




            }

        }

        private void home_btn_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = home_tab;

        }

        private void whatson_btn_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = home_tab;

        }

        private void upcoming_btn_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = upcoming_tab;


        }

        private void aboutus_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = aboutus_tab;
        }

        private void Search_txt_IconRightClick(object sender, EventArgs e)
        {
            string branch_id = SelectedValue6;

            flowLayoutPanel3.Controls.Clear();
            tabControl1.SelectedTab = search_tab;

            cn.Close();
            cn.Open();
            // just add the next following lines 
            SqlCommand cmd = new SqlCommand("SELECT * FROM [HVcinemas].[dbo].[Movie] where Branch_id = '" + branch_id + "' and State='current' and name LIKE '%'  + @deceasedFirstName + '%' ", cn);
            cmd.Parameters.Add("@deceasedFirstName", SqlDbType.NVarChar).Value = Search_txt.Text;
            // and that`s it

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                movie_card movie_card = new movie_card();
                movie_card.card_language = reader["language"].ToString();
                string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["poster"].ToString();
                movie_card.MovieId = Convert.ToInt32(reader["movie_id"]);
                Image image = Image.FromFile(imagePath);
                pictureBox1.Image = image;
                movie_card.card_pos = pictureBox1.Image;
                movie_card.card_pg = reader["parent_guide"].ToString();
                movie_card.card_name = reader["name"].ToString();
                movie_card.card_genres = reader["genre1"].ToString() + ", " + reader["genre2"].ToString() + ", " + reader["genre3"].ToString();
                flowLayoutPanel3.Controls.Add(movie_card);
            }

            cn.Close();

            foreach (Control control in flowLayoutPanel3.Controls)
            {
                if (control is movie_card movieCard)
                {
                    movieCard.CardClicked += MovieCard_CardClicked;
                }
            }

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var embed = "<html><head>" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
            "</head><body>" +
            "<iframe width=\"883\" height=\"581\" src=\"{0}\"" +
            "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
            "</body></html>";
            var url = "https://www.youtube.com/embed/uYPbbksJxIg?si=4jJTkJuz0Iwf34q5";
            this.movie_trailer_lbl.DocumentText = string.Format(embed, url);
        }

        // select movies when loading
        private void Form1_Load(object sender, EventArgs e)
        {
            string valueFromLogin = SelectedValue;
            string valueFromLogin2 = SelectedValue2;
            string branch_id = SelectedValue6;
            user_txt.Text = valueFromLogin + " " + valueFromLogin2;
            first_name_txt.Text = SelectedValue;
            last_name_txt.Text = SelectedValue2;
            email_txt.Text = SelectedValue3;

            cn.Close() ;
            cn.Open();

            SqlCommand cmd = new SqlCommand("select * from [HVcinemas].[dbo].[Movie] where Branch_id = '" + branch_id + "' and State='current' ", cn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                movie_card movie_card = new movie_card();
                movie_card.card_language = reader["language"].ToString();
                string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["poster"].ToString();
                movie_card.MovieId = Convert.ToInt32(reader["movie_id"]);
                Image image = Image.FromFile(imagePath);
                pictureBox1.Image = image;
                movie_card.card_pos = pictureBox1.Image;
                movie_card.card_pg = reader["parent_guide"].ToString();
                movie_card.card_name = reader["name"].ToString();
                movie_card.card_genres = reader["genre1"].ToString() + ", " + reader["genre2"].ToString() + ", " + reader["genre3"].ToString();
                flowLayoutPanel1.Controls.Add(movie_card);
            }
            cn.Close();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is movie_card movieCard)
                {
                    movieCard.CardClicked += MovieCard_CardClicked;
                }
            }

            cn.Close();
            cn.Open();

            SqlCommand cmd2 = new SqlCommand("select* from [HVcinemas].[dbo].[Movie] where Branch_id = '" + branch_id + "' and State='upcoming' ", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {

                movie_card movie_card2 = new movie_card();
                movie_card2.card_language = reader2["language"].ToString();
                string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\Upcoming\" + reader2["name"].ToString() + @"\" + reader2["poster"].ToString();
                movie_card2.MovieId = Convert.ToInt32(reader2["movie_id"]);
                Image image = Image.FromFile(imagePath);
                pictureBox1.Image = image;
                movie_card2.card_pos = pictureBox1.Image;
                movie_card2.card_pg = reader2["parent_guide"].ToString();
                movie_card2.card_name = reader2["name"].ToString();
                movie_card2.card_genres = reader2["genre1"].ToString() + ", " + reader2["genre2"].ToString() + ", " + reader2["genre3"].ToString();
                flowLayoutPanel2.Controls.Add(movie_card2);
            }
            cn.Close();

            foreach (Control control in flowLayoutPanel2.Controls)
            {
                if (control is movie_card movieCard2)
                {
                    movieCard2.CardClicked += MovieCard_CardClicked;
                }
            }






        }

       

        private void guna2Button13_Click(object sender, EventArgs e)
        {

        }

        // button for showtime
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Control specificControl = guna2Button5;
            panel4.ScrollControlIntoView(specificControl);
        }


        private void guna2Button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = home_tab;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = upcoming_tab;
        }






        // varaibles to detect if the button is clicked or not
        public bool button2WasClicked = false;
        public bool button3WasClicked = false;
        public bool button4WasClicked = false;

        // the event of clicking the first date
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string branch_id = SelectedValue6;
            button2WasClicked = true;
            button3WasClicked = false;
            button4WasClicked = false;
            cn.Close();
            cn.Open();

            SqlCommand cmd = new SqlCommand("select DISTINCT top 1 Auditorium_name from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id='" + branch_id + "' and Movie_id = '" + id.Text + "' ", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                auditorium_1_type.Text = reader["Auditorium_name"].ToString();

            }
            cn.Close();


            cn.Open();

            SqlCommand cmd1 = new SqlCommand("select DISTINCT Auditorium_name from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id='" + branch_id + "' and Movie_id = '" + id.Text + "' ORDER BY Auditorium_name OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY  ", cn);
            reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                auditorium_2_type.Text = reader["Auditorium_name"].ToString();

            }
            cn.Close();

            cn.Open();

            SqlCommand cmd2 = new SqlCommand("select DISTINCT top 1 screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_1_type.Text + "' and Movie_id = '" + id.Text + "'", cn);
            reader = cmd2.ExecuteReader();
            while (reader.Read())
            {

                screening_time1.Text = reader["screening_start"].ToString();

            }
            cn.Close();

            cn.Open();

            SqlCommand cmd3 = new SqlCommand("select DISTINCT screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_1_type.Text + "' and Movie_id = '" + id.Text + "'  ORDER BY screening_start OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
            reader = cmd3.ExecuteReader();
            while (reader.Read())
            {

                screening_time2.Text = reader["screening_start"].ToString();

            }
            cn.Close();


            cn.Open();

            SqlCommand cmd4 = new SqlCommand("select DISTINCT top 1 screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_2_type.Text + "' and Movie_id = '" + id.Text + "'", cn);
            reader = cmd4.ExecuteReader();
            while (reader.Read())
            {

                screening_time3.Text = reader["screening_start"].ToString();

            }
            cn.Close();

            cn.Open();

            SqlCommand cmd5 = new SqlCommand("select DISTINCT screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button2.Text + "' and Branch_id='" + branch_id + "' and Auditorium_name = '" + auditorium_2_type.Text + "' and Movie_id = '" + id.Text + "'  ORDER BY screening_start OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
            reader = cmd5.ExecuteReader();
            while (reader.Read())
            {

                screening_time4.Text = reader["screening_start"].ToString();

            }
            cn.Close();



            // screen_id
            cn.Open();
            SqlCommand cm1 = new SqlCommand("select top 1 screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "'", cn);
            reader = cm1.ExecuteReader();
            while (reader.Read())
            {

                screen_id1.Text = reader["screen_id"].ToString();

            }
            cn.Close();


            cn.Open();
            SqlCommand cm2 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' ORDER BY screen_id OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY", cn);
            reader = cm2.ExecuteReader();
            while (reader.Read())
            {

                screen_id2.Text = reader["screen_id"].ToString();

            }
            cn.Close();

            cn.Open();
            SqlCommand cm3 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' ORDER BY screen_id OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY", cn);
            reader = cm3.ExecuteReader();
            while (reader.Read())
            {

                screen_id3.Text = reader["screen_id"].ToString();

            }
            cn.Close();


            cn.Open();
            SqlCommand cm4 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' ORDER BY screen_id OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY", cn);
            reader = cm4.ExecuteReader();
            while (reader.Read())
            {

                screen_id4.Text = reader["screen_id"].ToString();

            }
            cn.Close();



        }


        // the event of clicking the second date
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string branch_id = SelectedValue6;
            button3WasClicked = true;
            button2WasClicked = false;
            button4WasClicked = false;
            cn.Close();
            cn.Open();

            SqlCommand cmd = new SqlCommand("select DISTINCT top 1 Auditorium_name from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button3.Text + "' and Branch_id='" + branch_id + "' and Movie_id = '" + id.Text + "' ", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                auditorium_1_type.Text = reader["Auditorium_name"].ToString();

            }
            cn.Close();


            cn.Open();

            SqlCommand cmd1 = new SqlCommand("select DISTINCT Auditorium_name from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button3.Text + "' and Branch_id= '" + branch_id + "' and Movie_id = '" + id.Text + "' ORDER BY Auditorium_name OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY  ", cn);
            reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                auditorium_2_type.Text = reader["Auditorium_name"].ToString();

            }
            cn.Close();

            cn.Open();

            SqlCommand cmd2 = new SqlCommand("select DISTINCT top 1 screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button3.Text + "' and Branch_id='" + branch_id + "' and Auditorium_name = '" + auditorium_1_type.Text + "' and Movie_id = '" + id.Text + "'", cn);
            reader = cmd2.ExecuteReader();
            while (reader.Read())
            {

                screening_time1.Text = reader["screening_start"].ToString();

            }
            cn.Close();

            cn.Open();

            SqlCommand cmd3 = new SqlCommand("select DISTINCT screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button3.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_1_type.Text + "' and Movie_id = '" + id.Text + "'  ORDER BY screening_start OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
            reader = cmd3.ExecuteReader();
            while (reader.Read())
            {

                screening_time2.Text = reader["screening_start"].ToString();

            }
            cn.Close();


            cn.Open();

            SqlCommand cmd4 = new SqlCommand("select DISTINCT top 1 screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button3.Text + "' and Branch_id='" + branch_id + "' and Auditorium_name = '" + auditorium_2_type.Text + "' and Movie_id = '" + id.Text + "'", cn);
            reader = cmd4.ExecuteReader();
            while (reader.Read())
            {

                screening_time3.Text = reader["screening_start"].ToString();

            }
            cn.Close();

            cn.Open();

            SqlCommand cmd5 = new SqlCommand("select DISTINCT screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button3.Text + "' and Branch_id='" + branch_id + "' and Auditorium_name = '" + auditorium_2_type.Text + "' and Movie_id = '" + id.Text + "'  ORDER BY screening_start OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
            reader = cmd5.ExecuteReader();
            while (reader.Read())
            {

                screening_time4.Text = reader["screening_start"].ToString();

            }
            cn.Close();




            // screen_id
            cn.Open();
            SqlCommand cm1 = new SqlCommand("select top 1 screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button3.Text + "'", cn);
            reader = cm1.ExecuteReader();
            while (reader.Read())
            {

                screen_id5.Text = reader["screen_id"].ToString();

            }
            cn.Close();


            cn.Open();
            SqlCommand cm2 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button3.Text + "' ORDER BY screen_id OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY", cn);
            reader = cm2.ExecuteReader();
            while (reader.Read())
            {

                screen_id6.Text = reader["screen_id"].ToString();

            }
            cn.Close();

            cn.Open();
            SqlCommand cm3 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button3.Text + "' ORDER BY screen_id OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY", cn);
            reader = cm3.ExecuteReader();
            while (reader.Read())
            {

                screen_id7.Text = reader["screen_id"].ToString();

            }
            cn.Close();


            cn.Open();
            SqlCommand cm4 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button3.Text + "' ORDER BY screen_id OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY", cn);
            reader = cm4.ExecuteReader();
            while (reader.Read())
            {

                screen_id8.Text = reader["screen_id"].ToString();

            }
            cn.Close();



        }



        // the event of clicking the third date
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string branch_id = SelectedValue6;
            button4WasClicked = true;
            button2WasClicked = false;
            button3WasClicked = false;
            cn.Close() ;
            cn.Open();

            SqlCommand cmd = new SqlCommand("select DISTINCT top 1 Auditorium_name from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button4.Text + "' and Branch_id= '" + branch_id + "' and Movie_id = '" + id.Text + "' ", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                auditorium_1_type.Text = reader["Auditorium_name"].ToString();

            }
            cn.Close();


            cn.Open();

            SqlCommand cmd1 = new SqlCommand("select DISTINCT Auditorium_name from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button4.Text + "' and Branch_id= '" + branch_id + "' and Movie_id = '" + id.Text + "' ORDER BY Auditorium_name OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY  ", cn);
            reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                auditorium_2_type.Text = reader["Auditorium_name"].ToString();

            }
            cn.Close();

            cn.Open();

            SqlCommand cmd2 = new SqlCommand("select DISTINCT top 1 screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button4.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_1_type.Text + "' and Movie_id = '" + id.Text + "'", cn);
            reader = cmd2.ExecuteReader();
            while (reader.Read())
            {

                screening_time1.Text = reader["screening_start"].ToString();

            }
            cn.Close();

            cn.Open();

            SqlCommand cmd3 = new SqlCommand("select DISTINCT screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button4.Text + "' and Branch_id= '" + branch_id + "' and Auditorium_name = '" + auditorium_1_type.Text + "' and Movie_id = '" + id.Text + "'  ORDER BY screening_start OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
            reader = cmd3.ExecuteReader();
            while (reader.Read())
            {

                screening_time2.Text = reader["screening_start"].ToString();

            }
            cn.Close();


            cn.Open();

            SqlCommand cmd4 = new SqlCommand("select DISTINCT top 1 screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button4.Text + "' and Branch_id='" + branch_id + "' and Auditorium_name = '" + auditorium_2_type.Text + "' and Movie_id = '" + id.Text + "'", cn);
            reader = cmd4.ExecuteReader();
            while (reader.Read())
            {

                screening_time3.Text = reader["screening_start"].ToString();

            }
            cn.Close();

            cn.Open();

            SqlCommand cmd5 = new SqlCommand("select DISTINCT screening_start from Auditorium join Screening on Auditorium.Auditorium_id= Screening.Auditorium_id where date1 = '" + guna2Button4.Text + "' and Branch_id='" + branch_id + "' and Auditorium_name = '" + auditorium_2_type.Text + "' and Movie_id = '" + id.Text + "'  ORDER BY screening_start OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY ", cn);
            reader = cmd5.ExecuteReader();
            while (reader.Read())
            {

                screening_time4.Text = reader["screening_start"].ToString();

            }
            cn.Close();


            // screen_id
            cn.Open();
            SqlCommand cm1 = new SqlCommand("select top 1 screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button4.Text + "'", cn);
            reader = cm1.ExecuteReader();
            while (reader.Read())
            {

                screen_id9.Text = reader["screen_id"].ToString();

            }
            cn.Close();


            cn.Open();
            SqlCommand cm2 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button4.Text + "' ORDER BY screen_id OFFSET 1 ROWS FETCH NEXT 1 ROWS ONLY", cn);
            reader = cm2.ExecuteReader();
            while (reader.Read())
            {

                screen_id10.Text = reader["screen_id"].ToString();

            }
            cn.Close();

            cn.Open();
            SqlCommand cm3 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button4.Text + "' ORDER BY screen_id OFFSET 2 ROWS FETCH NEXT 1 ROWS ONLY", cn);
            reader = cm3.ExecuteReader();
            while (reader.Read())
            {

                screen_id11.Text = reader["screen_id"].ToString();

            }
            cn.Close();


            cn.Open();
            SqlCommand cm4 = new SqlCommand("select screen_id from Screening where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button4.Text + "' ORDER BY screen_id OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY", cn);
            reader = cm4.ExecuteReader();
            while (reader.Read())
            {

                screen_id12.Text = reader["screen_id"].ToString();

            }
            cn.Close();


        }




        // the event of choosing the first showtime
        private void screening_time1_Click(object sender, EventArgs e)
        {
            cn.Close();
            if (button2WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' and Auditorium_name ='" + auditorium_1_type.Text + "' and screening_start = '" + screening_time1.Text + "'", cn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    finalscreen_id1.Text = reader1["screen_id"].ToString();

                }

                cn.Close();
            }

            if (button3WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button3.Text + "' and Auditorium_name ='" + auditorium_1_type.Text + "' and screening_start = '" + screening_time1.Text + "'", cn);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {

                    finalscreen_id1.Text = reader2["screen_id"].ToString();

                }
                cn.Close();


            }
            if (button4WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button4.Text + "' and Auditorium_name ='" + auditorium_1_type.Text + "' and screening_start = '" + screening_time1.Text + "'", cn);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {

                    finalscreen_id1.Text = reader3["screen_id"].ToString();

                }
                cn.Close();


            }

            string selectedValue = finalscreen_id1.Text;
            string selectedValue2 = id.Text;
            Auditorium auditorium = new Auditorium();
            auditorium.SelectedValue = selectedValue;
            auditorium.SelectedValue2 = selectedValue2;
            auditorium.Show();

        }


        // the event of choosing the second showtime
        public void screening_time2_Click(object sender, EventArgs e)
        {

            cn.Close();
            if (button2WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' and Auditorium_name ='" + auditorium_1_type.Text + "' and screening_start = '" + screening_time2.Text + "'", cn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    finalscreen_id1.Text = reader1["screen_id"].ToString();

                }
                cn.Close();


            }

            if (button3WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button3.Text + "' and Auditorium_name ='" + auditorium_1_type.Text + "' and screening_start = '" + screening_time2.Text + "'", cn);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {

                    finalscreen_id1.Text = reader2["screen_id"].ToString();

                }
                cn.Close();


            }
            if (button4WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button4.Text + "' and Auditorium_name ='" + auditorium_1_type.Text + "' and screening_start = '" + screening_time2.Text + "'", cn);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {

                    finalscreen_id1.Text = reader3["screen_id"].ToString();

                }
                cn.Close();


            }
            string selectedValue = finalscreen_id1.Text;
            string selectedValue2 = id.Text;
            Auditorium auditorium = new Auditorium();
            auditorium.SelectedValue = selectedValue;
            auditorium.SelectedValue2 = selectedValue2;
            auditorium.Show();

        }


        // the event of choosing the third showtime
        public void screening_time3_Click(object sender, EventArgs e)
        {
            cn.Close();
            if (button2WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' and Auditorium_name ='" + auditorium_2_type.Text + "' and screening_start = '" + screening_time3.Text + "'", cn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    finalscreen_id1.Text = reader1["screen_id"].ToString();

                }
                cn.Close();


            }

            if (button3WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button3.Text + "' and Auditorium_name ='" + auditorium_2_type.Text + "' and screening_start = '" + screening_time3.Text + "'", cn);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {

                    finalscreen_id1.Text = reader2["screen_id"].ToString();

                }
                cn.Close();


            }
            if (button4WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button4.Text + "' and Auditorium_name ='" + auditorium_2_type.Text + "' and screening_start = '" + screening_time3.Text + "'", cn);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {

                    finalscreen_id1.Text = reader3["screen_id"].ToString();

                }
                cn.Close();



            }

            string selectedValue = finalscreen_id1.Text;
            string selectedValue2 = id.Text;
            Auditorium auditorium = new Auditorium();
            auditorium.SelectedValue = selectedValue;
            auditorium.SelectedValue2 = selectedValue2;
            auditorium.Show();

        }


        // the event of choosing the forth showtime
        public void screening_time4_Click(object sender, EventArgs e)
        {
            cn.Close();
            if (button2WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button2.Text + "' and Auditorium_name ='" + auditorium_2_type.Text + "' and screening_start = '" + screening_time4.Text + "'", cn);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {

                    finalscreen_id1.Text = reader1["screen_id"].ToString();

                }
                cn.Close();


            }

            if (button3WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button3.Text + "' and Auditorium_name ='" + auditorium_2_type.Text + "' and screening_start = '" + screening_time4.Text + "'", cn);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {

                    finalscreen_id1.Text = reader2["screen_id"].ToString();

                }
                cn.Close();


            }
            if (button4WasClicked == true)
            {
                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select screen_id from Screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where Movie_id = '" + id.Text + "' and date1 = '" + guna2Button4.Text + "' and Auditorium_name ='" + auditorium_2_type.Text + "' and screening_start = '" + screening_time4.Text + "'", cn);
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {

                    finalscreen_id1.Text = reader3["screen_id"].ToString();

                }
                cn.Close();
            }

            string selectedValue = finalscreen_id1.Text;
            string selectedValue2 = id.Text;
            Auditorium auditorium = new Auditorium();
            auditorium.SelectedValue = selectedValue;
            auditorium.SelectedValue2 = selectedValue2;
            auditorium.Show();

        }

        private void Search_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void account_btn_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = account_tab;
        }

        private void password_btn_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = password_tab;
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = profile_tab;
        }

        private void account_update_btn_Click(object sender, EventArgs e)
        {
            cn.Close();

            cn.Open();


            SqlCommand cmd = new SqlCommand("UPDATE Employee1 SET Fname = '" + first_name_txt.Text + "', Lname = '" + last_name_txt.Text + "', email='" + email_txt.Text + "' WHERE employee_id = '" + selectedValue4 + "';", cn);
            cmd.ExecuteNonQuery();

            SqlCommand cm = new SqlCommand("select * from Employee1 where employee_id='" + selectedValue4 + "' ", cn);
            SqlDataReader sd = cm.ExecuteReader();
            while (sd.Read())
            {
                first_name_txt.Text = sd["Fname"].ToString();
                last_name_txt.Text = sd["Lname"].ToString();
                user_txt.Text = sd["Fname"].ToString() + " " + sd["Lname"].ToString();
                email_txt.Text = sd["email"].ToString();
            }
            MessageBox.Show("updated!");
            cn.Close();

        }

        private void password_update_btn_Click(object sender, EventArgs e)
        {
            if (old_password_txt.Text == selectedValue5)
            {
                if (new_password_txt.Text == confirm_password_txt.Text)
                {
                    cn.Close();

                    cn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE Employee1 SET password = '" + new_password_txt.Text + "'  WHERE employee_id = '" + selectedValue4 + "';", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("updated!");
                }
                else
                {
                    MessageBox.Show("make sure you confirmed your password the right way");
                }
            }
            else
            {
                MessageBox.Show("wrong password");
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Close();

            Login ll = new Login();
            ll.Show();

        }

        
       

       
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string branch_id = SelectedValue6;

            if (comboBox1.SelectedIndex == 0)
            {
                cn.Close();
                cn.Open();

                SqlCommand cmd = new SqlCommand("select * from [HVcinemas].[dbo].[Movie] where Branch_id = '" + branch_id + "' and State='current' ORDER BY name ASC ", cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    movie_card movie_card = new movie_card();
                    movie_card.card_language = reader["language"].ToString();
                    string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["poster"].ToString();
                    movie_card.MovieId = Convert.ToInt32(reader["movie_id"]);
                    Image image = Image.FromFile(imagePath);
                    pictureBox1.Image = image;
                    movie_card.card_pos = pictureBox1.Image;
                    movie_card.card_pg = reader["parent_guide"].ToString();
                    movie_card.card_name = reader["name"].ToString();
                    movie_card.card_genres = reader["genre1"].ToString() + ", " + reader["genre2"].ToString() + ", " + reader["genre3"].ToString();
                    flowLayoutPanel1.Controls.Add(movie_card);
                }
                cn.Close();

                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is movie_card movieCard)
                    {
                        movieCard.CardClicked += MovieCard_CardClicked;
                    }
                }

                cn.Close();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                cn.Close();
                cn.Open();

                SqlCommand cmd = new SqlCommand("select * from [HVcinemas].[dbo].[Movie] where Branch_id = '" + branch_id + "' and State='current' ORDER BY name DESC ", cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    movie_card movie_card = new movie_card();
                    movie_card.card_language = reader["language"].ToString();
                    string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["poster"].ToString();
                    movie_card.MovieId = Convert.ToInt32(reader["movie_id"]);
                    Image image = Image.FromFile(imagePath);
                    pictureBox1.Image = image;
                    movie_card.card_pos = pictureBox1.Image;
                    movie_card.card_pg = reader["parent_guide"].ToString();
                    movie_card.card_name = reader["name"].ToString();
                    movie_card.card_genres = reader["genre1"].ToString() + ", " + reader["genre2"].ToString() + ", " + reader["genre3"].ToString();
                    flowLayoutPanel1.Controls.Add(movie_card);
                }
                cn.Close();

                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is movie_card movieCard)
                    {
                        movieCard.CardClicked += MovieCard_CardClicked;
                    }
                }

                cn.Close();
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            flowLayoutPanel1.Controls.Clear();

            string branch_id = SelectedValue6;

            if (guna2ComboBox1.SelectedIndex == 0)
            {
                cn.Close();
                cn.Open();

                SqlCommand cmd = new SqlCommand("select * from [HVcinemas].[dbo].[Movie] where Branch_id = '" + branch_id + "' and State='current'  ", cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    movie_card movie_card = new movie_card();
                    movie_card.card_language = reader["language"].ToString();
                    string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["poster"].ToString();
                    movie_card.MovieId = Convert.ToInt32(reader["movie_id"]);
                    Image image = Image.FromFile(imagePath);
                    pictureBox1.Image = image;
                    movie_card.card_pos = pictureBox1.Image;
                    movie_card.card_pg = reader["parent_guide"].ToString();
                    movie_card.card_name = reader["name"].ToString();
                    movie_card.card_genres = reader["genre1"].ToString() + ", " + reader["genre2"].ToString() + ", " + reader["genre3"].ToString();
                    flowLayoutPanel1.Controls.Add(movie_card);
                }
                cn.Close();

                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is movie_card movieCard)
                    {
                        movieCard.CardClicked += MovieCard_CardClicked;
                    }
                }

                cn.Close();
            }
            else if (guna2ComboBox1.SelectedIndex == 1)
            {
                cn.Close();
                cn.Open();

                SqlCommand cmd = new SqlCommand("select * from [HVcinemas].[dbo].[Movie] where Branch_id = '" + branch_id + "' and State='current' ORDER BY name ASC ", cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    movie_card movie_card = new movie_card();
                    movie_card.card_language = reader["language"].ToString();
                    string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["poster"].ToString();
                    movie_card.MovieId = Convert.ToInt32(reader["movie_id"]);
                    Image image = Image.FromFile(imagePath);
                    pictureBox1.Image = image;
                    movie_card.card_pos = pictureBox1.Image;
                    movie_card.card_pg = reader["parent_guide"].ToString();
                    movie_card.card_name = reader["name"].ToString();
                    movie_card.card_genres = reader["genre1"].ToString() + ", " + reader["genre2"].ToString() + ", " + reader["genre3"].ToString();
                    flowLayoutPanel1.Controls.Add(movie_card);
                }
                cn.Close();

                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is movie_card movieCard)
                    {
                        movieCard.CardClicked += MovieCard_CardClicked;
                    }
                }

                cn.Close();
            }
            else if (guna2ComboBox1.SelectedIndex == 2)
            {
                cn.Close();
                cn.Open();

                SqlCommand cmd = new SqlCommand("select * from [HVcinemas].[dbo].[Movie] where Branch_id = '" + branch_id + "' and State='current' ORDER BY name DESC ", cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    movie_card movie_card = new movie_card();
                    movie_card.card_language = reader["language"].ToString();
                    string imagePath = @"D:\asma\computers and information\Third year IS\First term\HollyView cenimas\MOVIES data\current\" + reader["name"].ToString() + @"\" + reader["poster"].ToString();
                    movie_card.MovieId = Convert.ToInt32(reader["movie_id"]);
                    Image image = Image.FromFile(imagePath);
                    pictureBox1.Image = image;
                    movie_card.card_pos = pictureBox1.Image;
                    movie_card.card_pg = reader["parent_guide"].ToString();
                    movie_card.card_name = reader["name"].ToString();
                    movie_card.card_genres = reader["genre1"].ToString() + ", " + reader["genre2"].ToString() + ", " + reader["genre3"].ToString();
                    flowLayoutPanel1.Controls.Add(movie_card);
                }
                cn.Close();

                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is movie_card movieCard)
                    {
                        movieCard.CardClicked += MovieCard_CardClicked;
                    }
                }

                cn.Close();
            }

        }
    }
}
