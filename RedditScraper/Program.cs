using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;

namespace RedditScraper {
    class Program {
        static void Main(string[] args) {
            ScrapingBrowser Browser = new ScrapingBrowser();
            Browser.AllowAutoRedirect = true;
            Browser.AllowMetaRedirect = true;

            var cnt = 0;
            var url = @"https://old.reddit.com/r/chapotraphouse";
            IList<string> Posts = new List<string>();

            while (cnt < 100) {

                WebPage PageResult = Browser.NavigateToPage(new Uri(url));
                var Table = PageResult.Html.CssSelect("#siteTable").First();
                foreach (var row in Table.CssSelect("p.title")) {
                    foreach (var cell in row.SelectNodes("a")) {
                        Posts.Add(cell.InnerText);
                    }
                }

                var nextButton = Table.CssSelect("span.next-button").FirstOrDefault();
                if (nextButton == null) {
                    break;
                }
                url = nextButton.SelectSingleNode("a").Attributes[0].Value;
                cnt++;
            }

            var uniqueWords = new Dictionary<string, int>();

            foreach(var title in Posts) {
                foreach(var word in title.Split(" ")) {
                    var simpleWord = word.ToLower();
                    if (uniqueWords.ContainsKey(simpleWord)) {
                        uniqueWords[simpleWord]++;
                    } else {
                        uniqueWords.Add(simpleWord, 1);
                    }
                }
            }

            Console.WriteLine("The top 10 most common words on ChapoTrapHouse subreddit over the past 1000 posts:");
            var topWords = uniqueWords.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
            for (var i=0; i<=10; i++) {
                Console.WriteLine($"{i}: {topWords[i]}");
            }
            
            
        }
    }
}
