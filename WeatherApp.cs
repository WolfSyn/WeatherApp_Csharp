using System;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
/* 
Design: 
    Add a Text Box and name in 'txtCityName' for your input.
    Add a Button and name it 'btnGetWeather' for fetching the weather.
    Add a Label and name it 'lblResult' to dispaly the results.
   
   
Steps to Design Using Toolbox: 
    TextBox: Set its 'Name' property to 'txtCityName' and position it on the form.
    Button: Set its 'Name' property to 'btnGetWeather' and 'Text' property to "Get Weather"
    Label: Set its 'Name' property to lblResult and adjust the size to fit the weather output.

Run the Program: 
    After setting up the design, press 'F5' to tun the program. 
    
    Enter a city name in the TextBox, click the Button, and the weather information will display in the Label.
    
This will provide a user-friendly interface for checking the weather. 
*/
namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private async void btnGetWeather_Click(object sender, EventArgs e)
        {
            string apiKey = "YOUR_API_KEY"; /* Replace with OpenWeatherMap API KEY*/
            string city = txtCityName.Text; /* Get the city name from the input field*/
            
            if (string.IsNullOrEmpty(city))
            {
                lblResult.Text = "Please enter a city name";
                return;
            }
            
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apikey}&units=metric";
            
            using (HttpClient clinet = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.Is SuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject weatherData = JObject.Parse(jsonResponse);
                    
                    string description = weatherData["weather"][0]["description"].ToString();
                    string temperature = weatherData["main"]["temp"].ToString();
                    string country = weatherData["sys"]["country"].ToString();
                    
                    
                    lblResult.Text = $"Weather in {city}, {country}:\nTemperature: {temperature}°C\nCondition: {description}";
                }
                else
                {
                    lblResult.Text = "unable to fetch weather data. Please check the city name.";
                }
            }
        }
    }
}
