using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QBisnis
{
    public partial class FormVC : Form
    {
        VariableCost VC;
        public FormVC()
        {
            InitializeComponent();
            Clear();
            GridView();
            TotalSemua();
        }
        void Clear()
        {
            tbNominal.Text = tbKategori.Text = tbNote.Text = "";
        }

        private double TotalSemua()
        {
            double total = 0;
            tbTotalVC.Text = "0";
            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                total += Convert.ToDouble(DataGridView1.Rows[i].Cells[2].Value);
            }
            tbTotalVC.Text = total.ToString();
            return total;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbNominal.Text != "" && tbKategori.Text != "" && tbNote.Text != "")
            {
                using (dbModel1 db = new dbModel1())
                {
                    VC = new VariableCost()
                    {
                        Nominal = int.Parse(tbNominal.Text),
                        Kategori = tbKategori.Text,
                        Note = tbNote.Text,
                    };
                    if (VC.Id == 0)
                        db.VariableCosts.Add(VC);
                    else //Update
                        db.Entry(VC).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    Clear();
                    GridView();
                    TotalSemua();
                }
            }
            else
            {
                MessageBox.Show("Data Belum Lengkap");
            }
        }

        private void GridView()
        {
            DataGridView1.AutoGenerateColumns = false;
            using (dbModel1 db = new dbModel1())
            {
                DataGridView1.DataSource = db.VariableCosts.ToList<VariableCost>();
            }
        }


        private void btnHapus_Click(object sender, EventArgs e)
        {
            
            VC = new VariableCost();
            if (DataGridView1.Rows.Count != 0)
            {
                if (MessageBox.Show("Are You Sure to Delete this Record ?", "EF CRUD Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    VC.Id = (int)DataGridView1.CurrentRow.Cells["ID"].Value;
                    using (dbModel1 db = new dbModel1())
                    {
                        VC = db.VariableCosts.Where(x => x.Id == VC.Id).FirstOrDefault();
                        tbKategori.Text = VC.Kategori;
                        tbNominal.Text = Convert.ToString(VC.Nominal);
                        tbNote.Text = VC.Note;
                        db.VariableCosts.Remove(VC);
                        db.SaveChanges();
                        Clear();
                        GridView();
                        TotalSemua();
                    }
                }
            }
            else
            {
                MessageBox.Show("Data is empty");
            }

        }

        private void FormVC_Load(object sender, EventArgs e)
        {
            Clear();
            GridView();
            TotalSemua();
        }

        public double totalvc()
        {
            double total;
            GridView();
            total = TotalSemua();
            return total;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormUtama form = new FormUtama(tbTotalVC.Text);
            form.Show();

            this.Hide();
        }
    }
}
