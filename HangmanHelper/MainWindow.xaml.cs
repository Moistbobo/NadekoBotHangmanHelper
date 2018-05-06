using HangmanHelper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HangmanHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_process_list_Click(object sender, RoutedEventArgs e)
        {
            string[] itemvalues = textbox_word_values.Text.Split('\n');
            string[] imgvalues = textbox_img_values.Text.Split('\n');
            string categoryname = textbox_category_name.Text;


            List<HangmanObject> hangmanlist = new List<HangmanObject>();

            for (int i = 0; i < itemvalues.Length; i++)
            {
                // Do not add words that contain hyphens
                if (!itemvalues[i].Contains("-"))
                {
                    HangmanObject temp = new HangmanObject();
                    temp.Word = itemvalues[i].Replace("\r", "");
                    try
                    {
                        temp.ImageUrl = imgvalues[i].Replace("\r", "");
                    }
                    catch (Exception ex)
                    {
                        temp.ImageUrl = "";
                    }
                    hangmanlist.Add(temp);
                }

            }

            string json = JsonConvert.SerializeObject(hangmanlist, Formatting.Indented);
            string filecontents = string.Format("\"{0}\":{1}", categoryname, json);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"GeneratedList.json"))
            {
                file.WriteLine(filecontents);
            }
        }
    }
}
