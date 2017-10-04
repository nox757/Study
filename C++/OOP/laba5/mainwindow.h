#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QMessageBox>
#include <QString>
#include <fstream>
#include "Message.h"
#include "templ.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    
private slots:
    void on_button_add_clicked();

    void on_button_clear_clicked();

    void on_button_addhead_clicked();

    void on_button_view_clicked();

    void on_button_del_clicked();

    void on_button_add_4_clicked();

    void on_button_addhead_4_clicked();

    void on_pushButton_clicked();

private:
    Ui::MainWindow *ui;
};

template <class N1, class N2>N1 summa(N1 const &a, N2 const &b)//шаблон функции сложения объектов классов
{
    N1 c;
    c = a + b;
    return c;
}




#endif // MAINWINDOW_H
