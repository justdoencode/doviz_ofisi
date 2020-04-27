using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace doviz_ofisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lbl_dolaralis.Text = dolaralis;
            lbl_dolarsatis.Text = dolarsatis;
            lbl_euroalis.Text = euroalis;
            lbl_eurosatis.Text = eurosatis;
            btn_aldovizhesap.Enabled = false;
            btn_altlhesap.Enabled = false;
            btn_satdovizhesap.Enabled = false;
            btn_sattlhesap.Enabled = false;
        }
        string hesaplanan;
        private void btn_dolaralis_Click(object sender, EventArgs e)
        {
            txt_kur.Text = lbl_dolaralis.Text;
            btn_aldovizhesap.Enabled = true;
            btn_altlhesap.Enabled = true;
            btn_satdovizhesap.Enabled = false;
            btn_sattlhesap.Enabled = false;
            hesaplanan = "DOLAR";
        }

        private void btn_dolarsatis_Click(object sender, EventArgs e)
        {
            txt_satkur.Text = lbl_dolarsatis.Text;
            btn_altlhesap.Enabled = false;
            btn_aldovizhesap.Enabled = false;
            btn_satdovizhesap.Enabled = true;
            btn_sattlhesap.Enabled = true;
            hesaplanan = "DOALR";
        }

        private void btn_euroalis_Click(object sender, EventArgs e)
        {
            txt_kur.Text = lbl_euroalis.Text;
            btn_aldovizhesap.Enabled = true;
            btn_altlhesap.Enabled = true;
            btn_satdovizhesap.Enabled = false;
            btn_sattlhesap.Enabled = false;
            hesaplanan = "EURO";
        }

        private void btn_eurosatis_Click(object sender, EventArgs e)
        {
            txt_satkur.Text = lbl_eurosatis.Text;
            btn_altlhesap.Enabled = false;
            btn_aldovizhesap.Enabled = false;
            btn_satdovizhesap.Enabled = true;
            btn_sattlhesap.Enabled = true;
            hesaplanan = "EURO";
        }

        private void btn_aldovizhesap_Click(object sender, EventArgs e)
        {
           double miktar = double.Parse(txt_miktar.Text);
            double kur = double.Parse(txt_kur.Text);
            double tutar = miktar * kur;
            lbl_altutar.Text = (tutar = Math.Round(tutar, 2)).ToString()+" TL";
        }

        private void txt_kur_TextChanged(object sender, EventArgs e)
        {
            txt_kur.Text = txt_kur.Text.Replace(".", ",");
        }

        private void btn_altlhesap_Click_1(object sender, EventArgs e)
        {
            double kur = double.Parse(txt_kur.Text);
            double miktar = double.Parse(txt_miktar.Text);
            double tutar = miktar/ kur;
            lbl_altutar.Text = (tutar = Math.Round(tutar, 2)).ToString()+" "+hesaplanan;
        }

        private void btn_satdovizhesap_Click(object sender, EventArgs e)
        {
            double kur = double.Parse(txt_satkur.Text);
            double miktar = double.Parse(txt_satmiktar.Text);
            double tutar = miktar * kur;
            lbl_sattutar.Text = (tutar = Math.Round(tutar, 2)).ToString() + " TL";
        }

        private void btn_sattlhesap_Click(object sender, EventArgs e)
        {
            double kur = double.Parse(txt_satkur.Text);
            double miktar = double.Parse(txt_satmiktar.Text);
            double tutar = miktar / kur;
            lbl_sattutar.Text = (tutar = Math.Round(tutar, 2)).ToString() + " " + hesaplanan;
        }

        private void txt_satkur_TextChanged(object sender, EventArgs e)
        {
            txt_satkur.Text = txt_satkur.Text.Replace(".", ",");
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
