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
        public override void Show(MvxViewModelRequest request)
        {
            var fragmentHost = Activity as IMvxFragmentHost;
            if (fragmentHost != null) {

                var bundle = new Bundle ();
                var serializedRequest = Serializer.Serializer.SerializeObject (request);
                bundle.PutString (ViewModelRequestBundleKey, serializedRequest);

                fragmentHost.Show (request, bundle);
                return;
            }
            base.Show (request);
        }
    }
}