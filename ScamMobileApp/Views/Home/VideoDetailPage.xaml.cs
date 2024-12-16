using ScamMobileApp.Models.Feedback;
using ScamMobileApp.Models.Others;
using ScamMobileApp.ViewModels.FeedBack;
using ScamMobileApp.ViewModels.Others;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScamMobileApp.Views.Home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoDetailPage : ContentPage
	{
		public VideoDetailPage (ObservableCollection<VideoModel> selectedItems)
		{
			InitializeComponent ();
            BindingContext = new VideoListDetailViewModel(Navigation, selectedItems);

        }

        private void OnMediaOpened(object sender, EventArgs e)
        {
            if (BindingContext is VideoListDetailViewModel viewModel)
            {
                viewModel.IsLoading = false; // Hide the loader
            }
        }
    }
}