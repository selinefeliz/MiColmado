﻿using MiColmado.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MiColmado.View
{
    public partial class frmUserView : SampleView
    {
        private string guna2dataGridView1;

        public object Private { get; private set; }
        public object CurrentCell { get; private set; }

        public frmUserView()
        {
            InitializeComponent();
        }

        private void frmUserView_Load(object sender, EventArgs e)
        {
            LoadData();
            AgregarDgv(); //agrega los nuevos campos
            txtSearch.KeyPress += txtSearch_KeyPress; // Suscribir el evento KeyPress al método txtSearch_KeyPress
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmUserAdd()); //aqui se abre el nuevo formulario
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        //para que carge los datos del data grid view
        private void LoadData()
        {
            //ListBox lb = new ListBox();
            //lb.Items.Add(dgvid);
            //lb.Items.Add(dgvuserName);
            //lb.Items.Add(dgvpass);
            //lb.Items.Add(dgvname);
            //lb.Items.Add(dgvphone);

            string qry = @"Select userID as ID, userName as NombreUsuario, upass as Contraseña, uName as Nombre, uPhone as Telefono from users";
            //   where uName like '%" + txtSearch.Text + " %' order by userID desc";

            // Agregar una cláusula WHERE para filtrar los resultados según el texto ingresado en txtSearch
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                // Agregar una condición OR para buscar en múltiples campos
                qry += " WHERE uName LIKE '%" + txtSearch.Text + "%' OR " +
                       "userName LIKE '%" + txtSearch.Text + "%' OR " +
                       "upass LIKE '%" + txtSearch.Text + "%' OR " +
                       "uPhone LIKE '%" + txtSearch.Text + "%'";
            }

            MainClass.LoadData(qry, dataGridView1);//, lb);
        }

        //agregar programable la columnas de dgvEdit y dgvDel
        private void AgregarDgv()
        {

            DataGridViewImageColumn dgvEdit = new DataGridViewImageColumn();
            dgvEdit.Name = "dgvEdit";
            dgvEdit.HeaderText = "";
            dgvEdit.Width = 30;
            dgvEdit.Image = Properties.Resources.editar;
            dgvEdit.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewImageColumn dgvDel = new DataGridViewImageColumn();
            dgvDel.Name = "dgvDel";
            dgvDel.HeaderText = "";
            dgvDel.Width = 30;
            dgvDel.Image = Properties.Resources.cerrar;
            dgvDel.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.Columns.Add(dgvEdit);
            dataGridView1.Columns.Add(dgvDel);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si se presiona la tecla Enter
            if (e.KeyChar == (char)Keys.Enter)

            {
                // Realizar la búsqueda
                LoadData();
                e.Handled = true; // Manejar el evento para evitar que se emita el sonido de error de Windows
            }

        }

        private void frmuserVied_Load(object sende, EventArgs e)
        {
            LoadData();
        }
        //public override void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    MainClass.BlurBackground(new frmUserAdd());
        //    LoadData();
        //}

        public override void textBox1_Enter(object sender, EventArgs e)
        {
            LoadData();
        }
        private void loadData()
        {
            //ListBox lb = new ListBox();
            //lb.Items.Add(dgvid);
            //lb.Items.Add(dgvname);
            //lb.Items.Add(dgvuserName);
            //lb.Items.Add(dgvpass);
            //lb.Items.Add(dgvphon);

            string qry = @"Select * from Categoria 
                              where catName like '%" + txtSearch.Text + " %' order by catID desc";
            MainClass.LoadData(qry: guna2dataGridView1); //,1b);
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //Update
            if (dataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmcategoryAdd  frm = new frmcategoryAdd();
                frm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["dgvname"].Value);

                MainClass.BlurBackground(frm);
                LoadData();
            }
            // Delete
            if (dataGridView1.CurrentCell.OwningColumn.Name == "dgvDe1")
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvid"].Value);
                string qry = "DELETE FROM Categoria WHERE catID = " + id;
                Hashtable ht = new Hashtable();
                if (MainClass.SQL(qry, ht) > 0)
                {
                    MessageBox.Show("Deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }
    }
}

