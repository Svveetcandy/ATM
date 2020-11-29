using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ATM
{
    public partial class WithdrawMoneyForm : Form
    {
        string pathToBanknoteData = "BanknoteData.txt";
        string pathToCardsBalance = "CardsBalance.txt";
        List<Banknotes> banknotesData = new List<Banknotes>();
        CurrentCardInfo currentCardInfo;
        public WithdrawMoneyForm(CurrentCardInfo currentCardInfo)
        {
            InitializeComponent();
            this.currentCardInfo = currentCardInfo;
            AddAllBanknotes(pathToBanknoteData);
        }

        void AddAllBanknotes(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr = new string[2];
                    arr = line.Split(' ');
                    banknotesData.Add(new Banknotes(int.Parse(arr[0]), int.Parse(arr[1])));
                }
            }

            Button[] banknoteButtons = { button1, button2, button3, button4, button5, button6 };
            int count = 0;
            foreach(Banknotes item in banknotesData)
            {

                if (count < banknoteButtons.Length)
                {
                    banknoteButtons[count].Text = item.Nominal.ToString();
                }

                count++;
            }
        }
        private void SumOfMoneyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BanknoteButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int banknoteDenomination = int.Parse(button.Text);
            if (currentCardInfo.balance > banknoteDenomination)
            {
                currentCardInfo.balance = currentCardInfo.balance - banknoteDenomination;
                WriteNewValueOfMoney(pathToCardsBalance);
                WriteNewNominalCount(pathToBanknoteData);
                MessageBox.Show("Средства успешно сняты!");
            }
            else
            {
                MessageBox.Show("Недостаточно средств для снятия!");
            }

        }

        private void WidthrawButton_Click(object sender, EventArgs e)
        {
            int.TryParse(SumOfMoneyTextBox.Text, out int sumOfMoney);
            
            banknotesData.Sort((item1, item2) => item2.Nominal - item1.Nominal);

            int minNominal = banknotesData.LastOrDefault().Nominal;
            if (currentCardInfo.balance >= sumOfMoney)
            {
                if (sumOfMoney % minNominal == 0)
                {
                    currentCardInfo.balance = currentCardInfo.balance - sumOfMoney;
                    foreach (Banknotes banknote in banknotesData)
                    {
                        int count = 1;
                        for (int i = 1; i != 0; i++) {
                            if ((count * banknote.Nominal > sumOfMoney) || (count-1 == banknote.Count))
                            {
                                i = -1;

                            }
                            else
                            {
                                count++;
                                
                            }

                        }
                        sumOfMoney = sumOfMoney - ((count - 1) * banknote.Nominal);
                        banknote.Count = banknote.Count - (count - 1);

                    }
                    if (sumOfMoney == 0)
                    {
                        WriteNewValueOfMoney(pathToCardsBalance);
                        WriteNewNominalCount(pathToBanknoteData);
                        MessageBox.Show("Средства успешно сняты!");
                    }
                    else
                    {
                        MessageBox.Show("В банкомате недостаточно средств!");
                    }

                }
                else
                {
                    MessageBox.Show("Невозможно выдать данную денежную сумму!");
                }

            }
            else
            {
                MessageBox.Show("Недостаточно средств для снятия!");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenuForm mainMenu = new MainMenuForm(currentCardInfo);
            mainMenu.Show();
        }

        private void WithdrawMoneyForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(520, 320);
        }
        void WriteNewValueOfMoney(string path)
        {
            List<string> allCardInfo = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] arr = new string[2];
                while ((line = sr.ReadLine()) != null)
                {
                    arr = line.Split('/');
                    if (arr[0] == currentCardInfo.number)
                    {
                        allCardInfo.Add(arr[0] + "/" + currentCardInfo.balance);
                    }
                    else
                    {
                        allCardInfo.Add(arr[0] + "/" + arr[1]);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(File.Open("buf" + path, FileMode.OpenOrCreate)))
            {
                foreach (string line in allCardInfo)
                {
                    sw.WriteLine(line);
                }
            }
            File.Delete(path);
            File.Move("buf" + path, path);
        }
        void WriteNewNominalCount(string path)
        {
            List<string> allCardInfo = new List<string>();
            using (StreamWriter sw = new StreamWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach(Banknotes banknotes in banknotesData)
                {
                    sw.WriteLine(banknotes.Nominal + " " + banknotes.Count);
                }
            }
        }
    }
}
