using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiColmado.Model
{
    public partial class frmcategoryAdd : SampleView
    {
        public frmcategoryAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            //antes de guardar la imagen se necesita validacion
            if (MainClass.Validation(this) == false)
            {
                MessageBox.Show("Complete los campos requeridos", "Errores encontrados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string qry = "";
                if (id == 0)//para insertar datos
                {
                    qry = @"Insert into Categoria values(@name)";

                }
                else //actualizar
                {
                    qry = @"UPDATE Categoria set catName =@userName,
                      where userID = @id";
                }

                System.Collections.Hashtable ht = new System.Collections.Hashtable();
                ht.Add("@id", id);
                ht.Add("@name", txtName.Text);

                if (MainClass.SQL(qry, ht) > 0)
                {
                    MessageBox.Show("Datos Guardados correctamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id = 0;
                    txtName.Text = "";
                    txtName.Focus();
                }

            }
        }
        private void frmcategoryAdd_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void frmcategoryAdd_Load_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
