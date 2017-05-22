using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvxAndXamForms.Core.ViewModels;

namespace MvxAndXamForms.iOS.Views
{
    using System.Reflection.Emit;
    using UIKit;

    public class SecondView : MvxViewController
    {
        public SecondView() : base()
        {
        }

        public SecondView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.Title = "Second Page (Native) 2";
            this.View.BackgroundColor = UIColor.White;

            UIStackView stackView = new UIStackView();

            stackView.Axis = UILayoutConstraintAxis.Vertical;
            stackView.Distribution = UIStackViewDistribution.EqualSpacing;
            stackView.Alignment = UIStackViewAlignment.Leading;
            stackView.Spacing = 5;
            stackView.TranslatesAutoresizingMaskIntoConstraints = false;

            this.View.Add(stackView);

            this.View.AddConstraint(NSLayoutConstraint.Create(stackView, NSLayoutAttribute.Leading,
                NSLayoutRelation.Equal, this.View, NSLayoutAttribute.LeadingMargin, 1.0f, 0.0f));
            this.View.AddConstraint(NSLayoutConstraint.Create(stackView, NSLayoutAttribute.Trailing,
                NSLayoutRelation.Equal, this.View, NSLayoutAttribute.TrailingMargin, 1.0f, 0.0f));
            this.View.AddConstraint(NSLayoutConstraint.Create(stackView, NSLayoutAttribute.Top,
                NSLayoutRelation.Equal, this.TopLayoutGuide, NSLayoutAttribute.Bottom, 1.0f, 0.0f));
            this.View.AddConstraint(NSLayoutConstraint.Create(this.BottomLayoutGuide, NSLayoutAttribute.Top,
                NSLayoutRelation.Equal, stackView, NSLayoutAttribute.Bottom, 1.0f, 0.0f));

            var label = new UILabel();
            stackView.AddArrangedSubview(label);

            var text = new UITextField();
            stackView.AddArrangedSubview(text);

            var button = new UIButton(UIButtonType.System);
            button.SetTitle("GoTo Third", UIControlState.Normal);
            stackView.AddArrangedSubview(button);

            var set = this.CreateBindingSet<SecondView, SecondViewModel>();
            set.Bind(label).To(vm => vm.Hello);
            set.Bind(text).To(vm => vm.Hello);
            set.Bind(button).To(vm => vm.GoToThirdVm);

            set.Apply();
        }
    }
}
