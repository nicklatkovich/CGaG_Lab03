using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using static CGaG_Lab04.Pen;

namespace CGaG_Lab04 {
    static class LabsUtils {

        public static float F1(float x) {
            return (float)Math.Sin(x) / x;
        }

        public static float F2(float x) {
            return (float)Math.Pow(x, 3);
        }

        public static float F3(float x) {
            return (float)(Math.Sqrt(x) * Math.Sin(x));
        }

        public static float F4(float x) {
            return x * x;
        }

        static void SetProjectionOrtho(RenderWindow win, FloatRect world_view, IntRect win_view) {
            Vector2f scale = new Vector2f(
                win_view.Width / world_view.Width,
                win_view.Height / world_view.Height);
            Vector2f position = new Vector2f(
                world_view.Left - win_view.Left / scale.X,
                world_view.Top - win_view.Top / scale.Y);
            win.SetView(new View(new Vector2f(
                position.X + world_view.Width * win.Size.X / win_view.Width / 2,
                position.Y + world_view.Height * win.Size.Y / win_view.Height / 2), new Vector2f(
                world_view.Width * win.Size.X / win_view.Width,
                world_view.Height * win.Size.Y / win_view.Height)));
        }

        public static List<VertexArray> FunctionPresenter(Func<float, float> function, FloatRect borders, float x_step, Color cl, float line_width, LineStyle style) {

            bool[ ] lines = Lines[(int)style];
            List<Vector2f> vertexList = new List<Vector2f>( );
            //VertexArray result = new VertexArray(PrimitiveType.Lines);
            float start = borders.Left;
            float end = borders.Left + borders.Width;
            float up = borders.Top;
            float down = borders.Top + borders.Height;
            float y_prev = 0; // undefined
            float x_prev = 0; // undefined
            for (float x = start; x <= end; x += x_step) {
                try {
                    float y = function(x);
                    //result.Append(new Vertex(new Vector2f(x_prev, y_prev), cl));
                    //result.Append(new Vertex(new Vector2f(x, y), cl));
                    if (y < down && y > up) {
                        vertexList.Add(new Vector2f(x, y));
                    }
                    x_prev = x;
                    y_prev = y;
                } catch {
                }
            }
            //return result;
            return SimpleUtils.GenerateLineWithThickness(vertexList, cl, line_width, lines);
        }

        //public static void DrawAxisses(RenderWindow win, FloatRect world_coords, IntRect win_coords, Color cl, float thickness)

        public static void DrawFunction(RenderWindow win, Func<float, float> func, FloatRect world_coords, IntRect win_coords, Pen pen) {
            FloatRect reversWorldCoords = new FloatRect(world_coords.Left, world_coords.Top + world_coords.Height, world_coords.Width, -world_coords.Height);
            SetProjectionOrtho(win, reversWorldCoords, win_coords);
            float step = world_coords.Width / win_coords.Width;
            List<VertexArray> vertexesToDraw = FunctionPresenter(func, world_coords, step, pen.Color, pen.Width * step, pen.Style);
            foreach (var a in vertexesToDraw) {
                win.Draw(a);
            }
        }
    }
}
