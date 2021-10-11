namespace MinhLam.XemPhim.Application.Web.ViewModels
{
    public class CountryMenuViewModel
    {
        public CountryMenuViewModel(int countryId, string name)
        {
            CountryId = countryId;
            Name = name;
        }

        public CountryMenuViewModel()
        {
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
