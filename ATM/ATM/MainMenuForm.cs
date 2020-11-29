using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class MainMenuForm : Form
    {
        CurrentCardInfo currentCardInfo;
        public MainMenuForm(CurrentCardInfo currentCardInfo)
        {
            InitializeComponent();
            this.currentCardInfo = currentCardInfo;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            AuthorizationForm authorizationForm = new AuthorizationForm();
            authorizationForm.Show();
        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("На счету осталось: " + currentCardInfo.balance);
        }

        private void WidthrawButton_Click(object sender, EventArgs e)
        {
            WithdrawMoneyForm withdrawForm = new WithdrawMoneyForm(currentCardInfo);
            withdrawForm.Show();
            this.Hide();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(510, 310);
        }
    }
}
