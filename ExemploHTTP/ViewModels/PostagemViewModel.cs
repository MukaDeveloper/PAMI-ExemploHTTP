using CommunityToolkit.Mvvm.ComponentModel;
using ExemploHTTP.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ExemploHTTP.ViewModels
{
    public partial class PostagemViewModel : ObservableObject
    {
        private readonly RestService _restService;

        public PostagemViewModel()
        {
            _restService = new RestService();
            ListarAsyncCommand = new Command(async () => await ListarPostagens());
        }

        private ObservableCollection<Postagem> _postagens = new ObservableCollection<Postagem>();
        public ObservableCollection<Postagem> Postagens
        {
            get { return _postagens; }
            set { _postagens = value; }
        }

        public ICommand ListarAsyncCommand { get; }

        public async Task ListarPostagens()
        {
            Postagens = await _restService.GetPostagensAsync();
        }
    }
}
