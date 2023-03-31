using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCMS
{
    public partial class FrmTrainees : Form
    {
        string conString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
        public FrmTrainees()
        {
            InitializeComponent();
        }

        private void FrmTrainees_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        public void LoadGrid()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT t.Image, t.traineeId, t.name, t.email, t.phone, t.dob, b.bloodGroupTitle, t.nid FROM trainees t INNER JOIN bloodGroup b ON t.bloodGroupId=b.bloodGroupId", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                dataGridView1.AllowUserToAddRows = false;

                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dataGridView1.Columns[0];
                imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                imgCol.Width = 60;

                var deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "dataGridViewEditButton";
                deleteButton.HeaderText = "Edit";
                deleteButton.Text = "";
                deleteButton.FlatStyle = FlatStyle.Flat;
                deleteButton.Width = 35;
                deleteButton.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(deleteButton);



                var editButton = new DataGridViewButtonColumn();
                editButton.Name = "dataGridViewDeleteButton";
                editButton.HeaderText = "Delete";
                editButton.Text = "";
                editButton.FlatStyle = FlatStyle.Flat;
                editButton.Width = 35;
                editButton.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(editButton);
            }
        }
        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewEditButton"].Index)
            {
                var image = Properties.Resources.edit; //An image
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var x = e.CellBounds.Left + (e.CellBounds.Width - image.Width) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - image.Height) / 2;
                e.Graphics.DrawImage(image, new Point(x, y));
                e.Handled = true;
            }
            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
            {
                var image2 = Properties.Resources.delete; //An image
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var x = e.CellBounds.Left + (e.CellBounds.Width - image2.Width) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - image2.Height) / 2;
                e.Graphics.DrawImage(image2, new Point(x, y));

                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddTrainee newForm = new FormAddTrainee();
            newForm.Owner = this;
            newForm.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewEditButton"].Index)
            {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells["traineeId"].Value;

                FormEditTrainee formEdit = new FormEditTrainee();
                formEdit.Id = id;
                formEdit.Show();
                this.Close();
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["dataGridViewDeleteButton"].Index)
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        int id = (int)dataGridView1.Rows[e.RowIndex].Cells["traineeId"].Value;
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM trainees WHERE traineeId=@id", con);
                        cmd.Parameters.AddWithValue("@id", id);
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Deleted successfully!!!");
                            LoadGrid();
                        }
                        con.Close();
                    }
                }
                else if (dr == DialogResult.No)
                {
                    //Nothing to do
                }

            }
        }

        private void btnTrainees_Click(object sender, EventArgs e)
        {
            FormAddTrainee newForm = new FormAddTrainee();
            newForm.Show();
            this.Close();
        }
    }
}
