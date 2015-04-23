using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace LiveTileUniversalApps
{    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void CreateLiveTileButton_Click(object sender, RoutedEventArgs e)
        {
            // To see all live tiles template, access https://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh761491.aspx           

            var xmlFile = XElement.Load("Tile.xml");

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlFile.ToString());

            TileNotification tileNotification = new TileNotification(xmldoc);

            TileUpdateManager.CreateTileUpdaterForApplication().Clear();            
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);

            Application.Current.Exit();
        }

        private void ChangeContentButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TileContentPage));            
        }

        private void ChangeTileTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            var xmlFile = XElement.Load("NewTile.xml");

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlFile.ToString());

            TileNotification tileNotification = new TileNotification(xmldoc);

            TileUpdateManager.CreateTileUpdaterForApplication().Clear();
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);

            Application.Current.Exit();
        }
    }
}
