using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab4_gener
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Stack<string> res = new Stack<string>();
        private List<string> skb = new List<string>();

        private bool isDigit(string str)
        {
            int i = 0;
            if ((str[0] == '+' || str[0] == '-' || str[0] == '#') && str.Length != 1)
                i++;
            while (i < str.Length && (str[i] >= '0' && str[i] <= '9'))
                i++;
            if (str.Length == i)
                return true;
            else
                return false;

        }
        private bool isID(string str)
        {
            int i = 0;
            if ((str[i] >= '0') && str[i] <= '9')
                return false;
            while (i < str.Length && ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z')
                        || (str[i] >= '0' && str[i] <= '9')))
                i++; 
            if (str.Length == i)
                return true;
            else
                return false;

        }

        private int isWho(string str)//0 - num, 1 - id, 2 - exp , 3+num -group_skb 
        {
            if (str == "")
                return -1;
            
            if (isDigit(str))
                return 0;
            if (isID(str))
                return 1;
            if (str[0] == '!')
            {

                int n = 0;
                try
                {
                    n = int.Parse(str.Substring(1, str.Length - 1));
                    return 3 + n - 1;
                }
                catch
                {
                    return isWho(str.Substring(1, str.Length - 1));
                }

            }
            return 2;
        }        
    
        private string prisvoit(string str)
        {
            int i = -1, h;
            string temp = "", temp2 = "";
            if ((i = str.IndexOf('=')) != -1)
            {
                temp = str.Substring(0, i);
                if (isWho(temp) != 1)
                    return "err";
                temp2 = generate3(str.Substring(i+1, str.Length - i - 1));
                if (temp2 == "err")
                    return "err";
                h = isWho(temp2);
                if (h == -1)
                    return "err";
                if (h == 0 || h == 1)
                {
                    return ("mov " + temp + ", " + temp2);
                }
                else
                {
                    return (temp2 + "mov " + temp + ", ax");
                }

            }
            return "err";
        }

        private string un_skb(string str)
        {
            string temp = "";
            int i = -1;  
            if ((i = str.LastIndexOf(')')) != -1)
            {
                int j = i;
                i--;
                int count = -1;
                temp = "";
                while (count != 0 && i >= 0)
                {
                    if (str[i] == ')')
                        count--;
                    if (str[i] == '(')
                        count++;
                    if (count != 0)
                        temp = str[i] + temp;
                    i--;
                }
                i++;
                if (i < 0)
                    return "err";
                else
                {
                    int h;
                    temp = un_skb(temp); 
                    h = isWho(temp);
                    if (h == -1)
                    {
                        temp = "err";
                    }
                    if(h == 0 || h == 1)
                        temp = temp;
                    if (h == 2)
                    {                      
                        
                        skb.Add(temp);
                        temp = "!" + skb.Count.ToString();
                        
                    }
                    
                    if (j + 1 < str.Length)
                            str = str.Substring(0, i) + temp + str.Substring(j + 1, str.Length - j - 1);
                    else
                            str = str.Substring(0, i) + temp;
                    return un_skb(str);                    
                }
            }
            else
                return str;
        }

        private string generate3(string str)
        {
            string temp = "", left_str = "", right_str = "";
            int i = -1;
            int is_right = -1;
            int is_left = -1;
            int flag = 0;
            string resualt = "";
            if ((i = str.IndexOf('+')) != -1 && flag == 0)
            {
                flag = 1;
                left_str = str.Substring(0, i);
                right_str = str.Substring(i + 1, str.Length - i - 1);
                is_left = isWho(left_str);
                is_right = isWho(right_str);
                if (is_left == -1 || is_right == -1)
                    return "err";
                if (is_left == 0 || is_left == 1)
                {
                    if (is_right == 0 || is_right == 1)
                    {
                        temp = "mov ax, " + left_str;
                        resualt += temp + "^";
                        temp = "add ax, " + right_str;
                        resualt += temp + "^";
                        temp = "";
                    }
                    else
                    {
                        if (is_right == 2 || is_right >= 3)
                        {
                            if (is_right < 3)
                                if ((temp = generate3(right_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                if ((temp = generate3(skb[is_right - 3])) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            temp = "add ax, " + left_str;
                            resualt += temp + "^";

                        }
                        else
                            return "err";
                    }
                }
                else
                {
                    if (is_left == 2 || is_left >= 3)
                    {
                        if (is_right == 0 || is_right == 1)
                        {
                            if (is_left < 3)
                                if ((temp = generate3(left_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";

                            else
                                if ((temp = generate3(skb[is_left - 3])) != "err")
                                    resualt += temp;
                                else
                                    return "err"; 
                            temp = "add ax, " + right_str;
                            resualt += temp + "^";
                        }
                        else
                        {
                            if (is_right == 2 || is_right >= 3)
                            {
                                if (is_right < 3)
                                    if ((temp = generate3(right_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";

                                else
                                    if ((temp = generate3(skb[is_right - 3])) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                resualt += "push ax" + "^";
                                if (is_left < 3)
                                    if ((temp = generate3(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    if ((temp = generate3(skb[is_left - 3])) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                resualt += "pop dx" + "^";
                                resualt += "add ax, dx" + "^";
                            }
                            else
                                return "err";
                        }
                    }
                    else
                        return "err";
                }
            }
            if ((i = str.LastIndexOf('-')) != -1 && flag == 0)
            {
                flag = 1;
                left_str = str.Substring(0, i);
                right_str = str.Substring(i + 1, str.Length - i - 1);
                is_left = isWho(left_str);
                is_right = isWho(right_str);
                
                if (is_left == -1 || is_right == -1)
                    return "err";
                
                if (is_left == 0 || is_left == 1)
                {
                    if (is_right == 0 || is_right == 1)
                    {
                        temp = "mov ax, " + left_str;
                        resualt += temp + "^";
                        temp = "sub ax, " + right_str;
                        resualt += temp + "^";
                        temp = "";
                    }
                    else
                    {
                        if (is_right == 2 || is_right >= 3)
                        {
                            if (is_right < 3)
                                 if ((temp = generate3(right_str)) != "err")
                                    resualt += temp;
                                 else
                                    return "err";
                                
                            else
                                if ((temp = generate3(skb[is_right - 3])) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            temp = "mov dx, " + left_str;
                            resualt += temp + "^";
                            resualt += ("xchg ax, dx^");
                            resualt += ("sub ax, dx^");

                        }
                        else
                            return "err";
                    }
                }
                else
                {
                    if (is_left == 2 || is_left >= 3)
                    {
                        if (is_right == 0 || is_right == 1)
                        {
                            if (is_left < 3)
                                if ((temp = generate3(left_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                if ((temp = generate3(skb[is_left - 3])) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            temp = "sub ax, " + right_str;
                            resualt += (temp) + "^";
                        }
                        else
                        {
                            if (is_right == 2 || is_right >= 3)
                            {
                                if (is_right < 3)
                                    if ((temp = generate3(right_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    if ((temp = generate3(skb[is_right - 3])) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                resualt += ("push ax^");
                                if (is_left < 3)
                                    if ((temp = generate3(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    if ((temp = generate3(skb[is_left - 3])) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                resualt +=("pop dx^");
                                resualt += ("sub ax, dx^");
                            }
                            else
                                return "err";
                        }
                    }
                }

            }
            if ((i = str.IndexOf('*')) != -1 && flag == 0)
            {
                flag = 1;
                left_str = str.Substring(0, i);
                right_str = str.Substring(i + 1, str.Length - i - 1);
                is_left = isWho(left_str);
                is_right = isWho(right_str);
                if (is_left == -1 || is_right == -1)
                    return "err";
                if (is_left == 0 || is_left == 1)
                {
                    if (is_right == 0 || is_right == 1)
                    {
                        temp = "mov ax, " + left_str;
                        resualt += (temp) + "^";
                        temp = "mul ax, " + right_str;
                        resualt += (temp) + "^";
                        temp = "";
                    }
                    else
                    {
                        if (is_right == 2 || is_right >= 3)
                        {
                            if (is_right < 3)
                                if ((temp = generate3(right_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                if ((temp = generate3(skb[is_right - 3])) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            temp = "mul ax, " + left_str;
                            resualt += (temp) + "^";
                        }
                    }
                }
                else
                {
                    if (is_left == 2 || is_left >= 3)
                    {
                        if (is_right == 0 || is_right == 1)
                        {
                            if (is_left < 3)
                                if ((temp = generate3(left_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                if ((temp = generate3(skb[is_left - 3])) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            temp = "mul ax, " + right_str;
                            resualt += (temp) + "^";
                        }
                        else
                        {
                            if (is_right == 2 || is_right >= 3)
                            {
                                if (is_right < 3)
                                    if ((temp = generate3(right_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    if ((temp = generate3(skb[is_right - 3])) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                resualt += ("push ax^");
                                if (is_left < 3)
                                    if ((temp = generate3(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    if ((temp = generate3(skb[is_left - 3])) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                               resualt += ("pop dx^");
                               resualt += ("mul ax, dx^");
                            }
                        }
                    }
                }

            }
            if ((i = str.LastIndexOf('/')) != -1 && flag == 0)
            {
                flag = 1;
                left_str = str.Substring(0, i);
                right_str = str.Substring(i + 1, str.Length - i - 1);
                is_left = isWho(left_str);
                is_right = isWho(right_str);
                if (is_left == -1 || is_right == -1)
                    return "err";
                if (is_left == 0 || is_left == 1)
                {
                    if (is_right == 0 || is_right == 1)
                    {
                        temp = "mov ax, " + left_str;
                        resualt += (temp) + "^";
                        temp = "div ax, " + right_str;
                        resualt += (temp) + "^";
                        temp = "";
                    }
                    else
                    {
                        if (is_right == 2 || is_right >= 3)
                        {
                            if (is_right < 3)
                                if ((temp = generate3(right_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                if ((temp = generate3(skb[is_right - 3])) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            temp = "mov dx, " + left_str;
                            resualt += (temp) +"^";
                            resualt += ("xchg ax, dx^");
                            resualt += ("div ax, dx^");

                        }
                    }
                }
                else
                {
                    if (is_left == 2 || is_left >= 3)
                    {
                        if (is_right == 0 || is_right == 1)
                        {
                            if (is_left < 3)
                                if ((temp = generate3(left_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                if ((temp = generate3(skb[is_left - 3])) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            temp = "div ax, " + right_str;
                            resualt += (temp)+"^";
                        }
                        else
                        {
                            if (is_right == 2 || is_right >= 3)
                            {
                                if (is_right < 3)
                                    if ((temp = generate3(right_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    if ((temp = generate3(skb[is_right - 3])) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                resualt += ("push ax^");
                                if (is_left < 3)
                                    if ((temp = generate3(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    if ((temp = generate3(skb[is_left - 3])) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                resualt += ("pop dx^");
                                resualt += ("div ax, dx^");
                            }
                        }
                    }
                }

            }
            if ((i = str.LastIndexOf('#')) != -1 && flag == 0)
            {
                if(i != 0)
                    return "err";
                int h = isWho(str.Substring(1, str.Length -1));
                if (h == 1)
                {
                    return resualt += "mov ax, " + str.Substring(1, str.Length - 1) + "^neg ax^";
                    
                }
                if(h == 2)
                {
                    temp = str.Substring(1, str.Length - 1);
                    if ((temp = generate3(temp)) != "err")
                        return resualt += temp + "neg ax^";
                    else
                        return "err";
                }
                if (h >= 3)
                {
                    temp = str.Substring(1, str.Length - 1);
                    if ((temp = generate3(skb[h - 3])) != "err")
                        resualt += temp;                        
                    else
                        return "err";
                    return resualt +=  "neg ax^";
                   
                }
                return "err";
            }
            if (flag == -1)
                return "err";
            else
            {
                if (flag == 0)
                {
                    int h = isWho(str);
                    if (h == -1)
                        return "err";

                    if(h >= 3)
                        if ((temp = generate3(skb[h - 3])) != "err")
                            resualt += temp;
                        else
                            return "err";
                        
                    if (h == 0)
                    {
                       return str;
                    }
                    if (h == 1)
                       return str;
                        
                }
                return resualt;
            }

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            str = textBox1.Text;
            str = str.Replace(" ", "");
            if (str != "")
            {
                textBox2.AppendText(str + "\n");
               
                
                for (int i = 1; i < str.Length; i++ )
                {
                    if(str[i] == '-')
                         if (str[i - 1] == '=' ||str[i - 1] == '*' || str[i - 1] == '/' || str[i - 1] == '+' || str[i - 1] == '-' || str[i - 1] == '(')
                        str = str.Substring(0, i) + "#" + str.Substring(i + 1, str.Length - i - 1);
                }
                str = un_skb(str);                
                  str = prisvoit(str);
                  if (str != "err")
                  {

                      str = str.Replace("#", "-");
                      String[] elements = str.Split('^');
                      foreach (var element in elements)
                          textBox2.AppendText(element + "\n");
                  }
                  else
                      MessageBox.Show("Error sttring!");
            }
            else
            {
                MessageBox.Show("Empty sttring!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox1.Clear();
            res.Clear();
        }
    }
}
