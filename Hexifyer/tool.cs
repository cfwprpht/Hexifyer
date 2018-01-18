using System;

namespace Hexifyer {
    /// <summary>
    /// Enumuration for Hex Alligning.
    /// </summary>
    public enum HexAllign {
        /// <summary>
        /// Allign Hex to 4 byte blocks.
        /// </summary>
        x4 = 4,
        /// <summary>
        /// Allign Hex to 8 byte blocks.
        /// </summary>
        x8 = 8,
        /// <summary>
        /// Allign Hex to 16 byte blocks.
        /// </summary>
        x16 = 16
    }

    /// <summary>
    /// Enumuration for Byte Alligning.
    /// </summary>
    public enum ByteAllign {
        /// <summary>
        /// Alling a single byte to Hex.
        /// </summary>
        b1 = 1,
        /// <summary>
        /// Allign two bytes to Hex.
        /// </summary>
        b2 = 2,
        /// <summary>
        /// Allign four bytes to Hex.
        /// </summary>
        b4 = 4,
        /// <summary>
        /// Allign eight bytes to Hex.
        /// </summary>
        b8 = 8,
        /// <summary>
        /// Allign sixteen bytes to Hex.
        /// </summary>
        b16 = 16
    }

    public static class ArrayExtension {
        /// <summary>
        /// Checks a Array for existens of a value.
        /// </summary>
        /// <typeparam name="T">The Type of the array to use and the value to add.</typeparam>
        /// <param name="source">The source Array.</param>
        /// <param name="value">The value to check for existens.</param>
        /// <returns>True if the source Array contains the value to check for, else false.</returns>
        public static bool Contains<T>(this T[] source, T value) {
            if (source == null) throw new FormatException("Null Refernce", new Exception("The Array to check for a value existens is not Initialized."));
            foreach (T check in source) if (check.Equals(value)) return true;
            return false;
        }
    }
}
