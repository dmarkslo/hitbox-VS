using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacija1
{
    public partial class lblLoc : Form
    {
        public lblLoc(string Id)
        {
            InitializeComponent();
            Id = this.Id;
        }
        string Id;
        private void body1_Load(object sender, EventArgs e)
        {

        }

        private void body1_MouseHover(object sender, EventArgs e)
        {
            
        }
        
        private void body1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
        Body body = new Body();
        private void Subject_Load(object sender, EventArgs e)
        {
            this.Name = Id;
            //začne se timer, ki pinga vsakih 50ms
            timer1.Interval = 50;
            timer1.Start();

            //ustvari body

            body.Location = new Point(0, 0);
            this.Controls.Add(body);
            body.Show();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //dobi trenutne koordinate miške
            id_mouse_coords.Text = Convert.ToString(body.mousePosition);

            //preveri, če je miška v regiji
            if (body.IsMouseInRegion(body.mousePosition))
            {
                lblLocation.ForeColor = Color.DarkGreen;
                lblLocation.Text = "REGION FOUND.";
            }
            else
            {
                lblLocation.ForeColor = Color.OrangeRed;
                lblLocation.Text = "REGION NOT FOUND.";
            }
            label5.Text = body.MouseRegionId(body.mousePosition);
        }

        private void Subject_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void lblLocation_TextChanged(object sender, EventArgs e)
        {
            if(lblLocation.Text == "REGION FOUND.")
            {
                label2.Visible = true;
                label5.Visible = true;
            }
            else
            {
                label2.Visible = false;
                label5.Visible = false;
            }
        }
    }
}
