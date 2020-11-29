using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CurrentCardInfo
    {
        public string number { get; set; }
        string name;
        public int balance { get; set; }
        public CurrentCardInfo(string number, int balance)
        {
            this.number = number;
            this.balance = balance;
        }
        void WriteNeValueOfMoney(string path)
        {
            List<string> allCardInfo = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] arr = new string[2];
                while ((line = sr.ReadLine()) != null)
                {
                    arr = line.Split('/');
                    if (arr[0] == number)
                    {
                        allCardInfo.Add(arr[0] + "/" + balance);
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
    }
}
