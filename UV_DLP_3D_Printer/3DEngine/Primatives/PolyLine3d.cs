using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Engine3D;
using UV_DLP_3D_Printer;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using System.IO;
namespace Engine3D
{
    public class PolyLine3d
    {
        //classification flags for support generation
        public enum eCLASSIFICATION 
        {
            eIsContained, 
            eContaining,
            eCrosses,
            eNone
        }
        public List<Point3d> m_points; // world coordinate points
        public Point3d m_center;
        public Color m_color;
        // precached
        public float minx, maxx;
        public float miny, maxy;
        public float minz, maxz;
        Point3d pmin, pmax;
        public bool cached = false; // bbox is calculated
        public int linewidth;
        public bool visible;
        public int tag;
        // this derived reference is a cheat. Basically, we need to retain information
        // that this polygon was dereived from, so we can later look up it's neighbors
        public Polygon m_derived; // 
        public PolyLine3d m_plyderived;
        public static int TAG_EXTERIOR = 1;
        public static int TAG_INTERIOR = 2;

        public PolyLine3d(PolyLine3d src) 
        {
            tag = 0;
            m_color = src.m_color;
            m_derived = src.m_derived;
            minx = src.minx;
            miny = src.miny;
            minz = src.minz;
            maxx = src.maxx;
            maxy = src.maxy;
            maxz = src.maxz;
            linewidth = 1;
            visible = true;
            m_points = new List<Point3d>();
            foreach (Point3d pnt in src.m_points) 
            {
                Point3d p = new Point3d(pnt.x, pnt.y, pnt.z);
                m_points.Add(p);                
            }
        }
        /// <summary>
        /// This function returns a classification to see if this polyline
        /// contains wholly the 'test' polyline,
        /// is contained by the 'test' polyline,      
        /// crosses the 'test' polyline,
        /// or does not intersect the contained polyline
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public eCLASSIFICATION Classify(PolyLine3d test) 
        {
            // as a first pass, we're going to simply check bounding boxes
            //CalcBBox();
            //test.CalcBBox();
            bool p1, p2, p3, p4;
            bool t1, t2, t3, t4;
            t1 = BBOXContains(test.minx, test.miny);
            t2 = BBOXContains(test.minx, test.maxy);
            t3 = BBOXContains(test.maxx, test.miny);
            t4 = BBOXContains(test.maxx, test.maxy);
            //check to see if this contains all 4 points of test OR
            if (t1 && t2 && t3 && t4)
                return eCLASSIFICATION.eContaining;

            // check to see if test contains all points of this
            p1 = test.BBOXContains(minx, miny);
            p2 = test.BBOXContains(minx, maxy);
            p3 = test.BBOXContains(maxx, miny);
            p4 = test.BBOXContains(maxx, maxy);
            if (p1 && p2 && p3 && p4)
                return eCLASSIFICATION.eIsContained;

            //no overlap between any points - disjoint
            if ((t1 == false && t2== false && t3 == false && t4 == false) && 
                (p1 == false && p2== false && p3 == false && p4 == false))
                return eCLASSIFICATION.eNone;

            //otherwise, we must be crossing somehow.
            return eCLASSIFICATION.eCrosses;
        }

        public bool BBOXContains(float x, float y)
        {
            if ((x >= minx && x <= maxx) && (y >= miny && y <= maxy))
                return true;
            return false;
        }

        // Return True if the point is in the polygon.
        public bool PointInPolygon(float X, float Y)
        {
            // Get the angle between the point and the
            // first and last vertices.
            int max_point = m_points.Count - 1;
            float total_angle = GetAngle(
                m_points[max_point].x, m_points[max_point].y,
                X, Y,
                m_points[0].x, m_points[0].y);

            // Add the angles from the point
            // to each other pair of vertices.
            for (int i = 0; i < max_point; i++)
            {
                total_angle += GetAngle(
                    m_points[i].x, m_points[i].y,
                    X, Y,
                    m_points[i + 1].x, m_points[i + 1].y);
            }

            // The total angle should be 2 * PI or -2 * PI if
            // the point is in the polygon and close to zero
            // if the point is outside the polygon.
            return (Math.Abs(total_angle) > 0.000001);
        }
        // Return the angle ABC.
        // Return a value between PI and -PI.
        // Note that the value is the opposite of what you might
        // expect because Y coordinates increase downward.
        public static float GetAngle(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the dot product.
            float dot_product = DotProduct(Ax, Ay, Bx, By, Cx, Cy);

            // Get the cross product.
            float cross_product = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy);

            // Calculate the angle.
            return (float)Math.Atan2(cross_product, dot_product);
        }
        // Return the dot product AB · BC.
        // Note that AB · BC = |AB| * |BC| * Cos(theta).
        private static float DotProduct(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the dot product.
            return (BAx * BCx + BAy * BCy);
        }
        // Return the cross product AB x BC.
        // The cross product is a vector perpendicular to AB
        // and BC having length |AB| * |BC| * Sin(theta) and
        // with direction given by the right-hand rule.
        // For two vectors in the X-Y plane, the result is a
        // vector with X and Y components 0 so the Z component
        // gives the vector's length and direction.
        public static float CrossProductLength(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy - BAy * BCx);
        }

        public eCLASSIFICATION Classify2(PolyLine3d test)
        {
            int incnt, outcnt;
            incnt = 0;
            outcnt = 0;
            foreach (Point3d pnt in test.m_points) 
            {
                //iterate through each point
                if(PointInPolygon(pnt.x,pnt.y))
                {
                    incnt++;
                }else
                {
                    outcnt++;
                }
            }
            if(incnt == test.m_points.Count)
                return eCLASSIFICATION.eIsContained;

            if (outcnt == test.m_points.Count)
                return eCLASSIFICATION.eNone;

            return eCLASSIFICATION.eCrosses;
        }


        public Point3d Center
        {
            get { return m_center; }
        }
        //Estimating the centroid
        public void CalcCenter() 
        {            
            m_center = new Point3d();
            m_center.Set(0, 0, 0);
            foreach (Point3d pnt in m_points) 
            {
                m_center.x += pnt.x;
                m_center.y += pnt.y;
                m_center.z += pnt.z;
            }
            m_center.x /= m_points.Count;
            m_center.y /= m_points.Count;
            m_center.z /= m_points.Count;

        }

        public void SetZ(float z) 
        {
            //sets the z val of all the points
            foreach (Point3d pnt in m_points)
            {
                pnt.z = z;
            }
        }
        public PolyLine3d(Point3d p1, Point3d p2, Color clr) 
        {
            m_points = new List<Point3d>();
            linewidth = 1;
            m_color = clr;
            visible = true;
            m_points.Add(p1);
            m_points.Add(p2);
        }
        public PolyLine3d() 
        {
            m_points = new List<Point3d>();
            m_color = Color.Green;
            linewidth = 1;
            visible = true;
        }
        /// <summary>
        /// Split this long polyline into a list of shorter segments
        /// </summary>
        /// <returns></returns>
        public List<PolyLine3d> Split() 
        {
            List<PolyLine3d> segments = new List<PolyLine3d>();
            try
            {
                for (int c = 0; c < m_points.Count - 1; c++)
                {
                    PolyLine3d ply = new PolyLine3d();
                    ply.m_plyderived = this; // make all these children of the main
                    ply.m_points.Add(m_points[c]);
                    ply.m_points.Add(m_points[c + 1]);
                    segments.Add(ply);
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
            return segments;
        }
        /// <summary>
        /// Calculate the bounding box for this polyline
        /// </summary>
        public void CalcBBox() 
        {
            try
            {
                minx = maxx = m_points[0].x;
                miny = maxy = m_points[0].y;
                minz = maxz = m_points[0].z;
                foreach (Point3d pnt in m_points) 
                {
                    if (pnt.x < minx) minx = pnt.x;
                    if (pnt.y < miny) miny = pnt.y;
                    if (pnt.z < minz) minz = pnt.z;
                    if (pnt.x > maxx) maxx = pnt.x;
                    if (pnt.y > maxy) maxy = pnt.y;
                    if (pnt.z > maxz) maxz = pnt.z;
                }
                cached = true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex.Message);
            }
        }
        /*
         This function assumes that the polyline consists of 2 points
         */
        public Point3d IntersectZ(float zcur)
        {
            try
            {                
                // now, using the 3d line equation, calculate the x/y intersection of the z plane
                // the line is in the 0 and 1 index (start/end)
                Point3d p1 = (Point3d)m_points[0];
                Point3d p2 = (Point3d)m_points[1];
                
                //if both points are above or below it, return nothing
                if ((p1.z > zcur && p2.z > zcur) || (p1.z < zcur && p2.z < zcur))
                {
                    return null;// no intersection
                }

                // if both points are on the line
                if (p2.z == zcur && p1.z == zcur)
                    return null;

                // if one points z cordinate equals the z level:
                if (p1.z == zcur || p2.z == zcur) 
                {
                    // if the other point is below, return nothing
                    if ((p1.z == zcur && p2.z < zcur) || (p2.z == zcur && p1.z < zcur))
                    {
                        return null;
                    }
                    // if the other point is above, return the first point
                    if (p1.z == zcur && p2.z > zcur) 
                        return p1;
                    if (p2.z == zcur && p1.z > zcur) 
                        return p2;
                }


                Point3d p3d = new Point3d();                                
                // if 1 is above and 1 is below, calculate it.
            //    if ((p1.z > zcur && p2.z < zcur) || (p1.z < zcur && p2.z > zcur)) // i think this check is unessariy at this point
                //{
                    //should pre-cache this too
                if (cached == false)
                {
                    minx = (float)Math.Min(p1.x, p2.x);
                    maxx = (float)Math.Max(p1.x, p2.x);
                    miny = (float)Math.Min(p1.y, p2.y);
                    maxy = (float)Math.Max(p1.y, p2.y);
                    minz = (float)Math.Min(p1.z, p2.z);
                    maxz = (float)Math.Max(p1.z, p2.z);
                    if (p1.z < p2.z) // find the point with the min z
                    {
                        pmin = p1;
                        pmax = p2;
                    }
                    else
                    {
                        pmin = p2;
                        pmax = p1;
                    }

                    cached = true;
                }
                float zrange = maxz - minz;// the range of the z coord
                float scale = (float)((zcur - minz) / zrange);
                p3d.z = zcur; // set to the current z
                //p3d.x = LERP(pmin.x, pmax.x, scale); // do the intersection
                //p3d.y = LERP(pmin.y, pmax.y, scale);
                p3d.x =  (pmax.x - pmin.x) * scale + pmin.x;
                p3d.y =  (pmax.y - pmin.y) * scale + pmin.y;

                return p3d;
            }
            catch (Exception) 
            {
                return null;
            }
        }
        private static double LERP(double a, double b, double c) { return (double)(((b) - (a)) * (c) + (a)); }
        public void AddPoint(Point3d pnt) 
        {
            m_points.Add(pnt);
        }

        public void AddPoints(Point3d[] pnts) 
        {
            m_points.AddRange(pnts);
        }

        public bool PointInPoly2D(float x, float y)
        {
            int i, j, nvert = m_points.Count;
            bool c = false;

            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((m_points[i].y >= y) != (m_points[j].y >= y)) &&
                    (x <= (m_points[j].x - m_points[i].x) * (y - m_points[i].y) / (m_points[j].y - m_points[i].y) + m_points[i].x)
                  )
                    c = !c;
            }

            return c;
        }

        public void RenderGL() 
        {
            try
            {
                if (!visible)
                    return;
                //.Lines);
                GL.Color3(m_color);
                GL.LineWidth(linewidth);
                GL.BindTexture(TextureTarget.Texture2D, 0);
                GL.Enable(EnableCap.LineSmooth);
                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                GL.Hint(HintTarget.LineSmoothHint, HintMode.DontCare);
                GL.Begin(PrimitiveType.LineLoop);
                //var i = 0;
                foreach (Point3d p in this.m_points)
                {
                    GL.Vertex3(p.x, p.y, p.z);
                }
                GL.End();
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogError(ex);
            }
        }
        public bool Load(StreamReader sr) 
        {
            try
            {
                //load color
                int a = byte.Parse(sr.ReadLine());
                int r = byte.Parse(sr.ReadLine()); //R
                int g = byte.Parse(sr.ReadLine()); //G
                int b = byte.Parse(sr.ReadLine()); //B
                m_color = Color.FromArgb(a, r, g, b);

                //load numer of points
                int npoint = int.Parse(sr.ReadLine());
                //load points
                for (int c = 0; c< npoint; c++)
                {
                    Point3d p = new Point3d();
                    p.Load(sr);
                    m_points.Add(p);
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }        
        }
        public bool Save(StreamWriter sw) 
        {
            try
            {
                //save color
                sw.WriteLine(m_color.A);
                sw.WriteLine(m_color.R);
                sw.WriteLine(m_color.G);
                sw.WriteLine(m_color.B);
                //save numer of points
                sw.WriteLine(m_points.Count);
                foreach (Point3d p in m_points) 
                {
                    p.Save(sw);
                }
                //save points
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
        
    }
}
