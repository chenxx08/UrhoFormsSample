using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Forms.Xaml;

namespace UrhoFormsSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage
    {
        public DetailPage()
        {
            InitializeComponent();
            var peoples = new List<People>();
            for (var i = 0; i < 20; i++)
            {
                peoples.Add(new People
                {
                    Name = "Name" + i,
                    Age = 20 + i
                });
            }
            //The code below can cause app crash when back key pressed on UrhoPage!!!!!
            var jsonStr = JsonConvert.SerializeObject(peoples);
            ListView.ItemsSource = JsonConvert.DeserializeObject<List<People>>(jsonStr);
            
            //ListView.ItemsSource = peoples;  //this code is safe
        }
    }

    public class People
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}