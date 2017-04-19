using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using System.Collections;
using System.Data.SqlClient;
using _3D_graphic_library;

namespace SharpGLWinformsApplication2
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            InitializeComponent();
        }

        OpenGL gl;
        cylinder cs = new cylinder();
        pryzma prs = new pryzma();
        ArrayList choosen_fs=new ArrayList();
        int choosen = 0;
        int x0;
        int y0;
        bool choosing_mode = false;
        bool x_move = false;
        bool y_move = false;
        bool z_move = false;
        bool x_turn = false;
        bool y_turn = false;
        bool z_turn = false;
        bool resize=false;
        bool coloring_mode = false;

        void paint_cylinder(int n,int choosen)
        {
            gl.LoadIdentity();

            gl.Begin(OpenGL.GL_POLYGON);
            cylinder.cylinder_pr cur=(cylinder.cylinder_pr)cs.cylinders[n];
            if (choosen == -2 || choosen == 0) { gl.Color(1f, 1f, 0.9f); }
            else gl.Color(cur.cylinder_colors[2, 0], cur.cylinder_colors[2, 1], cur.cylinder_colors[2, 2]);

            for (int i = 0; i <cur.base_cylinder_x.Count; i++)
            {
                gl.Vertex((float)cur.base_cylinder_x[i],(float)cur.base_cylinder_y[i] , (float)cur.base_cylinder_z[i]);
            }
            gl.End();

            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            if (choosen == -2 || choosen == 1) { gl.Color(1f, 1f, 0.9f); }
            else gl.Color(cur.cylinder_colors[1, 0], cur.cylinder_colors[1, 1], cur.cylinder_colors[1, 2]);
            for (int i = 0; i < cur.base_cylinder_x.Count; i++)
            {
                gl.Vertex((float)cur.base_cylinder_x[i],(float)cur.base_cylinder_y[i], (float)cur.base_cylinder_z[i]);
                gl.Vertex((float)cur.base_cylinder_x_d[i],(float)cur.base_cylinder_y_d[i], (float)cur.base_cylinder_z_d[i]);
            }
            gl.Vertex((float)cur.base_cylinder_x[0],(float)cur.base_cylinder_y[0], (float)cur.base_cylinder_z[0]);
            gl.Vertex((float)cur.base_cylinder_x_d[cur.base_cylinder_x.Count - 1],(float)cur.base_cylinder_y_d[cur.base_cylinder_x.Count - 1], (float)cur.base_cylinder_z_d[cur.base_cylinder_x.Count - 1]);
            gl.Vertex((float)cur.base_cylinder_x_d[0],(float)cur.base_cylinder_y_d[0], (float)cur.base_cylinder_z_d[0]);
            gl.End();

            gl.Begin(OpenGL.GL_POLYGON);
            if (choosen == -2 || choosen == 0) { gl.Color(1f, 1f, 0.9f); }
            else gl.Color(cur.cylinder_colors[0, 0], cur.cylinder_colors[0, 1], cur.cylinder_colors[0, 2]);
            for (int i = 0; i < cur.base_cylinder_x_d.Count; i++)
            {
                gl.Vertex((float)cur.base_cylinder_x_d[i],(float)cur.base_cylinder_y_d[i], (float)cur.base_cylinder_z_d[i]);
            }
            gl.End();

            gl.LineWidth(2.0f);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Color(0.0f, 0.0f, 0.0f);
            for (int i = 0; i < cur.base_cylinder_x.Count; i++)
            {
                gl.Vertex((float)cur.base_cylinder_x[i],(float)cur.base_cylinder_y[i], (float)cur.base_cylinder_z[i]);
            }
            gl.End();

            gl.LineWidth(2.0f);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Color(0.0f, 0.0f, 0.0f);
            for (int i = 0; i < cur.base_cylinder_x_d.Count; i++)
            {
                gl.Vertex((float)cur.base_cylinder_x_d[i],(float)cur.base_cylinder_y_d[i] , (float)cur.base_cylinder_z_d[i]);
            }
            gl.End();
        }
        void paint_pryzma(int n,int choosen)
        {

            //  Load the identity matrix.
            gl.LoadIdentity();

            pryzma.pryzma_pr cur=(pryzma.pryzma_pr)prs.pryzmas[n];

            gl.Begin(OpenGL.GL_POLYGON);
            if (choosen == -2 || choosen == 0) { gl.Color(1f, 1f, 0.9f); }
            else { gl.Color(cur.pryzma_colors[0, 0], cur.pryzma_colors[0, 1], cur.pryzma_colors[0, 2]); }
              
                    for(int i=0;i<5;i++)
                    {
                        gl.Vertex(cur.u_points[i,0],cur.u_points[i,1],cur.u_points[i,2]);
                    }
                gl.End();

                gl.Begin(OpenGL.GL_POLYGON);
                if (choosen == -2 || choosen == 1) { gl.Color(1f, 1f, 0.9f); }
                else { gl.Color(cur.pryzma_colors[1, 0], cur.pryzma_colors[1, 1], cur.pryzma_colors[1, 2]); }
           
                        gl.Vertex(cur.u_points[0,0],cur.u_points[0,1],cur.u_points[0,2]);
                        gl.Vertex(cur.u_points[1,0],cur.u_points[1,1],cur.u_points[1,2]);
                        gl.Vertex(cur.d_points[1,0],cur.d_points[1,1],cur.d_points[1,2]);
                        gl.Vertex(cur.d_points[0,0],cur.d_points[0,1],cur.d_points[0,2]);
                gl.End();

                gl.Begin(OpenGL.GL_POLYGON);
                if (choosen == -2 || choosen == 2) { gl.Color(1f, 1f, 0.9f); }
                else { gl.Color(cur.pryzma_colors[2, 0], cur.pryzma_colors[2, 1], cur.pryzma_colors[2, 2]); }
                
                        gl.Vertex(cur.u_points[1,0],cur.u_points[1,1],cur.u_points[1,2]);
                        gl.Vertex(cur.u_points[2,0],cur.u_points[2,1],cur.u_points[2,2]);
                        gl.Vertex(cur.d_points[2,0],cur.d_points[2,1],cur.d_points[2,2]);
                        gl.Vertex(cur.d_points[1,0],cur.d_points[1,1],cur.d_points[1,2]);
                gl.End();

                gl.Begin(OpenGL.GL_POLYGON);
                if (choosen == -2 || choosen == 3) { gl.Color(1f, 1f, 0.9f); }
                else { gl.Color(cur.pryzma_colors[3, 0], cur.pryzma_colors[3, 1], cur.pryzma_colors[3, 2]); }
              
                        gl.Vertex(cur.u_points[2,0],cur.u_points[2,1],cur.u_points[2,2]);
                        gl.Vertex(cur.u_points[3,0],cur.u_points[3,1],cur.u_points[3,2]);
                        gl.Vertex(cur.d_points[3,0],cur.d_points[3,1],cur.d_points[3,2]);
                        gl.Vertex(cur.d_points[2,0],cur.d_points[2,1],cur.d_points[2,2]);
                gl.End();

                gl.Begin(OpenGL.GL_POLYGON);
                if (choosen == -2 || choosen == 4) { gl.Color(1f, 1f, 0.9f); }
                else { gl.Color(cur.pryzma_colors[4, 0], cur.pryzma_colors[4, 1], cur.pryzma_colors[4, 2]); }
          
                        gl.Vertex(cur.u_points[3,0],cur.u_points[3,1],cur.u_points[3,2]);
                        gl.Vertex(cur.u_points[4,0],cur.u_points[4,1],cur.u_points[4,2]);
                        gl.Vertex(cur.d_points[4,0],cur.d_points[4,1],cur.d_points[4,2]);
                        gl.Vertex(cur.d_points[3,0],cur.d_points[3,1],cur.d_points[3,2]);
                gl.End();

                gl.Begin(OpenGL.GL_POLYGON);
                if (choosen == -2 || choosen == 5) { gl.Color(1f, 1f, 0.9f); }
                else { gl.Color(cur.pryzma_colors[5, 0], cur.pryzma_colors[5, 1], cur.pryzma_colors[5, 2]); }
             
                        gl.Vertex(cur.u_points[4,0],cur.u_points[4,1],cur.u_points[4,2]);
                        gl.Vertex(cur.u_points[0,0],cur.u_points[0,1],cur.u_points[0,2]);
                        gl.Vertex(cur.d_points[0,0],cur.d_points[0,1],cur.d_points[0,2]);
                        gl.Vertex(cur.d_points[4,0],cur.d_points[4,1],cur.d_points[4,2]);
                gl.End();

                gl.Begin(OpenGL.GL_POLYGON);
                if (choosen == -2 || choosen == 6) { gl.Color(1f, 1f, 0.9f); }
                else { gl.Color(cur.pryzma_colors[6, 0], cur.pryzma_colors[6, 1], cur.pryzma_colors[6, 2]); }
               
                    for(int i=0;i<5;i++)
                    {
                        gl.Vertex(cur.d_points[i,0],cur.d_points[i,1],cur.d_points[i,2]);
                    }
                gl.End();

                gl.LineWidth(2.0f);
                gl.Begin(OpenGL.GL_LINE_LOOP);
                if (choosen==-1) gl.Color(0, 0, 0);
                else gl.Color(1, 1, 1);
                    for(int i=0;i<5;i++)
                    {
                        gl.Vertex(cur.u_points[i,0],cur.u_points[i,1],cur.u_points[i,2]);
                    }
                gl.End();

              gl.LineWidth(2.0f);
                gl.Begin(OpenGL.GL_LINE_LOOP);
                if (choosen == -1) gl.Color(0, 0, 0);
               else gl.Color(1, 1, 1);
                        gl.Vertex(cur.u_points[0,0],cur.u_points[0,1],cur.u_points[0,2]);
                        gl.Vertex(cur.u_points[1,0],cur.u_points[1,1],cur.u_points[1,2]);
                        gl.Vertex(cur.d_points[1,0],cur.d_points[1,1],cur.d_points[1,2]);
                        gl.Vertex(cur.d_points[0,0],cur.d_points[0,1],cur.d_points[0,2]);
                gl.End();

                 gl.LineWidth(2.0f);
                gl.Begin(OpenGL.GL_LINE_LOOP);
                if (choosen == -1) gl.Color(0, 0, 0);
                else gl.Color(1, 1, 1);
                        gl.Vertex(cur.u_points[1,0],cur.u_points[1,1],cur.u_points[1,2]);
                        gl.Vertex(cur.u_points[2,0],cur.u_points[2,1],cur.u_points[2,2]);
                        gl.Vertex(cur.d_points[2,0],cur.d_points[2,1],cur.d_points[2,2]);
                        gl.Vertex(cur.d_points[1,0],cur.d_points[1,1],cur.d_points[1,2]);
                gl.End();

                 gl.LineWidth(2.0f);
                gl.Begin(OpenGL.GL_LINE_LOOP);
                if (choosen == -1) gl.Color(0, 0, 0);
                else gl.Color(1, 1, 1);
                        gl.Vertex(cur.u_points[2,0],cur.u_points[2,1],cur.u_points[2,2]);
                        gl.Vertex(cur.u_points[3,0],cur.u_points[3,1],cur.u_points[3,2]);
                        gl.Vertex(cur.d_points[3,0],cur.d_points[3,1],cur.d_points[3,2]);
                        gl.Vertex(cur.d_points[2,0],cur.d_points[2,1],cur.d_points[2,2]);
                gl.End();

                 gl.LineWidth(2.0f);
                gl.Begin(OpenGL.GL_LINE_LOOP);
                if (choosen == -1) gl.Color(0, 0, 0);
                else gl.Color(1, 1, 1);
                        gl.Vertex(cur.u_points[3,0],cur.u_points[3,1],cur.u_points[3,2]);
                        gl.Vertex(cur.u_points[4,0],cur.u_points[4,1],cur.u_points[4,2]);
                        gl.Vertex(cur.d_points[4,0],cur.d_points[4,1],cur.d_points[4,2]);
                        gl.Vertex(cur.d_points[3,0],cur.d_points[3,1],cur.d_points[3,2]);
                gl.End();

                 gl.LineWidth(2.0f);
                gl.Begin(OpenGL.GL_LINE_LOOP);
                if (choosen == -1) gl.Color(0, 0, 0);
                else gl.Color(1, 1, 1);
                        gl.Vertex(cur.u_points[4,0],cur.u_points[4,1],cur.u_points[4,2]);
                        gl.Vertex(cur.u_points[0,0],cur.u_points[0,1],cur.u_points[0,2]);
                        gl.Vertex(cur.d_points[0,0],cur.d_points[0,1],cur.d_points[0,2]);
                        gl.Vertex(cur.d_points[4,0],cur.d_points[4,1],cur.d_points[4,2]);
                gl.End();


                gl.LineWidth(2.0f);
                gl.Begin(OpenGL.GL_LINE_LOOP);
                if (choosen == -1) gl.Color(0, 0, 0);
                else gl.Color(1, 1, 1);
                    for(int i=0;i<5;i++)
                    {
                        gl.Vertex(cur.d_points[i,0],cur.d_points[i,1],cur.d_points[i,2]);
                    }
                gl.End();
              
        }

        public void paint_axes()
        {
            gl.LoadIdentity();
            gl.LineWidth(4.0f);
            gl.Color(1.0, 0.1, 0.1);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Vertex(-10.0f, 0.0f, 0.0f);
            gl.Vertex(10.0f, 0.0f, 0.0f);
            gl.End();
            gl.LineWidth(4.0f);
            gl.Color(0.1, 1.0, 0.1);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, -10.0f, 0.0f);
            gl.Vertex(0.0f, 10.0f, 0.0f);
            gl.End();
            gl.LineWidth(4.0f);
            gl.Color(0.1, 0.1, 1.0);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Vertex(0.0f, 0.0f, -10.0f);
            gl.Vertex(0.0f, 0.0f, 10.0f);
            gl.End();
        }



        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RenderEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Get the OpenGL object.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT );

            paint_axes();

            for(int c=0;c<cs.cylinders.Count;c++)
            {
                if (coloring_mode && choosen>0 && (int)choosen_fs[0]-1==c)
                {
                    paint_cylinder(c, choosen - 1);
                }
                else
                {
                    if (choosen == c + 1 && !coloring_mode)
                    {
                       paint_cylinder(c, -2); 
                    }
                    else paint_cylinder(c, -1);
                    
                }
            }
            for(int p=0; p<prs.pryzmas.Count;p++)
            {
                if (coloring_mode && choosen > 0 && (-(int)choosen_fs[0]) - 1 == p)
                {
                    paint_pryzma(p, choosen - 1);
                }
                else
                {
                    if (p + 1 == (choosen - cs.cylinders.Count) && !coloring_mode)
                        paint_pryzma(p, -2);
                    else paint_pryzma(p, -1);
                }
            }

        }



        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  TODO: Initialise OpenGL here.

            //  Get the OpenGL object.
            gl = openGLControl.OpenGL;

            //  Set the clear color.
            gl.ClearColor(0, 0, 0, 0);
            

        }

        /// <summary>
        /// Handles the Resized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            //  Load the identity.
            gl.LoadIdentity();
           
            //  Create a perspective transformation.
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Use the 'look at' helper function to position and aim the camera.
            gl.LookAt(1, 1, 7, 0, 0, 0, 0, 1, 0);


            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        /// <summary>
        /// The current rotation.
        /// </summary>

        private void SharpGLForm_Load(object sender, EventArgs e)
        { }

        private void openGLControl_Click(object sender, EventArgs e)
        {
            int X=openGLControl.Width/2;
            int Y=openGLControl.Height/2;
            /*int X =Cursor.Position.X- this.Location.X;
            int Y =openGLControl.Height - (Cursor.Position.Y-this.Location.Y);
           /* // gl.GDItoOpenGL(ref x, ref y);
            int[] viewport = new int[4];       // параметры viewport-a.
            double[] projection = new double[16]; // матрица проекции.
            double[] modelview = new double[16];  // видовая матрица.
            int vx, vy;          // координаты курсора мыши в системе координат viewport-a.
            double x1, x2, y1, y2, z1, z2, ro, x, y;
          
            gl.GetInteger(OpenGL.GL_VIEWPORT, viewport);           // узнаём параметры viewport-a.
            gl.GetDouble(OpenGL.GL_PROJECTION_MATRIX, projection); // узнаём матрицу проекции.
            gl.GetDouble(OpenGL.GL_MODELVIEW_MATRIX, modelview);   // узнаём видовую матрицу.
            vx = X-viewport[2];
            vy =  Y-viewport[3];
            Glu.gluUnProject(vx, vy, -1, modelview, projection, viewport, out x1 , out y1, out z1);
            Glu.gluUnProject(vx, vy, 1, modelview, projection, viewport, out x2, out y2, out z2);*/
        
        }

        private void drawToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            float x = 0.0f; float y = 0.0f; float z = 0.0f; 
            float r = 1.0f; float h = 3.0f;
            float[,] colors=new float[3,3];
            colors[0,0]=0.0f; colors[0,1]=1.0f; colors[0,2]=0.0f;
            colors[1,0]=0.0f; colors[1,1]=1.0f; colors[1,2]=0.0f;
            colors[2,0]=0.0f; colors[2,1]=1.0f; colors[2,2]=0.0f;
            if (toolStripTextBox1.Text != "") try { x = (float)Convert.ToDouble(toolStripTextBox1.Text); }
                catch { };
            if (toolStripTextBox2.Text != "") try { y = (float)Convert.ToDouble(toolStripTextBox2.Text); }
                catch { };
            if (toolStripTextBox3.Text != "") try { z = (float)Convert.ToDouble(toolStripTextBox3.Text); }
                catch { };
            if (toolStripTextBox4.Text != "") try { r = (float)Convert.ToDouble(toolStripTextBox4.Text); }
                catch { };
            if (toolStripTextBox5.Text != "") try { h = (float)Convert.ToDouble(toolStripTextBox5.Text); }
                catch { };
            cs.cylinder_build(-1, x, y, z, r, h, 100,ref colors);
        }

        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float x = 0.0f; float y = 0.0f; float z = 0.0f;
            float l = 1.0f; float h = 3.0f;
            float[,] colors = new float[7, 3];
            colors[0, 0] = 1.0f; colors[0, 1] = 0.0f; colors[0, 2] = 0.0f;
            colors[1, 0] = 1.0f; colors[1, 1] = 0.0f; colors[1, 2] = 0.0f;
            colors[2, 0] = 1.0f; colors[2, 1] = 0.0f; colors[2, 2] = 0.0f;
            colors[3, 0] = 1.0f; colors[3, 1] = 0.0f; colors[3, 2] = 0.0f;
            colors[4, 0] = 1.0f; colors[4, 1] = 0.0f; colors[4, 2] = 0.0f;
            colors[5, 0] = 1.0f; colors[5, 1] = 0.0f; colors[5, 2] = 0.0f;
            colors[6, 0] = 1.0f; colors[6, 1] = 0.0f; colors[6, 2] = 0.0f;
            if (toolStripTextBox6.Text != "") try { x = (float)Convert.ToDouble(toolStripTextBox6.Text); }
                catch { };
            if (toolStripTextBox7.Text != "") try { y = (float)Convert.ToDouble(toolStripTextBox7.Text); }
                catch { };
            if (toolStripTextBox8.Text != "") try { z = (float)Convert.ToDouble(toolStripTextBox8.Text); }
                catch { };
            if (toolStripTextBox9.Text != "") try { l = (float)Convert.ToDouble(toolStripTextBox9.Text); }
                catch { };
            if (toolStripTextBox10.Text != "") try { h = (float)Convert.ToDouble(toolStripTextBox10.Text); }
                catch { };
            prs.pryzma_build(-1, x, y, z, l, h, ref colors);
        }

        private void SharpGLForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (choosing_mode)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        {
                            if (choosen == cs.cylinders.Count + prs.pryzmas.Count && cs.cylinders.Count + prs.pryzmas.Count != 0)
                                choosen = 1;
                            else
                            {
                                if (choosen < cs.cylinders.Count + prs.pryzmas.Count) choosen++;
                            }
                            break;
                        }
                    case Keys.A:
                        {
                            if (choosen == 1)
                            {
                                choosen = cs.cylinders.Count + prs.pryzmas.Count;
                            }
                            else
                            {
                                if (choosen != 0) choosen--;
                            }
                            break;
                        }

                    case Keys.Enter:
                        {
                            if (choosen != 0)
                            {
                                if (choosen <= cs.cylinders.Count)
                                {
                                    if (!choosen_fs.Contains(choosen))
                                    choosen_fs.Add(choosen); 
                                }
                                else
                                {
                                    int t = choosen - cs.cylinders.Count;
                                    if (!choosen_fs.Contains(-t))
                                        choosen_fs.Add(-t);
                                }
                            }
                            break;
                        }
                }
            }

            switch (e.KeyCode)
            {
                case Keys.W:
                    {
                        if (coloring_mode)
                        {
                            if ((int)choosen_fs[0] < 0)
                            {
                                if (choosen == 7)
                                { choosen = 1; }
                                else
                                {
                                    choosen++;
                                }
                            }
                            else
                            {
                                if (choosen == 3)
                                { choosen = 1; }
                                else
                                {
                                    choosen++;
                                }
                            }
                        }
                        break;
                    }

                case Keys.S:
                    {
                        if (coloring_mode)
                        {
                            if ((int)choosen_fs[0] < 0)
                            {
                                if (choosen == 1)
                                { choosen = 7; }
                                else
                                {
                                  if(choosen!=0)  choosen--;
                                }
                            }
                            else
                            {
                                if (choosen == 1)
                                { choosen = 3; }
                                else
                                {
                                    if (choosen != 0) choosen--;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Enter:
                        {
                            if (coloring_mode)
                            {
                                colorDialog1.ShowDialog();
                                Color c=colorDialog1.Color;
                                if((int)choosen_fs[0]<0)
                                {
                                    prs.change_color(-(int)choosen_fs[0] - 1, choosen-1, (float)c.R / 255, (float)c.G/255, (float)c.B/255);
                                }
                                if((int)choosen_fs[0]>0)
                                {
                                    cs.change_color((int)choosen_fs[0] - 1, choosen - 1, (float)c.R / 255, (float)c.G / 255, (float)c.B / 255);
                                }
                                coloring_mode = false;
                                choosen = 0;
                            }
                            break;
                        }

            }

        }

        private void chooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosing_mode = true;
            setChoosenFiguresToolStripMenuItem.Enabled = true;
            deleteSelectingToolStripMenuItem.Enabled = true;
            textBox1.Clear();
            textBox1.Text = "Use buttons 'A' and 'D' to indetificate figure, press 'Enter' to add figure to selected group!";
        }

        private void SharpGLForm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void SharpGLForm_KeyDown(object sender, KeyPressEventArgs e)
        {
        }

        private void setChoosenFiguresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosen = 0;
            choosing_mode = false;
        }

        private void deleteSelectingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setChoosenFiguresToolStripMenuItem.Enabled = false;
            deleteSelectingToolStripMenuItem.Enabled = false;
            choosing_mode = false;
            choosen = 0;
            choosen_fs.Clear();
        }

        private void byXaxeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_move = true;
            x0 = openGLControl.Width / 2;
            y0 = openGLControl.Height / 2;
            textBox1.Clear();
            textBox1.Text = "Use mouse to move the figure(s). The moving will be stopped by mouse click!";
        }

        private void SharpGLForm_MouseMove(object sender, MouseEventArgs e)
        {
            int x=e.X;
            int y=e.Y;
            if(x_move)
            {
                if(x0-x>0)
                {
                    for(int i=0;i<choosen_fs.Count;i++)
                    {
                        if((int)choosen_fs[i]>0)
                        {
                            cylinder.cylinder_pr cur=(cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i]-1];
                            cs.cylinder_build((int)choosen_fs[i] - 1, cur.x -0.1f, cur.y-cur.H/2, cur.z, cur.R, cur.H, 100, ref cur.cylinder_colors);
                        }
                        else
                        {
                            pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                            prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x - 0.1f, cur.y - cur.H / 2, cur.z, cur.L, cur.H, ref cur.pryzma_colors);
                        }
                    }
                }
                else
                {
                    if(x-x0>0)
                    {
                        for (int i = 0; i < choosen_fs.Count; i++)
                        {
                            if ((int)choosen_fs[i] > 0)
                            {
                                cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                                cs.cylinder_build((int)choosen_fs[i] - 1, cur.x +0.1f, cur.y - cur.H / 2, cur.z, cur.R, cur.H, 100, ref cur.cylinder_colors);
                            }
                            else
                            {
                                pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                                prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x + 0.1f, cur.y - cur.H / 2, cur.z, cur.L, cur.H, ref cur.pryzma_colors);
                            }
                        }

                    }
                }
            }
            if (y_move)
            {
                if (y0 - y > 0)
                {
                    for (int i = 0; i < choosen_fs.Count; i++)
                    {
                        if ((int)choosen_fs[i] > 0)
                        {
                            cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                            cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2 + 0.1f, cur.z, cur.R, cur.H, 100, ref cur.cylinder_colors);
                        }
                        else
                        {
                            pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                            prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x , cur.y - cur.H / 2 + 0.1f, cur.z, cur.L, cur.H, ref cur.pryzma_colors);
                        }
                    }
                }
                else
                {
                    if (y - y0 > 0)
                    {
                        for (int i = 0; i < choosen_fs.Count; i++)
                        {
                            if ((int)choosen_fs[i] > 0)
                            {
                                cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                                cs.cylinder_build((int)choosen_fs[i] - 1, cur.x , cur.y - cur.H / 2 - 0.1f, cur.z, cur.R, cur.H, 100, ref cur.cylinder_colors);
                            }
                            else
                            {
                                pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                                prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x , cur.y - cur.H / 2 - 0.1f, cur.z, cur.L, cur.H, ref cur.pryzma_colors);
                            }
                        }

                    }
                }
            }
            if (z_move)
            {
                if (y0 - y > 0)
                {
                    for (int i = 0; i < choosen_fs.Count; i++)
                    {
                        if ((int)choosen_fs[i] > 0)
                        {
                            cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                            cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z - 0.1f, cur.R, cur.H, 100, ref cur.cylinder_colors);
                        }
                        else
                        {
                            pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                            prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x , cur.y - cur.H / 2, cur.z - 0.1f, cur.L, cur.H, ref cur.pryzma_colors);
                        }
                    }
                }
                else
                {
                    if (y - y0 > 0)
                    {
                        for (int i = 0; i < choosen_fs.Count; i++)
                        {
                            if ((int)choosen_fs[i] > 0)
                            {
                                cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                                cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z + 0.1f, cur.R, cur.H, 100, ref cur.cylinder_colors);
                            }
                            else
                            {
                                pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                                prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x , cur.y - cur.H / 2, cur.z + 0.1f, cur.L, cur.H, ref cur.pryzma_colors);
                            }
                        }

                    }
                }
            }

            if(x_turn)
             {
                 if(y0-y>0)
                 {
                     for (int i = 0; i < choosen_fs.Count; i++)
                     {
                         if ((int)choosen_fs[i] > 0)
                         {
                             cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                             cur.x_alpha -= 1.57f / 6;
                             cs.cylinders[(int)choosen_fs[i] - 1] = cur;
                             cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.R, cur.H, 100, ref cur.cylinder_colors);
                         }
                         else
                         {

                             pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                             cur.x_alpha -= 1.57f / 6;
                             prs.pryzmas[-(int)choosen_fs[i] - 1] = cur;
                             prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.L, cur.H, ref cur.pryzma_colors);
                         }
                     }
                 }
                 else
                 {
                     if(y-y0>0)
                     {
                         for (int i = 0; i < choosen_fs.Count; i++)
                         {
                             if ((int)choosen_fs[i] > 0)
                             {
                                 cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                                 cur.x_alpha += 1.57f / 6;
                                 cs.cylinders[(int)choosen_fs[i] - 1] = cur;
                                 cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.R, cur.H, 100, ref cur.cylinder_colors);
                             }
                             else
                             {

                                 pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                                 cur.x_alpha += 1.57f / 6;
                                 prs.pryzmas[-(int)choosen_fs[i] - 1] = cur;
                                 prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.L, cur.H, ref cur.pryzma_colors);
                             }
                         }
                     }
                 }
             }
            if(y_turn)
            {
                if (x - x0 > 0)
                {
                    for (int i = 0; i < choosen_fs.Count; i++)
                    {
                        if ((int)choosen_fs[i] > 0)
                        {
                            cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                            cur.y_alpha += 1.57f / 6;
                            cs.cylinders[(int)choosen_fs[i] - 1] = cur;
                            cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.R, cur.H, 100, ref cur.cylinder_colors);
                        }
                        else
                        {

                            pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                            cur.y_alpha += 1.57f / 6;
                            prs.pryzmas[-(int)choosen_fs[i] - 1] = cur;
                            prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.L, cur.H, ref cur.pryzma_colors);
                        }
                    }
                }
                else
                {
                    if (x0 - x > 0)
                    {
                        for (int i = 0; i < choosen_fs.Count; i++)
                        {
                            if ((int)choosen_fs[i] > 0)
                            {
                                cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                                cur.y_alpha -= 1.57f / 6;
                                cs.cylinders[(int)choosen_fs[i] - 1] = cur;
                                cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.R, cur.H, 100, ref cur.cylinder_colors);
                            }
                            else
                            {

                                pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                                cur.y_alpha -= 1.57f / 6;
                                prs.pryzmas[-(int)choosen_fs[i] - 1] = cur;
                                prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.L, cur.H, ref cur.pryzma_colors);
                            }
                        }
                    }
                }
            }
            if (z_turn)
            {
                if (x - x0 > 0)
                {
                    for (int i = 0; i < choosen_fs.Count; i++)
                    {
                        if ((int)choosen_fs[i] > 0)
                        {
                            cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                            cur.z_alpha += 1.57f / 6;
                            cs.cylinders[(int)choosen_fs[i] - 1] = cur;
                            cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.R, cur.H, 100, ref cur.cylinder_colors);
                        }
                        else
                        {

                            pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                            cur.z_alpha += 1.57f / 6;
                            prs.pryzmas[-(int)choosen_fs[i] - 1] = cur;
                            prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.L, cur.H, ref cur.pryzma_colors);
                        }
                    }
                }
                else
                {
                    if (x0 - x > 0)
                    {
                        for (int i = 0; i < choosen_fs.Count; i++)
                        {
                            if ((int)choosen_fs[i] > 0)
                            {
                                cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                                cur.z_alpha -= 1.57f / 6;
                                cs.cylinders[(int)choosen_fs[i] - 1] = cur;
                                cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.R, cur.H, 100, ref cur.cylinder_colors);
                            }
                            else
                            {

                                pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                                cur.z_alpha -= 1.57f / 6;
                                prs.pryzmas[-(int)choosen_fs[i] - 1] = cur;
                                prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.L, cur.H, ref cur.pryzma_colors);
                            }
                        }
                    }
                }
            }

            if(resize)
            {
                if(y-y0>0)
                {
                    for (int i = 0; i < choosen_fs.Count; i++)
                    {
                        if ((int)choosen_fs[i] > 0)
                        {
                            cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                            cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.R + (cur.R / (cur.R + cur.H))/100, cur.H + (cur.H / (cur.R + cur.H))/100, 100, ref cur.cylinder_colors);
                        }
                        else
                        {
                            pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                            prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.L + (cur.L / (cur.L + cur.H))/100, cur.H + (cur.H / (cur.H + cur.L))/100, ref cur.pryzma_colors);
                        }
                    }
                }
                else
                {
                    if(y0-y>0)
                    {
                        for (int i = 0; i < choosen_fs.Count; i++)
                        {
                            if ((int)choosen_fs[i] > 0)
                            {
                                cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[(int)choosen_fs[i] - 1];
                                cs.cylinder_build((int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.R -( cur.R / (cur.R + cur.H))/100, cur.H - (cur.H / (cur.R + cur.H))/100, 100, ref cur.cylinder_colors);
                            }
                            else
                            {
                                pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[-(int)choosen_fs[i] - 1];
                                prs.pryzma_build(-(int)choosen_fs[i] - 1, cur.x, cur.y - cur.H / 2, cur.z, cur.L - (cur.L / (cur.L + cur.H))/100, cur.H - (cur.H / (cur.H + cur.L))/100, ref cur.pryzma_colors);
                            }
                        }
                    }
                }
            }

            x0 = x;
            y0 = y;
            
        }

        private void SharpGLForm_MouseClick(object sender, MouseEventArgs e)
        {
            x_move = false;
            y_move = false;
            z_move = false;
            x_turn = false;
            y_turn = false;
            z_turn = false;
            resize = false;
        }

        private void byYaxeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            y_move = true;
            x0 = openGLControl.Width / 2;
            y0 = openGLControl.Height / 2;
            textBox1.Clear();
            textBox1.Text = "Use mouse to move the figure(s). The moving will be stopped by mouse click!";
        }

        private void byZaxeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            z_move = true;
            x0 = openGLControl.Width / 2;
            y0 = openGLControl.Height / 2;
            textBox1.Clear();
            textBox1.Text = "Use mouse to move the figure(s). The moving will be stopped by mouse click!";
        }

        private void byXaxeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            x_turn = true;
            x0 = openGLControl.Width / 2;
            y0 = openGLControl.Height / 2;
            textBox1.Clear();
            textBox1.Text = "Use mouse to turn the figure(s). The turning will be stopped by mouse click!";
        }

        private void byYaxeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            y_turn = true;
            x0 = openGLControl.Width / 2;
            y0 = openGLControl.Height / 2;
            textBox1.Clear();
            textBox1.Text = "Use mouse to turn the figure(s). The turning will be stopped by mouse click!";
        }

        private void byZaxeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            z_turn = true;
            x0 = openGLControl.Width / 2;
            y0 = openGLControl.Height / 2;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            resize = true;
            x0 = openGLControl.Width / 2;
            y0 = openGLControl.Height / 2;
            textBox1.Clear();
            textBox1.Text = "Use mouse to resize the figure(s). The resizing will be stopped by mouse click!";
        }

        private void byZaxeToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            z_turn = true;
            x0 = openGLControl.Width / 2;
            y0 = openGLControl.Height / 2;
            textBox1.Clear();
            textBox1.Text = "Use mouse to turn the figure(s). The turning will be stopped by mouse click!";
        }

        private void figureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Color c = colorDialog1.Color;
                for (int i = 0; i < choosen_fs.Count; i++)
                {
                    if((int)choosen_fs[i]>0)
                    {
                        for(int j=0;j<3;j++)
                        {
                            cs.change_color((int)choosen_fs[i] - 1, j, (float)c.R/255, (float)c.G/255, (float)c.B/255);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 7; j++)
                        {
                          prs.change_color(-(int)choosen_fs[i] - 1, j, (float)c.R/255, (float)c.G/255, (float)c.B/255);
                        }
                    }
                }
        }

        private void componentOfFigufeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            coloring_mode = true;
            textBox1.Clear();
            textBox1.Text = "choose part of figure using buttons 'W' and 'S', press 'Enter' after that";
        }
        private void saveInDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\c++_дз\projects\С++_дз\2 курс\2 semestr\лабораторні\Лаб.1\3d_graphics\3d_redactor\figures-database.mdf;Integrated Security=True");
            SqlCommand cmdcl = new SqlCommand("Delete CYLINDER",conn);
            conn.Open();
                cmdcl.ExecuteNonQuery();
                conn.Close();
            for(int i=0; i<cs.cylinders.Count; i++)
            {
                cylinder.cylinder_pr cur = (cylinder.cylinder_pr)cs.cylinders[i];
                SqlCommand cmd = new SqlCommand("INSERT INTO CYLINDER(Id,x,y,z,r,h,r0,g0,b0,r1,g1,b1,r2,g2,b2,x_alpha,y_alpha,z_alpha)VALUES("+(i+1)+",'"+cur.x+"','"+cur.y+"','"+cur.z+"','"+cur.R+"','"+cur.H+"','"+cur.cylinder_colors[0,0]+"','"+cur.cylinder_colors[0,1]+"','"+cur.cylinder_colors[0,2]+"','"+cur.cylinder_colors[1,0]+"','"+cur.cylinder_colors[1,1]+"','"+cur.cylinder_colors[1,2]+"','"+cur.cylinder_colors[2,0]+"','"+cur.cylinder_colors[2,1]+"','"+cur.cylinder_colors[2,2]+"','"+cur.x_alpha+"','"+cur.y_alpha+"','"+cur.z_alpha+"')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            SqlCommand cmdclp = new SqlCommand("Delete PRYZMA", conn);
            conn.Open();
            cmdclp.ExecuteNonQuery();
            conn.Close();
            for (int i = 0; i < prs.pryzmas.Count; i++)
            {
                pryzma.pryzma_pr cur = (pryzma.pryzma_pr)prs.pryzmas[i];
                SqlCommand cmd = new SqlCommand("INSERT INTO PRYZMA(Id,x,y,z,l,h,r0,g0,b0,r1,g1,b1,r2,g2,b2,r3,g3,b3,r4,g4,b4,r5,g5,b5,r6,g6,b6,x_alpha,y_alpha,z_alpha)VALUES(" + (i + 1) + ",'" + cur.x + "','" + cur.y + "','" + cur.z + "','" + cur.L + "','" + cur.H + "','" + cur.pryzma_colors[0, 0] + "','" + cur.pryzma_colors[0, 1] + "','" + cur.pryzma_colors[0, 2] + "','" + cur.pryzma_colors[1, 0] + "','" + cur.pryzma_colors[1, 1] + "','" + cur.pryzma_colors[1, 2] + "','" + cur.pryzma_colors[2, 0] + "','" + cur.pryzma_colors[2, 1] + "','" + cur.pryzma_colors[2, 2] + "','" + cur.pryzma_colors[3, 0] + "','" + cur.pryzma_colors[3, 1] + "','" + cur.pryzma_colors[3, 2] + "','" + cur.pryzma_colors[4, 0] + "','" + cur.pryzma_colors[4, 1] + "','" + cur.pryzma_colors[4, 2] + "','" + cur.pryzma_colors[5, 0] + "','" + cur.pryzma_colors[5, 1] + "','" + cur.pryzma_colors[5, 2] + "','" + cur.pryzma_colors[6, 0] + "','" + cur.pryzma_colors[6, 1] + "','" + cur.pryzma_colors[6, 2] + "','" + cur.x_alpha + "','" + cur.y_alpha + "','" + cur.z_alpha + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void loadFromDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\c++_дз\projects\С++_дз\2 курс\2 semestr\лабораторні\Лаб.1\3d_graphics\3d_redactor\figures-database.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from CYLINDER", conn);
            conn.Open();
            SqlDataReader read = cmd.ExecuteReader();
            cs.cylinders.Clear();
            while(read.Read())
            {
                string temp = (read["x"].ToString());
                float x = (float)Convert.ToDouble(temp);
                temp = (read["y"].ToString());
                float y = (float)Convert.ToDouble(temp);
                temp = (read["z"].ToString());
                float z = (float)Convert.ToDouble(temp);
                temp = (read["r"].ToString());
                float R = (float)Convert.ToDouble(temp);
                temp = (read["h"].ToString());
                float H = (float)Convert.ToDouble(temp);
                float[,] colors=new float[3,3];
                temp = (read["r0"].ToString());
                colors[0,0] = (float)Convert.ToDouble(temp);
                temp = (read["g0"].ToString());
                colors[0, 1] = (float)Convert.ToDouble(temp);
                temp = (read["b0"].ToString());
                colors[0, 2] = (float)Convert.ToDouble(temp);
                temp = (read["r1"].ToString());
                colors[1, 0] = (float)Convert.ToDouble(temp);
                temp = (read["g1"].ToString());
                colors[1, 1] = (float)Convert.ToDouble(temp);
                temp = (read["b1"].ToString());
                colors[1, 2] = (float)Convert.ToDouble(temp);
                temp = (read["r2"].ToString());
                colors[2, 0] = (float)Convert.ToDouble(temp);
                temp = (read["g2"].ToString());
                colors[2, 1] = (float)Convert.ToDouble(temp);
                temp = (read["b2"].ToString());
                colors[2, 2] = (float)Convert.ToDouble(temp);
                cs.cylinder_build(-1, x, y-H/2, z, R, H, 100,ref colors);
                temp = (read["x_alpha"].ToString());
                float alpha = (float)Convert.ToDouble(temp);
                if(alpha!=0.0f)
                {
                    cs.turn_by_x(cs.cylinders.Count - 1, alpha);
                }
                temp = (read["y_alpha"].ToString());
                alpha = (float)Convert.ToDouble(temp);
                if (alpha != 0.0f)
                {
                    cs.turn_by_y(cs.cylinders.Count - 1, alpha);
                }
                temp = (read["z_alpha"].ToString());
                alpha = (float)Convert.ToDouble(temp);
                if (alpha != 0.0f)
                {
                    cs.turn_by_z(cs.cylinders.Count - 1, alpha);
                }
            }
            conn.Close();
            SqlCommand cmdp = new SqlCommand("Select * from PRYZMA", conn);
            conn.Open();
            SqlDataReader readp = cmdp.ExecuteReader();
            prs.pryzmas.Clear();
            while (readp.Read())
            {
                string temp = (readp["x"].ToString());
                float x = (float)Convert.ToDouble(temp);
                temp = (readp["y"].ToString());
                float y = (float)Convert.ToDouble(temp);
                temp = (readp["z"].ToString());
                float z = (float)Convert.ToDouble(temp);
                temp = (readp["l"].ToString());
                float l = (float)Convert.ToDouble(temp);
                temp = (readp["h"].ToString());
                float H = (float)Convert.ToDouble(temp);
                float[,] colors = new float[7, 3];
                temp = (readp["r0"].ToString());
                colors[0, 0] = (float)Convert.ToDouble(temp);
                temp = (readp["g0"].ToString());
                colors[0, 1] = (float)Convert.ToDouble(temp);
                temp = (readp["b0"].ToString());
                colors[0, 2] = (float)Convert.ToDouble(temp);
                temp = (readp["r1"].ToString());
                colors[1, 0] = (float)Convert.ToDouble(temp);
                temp = (readp["g1"].ToString());
                colors[1, 1] = (float)Convert.ToDouble(temp);
                temp = (readp["b1"].ToString());
                colors[1, 2] = (float)Convert.ToDouble(temp);
                temp = (readp["r2"].ToString());
                colors[2, 0] = (float)Convert.ToDouble(temp);
                temp = (readp["g2"].ToString());
                colors[2, 1] = (float)Convert.ToDouble(temp);
                temp = (readp["b2"].ToString());
                colors[2, 2] = (float)Convert.ToDouble(temp);
                temp = (readp["r3"].ToString());
                colors[3, 0] = (float)Convert.ToDouble(temp);
                temp = (readp["g3"].ToString());
                colors[3, 1] = (float)Convert.ToDouble(temp);
                temp = (readp["b3"].ToString());
                colors[3, 2] = (float)Convert.ToDouble(temp);
                temp = (readp["r4"].ToString());
                colors[4, 0] = (float)Convert.ToDouble(temp);
                temp = (readp["g4"].ToString());
                colors[4, 1] = (float)Convert.ToDouble(temp);
                temp = (readp["b4"].ToString());
                colors[4, 2] = (float)Convert.ToDouble(temp);
                temp = (readp["r5"].ToString());
                colors[5, 0] = (float)Convert.ToDouble(temp);
                temp = (readp["g5"].ToString());
                colors[5, 1] = (float)Convert.ToDouble(temp);
                temp = (readp["b5"].ToString());
                colors[5, 2] = (float)Convert.ToDouble(temp);
                temp = (readp["r6"].ToString());
                colors[6, 0] = (float)Convert.ToDouble(temp);
                temp = (readp["g6"].ToString());
                colors[6, 1] = (float)Convert.ToDouble(temp);
                temp = (readp["b6"].ToString());
                colors[6, 2] = (float)Convert.ToDouble(temp);
                prs.pryzma_build(-1, x, y - H / 2, z, l, H, ref colors);
                temp = (readp["x_alpha"].ToString());
                float alpha = (float)Convert.ToDouble(temp);
                if (alpha != 0.0f)
                {
                    prs.turn_by_x(prs.pryzmas.Count - 1, alpha);
                }
                temp = (readp["y_alpha"].ToString());
                alpha = (float)Convert.ToDouble(temp);
                if (alpha != 0.0f)
                {
                    prs.turn_by_y(prs.pryzmas.Count - 1, alpha);
                }
                temp = (readp["z_alpha"].ToString());
                alpha = (float)Convert.ToDouble(temp);
                if (alpha != 0.0f)
                {
                    prs.turn_by_z(prs.pryzmas.Count - 1, alpha);
                }
            }
            conn.Close();
        }

        private void toolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "Choose the type of figure, which you want to draw";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox1.Text = "Choose the type of figure, which you want to draw";
        }

        private void cylinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cylinderToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "Set the koordinats and parametrs of cylinder,(By default they are: (x,y,z)=(0,0,0); R=1; H=3; the color is grean), click 'draw' after that!";
        }

        private void pryzmaToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "Set the koordinats and parametrs of pryzma,(By default they are: (x,y,z)=(0,0,0); L=1; H=3; the color is red), click 'draw' after that!";
        }

        private void setXYZToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "All the values have to be inputed in form *,* or * for example 1,2 or 14, otherwise values by default will be used! ";
        }

        private void setLenghtToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "All the values have to be inputed in form *,* or * for example 1,2 or 14, otherwise values by default will be used! ";
        }

        private void setHeightToolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "All the values have to be inputed in form *,* or * for example 1,2 or 14, otherwise values by default will be used! ";
        }

        private void toolStripMenuItem2_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "All the values have to be inputed in form *,* or * for example 1,2 or 14, otherwise values by default will be used! ";
        }

        private void setRadiusToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "All the values have to be inputed in form *,* or * for example 1,2 or 14, otherwise values by default will be used! ";
        }

        private void setHeightToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "All the values have to be inputed in form *,* or * for example 1,2 or 14, otherwise values by default will be used! ";
        }

        private void drawToolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "Draw cylinder!";
        }

        private void drawToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "Draw pryzma!";
        }

        private void selectingFiguresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void toolStripComboBox1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "If you want select figure(s) click 'choose'. If you want set selected  figure(s) click 'set choosen figures'";
        }

        private void deleteSelectingToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "delete selecting of figure or group of figures!";
        }

        private void selectingFiguresToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void moveFiguresToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "Choose the axe, which you want to move figure(s) by";
        }

        private void moveFiguresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "Choose the axe, which you want to move figure(s) by";
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "to change color of selected figure(s) click 'Figure(s)', to change color of part of figure click 'component of figure' (one figure should be choosen, otherwise the changings will be done on first figure added to selected group)";
        }

        private void saveInDBToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void loadFromDBToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void turnFiguresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "Choose the axe, which you want to turn figure(s) by";
        }

        private void turnFiguresToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "Choose the axe, which you want to turn figure(s) by";
        }

        private void changeColorToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "to change color of selected figure(s) click 'Figure(s)', to change color of part of figure click 'component of figure' (one figure should be choosen, otherwise the changings will be done on first figure added to selected group)";
       
        }

        private void deleteFiguresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < choosen_fs.Count; i++ )
            {
                 if((int)choosen_fs[i]>0)
                 {
                     cs.cylinders.RemoveAt((int)choosen_fs[i] - 1);
                 }
                else
                 {
                     prs.pryzmas.RemoveAt(-(int)choosen_fs[i] - 1);
                 }
            }
            choosen_fs.Clear();
        }

        private void deleteFiguresToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = "delete selected figure or group of figures";
        }
    }
}
