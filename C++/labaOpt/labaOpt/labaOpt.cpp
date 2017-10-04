// labaOpt.cpp: определяет точку входа для консольного приложения.
//

//#include "stdafx.h"
#include <iostream>
#include <cmath>
#include <cstdio>
#include <fstream>
#include <vector>
#include <string>

using namespace std;


void LU(vector <vector <double> > A, vector <vector <double> > &L, //получение матриц L и U
        vector <vector <double> > &U, int n)
{
    U=A;
    for(int i = 0; i < n; i++)
        for(int j = i; j < n; j++)
            L[j][i]=U[j][i]/U[i][i];

    for(int k = 1; k < n; k++)
    {
        for(int i = k-1; i < n; i++)
            for(int j = i; j < n; j++)
                L[j][i]=U[j][i]/U[i][i];

        for(int i = k; i < n; i++)
            for(int j = k-1; j < n; j++)
                U[i][j]=U[i][j]-L[i][k-1]*U[k-1][j];
    }
/*    for (int i = 0; i < n; i++)
//              {
//                  for (int j = 0; j < n; j++)
//                  {
//                      U[0][i] = A[0][i];
//                      L[i][0] = A[i][0] / U[0][0];
//                      double sum = 0;
//                      for (int k = 0; k < i; k++)
//                      {
//                          sum += L[i][k] * U[k][j];
//                      }
//                      U[i][j] = A[i][j] - sum;
//                      if (i > j)
//                      {
//                          L[j][i] = 0;
//                      }
//                      else
//                      {
//                          sum = 0;
//                          for (int k = 0; k < i; k++)
//                          {
//                              sum += L[j][k] * U[k][i];
//                          }
//                          L[j][i] = (A[j][i] - sum) / U[i][i];
//                      }
//                  }
//              }
*/
}

void proisv(vector <vector <double> > A, vector <vector <double> > B, //проверка результата
            vector <vector <double> > &R, int n)
{
    for(int i = 0; i < n; i++)
        for(int j = 0; j < n; j++)
            for(int k = 0; k < n; k++)
                R[i][j] += A[i][k] * B[k][j];
}

void show(vector <vector <double> > A, int n)//вывод матрицы n*n
{
    for(int i = 0; i < n; i++)
    {
        for(int j = 0; j < n; j++)
        {
            cout <<"\t"<< A[i][j] << "\t";
        }
        cout << endl;
    }
}

void show_v(vector <double> b, int n)///вывод вектора на экран
{
    for(int j = 0; j < n; j++)
    {
        cout <<"\t"<< b[j] << endl;
    }

}


void read_f(vector <double> &b, vector <vector <double> > &A, int n)//считывание данных и запись в массивы
{
     ifstream fin("input.txt", ios_base::in);
     string str;
     double temp;
     while(fin>>str)
     {
         //getline(fin, str);
        // cout <<str<<endl;

         if(str == "E")
         {
             for (int i= 0; i < 3; i++)
                  {
                      fin >>temp;
                  }
             b[0] = temp;
         }
         else
         {
             if(str == "Rin")
             {
                 for (int i= 0; i < 3; i++)
                 {
                          fin >>temp;

                 }
                 A[0][0] += (1/temp);
                 b[0] *= (1/temp);
             }
             else
             {
                 int i, j;
                 fin >>i>>j>>temp;
                 temp = 1/temp;
                 if(i == 0)
                 {
                     j--;
                     A[j][j] += temp;
                 }
                 else
                 {
                    i--;
                    j--;
                    A[i][i] += temp;
                    A[j][j] += temp;
                    A[j][i] -= temp;
                    A[i][j] -= temp;
                 }


             }
         }

     }

     fin.close();
}

void read_f1(vector <double> &b, vector <vector <double> > &A, int n)//считывание данных и запись в массивы
{
     ifstream fin("input2.txt", ios_base::in);
     string str;
     double temp;
     while(fin>>str)
     {
         //getline(fin, str);
        // cout <<str<<endl;

         if(str == "E")
         {
             for (int i= 0; i < 3; i++)
                  {
                      fin >>temp;
                  }
             b[0] = temp;
         }
         else
         {
             if(str == "Rin")
             {
                 for (int i= 0; i < 3; i++)
                 {
                          fin >>temp;

                 }
                 A[0][0] += (1/temp);
                 b[0] *= (1/temp);
             }
             else
             {
                 int i, j;
                 fin >>i>>j>>temp;
				 if(temp != 0)
					temp = 1/temp;

                 if(i == 0)
                 {
                     j--;
                     A[j][j] += temp;
                 }
                 else
                 {
                    i--;
                    j--;
                    A[i][i] += temp;
                    A[j][j] += temp;
                    A[j][i] -= temp;
                    A[i][j] -= temp;
                 }


             }
         }

     }

     fin.close();
}
//чтение и создание матрицы производных
void read_f_proizv(vector <vector <double> > &A, int n, int num_el)
{
     ifstream fin("input.txt", ios_base::in);
     string str;
     double temp;
	 int t = 0;
     while(fin>>str)
     {
         //getline(fin, str);
        // cout <<str<<endl;

         if(str == "E")
         {
             for (int i= 0; i < 3; i++)
                  {
                      fin >>temp;
                  }
             
         }
         else
         {
             if(str == "Rin")
             {
                 for (int i= 0; i < 3; i++)
                 {
                          fin >>temp;

                 }
                 
             }
             else
             {
				 t++;
				 
                 int i, j;
                 fin >>i>>j>>temp;
                 temp = 1/temp;
                 if(i == 0)
                 {
                     j--;
					 if(t == num_el)
						A[j][j] = 1;
                 }
                 else
                 {
                    i--;
                    j--;
					if(t == num_el)
					{
						A[i][i] = 1;
						A[j][j] = 1;
						A[j][i] = -1;
						A[i][j] = -1;
					}
                 }


             }
         }

     }

     fin.close();
}


//получение y для LU разложения
void solve_y(vector <double> &y, vector <vector <double> > L, vector <double> b,  int n)
{
    y[0] = b[0]/L[0][0];
    for(int i = 1; i < n; i++)
    {
        double temp = 0;
        for (int j = 0; j < i; j++)
        {
            temp += y[j]*L[i][j];
        }
        y[i] = (b[i] - temp)/L[i][i];
    }
}

//полечения x для LU разложения
void solve_x(vector <double> &x, vector <vector <double> > U, vector <double> y,  int n)
{
    n--;
    x[n] = y[n]/U[n][n];
    for(int i = n-1; i >= 0; i--)
    {
        double temp = 0;
        for (int j = n; j > i; j--)
        {
            temp += x[j]*U[i][j];
        }
        x[i] = (y[i] - temp)/U[i][i];
    }
}


//перемножение матрицы на вектор
void umnogenie_m_v(vector <double> &res, vector <vector <double> > A, vector <double> b, int n)
{
	for(int i = 0; i < n; i++)
	{
		res[i] = 0;
		for(int j = 0; j < n; j++)
		{
			res[i] += A[i][j]*b[j];
		}
	}
}


///gradient
void gradient(double Uzad, double Uras, vector <vector <double> > R, int n)
{
	cout << " Gradient "<<endl;
	for(int i = 0; i < 5; i++)
	{
		cout << 2*(Uras - Uzad)*R[i][n-1] << endl;
	}
}

//gplden_sech
double function(double a_i, double b_i, double E, double Uzad)
{
    double x1, x2, q = 1.618, y1, y2;
	const int n = 3;
	while (abs(b_i - a_i) > E)
    {
        x1 = b_i- (b_i - a_i) / q;
        x2 = a_i + (b_i - a_i) / q;
		
		vector <vector <double> > A (n,0)/*проводимости*/, L (n,0), U(n,0);
		vector <double> y(n), Ux(n)/*напряжения*/, b(n);//источник
		for(int i = 0; i < n; i++) //заполнение нулями
		{
			for(int j = 0; j < n; j++)
			{
				A[i].push_back(0);
				L[i].push_back(0);
				U[i].push_back(0);
			}
			y.push_back(0);
			Ux.push_back(0);
			b.push_back(0);
		}


		read_f1(b,A,n);//чтение данных
		A[2][2] += x1;	//Y5 первый  
		LU(A,L,U,n); //получение L U
		solve_y(y,L,b,n);
		solve_x(Ux,U,y,n);

        y1 = (Ux[2] - Uzad)*(Ux[2] - Uzad);
		A[2][2] -= x1;
		A[2][2] += x2;
		LU(A,L,U,n); //получение L U
		solve_y(y,L,b,n);
		solve_x(Ux,U,y,n);
        y2 = (Ux[2] - Uzad)*(Ux[2] - Uzad);
        if (y1 >= y2)
        {
            a_i = x1;
            x1 = b_i - (b_i - a_i) / q;
            x2 = a_i + (b_i - a_i) / q;
        }
        else
        {
            b_i = x2;
            x1 = b_i - (b_i - a_i) / q;
            x2 = a_i + (b_i - a_i) / q;
        }
        q = (b_i - a_i) / (b_i - x1);
    }
    return (a_i + b_i) / 2;
}
//x^2
double function1(double a, double b, double E)
{
    double x1, x2, q = 1.68, y1, y2;
	while (abs(b - a) > E)
    {
        x1 = b - (b - a) / q;
        x2 = a + (b - a) / q;
        y1 = x1 * x1;
        y2 = x2 * x2;
        if (y1 >= y2)
        {
            a = x1;
            x1 = b - (b - a) / q;
            x2 = a + (b - a) / q;
        }
        else
        {
            b = x2;
            x1 = b - (b - a) / q;
            x2 = a + (b - a) / q;
        }
        q = (b - a) / (b - x1);
    }
    return (a + b) / 2;
}

int main()
{

 //   ofstream fout("output.txt");

    const int n=3;//размерность A матрицы AUx=b
    vector <vector <double> > A (n,0)/*проводимости*/, L (n,0), U(n,0), d_Ui(5,0), A_temp(n,0);
    vector <double> y(n), Ux(n)/*напряжения*/, b(n), x_temp(n), b_temp(n);//источник
    for(int i = 0; i < n; i++) //заполнение нулями
    {
        for(int j = 0; j < n; j++)
        {
            A[i].push_back(0);
            L[i].push_back(0);
            U[i].push_back(0);
            
			A_temp[i].push_back(0);
        }
        y.push_back(0);
        Ux.push_back(0);
        b.push_back(0);
		x_temp.push_back(0);
		b_temp.push_back(0);
    }


    read_f(b,A,n);//чтение данных

   cout << "A matrix" << endl;
   show(A,n);
   cout << "b vector" <<endl;
   show_v(b,n);
   LU(A,L,U,n); //получение L U
  /*  cout << "U matrix" << endl;
    show(U,n);
    cout << "L matrix" << endl;
    show(L,n);*/

    solve_y(y,L,b,n);
   // cout << "y vector" <<endl;
   // show_v(y,n);

    solve_x(Ux,U,y,n);
    cout << "Ux vector" <<endl;
    show_v(Ux,n);

    cout<<"Enter u3(Ux3)"<<endl;
    double u3;
    cin>>u3;
    cout<<"Func"<<endl<<(Ux[2]-u3)*(Ux[2]-u3)<<endl;
/*   proisv(L,U,R,n);
//    cout << "L*U matrix" << endl;
//    show(R,n);
//    fout.close();
        */

	///gradient
	//kol_el = 5
	for(int i = 0; i < 5; i++) //заполнение нулями
    {
		
		//clear
		for(int i1 = 0; i1 < n; i1++) //заполнение нулями
		{
			for(int j = 0; j < n; j++)
			{
				A_temp[i1][j] = 0;
			}
			b_temp[i1] = 0;
			x_temp[i1] = 0;
		}
		read_f_proizv(A_temp,n,i+1);//матрица производной
		umnogenie_m_v(b_temp,A_temp, Ux,n);
		for(int i1 = 0; i1 < n; i1++) //правый вектор
		{
				
			b_temp[i1] = -b_temp[i1];
		}		
		solve_y(y,L,b_temp,n);
		solve_x(x_temp,U,y,n);
		for(int i1 = 0; i1 < n; i1++) //запись в R
		{				
			d_Ui[i].push_back(x_temp[i1]);
		}
    }
	gradient(u3, Ux[n-1], d_Ui, n);

	//gessian
	vector <vector <double> > ges(5,0);
	 cout <<"Gessian func all\n";
	for(int i = 0; i < 5; i++) //заполнение нулями
    {
		
		for(int j = 0; j < 5; j++)
		{
			//clear
			
		    for(int i1 = 0; i1 < n; i1++) //заполнение нулями
			{
				for(int g = 0; g < n; g++)
				{
					A_temp[i1][g] = 0;
					
				}
				b_temp[i1] = 0;
				x_temp[i1] = 0;
			}

			read_f_proizv(A_temp,n,j+1);//матрица производной
			vector <double> b2_temp;
			for(int i1 = 0; i1 < n; i1++) //правый вектор
			{				
				b_temp[i1] = -d_Ui[i][i1];
				b2_temp.push_back(0);
			}			
			umnogenie_m_v(b2_temp,A_temp, b_temp,n);
			  for(int i1 = 0; i1 < n; i1++) //заполнение нулями
			{
				for(int g = 0; g < n; g++)
				{
					A_temp[i1][g] = 0;
					
				}
				
			}
			read_f_proizv(A_temp,n,i+1);//матрица производной
			vector <double> b3_temp;
			for(int i1 = 0; i1 < n; i1++) //правый вектор
			{				
				b_temp[i1] = -d_Ui[j][i1];
				b3_temp.push_back(0);
			}			
			umnogenie_m_v(b3_temp,A_temp, b_temp,n);
			for(int i1 = 0; i1 < n; i1++) //правый вектор
			{				
				b3_temp[i1] += b2_temp[i1];		
				//cout << b3_temp[i1]<< "\t";
			}	
			solve_y(y,L,b3_temp,n);
			solve_x(x_temp,U,y,n);
			
			for(int i1 = 0; i1 < n; i1++) //запись в R
			{		
				cout << x_temp[i1]<< "\t";				
			}
			cout<<endl;
			ges[i].push_back(x_temp[2]);
		}
		
    }
	cout << "Gessian\n";
	for(int i = 0; i < 5; i++) //output
    {		
		for(int j = 0; j < 5; j++)
		{
			cout << ges[i][j] << "\t";
		}
		cout <<endl;		
    }
	cout << "Gessian mod\n";
	for(int i = 0; i < 5; i++) //output
    {		
		for(int j = 0; j < 5; j++)
		{
			cout << 2*d_Ui[i][2]*d_Ui[j][2] + ges[i][j] << "\t";
		}
		cout <<endl;		
    }
	double a_inter, b_inter, eps;
	cout<<endl<<endl<<"Input a"<<endl;
	cin>>a_inter;
	cout<<"Input b"<<endl;
	cin >> b_inter;
	cout<<"Input eps"<<endl;
	cin>>eps;
	cout<<function(a_inter,b_inter,eps,u3)<<endl;
    return 0;
}

