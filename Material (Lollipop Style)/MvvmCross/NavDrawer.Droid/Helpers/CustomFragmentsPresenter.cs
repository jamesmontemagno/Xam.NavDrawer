using Android.Content;
using Android.OS;
using Cirrious.MvvmCross.Droid.FullFragging.Presenter;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using System;

namespace BMM.UI.Droid.Application.Helpers
{
    public class CustomFragmentsPresenter : MvxFragmentsPresenter
    {
        /*public interface IMvxFragmentHostEx : IMvxFragmentHost
        {
            void Close(IMvxViewModel viewModel);

            void ChangePresentation(MvxPresentationHint hint);
        }*/


        //private readonly Dictionary<Type, IMvxFragmentHost> _dictionary = new Dictionary<Type, IMvxFragmentHost>();

        public override void Show(MvxViewModelRequest request)
        {
            var fragmentHost = Activity as IMvxFragmentHost;
            if (fragmentHost != null)
            {

                var bundle = new Bundle();
                var serializedRequest = Serializer.Serializer.SerializeObject(request);
                bundle.PutString(ViewModelRequestBundleKey, serializedRequest);

                fragmentHost.Show(request, bundle);
                return;
            }
            base.Show(request);

            /*var fragmentHost = Activity as IMvxFragmentHost;
            if (fragmentHost != null)
            {
                var bundle = new Bundle();
                var serializedRequest = Serializer.Serializer.SerializeObject(request);
                bundle.PutString(ViewModelRequestBundleKey, serializedRequest);
                fragmentHost.Show(request, bundle);
            }
            else
            {
                var bundle = new Bundle();
                var serializedRequest = Serializer.Serializer.SerializeObject(request);
                bundle.PutString(ViewModelRequestBundleKey, serializedRequest);

                var intentFor = new Intent(Activity.ApplicationContext, typeof(MainActivity));
                intentFor.PutExtra("request", bundle);
                base.Show(intentFor);
            }*/
        }

        /*public override void ChangePresentation(MvxPresentationHint hint)
        {
            if (hint != null)
            {
                var fragmentHost = Activity as IMvxFragmentHost as IMvxFragmentHostEx;
                if (fragmentHost != null)
                {
                    fragmentHost.ChangePresentation(hint);
                }
            }
            base.ChangePresentation(hint);
        }

        public override void Close(IMvxViewModel viewModel)
        {
            var fragmentHost = Activity as IMvxFragmentHost as IMvxFragmentHostEx;
            if (fragmentHost != null)
            {
                fragmentHost.Close(viewModel);
            }
            base.Close(viewModel);
        }*/
    }
}