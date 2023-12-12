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
    public partial class TablePage : ContentPage
    {
        TableView tableView;
        SwitchCell switchCell;
        ImageCell imageCell;
        TableSection fotosection;
        ViewCell cell;
        StackLayout st;
        public TablePage()
        {
            fotosection = new TableSection();
            switchCell = new SwitchCell { Text = "Näita veel..." };
            switchCell.OnChanged += SwitchCell_OnChanged;
            
            

            
            imageCell = new ImageCell 
            { 
                Text = "Foto:", 
                ImageSource = "bees.png",
                Detail="Kirjeldus",
                
            };
            
            tableView = new TableView
            {
                
                Intent = TableIntent.Form,
                
                Root=new TableRoot("Andmed:")
                {
                    new TableSection("Põhiandmed:")
                    {
                        
                        new EntryCell
                        {
                            Label="Nimi:",
                            Placeholder="Siia tuleb nimi",
                            Keyboard=Keyboard.Default,
                            HorizontalTextAlignment=TextAlignment.Center,
                            VerticalTextAlignment=TextAlignment.Center,
                        }
                    },
                    new TableSection("Kontaktandmed:")
                    {
                        new EntryCell
                        {
                            Label="Telefon:",
                            Placeholder="Kirjuta telefoni nr.   ",
                            Keyboard=Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label="Email:",
                            Placeholder="Siia tuleb email",
                            Keyboard=Keyboard.Email
                        },
                        switchCell
                    },
                    fotosection
                }
            };
            
            Content = tableView;
        }
        public async void LaunchingMap()
        {
            var placemark = new Placemark
            {
                CountryName ="Estonia",// "United States",
                AdminArea = "Harjumaa",//"WA",
                Thoroughfare ="Sõpruse tee 183",// "Microsoft Building 25",
                Locality ="Tallinn"// "Redmond"
            };
            var options = new MapLaunchOptions { Name = "Sõpruse tee 183" };
            //var options = new MapLaunchOptions { NavigationMode = NavigationMode.Bicycling };//Bicycling, Driving, and Walking
            await Map.OpenAsync(placemark, options);
        }
        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto: ";
                fotosection.Add(imageCell);
                switchCell.Text = "Peida";
                //LaunchingMap();
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(imageCell);
                switchCell.Text = "Näita veel...";
            }
        }
    }
}