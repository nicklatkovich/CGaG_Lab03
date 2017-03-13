using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGaG_Lab04 {

    public class Matrix {
        private float[ ][ ] array;

        public Matrix(uint width, uint height, float defaultValue = 0f) {
            if (width == 0 || height == 0) {
                throw new System.Exception("The matrix size can not be zero");
            }
            this.array = new float[width][ ];
            for (uint i = 0; i < width; i++) {
                this.array[i] = new float[height];
                for (uint j = 0; j < height; j++) {
                    this.array[i][j] = defaultValue;
                }
            }
        }

        public Matrix(uint vectorSize, float defaultValue = 0f) : this(vectorSize, 1, defaultValue) { }

        public Matrix(Matrix copy) : this(copy.Width, copy.Height) {
            for (uint i = 0; i < this.Width; i++) {
                for (uint j = 0; j < this.Height; j++) {
                    this.array[i][j] = copy[i, j];
                }
            }
        }

        public Matrix(float[][] values) : this((uint)values.Length, (uint)values[0].Length, 0f) {
            for (uint i = 0; i < Width; i++) {
                for (uint j = 0; j < Height; j++) {
                    this[i, j] = values[i][j];
                }
            }
        }

        public uint Width { get { return (uint)this.array.Length; } }

        public uint Height { get { return (uint)this.array[0].Length; } }

        public float X {
            get { return this.array[0][0]; }
            set { this.array[0][0] = value; }
        }

        public float Y {
            get { return this.array[1][0]; }
            set { this.array[1][0] = value; }
        }

        public float Z {
            get { return this.array[2][0]; }
            set { this.array[2][0] = value; }
        }

        public float this[uint x, uint y] {
            get { return this.array[x][y]; }
            set { this.array[x][y] = value; }
        }

        public void CheckForVector( ) {
            if (this.Height != 1) {
                throw new System.Exception("Is not a vector");
            }
        }

        public float this[uint x] {
            get {
                CheckForVector( );
                return this.array[x][0];
            }
            set {
                CheckForVector( );
                this.array[x][0] = value;
            }
        }

        public static Matrix operator -(Matrix matrix) {
            Matrix result = new Matrix(matrix.Width, matrix.Height);
            for (uint i = 0; i < matrix.Width; i++) {
                for (uint j = 0; j < matrix.Height; j++) {
                    result[i, j] = -matrix[i, j];
                }
            }
            return result;
        }

        public void checkForMonospaced(Matrix matrix) {
            if (this.Width != matrix.Width || this.Height != matrix.Height) {
                throw new System.Exception("Matrices are not monospaced");
            }
        }

        public static Matrix operator +(Matrix m1, Matrix m2) {
            m1.checkForMonospaced(m2);
            Matrix result = new Matrix(m1.Width, m1.Height);
            for (uint i = 0; i < m1.Width; i++) {
                for (uint j = 0; j < m1.Height; j++) {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2) {
            return m1 + (-m2);
        }

        public static Matrix operator *(Matrix m1, Matrix m2) {
            if (m1.Height != m2.Width) {
                throw new System.Exception("Can not multiple this matrices");
            }
            Matrix result = new Matrix(m1.Width, m2.Height);
            for (uint i = 0; i < result.Width; i++) {
                for (uint j = 0; j < result.Height; j++) {
                    float sum = 0;
                    for (uint r = 0; r < m1.Height; r++) {
                        sum += m1[i, r] * m2[r, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static explicit operator float(Matrix matrix) {
            if (matrix.Width != 1 || matrix.Height != 1) {
                throw new System.Exception("Matrix to float is not alowed (Matrix is not [1,1])");
            } else {
                return matrix[0, 0];
            }
        }

        public static Matrix operator +(Matrix matrix, float x) {
            Matrix result = new Matrix(matrix);
            for (uint i = 0; i < matrix.Width; i++) {
                for (uint j = 0; j < matrix.Height; j++) {
                    result[i, j] += x;
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix matrix, float x) {
            return matrix + (-x);
        }

        public Matrix Transpose {
            get {
                Matrix result = new Matrix(this.Height, this.Width);
                for (uint i = 0; i < result.Width; i++) {
                    for (uint j = 0; j < result.Height; j++) {
                        result[i, j] = this.array[j][i];
                    }
                }
                return result;
            }
        }

        public void Randomize(int minValue, int maxValue, Random rand = null) {
            if (rand == null) {
                rand = new Random( );
            }
            for (uint i = 0; i < this.Width; i++) {
                for (uint j = 0; j < this.Height; j++) {
                    this.array[i][j] = rand.Next(minValue, maxValue);
                }
            }
        }
    }
}
