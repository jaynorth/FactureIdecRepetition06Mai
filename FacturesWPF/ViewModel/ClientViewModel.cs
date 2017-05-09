using FactureIdecEntity;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FacturesWPF.ViewModel
{
    public class ClientViewModel: BaseViewModel
    {
        
        private FactureIdecEntities _entity;

        private ObservableCollection<Client> _listClients;

        public ObservableCollection<Client> ListClients
        {
            get { return _listClients; }
            set
            {
                _listClients = value;
                FirePropertyChanged();
            }
        }

        private Client _clientCourant;



        public Client ClientCourant
        {
            get { return _clientCourant; }
            set
            {
                _clientCourant = value;
                FirePropertyChanged();
            }
        }

        public RelayCommand Save { get; set; }

        public RelayCommand New { get; set; }
        public RelayCommand Delete { get; set; }

        public void Sauver()
        {
            foreach (Client c in ListClients)
            {
                if (c.New == true)
                    
                    _entity.Clients.Add(c);
                if (c.Del)
                    _entity.Clients.Remove(c);
            }
            _entity.SaveChanges();
            Init();
        }

        public void Nouveau()
        {
            ClientCourant = Client.GetNewClient();
            ListClients.Add(ClientCourant);
        }

        public void Supprimer()
        {
            ClientCourant.Del = true;
        }



        public ClientViewModel()
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
            this.ListClients = new ObservableCollection<Client>(_entity.Clients.OrderBy(a => a.Nom));
            this.ClientCourant = this.ListClients[0];
        }

    }
}

