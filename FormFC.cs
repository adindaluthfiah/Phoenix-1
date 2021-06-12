using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace QBisnis
{

    public partial class FormFC : Form
    {
        FixedCost FC;

        public FormFC()
        {
            InitializeComponent();
        }
        void Clear()
        {
            tbNominal.Text = tbKategori.Text = tbNote.Text = "";
        }
        public double TotalSemua()
        {
            double total = 0;
            tbTotalFC.Text = "0";
            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                total += Convert.ToDouble(DataGridView1.Rows[i].Cells[2].Value);
            }
            tbTotalFC.Text = total.ToString();
            return total;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbNominal.Text != "" && tbKategori.Text != "" && tbNote.Text != "")
            {
                using (dbModel1 db = new dbModel1())
                {
                    FC = new FixedCost
                    {
                        Nominal = int.Parse(tbNominal.Text),
                        Kategori = tbKategori.Text,
                        Note = tbNote.Text,
                    };
                    if (FC.id == 0)
                        db.FixedCosts.Add(FC);
                    else //Update
                        db.Entry(FC).State = System.Data.Entity.EntityState.Modified;
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
        public void GridView()
        {
            DataGridView1.AutoGenerateColumns = false;
            using (dbModel1 db = new dbModel1())
            {
                DataGridView1.DataSource = db.FixedCosts.ToList<FixedCost>();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            FC = new FixedCost();
            if (DataGridView1.Rows.Count !=  0)
            {
                if (MessageBox.Show("Are You Sure to Delete this Record ?", "EF CRUD Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FC.id = (int)DataGridView1.CurrentRow.Cells["ID"].Value;
                    using (dbModel1 db = new dbModel1())
                    {
                        FC = db.FixedCosts.Where(x => x.id == FC.id).FirstOrDefault();
                        tbKategori.Text = FC.Kategori;
                        tbNominal.Text = Convert.ToString(FC.Nominal);
                        tbNote.Text = FC.Note;
                        db.FixedCosts.Remove(FC);
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

        private void FormFC_Load(object sender, EventArgs e)
        {
            Clear();
            GridView();
            TotalSemua();
        }
        public double totalfc()
        {
            double total;
            GridView();
            total = TotalSemua();
            return total;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            FormUtama form = new FormUtama(tbTotalFC.Text);
            form.Show();

            this.Hide();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
