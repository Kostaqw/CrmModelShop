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
        public SellerForm(Seller seller) : this()
        {
            Sellers = seller;
            textBox1.Text = seller.Name;
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = Sellers ?? new Seller();

            s.Name = textBox1.Text;
            
            Close();
        }
    }
}
