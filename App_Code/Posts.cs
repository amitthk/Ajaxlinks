using System;
using System.Collections.Generic;
using System.Web;

namespace ajaxPostDemo
{
    public class Posts
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Inquiry;

        public string Inquiry
        {
            get { return _Inquiry; }
            set { _Inquiry = value; }
        }

        private DateTime _Timestamp;

        public DateTime Timestamp
        {
            get { return _Timestamp; }
            set { _Timestamp = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }


    }
}
