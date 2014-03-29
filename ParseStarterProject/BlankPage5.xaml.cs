using System;
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
    public sealed partial class BlankPage5 : Page
    {
        public BlankPage5()
        {
            this.InitializeComponent();
            first.Begin();
        }


        public async void submit()
        {

            pr.IsActive = true;
            string q = tq.Text.ToString();
            string qa = ta.Text.ToString();
            string qb = tb.Text.ToString();
            string qc = tc.Text.ToString();
            string asd = "";
            if (a.IsChecked == true)
            {
                asd = qa;

            }else if (b.IsChecked == true)
            {
                asd = qb;

            }else if (c.IsChecked == true)   
            {
                asd = qc;
            }
            ParseUser pu = ParseUser.CurrentUser;
            ParseObject question = new ParseObject("Questionss");
            question["Question"] = q;
            question["MC1"] = qa;
            question["MC2"] = qb;
            question["MC3"] = qc;
            question["MA"] = asd;
            await question.SaveAsync();

            var user = ParseUser.CurrentUser;
        
            var relation = user.GetRelation<ParseObject>("usqc");
            relation.Add(question);
            await user.SaveAsync();
            tq.Text = "";
            ta.Text = "";
            tb.Text = "";
            tc.Text = "";
            pr.IsActive = false;
        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            submit();
        }
    }
}
