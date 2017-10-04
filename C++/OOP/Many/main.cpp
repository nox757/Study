#include <iostream>
#include <cmath>
#include <string>
#include <map>
#include <vector>
#include <climits>


using namespace std;

long long Nod(long long a, long long b)//������� ���������� ���
{
    if(a < 0)
        a = -a;
    if(b < 0)
        b = -b;
    if(b == 0)
        return a;
    else
        return Nod(b, a % b);
}


bool toInt(string s, long long *a,long long *b)//��������� ����� � � b �� ������
{
    if(s.length() == 0)
    {
        return false;
    }

    int lpos = s.length() - 1, fpos = 0;//������� ��������� � ������ �����
    *a = 0;
    *b = 0;
    long long t = 0, p = 1;
    int flag = 0, sign = 1;
    if(s[0] == '(')//���� ����� � �������
    {
        if(s[lpos] == ')')
        {
            lpos--;
            fpos++;
            if(s[1] == '-')//���� ������������� �����
            {
                sign = -1;
                fpos++;
                if(s.length() == 3)
                    return false;
            }

        }
        else//��� ����������� ������
            return false;
    }
    if(s[0] == '-')
    {
        sign = -1;
        fpos++;
        if(s.length() == 1)
            return false;
    }
    for(int i = lpos; i >= fpos; i-- )
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
                if(p > 1E9 || flag != 0 || i == lpos || i == fpos)
                     return false;
                *b = t;
                t = 0;
                p = 1;
                flag = 2;
            }
            if(s[i] == '.')
            {
                if(p > 1E9 || flag != 0 || i == lpos || i == fpos)
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

    if(flag == 2 && p <= 1E9)//���� ��. �����
    {
        *a = t*sign;
        return true;

    }
    if(flag == 3 && p <= 1E9)//���� ���. �����
    {
        *a += t*(*b);
        *a = (*a)*sign;
        return true;
    }
    if(flag == 0 && p <= 1E9)// ������� �����
    {
        *a = t*sign;
        *b = 1;
        return true;
    }
    return false;
}



string stand_poly(string poly)//������� ���������� �������� ������ �����������
{
    string res, temp;//�������� ������ � �������
    int base[100][26]; // ���������
    string base0[100];// ��� ���������

    vector <long long> a, b;//���������� � ������� ���������/�����������

    long long c, d, g;
    char ch;

    int pos = -1, temp_pow = 0;//������� ��� ������������ �� ������
    int count_mono = 0;//������� ����������


    int i = 0, len_poly = poly.length(), j = -1;


    pos =  0;

    if(len_poly != 0)//���� ������ �� ������
    {
        count_mono++;
        for(int k  = 0; k < 26; k++ )
            base[count_mono-1][k] = 0;
        base0[count_mono - 1] = "00000000000000000000000000";
        if(poly[0] == '-')
        {
            if(len_poly == 1)
                return "#0. error one -";
            a.push_back(-1);
            b.push_back(1);
            i = 1;
            pos++;
        }
        else
        {

            a.push_back(1);
            b.push_back(1);
        }
    }
    else
    {
        return "#-1 empty";
    }
    for(i = i; i < len_poly; i++)
    {
            j = i;
            while(j < len_poly && poly[j] != '+' && poly[j] != '*' && (poly[j] != '-'  || poly[j-1] == '(') )
            {
                j++;
            }
            if(j == 0)//������ �� ������ ����� ��������� ������
                return "#0";
            if(j == len_poly-1)//�� ��������� ����� ��������� ����
                return "#0/1";

            ch = poly[pos];
            if((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))//���� ������ �����
            {
                if(pos+1 < len_poly && poly[pos+1] == '^')//���� �� ������ �������
                {
                    c = 0;
                    d = 0;
                    if(toInt(poly.substr(pos+2, j - pos - 2), &c, &d))
                    {

                        if(c >= 0 && d == 1)//���� ������� �����������
                        {
                            if(c != 0)
                            {
                                if(ch >= 'a' && ch <= 'z')
                                    temp_pow = ch - 'a';
                                else
                                    temp_pow = ch - 'A';
                                base0[count_mono - 1][temp_pow] = '1';
                                base[count_mono - 1][temp_pow] += c;
                            }
                        }
                        else
                            return "#1";

                    }
                    else
                        return "#2";
                }//��� ������� �� ������
                else
                {

                    if(pos + 1 < len_poly && poly[pos+1] != '*' && poly[pos+1] != '+' && poly[pos+1] != '-')
                        return "#2.1";
                    else//���� ������ ���� ����� �.� ������ �������
                    {
                        if(ch >= 'a' && ch <= 'z')
                            temp_pow = ch - 'a';
                        else
                            temp_pow = ch - 'A';
                        base0[count_mono -1][temp_pow] = '1';
                        base[count_mono - 1][temp_pow] += 1;
                    }
                }

            }
            else//�� �����, ������ �����- �� �����
            {
                c = 0;
                d = 0;
                if(toInt(poly.substr(pos, j - pos), &c, &d))//����� ����������
                {

                        a[count_mono - 1] *= c;
                        b[count_mono - 1] *= d;


                        g = Nod(a[count_mono - 1], b[count_mono - 1]);

                        a[count_mono - 1] /= g;
                        b[count_mono - 1] /= g;
                        if(a[count_mono - 1] > 1E9 ||  b[count_mono - 1] > 1E9)
                            return "#error bolshoy";


                }
                else//�� �����, ��� �� ���������� ������
                    return "#3";
            }


            if(j < len_poly)//���� �� ����� �� �����
            {

                if(poly[j] == '+')////���������� ������ ��� + � -!!!!!!!!!!!!!!!!!!!!!!!!!!!
                {
                    count_mono++;
                    for(int k  = 0; k < 26; k++ )
                        base[count_mono-1][k] = 0;
                    base0[count_mono - 1] = "00000000000000000000000000";
                    a.push_back(1);
                    b.push_back(1);


                }
                if(poly[j] == '-')
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
            }
            pos =  j + 1;
            i = j;

    }
    //����� ������ �������� ���������


    //����� ��������
    int flag[100];
    int temp_count = 0;
    for(i = 0 ; i < 100; i++)
        flag[i] = 0;
    for(i = 0; i < count_mono - 1; i++)
    {
        for(j = i + 1; j < count_mono; j++)
        {
            if(flag[j] == 0 && base0[i] == base0[j])//���� ������������� ���� � ���� �����
            {
                temp_count = 0;
                if(base0[i] != "00000000000000000000000000")
                {
                    for(int k = 0; k < 26; k++)
                    {
                        if(base[i][k] == base[j][k])
                        {
                            temp_count++;
                        }
                    }
                }
                else
                    temp_count = 26;
                if(temp_count == 26)
                {
                    flag[j] = 1;
                    a[i] = a[i]*b[j] + a[j]*b[i];
                    b[i] *= b[j];
                    g = Nod(a[i], b[i]);
                    a[i] /= g;
                    b[i] /= g;
                    if(a[i] > 1E9 || b[i] > 1E9)
                    {
                        return "#erro out of range";
                    }
                }
            }
        }
    }


    //������� � ��������� ���

    res = "";
    for(i = 0; i < count_mono; i++)
    {
        if(flag[i] == 0 && a[i] != 0)
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
    if(res == "")
        return "0";
    else
        return res;

}



int main()
{
    string poly;
    while(1)
    {
    cin >>poly;

    cout<<endl<<poly<<endl;

    poly = stand_poly(poly);
    cout<<poly<<endl;
    }

    return 0;
}

