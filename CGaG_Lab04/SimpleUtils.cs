﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;

namespace CGaG_Lab04 {
    static class SimpleUtils {
        
        public static Matrix SpaceToWindow(FloatRect world_coords, IntRect win_coords) {
            float
                dxw = win_coords.Width,
                dyw = win_coords.Height,
                dx = world_coords.Left,
                dy = world_coords.Top,
                kx = dxw / dx,
                ky = dyw / dy;
            return new Matrix(new float[ ][ ] {
                new float[] { kx, 0, win_coords.Left - kx * world_coords.Left },
                new float[] { 0, ky, win_coords.Top - ky * world_coords.Top },
                new float[] { 0, 0, 1 }
            });
        }

        public static VertexArray GenerateLineWithThickness(List<Vector2f> points, Color color, float thickness) {
            var array = new VertexArray(PrimitiveType.TrianglesStrip);
            for (int i = 1; i < points.Count + 2; i++) {
                Vector2f v0 = points[(i - 1) % points.Count];
                Vector2f v1 = points[i % points.Count];
                Vector2f v2 = points[(i + 1) % points.Count];
                Vector2f v01 = (v1 - v0).Normalized( );
                Vector2f v12 = (v2 - v1).Normalized( );
                Vector2f d = (v01 + v12).GetNormal( );
                float dot = d.Dot(v01.GetNormal( ));
                d *= thickness / 2f / dot; //< TODO: Add flat miter joint in extreme cases
                array.Append(new Vertex(v1 + d, color));
                array.Append(new Vertex(v1 - d, color));
            }
            return array;
        }
    }
}