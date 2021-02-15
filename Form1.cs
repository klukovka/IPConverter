using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPconverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] mask = new string[] { ConvertDecToSmth(Convert.ToInt32(MOct1.Text), 2), ConvertDecToSmth(Convert.ToInt32(MOct2.Text), 2),
              ConvertDecToSmth(Convert.ToInt32(MOct3.Text), 2),ConvertDecToSmth(Convert.ToInt32(MOct4.Text), 2)};
            string[] ip = new string[] { ConvertDecToSmth(Convert.ToInt32(IPOct1.Text), 2), ConvertDecToSmth(Convert.ToInt32(IPOct2.Text), 2),
              ConvertDecToSmth(Convert.ToInt32(IPOct3.Text), 2),ConvertDecToSmth(Convert.ToInt32(IPOct4.Text), 2)};
            for (int i = 0; i < 4; i++)
            {
                mask[i] = mask[i].PadLeft(8, '0');
                ip[i] = ip[i].PadLeft(8, '0');
            }

            string[] res = new string[4];
            int[] num = new int[] {Convert.ToInt32(IPOct1.Text),
            Convert.ToInt32(IPOct2.Text),
            Convert.ToInt32(IPOct3.Text),
            Convert.ToInt32(IPOct4.Text)};

            string number = "";
            string result = "";
            for (int i = 0; i < 4; i++)
            {
             
                res[i] = "";
                for (int j = 0; j < 8; j++)
                    res[i] += (mask[i][j] == '1') && (ip[i][j] == '1') ? "1" : "0";
                result += ConvertToDec(res[i], 2) + ".";
                num[i] -= Convert.ToInt32(ConvertToDec(res[i], 2));
             number += num[i].ToString() + ".";
            }
            result = result.TrimEnd('.');
            number = number.TrimEnd('.');
            Result.Text = result;
            Number.Text = number;

       
        }
        private string ConvertToDec(string num, int based)
        {
            num = num.ToUpper();
            char[] val = num.ToCharArray();
            Array.Reverse(val);
            double res = 0;
            for (int i = 0; i < val.Length; i++)
            {
                int temp;
                switch (val[i])
                {
                    case 'A':
                        temp = 10;
                        break;
                    case 'B':
                        temp = 11;
                        break;
                    case 'C':
                        temp = 12;
                        break;
                    case 'D':
                        temp = 13;
                        break;
                    case 'E':
                        temp = 14;
                        break;
                    case 'F':
                        temp = 15;
                        break;
                    default:
                        temp = Convert.ToInt32(val[i].ToString());
                        break;
                }
                res += temp * Math.Pow(based, i);

            }
            return res.ToString();
        }
        private string ConvertDecToSmth(int num, int a)
        {
            string res = "";
            List<int> list = new List<int>();
            while (num >= a)
            {
                list.Add(num % a);
                num = Convert.ToInt32(Math.Floor((decimal)num / a));
            }
            list.Add(num);

            list.Reverse();
            foreach (int item in list)
            {
                switch (item)
                {
                    case 10:
                        res += "A";
                        break;
                    case 11:
                        res += "B";
                        break;
                    case 12:
                        res += "C";
                        break;
                    case 13:
                        res += "D";
                        break;
                    case 14:
                        res += "E";
                        break;
                    case 15:
                        res += "F";
                        break;
                    default:
                        res += item.ToString();
                        break;
                }


            }
            return res;
        }

        private void pref_TextChanged(object sender, EventArgs e)
        {
            if (pref.Text != "")
            {
                string nums = "";
                for (int i = 0; i < Convert.ToInt32(pref.Text); i++)
                    nums += "1";
                nums = nums.PadRight(32, '0');
                MOct1.Text = ConvertToDec(nums.Substring(0, 8), 2);
                MOct2.Text = ConvertToDec(nums.Substring(8, 8), 2);
                MOct3.Text = ConvertToDec(nums.Substring(16, 8), 2);
                MOct4.Text = ConvertToDec(nums.Substring(24, 8), 2);
            }
        }
    }
}
