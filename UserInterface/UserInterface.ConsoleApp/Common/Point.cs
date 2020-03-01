using System;

namespace UserInterface.ConsoleApp.Common
{
    public struct Point
    {

        #region Properties

        public int X { get; private set; }

        public int Y { get; private set; }

        #endregion /Properties

        #region Constructors

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion /Constructors

        #region Methods

        public override bool Equals(object obj)
        {
            var point = (Point)obj  ;
            return  this.X.Equals(point.X) && this.Y.Equals(point.Y);
        }

        public override int GetHashCode()
        {
            return ShiftAndWrap(X.GetHashCode(), 2) ^ Y.GetHashCode();
        }

        private int ShiftAndWrap(int value, int positions)
        {
            positions = positions & 0x1F;

            // Save the existing bit pattern, but interpret it as an unsigned integer.
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            // Preserve the bits to be discarded.
            uint wrapped = number >> (32 - positions);
            // Shift and wrap the discarded bits.
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }

        #endregion /Methods

    }
}
