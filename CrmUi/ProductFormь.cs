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
            Products = product ?? new Product();
            textBox1.Text = product.Name;
            numericUpDown1.Value = product.Price;
            numericUpDown2.Value = product.Count;
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Products = Products ?? new Product();

            Products.Name = textBox1.Text;
            Products.Price = numericUpDown1.Value;
            Products.Count = Convert.ToInt32(numericUpDown2.Value);
          
            Close();
        }
    }
}
