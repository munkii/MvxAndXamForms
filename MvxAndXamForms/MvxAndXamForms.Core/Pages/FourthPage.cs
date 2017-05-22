using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MvxAndXamForms.Core.Pages
{
    public class FourthPage : ContentPage
    {
        public FourthPage()
        {
            this.Title = "Fourth Page (XF)";

            var doneButton = new Button
            {
                Text = "Done",
                WidthRequest = 30
            };

            Content = new StackLayout
            {
                Padding = 40,
                Spacing = 10,
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new Label
                    {
                        Text = "Test",
                        FontSize = 24
                    },
                    doneButton
                }
            };

            doneButton.SetBinding(Button.CommandProperty, new Binding("DoneCommand"));
        }
    }
}
