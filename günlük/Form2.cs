using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace günlük
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\data\\data.mdb");
        OleDbCommand komut = new OleDbCommand();
        private void listele()
        {
            try
            {
                listView1.Items.Clear();
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("Select *From data", baglan);
                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {

                    ListViewItem ekle = new ListViewItem();

                    
                    //richTextBox2.Text= oku["metin"].ToString();

                    ekle.Text = oku["gün"].ToString();

                    ekle.SubItems.Add(oku["konu"].ToString());

                   // ekle.SubItems.Add(oku["metin"].ToString());
                   
                    listView1.Items.Add(ekle);


                }

                baglan.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("veritabanı bulunamıyor!!!");
            }

        }
        private void listele2()
        {
            try
            {
             
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("Select *From data", baglan);
                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {

                    


                    richTextBox2.Text = oku["metin"].ToString();
                    label4.Text = oku["metin"].ToString();
                    label7.Text = oku["face"].ToString();
                    label10.Text = oku["önemli"].ToString();
                    label11.Text = oku["yıldızlı"].ToString();

                }

                baglan.Close();
            }
            catch (Exception ex)
            {
                
            }

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            checkBox3.Checked = true;
            listele();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || richTextBox2.Text == "")
            {
             
                button3.Enabled = false;
                
                button2.Enabled = false;
            }
            else
            {
               
                button2.Enabled = true;
                button3.Enabled = true;

            }
            if (label2.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
            if (textBox1.Text == "" && richTextBox2.Text == "" && label2.Text == "")
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }

            if (checkBox1.Checked == true)
            {
                label8.Text = "önemli";
                pictureBox7.Visible = true;
            }
            else
            {
                label8.Text = "";
                pictureBox7.Visible = false;
            }
            if (checkBox2.Checked == true)
            {
                pictureBox8.Visible = true;
                label9.Text = "yıldızlı";
            }
            else
            {
                pictureBox8.Visible = false;
                label9.Text = "";
            }

           
            if (checkBox3.Checked == true)
            {
                pictureBox6.Visible = true;
                groupBox1.Enabled = true;
                textBox1.Enabled = true;
                richTextBox2.Enabled = true;
                checkBox2.Enabled = true;
                checkBox1.Enabled = true;
            }
            else
            {
                pictureBox6.ImageLocation = ("");
                pictureBox6.Visible = false;
                groupBox1.Enabled = false;
                textBox1.Enabled = false;
                richTextBox2.Enabled = false;
                checkBox2.Enabled = false;
                checkBox1.Enabled = false;
            }
            label6.Text = DateTime.Now.ToLongDateString() + "  /  " + DateTime.Now.ToLongTimeString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult sil = new DialogResult();
            sil = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Sİl", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sil == DialogResult.Yes)
            {
                try
                {
                    baglan.Open();

                    komut.Connection = baglan;
                    komut.CommandText = "delete from data where gün ='" + label2.Text + "'";
                    komut.ExecuteNonQuery();
                    baglan.Close();
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt bulunamadı!", "HATA");
                }
            }
            if (sil == DialogResult.No)
            { }
            listele();

            button4.PerformClick();
            pictureBox6.ImageLocation=("");
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           label5.Text = listView1.SelectedItems[0].SubItems[1].Text.ToString();
           textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text.ToString();
           label2.Text = listView1.SelectedItems[0].SubItems[0].Text.ToString();
           textBox1.Enabled = false;
           richTextBox2.Enabled = false;
           checkBox1.Enabled = false;
           checkBox2.Enabled = false;
           button2.Enabled = false;
           listele2();
           listele();

           if (label7.Text == "face\\sinirli.png")
           {
               pictureBox6.ImageLocation = (@"face\sinirli.png");
           }
           if (label7.Text == "face\\mutlu.png")
           {
               pictureBox6.ImageLocation = (@"face\mutlu.png");
           }
           if (label7.Text == "face\\huzurlu.png")
           {
               pictureBox6.ImageLocation = (@"face\huzurlu.png");
           }
           if (label7.Text == "face\\yorgun.png")
           {
               pictureBox6.ImageLocation = (@"face\yorgun.png");
           }
           if (label7.Text == "face\\hüzünlü.png")
           {
               pictureBox6.ImageLocation = (@"face\hüzünlü.png");
           }
           if (label10.Text == "önemli")
           {
               checkBox1.Checked = true;
           }
           else
           {
               checkBox1.Checked = false;
           }

           if (label11.Text == "yıldızlı")
           {
               checkBox2.Checked = true;
           }
           else
           {
               checkBox2.Checked = false;
           }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            label5.Text = "";
            label2.Text = "";
            label10.Text = "";
            label11.Text = "";
            label9.Text = "";
            label8.Text = "";
            textBox1.Text = "";
            richTextBox2.Enabled = true;
            checkBox2.Enabled = true;
            checkBox1.Enabled = true;
            textBox1.Enabled = true;
            button2.Enabled = true;
            checkBox2.Enabled = true;
            checkBox1.Enabled = true;
            pictureBox6.ImageLocation = ("");
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand kaydet = new OleDbCommand("insert into data (gün,konu,metin,face,önemli,yıldızlı) values('" + DateTime.Now.ToLocalTime() + "','" + textBox1.Text + "','" + richTextBox2.Text + "','" + pictureBox6.ImageLocation + "','" + label8.Text + "','" + label9.Text + "')", baglan);
            kaydet.ExecuteNonQuery();
            baglan.Close();
            listele();
            textBox1.Text = "";
            richTextBox2.Text = "";
            label2.Text = "";
            button4.PerformClick();
            pictureBox6.ImageLocation = ("");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult degis = new DialogResult();
            degis = MessageBox.Show("Kaydı değiştirmek istediğinizden emin misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (degis == DialogResult.Yes)
            {

                try
                {
                    baglan.Open();
                    komut.Connection = baglan;
                    komut.CommandText = "update data set konu='" + textBox1.Text + "',gün='" + DateTime.Now.ToLocalTime() + "',metin='" + richTextBox2.Text + "',face='" + pictureBox6.ImageLocation + "',önemli='" + label8.Text + "',yıldızlı='" + label9.Text + "'where gün='" + label2.Text + "'";
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Değişiklik yapılamıyor!!!", "UYARI");
                }
                button4.PerformClick();
            }
            if (degis == DialogResult.No)
            { }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox6.ImageLocation=("face\\mutlu.png");
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox6.ImageLocation = ("face\\hüzünlü.png");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox6.ImageLocation = ("face\\yorgun.png");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox6.ImageLocation = ("face\\sinirli.png");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox6.ImageLocation = ("face\\huzurlu.png");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
           
        }

        private void arkaplanRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 hak = new Form3();
            hak.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
