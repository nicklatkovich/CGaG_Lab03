using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGaG_Lab04 {
    class Pen {

        public enum LineStyle {
            Solid = 0,
            Dash_Dot = 1
        }

        public LineStyle Style;

        public static readonly bool[ ][ ] Lines;
        static Pen( ) {
            Lines = new bool[ ][ ] {
                new bool[] { true },
                new bool[] {
                    true, true, true,
                    true, true, true,
                    false, false,
                    false, false,
                    true,
                    true,
                    false, false,
                    false, false,
                }
            };
        }

        private float _width;
        public float Width {
            get { return _width; }
            set {
                if (value < 0) {
                    throw new NegativeValueException( );
                }
                _width = value;
            }
        }

        public Color Color;

        public Pen(Color color, float width, LineStyle style) {
            Color = color;
            Width = width;
            Style = style;
        }

        public Pen(Color color, float width = 1) : this(color, width, LineStyle.Solid) { }

    }
}
