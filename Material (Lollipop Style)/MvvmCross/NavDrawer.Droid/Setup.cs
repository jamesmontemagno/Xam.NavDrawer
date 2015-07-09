using Android.Content;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Reflection;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Droid.FullFragging.Presenter;
using Cirrious.CrossCore;
using Android.Support.V7.Widget;
using Cirrious.MvvmCross.Binding.Droid;
using Cirrious.MvvmCross.Binding.Droid.Binders;
using Android.Views;
using Android.OS;
using Android.Util;
using BMM.UI.Droid.Application.Helpers;

namespace NavDrawer.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var customPresenter = new CustomFragmentsPresenter();
            Mvx.RegisterSingleton<IMvxFragmentsPresenter>(customPresenter);
            return customPresenter;
        }

        protected override IList<Assembly> AndroidViewAssemblies
        {
            get
            {
                var assemblies = base.AndroidViewAssemblies;
                assemblies.Add(typeof(Android.Support.V7.Widget.Toolbar).Assembly);
                assemblies.Add(typeof(Android.Support.V7.Widget.CardView).Assembly);
                assemblies.Add(typeof(Android.Support.V4.Widget.DrawerLayout).Assembly);
                assemblies.Add(typeof(Android.Support.V4.View.ViewPager).Assembly);
                assemblies.Add(typeof(com.refractored.PagerSlidingTabStrip).Assembly);
                return assemblies;
            }
        }

        public class AppCompatViewFactory : MvxAndroidViewFactory
        {
            public override View CreateView (View parent, string name, Context context, IAttributeSet attrs)
            {
                if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
                {
                    // If we're running pre-L, we need to 'inject' our tint aware Views in place of the standard framework versions
                    switch (name)
                    {
                    case "EditText":
                        return new AppCompatEditText(context, attrs);
                    case "Spinner":
                        return new AppCompatSpinner(context, attrs);
                    case "CheckBox":
                        return new AppCompatCheckBox(context, attrs);
                    case "RadioButton":
                        return new AppCompatRadioButton(context, attrs);
                    case "CheckedTextView":
                        return new AppCompatCheckedTextView(context, attrs);
                    case "AutoCompleteTextView":
                        return new AppCompatAutoCompleteTextView(context, attrs);
                    case "MultiAutoCompleteTextView":
                        return new AppCompatMultiAutoCompleteTextView(context, attrs);
                    case "RatingBar":
                        return new AppCompatRatingBar(context, attrs);
                    case "Button":
                        return new AppCompatButton(context, attrs);
                    }
                }
                return base.CreateView(parent, name, context, attrs);
            }
        }

        public class BindingBuilder : MvxAndroidBindingBuilder
        {
            protected override IMvxAndroidViewFactory CreateAndroidViewFactory()
            {
                return new AppCompatViewFactory();
            }
        }

        protected override MvxAndroidBindingBuilder CreateBindingBuilder()
        {
            return new BindingBuilder();
        }
    }
}