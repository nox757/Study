#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QString>
#include <QMessageBox>

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

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
