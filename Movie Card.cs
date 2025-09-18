using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Holly_View
{
    public partial class movie_card : UserControl
    {
        public event EventHandler CardClicked;
        public movie_card()
        {
            InitializeComponent();

        }

        private int _movieId;

        public int MovieId
        {
            get { return _movieId; }
            set { _movieId = value; }
        }

        public Image card_pos
        {
            get
            {
                return movie_pos_pic.Image;
            }
            set
            {
                movie_pos_pic.Image = value;
            }
        }
        public string card_pg
        {
            get
            {
                return movie_pos_pg.Text;
            }
            set
            {
                movie_pos_pg.Text = value;
            }
        }
        public string card_name
        {
            get
            {
                return movie_pos_name.Text;
            }
            set
            {
                movie_pos_name.Text = value;
            }
        }
        public string card_language
        {
            get
            {
                return movie_pos_language.Text;
            }
            set
            {
                movie_pos_language.Text = value;
            }
        }
        public string card_genres
        {
            get
            {
                return movie_pos_genres.Text;
            }
            set
            {
                movie_pos_genres.Text = value;
            }
        }

        private void movie_pos_pic_Click(object sender, EventArgs e)
        {
            // Raise the custom CardClicked event when the picture is clicked
            CardClicked?.Invoke(this, EventArgs.Empty);
        }


    }
}
