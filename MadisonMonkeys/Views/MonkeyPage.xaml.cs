using System;
using System.Collections.Generic;

using Xamarin;
using Xamarin.Forms;
using Refractored.Xam.TTS;
using Refractored.Xam.TTS.Abstractions;

namespace MadisonMonkeys
{
	public partial class MonkeyPage : ContentPage
	{
		MonkeyListViewModel viewModel;

		public MonkeyPage ()
		{
			{
				InitializeComponent ();

				viewModel = new MonkeyListViewModel ();

				//Text to Speech use
				SpeakButtonGet.Clicked += (sender, e) =>
				{
					//Try Using The Button
					try
					{
						//Set it To False While we are using it
						SpeakButtonGet.IsEnabled = false;

						//Grab the binding details use the speak method
						CrossTextToSpeech.Current.Speak(MonkeyDetails.Text);

						//Done using, set back to true
						SpeakButtonGet.IsEnabled = true;
					} 
					catch (Exception ex) 
					{
						DisplayAlert ("Oh no!", "Unable to speak the details" + ex.Message, "ok");
					}
				};

				BindingContext = viewModel;
			}
		}
	}
}
