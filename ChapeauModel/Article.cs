using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Article
    {
        public int articleId { get; set; }
        public string name { get; set; }
        public string category { get; set; } //this can be an enum
        public int stock { get; set; }
    }
}
