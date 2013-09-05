using MvxSample.Core.ViewModels;

namespace MvxSample.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {

        public override void Initialize()
        {

            this.RegisterAppStart<HomeViewModel>();
        }

    }
}
