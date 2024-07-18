using System.Security.AccessControl;
//Iconfiguratin u denemek için burasını oluşturdum kafa karıştırmasın
namespace LibraryMVC.Service
{
    public class BookService
    {
        //_configuratin sayesinde appsetting.json dosasının içini okuyoruz
        private readonly IConfiguration _configuration;

            //interface implement ettiğimiz için ctor unu oluşturduk
        public BookService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //appsettings.json  dosyasının içini bu şekilde okyabiliyoruz.
        //appsettings dosyasını oku CloudServices i bul aldında Connection a bak ve GetValue yi kullanarak bool tipinde bir değer döndür
        public BookService()
        {
            if (_configuration.GetValue /*değerleri getirmesi için kullanılan methot*/ <bool /*geriye döndürülecke değerin tipi*/>("CloudServices:Conneciton")) ;
        }
    }
}
