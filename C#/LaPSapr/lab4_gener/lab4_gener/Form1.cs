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
       /* private string preobr(string str)
        {
            string temp = "";
            int i = -1, count = 1, size_skb = -1 ;
            int j = -1;
            while ((i = str.IndexOf('(')) != -1)
            {
                j = i;
                while (count != 0 && i < str.Length)
                {
                    if (str[i] == ')')
                        count--;
                    if (str[i] == '(')
                        count++;
                    if(count != 0)
                        temp += str[i];
                    i++;
                }
                if (i > str.Length)
                    return "";
                size_skb++;
                skb.Add(temp);
                str = str.Substring(0, j) + "!" + size_skb.ToString() + str.Substring(j, str.Length - j - 1);
            }
            return str;
        }
        */

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

        private int isSimple(string str)//0 - num, 1 - id, 2 - exp , 3+num -group_skb 
        {
            if(str == "")
                return -1;            
            int i = 0;
            if (str[0] == '!')
            {
               
                int n = 0;
                try
                {
                    n = int.Parse(str.Substring(1, str.Length - 1));
                    return 3+n-1;
                }
                catch 
                {
                    return isSimple(str.Substring(1, str.Length - 1));                 
                }
                
            }
            for (int j = 0; j < str.Length; j++)
            {
                if (i == 0)
                {
                    if (str[j] >= '0' && str[j] <= '9')
                        i = 0;
                    else
                        if ( (str[j] >= 'a' && str[j] <= 'z') || (str[j] >= 'A' && str[j] <= 'Z'))
                            i = 1;
                        else
                           return 2;
                }
                else
                {
                    if ( (str[j] >= 'a' && str[j] <= 'z') || (str[j] >= 'A' && str[j] <= 'Z')
                        || (str[j] >= '0' && str[j] <= '9'))
                        i = 1;
                    else
                        return 2;
                }
            }
            return i;
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

        private string generate3(string str)
        {
            string temp = "", left_str = "", right_str = "";
            int i = -1;
            int is_right = -1;
            int is_left = -1;
            int flag = 0;
            string resualt = "";
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
                    flag = -1;
                else
                {
                    int h, h1 = -2;
                    temp = generate3(temp);
                    h = isWho(temp);
                    if (h == -1)
                    {
                        //int i1;
                        //if ((i1 = str.LastIndexOf('#')) != -1)
                        //{
                        //    if (i1 != 0)
                        //        return "err";
                        //    h1 = isWho(str.Substring(1, str.Length - 1));
                        //  /*  if (h1 == 1)
                        //    {
                        //        return resualt += "mov ax, " + str.Substring(1, str.Length - 1) + "^neg ax^";

                        //    }
                        //    if (h1 == 2)
                        //    {
                        //        temp = str.Substring(1, str.Length - 1);
                        //        if ((temp = generate3(temp)) != "err")
                        //            return resualt += temp + "^neg ax^";
                        //        else
                        //            return "err";
                        //    }*/
                        //    if(h1 != 2 || h1 != 1)
                        //        return "err";
                        //}
                        return "err";
                    }
                        
                    if (h >= 2)
                    {
                        skb.Add(temp);
                        int g = str.Length;
                        
                        if(j+1 < str.Length)
                            str = str.Substring(0, i) + "!" + skb.Count.ToString() + str.Substring(j + 1, str.Length - j - 1);
                        else
                            str = str.Substring(0, i) + "!" + skb.Count.ToString();
                        
                    }
                    else
                    {
                        if (h == 0 || h == 1)
                        {
                            if (j + 1 < str.Length)
                                str = str.Substring(0, i) + temp + str.Substring(j + 1, str.Length - j - 1);
                            else
                                str = str.Substring(0, i) + temp;
                        }
                        else
                            flag = -1;
                    }
                   if ((temp = generate3(str)) != "err")
                         resualt += temp;
                        //return temp;
                    else
                        return "err";
                    flag = 1;
                }
            }

            if ((i = str.LastIndexOf('+')) != -1 && flag == 0)
            {
                flag = 1;
                left_str = str.Substring(0, i);
                right_str = str.Substring(i + 1, str.Length - i - 1);
                is_left = isWho(left_str);
                is_right = isWho(right_str);
                if (is_left == -1 || is_right == -1)
                    return "err";          
                if (is_left == 0 || is_left == 1 )
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
                                resualt += skb[is_right - 3];
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
                                resualt += skb[is_left - 3];
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
                                    resualt += skb[is_right - 3];
                                resualt += "push ax" + "^";
                                if (is_left < 3)
                                    if ((temp = generate3(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_left - 3];
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
                                resualt += skb[is_right - 3];
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
                                resualt += skb[is_left - 3];
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
                                    resualt += skb[is_right - 3];
                                resualt += ("push ax^");
                                if (is_left < 3)
                                    if ((temp = generate3(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_left - 3];
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
                                resualt += skb[is_right - 3];
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
                                resualt += skb[is_left - 3];
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
                                    resualt += skb[is_right - 3];
                                resualt += ("push ax^");
                                if (is_left < 3)
                                    if ((temp = generate3(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_left - 3];
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
                                resualt += skb[is_right - 3];
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
                                resualt += skb[is_left - 3];
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
                                    resualt += skb[is_right - 3];
                                resualt += ("push ax^");
                                if (is_left < 3)
                                    if ((temp = generate3(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_left - 3];
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
                    //if ((temp = generate3(temp)) != "err")
                        return resualt += skb[h-3] + "neg ax^";
                    //else
                       // return "err";
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
                        resualt += skb[h - 3];
                    if (h == 0)
                    {
                       // resualt += "mov ax, " + str + "^";
                        return str;
                    }
                    if (h == 1)
                        return str;
                        //resualt += "mov ax, " + str + "^";
                }
                return resualt;
            }

        }

        private string generate4(string str)
        {
            string temp = "", left_str = "", right_str = "";
            int i = -1;
            int is_right = -1;
            int is_left = -1;
            int flag = 0;
            string resualt = "";
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
                    flag = -1;
                else
                {
                    //int h;
                    //temp = generate4(temp);
                    //h = isWho(temp);
                    //if (h == -1)
                    //{
                    //    return "err";
                    //}
                    //if (h >= 2)
                    //{
                        skb.Add(temp);   
                        if (j + 1 < str.Length)
                            str = str.Substring(0, i) + "!" + skb.Count.ToString() + str.Substring(j + 1, str.Length - j - 1);
                        else
                            str = str.Substring(0, i) + "!" + skb.Count.ToString();
                    //}
                    //else
                    //{
                    //    if (h == 0 || h == 1)
                    //    {
                    //        if (j + 1 < str.Length)
                    //            str = str.Substring(0, i) + temp + str.Substring(j + 1, str.Length - j - 1);
                    //        else
                    //            str = str.Substring(0, i) + temp;
                    //    }
                    //    else
                    //        flag = -1;
                    //}
                    //if ((temp = generate4(str)) != "err")////?????
                    //    resualt += temp;
                    //else
                    //    return "err";
                    //flag = 1;
                }
            }

            if ((i = str.LastIndexOf('+')) != -1 && flag == 0)
            {
                flag = 1;
                left_str = str.Substring(0, i);
                right_str = str.Substring(i + 1, str.Length - i - 1);
                is_left = isWho(left_str);
                is_right = isWho(right_str);
                if (is_left == -1 || is_right == -1)
                    return "err";
                // новый метод
                if (is_left == 2 && is_right == 2)//поддереьвья и справа и слева
                {
                    if ((temp = generate4(right_str)) != "err")
                        resualt += temp;
                    else
                        return "err";
                    resualt += "push ax" + "^";
                    if ((temp = generate4(left_str)) != "err")
                        resualt += temp;
                    else
                        return "err";
                    resualt += "pop dx" + "^";
                    resualt += "add ax, dx" + "^";
                }
                else
                {
                    if (is_right == 2)//справа поддерево
                    {
                        if (is_left == 0 || is_left == 1)//индитф/конс слева
                        {
                            if ((temp = generate4(right_str)) != "err")//код справа
                                resualt += temp;
                            else
                                return "err";
                            temp = "add ax, " + left_str;
                            resualt += temp + "^";
                        }
                        else
                        {
                            if (is_left >= 3)//skb слева
                            {
                                if ((temp = generate4(right_str)) != "err")//код справа
                                    resualt += temp;
                                else
                                    return "err";
                                if ((temp = generate4(skb[is_left - 3])) != "err")//код справа
                                    resualt += temp;
                                else
                                    return "err";
                               // temp = skb[is_left - 3];
                                temp = "add ax, " + temp.Substring(8, temp.Length - 8);
                                resualt += temp + "^";
                            }
                            else
                                return "err";
                        }
                    }
                    else
                    {
                    }

                }
                   // конец нового метода


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
                                if ((temp = generate4(right_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                resualt += skb[is_right - 3];
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
                                if ((temp = generate4(left_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";

                            else
                                resualt += skb[is_left - 3];
                            temp = "add ax, " + right_str;
                            resualt += temp + "^";
                        }
                        else
                        {
                            if (is_right == 2 || is_right >= 3)
                            {
                                if (is_right < 3)
                                    if ((temp = generate4(right_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";

                                else
                                    resualt += skb[is_right - 3];
                                resualt += "push ax" + "^";
                                if (is_left < 3)
                                    if ((temp = generate4(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_left - 3];
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
                                if ((temp = generate4(right_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";

                            else
                                resualt += skb[is_right - 3];
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
                                if ((temp = generate4(left_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                resualt += skb[is_left - 3];
                            temp = "sub ax, " + right_str;
                            resualt += (temp) + "^";
                        }
                        else
                        {
                            if (is_right == 2 || is_right >= 3)
                            {
                                if (is_right < 3)
                                    if ((temp = generate4(right_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_right - 3];
                                resualt += ("push ax^");
                                if (is_left < 3)
                                    if ((temp = generate4(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_left - 3];
                                resualt += ("pop dx^");
                                resualt += ("sub ax, dx^");
                            }
                            else
                                return "err";
                        }
                    }
                }

            }
            if ((i = str.LastIndexOf('*')) != -1 && flag == 0)
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
                                if ((temp = generate4(right_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                resualt += skb[is_right - 3];
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
                                if ((temp = generate4(left_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                resualt += skb[is_left - 3];
                            temp = "mul ax, " + right_str;
                            resualt += (temp) + "^";
                        }
                        else
                        {
                            if (is_right == 2 || is_right >= 3)
                            {
                                if (is_right < 3)
                                    if ((temp = generate4(right_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_right - 3];
                                resualt += ("push ax^");
                                if (is_left < 3)
                                    if ((temp = generate4(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_left - 3];
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
                                if ((temp = generate4(right_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                resualt += skb[is_right - 3];
                            temp = "mov dx, " + left_str;
                            resualt += (temp) + "^";
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
                                if ((temp = generate4(left_str)) != "err")
                                    resualt += temp;
                                else
                                    return "err";
                            else
                                resualt += skb[is_left - 3];
                            temp = "div ax, " + right_str;
                            resualt += (temp) + "^";
                        }
                        else
                        {
                            if (is_right == 2 || is_right >= 3)
                            {
                                if (is_right < 3)
                                    if ((temp = generate4(right_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_right - 3];
                                resualt += ("push ax^");
                                if (is_left < 3)
                                    if ((temp = generate4(left_str)) != "err")
                                        resualt += temp;
                                    else
                                        return "err";
                                else
                                    resualt += skb[is_left - 3];
                                resualt += ("pop dx^");
                                resualt += ("div ax, dx^");
                            }
                        }
                    }
                }

            }
            if ((i = str.LastIndexOf('#')) != -1 && flag == 0)
            {
                if (i != 0)
                    return "err";
                int h = isWho(str.Substring(1, str.Length - 1));
                if (h == 1)
                {
                    return resualt += "mov ax, " + str.Substring(1, str.Length - 1) + "^neg ax^";

                }
                if (h == 2)
                {
                    temp = str.Substring(1, str.Length - 1);
                    if ((temp = generate4(temp)) != "err")
                        return resualt += temp + "neg ax^";
                    else
                        return "err";
                }
                if (h >= 3)
                {
                    temp = str.Substring(1, str.Length - 1);
                    //if ((temp = generate4(temp)) != "err")
                    return resualt += skb[h - 3] + "neg ax^";
                    //else
                    // return "err";
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

                    if (h >= 3)
                        resualt += skb[h - 3];
                    if (h == 0)
                    {
                        // resualt += "mov ax, " + str + "^";
                        return str;
                    }
                    if (h == 1)
                        return str;
                    //resualt += "mov ax, " + str + "^";
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
                  str = prisvoit(str); 
                if (str != "err")
                    {
                        Stack<string> res2 = new Stack<string>();
                        /* while (res.Count != 0)
                         {
                             res2.Push(res.Pop());
                         }
                         while (res2.Count != 0)
                         {
                             textBox2.AppendText(res2.Pop() + "\n");
                         }
                         res.Clear();*/
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
