#include <iostream>
#include <cmath>
#include <string>
#include <map>
#include <vector>
#include <sstream>


using namespace std;

long long Nod(long long a, long long b)//функция нахождение НОД
{
    if(b == 0)
        return a;
    else
        return Nod(b, a % b);
}


bool toInt(string s, long long *a,long long *b)//Получение числе а и b из строки
{
    int len = s.length();
    *a = 0;
    *b = 0;
    long long t = 0, p = 1;
    int flag = 0, sign = 1;
    if(s[0] == '(')
    {
        if(s[len - 1] == ')')
        {

            if(s[1] == '-')
            {
                sign = -1;
                len--;
            }
            else
                return false;
        }
        else
            return false;
    }
    for(int i = len - 1; i >= -sign + 1; i-- )
    {

        if(s[i] >= '0' && s[i] <= '9')
        {
            t += (int(s[i]) - int('0')) * p;
            p *= 10;

        }
        else
        {
            if(s[i] == '/')
            {
                if(flag != 0)
                     return false;
                *b = t;
                t = 0;
                p = 1;
                flag = 2;
            }
            if(s[i] == '.')
            {
                if(flag != 0)
                     return false;
                *a = t;
                *b = p;
                t = 0;
                p = 1;
                flag = 3;
            }
            if(flag == 0)
                return false;
        }

    }
    if(flag == 2)//если об. дробь
    {
        *a = t*sign;
        return true;

    }
    if(flag == 3)//если дес. дробь
    {
        *a += t*(*b);
        *a *= (*a)*sign;
        return true;
    }
    if(flag == 0)// обычное число
    {
        *a = t*sign;
        *b = 1;
        return true;
    }
    return false;
}



string stand_poly(string poly)//функция приведения подобных членов многочлелна
{
    string res, mono, temp;//исходная строка с полином
    int base[100][26]; // основание
    string base0[100];// код основания

    vector <long long> a, b;//коэфиценты в формате числитель/знаменатель

    long long c, d, g;
    char ch, ch1;

    int fpos = -1, lpos = -1, temp_pow = 0;//каретки для передвижения по строке
    int count_mono = 0;//счетчик моночленов


    int i = 0, len_poly = poly.length(), j = -1;


    fpos =  0;
    lpos = 0;
    if(len_poly != 0)//если строка не пустая
    {
        count_mono++;
        for(int k  = 0; k < 26; k++ )
            base[count_mono-1][k] = 0;
        base0[count_mono - 1] = "00000000000000000000000000";
        a.push_back(1);
        b.push_back(1);
    }
    for(i = 0; i < len_poly; i++)
    {
            j = i;
            while(j < len_poly && poly[j] != '+' && poly[j] != '*' && poly[j] != '-')
            {
                j++;
            }
            ch = poly[fpos];


            if((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))//если первая буква
            {
                if(poly[fpos+1] == '^')//если за буквой степень
                {
                    c = 0;
                    d = 0;
                    if(toInt(poly.substr(fpos+2, j - fpos - 2), &c, &d))
                    {
                        if(c >= 0 && d == 1)//если степень натуральная
                        {
                            if(ch >= 'a' && ch <= 'z')
                                temp_pow = ch - 'a';
                            else
                                temp_pow = ch - 'A';
                            base0[count_mono - 1][temp_pow] = '1';
                            base[count_mono - 1][temp_pow] += c;
                        }
                        else
                            return "#1";

                    }
                    else
                        return "#2";
                }//нет степени за буквой
                else
                {
                    ch1 = poly[fpos + 1];
                    if(ch1 != '*' && ch1 != '+' && ch1 != '-')
                        return NULL;
                    else//если просто одна буква т.е первая степень
                    {
                        if(ch >= 'a' && ch <= 'z')
                            temp_pow = ch - 'a';
                        else
                            temp_pow = ch - 'A';
                        base0[temp_pow] = '1';
                        base[count_mono - 1][temp_pow] += 1;
                    }
                }

            }
            else//не буква, значит какое- то число
            {
                c = 0;
                d = 0;
                if(toInt(poly.substr(fpos, j - fpos), &c, &d))//число перевелось
                {

                    if(c < 0)
                       g = Nod(-c,d);
                    else
                       g = Nod(c,d);
                    a[count_mono - 1] *= (c / g);
                    b[count_mono - 1] *= (d /g);
                    g = Nod(a[count_mono - 1], b[count_mono - 1]);
                    a[count_mono - 1] /= g;
                    b[count_mono - 1] /= g;
                }
                else//не число, или не правильный формат
                    return "#3";
            }


            if(j == len_poly)//если дошил до конца
            {
/*                ch = poly[fpos];
//                if((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))//если первая буква
//                {
//                    if(poly[fpos+1] == '^')//если за буквой степень
//                    {
//                        c = 0;
//                        d = 0;
//                        if(toInt(poly.substr(fpos+2, j - fpos - 2), &c, &d))
//                        {
//                            if(c >= 0 && d == 1)//если степень натуральная
//                            {
//                                if(ch >= 'a' && ch <= 'z')
//                                    temp_pow = ch - 'a';
//                                else
//                                    temp_pow = ch - 'A';
//                                base0[count_mono -1][temp_pow] = '1';
//                                base[count_mono - 1][temp_pow] += c;
//                            }
//                            else
//                                return NULL;

//                        }
//                        else
//                            return NULL;
//                    }//нет степени за буквой
//                    else
//                    {
//                        ch1 = poly[fpos + 1];
//                        if(ch1 != '*' && ch1 != '+' && ch1 != '-')
//                            return NULL;
//                        else//если просто одна буква т.е первая степень
//                        {
//                            if(ch >= 'a' && ch <= 'z')
//                                temp_pow = ch - 'a';
//                            else
//                                temp_pow = ch - 'A';
//                            base0[temp_pow] = '1';
//                            base[count_mono - 1][temp_pow] += 1;
//                        }
//                    }

//                }
//                else//не буква, значит какое- то число
//                {
//                    c = 0;
//                    d = 0;
//                    if(toInt(poly.substr(fpos, j - fpos), &c, &d))//число перевелось
//                    {

//                        if(c < 0)
//                           g = Nod(-c,d);
//                        else
//                           g = Nod(c,d);
//                        a[count_mono - 1] *= (c / g);
//                        b[count_mono - 1] *= (d /g);
//                        g = Nod(a[count_mono - 1], b[count_mono - 1]);
//                        a[count_mono - 1] /= g;
//                        b[count_mono - 1] /= g;
//                    }
//                    else//не число, или не правильный формат
//                        return NULL;
//                }
*/
                fpos =  j + 1;
                i = j;
                break;

            }

            if(poly[j] == '+')////доработать ошибки при + и -
            {
                count_mono++;
                for(int k  = 0; k < 26; k++ )
                    base[count_mono-1][k] = 0;
                base0[count_mono - 1] = "00000000000000000000000000";
                a.push_back(1);
                b.push_back(1);

                fpos = j + 1;
                i = j;
            }
            if(poly[j] == '-')
            {
                if(j != 0)
                {
                    if(poly[j - 1] != '(')
                    {
                        count_mono++;
                        for(int k  = 0; k < 26; k++ )
                            base[count_mono-1][k] = 0;
                        base0[count_mono - 1] = "00000000000000000000000000";
                        a.push_back(-1);
                        b.push_back(1);
                    }
                }
                else
                {
                    a[count_mono - 1] = -1;
                }


                fpos = j + 1;
                i = j;

            }


            if(poly[j] == '*')
            {

/*                if((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))//если первая буква
//                {
//                    if(poly[fpos+1] == '^')//если за буквой степень
//                    {
//                        c = 0;
//                        d = 0;
//                        if(toInt(poly.substr(fpos+2, j - fpos - 2), &c, &d))
//                        {
//                            if(c >= 0 && d == 1)//если степень натуральная
//                            {
//                                if(ch >= 'a' && ch <= 'z')
//                                    temp_pow = ch - 'a';
//                                else
//                                    temp_pow = ch - 'A';
//                                base0[temp_pow] = '1';
//                                base[count_mono - 1][temp_pow] += c;
//                            }
//                            else
//                                return NULL;

//                        }
//                        else
//                            return NULL;
//                    }//нет степени за буквой
//                    else
//                    {
//                        ch1 = poly[fpos + 1];
//                        if(ch1 != '*' && ch1 != '+' && ch1 != '-')
//                            return NULL;
//                        else//если просто одна буква т.е первая степень
//                        {
//                            if(ch >= 'a' && ch <= 'z')
//                                temp_pow = ch - 'a';
//                            else
//                                temp_pow = ch - 'A';
//                            base0[temp_pow] = '1';
//                            base[count_mono - 1][temp_pow] += 1;
//                        }
//                    }

//                }
//                else//не буква, значит какое- то число
//                {
//                    c = 0;
//                    d = 0;
//                    if(toInt(poly.substr(fpos, j - fpos), &c, &d))//число перевелось
//                    {

//                        if(c < 0)
//                           g = Nod(-c,d);
//                        else
//                           g = Nod(c,d);
//                        a[count_mono - 1] *= (c / g);
//                        b[count_mono - 1] *= (d /g);
//                        g = Nod(a[count_mono - 1], b[count_mono - 1]);
//                        a[count_mono - 1] /= g;
//                        b[count_mono - 1] /= g;
//                    }
//                    else//не число, или не правильный формат
//                        return NULL;
//                }
*/
                fpos =  j + 1;
                i = j;
            }
    }
    //конец записи полинома структуры


    //поиск подобных
    int flag[100];
    for(i = 0 ; i < 100; i++)
        flag[i] = 0;
    for(i = 0; i < count_mono - 1; i++)
    {
        for(j = i + 1; j < count_mono; j++)
        {
            if(flag[j] == 0 && base0[i] == base0[j])
            {
                flag[j] = 1;
                a[i] = a[i]*b[j] + a[j]*b[i];
                b[i] *= b[j];
                g = Nod(a[i], b[i]);
                a[i] /= g;
                b[i] /= g;
            }
        }
    }


    //перевод в строковый вид

    res = "";
    for(i = 0; i < count_mono; i++)
    {
        if(flag[i] == 0)
        {
            if(b[i] == 1)
            {
                if(a[i] < 0)
                    res += "-" + to_string(-a[i]);
                else
                {
                    if(res != "")
                        res += "+";
                    res += to_string(a[i]);
                }
            }
            else
            {
                if(a[i] < 0)
                    res += "-" + to_string(-a[i]) +"/"+ to_string(b[i]);
                else
                {
                    if(res != "")
                        res += "+";
                    res += to_string(a[i]) + "/"+ to_string(b[i]);
                }
            }
            for(j = 0; j < 26; j++)
            {

                if(base[i][j] != 0)
                {
                    res += '*'   ;
                    res += char(int('a') + j);
                    res += '^';
                    char buff[25];
                    itoa(base[i][j], buff,10);
                    temp = buff;
                    res += temp;
                }
            }
        }
    }
    return res;

}



int main()
{
    string poly, mono, temp;//исходная строка с полином
    int base[100][26]; // основание
    vector <long long> a, b;//коэфиценты в формате числитель/знаменатель


    int fpos = -1, lpos = -1;//каретки для передвижения по строке
    int count_mono = 0;//счетчик моночленов
    cin >>poly;

    cout<<endl<<poly<<endl;

    poly = stand_poly(poly);
   cout<<poly<<endl;










    return 0;
}

