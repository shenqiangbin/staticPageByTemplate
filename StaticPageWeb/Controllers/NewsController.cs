using StaticPageWeb.Models;
using StaticPageWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaticPageWeb.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            NewsService service = new NewsService();
            List<News> news = service.Get();

            return View(news);
        }

        public ActionResult BuildStaticFiles()
        {
            NewsService service = new NewsService();
            List<News> news = service.Get();

            string newsTemplateFileContent = GetNewsTemplate();
            foreach (var item in news)
            {
                string replacedContent = ReplaceTemplateFileByNewsModel(newsTemplateFileContent, item);
                SaveStaticFile(replacedContent,item);
            }

            return Content("静态文件生成完成");
        }

        private string GetNewsTemplate()
        {
            string templateFile = Server.MapPath("~/Templates/NewsTemplate.html");
            return System.IO.File.ReadAllText(templateFile);
        }

        private string ReplaceTemplateFileByNewsModel(string newsTemplateFileContent, News item)
        {
            return
                newsTemplateFileContent.
                Replace("@title", item.Title)
                .Replace("@author", item.Author)
                .Replace("@releaseTime", item.ReleaseTime.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("@content", item.Content);
        }


        private void SaveStaticFile(string replacedContent, News model)
        {
            string directoryPath = Server.MapPath("~/Statics/News");
            System.IO.Directory.CreateDirectory(directoryPath);

            string filePath = $"{directoryPath}/{model.Id}.html";
            System.IO.File.WriteAllText(filePath, replacedContent);
        }

       
    }
}