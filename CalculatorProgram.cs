using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Calc
    {
        public double ResultingVariable { get; set; }
        public double MemoryVariable { get; set; }

        public Calc(double s, double m)
        {
            ResultingVariable = s;
            MemoryVariable = m;

        }
        public Calc()
        {
            ResultingVariable = 0;
            MemoryVariable = 0;
        }
        public double Calculate(string ex)
        {
            string[] s;
            if (ex.Contains("∞"))//артефакт может появиться после попытки поделить на ноль
            {
                ex = ex.Substring(1, ex.Length - 1);
            }
            char a_negativity = Convert.ToChar(ex.Substring(0, 1));//проверям, отрицательное ли первое число
            string[] seporators = new string[] { "+", "-", "*", "/" };//разделителями для строки будут вычиляемые операции
            double a, b;//контейнеры для первичных значений цифр
            double a_res, b_res;//контейнеры для вычисленных значений

            if (ex[0] == '-' || ex[0] == '+' || ex[0] == '*' || ex[0] == '/')//убираем любые лишние знаки из строки
            //они могут появиться после деления на ноль
            {
                ex = ex.Substring(1, ex.Length - 1);
            }

            if (!ex.Contains("+") && !ex.Contains("-") && !ex.Contains("*") && !ex.Contains("/") && !ex.Contains("^") && !ex.Contains("%"))
            //если в строке нет ни одного знака операции, значит у нас просто число, возвращаем его
            {
                a = Convert.ToDouble(ex);
                if (a_negativity == '-')//отрицательное, если первым знаком был минус
                {
                    ResultingVariable = -a;
                    return ResultingVariable;
                }
                ResultingVariable = a;//либо положительное
                return ResultingVariable;
            }
            
            //наконец переходим к операциям с двумя числами
            else
            {
                //проверим, отрицательное ли второе число
                if (!ex.Contains("+-") && !ex.Contains("--") && !ex.Contains("*-") && !ex.Contains("/-"))//положительное
                {
                    s = ex.Split(seporators, StringSplitOptions.None);//делим строку на числа

                    a_res = Convert.ToDouble(s[0]);

                    if (a_negativity == '-')
                    {
                        a_res = -a_res;
                    }
                    
                    else b_res = Convert.ToDouble(s[1]);


                    if (ex.Contains('+'))
                    {
                        ResultingVariable = a_res + b_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains('-'))
                    {
                        ResultingVariable = a_res - b_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains('*'))
                    {
                        ResultingVariable = a_res * b_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains('/'))
                    {
                        ResultingVariable = a_res / b_res;
                        return ResultingVariable;
                    }
                    else return a_res;
                }
                else //если отрицательное
                {
                    char b_negativity = '-';
                    seporators = new string[] { "+-", "--", "*-", "/=" };//изменяем разделителями

                    s = ex.Split(seporators, StringSplitOptions.None);//делим строку на числа

                    a_res = Convert.ToDouble(s[0]);

                    if (a_negativity == '-')
                    {
                        a_res = -a_res;
                    }
                    
                    else b_res = Convert.ToDouble(s[1]);
                    if (b_negativity == '-')
                    {
                        b_res = -b_res;
                    }

                    if (ex.Contains("+-"))
                    {
                        ResultingVariable = a_res + b_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains("--"))
                    {
                        ResultingVariable = a_res - b_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains("*-"))
                    {
                        ResultingVariable = a_res * b_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains("/-"))
                    {
                        ResultingVariable = a_res / b_res;
                        return ResultingVariable;
                    }
                    else return a_res;
                }
            }
        }//функция проверки наличия точки в числе
        public bool CheckDot(string ex)
        {
            string[] s;
            ex = ex.Substring(1, ex.Length - 1);//сразу сносим первый знак, чтобы не мешал. если он минус, это ни на что не повлияет
            string[] seporators = new string[] { "+", "-", "*", "/" };//разделителями для строки будут вычиляемые операции
            //если теперь нет знаков операций, значит. число единичное
            if (!ex.Contains("+") && !ex.Contains("-") && !ex.Contains("*") && !ex.Contains("/") && !ex.Contains("^") && !ex.Contains("%"))
            {
                if (ex.Contains(",")) return true;
                else return false;
            }
            //если всё ещё есть:
            else
            {
                s = ex.Split(seporators, StringSplitOptions.None);//делим строку на числа
                if (s[1].Contains(",")) return true;
                else return false;
            }
        }
    }
}

