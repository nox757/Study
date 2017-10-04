#include "Message.h"


Message::Message()
{
    text = "";
    user = "";
    prev = NULL;
    next = NULL;
}


bool Message::set_text(QString s)
{
    if (s == "" || s.length() > 50)
        return false;
    else
    {
        text = s;
        return true;
    }

}


bool Message::set_user(QString s)
{
    if (s == "" || s.length() > 50)
        return false;
    else
    {
        user = s;
        return true;
    }
}

QString Message::get_text() const
{
    return text;
}

QString Message::get_user() const
{
    return user;
}

