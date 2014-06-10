using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tbDRP.Http
{
    public class ConditionInfo
    {
        private int id = 0;
        private string site = "";
        private string name = "";
        private string description = "";
        private int boardId = 0;
        private string charSet = "";
        private string mainPageUrl = "";
        private string startTitle = "";
        private string endTitle = "";
        private string condition = "";
        private string startContent = "";
        private string endContent = "";
        private bool keyInclude = false;
        private bool descriptionInclude = false;
        private bool imgInclude = false;
        private bool bImgSaveLocal = false;

        public ConditionInfo()
        {
        }

        public ConditionInfo(int id)
        {
            this.id = id;
        }

        public int Id
        {
            get { return id; }
        }

        public string Site
        {
            get { return site; }
            set { site = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int BoardId
        {
            get { return boardId; }
            set { boardId = value; }
        }

        public string CharSet
        {
            get { return charSet; }
            set { charSet = value; }
        }

        public string MainPageUrl
        {
            get { return mainPageUrl; }
            set { mainPageUrl = value; }
        }

        public string StartTitle
        {
            get { return startTitle; }
            set { startTitle = value; }
        }

        public string EndTitle
        {
            get { return endTitle; }
            set { endTitle = value; }
        }

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        public string StartContent
        {
            get { return startContent; }
            set { startContent = value; }
        }

        public string EndContent
        {
            get { return endContent; }
            set { endContent = value; }
        }

        public bool KeyInclude
        {
            get { return keyInclude; }
            set { keyInclude = value; }
        }

        public bool DescriptionInclude
        {
            get { return descriptionInclude; }
            set { descriptionInclude = value; }
        }

        public bool ImgInclude
        {
            get { return imgInclude; }
            set { imgInclude = value; }
        }

        public bool ImgSaveLocal
        {
            get { return bImgSaveLocal; }
            set { bImgSaveLocal = value; }
        }
    }
}
