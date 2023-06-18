using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorProgram
    {
        public static  double ResultingVariable { get; set; }
        public static double MemoryVariable { get; set; }

        public static double A_res { get; set; }
        public static double B_res { get; set; }
        public static char Operation { get; set; }


        public CalculatorProgram(double s, double m)
        {
            ResultingVariable = s;
            MemoryVariable = m;
            A_res = 0;
            B_res = 0;

        }
        public CalculatorProgram()
        {
            ResultingVariable = 0;
            MemoryVariable = 0;
            A_res = 0;
            B_res = 0;
        }
        public static double Calculate(string ex)
        {
            string[] s;
            if (ex.Contains("∞"))//артефакт может появиться после попытки поделить на ноль
            {
                ex = ex.Substring(1, ex.Length - 1);
            }
            char a_negativity = Convert.ToChar(ex.Substring(0, 1));//проверям, отрицательное ли первое число
            string[] seporators = new string[] { "+", "-", "*", "/" };//разделителями для строки будут вычиляемые операции
            double a, b;//контейнеры для первичных значений цифр

            if (ex[0] == '-' || ex[0] == '+' || ex[0] == '*' || ex[0] == '/')//убираем любые лишние знаки из строки
            //они могут появиться после деления на ноль
            {
                ex = ex.Substring(1, ex.Length - 1);
            }

            if (!ex.Contains("+") && !ex.Contains("-") && !ex.Contains("*") && !ex.Contains("/") && !ex.Contains("^") && !ex.Contains("%"))
            //если в строке нет ни одного знака операции, значит у нас просто число, возвращаем его
            {
                Operation = '0';
                a = Convert.ToDouble(ex);
                if (a_negativity == '-')//отрицательное, если первым знаком был минус
                {
                    ResultingVariable = -a;
                    return ResultingVariable;
                }
                ResultingVariable = a;//либо положительное
                return ResultingVariable;
            }
            else if (!ex.Contains("+") && !ex.Contains("-") && !ex.Contains("*") && !ex.Contains("/") && !ex.Contains("%") && ex.Contains("^"))
            //если в строке есть только знак квадратного корня
            {
                if (a_negativity == '-')//квадратного корня от отрицательного числа нет, возвращаем ноль
                {
                    ResultingVariable = 0;
                    return ResultingVariable;
                }
                ex = ex.Substring(0, ex.Length - 1);//убираем из строки знак корня 
                a = Convert.ToDouble(ex);
                ResultingVariable = Math.Sqrt(a);//и возвращаем вычисление
                return ResultingVariable;
            }
            else if (!ex.Contains("+") && !ex.Contains("-") && !ex.Contains("*") && !ex.Contains("/") && !ex.Contains("^") && ex.Contains("%"))
            //если в строке только знак процента, возвращаем сотую часть числа
            {
                ex = ex.Substring(0, ex.Length - 1);
                a = Convert.ToDouble(ex);
                if (a_negativity == '-')//если первым знаком был минус, возвращаем отрицательное число
                {
                    ResultingVariable = -a / 100;
                    return ResultingVariable;
                }
                ResultingVariable = a / 100;//если нет, то положительное
                return ResultingVariable;
            }

            //наконец переходим к операциям с двумя числами
            else
            {
                //проверим, отрицательное ли второе число
                if (!ex.Contains("+-") && !ex.Contains("--") && !ex.Contains("*-") && !ex.Contains("/-"))//положительное
                {
                    s = ex.Split(seporators, StringSplitOptions.None);//делим строку на числа

                    A_res = Convert.ToDouble(s[0]);

                    if (a_negativity == '-')
                    {
                        A_res = -A_res;
                    }

                    if (s[1].Contains('%'))
                    {
                        Operation = '%';
                        s[1] = s[1].Substring(0, s[1].Length - 1);//убираем значок процента в конце
                        b = Convert.ToDouble(s[1]);
                        B_res = b * A_res / 100;
                    }
                    else if (s[1].Contains('^'))
                    {
                        Operation = '^';
                        s[1] = s[1].Substring(0, s[1].Length - 1);//убираем значок корня конце
                        b = Convert.ToDouble(s[1]);
                        B_res = Math.Sqrt(b);
                    }
                    else B_res = Convert.ToDouble(s[1]);


                    if (ex.Contains('+'))
                    {
                        Operation = '+';
                        ResultingVariable = A_res + B_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains('-'))
                    {
                        Operation = '-';
                        ResultingVariable = A_res - B_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains('*'))
                    {
                        Operation = '*';
                        ResultingVariable = A_res * B_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains('/'))
                    {
                        Operation = '/';
                        ResultingVariable = A_res / B_res;
                        return ResultingVariable;
                    }
                    else return A_res;
                }
                else //если отрицательное
                {
                    char b_negativity = '-';
                    seporators = new string[] { "+-", "--", "*-", "/=" };//изменяем разделителями

                    s = ex.Split(seporators, StringSplitOptions.None);//делим строку на числа

                    A_res = Convert.ToDouble(s[0]);

                    if (a_negativity == '-')
                    {
                        A_res = -A_res;
                    }

                    if (s[1].Contains('%'))
                    {
                        s[1] = s[1].Substring(0, s[1].Length - 1);//убираем значок процента в конце
                        b = Convert.ToDouble(s[1]);
                        B_res = b * A_res / 100;
                    }
                    else if (s[1].Contains('^'))
                    {
                        s[1] = s[1].Substring(0, s[1].Length - 1); //убираем значок корня конце
                        b = Convert.ToDouble(s[1]);
                        B_res = Math.Sqrt(b);
                    }
                    else B_res = Convert.ToDouble(s[1]);
                    if (b_negativity == '-')
                    {
                        B_res = -B_res;
                    }

                    if (ex.Contains("+-"))
                    {
                        ResultingVariable = A_res + B_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains("--"))
                    {
                        ResultingVariable = A_res - B_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains("*-"))
                    {
                        ResultingVariable = A_res * B_res;
                        return ResultingVariable;
                    }
                    else if (ex.Contains("/-"))
                    {
                        ResultingVariable = A_res / B_res;
                        return ResultingVariable;
                    }
                    else return A_res;
                }
            }
        }//функция проверки наличия точки в числе
        public static bool CheckDot(string ex)
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

