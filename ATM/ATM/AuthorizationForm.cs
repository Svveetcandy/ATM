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
using System.Data.SqlClient;

namespace ATM
{
    public partial class AuthorizationForm : Form
    {
        const string pathToCardsInfo = "CardsInfo.txt";
        const string pathToCardsBalance = "CardsBalance.txt";
        const string pathToCardsBanned = "CardsBanned.txt";
        int maxAttemtps = 3;
        CurrentCardInfo currentCard;
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 300);
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            int cardIsBanned = -1;
            string cardName = isValidCard(textBoxCardNum.Text);

            if (cardName == "INVALID") return;


            if (CardNumCheck(pathToCardsInfo))
            {
                if (CardBanCheck(pathToCardsBanned, true) != cardIsBanned)
                {
                    currentCard = new CurrentCardInfo(textBoxCardNum.Text, CardBalanceCheck(pathToCardsBalance));
                    MainMenuForm mainMenu = new MainMenuForm(currentCard);
                    mainMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Данная карта заблокирована!");
                }
                label3.Visible = false;
            }
            else
            {
                int attemtNum = CardBanCheck(pathToCardsBanned, false);
                if (attemtNum != 0 && attemtNum != -1)
                {
                    label3.Visible = true;
                    label3.Text = label3.Text.Substring(0, label3.Text.Length - 1) + (maxAttemtps - attemtNum);
                }
            }
        }
        private void textBoxCardNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        bool CardNumCheck(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] cardInfo = new string[2];
                while ((line = sr.ReadLine()) != null)
                {
                    cardInfo = line.Split('/');
                    if (textBoxCardNum.Text == cardInfo[0] && textBoxPass.Text == cardInfo[1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        int CardBanCheck(string path, bool isTruePassword)
        {
            int attemptNum = 0;
            List<string> allCardInfo = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] cardInfo = new string[2];
                while ((line = sr.ReadLine()) != null)
                {
                    cardInfo = line.Split('/');
                    if (textBoxCardNum.Text == cardInfo[0])
                    {
                        if (cardInfo[1] == maxAttemtps.ToString())
                        {
                            return -1;
                        }
                        if (isTruePassword)
                        {
                            allCardInfo.Add(cardInfo[0] + "/0");
                        }
                        else
                        {
                            attemptNum = int.Parse(cardInfo[1]);
                            attemptNum++;
                            allCardInfo.Add(cardInfo[0] + "/" + attemptNum.ToString());
                        }
                    }
                    else
                    {
                        allCardInfo.Add(cardInfo[0] + "/" + cardInfo[1]);
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
            return attemptNum;
        }
        int CardBalanceCheck(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] cardInfo = new string[2];
                while ((line = sr.ReadLine()) != null)
                {
                    cardInfo = line.Split('/');
                    if (textBoxCardNum.Text == cardInfo[0])
                    {
                        return int.Parse(cardInfo[1]);
                    }
                }
            }
            return -1;
        }


        string isValidCard(string cardNum) 
        {
            string pathToCardRules = "CARDSrules.txt";
            string name;

            name = Check_Card(cardNum, pathToCardRules);
            return name;
        }
        string Check_Card(string number, string filename)
        {
            string name;
            int count = 0;
            string[] all_num;
            string[] first_num;
            using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default))
            {
                string line, line1="", line2="";
                while ((line = sr.ReadLine()) != null)
                {
                    switch (count) {
                        case 0:
                            line1 = line;
                            count++;
                            break;
                        case 1:
                            line2 = line;
                            count++;
                            break;
                        case 2:
                            name = line1;
                            all_num = line2.Split(' ');
                            first_num = line.Split(' ');

                            foreach(string num in all_num)
                            {
                                if (num == number.Length.ToString())
                                {
                                    foreach(string first in first_num)
                                    {
                                        if(first==number.Substring(0, 2) || first == number[0].ToString())
                                        {
                                            if (Check_Sum(number, number.Length))
                                            {
                                                return name;
                                            }
                                            else
                                            {
                                                return "INVALID";
                                            }
                                        }
                                    }
                                }
                            }
                            count = 0;
                            break;
                    }
                }
            }
            return "INVALID";
        }
        bool Check_Sum(string numberString, int length)
        {
            int[] number=new int[length];
            for (int i = 0; i < numberString.Length; i++)
            {
                number[i] = (int)Char.GetNumericValue(numberString[i]);
            }

            int mult_sum = 0, not_mult_sum = 0, ostatok, count = 0;
            while (length != 0)
            {
                length--;
                count++;
                if (count % 2 == 0)
                {
                    number[length] = number[length] * 2;
                    if (number[length] > 9)
                    {
                        ostatok = number[length] % 10;
                        number[length] = number[length] / 10;
                        number[length] = number[length] + ostatok;
                    }
                    mult_sum = mult_sum + number[length];
                }
                else
                {
                    not_mult_sum = not_mult_sum + number[length];
                }
            }
            if ((mult_sum + not_mult_sum) % 10 == 0) return true;
            return false;
        }




    }
}
