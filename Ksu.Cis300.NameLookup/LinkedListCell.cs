/* LinkedListCell.cs
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
    /// A single cell of a linked list.
    /// </summary>
    /// <typeparam name="T">The type of the data stored in the cell.</typeparam>
    public class LinkedListCell<T>
    {
        /// <summary>
        /// Gets or sets the data element stored in the cell.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets the next element in the list.
        /// </summary>
        public LinkedListCell<T> Next { get; set; }
    }
}
