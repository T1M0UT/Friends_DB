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

namespace Friends_DB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string link = textBox3.Text;
            string grade = comboBox1.Text;
            bool leader = checkBox1.Checked;
            string img = textBox4.Text;
            dataGridView1.Rows.Add(name, surname, link, grade, leader, Image.FromFile(img));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedCells[0].RowIndex;
            dataGridView1.Rows.RemoveAt(index);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"DB.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int num;
                    string[] str;
                    try
                    {
                        string[] str1 = sr.ReadToEnd().Split('\n');
                        num = str1.Count();
                        dataGridView1.RowCount = num;
                        for (int i = 0; i < num; i++)
                        {
                            str = str1[i].Split(' ');
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                try
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = str[j];
                                }
                                catch
                                {

                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        sr.Close();
                    }
                }
            }
            catch (Exception exx)
            {
                Console.WriteLine(exx.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = @"DB.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                try
                                {
                                    sw.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + " ");

                                }
                                catch { }
                            }
                            sw.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception exx)
            {
                Console.WriteLine(exx.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile($"{textBox4.Text}");
            }
            catch { }
        }
    }
}
