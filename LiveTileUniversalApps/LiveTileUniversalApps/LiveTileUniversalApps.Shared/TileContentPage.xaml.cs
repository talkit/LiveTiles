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
    public sealed partial class TileContentPage : Page
    {
        public TileContentPage()
        {
            this.InitializeComponent();
        }       

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var xmlFile = XElement.Load("Tile.xml");

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xmlFile.ToString());


            // Change content of tile
            foreach (IXmlNode node in xmldoc.GetElementsByTagName("text"))
            {
                if (node.ParentNode.Attributes.GetNamedItem("template").InnerText == "TileWide310x150ImageAndText01")
                {
                    if (node.Attributes.GetNamedItem("id").InnerText == "1")
                    {
                        node.InnerText = this.text1TextBox.Text;
                    }
                }
                else if (node.ParentNode.Attributes.GetNamedItem("template").InnerText == "TileSquare150x150Text02")
                {
                    if (node.Attributes.GetNamedItem("id").InnerText == "1")
                    {
                        node.InnerText = this.text1TextBox.Text;
                    }
                    if (node.Attributes.GetNamedItem("id").InnerText == "2")
                    {
                        node.InnerText = this.text2TextBox.Text;
                    }
                }
            }

            TileNotification tileNotification = new TileNotification(xmldoc);

            TileUpdateManager.CreateTileUpdaterForApplication().Clear();
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);

            Application.Current.Exit();
        }
    }
}
