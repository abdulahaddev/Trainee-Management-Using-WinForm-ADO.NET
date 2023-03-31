using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCMS
{
    public partial class FormEditTrainee : Form
    {
        public int? Id { get; set; }
        public FileInfo UploadedFileInfo { get; set; }

        string conString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;

        public FormEditTrainee()
        {
            InitializeComponent();
        }

        private void FormEditTrainee_Load(object sender, EventArgs e)
        {
            LoadCombo();
            if (Id != null)
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM trainees where traineeId=@id", con);
                    cmd.Parameters.AddWithValue("@id", Id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtName.Text = dr.GetString(dr.GetOrdinal("name"));
                        txtEmail.Text = dr.GetString(dr.GetOrdinal("email"));
                        txtPhone.Text = dr.GetString(dr.GetOrdinal("phone"));
                        dob.Value = dr.GetDateTime(dr.GetOrdinal("dob")).Date;
                        cmbBloodGroup.SelectedValue = dr.GetInt32(dr.GetOrdinal("bloodGroupId"));
                        //txtName.Text = dr.GetString(dr.GetOrdinal("gender"));
                        if (dr.GetString(dr.GetOrdinal("gender")) == rdMale.Text)
                        {
                            rdMale.Checked = true;
                        }
                        else if (dr.GetString(dr.GetOrdinal("gender")) == rdFemale.Text)
                        {
                            rdFemale.Checked = true;
                        }
                        txtNid.Text = dr.GetString(dr.GetOrdinal("nid"));
                        txtAddress.Text = dr.GetString(dr.GetOrdinal("address"));
                        txtFather.Text = dr.GetString(dr.GetOrdinal("father"));
                        txtMother.Text = dr.GetString(dr.GetOrdinal("mother"));

                        MemoryStream ms = new MemoryStream((byte[])dr[dr.GetOrdinal("Image")]);
                        Image img = Image.FromStream(ms);
                        pictureBox1.Image = img;
                    }
                    con.Close();
                }
            }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE trainees SET name=@n,email=@e,phone=@p,dob=@d,bloodGroupId=@b,gender=@g,nid=@nid,address=@addr,father=@f,mother=@m,Image=@img WHERE traineeId=@id", con);
                cmd.Parameters.AddWithValue("@id", Id);

                cmd.Parameters.AddWithValue("@n", txtName.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                cmd.Parameters.AddWithValue("@d", dob.Value.Date);
                cmd.Parameters.AddWithValue("@b", cmbBloodGroup.SelectedValue);
                cmd.Parameters.AddWithValue("@g", ((rdMale.Checked == true) ? rdMale.Text : rdFemale.Text));
                cmd.Parameters.AddWithValue("@nid", txtNid.Text);
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
                cmd.Parameters.AddWithValue("@f", txtFather.Text);
                cmd.Parameters.AddWithValue("@m", txtMother.Text);

                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                cmd.Parameters.AddWithValue("@img", ms.ToArray());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data updated successfully");
                con.Close();
                FrmTrainees frm = new FrmTrainees();
                frm.Show();
            }
        }

        private void btnImageUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog1.FileName);
                this.pictureBox1.Image = img;
            }
        }

        private void FormEditTrainee_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}