using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    class CashBoxView
    {
        CashDesk cashDesk;
        public Label CashDeskName { get; set; }
        public NumericUpDown Price { get; set; }
        
        public ProgressBar QueuLength { get; set; }

        public Label LeaveCustomer { get; set; }
        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;


            Price = new NumericUpDown();
            CashDeskName = new Label();
            LeaveCustomer = new Label();
            QueuLength = new ProgressBar();
            

            CashDeskName.AutoSize = true;
            CashDeskName.Location = new System.Drawing.Point(x, y);
            CashDeskName.Name = "Label" + number;
            CashDeskName.Size = new System.Drawing.Size(35, 13);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = cashDesk.ToString();

            Price.Location = new System.Drawing.Point(x+63, y);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 1000000000000;

            QueuLength.Location = new System.Drawing.Point(x+200, y);
            QueuLength.Maximum = cashDesk.MaxQueueLength;
            QueuLength.Name = "progressBar1"+number;
            QueuLength.Size = new System.Drawing.Size(100, 23);
            QueuLength.TabIndex = number;
            QueuLength.Value = 0;

            LeaveCustomer.AutoSize = true;
            LeaveCustomer.Location = new System.Drawing.Point(x+400, y);
            LeaveCustomer.Name = "Label2" + number;
            LeaveCustomer.Size = new System.Drawing.Size(35, 13);
            LeaveCustomer.TabIndex = number;
            LeaveCustomer.Text = "";

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, Check e)
        {
            Price.Invoke((Action)delegate 
            { 
                Price.Value += e.Price;
                QueuLength.Value = cashDesk.Count;
                LeaveCustomer.Text = cashDesk.ExitCustomer.ToString();
            });
        }
    }
}
