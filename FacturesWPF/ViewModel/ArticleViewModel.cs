using FactureIdecEntity;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Linq;

namespace FacturesWPF.ViewModel
{
    public class ArticleViewModel: BaseViewModel
    {
        private FactureIdecEntities _entity;

        private ObservableCollection<Article> _listArticle;

        public ObservableCollection<Article> ListArticles
        {
            get { return _listArticle; }
            set { _listArticle = value; 
            FirePropertyChanged();
            }
        }

        private Article _articleCourant;



        public Article ArticleCourant
        {
            get { return _articleCourant; }
            set { _articleCourant = value;
                FirePropertyChanged();
            }
        }

        public RelayCommand Save { get; set; }

        public RelayCommand New { get; set; }
        public RelayCommand Delete { get; set; }

        public void Sauver()
        {
            foreach (Article a in ListArticles)
            {
                if (a.Id == -1)
                    _entity.Articles.Add(a);
                if (a.Del)
                    _entity.Articles.Remove(a);
            }
            _entity.SaveChanges();
            Init();
        }

        public void Nouveau()
        {
            ArticleCourant = Article.GetNewArticle();
            ListArticles.Add(ArticleCourant);
        }

        public void Supprimer()
        {
            ArticleCourant.Del = true;
        }



        public ArticleViewModel()
        {
            _entity = new FactureIdecEntities();
            Init();
            //this._listArticle = new ObservableCollection<Article>(_entity.Articles.OrderBy(a => a.Nom));
            //this._articleCourant = this.ListArticles[0];
            this.Save = new RelayCommand(Sauver);
            this.New = new RelayCommand(Nouveau);
            this.Delete = new RelayCommand(Supprimer);
        }

        private void Init()
        {
            this.ListArticles = new ObservableCollection<Article>(_entity.Articles.OrderBy(a => a.Nom));
            this.ArticleCourant = this.ListArticles[0];
        }

    }
}
