using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borwell_Project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void Main_Load(object sender, EventArgs e)
        {
            //Setting window size, position on screen and colour
            this.Size = new Size(1200, 600);
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.BackColor = Color.DeepSkyBlue;

            //Creating a heading for the form
            Label heading = new Label();
            heading.AutoSize = true;
            heading.Text = "Paint Calculator";
            heading.Font = new Font("Calibri (Body)", 40, FontStyle.Bold);
            heading.Location = new Point(400, 25);
            heading.ForeColor = Color.Black;
            heading.BackColor = Color.Transparent;
            this.Controls.Add(heading);

            //Creating a sub-heading with user instructions
            Label subheading = new Label();
            subheading.AutoSize = true;
            subheading.Text = "Please enter the following dimensions in meters:";
            subheading.Font = new Font("Calibri (Body)", 20);
            subheading.Location = new Point(325, 125);
            subheading.ForeColor = Color.Black;
            subheading.BackColor = Color.Transparent;
            this.Controls.Add(subheading);

            //Creating an input box for room width.
            TextBox roomWidth = new TextBox();
            roomWidth.Text = "0";
            Program.width = float.Parse(roomWidth.Text);
            roomWidth.Height = 20;
            roomWidth.MaxLength = 100;
            roomWidth.Font = new Font("Calibri (Body)", 15, FontStyle.Bold);
            roomWidth.Location = new Point(600, 200);
            roomWidth.ForeColor = Color.Black;
            roomWidth.BackColor = Color.LightGray;
            roomWidth.KeyPress += new KeyPressEventHandler(validation_KeyPress);
            this.Controls.Add(roomWidth);

            //Creating an input box for room height.
            TextBox roomHeight = new TextBox();
            roomHeight.Text = "0";
            Program.height = float.Parse(roomHeight.Text);
            roomHeight.Height = 20;
            roomHeight.MaxLength = 100;
            roomHeight.Font = new Font("Calibri (Body)", 15, FontStyle.Bold);
            roomHeight.Location = new Point(600, 250);
            roomHeight.ForeColor = Color.Black;
            roomHeight.BackColor = Color.LightGray;
            roomHeight.KeyPress += new KeyPressEventHandler(validation_KeyPress);
            this.Controls.Add(roomHeight);

            //Creating an input box for room length.
            TextBox roomLength = new TextBox();
            roomLength.Text = "0";
            Program.length = float.Parse(roomLength.Text);
            roomLength.Height = 20;
            roomLength.MaxLength = 100;
            roomLength.Font = new Font("Calibri (Body)", 15, FontStyle.Bold);
            roomLength.Location = new Point(600, 300);
            roomLength.ForeColor = Color.Black;
            roomLength.BackColor = Color.LightGray;
            roomLength.KeyPress += new KeyPressEventHandler(validation_KeyPress);
            this.Controls.Add(roomLength);

            //Creating a label that will appear next to the room width input box
            Label widthLabel = new Label();
            widthLabel.AutoSize = true;
            widthLabel.Text = "Width:";
            widthLabel.Font = new Font("Calibri (Body)", 15, FontStyle.Bold);
            widthLabel.Location = new Point(525, 200);
            widthLabel.ForeColor = Color.Black;
            widthLabel.BackColor = Color.Transparent;
            this.Controls.Add(widthLabel);

            //Creating a label that will appear next to the room height input box
            Label heightLabel = new Label();
            heightLabel.AutoSize = true;
            heightLabel.Text = "Height:";
            heightLabel.Font = new Font("Calibri (Body)", 15, FontStyle.Bold);
            heightLabel.Location = new Point(517, 250);
            heightLabel.ForeColor = Color.Black;
            heightLabel.BackColor = Color.Transparent;
            this.Controls.Add(heightLabel);

            //Creating a label that will appear next to the room length input box
            Label lengthLabel = new Label();
            lengthLabel.AutoSize = true;
            lengthLabel.Text = "Length:";
            lengthLabel.Font = new Font("Calibri (Body)", 15, FontStyle.Bold);
            lengthLabel.Location = new Point(515, 300);
            lengthLabel.ForeColor = Color.Black;
            lengthLabel.BackColor = Color.Transparent;
            this.Controls.Add(lengthLabel);

            //Creating a continue button that allows the user to submit their dimensions and continue to the calculation results
            Button continueButton = new Button();
            continueButton.Height = 60;
            continueButton.Width = 180;
            continueButton.Text = "Continue";
            continueButton.Font = new Font("Calibri (Body)", 25, FontStyle.Bold);
            continueButton.Location = new Point(525, 400);
            continueButton.BackColor = Color.LightGray;
            continueButton.ForeColor = Color.Black;
            continueButton.Click += (sender2, EventArgs) => { continue_click (sender, EventArgs, roomLength.Text, roomWidth.Text, roomHeight.Text); };
            this.Controls.Add(continueButton);

            //Creating a quit button that will close the application
            Button quitButton = new Button();
            quitButton.Height = 40;
            quitButton.Width = 125;
            quitButton.Text = "Quit";
            quitButton.Font = new Font("Calibri (Body)", 15, FontStyle.Bold);
            quitButton.Location = new Point(25, 12);
            quitButton.BackColor = Color.LightGray;
            quitButton.ForeColor = Color.Black;
            quitButton.Click += new EventHandler(quit_click);
            this.Controls.Add(quitButton);

            dataSave(roomLength.Text, roomWidth.Text, roomHeight.Text);
        }

        public void dataSave(string length,string width,string height)
        {
            Program.length = float.Parse(length);
            Program.width = float.Parse(width);
            Program.height = float.Parse(height);
        }

        //Validation for textbox input
        private void validation_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Allow only numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        //Code for the continue button
        void continue_click(object sender, EventArgs e, string length, string width, string height)
        {
            //Assigning the textbox inputs to the global variables so they can be used in the next form
            Program.length = float.Parse(length);
            Program.width = float.Parse(width);
            Program.height = float.Parse(height);

            Calculation calculationForm = new Calculation();
            this.Hide();
            calculationForm.Show();
        }

        //Quits the application
        void quit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
