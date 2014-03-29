using Parse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public sealed partial class MainPage : Page
    {
        public int count = 0;
        private static readonly Random rand = new Random();
        public string answer = "";
        public string a1s = "";
        public string a2s = "";
        public string a3s = "";
        public int po = 0;
        public MainPage()
        {
            this.InitializeComponent();
            flyin.Begin();
            query();
            
                  }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private async void query()
        {
            if (po == 10)
            {
                ParseUser.CurrentUser.Increment("point", count);
            }
            else {
            po += 1;
            var query = from questions in ParseObject.GetQuery("Questionss")
                        where questions.Get<string>("Question") != null
                        
                        select questions;
            IEnumerable<ParseObject> results = await query.FindAsync();
            int count = await query.CountAsync();
            Random rnd = new Random();
            int x = rnd.Next(1, count); // creates a number between 1 and 12
            ParseObject obj = results.ElementAt<ParseObject>(x);

            TextBlock code = questionsss;
            string question = obj.Get<string>("Question");
            code.Text = question;
            a1s = obj.Get<string>("MC1");
            a2s = obj.Get<string>("MC2");
            a3s = obj.Get<string>("MC3");
            a1.Content = obj.Get<string>("MC1");
            a2.Content = obj.Get<string>("MC2");
            a3.Content = obj.Get<string>("MC3");
            answer = obj.Get<string>("MA"); 
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {query();


        if (ts.IsOn)
        {

            but1click.Begin();
            correct1.Begin();
        }
        }

        private void dothis()
        {
            query();
            if (ts.IsOn) {
            flyin.Begin(); 
            }
        }

        private void ts_Toggled(object sender, RoutedEventArgs e)
        {
            if (ts.IsOn)
            {

            }
        }

        private void a1_Click(object sender, RoutedEventArgs e)
        {

            if (a1s.Equals(answer))
            {
              
                correct1.Begin();
                textBlockjj.Text = "Correct";
                correctslap.Begin();
                count += 1;
            }
            else
            {
                
                wrong1.Begin();
                textBlockjj.Text = "Wrong";
                correctslap.Begin();
            }
        }

     
    

        private void a2_Click_1(object sender, RoutedEventArgs e)
        {

            if (a2s.Equals(answer))
            {
                
                correct2.Begin();
                textBlockjj.Text = "Correct";
                correctslap.Begin();
                count += 1;
            }
            else
            {
                textBlockjj.Text = "Wrong";
                correctslap.Begin();
                wrong2.Begin();
            }
        }

        private void a3_Click_1(object sender, RoutedEventArgs e)
        {

            if (a3s.Equals(answer))
            {
               
                correct3.Begin();
                textBlockjj.Text = "Correct";
                correctslap.Begin();
                count += 1;
            }
            else
            {
                textBlockjj.Text = "Wrong";
                correctslap.Begin();
                wrong3.Begin();
            }
        }

        private void correctslap_Completed(object sender, object e)
        {
            query();

        }
    }
}
