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
            // File paths
            string windowsHostFile = "C:/Windows/System32/drivers/etc/hosts";
            string localHostFile = Directory.GetCurrentDirectory() + "/hosts";

            // Copy hosts file
            File.Copy(windowsHostFile, localHostFile, true);

            // Fix lines, fix content
            string[] allLines = File.ReadAllLines(localHostFile);
            if (allLines != null)
            {
                for (int i = 0; i < allLines.Length; i++)
                {
                    if (allLines[i].StartsWith("#") == false)
                    {
                        List<string> hostLine = new List<string>(allLines[i].Split(new char[0]));
                        if (hostLine != null && hostLine.Count > 0)
                        {
                            hostLine.RemoveAll(x => string.IsNullOrWhiteSpace(x));
                            if (hostLine.Count >= 2)
                            {
                                int rowLine = this.dataGridView.Rows.Add();
                                // Hostname
                                this.dataGridView.Rows[rowLine].Cells[0].Value = hostLine[1];
                                // IP
                                this.dataGridView.Rows[rowLine].Cells[1].Value = hostLine[0];
                            }
                        }
                    }
                }
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Get hostname infos
            List<HostnameInfos> hostnameInfos = new List<HostnameInfos>();
            foreach (DataGridViewRow row in this.dataGridView.Rows)
            {
                if (string.IsNullOrWhiteSpace((string)row.Cells[0].Value) == false
                    && string.IsNullOrWhiteSpace((string)row.Cells[1].Value) == false)
                {
                    hostnameInfos.Add(new HostnameInfos() { Hostname = (string)row.Cells[0].Value, Ip = (string)row.Cells[1].Value });
                }
            }

            // File paths
            string windowsHostFile = "C:/Windows/System32/drivers/etc/hosts";
            string localHostFile = Directory.GetCurrentDirectory() + "/hosts";

            // Copy hosts file
            File.Copy(windowsHostFile, localHostFile, true);

            // End content
            string fileContent = string.Empty;

            // Fix lines, fix content
            string[] allLines = File.ReadAllLines(localHostFile);
            if (allLines != null)
            {
                for (int i=0; i<allLines.Length; i++)
                {
                    if (allLines[i].StartsWith("#") == true)
                    {
                        fileContent += (allLines[i] + System.Environment.NewLine);
                    }
                }
            }
            
            // Add Hosts content
            if (hostnameInfos != null && hostnameInfos.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(fileContent) == false)
                    fileContent += System.Environment.NewLine;

                for (int i=0; i<hostnameInfos.Count; i++)
                {
                    fileContent += (hostnameInfos[i].Ip + "\t\t" + hostnameInfos[i].Hostname + System.Environment.NewLine);
                }
            }
            
            // Write
            File.WriteAllLines(localHostFile, new string[] { fileContent });

            // Copy back
            File.Copy(localHostFile, windowsHostFile, true);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.dataGridView.Rows.Add();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.RowIndex != (this.dataGridView.RowCount - 1))
                    this.dataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }

    public class HostnameInfos
    {
        public string Ip;
        public string Hostname;
    }
}
