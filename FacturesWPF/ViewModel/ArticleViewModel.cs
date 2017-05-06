using FactureIdecEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturesWPF.ViewModel
{
    class ArticleViewModel
    {
        private FactureIdecEntities _entity;

        private List<Article> _listArticle;

        public List<Article> ListArticles
        {
            get { return _listArticle; }
            set { _listArticle = value; }
        }

        private Article _articleCourant;

        public Article ArticleCourant
        {
            get { return _articleCourant; }
            set { _articleCourant = value; }
        }

        public ArticleViewModel()
        {
            _entity = new FactureIdecEntities();
            this._listArticle = new List<Article>(_entity.Articles.OrderBy(a => a.Nom));
            this._articleCourant = this.ListArticles[0];
        }


    }
}
