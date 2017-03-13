using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace CGaG_Lab04 {
    class Program {

        static RenderWindow Win;
        static Matrix SpaceToWindow;
        static Random rand = new Random( );

        static void Main(string[ ] args) {

            Win = new RenderWindow(new SFML.Window.VideoMode(1024, 720), "CGaG Lab04");
            Win.Position = new Vector2i(0, 0);
            Win.SetVerticalSyncEnabled(true);
            Win.Closed += OnClosed;

            SpaceToWindow = SimpleUtils.SpaceToWindow(new FloatRect(50, 50, 10, 10), new IntRect(0, 0, (int)Win.Size.X, (int)Win.Size.Y));

            SetProjectionOrtho(Win, new FloatRect(15, 15, 40, 40), new IntRect(120, 120, 120, 120));

            while (Win.IsOpen) {
                Win.DispatchEvents( );
                Win.Clear(new Color(30, 30, 30));

                // TODO: Draw
                {
                    CircleShape circle = new CircleShape(20, 24);
                    circle.Position = new Vector2f(35, 35);
                    Win.Draw(circle);
                }

                Win.Display( );
            }
        }

        private static void OnClosed(Object sender, EventArgs e) {
            Win.Close( );
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
    }
}
