using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _3D_graphic_library
{
    public class cylinder
    {
        public ArrayList cylinders = new ArrayList();
        public struct cylinder_pr
        {
            public float x;
            public float y;
            public float z;
            public float R;
            public float H;
            public ArrayList base_cylinder_x;
            public ArrayList base_cylinder_x_d;
            public ArrayList base_cylinder_y;
            public ArrayList base_cylinder_y_d;
            public ArrayList base_cylinder_z;
            public ArrayList base_cylinder_z_d;
            public float[,] cylinder_colors;
            public float x_alpha;
            public float y_alpha;
            public float z_alpha;
        }

        public void cylinder_build(int num, float x, float y, float z, float r, float h, int quality, ref float[,] colors)
        {
            if (num == -1)
            {
                cylinder_pr cur = new cylinder_pr();
                cur.base_cylinder_x = new ArrayList();
                cur.base_cylinder_y = new ArrayList();
                cur.base_cylinder_z = new ArrayList();
                cur.base_cylinder_x_d = new ArrayList();
                cur.base_cylinder_y_d = new ArrayList();
                cur.base_cylinder_z_d = new ArrayList();
                cur.cylinder_colors = new float[3, 3];
                cur.x_alpha = 0.0f;
                cur.y_alpha = 0.0f;
                cur.z_alpha = 0.0f;
                cylinders.Add(cur);
                num = cylinders.Count - 1;
            }
            cylinder_pr t = (cylinder_pr)cylinders[num];
            t.R = r;
            t.H = h;
            t.x = x;
            t.y = y + h / 2;
            t.z = z;
            calc_points_circle(quality, ref t);
            t.cylinder_colors[0, 0] = colors[0, 0];
            t.cylinder_colors[0, 1] = colors[0, 1];
            t.cylinder_colors[0, 2] = colors[0, 2];

            t.cylinder_colors[1, 0] = colors[1, 0];
            t.cylinder_colors[1, 1] = colors[1, 1];
            t.cylinder_colors[1, 2] = colors[1, 2];

            t.cylinder_colors[2, 0] = colors[2, 0];
            t.cylinder_colors[2, 1] = colors[2, 1];
            t.cylinder_colors[2, 2] = colors[2, 2];

            float ax = t.x_alpha;
            float ay = t.y_alpha;
            float az = t.z_alpha;
            t.x_alpha = 0.0f;
            t.y_alpha = 0.0f;
            t.z_alpha = 0.0f;
            cylinders[num] = t;
            if (ax != 0.0) { turn_by_x(num, ax); }
            if (ay != 0.0) { turn_by_y(num, ay); }
            if (az != 0.0) { turn_by_z(num, az); }
        }

        public void calc_points_circle(int quality, ref cylinder_pr cur)
        {
            float x = cur.x;
            float z = cur.z;
            float y = cur.y - cur.H / 2;
            float r = cur.R;
            cur.base_cylinder_x.Clear();
            cur.base_cylinder_y.Clear();
            cur.base_cylinder_z.Clear();
            cur.base_cylinder_x_d.Clear();
            cur.base_cylinder_y_d.Clear();
            cur.base_cylinder_z_d.Clear();
            for (int i = 0; i < quality; i++)
            {

                float angle = 2f * 3.14f * (float)i / (float)quality;
                float dx = r * (float)Math.Cos(angle);
                float dz = r * (float)Math.Sin(angle);
                cur.base_cylinder_x.Add(x + dx);
                cur.base_cylinder_x_d.Add(x + dx);
                cur.base_cylinder_z.Add(z + dz);
                cur.base_cylinder_z_d.Add(z + dz);
                cur.base_cylinder_y.Add(y);
                cur.base_cylinder_y_d.Add(y + cur.H);
            }
        }

        public void turn_by_x(int num, float alpha)
        {
            cylinder_pr cur = (cylinder_pr)cylinders[num];
            for (int i = 0; i < cur.base_cylinder_x.Count; i++)
            {
                float y = (float)cur.base_cylinder_y[i];
                float y_d = (float)cur.base_cylinder_y_d[i];
                cur.base_cylinder_y[i] = (y - cur.y) * (float)(Math.Cos(alpha)) + ((float)cur.base_cylinder_z[i] - cur.z) * (float)(Math.Sin(alpha)) + cur.y;
                cur.base_cylinder_y_d[i] = (y_d - cur.y) * (float)(Math.Cos(alpha)) + ((float)cur.base_cylinder_z_d[i] - cur.z) * (float)(Math.Sin(alpha)) + cur.y;
                float z = (float)cur.base_cylinder_z[i];
                float z_d = (float)cur.base_cylinder_z_d[i];
                cur.base_cylinder_z[i] = -(y - cur.y) * (float)(Math.Sin(alpha)) + (z - cur.z) * (float)(Math.Cos(alpha)) + cur.z;
                cur.base_cylinder_z_d[i] = -(y_d - cur.y) * (float)(Math.Sin(alpha)) + (z_d - cur.z) * (float)(Math.Cos(alpha)) + cur.z;
            }
            cur.x_alpha += alpha;
            cylinders[num] = cur;
        }

        public void turn_by_y(int num, float alpha)
        {
            cylinder_pr cur = (cylinder_pr)cylinders[num];
            for (int i = 0; i < cur.base_cylinder_x.Count; i++)
            {
                float x = (float)cur.base_cylinder_x[i];
                float x_d = (float)cur.base_cylinder_x_d[i];
                float z = (float)cur.base_cylinder_z[i];
                float z_d = (float)cur.base_cylinder_z_d[i];
                cur.base_cylinder_x[i] = (float)((x - cur.x) * (Math.Cos(alpha)) + (z - cur.z) * (Math.Sin(alpha))) + cur.x;
                cur.base_cylinder_x_d[i] = (float)((x_d - cur.x) * (Math.Cos(alpha)) + (z_d - cur.z) * (Math.Sin(alpha))) + cur.x;
                cur.base_cylinder_z[i] = (float)(-(x - cur.x) * (Math.Sin(alpha)) + (z - cur.z) * (Math.Cos(alpha))) + cur.z;
                cur.base_cylinder_z_d[i] = (float)(-(x_d - cur.x) * (Math.Sin(alpha)) + (z_d - cur.z) * (Math.Cos(alpha))) + cur.z;
            }
            cur.y_alpha += alpha;
            cylinders[num] = cur;
        }

        public void turn_by_z(int num, float alpha)
        {
            cylinder_pr cur = (cylinder_pr)cylinders[num];
            for (int i = 0; i < cur.base_cylinder_x.Count; i++)
            {
                float x = (float)cur.base_cylinder_x[i];
                float x_d = (float)cur.base_cylinder_x_d[i];
                float y = (float)cur.base_cylinder_y[i];
                float y_d = (float)cur.base_cylinder_y_d[i];
                cur.base_cylinder_x[i] = (float)((x - cur.x) * (Math.Cos(alpha)) - (y - cur.y) * (Math.Sin(alpha))) + cur.x;
                cur.base_cylinder_x_d[i] = (float)((x_d - cur.x) * (Math.Cos(alpha)) - (y_d - cur.y) * (Math.Sin(alpha))) + cur.x;
                cur.base_cylinder_y[i] = (float)((x - cur.x) * (Math.Sin(alpha)) + (y - cur.y) * (Math.Cos(alpha))) + cur.y;
                cur.base_cylinder_y_d[i] = (float)((x_d - cur.x) * (Math.Sin(alpha)) + (y_d - cur.y) * (Math.Cos(alpha))) + cur.y;
            }
            cur.z_alpha += alpha;
            cylinders[num] = cur;
        }

        public void change_color(int num, int n, float r, float g, float b)
        {
            cylinder_pr cur = (cylinder_pr)cylinders[num];
            cur.cylinder_colors[n, 0] = r;
            cur.cylinder_colors[n, 1] = g;
            cur.cylinder_colors[n, 2] = b;
            cylinders[num] = cur;
        }

    }

    public class pryzma
    {
        public ArrayList pryzmas = new ArrayList();


        public struct pryzma_pr
        {
            public float[,] u_points;
            public float[,] d_points;
            public float x;
            public float y;
            public float z;
            public float H;
            public float L;
            public float[,] pryzma_colors;
            public float x_alpha;
            public float y_alpha;
            public float z_alpha;

        }

        public void pryzma_build(int num, float x, float y, float z, float l, float h, ref float[,] colors)
        {
            if (num == -1)
            {
                pryzma_pr cur = new pryzma_pr();
                cur.d_points = new float[5, 3];
                cur.u_points = new float[5, 3];
                cur.pryzma_colors = new float[7, 3];
                pryzmas.Add(cur);
                num = pryzmas.Count - 1;
            }
            pryzma_pr t = (pryzma_pr)pryzmas[num];
            float alpha = 0;
            for (int i = 0; i < 5; i++)
            {
                t.u_points[i, 0] = x + l * ((float)Math.Cos(alpha));
                t.u_points[i, 2] = z + l * ((float)Math.Sin(alpha));
                t.u_points[i, 1] = y;
                t.d_points[i, 0] = x + l * ((float)Math.Cos(alpha));
                t.d_points[i, 2] = z + l * ((float)Math.Sin(alpha));
                t.d_points[i, 1] = y + h;
                alpha += (float)(0.4 * 3.14);
            }
            t.H = h;
            t.L = l;
            t.x = x;
            t.y = y + h / 2;
            t.z = z;

            t.pryzma_colors[0, 0] = colors[0, 0];
            t.pryzma_colors[0, 1] = colors[0, 1];
            t.pryzma_colors[0, 2] = colors[0, 2];

            t.pryzma_colors[1, 0] = colors[1, 0];
            t.pryzma_colors[1, 1] = colors[1, 1];
            t.pryzma_colors[1, 2] = colors[1, 2];

            t.pryzma_colors[2, 0] = colors[2, 0];
            t.pryzma_colors[2, 1] = colors[2, 1];
            t.pryzma_colors[2, 2] = colors[2, 2];

            t.pryzma_colors[3, 0] = colors[3, 0];
            t.pryzma_colors[3, 1] = colors[3, 1];
            t.pryzma_colors[3, 2] = colors[3, 2];

            t.pryzma_colors[4, 0] = colors[4, 0];
            t.pryzma_colors[4, 1] = colors[4, 1];
            t.pryzma_colors[4, 2] = colors[4, 2];

            t.pryzma_colors[5, 0] = colors[5, 0];
            t.pryzma_colors[5, 1] = colors[5, 1];
            t.pryzma_colors[5, 2] = colors[5, 2];

            t.pryzma_colors[6, 0] = colors[6, 0];
            t.pryzma_colors[6, 1] = colors[6, 1];
            t.pryzma_colors[6, 2] = colors[6, 2];
            float ax = t.x_alpha;
            float ay = t.y_alpha;
            float az = t.z_alpha;
            t.x_alpha = 0.0f;
            t.y_alpha = 0.0f;
            t.z_alpha = 0.0f;
            pryzmas[num] = t;
            if (ax != 0.0) { turn_by_x(num, ax); }
            if (ay != 0.0) { turn_by_y(num, ay); }
            if (az != 0.0) { turn_by_z(num, az); }
        }

        public void turn_by_x(int num, float alpha)
        {
            pryzma_pr cur = (pryzma_pr)pryzmas[num];
            for (int i = 0; i < 5; i++)
            {
                float y = (float)cur.u_points[i, 1];
                float y_d = (float)cur.d_points[i, 1];
                cur.u_points[i, 1] = (float)((y - cur.y) * (Math.Cos(alpha)) + (cur.u_points[i, 2] - cur.z) * (Math.Sin(alpha))) + cur.y;
                cur.d_points[i, 1] = (float)((y_d - cur.y) * (Math.Cos(alpha)) + (cur.d_points[i, 2] - cur.z) * (Math.Sin(alpha))) + cur.y;
                float z = cur.u_points[i, 2];
                float z_d = cur.d_points[i, 2];
                cur.u_points[i, 2] = (float)(-(y - cur.y) * (Math.Sin(alpha)) + (z - cur.z) * (Math.Cos(alpha))) + cur.z;
                cur.d_points[i, 2] = (float)(-(y_d - cur.y) * (Math.Sin(alpha)) + (z_d - cur.z) * (Math.Cos(alpha))) + cur.z;
            }
            cur.x_alpha += alpha;
            pryzmas[num] = cur;
        }

        public void turn_by_y(int num, float alpha)
        {
            pryzma_pr cur = (pryzma_pr)pryzmas[num];
            for (int i = 0; i < 5; i++)
            {
                float x = cur.u_points[i, 0];
                float x_d = cur.d_points[i, 0];
                float z = cur.u_points[i, 2];
                float z_d = cur.d_points[i, 2];
                cur.u_points[i, 0] = (float)((x - cur.x) * (Math.Cos(alpha)) + (z - cur.z) * (Math.Sin(alpha))) + cur.x;
                cur.d_points[i, 0] = (float)((x_d - cur.x) * (Math.Cos(alpha)) + (z_d - cur.z) * (Math.Sin(alpha))) + cur.x;
                cur.u_points[i, 2] = (float)(-(x - cur.x) * (Math.Sin(alpha)) + (z - cur.z) * (Math.Cos(alpha))) + cur.z;
                cur.d_points[i, 2] = (float)(-(x_d - cur.x) * (Math.Sin(alpha)) + (z_d - cur.z) * (Math.Cos(alpha))) + cur.z;
            }
            cur.y_alpha += alpha;
            pryzmas[num] = cur;
        }

        public void turn_by_z(int num, float alpha)
        {
            pryzma_pr cur = (pryzma_pr)pryzmas[num];
            for (int i = 0; i < 5; i++)
            {
                float x = cur.u_points[i, 0];
                float x_d = cur.d_points[i, 0];
                float y = cur.u_points[i, 1];
                float y_d = cur.d_points[i, 1];
                cur.u_points[i, 0] = (float)((x - cur.x) * (Math.Cos(alpha)) - (y - cur.y) * (Math.Sin(alpha))) + cur.x;
                cur.d_points[i, 0] = (float)((x_d - cur.x) * (Math.Cos(alpha)) - (y_d - cur.y) * (Math.Sin(alpha))) + cur.x;
                cur.u_points[i, 1] = (float)((x - cur.x) * (Math.Sin(alpha)) + (y - cur.y) * (Math.Cos(alpha))) + cur.y;
                cur.d_points[i, 1] = (float)((x_d - cur.x) * (Math.Sin(alpha)) + (y_d - cur.y) * (Math.Cos(alpha))) + cur.y;
            }
            cur.z_alpha += alpha;
            pryzmas[num] = cur;
        }

        public void change_color(int num, int n, float r, float g, float b)
        {
            pryzma_pr cur = (pryzma_pr)pryzmas[num];
            cur.pryzma_colors[n, 0] = r;
            cur.pryzma_colors[n, 1] = g;
            cur.pryzma_colors[n, 2] = b;
            pryzmas[num] = cur;
        }
    }
}
