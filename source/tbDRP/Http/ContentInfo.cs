using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tbDRP.Http
{
    /// <summary>
    /// ContentInfo 的摘要说明
    /// </summary>
    public class ContentInfo
    {
        private int id = 0;
        private string novel = "";
        private string type = "";
        private string title = "";
        private string url = "";
        private string parentUrl = "";
        private string key = "";
        private string description = "";
        private string content = "";
        private string imageList = "";
        private string time = "";
        private string author = "";
        private string borard = "";
        private string status = "";
        private string preview = "";
        private string source = "";
        private string last = "";
        private bool complete = false;
        private bool isParentSection = false;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Novel
        {
            get { return novel; }
            set { novel = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string ParentUrl
        {
            get { return parentUrl; }
            set { parentUrl = value; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public string ImageList
        {
            get { return imageList; }
            set { imageList = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Borard
        {
            get { return borard; }
            set { borard = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Preview
        {
            get { return preview; }
            set { preview = value; }
        }

        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        public string Last
        {
            get { return last; }
            set { last = value; }
        }

        public bool Complete
        {
            get { return complete; }
            set { complete = value; }
        }

        public bool IsParentSection
        {
            get { return isParentSection; }
            set { isParentSection = value; }
        }
    }
}
