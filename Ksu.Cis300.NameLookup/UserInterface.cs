/* UserInterface.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A GUI for a program that looks up information on names.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The information for each name.
        /// </summary>
        private Dictionary<string, FrequencyAndRank> _nameInformation = new Dictionary<string, FrequencyAndRank>();

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads the given input file into a dictionary.
        /// </summary>
        /// <param name="fn">The name of the file to read.</param>
        /// <returns>A dictionary whose keys are the names from the file and whose values give the frequency and 
        /// rank for each name.</returns>
        private static Dictionary<string, FrequencyAndRank> ReadFile(string fn)
        {
            Dictionary<string, FrequencyAndRank> d = new Dictionary<string, FrequencyAndRank>();
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    d.Add(name, new FrequencyAndRank(freq, rank));
                }
            }
            return d;
        }

        /// <summary>
        /// Handles a Click event on the "Open Data File" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpen_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _nameInformation = ReadFile(uxOpenDialog.FileName);
                    _nameInformation.Drawing.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "Get Statistics" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            if (_nameInformation.TryGetValue(name, out FrequencyAndRank info))
            {
                uxFrequency.Text = info.Frequency.ToString();
                uxRank.Text = info.Rank.ToString();
            }
            else
            {
                MessageBox.Show("Name not found.");
                uxFrequency.Text = "";
                uxRank.Text = "";
            }
        }
    }
}
