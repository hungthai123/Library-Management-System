
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace Library
{
    public class Books
    {
        private string title;
        private string author;
        private string category;
        private string year;
        private string url;
        private string description;
        private string returndate;
        private string status;


        public Books() { }

        public Books(string title, string author, string category, string year, string url, string description,string returndate,string status)
        {
            this.title = title;
            this.author = author;
            this.category = category;
            this.year = year;
            this.returndate = returndate;
            this.url = url;
            this.description = description;
            this.status = status;
        }
        

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Status { 
            get { return status; }
            set { status = value; }
        }
        public string ReturnDate {
            get { return returndate; }
            set { returndate = value; }
        }
    }
}