using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigPage : ContentPage
    {
        Entry riik;
        Entry maakond;
        Entry tanav;
        Entry linn;
        Button go;
        RadioButton jalg, rattas, auto;
        
        public NavigPage()
        {
            riik = new Entry
            {
                Placeholder = "Riik"
            };
            maakond = new Entry
            {
                Placeholder = "Maakond"
            };
            linn = new Entry
            {
                Placeholder = "Linn"
            };
            tanav = new Entry
            {
                Placeholder = "Tänav"
            };
            go = new Button
            {
                Text = "Mine"
            };
            jalg = new RadioButton
            {
                Content = new Image { Source="jalaga.png"}
            };
            rattas = new RadioButton
            {
                Content = new Image { Source = "rattas.png" }
            };
            auto = new RadioButton
            {
                Content = new Image { Source = "auto.png" }
            };
            StackLayout nupud=new StackLayout { Children = {jalg,rattas,auto} };    

            go.Clicked += Go_Clicked;
            Content= new StackLayout { Children = { riik, maakond, linn, tanav ,nupud, go} };
        }

        private void Go_Clicked(object sender, EventArgs e)
        {
            LaunchingMap();
        }

        public async void LaunchingMap()
        {
            var placemark = new Placemark
            {
                CountryName = riik.Text,// "United States",
                AdminArea = maakond.Text,//"WA",
                Thoroughfare = tanav.Text,// "Microsoft Building 25",
                Locality = linn.Text// "Redmond"
            };
            //var options = new MapLaunchOptions { Name = "Sõpruse tee 183" };
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Bicycling };//Bicycling, Driving, and Walking
            await Map.OpenAsync(placemark, options);
        }
    }
}