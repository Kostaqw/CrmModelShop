using CrmBL.Model;
using System;

using System.Windows.Forms;

namespace CrmUi
{
    public partial class SellerForm : Form
    {
        public Seller Sellers { get; set; }
        public SellerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sellers = new Seller()
            {
                Name = textBox1.Text
            };
            Close();
        }
    }
}
