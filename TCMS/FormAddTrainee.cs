using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCMS
{
    public partial class FormAddTrainee : Form
    {
        public FileInfo UploadedFileInfo { get; set; }

        string conString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
        public FormAddTrainee()
        {
            InitializeComponent();
        }

        private void LoadCombo()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT bloodGroupId,bloodGroupTitle FROM bloodGroup", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmbBloodGroup.DisplayMember = "bloodGroupTitle";
                cmbBloodGroup.ValueMember = "bloodGroupId";
                cmbBloodGroup.DataSource = dt;
                con.Close();
            }

        }

        private void btnImageUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = img;
                UploadedFileInfo = new FileInfo(openFileDialog1.FileName);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO trainees VALUES(@name,@email,@phone,@dob,@blood,@gender,@nid,@address,@father,@mother,@image)", con))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@dob", dob.Value.Date);
                        cmd.Parameters.AddWithValue("@blood", cmbBloodGroup.SelectedValue);
                        cmd.Parameters.AddWithValue("@gender", (rdMale.Checked == true) ? rdMale.Text : rdFemale.Text);
                        cmd.Parameters.AddWithValue("@nid", txtNid.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@father", txtFather.Text);
                        cmd.Parameters.AddWithValue("@mother", txtMother.Text);

                        using (MemoryStream ms = new MemoryStream())
                        {
                            Image img = Image.FromFile(UploadedFileInfo.FullName);
                            img.Save(ms, ImageFormat.Bmp);

                            cmd.Parameters.Add(new SqlParameter("@image", SqlDbType.VarBinary) { Value = ms.ToArray() });
                        }
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully!!!");

                        FrmTrainees frm = new FrmTrainees();
                        frm.Show();
                        frm.LoadGrid();
                        this.Close();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
                con.Close();
            }
        }

        private void FrmAddTrainee_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void FormAddTrainee_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
    }
}
