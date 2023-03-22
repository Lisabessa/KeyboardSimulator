using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardApp
{
    class Trainer
    {
        public int Speed = 0;
        public bool CaseSensitive { get; set; }
        public int Level { get; set; }
        public int Errors { get; set; }
        public string Test;

        private string alphabetCS = "`1234567890-=~!@#$%^&*()_+qwertyuiop[]QWERTYUIOP{}asdfghjkl;'\\ASDFGHJKL:\"|zxcvbnm,./ZXCVBNM<>?";
        private string alphabet = "`1234567890-=qwertyuiop[]asdfghjkl;'\\zxcvbnm,./";

        public Trainer()
        {
            CaseSensitive = false;
            Level = 3;
        }

        public string GenTest() // метод генерации строки
        {
            string test = "";
            string currAlpha = "";
            List<int> indexes = new List<int>();
            int num;
            Random rand = new Random();
            for(int i=0; i<this.Level; i++)
            {
                if (CaseSensitive)
                {
                    num = rand.Next(alphabetCS.Length);
                    while (indexes.Contains(num))
                    {
                        num = rand.Next(alphabetCS.Length);
                    }
                    indexes.Add(num);
                    currAlpha += alphabetCS[num];
                }
                else
                {
                    num = rand.Next(alphabet.Length);
                    while (indexes.Contains(num))
                    {
                        num = rand.Next(alphabet.Length);
                    }
                    indexes.Add(num);
                    currAlpha += alphabet[num];
                }
            }
            currAlpha += " ";
            
            for(int i=0; i<50; i++)
            {
                num = rand.Next(currAlpha.Length);
                test += currAlpha[num];
            }

            this.Test = test;
            return test;
        }

        public bool Comparison(int ind, string symb)
        {
            if(this.Test[ind] == symb[0])
            {
                return true;
            }
            return false;
        }

        public string GameResult()
        {
            string res = "Поздравляем! Вы закончили игру\n";
            res += "Вы допустили " + this.Errors.ToString() + " ошибок.\n";

            if(this.Errors <= 3)
            {
                res += "Отличный результат, так держать!\n";
            }
            else if(this.Errors <= 5)
            {
                res += "Ты молодец!\n";
            }
            else if (this.Errors <= 10)
            {
                res += "Неплохо, но будет лучше!\n";
            }
            else
            {
                res += "В следующий раз всё точно получится!\n";
            }


            return res;
        }
    }
}
