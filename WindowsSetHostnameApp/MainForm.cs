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
        // Constants for file paths
        private const string WINDOWS_HOSTS_FILE = "C:/Windows/System32/drivers/etc/hosts";
        private const string LOCAL_HOSTS_FILE = "hosts";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadHostsFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading hosts file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the hosts file and populates the DataGridView with hostname entries.
        /// </summary>
        private void LoadHostsFile()
        {
            string localHostFile = GetLocalHostsFilePath();

            // Copy the Windows hosts file to local directory for processing
            File.Copy(WINDOWS_HOSTS_FILE, localHostFile, true);

            // Read all lines from the hosts file and parse non-comment entries
            string[] allLines = File.ReadAllLines(localHostFile);
            if (allLines == null || allLines.Length == 0)
                return;

            foreach (string line in allLines)
            {
                // Skip comment lines and empty lines
                if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line))
                    continue;

                // Split line by whitespace to extract IP and hostname
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                
                // Ensure we have at least IP and hostname
                if (parts.Length >= 2)
                {
                    int rowLine = this.dataGridView.Rows.Add();
                    // Add hostname to first column
                    this.dataGridView.Rows[rowLine].Cells[0].Value = parts[1];
                    // Add IP address to second column
                    this.dataGridView.Rows[rowLine].Cells[1].Value = parts[0];
                }
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect all hostname entries from the DataGridView, excluding empty rows
                List<HostnameInfos> hostnameInfos = CollectHostnameEntries();

                if (hostnameInfos.Count == 0)
                {
                    MessageBox.Show("Please add at least one hostname entry.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveHostsFile(hostnameInfos);
                MessageBox.Show("Hosts file updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving hosts file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Collects all valid hostname entries from the DataGridView.
        /// </summary>
        private List<HostnameInfos> CollectHostnameEntries()
        {
            var hostnameInfos = new List<HostnameInfos>();
            foreach (DataGridViewRow row in this.dataGridView.Rows)
            {
                string hostname = row.Cells[0].Value?.ToString() ?? string.Empty;
                string ip = row.Cells[1].Value?.ToString() ?? string.Empty;

                // Only add rows with both hostname and IP address filled
                if (!string.IsNullOrWhiteSpace(hostname) && !string.IsNullOrWhiteSpace(ip))
                {
                    hostnameInfos.Add(new HostnameInfos { Hostname = hostname, Ip = ip });
                }
            }
            return hostnameInfos;
        }

        /// <summary>
        /// Saves the hostname entries to the Windows hosts file.
        /// </summary>
        private void SaveHostsFile(List<HostnameInfos> hostnameInfos)
        {
            string localHostFile = GetLocalHostsFilePath();

            // Copy the Windows hosts file to local directory for processing
            File.Copy(WINDOWS_HOSTS_FILE, localHostFile, true);

            // Build the new hosts file content using StringBuilder for efficiency
            var contentBuilder = new StringBuilder();

            // Read all lines and preserve comment lines
            string[] allLines = File.ReadAllLines(localHostFile);
            foreach (string line in allLines)
            {
                // Keep all comment lines from the original file
                if (line.StartsWith("#"))
                {
                    contentBuilder.AppendLine(line);
                }
            }

            // Append the new hostname entries
            if (hostnameInfos.Count > 0)
            {
                // Add a blank line before hostname entries if comments exist
                if (contentBuilder.Length > 0)
                    contentBuilder.AppendLine();

                // Format and add each hostname entry (IP followed by hostname)
                foreach (var entry in hostnameInfos)
                {
                    contentBuilder.AppendLine($"{entry.Ip}\t\t{entry.Hostname}");
                }
            }

            // Write the new content to the local hosts file
            File.WriteAllText(localHostFile, contentBuilder.ToString());

            // Copy the modified hosts file back to the Windows system directory
            File.Copy(localHostFile, WINDOWS_HOSTS_FILE, true);
        }

        /// <summary>
        /// Gets the full path to the local hosts file in the application directory.
        /// </summary>
        private string GetLocalHostsFilePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), LOCAL_HOSTS_FILE);
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
        /// Gets or sets the IP address associated with the hostname.
        /// </summary>
        public string Ip { get; set; }
        
        /// <summary>
        /// Gets or sets the hostname or domain name.
        /// </summary>
        public string Hostname { get; set; }
    }
}
