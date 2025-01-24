using Newtonsoft.Json;
using ScamMobileApp.Helpers;
using ScamMobileApp.Models.Others;
using ScamMobileApp.Popup;
using ScamMobileApp.Utils;
using ScamMobileApp.Views.Identity;
using System;
using System.Collections.Generic;
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
        #endregion

        //private async Task FetchNews()
        //{
        //    try
        //    {
        //        await LoadingPopup.Instance.Show("Fetching News...");

        //        var (ResponseData, ErrorData, StatusCode) = await _scamAppService.GetNewsAsync();
        //        if (ResponseData != null)
        //        {
        //            if (ResponseData.articles != null)
        //            {
        //                //UnwantedKeywords = ResponseData.data.keyword;

        //                var test = ResponseData.articles;
        //                News = test;

        //            }
        //            else
        //            {
        //                await MessagePopup.Instance.Show(ErrorData.message);
        //                EmptyPlaceholder = "No Keyword found.";

        //            }
        //        }
        //        else if (ErrorData != null && StatusCode == 401)
        //        {
        //            Application.Current.MainPage = new NavigationPage(new Login());
        //        }
        //        else if (ErrorData != null)
        //        {
        //            string message = "Error fetching News. Do you want to RETRY?";
        //            await MessagePopup.Instance.Show(
        //                message: message);

        //        }
        //        else
        //        {
        //            await MessagePopup.Instance.Show(ErrorData.message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = "Something went wrong. Try again later. ";
        //        await MessagePopup.Instance.Show(
        //            message: message);
        //        Console.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        await LoadingPopup.Instance.Hide();
        //    }
        //}


        public async Task FetchNews()
        {
            try
            {

                await LoadingPopup.Instance.Show("Fetching News...");

                HttpClient client = new HttpClient();

                string url = "https://newsapi.org/v2/top-headlines?country=us";

                // Add the API key in the Authorization header
                client.DefaultRequestHeaders.Add("Authorization", "Bearer aae4b3c2c26042a9b4d5ad99afafe4c5");


                HttpResponseMessage response = await client.GetAsync(url);

                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<NewsModel>(result);
                    Console.WriteLine("passedjiojiojiojio");


                    var latestNews = data.articles;
                    News = latestNews;
                    Console.WriteLine("vdhvg hdsh");
                }

                else
                {
                    Console.WriteLine("Someting went wrong");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await LoadingPopup.Instance.Hide();
            }
        }
    }
}
