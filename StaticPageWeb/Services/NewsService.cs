using StaticPageWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaticPageWeb.Services
{
    public class NewsService
    {
        private List<News> _list;

        public NewsService()
        {
            _list = new List<News>();
            _list.Add(new News
            {
                Id = 1,
                Author = "小编1",
                ReleaseTime = new DateTime(1991, 1, 1, 13, 12, 31),
                Title = "新闻标题1",
                Content = "新闻内容1"
            });

            _list.Add(new News
            {
                Id = 2,
                Author = "小编2",
                ReleaseTime = new DateTime(2001, 2, 3, 13, 12, 31),
                Title = "新闻标题2",
                Content = "新闻内容2"
            });

            _list.Add(new News
            {
                Id = 3,
                Author = "小编3",
                ReleaseTime = new DateTime(2003, 2, 3, 13, 12, 31),
                Title = "新闻标题3",
                Content = "新闻内容3"
            });
        }

        public List<News> Get()
        {
            return _list;
        }
    }
}