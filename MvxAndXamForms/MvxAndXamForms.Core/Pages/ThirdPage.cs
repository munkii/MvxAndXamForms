using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MvxAndXamForms.Core.Pages
{
    public class ThirdPage : ContentPage
    {
        public ThirdPage()
        {
            var entryBox = new Entry
            {
                Placeholder = "Value",
                TextColor = Color.Aqua,
                WidthRequest = 30
            };

            var saveButton = new Button
            {
                Text = "Save",
                WidthRequest = 30
            };

            var fourthButton = new Button
            {
                Text = "Jump To Fourth",
                WidthRequest = 30,
                BackgroundColor = Color.Green,
                TextColor = Color.Black
            };

            this.Title = "Third Page (XF)";
            
            Content = new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new Label
                    {
                        Text = "Enter value",
                        FontSize = 24
                    },
                    entryBox,
                    saveButton,
                    fourthButton
                }
            };

            if (Device.RuntimePlatform == Device.iOS)
            {
                ((StackLayout)Content).Padding = new Thickness(0, 40 , 0, 0);
            }
            
            entryBox.SetBinding(Entry.TextProperty, new Binding("Value"));
            saveButton.SetBinding(Button.CommandProperty, new Binding("SaveCommand"));
            fourthButton.SetBinding(Button.CommandProperty, new Binding("GoToFourthCommand"));
        }
    }
}
