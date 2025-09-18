using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace Holly_View
{
    public partial class Confirm : Form
    {
        public Confirm()
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




        private void account_update_btn_Click(object sender, EventArgs e)
        {
            string senderEmail = "holly.view.cinemas@gmail.com";
            string senderPassword = "qvvvdxjpikjajpca";
            string recipientEmail = user_email.Text;

            MailMessage mail = new MailMessage(senderEmail, recipientEmail)
            {
                Subject = "Holly View",
                Body = ""
            };

            string imagePath = @"C:\Users\assma\OneDrive\Desktop\ticket3.jpg";
            Image image = Image.FromFile(imagePath);

            // Manipulate the image here (e.g., add text)
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.DrawString("Name:'"+selectedValue+"'\nTime:'"+selectedValue2+"'\nAuditurim:'"+selectedValue3+"'\nSeat:'"+selectedValue5+"'\nPrice:'"+selectedValue4+"'", new Font("Arial", 12), Brushes.Black, new PointF(100, 30));
            }

            // Save the manipulated image to your PC
            string saveImagePath = @"C:\Users\assma\OneDrive\Desktop\tic\'"+selectedValue+"'.jpg";
            image.Save(saveImagePath);

            // Attach the saved image to the email
            Attachment attachment = new Attachment(saveImagePath);
            mail.Attachments.Add(attachment);

            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true
            };

            try
            {
                // Send the email
                smtp.Send(mail);

                

                if (DialogResult.OK == MessageBox.Show("Email sent successfully, and image saved!"))
                {
                    
                    this.Close();
                }
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                 if (DialogResult.OK == MessageBox.Show("Email sent successfully, and image saved!"))
                 {
                    
                    this.Close();
                }
            }
            finally
            {
                mail.Dispose();
                smtp.Dispose();
                image.Dispose();

               

            }

            

        }
    }
}
