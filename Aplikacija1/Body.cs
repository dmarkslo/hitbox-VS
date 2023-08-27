using Aplikacija1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacija1
{
    public partial class Body : UserControl
    {
        public Body()
        {
            InitializeComponent();
        }

        private void Body_Load(object sender, EventArgs e)
        {
            Limb glava1 = new Limb(glava);
            Limb trup1 = new Limb(trup);
            Limb levaRoka1 = new Limb(levaRoka);
            Limb desnaRoka1 = new Limb(desnaRoka);
            Limb levaNoga1 = new Limb(levaNoga);
            Limb desnaNoga1 = new Limb(desnaNoga);
        }
       
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            
        }
        public string MousePosition;
        Point mouseLocation = new Point();
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //dobi lokacijo miške in jo shrani
            mouseLocation.X = e.X; mouseLocation.Y = e.Y;
            MousePosition = mouseLocation.ToString();
        }

        public Point mousePosition { get { return mouseLocation; } set { mouseLocation = value; } }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //ko miška zapusti se koordinati resetirajo, ker jih ne potrebujemo več
            mouseLocation = new Point(0,0);
        }

        private void Body_Paint(object sender, PaintEventArgs e)
        {
            
        }
        //centri udov
        Point head = new Point(92, 10);

        //definicije regij (kvadratov), zunaj metod, za poenostavljeno prepoznavo udov.
        Rectangle glava = new Rectangle(91, 10, 108, 100);
        Rectangle trup = new Rectangle(91, 115, 108, 200);
        Rectangle levaRoka = new Rectangle(20,115,66,200);
        Rectangle desnaRoka = new Rectangle(204, 115, 66, 200);
        Rectangle levaNoga = new Rectangle(73, 325, 72, 380); // x y w h
        Rectangle desnaNoga = new Rectangle(150, 325, 72, 380); // 52def w
        




        //Metoda, ki preveri ali so koordinati miške (Point a) v regijah, definiranih zgoraj.
        public bool IsMouseInRegion(Point a)
        {

            bool isMouseInRegion = false;
            List<Rectangle> regions = new List<Rectangle>();
            regions.Add(glava); regions.Add(trup); regions.Add(levaRoka); regions.Add(desnaRoka); regions.Add(levaNoga); regions.Add(desnaNoga);

            //za vsako regijo v seznamu, preveri če je miška v njenih koordinatih.
            foreach(Rectangle region in regions)
            {
                if (region.Contains(a))
                {
                    //ko je pogoj TRUE, se breaka in pade na return statement. (drugače gre čez vse in bo TRUE samo pri desniNogi (zadnja v seznamu))
                    isMouseInRegion = true;
                    break;
                }
                else
                {
                    isMouseInRegion = false;
                }
            }
            return isMouseInRegion;
        }

        //Metoda, ki prikaže ime regije, ko miška pride znotraj te regije.
        public string MouseRegionId(Point a)
        {
            string regija = "";
            List<Rectangle> regions = new List<Rectangle>();
            regions.Add(glava); regions.Add(trup); regions.Add(levaRoka); regions.Add(desnaRoka); regions.Add(levaNoga); regions.Add(desnaNoga);

            //Pogoj za izvedbo: miška mora biti v katerikoli izmed registriranih regij.
            if (IsMouseInRegion(a) == true)
            {
                for (int i = 0; i < regions.Count; i++)
                {
                    if (regions[i].Contains(a))
                    {
                        switch (i)
                        {
                            case 0:
                                regija = "glava";
                                break;
                            case 1:
                                regija = "trup";
                                break;
                            case 2:
                                regija = "levaRoka";
                                break;
                            case 3:
                                regija = "desnaRoka";
                                break;
                            case 4:
                                regija = "levaNoga";
                                break;
                            case 5:
                                regija = "desnaNoga";
                                break;
                            default:
                                regija = "";
                                break;
                        }
                    }
                }
            }
            return regija;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //nariši zeleni kvadrat na glavo

            //zel. kvadrat
            Graphics g = e.Graphics;
            Brush blue = new TextureBrush(Resources.green_Rect1);

            //nariši na center glave
            g.FillRectangle(blue, glava);
            g.FillRectangle(blue, trup);
            g.FillRectangle(blue,levaRoka);
            g.FillRectangle(blue, desnaRoka);
            g.FillRectangle(blue, levaNoga);
            g.FillRectangle(blue, desnaNoga);
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
