using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TIMCADV
{
    public class ValuesContainer
    {
        //Values
        public List<double> list_of_elems = new List<double>();
        public List<double> one_elem_list = new List<double>();
        public Dictionary<double, double> diction = new Dictionary<double, double>();
        public bool UncreaseSample=false;
        public Dictionary<double, double> _dict = new Dictionary<double, double>();
        public int chosedIndex = 0;
        public int _size = 0;
        //Main lists
        public List<double> xList = new List<double>();
        public List<double> yList = new List<double>();
        //Methods
        //Read from file
        public void ReadFromFile(int size, string name)
        {
            _size = size;
            StreamReader Reader = new StreamReader(name, System.Text.Encoding.Default);
            string sLine = "";
            while (sLine != null)
            {
                string newSample = "";
                for (int i = 0; i < size; i++)
                {
                    sLine = Reader.ReadLine();
                    if (sLine == null || sLine == " ")
                    {
                        return;
                    }
                    newSample = newSample + sLine + " ";
                    one_elem_list.Add(double.Parse(sLine));
                }
                AddDictionary(double.Parse(newSample));
            }
            Reader.Close();
        }
        //For listbox, used in ReadFromFile
        public List<double> AddDictionary(double elem)
        {
            list_of_elems.Add(elem);
            return list_of_elems;
        }
        //Generate file
        public void GenerateFile(int size, int from, int to, string name)
        {
            string result = "";
            Random randomSample = new Random();
            for (int i = 0; i < size; i++)
            {
                result = result + randomSample.Next(from, to) + " " + "\n";
            }
            File.WriteAllText(name, result);
        }
        //For get value list
        public List<double> GetDict()
        {
            return list_of_elems;
        }
        //Transform list in dictionary
        public double SumOfY()
        {
            double sum = 0;
            for (int i = 0; i < yList.Count; i++)
            {
                sum += yList[i];
            }
            return sum;
        }
        public double SumOfX()
        {
            double sum = 0;
            for (int i = 0; i < xList.Count; i++)
            {
                sum += xList[i];
            }
            return sum;
        }
        public double Moda()
        {
            double res;
            res = xList[0];
            return res;
        }
        public double Mediana()
        {
            double res;
            if (xList.Count % 2 != 0)
            {
                res = xList[xList.Count / 2];
                return res;
            }
            else
            {
                res = (xList[xList.Count / 2] + xList[(xList.Count / 2) - 1]) / 2;
                return res;
            }
        }
        public double MidValue()
        {
            double res;
            res = Convert.ToDouble(SumOfX()) / Convert.ToDouble(xList.Count);
            return res;
        }
        public double Deviaciya()
        {
            double res = 0;
            for (int i = 0; i < xList.Count; i++)
            {
                res += Math.Pow(Convert.ToDouble(xList[i]) - Convert.ToDouble(MidValue()), 2);
            }
            return res;
        }
        public double Rozmah()
        {
            double res = 0;
            res = Convert.ToDouble(xList[xList.Count - 1]) - Convert.ToDouble(xList[0]);
            return res;
        }
        public double Variansa()
        {
            double res = 0;
            res = (Convert.ToDouble(1) / Convert.ToDouble(xList.Count - 1)) * Convert.ToDouble(Deviaciya());
            return res;
        }
        public double Standart()
        {
            double res = 0;
            res = Math.Sqrt(Convert.ToDouble(Variansa()));
            return res;
        }
        public double Variaciya()
        {
            double res = 0;
            res = Convert.ToDouble(Standart()) / Convert.ToDouble(MidValue());
            return res;
        }
        public string GetQuant()
        {
            string res = null;
            int index;
            for (int i = 1; i < xList.Count; i++)
            {
                index = (i * 100) / xList.Count;
                res += "q{" + index.ToString() + "}" + "=X{" + i.ToString() + "}\n";
            }
            return res;
        }
        public string GetQuartile()
        {
            string res = null;
            for (int i = 25; i <= 75; i += 25)
            {
                double temp = (i * xList.Count) / 100;
                double a = i * xList.Count / 100;
                if (temp % 1 == 0)
                {
                    res += "Q{" + (i / 25).ToString() + "}=X{" + ((double)a).ToString() + "}\n";
                }
            }
            return res;
        }
        public string GetDecel()
        {
            string res = null;
            for (int i = 10; i <= 90; i += 10)
            {
                double temp = (i * xList.Count) / 100;
                double a = i * xList.Count / 100;
                if (temp % 1 == 0)
                {
                    res += "Q{" + (i / 25).ToString() + "}=X{" + ((double)a).ToString() + "}\n";
                }
            }
            return res;
        }
        public double StartMoment(int n)
        {
            double sum = 0;
            foreach (var i in xList)
            {
                sum += Math.Pow(i, n);
            }
            return sum / xList.Count;
        }
        public double CentralMoment(double n)
        {
            double a = MidValue();
            double sum = 0;
            foreach (var i in xList)
            {
                sum += Math.Pow(i - a, n);
            }
            return sum / xList.Count;
        }
        public double GetAsymmetry()
        {
            double c3 = CentralMoment(3);
            double c2 = CentralMoment(2);
            c2 = Math.Pow(c2, 1.5);
            return c3 / c2;
        }
        public double GetExcess()
        {
            double c4 = CentralMoment(4);
            double c2 = CentralMoment(2);
            c2 *= c2;
            return (c4 / c2) - 3;
        }
    }
}
