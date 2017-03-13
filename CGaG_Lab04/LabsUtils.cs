using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
