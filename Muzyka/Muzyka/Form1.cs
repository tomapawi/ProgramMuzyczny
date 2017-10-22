using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Muzyka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "All files|*.*" })
            {
                if(ofd.ShowDialog()==DialogResult.OK)
                {
                    List<MediaFile> files = new List<MediaFile>();
                    foreach(string fileName in ofd.FileNames)
                    {
                        FileInfo fi= new FileInfo(fileName);
                        files.Add(new MediaFile() {FileName=Path.GetFileNameWithoutExtension(fi.FullName),Path=fi.FullName});
                    }
                    listBox1.DataSource=files;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = listBox1.SelectedItem as MediaFile;
            if (file != null)
            {
                axWindowsMediaPlayer1.URL = file.Path;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.ValueMember = "Path";
            listBox1.DisplayMember = "FileName";
        }
    }
}
