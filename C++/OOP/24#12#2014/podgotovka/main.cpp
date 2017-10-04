#include <iostream>
using namespace std;
class Date
{
 int mo, da, yr;
public:
 Date(int m, int d, int y) { mo = m; da = d; yr = y; }
 friend ostream& operator<<(ostream& os, const Date& dt)
 {
os << dt.mo << '/' << dt.da << '/' << dt.yr;
 return os;
 }
 friend istream& operator>>(istream& os,  Date& dt)
 {
    os >> dt.mo >>  dt.da >>  dt.yr;

    return os;
 }
};


int main()
{
    Date dt(2,10,2014);

    cout<<"Date"<<dt<<endl;
    cin>>dt;
     cout<<"Date"<<dt<<endl;
    return 0;
}
