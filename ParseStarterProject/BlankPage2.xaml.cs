using System;
using Facebook;

using Parse;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ParseStarterProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage2 : Page
    {
        public BlankPage2()
        {
         
            this.InitializeComponent();  
            
           
        }
        public async void hellos()
        { 
            bropop.Begin();
            try
            {
                ParseUser user = await ParseFacebookUtils.LogInAsync(
                    webbrowser, new[] { "user_likes", "email", "first_name" });
                // The user logged in with Facebook!
                this.Frame.Navigate(typeof(BlankPage3));
            }
            catch
            {
                // User cancelled the Facebook login or did not fully authorize.
            }
           
           
            webbrowser.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

       
        public async void hello(){
            try
            {
                prog.IsActive = true;

                string us = user.Text.ToString();
                string pa = password.Password.ToString();

                await Parse.ParseUser.LogInAsync(us, pa);
                textBlock.Text = "Welcome " + Parse.ParseUser.CurrentUser.Get<string>("username");
                prog.IsActive = false;
                prog.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                success.Begin();
                
            }
            catch (Exception e)
            {
                prog.IsActive = false;
                user.PlaceholderText = "Incorrect";
            }

           
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            hello();
        }

        private void sComplete(object sender, object e)
        {
            this.Frame.Navigate(typeof(BlankPage3));
        }

        private void face_Click(object sender, RoutedEventArgs e)
        {
            bropop.Begin();

            hellos(); 
        }
       
     
     

    }
     
    }

