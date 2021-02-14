using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace şifre_üretme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sifre.Text = "";
            string sifree = "";
            int rnd = 0;
            string kücük = "abcçdefgğhiıjklmnoöprsştuüvyz";
            string büyük = "ABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZ";
            string rakam = "123456789";
            string özel = ",.!'^+%&/?*";
            Random rnd_kh = new Random();
            Random rnd_bh = new Random();
            Random rnd_rk = new Random();
            Random rnd_ök = new Random();
            if (textBox1.Text==""||textBox2.Text==""||textBox3.Text==""||textBox4.Text=="")
            {
                MessageBox.Show("LÜTFEN BOŞ BIRAKMAYINIZ");
            }
            else
            {
                for (int i = 0; i < Convert.ToInt16(textBox2.Text); i++)
                {
                    rnd = rnd_bh.Next(0, büyük.Length - 1);
                    sifre.Text += büyük[rnd];

                }
                for (int i = 0; i < Convert.ToInt16(textBox1.Text); i++)
                {
                    rnd = rnd_kh.Next(0, kücük.Length - 1);
                    sifre.Text += kücük[rnd];
                }
                for (int i = 0; i < Convert.ToInt16(textBox3.Text); i++)
                {
                    rnd = rnd_rk.Next(0, rakam.Length - 1);
                    sifre.Text += rakam[rnd];
                }
                for (int i = 0; i < Convert.ToInt16(textBox4.Text); i++)
                {
                    rnd = rnd_ök.Next(0, özel.Length - 1);
                    sifre.Text += özel[rnd];
                }
                Random rnd_karistir = new Random();
                sifree = sifre.Text;
                sifre.Text = new string(sifree.ToCharArray().OrderBy(s => (rnd_karistir.Next(2) % 2) == 0).ToArray());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sifre.Text == "")
            {
                MessageBox.Show("lütfen önce şifre olusturunuz");
            }
            else
            {
                try
                {
                    string fileName = "C:/Users/HP/Desktop/sifre.txt";
                    string writeText = " şifre= " + sifre.Text;
                    FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Close();
                   

                    File.AppendAllText(fileName, Environment.NewLine + writeText);
                    MessageBox.Show("Kaydedildi");

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Kaydedilemedi" + Environment.NewLine + ex.Message);
                }

            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            StreamReader oku;
            oku = File.OpenText("C:/Users/HP/Desktop/sifre.txt");
            string yazi;
            while ((yazi = oku.ReadLine()) != null) //satır boş olana kadar satır satır okumaya devam eder
            {
                listBox1.Items.Add(yazi.ToString());
            }
            oku.Close();//okumayı kapat
            listBox1.Visible = !listBox1.Visible;

            
        }
    }
    }

