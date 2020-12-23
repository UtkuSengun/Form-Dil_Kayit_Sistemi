using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Görsel_Program_Fİnal_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // öğrenci bilgilerini kaydet
        {

            listBox2.Items.Clear();

            listBox2.Items.Add("Öğrenci ID :" + "   " + numericUpDown1.Value);
            listBox2.Items.Add("Ad Soyad :" + "   " + textBox1.Text);
            listBox2.Items.Add("TC Kimlik No :" + "   " + maskedTextBox1.Text);
            listBox2.Items.Add("Telefon Numarası :" + "   " + maskedTextBox2.Text);
            listBox2.Items.Add("E-Mail : " + "   " + textBox4.Text);
            listBox2.Items.Add("Bulunduğu seviye :" + comboBox1.Text);
            progressBar1.Value = 25;
            listBox2.Items.Add("-----------------------------");


            MessageBox.Show("Öğrenci Bilgileri Kaydedildi. Kart Bilgilerini doldurunuz.");

        }
        private void button5_Click(object sender, EventArgs e) // kayıt bilgilerini sil 
        {

            listBox2.Items.Clear();
            textBox1.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            textBox4.Clear();

            progressBar1.Value = 0;
        }


        private void button2_Click(object sender, EventArgs e) // kart bilgilerini kaydet
        {
            listBox2.Items.Add("Kartın Üzerinde Bulunan İsim :" + "   " + textBox9.Text);
            listBox2.Items.Add("Kart Numarası :" + "   " + maskedTextBox4.Text);
            listBox2.Items.Add("Son Kullanma Tarihi :" + "   " + maskedTextBox3.Text);
            listBox2.Items.Add("CVC :" + "   " + textBox11.Text);
            progressBar2.Value = 50;

            listBox2.Items.Add("-----------------------------");

            MessageBox.Show("Kart Bilgileri Kaydedildi. Uygun Taksitlendirmeyi seçiniz.");
        }

        private void button6_Click(object sender, EventArgs e) // kart bilgilerini sil
        {
            listBox2.Items.Clear();
            textBox9.Clear();
            maskedTextBox4.Clear();
            maskedTextBox3.Clear();
            textBox11.Clear();
            progressBar2.Value = 25;
        }

    double tutar;
       

        private void button4_Click(object sender, EventArgs e) // ödeme bilgilerini kaydet
        {
            progressBar3.Value = 75;

            if (comboBox1.Text == "A1") tutar = 12000;
            else if (comboBox1.Text == "A2") tutar = 9000;
            else if (comboBox1.Text == "B1") tutar = 6000;
            else if (comboBox1.Text == "B2") tutar = 3000;
            else if (comboBox1.Text == "C1") tutar = 1500;

            /* Nakit ödeme */
                    
              if (radioButton4.Checked == true) tutar /= 1;

            /* maksimum kart taksitlendirme */
            if (radioButton5.Checked == true) tutar /= 1;
            if (radioButton6.Checked == true) tutar /= 2;
            if (radioButton7.Checked == true) tutar /= 3;
            if (radioButton8.Checked == true) tutar /= 4;
            if (radioButton9.Checked == true) tutar /= 5;
            if (radioButton10.Checked == true) tutar /= 6;

            /* world kart taksitlendirme */
            if (radioButton11.Checked == true) tutar /= 1;
            if (radioButton12.Checked == true) tutar /= 2;
            if (radioButton13.Checked == true) tutar /= 3;
            if (radioButton14.Checked == true) tutar /= 4;

            listBox2.Items.Add("Aylık Ödenecek tutar: " + tutar + "  " + " Türk Lirası");

        }
        private void button7_Click(object sender, EventArgs e) // ödeme seçeneklerini sil
        {
            progressBar3.Value = 50;
            

            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            textBox3.Clear();
            textBox5.Clear();
            
        }
        private void button8_Click(object sender, EventArgs e) // sanal para ile ödeme butonu
        {
            if (comboBox1.Text == "A1") tutar = 12000;  // tekrardan tutarı hesaplattık.
            else if (comboBox1.Text == "A2") tutar = 9000;
            else if (comboBox1.Text == "B1") tutar = 6000;
            else if (comboBox1.Text == "B2") tutar = 3000;
            else if (comboBox1.Text == "C1") tutar = 1500;

            int sayi = Convert.ToInt32(textBox3.Text); // bitcoin kuru girme
            listBox2.Items.Add("ödeyeceğiniz tutar :" + (tutar / sayi).ToString() + "Bitcoin ödeyiniz."); // hesaplatma
            MessageBox.Show("Bitcoin Tutarı hesaplandı. Lütfen sonraki sekmeye geçiniz.");


            sayi = Convert.ToInt32(textBox5.Text); // ethereum kuru girme
            listBox2.Items.Add("ödeyeceğiniz tutar :" + (tutar / sayi).ToString() + "Ethereum ödeyiniz."); // hesaplatma
            MessageBox.Show("Ethereum Tutarı hesaplandı. Lütfen sonraki sekmeye geçiniz.");

        }

        private void button3_Click(object sender, EventArgs e) // ödemeyi gerçekleştir.
        {
            progressBar4.Value = 100;
            this.chart1.Series[comboBox1.Text].Points.Clear();
            this.chart1.Series[comboBox1.Text].Points.AddXY("Öğrenci ID numaraya göre dağılım", Convert.ToDouble(numericUpDown1.Value));
            MessageBox.Show("Öğrenci Başarıyla kaydedildi.");

        }

       
    }
}
