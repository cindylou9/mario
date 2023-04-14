using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        bool grav;
        int y = 92;
        bool left;
        bool right;
        bool jump;
        int gravity = 20;
        int gravpush;
        int force;
        private void Form2_Load(object sender, EventArgs e)
        {
        }
        private void contact()
        {
                if (pb_move.Bounds.IntersectsWith(pb_pipe1.Bounds))
                {
                    pb_move.Left -= 10;
                }

                if (pb_move.Bounds.IntersectsWith(pb_brick2.Bounds))
                {
                    pb_move.Left -= 10;
                    pb_move.Top += 10;
                }
                 if (pb_move.Bounds.IntersectsWith(pb_goomba1.Bounds))
                {
                    grav = true;
                    timergravity.Enabled = true;
                    timergoombas1.Enabled = false;
                    
                }
                 if (pb_goomba1.Bounds.IntersectsWith(pb_move.Bounds))
                 {
                     timergravity.Enabled = true; 
                     //timergoombas1.Enabled = false;
                     grav = true;
                 }


               else if (pb_move.Bounds.IntersectsWith(pb_question1.Bounds))
                {
                    pb_move.Top -= 10;
                    if (pb_mush.Top <= 222)
                    {
                        pb_mush.Top -= 10;
                        pb_mush.Left += 10;
                        timermush.Enabled = true;
                    }
               }
                 else if (pb_move.Bottom <= pb_brick2.Top)
                 {
                     MessageBox.Show("Works");
                     // timer1.Enabled = false;
                     pb_move.Top += 10;
                 }
                 else if (pb_move.Bounds.IntersectsWith(pb_goomba1.Bounds))
                 {
                     pb_goomba1.Image = pb_goombasquish.Image;
                 }
                 else if (pb_move.Bounds.IntersectsWith(pb_brick2.Bounds))
                 {
                     pb_move.Top += 10;
                 }
                 if (pb_move.Bounds.IntersectsWith(pb_goomba1.Bounds))
                 {
                     timergravity.Enabled = true;
                     grav = true;
                 }
                //else if (pb_move.Bounds.IntersectsWith(pb_brick2.Bounds))
                // {
                //     pb_move.Top += 10;
                //    // timerright.Enabled = false;
                //     //timerleft.Enabled = false;
                //     MessageBox.Show("YES");
                // }
                //if (pb_move.Bounds.Bottom.IntersectsWith(pb_brick2.Bounds.Top))
                //{
                //}
        }
        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
        }
        private void Form2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (jump == true)
            {
                if (e.KeyCode == Keys.Up)
                {
                    force = gravity;
                    jump = true;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                jump = true;
                force = gravity;
            }
            if (e.KeyCode == Keys.Right)
            {
                timerright.Enabled = true;
                timerleft.Enabled = true;
                timer1.Enabled = true;
                right = true;
                //this.Left -= 10;
                contact();
            }
            //if (e.KeyCode != Keys.Right)
            //{
            //    pb_move2.Image = pb_move.Image;
            //    pb_move3.Image = pb_move.Image;
            //}

            if (e.KeyCode == Keys.Left)
            {
                
                timer1.Enabled = true;
                pb_move.Image = pb_move11.Image;
                pb_move11.Left -= 10;
                timerright2.Enabled = true;
                timerleft2.Enabled = true;
                left = true;
                grav = true;


                contact();
            }
            if (e.KeyCode == Keys.Up)
            {
                jump = true;
                force = gravity;
                contact();
            }
            if (e.KeyCode == Keys.Down)
            {
                contact();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
        if (pb_move.Right > pb_pipe1.Left && pb_move.Left < pb_pipe1.Right && pb_move.Bottom > pb_pipe1.Top)
            {
                right = false;
            }
            if (pb_move.Left < pb_pipe1.Right && pb_move.Right > pb_pipe1.Left && pb_move.Bottom > pb_pipe1.Top)
            {
                left = false;
            }

            if (right == true)
            {
                pb_move.Left += 10;
                pb_move2.Left += 10;
                pb_move3.Left += 10;
            }
            if (left == true)
            {
                pb_move.Left -= 10;
                pb_move2.Left -= 10;
                pb_move3.Left -= 10;
            }


            if (jump == true)
            {
                pb_move.Top -= force;
                pb_move2.Top -= force;
                pb_move3.Top -= force;
                force -= 5;
            }
            if (pb_move.Bottom >= p_screen.Height)
            {
                pb_move.Top = p_screen.Height - pb_move.Height;
                jump = false;
            }
        }
        private void timermush_Tick(object sender, EventArgs e)
        {
            pb_mush.Top -= 5;
            if (pb_mush.Top > 270)
            {
                timermush.Enabled = false;
                pb_mush.Top += 10;
            }
        }
        private void timergravity_Tick(object sender, EventArgs e)
        {
            if (grav == true)
            {
                pb_move.Top += gravpush;
                pb_move11.Top += gravpush;
                pb_goomba1.Top += gravpush;
                gravpush += 2;
            }
            else  if (pb_goombasquish.Bottom < y)
            {
                pb_goombasquish.Top = y + pb_goombasquish.Height;
            }
            //else  if (pb_goombasquish.Bottom <= y)
            //{
            //    grav = false;
            //}
            else  if (pb_move.Bounds.IntersectsWith(pb_goomba1.Bounds))
            {
                pb_goomba1.Image = pb_goombasquish.Image;
                pb_goombasquish.Top += 20;
            }
        }

            private void timergoombas1_Tick(object sender, EventArgs e)
            {
                pb_goomba1.Left -= 10;
                if (pb_goomba1.Left >= 35)
                {
                    timergoombas1.Enabled = false;
                    timergoombas2.Enabled = true;
                    pb_goomba1.Image = pb_goomba2.Image;
                }
            //else if (pb_goomba1.Bounds.IntersectsWith(pb_move.Bounds))
            //{
            //    pb_goomba1.Image = pb_goombasquish.Image;
            //    timergravity.Enabled = true;

            //}
            //else if (pb_goomba1.Bounds.IntersectsWith(pb_pipe1.Bounds))
            //{
            //    pb_goomba1.Left -= 5;
            //    pb_goomba1.Visible = false;
            //    pb_goomba2.Visible = false;
            //    pb_goombasquish.Visible = false;
            //    pb_goomba1.Image = pb_goombasquish.Image;
            //    timergoombas2.Enabled = true;
            //    timergravity.Enabled = true;

            //}
        }
            private void timergoombas2_Tick(object sender, EventArgs e)
            {
                pb_goomba2.Left -= 10;
                if (pb_goomba2.Left >= 35)
                {
                    timergoombas2.Enabled = false;
                    timergoombas2.Enabled = true;
                    pb_goomba2.Image = pb_goomba1.Image;
                }
            }
        private void timerright_Tick(object sender, EventArgs e)
        {
         if (pb_move.Left >= 35)
            {
                timerright.Enabled = false;
                timerleft.Enabled = true;
                pb_move.Image = pb_move2.Image;
            }
        }
        private void timerleft_Tick(object sender, EventArgs e)
        {
            if (pb_move.Left >= 35)
            {
                timerright.Enabled = false;
                timerleft.Enabled = true;
                pb_move.Image = pb_move2.Image;
            }
        }
        private void timerright2_Tick(object sender, EventArgs e)
        {
            if (pb_move.Left <= 35)
            {
                pb_move.Left += 10;
                timerright2.Enabled = false;
                timerleft.Enabled = true;

                pb_move11.Image = pb_move22.Image;
            }
        }

        private void timerleft2_Tick(object sender, EventArgs e)
        {
            if (pb_move.Left <= 35)
            {
                timerright2.Enabled = false;
                timerleft.Enabled = true;
                pb_move11.Image = pb_move22.Image;
            }
        }
       
        
        
        
        
        private void pb_pipe1_Click(object sender, EventArgs e)
        {

        }

        private void pb_move2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

    }
        






}

