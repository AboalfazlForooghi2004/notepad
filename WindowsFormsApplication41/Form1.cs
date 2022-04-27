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

namespace WindowsFormsApplication41
{
    public partial class Form1 : Form
    {
        string strpath = "";
        bool strstatus = true;
        int sstart , log;
        string strtext = "";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()== DialogResult.OK)
            {
                strpath = saveFileDialog1.FileName;
                File.WriteAllText(strpath, textBox1.Text);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strpath=="")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    strpath = saveFileDialog1.FileName;
                    File.WriteAllText(strpath, textBox1.Text);
                    strstatus = true;
                }
            }
            else
            {
                File.WriteAllText(strpath, textBox1.Text);

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strstatus==true)
            {
                this.Close();
            }
            else
            {
                DialogResult dig = MessageBox.Show("save changes to the fallowing items?", "هشدار", MessageBoxButtons.YesNoCancel);
                if (dig==DialogResult.Yes)
                {
                   if (strpath=="")
                    {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                      {
                    strpath = saveFileDialog1.FileName;
                    File.WriteAllText(strpath, textBox1.Text);
                      }
                     }
            else
            {
                File.WriteAllText(strpath, textBox1.Text);
            } 
                }
                if (dig==DialogResult.No)
                {
                    this.Close();
                }
                if (dig==DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            strstatus = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strstatus==true)
            {
                textBox1.Clear();
            }
            else
            {
                   DialogResult dig = MessageBox.Show("save changes to the fallowing items?", "هشدار", MessageBoxButtons.YesNoCancel);
                if (dig==DialogResult.Yes)
                {
                   if (strpath=="")
                    {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                      {
                    strpath = saveFileDialog1.FileName;
                    File.WriteAllText(strpath, textBox1.Text);
                      }
                     }
            else
            {
                File.WriteAllText(strpath, textBox1.Text);
            } 
                }
                if (dig==DialogResult.No)
                {
                    textBox1.Clear();
                }
                if (dig==DialogResult.Cancel)
                {
                    return;
                }
            
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)

                strpath = openFileDialog1.FileName;
            textBox1.Text=File.ReadAllText(strpath);
            }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sstart = textBox1.SelectionStart;
            strtext = textBox1.SelectedText;
            log = textBox1.SelectionLength;
            textBox1.Text = textBox1.Text.Remove(sstart, log);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sstart = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(sstart, strtext);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strtext = textBox1.SelectedText;
        }
    }
}
