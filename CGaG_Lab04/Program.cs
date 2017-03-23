using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CGaG_Lab04 {
    class Program {

        public const float Pi3 = 3f * (float)Math.PI;
        public const float Pi6 = 6f * (float)Math.PI;

        static RenderWindow Win;
        static Random rand = new Random( );
        static uint State = 0;
        static Keyboard.Key[ ] KeysForState = {
            Keyboard.Key.Num0,
            Keyboard.Key.Num1,
            Keyboard.Key.Num2,
            Keyboard.Key.Num3,
            Keyboard.Key.Num4,
            Keyboard.Key.Num5,
        };

        static Pen Pen1 = new Pen(Color.Red);
        static Pen Pen2 = new Pen(Color.Green);
        static Pen Pen3 = new Pen(Color.Red, 3, Pen.LineStyle.Dash_Dot);
        static Pen Pen4 = new Pen(Color.Red, 2);
        static Pen AxisPen124 = new Pen(Color.Blue, 2);
        static Pen AxisPen3 = new Pen(new Color(191, 191, 191), 2);
        static FloatRect WorldCoords1 = new FloatRect(-Pi3, -Pi3, Pi6, Pi6);
        static FloatRect WorldCoords2 = new FloatRect(-5, -5, 10, 10);
        static FloatRect WorldCoords3 = new FloatRect(0, -Pi3, Pi6, Pi6);
        static FloatRect WorldCoords4 = new FloatRect(-10, -2, 20, 18);
        static IntRect WinCoords;
        static IntRect WinCoords1;
        static IntRect WinCoords2;
        static IntRect WinCoords3;
        static IntRect WinCoords4;

        static void Main(string[ ] args) {

            Win = new RenderWindow(new SFML.Window.VideoMode(640, 640), "CGaG Lab04");
            WinCoords = new IntRect(0, 0, (int)Win.Size.X, (int)Win.Size.Y);
            Win.Position = new Vector2i(0, 0);
            Win.SetVerticalSyncEnabled(true);
            Win.Closed += OnClosed;
            {
                int w7 = (int)Win.Size.X / 7;
                int h7 = (int)Win.Size.Y / 7;
                WinCoords1 = new IntRect(w7, h7, 2 * w7, 2 * h7);
                WinCoords2 = new IntRect(4 * w7, h7, 2 * w7, 2 * h7);
                WinCoords3 = new IntRect(w7, 4 * h7, 2 * w7, 2 * h7);
                WinCoords4 = new IntRect(4 * w7, 4 * h7, 2 * w7, 2 * h7);
            }

            while (Win.IsOpen) {
                Win.DispatchEvents( );
                Win.Clear(new Color(30, 30, 30));

                // TODO: Draw
                {

                    for (uint i = 0; i < KeysForState.Length; i++) {
                        if (Keyboard.IsKeyPressed(KeysForState[i])) {
                            State = i;
                            break;
                        }
                    }

                    switch (State) {
                    case 0:
                        break;
                    case 1:
                        LabsUtils.DrawAxisses(Win, WorldCoords1, WinCoords, AxisPen124);
                        LabsUtils.DrawFunction(Win, LabsUtils.F1, WorldCoords1, WinCoords, Pen1);
                        break;
                    case 2:
                        LabsUtils.DrawAxisses(Win, WorldCoords2, WinCoords, AxisPen124);
                        LabsUtils.DrawFunction(Win, LabsUtils.F2, WorldCoords2, WinCoords, Pen2);
                        break;
                    case 3:
                        LabsUtils.DrawAxisses(Win, WorldCoords3, WinCoords, AxisPen3);
                        LabsUtils.DrawFunction(Win, LabsUtils.F3, WorldCoords3, WinCoords, Pen3);
                        break;
                    case 4:
                        LabsUtils.DrawAxisses(Win, WorldCoords4, WinCoords, AxisPen124);
                        LabsUtils.DrawFunction(Win, LabsUtils.F4, WorldCoords4, WinCoords, Pen4);
                        break;
                    case 5:
                        LabsUtils.DrawAxisses(Win, WorldCoords1, WinCoords1, AxisPen124);
                        LabsUtils.DrawFunction(Win, LabsUtils.F1, WorldCoords1, WinCoords1, Pen1);
                        LabsUtils.DrawAxisses(Win, WorldCoords1, WinCoords2, AxisPen124);
                        LabsUtils.DrawFunction(Win, LabsUtils.F2, WorldCoords2, WinCoords2, Pen2);
                        LabsUtils.DrawAxisses(Win, WorldCoords1, WinCoords3, AxisPen3);
                        LabsUtils.DrawFunction(Win, LabsUtils.F3, WorldCoords3, WinCoords3, Pen3);
                        LabsUtils.DrawAxisses(Win, WorldCoords1, WinCoords4, AxisPen124);
                        LabsUtils.DrawFunction(Win, LabsUtils.F4, WorldCoords4, WinCoords4, Pen4);
                        break;
                    }
                }

                Win.Display( );
            }
        }

        private static void OnClosed(Object sender, EventArgs e) {
            Win.Close( );
        }

    }
}
