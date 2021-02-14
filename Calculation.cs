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
    public partial class Calculation : Form
    {
        public Calculation()
        {
            InitializeComponent();
        }

        private void Calculation_Load(object sender, EventArgs e)
        {
            //Setting window size, position on screen and colour
            this.Size = new Size(1200, 600);
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.BackColor = Color.DeepSkyBlue;

            //Calculations
            float roomVolume = Program.height * Program.length * Program.width;
            float floorArea = Program.length * Program.width;
            float paintRequired = 2 * (Program.height * Program.length) + 2 * (Program.height * Program.width);

            //Creating a heading for the form
            Label heading = new Label();
            heading.AutoSize = true;
            heading.Text = "Results";
            heading.Font = new Font("Calibri (Body)", 40, FontStyle.Bold);
            heading.Location = new Point(490, 75);
            heading.ForeColor = Color.Black;
            heading.BackColor = Color.Transparent;
            this.Controls.Add(heading);

            //Label to display the volume of the room
            Label volumeOfRoom = new Label();
            volumeOfRoom.AutoSize = true;
            volumeOfRoom.Text = "The volume of the room is " + roomVolume + " cubic meters.";
            volumeOfRoom.Font = new Font("Calibri (Body)", 20, FontStyle.Bold);
            volumeOfRoom.Location = new Point(320, 300);
            volumeOfRoom.ForeColor = Color.Black;
            volumeOfRoom.BackColor = Color.Transparent;
            this.Controls.Add(volumeOfRoom);

            //Label to display the area of the floor
            Label areaOfFloor = new Label();
            areaOfFloor.AutoSize = true;
            areaOfFloor.Text = "The area of the floor is " + floorArea + " square meters.";
            areaOfFloor.Font = new Font("Calibri (Body)", 20, FontStyle.Bold);
            areaOfFloor.Location = new Point(335, 200);
            areaOfFloor.ForeColor = Color.Black;
            areaOfFloor.BackColor = Color.Transparent;
            this.Controls.Add(areaOfFloor);

            //Label to display the amount of paint required in sqm
            Label amountOfPaint = new Label();
            amountOfPaint.AutoSize = true;
            amountOfPaint.Text = "The amount of paint required is " + paintRequired + " measured in square meters.";
            amountOfPaint.Font = new Font("Calibri (Body)", 20, FontStyle.Bold);
            amountOfPaint.Location = new Point(200, 400);
            amountOfPaint.ForeColor = Color.Black;
            amountOfPaint.BackColor = Color.Transparent;
            this.Controls.Add(amountOfPaint);

            //Creating a button to return to the main menu so that the user can alter their inputs
            Button returnButton = new Button();
            returnButton.Height = 40;
            returnButton.Width = 190;
            returnButton.Text = "Edit dimensions";
            returnButton.Font = new Font("Calibri (Body)", 15, FontStyle.Bold);
            returnButton.Location = new Point(975, 12);
            returnButton.BackColor = Color.LightGray;
            returnButton.ForeColor = Color.Black;
            returnButton.Click += new EventHandler(return_click);
            this.Controls.Add(returnButton);

            // Creating a quit button that will close the application
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
        }

        //Quits the application
        void quit_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Code for the continue button
        void return_click(object sender, EventArgs e)
        {
            Main mainForm = new Main();
            this.Close();
            mainForm.Show();
        }
    }
}
