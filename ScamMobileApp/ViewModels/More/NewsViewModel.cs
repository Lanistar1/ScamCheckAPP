using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Others;
using ScamMobileApp.Models.Popup;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Home;
using ScamMobileApp.Views.Identity;
using ScamMobileApp.Views.More;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScamMobileApp.ViewModels.More
{
    public class NewsViewModel : BaseViewModel
    {
        
        public  NewsViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _tsk = FetchNews();

            SelectPageCommand = new Command(async () => await SelectPageCommandExecute());

            TappedCommand = new Command<Article>(async (model) => await GetTappedExecute(model));


        }

        #region Bindings
        private string emptyPlaceholder = "Fetching Unwanted Keywords...";
        public string EmptyPlaceholder
        {
            get => emptyPlaceholder;
            set
            {
                emptyPlaceholder = value;
                OnPropertyChanged(nameof(EmptyPlaceholder));
            }
        }

        private List<Article> news;
        public List<Article> News
        {
            get => news;
            set
            {
                news = value;
                OnPropertyChanged(nameof(News));
            }
        }


        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private ObservableCollection<Article> SelectedItems = new ObservableCollection<Article>();

        #endregion


        #region commands
        public Command SelectPageCommand { get; }
        public Command TappedCommand { get; }


        #endregion

        private async Task SelectPageCommandExecute()
        {
            List<SelectItemModel> responseToLightTypes = new List<SelectItemModel>()
            {
                new SelectItemModel(1,"Australia"),
                new SelectItemModel(2,"Argentina"),
                new SelectItemModel(3,"Austria"),
                new SelectItemModel(4,"Belgium"),
                new SelectItemModel(5,"Brazil"),
                new SelectItemModel(6,"Bulgaria"),
                new SelectItemModel(7,"Canada"),
                new SelectItemModel(8,"China"),
                new SelectItemModel(9,"Croatia"),
                new SelectItemModel(10,"Czech Republic"),
                new SelectItemModel(11,"Denmark"),
                new SelectItemModel(12,"Egypt"),
                new SelectItemModel(13,"Estonia"),
                new SelectItemModel(14,"Finland"),
                new SelectItemModel(15,"France"),
                new SelectItemModel(16,"Germany"),
                new SelectItemModel(17,"Greece"),
                new SelectItemModel(18,"Hungary"),
                new SelectItemModel(19,"India"),
                new SelectItemModel(20,"Indonesia"),
                new SelectItemModel(21,"Ireland"),
                new SelectItemModel(22,"Israel"),
                new SelectItemModel(23,"Italy"),
                new SelectItemModel(24,"Japan"),
                new SelectItemModel(25,"Latvia"),
                new SelectItemModel(26,"Lithuania"),
                new SelectItemModel(27,"Malaysia"),
                new SelectItemModel(28,"Mauritius"),
                new SelectItemModel(29,"Mexico"),
                new SelectItemModel(30,"Netherland"),
                new SelectItemModel(31,"New Zealand"),
                new SelectItemModel(32,"Norway"),
                new SelectItemModel(33,"Pakistan"),
                new SelectItemModel(34,"Philippines"),
                new SelectItemModel(35,"Poland"),
                new SelectItemModel(36,"Portugal"),
                new SelectItemModel(37,"Romania"),
                new SelectItemModel(38,"Saudi Arabia"),
                new SelectItemModel(39,"Serbia"),
                new SelectItemModel(40,"Singapore"),
                new SelectItemModel(41,"Slovakia"),
                new SelectItemModel(42,"Slovenia"),
                new SelectItemModel(43,"South Africa"),
                new SelectItemModel(44,"South Korea"),
                new SelectItemModel(45,"Spain"),
                new SelectItemModel(46,"Sri Lanka"),
                new SelectItemModel(47,"Sweden"),
                new SelectItemModel(48,"Switzerland"),
                new SelectItemModel(49,"Thailand"),
                new SelectItemModel(50,"Turkey"),
                new SelectItemModel(51,"Ukraine"),
                new SelectItemModel(52,"United Arab Emirate"),
                new SelectItemModel(53,"United Kingdom"),
                new SelectItemModel(54,"United State of America"),

            };
            var popup = new SelectItemPickerPopup(responseToLightTypes);

            await PopupNavigation.Instance.PushAsync(popup);

            var result = await popup.PopupClosedTask;
            Title = result.Item1;
        }

        private async Task GetTappedExecute(Article model)
        {
            try
            {
                var mod = model;

                model.isSelected = model.isSelected ? false : true;
                if (SelectedItems.Count > 0)
                {
                    SelectedItems.Clear();
                }
                SelectedItems.Add(model);

                var testUrl = SelectedItems.FirstOrDefault().url;

                await Navigation.PushAsync(new NewsWebview(testUrl), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public async Task FetchNews()
        {
            try
            {
                await LoadingPopup.Instance.Show("Fetching News...");

                var (ResponseData, ErrorData, StatusCode) = await _scamAppService.GetNewsAsync();
                if (ResponseData != null)
                {

                    if (ResponseData.data != null)
                    {

                        News = ResponseData.data.articles;

                    }
                    else
                    {
                        await MessagePopup.Instance.Show(ErrorData.message);
                        EmptyPlaceholder = "No News found.";

                    }
                }
                else if (ErrorData != null && StatusCode == 401)
                {
                    Application.Current.MainPage = new NavigationPage(new Login());
                }
                else if (ErrorData != null)
                {
                    string message = "Error fetching News. Try again later.";
                    await MessagePopup.Instance.Show(
                        message: message);

                }
                else
                {
                    await MessagePopup.Instance.Show(ErrorData.message);
                }
            }
            catch (Exception ex)
            {
                string message = "Something went wrong. Try again later. ";
                await MessagePopup.Instance.Show(
                    message: message);
                Console.WriteLine(ex);
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }

        }
    }
}
