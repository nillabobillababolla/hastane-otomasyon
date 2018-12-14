﻿using System;
using System.Windows.Forms;
using HastaneOtomasyon.Abstracts;
using HastaneOtomasyon.Concretes;

namespace HastaneOtomasyon.Forms
{
    public partial class FrmDoktor : Form
    {
        public FrmDoktor()
        {
            InitializeComponent();
        }

        private void btnDoktorEkle_Click(object sender, EventArgs e)
        {
            var doktorListesi = Kisi.DoktorList;

            Doktor yeniDoktor = new Doktor();
            try
            {
                yeniDoktor.Ad = txtAd.Text;
                yeniDoktor.Soyad = txtSoyad.Text;
                yeniDoktor.DogumTarihi = dateTimePicker1.Value;
                yeniDoktor.TcNo = txtTcNo.Text;
                yeniDoktor.Brans = (string) Enum.Parse(typeof(Kisi.BranslarDoktor), cbBrans.SelectedText);
           //   yeniDoktor.Maas = 
                doktorListesi.Add(yeniDoktor);

                FormuTemizle(gbDoktorEkle);

                 if (doktorListesi != null) lstDoktor.Items.AddRange(doktorListesi.ToArray());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void FormuTemizle(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TextBox)
                {
                    if (child.Name == "TxtArama") { continue; }

                    child.Text = string.Empty;
                }
                else if (child is ListBox lstBox)
                {
                    lstBox.Items.Clear();
                }
            }
        }

        private void btnDoktorSil_Click(object sender, EventArgs e)
        {

        }

        private void btnDoktorGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void FrmDoktor_Load(object sender, EventArgs e)
        {
            cbBrans.Items.AddRange(Enum.GetNames(typeof(Kisi.BranslarDoktor)));
           // lstDoktor.DataSource = Kisi.DoktorList;
        }

        private void lstDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDoktor.SelectedItem == null) return;
            
            var seciliDoktor = (Doktor)lstDoktor.SelectedItem;
            txtAd.Text = seciliDoktor.Ad;
            txtSoyad.Text = seciliDoktor.Soyad;
            txtTcNo.Text = seciliDoktor.TcNo;
            cbBrans.SelectedItem = seciliDoktor.Brans;
            dateTimePicker1.Value = seciliDoktor.DogumTarihi;
            
        }
    }
}
