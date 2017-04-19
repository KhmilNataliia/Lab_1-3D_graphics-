using System;
using _3D_graphic_library;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_build_cylinder()
        {
            cylinder test = new cylinder();
            float[,] t=new float[3,3];
            test.cylinder_build(-1, 0, 0, 0, 1, 2, 4, ref t);
            bool flag = true;
            cylinder.cylinder_pr res = (cylinder.cylinder_pr)test.cylinders[0];
            for (int i = 0; i < res.base_cylinder_x.Count; i++)
                res.base_cylinder_x[i] = Math.Round((float)res.base_cylinder_x[i] * 10) / 10;
            for (int i = 0; i < res.base_cylinder_z.Count; i++)
                res.base_cylinder_z[i] = Math.Round((float)res.base_cylinder_z[i] * 10) / 10; 
            int r = res.base_cylinder_x.IndexOf(1.0);
            int l = res.base_cylinder_x.IndexOf(-1.0);
            int u = res.base_cylinder_z.IndexOf(1.0);
            int d = res.base_cylinder_z.IndexOf(-1.0);
            if (r < 0 || !Convert.Equals(res.base_cylinder_z[r],0.0)) flag = false;
            if (l < 0 || !Convert.Equals(res.base_cylinder_z[l],0.0)) flag = false;
            if (u < 0 || !Convert.Equals(res.base_cylinder_x[u], 0.0)) flag = false;
            if (d < 0 || !Convert.Equals(res.base_cylinder_x[d], 0.0)) flag = false;
            if (res.y != 1.0f) flag = false;
            Assert.AreEqual(true, flag);
        }

        [TestMethod]
        public void Test_rebuild_cylinder()
        {
            cylinder test = new cylinder();
            float[,] t = new float[3, 3];
            test.cylinder_build(-1, 0, 0, 0, 1, 2, 4, ref t);
            test.cylinder_build(0, 0, 0, 0, 2, 2, 4, ref t);
            bool flag = true;
            cylinder.cylinder_pr res = (cylinder.cylinder_pr)test.cylinders[0];
            for (int i = 0; i < res.base_cylinder_x.Count; i++)
                res.base_cylinder_x[i] = Math.Round((float)res.base_cylinder_x[i] * 10) / 10;
            for (int i = 0; i < res.base_cylinder_z.Count; i++)
                res.base_cylinder_z[i] = Math.Round((float)res.base_cylinder_z[i] * 10) / 10;
            int r = res.base_cylinder_x.IndexOf(2.0);
            int l = res.base_cylinder_x.IndexOf(-2.0);
            int u = res.base_cylinder_z.IndexOf(2.0);
            int d = res.base_cylinder_z.IndexOf(-2.0);
            if (r < 0 || !Convert.Equals(res.base_cylinder_z[r], 0.0)) flag = false;
            if (l < 0 || !Convert.Equals(res.base_cylinder_z[l], 0.0)) flag = false;
            if (u < 0 || !Convert.Equals(res.base_cylinder_x[u], 0.0)) flag = false;
            if (d < 0 || !Convert.Equals(res.base_cylinder_x[d], 0.0)) flag = false;

            Assert.AreEqual(true, flag);
        }

        [TestMethod]
        public void Test_turn_by_x()
        {
            cylinder test = new cylinder();
            float[,] t = new float[3, 3];
            test.cylinder_build(-1, 0, 0, 0, 1, 2, 4, ref t);
            bool flag = true;
            test.turn_by_x(0, 1.57f);
            cylinder.cylinder_pr res = (cylinder.cylinder_pr)test.cylinders[0];
            for (int i = 0; i < res.base_cylinder_x.Count; i++)
            {
                res.base_cylinder_x[i] = Math.Round((float)res.base_cylinder_x[i] * 10) / 10;
                res.base_cylinder_y[i] = Math.Round((float)res.base_cylinder_y[i] * 10) / 10;
                res.base_cylinder_z[i] = Math.Round((float)res.base_cylinder_z[i] * 10) / 10;
                res.base_cylinder_x_d[i] = Math.Round((float)res.base_cylinder_x_d[i] * 10) / 10;
                res.base_cylinder_y_d[i] = Math.Round((float)res.base_cylinder_y_d[i] * 10) / 10;
                res.base_cylinder_z_d[i] = Math.Round((float)res.base_cylinder_z_d[i] * 10) / 10;
            }
            int r = res.base_cylinder_x.IndexOf(1.0);
            int l = res.base_cylinder_x.IndexOf(-1.0);
            int u = res.base_cylinder_y.IndexOf(0.0);
            int d = res.base_cylinder_y.IndexOf(2.0);
            if (r < 0 || !Convert.Equals(res.base_cylinder_y[r], 1.0)) flag = false;
            if (l < 0 || !Convert.Equals(res.base_cylinder_y[l], 1.0)) flag = false;
            if (u < 0 || !Convert.Equals(res.base_cylinder_x[u], 0.0)) flag = false;
            if (d < 0 || !Convert.Equals(res.base_cylinder_x[d], 0.0)) flag = false;
            if (!Convert.Equals(res.base_cylinder_z[0], 1.0)) flag = false;
            if (!Convert.Equals(res.base_cylinder_z_d[0], -1.0)) flag = false;
            Assert.AreEqual(true, flag);
        }

        [TestMethod]
        public void Test_turn_by_y()
        {
            cylinder test = new cylinder();
            float[,] t = new float[3, 3];
            test.cylinder_build(-1, 0, 0, 0, 1, 2, 4, ref t);
            bool flag = true;
            test.turn_by_y(0, 1.57f);
            cylinder.cylinder_pr res = (cylinder.cylinder_pr)test.cylinders[0];
            for (int i = 0; i < res.base_cylinder_x.Count; i++)
            {
                res.base_cylinder_x[i] = Math.Round((float)res.base_cylinder_x[i] * 10) / 10;
                res.base_cylinder_y[i] = Math.Round((float)res.base_cylinder_y[i] * 10) / 10;
                res.base_cylinder_z[i] = Math.Round((float)res.base_cylinder_z[i] * 10) / 10;
                res.base_cylinder_x_d[i] = Math.Round((float)res.base_cylinder_x_d[i] * 10) / 10;
                res.base_cylinder_y_d[i] = Math.Round((float)res.base_cylinder_y_d[i] * 10) / 10;
                res.base_cylinder_z_d[i] = Math.Round((float)res.base_cylinder_z_d[i] * 10) / 10;
            }
            int r = res.base_cylinder_x.IndexOf(1.0);
            int l = res.base_cylinder_x.IndexOf(-1.0);
            int u = res.base_cylinder_z.IndexOf(1.0);
            int d = res.base_cylinder_z.IndexOf(-1.0);
            if (r < 0 || !Convert.Equals(res.base_cylinder_z[r], 0.0)) flag = false;
            if (l < 0 || !Convert.Equals(res.base_cylinder_z[l], 0.0)) flag = false;
            if (u < 0 || !Convert.Equals(res.base_cylinder_x[u], 0.0)) flag = false;
            if (d < 0 || !Convert.Equals(res.base_cylinder_x[d], 0.0)) flag = false;
            if (!Convert.Equals(res.base_cylinder_y[0],0.0)) flag = false;
            if (!Convert.Equals(res.base_cylinder_y_d[0], 2.0)) flag = false;
            Assert.AreEqual(true, flag);
        }

        [TestMethod]
        public void Test_turn_by_z()
        {
            cylinder test = new cylinder();
            float[,] t = new float[3, 3];
            test.cylinder_build(-1, 0, 0, 0, 1, 2, 4, ref t);
            bool flag = true;
            test.turn_by_z(0, 1.57f);
            cylinder.cylinder_pr res = (cylinder.cylinder_pr)test.cylinders[0];
            for (int i = 0; i < res.base_cylinder_x.Count; i++)
            {
                res.base_cylinder_x[i] = Math.Round((float)res.base_cylinder_x[i] * 10) / 10;
                res.base_cylinder_y[i] = Math.Round((float)res.base_cylinder_y[i] * 10) / 10;
                res.base_cylinder_z[i] = Math.Round((float)res.base_cylinder_z[i] * 10) / 10;
                res.base_cylinder_x_d[i] = Math.Round((float)res.base_cylinder_x_d[i] * 10) / 10;
                res.base_cylinder_y_d[i] = Math.Round((float)res.base_cylinder_y_d[i] * 10) / 10;
                res.base_cylinder_z_d[i] = Math.Round((float)res.base_cylinder_z_d[i] * 10) / 10;
            }
            int r = res.base_cylinder_y.IndexOf(2.0);
            int l = res.base_cylinder_y.IndexOf(0.0);
            int u = res.base_cylinder_z.IndexOf(1.0);
            int d = res.base_cylinder_z.IndexOf(-1.0);
            if (r < 0 || !Convert.Equals(res.base_cylinder_z[r], 0.0)) flag = false;
            if (l < 0 || !Convert.Equals(res.base_cylinder_z[l], 0.0)) flag = false;
            if (u < 0 || !Convert.Equals(res.base_cylinder_y[u], 1.0)) flag = false;
            if (d < 0 || !Convert.Equals(res.base_cylinder_y[d], 1.0)) flag = false;
            if (!Convert.Equals(res.base_cylinder_x[0], 1.0)) flag = false;
            if (!Convert.Equals(res.base_cylinder_x_d[0], -1.0)) flag = false;
            Assert.AreEqual(true, flag);
        }

        [TestMethod]

        public void Test_change_color()
        {
            cylinder test = new cylinder();
            float[,] colors = new float[3, 3];
            colors[0, 0] = 1.0f; colors[0, 1] = 0.0f; colors[0, 2] = 0.0f;
            colors[1, 0] = 1.0f; colors[1, 1] = 0.0f; colors[1, 2] = 0.0f;
            colors[2, 0] = 1.0f; colors[2, 1] = 0.0f; colors[2, 2] = 0.0f;
            test.cylinder_build(-1, 0, 0, 0, 1, 3, 100,ref colors);
            test.cylinder_build(-1, 3, 0, 0, 2, 4, 100, ref colors);
            test.change_color(0, 0, 0.0f, 0.0f, 1.0f);
            test.change_color(1, 1, 0.0f, 1.0f, 0.0f);
            bool flag = true;
            cylinder.cylinder_pr res1 = (cylinder.cylinder_pr)test.cylinders[0];
            cylinder.cylinder_pr res2= (cylinder.cylinder_pr)test.cylinders[1];
            if (res1.cylinder_colors[0, 0] != 0.0) flag = false;
            if (res1.cylinder_colors[0, 1] != 0.0) flag = false;
            if (res1.cylinder_colors[0, 2] != 1.0) flag = false;

            if (res1.cylinder_colors[1, 0] != 1.0) flag = false;
            if (res1.cylinder_colors[1, 1] != 0.0) flag = false;
            if (res1.cylinder_colors[1, 2] != 0.0) flag = false;

            if (res1.cylinder_colors[2, 0] != 1.0) flag = false;
            if (res1.cylinder_colors[2, 1] != 0.0) flag = false;
            if (res1.cylinder_colors[2, 2] != 0.0) flag = false;

            if (res2.cylinder_colors[0, 0] != 1.0) flag = false;
            if (res2.cylinder_colors[0, 1] != 0.0) flag = false;
            if (res2.cylinder_colors[0, 2] != 0.0) flag = false;

            if (res2.cylinder_colors[1, 0] != 0.0) flag = false;
            if (res2.cylinder_colors[1, 1] != 1.0) flag = false;
            if (res2.cylinder_colors[1, 2] != 0.0) flag = false;

            if (res2.cylinder_colors[2, 0] != 1.0) flag = false;
            if (res2.cylinder_colors[2, 1] != 0.0) flag = false;
            if (res2.cylinder_colors[2, 2] != 0.0) flag = false;

            Assert.AreEqual(true, flag);


        }
        [TestMethod]

        public void Test_build_pryzma()
        {
            pryzma test = new pryzma();
            float[,] t = new float[7, 3];
           test.pryzma_build(-1, 0, 0, 0, 1, 2, ref t);
            bool flag = true;
            pryzma.pryzma_pr res = (pryzma.pryzma_pr)test.pryzmas[0];
            for (int i = 0; i < 5; i++)
            {
                res.u_points[i, 0] = (float)Math.Round(res.u_points[i, 0] * 10) / 10;
                res.u_points[i, 1] = (float)Math.Round(res.u_points[i, 1] * 10) / 10;
                res.u_points[i, 2] = (float)Math.Round(res.u_points[i, 2] * 10) / 10;
                res.d_points[i, 0] = (float)Math.Round(res.u_points[i, 0] * 10) / 10;
                res.d_points[i, 1] = (float)Math.Round(res.u_points[i, 1] * 10) / 10;
                res.d_points[i, 2] = (float)Math.Round(res.u_points[i, 2] * 10) / 10;
            }
            //for x
            if (res.u_points[0, 0] != 1.0f) flag = false;
            if (res.u_points[1, 0] != 0.3f) flag = false;
            if (res.u_points[2, 0] != -0.8f) flag = false;
            if (res.u_points[3, 0] != -0.8f) flag = false;
            if (res.u_points[4, 0] != 0.3f) flag = false;
            //for y
            if (res.u_points[0, 1] != 0.0f) flag = false;
            if (res.u_points[1, 1] != 0.0f) flag = false;
            if (res.u_points[2, 1] != 0.0f) flag = false;
            if (res.u_points[3, 1] != 0.0f) flag = false;
            if (res.u_points[4, 1] != 0.0f) flag = false;
            //for z
            if (res.u_points[0, 2] != 0.0f) flag = false;
            if (res.u_points[1, 2] != 1.0f) flag = false;
            if (res.u_points[2, 2] != 0.6f) flag = false;
            if (res.u_points[3, 2] != -0.6f) flag = false;
            if (res.u_points[4, 2] != -1.0f) flag = false;

            if (res.y != 1.0f) flag = false;

            Assert.AreEqual(true, flag);
        }

        [TestMethod]

        public void Test_turn_by_x_pryzma()
        {
            pryzma test = new pryzma();
            float[,] t = new float[7, 3];
            test.pryzma_build(-1, 0, 0, 0, 1, 2, ref t);
            bool flag = true;
            test.turn_by_x(0, 1.57f);
            pryzma.pryzma_pr res = (pryzma.pryzma_pr)test.pryzmas[0];
            for (int i = 0; i < 5; i++)
            {
                res.u_points[i, 0] = (float)Math.Round(res.u_points[i, 0] * 10) / 10;
                res.u_points[i, 1] = (float)Math.Round(res.u_points[i, 1] * 10) / 10;
                res.u_points[i, 2] = (float)Math.Round(res.u_points[i, 2] * 10) / 10;
                res.d_points[i, 0] = (float)Math.Round(res.u_points[i, 0] * 10) / 10;
                res.d_points[i, 1] = (float)Math.Round(res.u_points[i, 1] * 10) / 10;
                res.d_points[i, 2] = (float)Math.Round(res.u_points[i, 2] * 10) / 10;
            }
            //for x
            if (res.u_points[0, 0] != 1.0f) flag = false;
            if (res.u_points[1, 0] != 0.3f) flag = false;
            if (res.u_points[2, 0] != -0.8f) flag = false;
            if (res.u_points[3, 0] != -0.8f) flag = false;
            if (res.u_points[4, 0] != 0.3f) flag = false;
            //for y
            if (res.u_points[0, 1] != 1.0f) flag = false;
            if (res.u_points[1, 1] != 2.0f) flag = false;
            if (res.u_points[2, 1] != 1.6f) flag = false;
            if (res.u_points[3, 1] != 0.4f) flag = false;
            if (res.u_points[4, 1] != 0.0f) flag = false;
            //for z
            if (res.u_points[0, 2] != 1.0f) flag = false;
            if (res.u_points[1, 2] != 1.0f) flag = false;
            if (res.u_points[2, 2] != 1.0f) flag = false;
            if (res.u_points[3, 2] != 1.0f) flag = false;
            if (res.u_points[4, 2] != 1.0f) flag = false;

            if (res.y != 1.0f) flag = false;

            Assert.AreEqual(true, flag);
        }

        [TestMethod]

        public void Test_turn_by_y_pryzma()
        {
            pryzma test = new pryzma();
            float[,] t = new float[7, 3];
            test.pryzma_build(-1, 0, 0, 0, 1, 2, ref t);
            bool flag = true;
            test.turn_by_y(0, 1.57f);
            pryzma.pryzma_pr res = (pryzma.pryzma_pr)test.pryzmas[0];
            for (int i = 0; i < 5; i++)
            {
                res.u_points[i, 0] = (float)Math.Round(res.u_points[i, 0] * 10) / 10;
                res.u_points[i, 1] = (float)Math.Round(res.u_points[i, 1] * 10) / 10;
                res.u_points[i, 2] = (float)Math.Round(res.u_points[i, 2] * 10) / 10;
                res.d_points[i, 0] = (float)Math.Round(res.u_points[i, 0] * 10) / 10;
                res.d_points[i, 1] = (float)Math.Round(res.u_points[i, 1] * 10) / 10;
                res.d_points[i, 2] = (float)Math.Round(res.u_points[i, 2] * 10) / 10;
            }
            //for x
            if (res.u_points[0, 0] != 0.0f) flag = false;
            if (res.u_points[1, 0] != 1.0f) flag = false;
            if (res.u_points[2, 0] != 0.6f) flag = false;
            if (res.u_points[3, 0] != -0.6f) flag = false;
            if (res.u_points[4, 0] != -1.0f) flag = false;
            //for y
            if (res.u_points[0, 1] != 0.0f) flag = false;
            if (res.u_points[1, 1] != 0.0f) flag = false;
            if (res.u_points[2, 1] != 0.0f) flag = false;
            if (res.u_points[3, 1] != 0.0f) flag = false;
            if (res.u_points[4, 1] != 0.0f) flag = false;
            //for z
            if (res.u_points[0, 2] != -1.0f) flag = false;
            if (res.u_points[1, 2] != -0.3f) flag = false;
            if (res.u_points[2, 2] != 0.8f) flag = false;
            if (res.u_points[3, 2] != 0.8f) flag = false;
            if (res.u_points[4, 2] != -0.3f) flag = false;

            if (res.y != 1.0f) flag = false;

            Assert.AreEqual(true, flag);
        }

        [TestMethod]

        public void Test_turn_by_z_pryzma()
        {
            pryzma test = new pryzma();
            float[,] t = new float[7, 3];
            test.pryzma_build(-1, 0, 0, 0, 1, 2, ref t);
            bool flag = true;
            test.turn_by_z(0, 1.57f);
            pryzma.pryzma_pr res = (pryzma.pryzma_pr)test.pryzmas[0];
            for (int i = 0; i < 5; i++)
            {
                res.u_points[i, 0] = (float)Math.Round(res.u_points[i, 0] * 10) / 10;
                res.u_points[i, 1] = (float)Math.Round(res.u_points[i, 1] * 10) / 10;
                res.u_points[i, 2] = (float)Math.Round(res.u_points[i, 2] * 10) / 10;
                res.d_points[i, 0] = (float)Math.Round(res.u_points[i, 0] * 10) / 10;
                res.d_points[i, 1] = (float)Math.Round(res.u_points[i, 1] * 10) / 10;
                res.d_points[i, 2] = (float)Math.Round(res.u_points[i, 2] * 10) / 10;
            }
            //for x
            if (res.u_points[0, 0] != 1.0f) flag = false;
            if (res.u_points[1, 0] != 1.0f) flag = false;
            if (res.u_points[2, 0] != 1.0f) flag = false;
            if (res.u_points[3, 0] != 1.0f) flag = false;
            if (res.u_points[4, 0] != 1.0f) flag = false;
            //for y
            if (res.u_points[0, 1] != 2.0f) flag = false;
            if (res.u_points[1, 1] != 1.3f) flag = false;
            if (res.u_points[2, 1] != 0.2f) flag = false;
            if (res.u_points[3, 1] != 0.2f) flag = false;
            if (res.u_points[4, 1] != 1.3f) flag = false;
            //for z
            if (res.u_points[0, 2] != 0.0f) flag = false;
            if (res.u_points[1, 2] != 1.0f) flag = false;
            if (res.u_points[2, 2] != 0.6f) flag = false;
            if (res.u_points[3, 2] != -0.6f) flag = false;
            if (res.u_points[4, 2] != -1.0f) flag = false;

            if (res.y != 1.0f) flag = false;

            Assert.AreEqual(true, flag);
        }

        [TestMethod]

        public void Test_change_color_pryzma()
        {
            pryzma test = new pryzma();
            float[,] colors = new float[7, 3];
            colors[0, 0] = 1.0f; colors[0, 1] = 0.0f; colors[0, 2] = 0.0f;
            colors[1, 0] = 1.0f; colors[1, 1] = 0.0f; colors[1, 2] = 0.0f;
            colors[2, 0] = 1.0f; colors[2, 1] = 0.0f; colors[2, 2] = 0.0f;
            colors[3, 0] = 1.0f; colors[0, 1] = 0.0f; colors[0, 2] = 0.0f;
            colors[4, 0] = 1.0f; colors[1, 1] = 0.0f; colors[1, 2] = 0.0f;
            colors[5, 0] = 1.0f; colors[2, 1] = 0.0f; colors[2, 2] = 0.0f;
            colors[6, 0] = 1.0f; colors[2, 1] = 0.0f; colors[2, 2] = 0.0f;
            test.pryzma_build(-1, 0, 0, 0, 1, 3, ref colors);
            test.pryzma_build(-1, 3, 0, 0, 2, 4, ref colors);
            test.change_color(0, 0, 0.0f, 0.0f, 1.0f);
            test.change_color(1, 1, 0.0f, 1.0f, 0.0f);
            bool flag = true;
            pryzma.pryzma_pr res1 = (pryzma.pryzma_pr)test.pryzmas[0];
            pryzma.pryzma_pr res2 = (pryzma.pryzma_pr)test.pryzmas[1];
            if (res1.pryzma_colors[0, 0] != 0.0) flag = false;
            if (res1.pryzma_colors[0, 1] != 0.0) flag = false;
            if (res1.pryzma_colors[0, 2] != 1.0) flag = false;

            if (res1.pryzma_colors[1, 0] != 1.0) flag = false;
            if (res1.pryzma_colors[1, 1] != 0.0) flag = false;
            if (res1.pryzma_colors[1, 2] != 0.0) flag = false;

            if (res1.pryzma_colors[2, 0] != 1.0) flag = false;
            if (res1.pryzma_colors[2, 1] != 0.0) flag = false;
            if (res1.pryzma_colors[2, 2] != 0.0) flag = false;

            if (res1.pryzma_colors[3, 0] != 1.0) flag = false;
            if (res1.pryzma_colors[3, 1] != 0.0) flag = false;
            if (res1.pryzma_colors[3, 2] != 0.0) flag = false;

            if (res1.pryzma_colors[4, 0] != 1.0) flag = false;
            if (res1.pryzma_colors[4, 1] != 0.0) flag = false;
            if (res1.pryzma_colors[4, 2] != 0.0) flag = false;

            if (res1.pryzma_colors[5, 0] != 1.0) flag = false;
            if (res1.pryzma_colors[5, 1] != 0.0) flag = false;
            if (res1.pryzma_colors[5, 2] != 0.0) flag = false;

            if (res1.pryzma_colors[6, 0] != 1.0) flag = false;
            if (res1.pryzma_colors[6, 1] != 0.0) flag = false;
            if (res1.pryzma_colors[6, 2] != 0.0) flag = false;

            if (res2.pryzma_colors[0, 0] != 1.0) flag = false;
            if (res2.pryzma_colors[0, 1] != 0.0) flag = false;
            if (res2.pryzma_colors[0, 2] != 0.0) flag = false;

            if (res2.pryzma_colors[1, 0] != 0.0) flag = false;
            if (res2.pryzma_colors[1, 1] != 1.0) flag = false;
            if (res2.pryzma_colors[1, 2] != 0.0) flag = false;

            if (res2.pryzma_colors[2, 0] != 1.0) flag = false;
            if (res2.pryzma_colors[2, 1] != 0.0) flag = false;
            if (res2.pryzma_colors[2, 2] != 0.0) flag = false;

            if (res2.pryzma_colors[3, 0] != 1.0) flag = false;
            if (res2.pryzma_colors[3, 1] != 0.0) flag = false;
            if (res2.pryzma_colors[3, 2] != 0.0) flag = false;

            if (res2.pryzma_colors[4, 0] != 1.0) flag = false;
            if (res2.pryzma_colors[4, 1] != 0.0) flag = false;
            if (res2.pryzma_colors[4, 2] != 0.0) flag = false;

            if (res2.pryzma_colors[5, 0] != 1.0) flag = false;
            if (res2.pryzma_colors[5, 1] != 0.0) flag = false;
            if (res2.pryzma_colors[5, 2] != 0.0) flag = false;

            if (res2.pryzma_colors[6, 0] != 1.0) flag = false;
            if (res2.pryzma_colors[6, 1] != 0.0) flag = false;
            if (res2.pryzma_colors[6, 2] != 0.0) flag = false;

            Assert.AreEqual(true, flag);


        }
    }
}
