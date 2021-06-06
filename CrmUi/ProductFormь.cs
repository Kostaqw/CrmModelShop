using CrmBL.Model;
using System;

using System.Windows.Forms;

namespace CrmUi
{
    public partial class ProductForm : Form
    {
        public Product Products{ get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(Product product) :this()
        {
            Products = product;
            textBox1.Text = product.Name;
            numericUpDown1.Value = product.Price;
            numericUpDown2.Value = product.Count;
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var p = Products ?? new Product();

            p.Name = textBox1.Text;
            p.Price = numericUpDown1.Value;
            p.Count = Convert.ToInt32(numericUpDown2.Value);
          
            Close();
        }
    }
}
