using System;
using System.IO;
using System.Windows.Forms;

namespace Txt_Tas_Kagit_Makas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sayaço, sayaçpc;
        Random rnd = new Random();
        string a, b;

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            sayaço = 0;
            sayaçpc = 0;
            a = "";
            b = "";

            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\pc.txt");
            string karakterler = "TKM";
            string pano = "";

            for (int i = 0; i < 100; i++)
            {
                pano = pano + karakterler[rnd.Next(karakterler.Length)] + "-";
            }
            a = pano;
            sw.WriteLine(a);
            textBox2.Text = a;
            sw.Close();

            StreamReader sd = new StreamReader(Application.StartupPath + "\\pc.txt");
            while (!sd.EndOfStream)
            {
                string[] pc = sd.ReadLine().Split('-');
                StreamReader so = new StreamReader(Application.StartupPath + "\\oyuncu.txt");
                while (!so.EndOfStream)
                {
                    string[] oyuncu = so.ReadLine().Split('-');
                    for (int a = 0; a < 100; a++)
                    {
                        b += oyuncu[a] + "-";
                    }
                    textBox1.Text = b;

                    for (int j = 0; j < 101; j++)
                    {
                        if (oyuncu[j] == "T" && pc[j] == "T")
                        {
                            continue;
                        }
                        else if (oyuncu[j] == "T" && pc[j] == "K")
                        {
                            sayaçpc++;
                        }
                        else if (oyuncu[j] == "T" && pc[j] == "M")
                        {
                            sayaço++;
                        }
                        else if (oyuncu[j] == "K" && pc[j] == "T")
                        {
                            sayaço++;
                        }
                        else if (oyuncu[j] == "K" && pc[j] == "K")
                        {
                            continue;
                        }
                        else if (oyuncu[j] == "K" && pc[j] == "M")
                        {
                            sayaçpc++;
                        }
                        else if (oyuncu[j] == "M" && pc[j] == "T")
                        {
                            sayaçpc++;
                        }
                        else if (oyuncu[j] == "M" && pc[j] == "K")
                        {
                            sayaço++;
                        }
                        else if (oyuncu[j] == "M" && pc[j] == "M")
                        {
                            continue;
                        }
                    }
                }
            }
            sd.Close();
            label4.Text = sayaço.ToString();
            label3.Text = sayaçpc.ToString();

            if (sayaço > sayaçpc) MessageBox.Show("Oyuncu Kazandı");
            else if (sayaço < sayaçpc) MessageBox.Show("Bilgisayar Kazandı");
            else MessageBox.Show("Berabere Kalındı");
        }
    }

}
