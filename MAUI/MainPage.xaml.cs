using Solely_MAUI.Models;
using Solely_MAUI.Services;

namespace Solely_MAUI
{
    public partial class MainPage : ContentPage
    {
        public BrandService BrandService { get; set; }
        public List<Brand> BrandList { get; set; }


        public MainPage()
        {
            InitializeComponent();
            BrandService = new BrandService();
            BrandList = new List<Brand>();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            activityIndicator.IsRunning = true;
            BrandList = await BrandService.GetAllBrands();
            activityIndicator.IsRunning = false;
            if (BrandList != null)
            {
                booksdata.ItemsSource = BrandList.ToList();
            }
            booksdata.SelectedItem = null;
        }

        private void btnEditBrand_Clicked(object sender, EventArgs e)
        {

        }

        private void btnDeleteBrand_Clicked(object sender, EventArgs e)
        {

        }

        private void btnAddBrand_Clicked(object sender, EventArgs e)
        {

        }
    }

}
