/* FrequencyAndRank.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// An immutable structure representing a frequency and a rank.
    /// </summary>
    public struct FrequencyAndRank
    {
        /// <summary>
        /// Gets the Frequency.
        /// </summary>
        public float Frequency { get; }

        /// <summary>
        /// Gets the Rank.
        /// </summary>
        public int Rank { get; }

        /// <summary>
        /// Initializes a FrequencyAndRank with the given values.
        /// </summary>
        /// <param name="freq">The frequency.</param>
        /// <param name="rank">The rank.</param>
        public FrequencyAndRank(float freq, int rank)
        {
            Frequency = freq;
            Rank = rank;
        }

        /// <summary>
        /// Obtains a string representation of the frequency and rank.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return Frequency + ", " + Rank;
        }
    }
}