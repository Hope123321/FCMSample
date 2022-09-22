using FCMSample.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FCMSample.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}