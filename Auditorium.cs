using Guna.UI2.WinForms;
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

namespace Holly_View
{
    public partial class Auditorium : Form
    {

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-KNJIE9E;Initial Catalog=HVcinemas;Integrated Security=True");

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
        public Auditorium()
        {
            InitializeComponent();

            
        }

        private void Auditorium_Load(object sender, EventArgs e)
        {
            // Access the selected value here
            string valueFromForm1 = SelectedValue;
            string valueFromForm12 = SelectedValue2;

            // Do something with the value
            // For example, display it in a label on Form2
            screen_id.Text = valueFromForm1;

            cn.Close();
            cn.Open();
            SqlCommand cmd0 = new SqlCommand("select* from Movie where Movie_id = '" + valueFromForm12 + "'  and State='current' ", cn);
            SqlDataReader reader0 = cmd0.ExecuteReader();

            while(reader0.Read())
            {
                label1.Text = reader0["name"].ToString();
            }
            cn.Close();


            cn.Open();
            SqlCommand cmd01 = new SqlCommand("select* from screening join Auditorium on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' ", cn);
            SqlDataReader reader01 = cmd01.ExecuteReader();

            while (reader01.Read())
            {
                label2.Text = reader01["screening_start"].ToString() + ","/* + reader01["date1"].ToString()*/;
                label3.Text = reader01["Auditorium_name"].ToString();
            }
            cn.Close();

            // selecting the seats

            cn.Close();
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("select top 1* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '"+screen_id.Text+"' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"') UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id = '"+screen_id.Text+"')AS combined_result ORDER BY seat_id;", cn);
            SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {

                A1.Text = reader["state"].ToString();
                label12.Text = reader["seat_id"].ToString();
                Price.Text = reader["price"].ToString();

                if (A1.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    A1.Image = image;
                    A1.Enabled = false;
                }
                else 
                {
                    A1.Enabled = true;
                }
            }
            cn.Close();

            cn.Open();
            SqlCommand cmd2 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '"+screen_id.Text+ "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text+"')AS combined_result ORDER BY seat_id OFFSET 1 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {

                A2.Text = reader2["state"].ToString();
                label13.Text = reader2["seat_id"].ToString();
                Price.Text = reader2["price"].ToString();

                if (A2.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    A2.Image = image;
                    A2.Enabled = false;
                }
                else
                {
                   
                    A2.Enabled = true;
                }
            }
            cn.Close();


            cn.Open();
            SqlCommand cmd3 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 2 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {

                A3.Text = reader3["state"].ToString();
                label14.Text = reader3["seat_id"].ToString();
                Price.Text = reader3["price"].ToString();

                if (A3.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    A3.Image = image;
                    A3.Enabled = false;
                }
                else
                {
                    A3.Enabled = true;
                }
            }
            cn.Close();


            cn.Open();
            SqlCommand cmd4 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 3 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader4 = cmd4.ExecuteReader();
            while (reader4.Read())
            {

                A4.Text = reader4["state"].ToString();
                label15.Text = reader4["seat_id"].ToString();
                Price.Text = reader4["price"].ToString();

                if (A4.Text == "not available")
                {

                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    A4.Image = image;
                    A4.Enabled = false;
                }
                else
                {
                    
                    A4.Enabled = true;
                }

            }
            cn.Close();

            cn.Open();
            SqlCommand cmd5 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 4 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader5 = cmd5.ExecuteReader();
            while (reader5.Read())
            {

                A5.Text = reader5["state"].ToString();
                label16.Text = reader5["seat_id"].ToString();
                Price.Text = reader5["price"].ToString();

                if (A5.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    A5.Image = image;
                    A5.Enabled = false;
                }
                else
                {
                   
                    A5.Enabled = true;
                }
            }
            cn.Close();

            //B
            cn.Open();
            SqlCommand cmd6 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 5 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader6 = cmd6.ExecuteReader();
            while (reader6.Read())
            {

                B1.Text = reader6["state"].ToString();
                label17.Text = reader6["seat_id"].ToString();
                Price.Text = reader6["price"].ToString();

                if (B1.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    B1.Image = image;
                    B1.Enabled = false;
                }
                else
                {
                   
                    B1.Enabled = true;
                }
            }
            cn.Close();

            cn.Open();
            SqlCommand cmd7 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 6 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader7 = cmd7.ExecuteReader();
            while (reader7.Read())
            {

                B2.Text = reader7["state"].ToString();
                label18.Text = reader7["seat_id"].ToString();
                Price.Text = reader7["price"].ToString();

                if (B2.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    B2.Image = image;
                    B2.Enabled = false;
                }
                else
                {
                   
                    B2.Enabled = true;
                }
            }
            cn.Close();


            cn.Open();
            SqlCommand cmd8 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 7 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader8 = cmd8.ExecuteReader();
            while (reader8.Read())
            {

                B3.Text = reader8["state"].ToString();
                label19.Text = reader8["seat_id"].ToString();
                Price.Text = reader8["price"].ToString();

                if (B3.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    B3.Image = image;
                    B3.Enabled = false;
                }
                else
                {
                    B3.Enabled = true;
                }
            }
            cn.Close();


            cn.Open();
            SqlCommand cmd9 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 8 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader9 = cmd9.ExecuteReader();
            while (reader9.Read())
            {

                B4.Text = reader9["state"].ToString();
                label20.Text = reader9["seat_id"].ToString();
                Price.Text = reader9["price"].ToString();

                if (B4.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    B4.Image = image;
                    B4.Enabled = false;
                }
                else
                {
                   
                    B4.Enabled = true;
                }
            }
            cn.Close();


            cn.Open();
            SqlCommand cmd10 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 9 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader10 = cmd10.ExecuteReader();
            while (reader10.Read())
            {

                B5.Text = reader10["state"].ToString();
                label21.Text = reader10["seat_id"].ToString();
                Price.Text = reader10["price"].ToString();

                if (B5.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    B5.Image = image;
                    B5.Enabled = false;
                }
                else
                {
                    
                    B5.Enabled = true;
                }
            }
            cn.Close();

            // C

            cn.Open();
            SqlCommand cmd11 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 10 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader11 = cmd11.ExecuteReader();
            while (reader11.Read())
            {

                C1.Text = reader11["state"].ToString();
                label22.Text = reader11["seat_id"].ToString();
                Price.Text = reader11["price"].ToString();

                if (C1.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    C1.Image = image;
                    C1.Enabled = false;
                }
                else
                {
                   
                    C1.Enabled = true;
                }
            }
            cn.Close();


            cn.Open();
            SqlCommand cmd12 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 11 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader12 = cmd12.ExecuteReader();
            while (reader12.Read())
            {

                C2.Text = reader12["state"].ToString();
                label23.Text = reader12["seat_id"].ToString();
                Price.Text = reader12["price"].ToString();

                if (C2.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    C2.Image = image;
                    C2.Enabled = false;
                }
                else
                {
                    
                    C2.Enabled = true;
                }
            }
            cn.Close();


            cn.Open();
            SqlCommand cmd13 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 12 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader13 = cmd13.ExecuteReader();
            while (reader13.Read())
            {

                C3.Text = reader13["state"].ToString();
                label24.Text = reader13["seat_id"].ToString();
                Price.Text = reader13["price"].ToString();

                if (C3.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    C3.Image = image;
                    C3.Enabled = false;
                }
                else
                {
                    
                    C3.Enabled = true;
                }
            }
            cn.Close();

            cn.Open();
            SqlCommand cmd14 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 13 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader14 = cmd14.ExecuteReader();
            while (reader14.Read())
            {

                C4.Text = reader14["state"].ToString();
                label25.Text = reader14["seat_id"].ToString();
                Price.Text = reader14["price"].ToString();

                if (C4.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    C4.Image = image;
                    C4.Enabled = false;
                }
                else
                {
                    
                    C4.Enabled = true;
                }
            }
            cn.Close();

            cn.Open();
            SqlCommand cmd15 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 14 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader15 = cmd15.ExecuteReader();
            while (reader15.Read())
            {

                C5.Text = reader15["state"].ToString();
                label26.Text = reader15["seat_id"].ToString();
                Price.Text = reader15["price"].ToString();

                if (C5.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    C5.Image = image;
                    C5.Enabled = false;
                }
                else
                {
                  
                    C5.Enabled = true;
                }
            }
            cn.Close();

            // D1
            cn.Open();
            SqlCommand cmd16 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 15 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader16 = cmd16.ExecuteReader();
            while (reader16.Read())
            {

                D1.Text = reader16["state"].ToString();
                label27.Text = reader16["seat_id"].ToString();
                Price.Text = reader16["price"].ToString();

                if (D1.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    D1.Image = image;
                    D1.Enabled = false;
                }
                else
                {
                   
                    D1.Enabled = true;
                }
            }
            cn.Close();

            cn.Open();
            SqlCommand cmd17 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 16 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader17 = cmd17.ExecuteReader();
            while (reader17.Read())
            {

                D2.Text = reader17["state"].ToString();
                label28.Text = reader17["seat_id"].ToString();
                Price.Text = reader17["price"].ToString();

                if (D2.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    D2.Image = image;
                    D2.Enabled = false;
                }
                else
                {
                   
                    D2.Enabled = true;
                }
            }
            cn.Close();


            cn.Open();
            SqlCommand cmd18 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id ='"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 17 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader18 = cmd18.ExecuteReader();
            while (reader18.Read())
            {

                D3.Text = reader18["state"].ToString();
                label29.Text = reader18["seat_id"].ToString();
                Price.Text = reader18["price"].ToString();

                if (D3.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    D3.Image = image;
                    D3.Enabled = false;
                }
                else
                {
                    
                    D3.Enabled = true;
                }
            }
            cn.Close();

            cn.Open();
            SqlCommand cmd19 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 18 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader19 = cmd19.ExecuteReader();
            while (reader19.Read())
            {

                D4.Text = reader19["state"].ToString();
                label30.Text = reader19["seat_id"].ToString();
                Price.Text = reader19["price"].ToString();

                if (D4.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    D4.Image = image;
                    D4.Enabled = false;
                }
                else
                {
                    
                    D4.Enabled = true;
                }
            }
            cn.Close();

            cn.Open();
            SqlCommand cmd20 = new SqlCommand("select* from(select seat_id,screen_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id not in(select seat_id from SeatReserved where screen_id = '"+screen_id.Text+"')UNION select seat_id,screen_id,state,price from SeatReserved  where screen_id ='" + screen_id.Text + "')AS combined_result ORDER BY seat_id OFFSET 19 ROW FETCH NEXT 1 ROW ONLY;", cn);
            SqlDataReader reader20 = cmd20.ExecuteReader();
            while (reader20.Read())
            {

                D5.Text = reader20["state"].ToString();
                label31.Text = reader20["seat_id"].ToString();
                Price.Text = reader20["price"].ToString();

                if (D5.Text == "not available")
                {
                    string imagePath = @"C:\Users\assma\OneDrive\Desktop\HV104\Holly View\Holly View\images\seat3.png";
                    Image image = Image.FromFile(imagePath);
                    D5.Image = image;
                    D5.Enabled = false;
                }
                else
                {
                    
                    D5.Enabled = true;
                }
            }
            cn.Close();




        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {
            int count = 0;

            if(A1.Checked) 
            {
                cn.Close();
                cn.Open();
                SqlCommand cd1 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '"+screen_id.Text+"' and seat_id = '"+label12.Text+"'", cn);
                cd1.ExecuteNonQuery();
                cn.Close();

                cn.Open ();
                SqlCommand cmd1 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '"+label12.Text+"' and screen_id = '"+ screen_id.Text + "'", cn);
                cmd1.ExecuteNonQuery();
                cn.Close() ;

                Seat.Text = A1.Name+",";
                count += 1;
            }

            if (A2.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd2 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label13.Text + "'", cn);
                cd2.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd2 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label13.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd2.ExecuteNonQuery();
                cn.Close();

                Seat.Text += A2.Name + ",";
                count += 1;
            }

            if (A3.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd3 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label14.Text + "'", cn);
                cd3.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label14.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd3.ExecuteNonQuery();
                cn.Close();

                Seat.Text += A3.Name + ",";
                count += 1;
            }

            if (A4.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd4 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label15.Text + "'", cn);
                cd4.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd4 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label15.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd4.ExecuteNonQuery();
                cn.Close();

                Seat.Text += A4.Name + ",";
                count += 1;

            }

            if (A5.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd5 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label16.Text + "'", cn);
                cd5.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd5 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label16.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd5.ExecuteNonQuery();
                cn.Close();

                Seat.Text += A5.Name + ",";
                count += 1;

            }

            if (B1.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd6 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label17.Text + "'", cn);
                cd6.ExecuteNonQuery();
                cn.Close();
                cn.Open();
                SqlCommand cmd6 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label17.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd6.ExecuteNonQuery();
                cn.Close();

                Seat.Text += B1.Name + ",";
                count += 1;

            }

            if (B2.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd7 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label18.Text + "'", cn);
                cd7.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd7 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label18.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd7.ExecuteNonQuery();
                cn.Close();

                Seat.Text += B2.Name + ",";
                count += 1;

            }

            if (B3.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd8 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label19.Text + "'", cn);
                cd8.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd8 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label19.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd8.ExecuteNonQuery();
                cn.Close();

                Seat.Text += B3.Name + ",";
                count += 1;

            }

            if (B4.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd9 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label20.Text + "'", cn);
                cd9.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd9 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label20.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd9.ExecuteNonQuery();
                cn.Close();

                Seat.Text += B4.Name + ",";
                count += 1;

            }

            if (B5.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd10 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label21.Text + "'", cn);
                cd10.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd10 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label21.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd10.ExecuteNonQuery();
                cn.Close();

                Seat.Text += B5.Name + ",";
                count += 1;

            }

            if (C1.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd11 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label22.Text + "'", cn);
                cd11.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd11 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label22.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd11.ExecuteNonQuery();
                cn.Close();

                Seat.Text += C1.Name + ",";
                count += 1;

            }

            if (C2.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd12 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label23.Text + "'", cn);
                cd12.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd12 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label23.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd12.ExecuteNonQuery();
                cn.Close();

                Seat.Text += C2.Name + ",";
                count += 1;

            }

            if (C3.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd13 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label24.Text + "'", cn);
                cd13.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd13 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label24.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd13.ExecuteNonQuery();
                cn.Close();

                Seat.Text += C3.Name + ",";
                count += 1;

            }

            if (C4.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd14 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label25.Text + "'", cn);
                cd14.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd14 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label25.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd14.ExecuteNonQuery();
                cn.Close();

                Seat.Text += C4.Name + ",";
                count += 1;

            }

            if (C5.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd15 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label26.Text + "'", cn);
                cd15.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd15 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label26.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd15.ExecuteNonQuery();
                cn.Close();

                Seat.Text += C5.Name + ",";
                count += 1;

            }

            if (D1.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd16 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label27.Text + "'", cn);
                cd16.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd16 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label27.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd16.ExecuteNonQuery();
                cn.Close();

                Seat.Text += D1.Name + ",";
                count += 1;

            }

            if (D2.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd17 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label28.Text + "'", cn);
                cd17.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd17 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label28.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd17.ExecuteNonQuery();
                cn.Close();

                Seat.Text += D2.Name + ",";
                count += 1;


            }


            if (D3.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd18 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label29.Text + "'", cn);
                cd18.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd18 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label29.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd18.ExecuteNonQuery();
                cn.Close();

                Seat.Text += D3.Name + ",";
                count += 1;

            }

            if (D4.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd19 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label30.Text + "'", cn);
                cd19.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd19 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label30.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd19.ExecuteNonQuery();
                cn.Close();

                Seat.Text += D4.Name + ",";
                count += 1;

            }

            if (D5.Checked)
            {
                cn.Close();

                cn.Open();
                SqlCommand cd20 = new SqlCommand("insert into SeatReserved(screen_id,seat_id,state,price) select screen_id,seat_id,state,price from Auditorium join Seat on Seat.Auditorium_id=Auditorium.Auditorium_id join Screening on Screening.Auditorium_id = Auditorium.Auditorium_id where screen_id = '" + screen_id.Text + "' and seat_id = '" + label31.Text + "'", cn);
                cd20.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd20 = new SqlCommand("update SeatReserved set state ='not available' where seat_id = '" + label31.Text + "' and screen_id = '" + screen_id.Text + "'", cn);
                cmd20.ExecuteNonQuery();
                cn.Close();

                Seat.Text += D5.Name + ",";
                count += 1;

            }

            int total_price = (int.Parse(Price.Text))*count;
            Price.Text = total_price.ToString();
            string sel1 = label1.Text;
            string sel2 = label2.Text;
            string sel3 = label3.Text;
            string sel4 = Price.Text;
            string sel5 = Seat.Text;

            Confirm confirm = new Confirm();
            confirm.SelectedValue = sel1;
            confirm.SelectedValue2 = sel2;
            confirm.SelectedValue3 = sel3;
            confirm.SelectedValue4 = sel4;
            confirm.SelectedValue5 = sel5;

            //MessageBox.Show("price:" + Price.Text+ "  Seat:"+ Seat.Text);
            
            
            confirm.Show();
        }
    }

   
}
