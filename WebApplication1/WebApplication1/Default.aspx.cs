using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Diagnostics;
namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
         public delegate bool Checker(string s);
         public delegate string StrFunc(string s);
         public static Regex RegexCheckOperator = new Regex(@"[xX*]|[:/]|\-|\+");
        public static Regex RegexFullOper = new Regex(@"[xX*]|[:/]|\-|\+|\((.*)\)|\(|\)");
         public static Regex RegexCheckParentheses = new Regex(@"\((.*)\)");
         
         public static Checker checkPrevIsOperator = (x => RegexCheckOperator.IsMatch(x[x.Length-1].ToString()));
         public static StrFunc removeLast = (x => x.Substring(0, x.Length - 1));
         public static StrFunc getLast = (x => x.Last().ToString());

      
        protected void Page_Load(object sender, EventArgs e)
        {
     
        }

        public static bool checkIsFirstIsZero(string s)
        {
            Regex regexZero = new Regex(@"^(0)");
            string[] stringSplit = RegexFullOper.Split(s).Where(x=>x.Length > 0).ToArray();
      
            if(stringSplit.Length < 1)
            {
                return false;
            }

            return regexZero.IsMatch(stringSplit[stringSplit.Length-1]);
        }
        protected void btn_num(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(prevRes.Text != "0" && storeRes.Text.Length > 0)
            {
                prevRes.Text = "Ans : " + storeRes.Text;
                result.Text = "0";
                storeRes.Text = "";
            }


            if(result.Text == "0")
            {
                result.Text = btn.Text;
            }
            else if(getLast(result.Text) == ")")
            {
                result.Text += "*"+ btn.Text;
            }
            else if(getLast(result.Text) == "0")
            {
                result.Text = removeLast(result.Text) + btn.Text;
            }
            else
            {
                result.Text += btn.Text;
            }
            
        }
        
        public static double evaluate(double a, double b, char op)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '/':
                    return a / b;
                case '*':
                    return a * b;
                default:
                    return 0;
            }
        }

        public static double count(List<string> listStr)
        {
            try
            {
                List<double> stackNum = new List<double>();
                foreach (var i in listStr)
                {
                    if (RegexCheckOperator.IsMatch(i))
                    {
                        double a = stackNum[stackNum.Count - 2];
                        double b = stackNum[stackNum.Count - 1];
                        double c = evaluate(a, b, Char.Parse(i));
                        stackNum.RemoveRange(stackNum.Count - 2, 2);
                        stackNum.Add(c);
                    }
                    else
                    {
                        stackNum.Add(Convert.ToDouble(i));
                    }
                }

                if (stackNum.Any())
                {
                    return stackNum[0];
                }
                return 0;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
          
            
        }
        public static List<string> convertPosition(string[] arr)
        {
            try
            {

            List<string> token = new List<string>(arr);
            List<string> postStack = new List<string>();
            List<string> operStack = new List<string>();
            Dictionary<string, int> sortOper = new Dictionary<string, int>()
            {
                {"*",2 },
                {"/",2 },
                {"+",1 },
                {"-",1 }
            };

            if (arr.Length == 0)
            {
                return postStack;
            }

            foreach (var elem in arr)
            {
                if (RegexCheckOperator.IsMatch(elem.ToString()))
                {
                   
                    while (operStack.Any() && RegexCheckOperator.IsMatch(operStack.Last().ToString()) && sortOper[operStack.Last()] >= sortOper[elem])
                    {
                        var lastItem = operStack.Last();

                        postStack.Add(lastItem);
                        operStack.RemoveAt(operStack.Count -1);
                    }
                    operStack.Add(elem);
                }
                else if (elem == "(")
                {
                    operStack.Add(elem);
                }
                else if (elem == ")")
                {
                    while (operStack.Any() && operStack[operStack.Count -1] != "(")
                    {
                        var lastItem = operStack.Last();

                        postStack.Add(lastItem);
                        operStack.RemoveAt(operStack.Count - 1);
                    }
                    operStack.RemoveAt(operStack.Count - 1);
                }
                else
                {
                    postStack.Add(elem);
                }

            }
            while (operStack.Any())
            {
                var lastItem = operStack.Last();
                postStack.Add(lastItem);
                operStack.RemoveAt(operStack.Count - 1);
            }
          
            return postStack;

            }
            catch
            {
                return new List<string>() {"1","1","-" };
            }
        }

        protected void btn_oper(object sender, EventArgs e)
        {
            Button btnOper = (Button)sender;
            if (prevRes.Text != "0" && storeRes.Text.Length > 0)
            {
                prevRes.Text = "Ans : " + storeRes.Text;
                storeRes.Text = "";
            }

            if (checkPrevIsOperator(result.Text) || !RegexCheckOperator.IsMatch(btnOper.Text) || getLast(result.Text) == "(")
            {
                return;
            }
            else if(btnOper.ID == "btn_mul")
            {
                result.Text += "*";
            }
            else if (btnOper.ID == "btn_div")
            {
                result.Text += "/";
            }
            else
            {
                result.Text += btnOper.Text;
            }
        
        }
        protected void btnParenthesesOpen(object sender, EventArgs e)
        {
            Button btn_parantheses1 = (Button)sender;

            if (prevRes.Text != "0" && storeRes.Text.Length > 0)
            {
                prevRes.Text = "Ans : " + storeRes.Text;
                storeRes.Text = "";
            }
            if (getLast(result.Text) == "(")
            {
                return;
            }
            else if (result.Text == "0")
            {
                result.Text = $"({result.Text}";
           
            }
            else if(!checkPrevIsOperator(result.Text) || getLast(result.Text) == ")")
            {
                result.Text += $"*{btn_parantheses1.Text}";
             
            }
            else
            {
                result.Text += btn_parantheses1.Text;
            }
            parentheses.Text += ")";

        }
        protected void btnParenthesesClose(object sender, EventArgs e)
        {
            Button btn_parantheses2 = (Button)sender;
            if (checkPrevIsOperator(result.Text) || getLast(result.Text) == "(" || parentheses.Text.Length == 0)
            {
                return;
            }
            
            else if(parentheses.Text.Length > 0)
            {
                result.Text += btn_parantheses2.Text;
                parentheses.Text = parentheses.Text.Remove(0,1);
            }
         
        }
        protected void btn_enter(object sender, EventArgs e)
        {
            try
            {
                if(parentheses.Text.Length > 0 || checkPrevIsOperator(result.Text))
                {
                    return;
                }
                Regex RegexSplit = new Regex(@"([-+*/()])");
                string[] strArray = RegexSplit.Split(result.Text).Where(x => x.Length > 0).ToArray();
                if(strArray.Length < 1)
                {
                     result.Text = "0";
                }
                else
                {
                    List<string> stringList = convertPosition(strArray);
                    prevRes.Text = result.Text;
                  
                    result.Text = count(stringList).ToString();
                    storeRes.Text = result.Text;
                }
               
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                result.Text = "0";
            }
           
          

        }
        protected void btn_c(object sender, EventArgs e)
        {
            result.Text = "0";
            prevRes.Text = "0";
            storeRes.Text = "";
        }
        protected void btn_ce(object sender, EventArgs e)
        {
            if(result.Text.Length > 1)
            {
                result.Text = removeLast(result.Text);
            }
            else if(getLast(result.Text) == "(")
            {
                result.Text = removeLast(result.Text);
                parentheses.Text = parentheses.Text.Substring(0, 0);
            }
         
            
        }
    }
}