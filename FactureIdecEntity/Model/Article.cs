using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactureIdecEntity
{
    public partial class Article
    {

        public static Article GetNewArticle()
        {
            Article a = new Article();
            a.Del = false;
            a.Id = -1;
            return a;
        }

        public bool Del { get; set; }
    }
}
