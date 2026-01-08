using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsSetHostnameApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Define file paths for Windows hosts file and local copy
            string windowsHostFile = "C:/Windows/System32/drivers/etc/hosts";
            string localHostFile = Directory.GetCurrentDirectory() + "/hosts";

            // Copy the Windows hosts file to local directory for processing
            File.Copy(windowsHostFile, localHostFile, true);

            // Read all lines from the hosts file and parse non-comment entries
            string[] allLines = File.ReadAllLines(localHostFile);
            if (allLines != null)
            {
                for (int i = 0; i < allLines.Length; i++)
                {
                    // Skip comment lines (starting with #)
                    if (allLines[i].StartsWith("#") == false)
                    {
                        // Split line by whitespace to extract IP and hostname
                        List<string> hostLine = new List<string>(allLines[i].Split(new char[0]));
                        if (hostLine != null && hostLine.Count > 0)
                        {
                            // Remove empty entries from split result
                            hostLine.RemoveAll(x => string.IsNullOrWhiteSpace(x));
                            // Ensure we have at least IP and hostname
                            if (hostLine.Count >= 2)
                            {
                                int rowLine = this.dataGridView.Rows.Add();
                                // Add hostname to first column
                                this.dataGridView.Rows[rowLine].Cells[0].Value = hostLine[1];
                                // Add IP address to second column
                                this.dataGridView.Rows[rowLine].Cells[1].Value = hostLine[0];
                            }
                        }
                    }
                }
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Collect all hostname entries from the DataGridView, excluding empty rows
            List<HostnameInfos> hostnameInfos = new List<HostnameInfos>();
            foreach (DataGridViewRow row in this.dataGridView.Rows)
            {
                // Only add rows with both hostname and IP address filled
                if (string.IsNullOrWhiteSpace((string)row.Cells[0].Value) == false
                    && string.IsNullOrWhiteSpace((string)row.Cells[1].Value) == false)
                {
                    hostnameInfos.Add(new HostnameInfos() { Hostname = (string)row.Cells[0].Value, Ip = (string)row.Cells[1].Value });
                }
            }

            // Define file paths for Windows hosts file and local copy
            string windowsHostFile = "C:/Windows/System32/drivers/etc/hosts";
            string localHostFile = Directory.GetCurrentDirectory() + "/hosts";

            // Copy the Windows hosts file to local directory for processing
            File.Copy(windowsHostFile, localHostFile, true);

            // Initialize content string to build the new hosts file
            string fileContent = string.Empty;

            // Read all lines and preserve comment lines (starting with #)
            string[] allLines = File.ReadAllLines(localHostFile);
            if (allLines != null)
            {
                for (int i=0; i<allLines.Length; i++)
                {
                    // Keep all comment lines from the original file
                    if (allLines[i].StartsWith("#") == true)
                    {
                        fileContent += (allLines[i] + System.Environment.NewLine);
                    }
                }
            }
            
            // Append the new hostname entries to the file content
            if (hostnameInfos != null && hostnameInfos.Count > 0)
            {
                // Add a blank line before hostname entries if comments exist
                if (string.IsNullOrWhiteSpace(fileContent) == false)
                    fileContent += System.Environment.NewLine;

                // Format and add each hostname entry (IP followed by hostname)
                for (int i=0; i<hostnameInfos.Count; i++)
                {
                    fileContent += (hostnameInfos[i].Ip + "\t\t" + hostnameInfos[i].Hostname + System.Environment.NewLine);
                }
            }
            
            // Write the new content to the local hosts file
            File.WriteAllLines(localHostFile, new string[] { fileContent });

            // Copy the modified hosts file back to the Windows system directory
            File.Copy(localHostFile, windowsHostFile, true);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Add a new empty row to the DataGridView for user input
            this.dataGridView.Rows.Add();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle click events on DataGridView cells
            var senderGrid = (DataGridView)sender;
            // Check if the clicked column is a button column and row index is valid
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Remove the row if it's not the last (empty) row
                if (e.RowIndex != (this.dataGridView.RowCount - 1))
                    this.dataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }

    /// <summary>
    /// Data class to store hostname and IP address information.
    /// </summary>
    public class HostnameInfos
    {
        /// <summary>
        /// IP address associated with the hostname.
        /// </summary>
        public string Ip;
        
        /// <summary>
        /// Hostname or domain name.
        /// </summary>
        public string Hostname;
    }
}
