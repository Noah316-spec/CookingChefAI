using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenAI.GPT3.Managers;
using OpenAI.GPT3;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace CookingBoard
{
    
    public partial class Form1 : Form
    {
        /// <summary>
        /// Projekt apikey free version funktioniert nicht 
        /// </summary>
        /// 
        
        //Deklarieren und Initialisieren
        static readonly HttpClient client = new HttpClient();
        List<string> list = new List<string>();
        List<string> wert = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0; // standardwert Flüssig
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wert.Add(comboBox1.Text);
            list.Add(richTextBox1.Text);
            richTextBox1.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Starten Sie die Main-Funktion als Task, um die asynchrone Ausführung zu ermöglichen.
            _ = Main();
        }

        private async Task Main()
        {
                // Erstellen Sie eine Instanz des OpenAIService mit Ihrem API-Schlüssel.
                var service = new OpenAIService(new OpenAiOptions
                {
                    ApiKey = "ihrAPIkey"
                });

                // Setzen Sie das Standardmodell für den Service.
                service.SetDefaultModelId(Models.ChatGpt3_5Turbo);

                // Erstellen Sie eine Liste von ChatMessages für die Anfrage.
                var message = new List<ChatMessage>
                {
                    ChatMessage.FromSystem("you are a cook chef"),
                    ChatMessage.FromUser("Erstell ein rezept aus diesen Lebensmitteln 100 ml Zimt 1 Apfel")
                };

                // Erstellen Sie die Anfrage für die ChatCompletion.
                var req = new ChatCompletionCreateRequest
                {
                    Messages = message,
                    N = 1,
                    //Maxtokens = 1000,
                    //FrequencyPenalty = 2.0f,
                    //Temperature = 0.1f
                };

                // Senden Sie die Anfrage und warten Sie auf die Antwort.
                var res = await service.ChatCompletion.CreateCompletion(req);

                // Überprüfen Sie, ob die Anfrage erfolgreich war.
                if (res.Successful)
                {
                    // Wenn die Anfrage erfolgreich war, setzen Sie den Text des richTextBox2 auf die Antwort des Modells.
                    richTextBox2.Text = res.Choices.First().Message.Content;
                }
                else
                {
                    // Wenn die Anfrage nicht erfolgreich war, zeigen Sie eine Fehlermeldung an.
                    MessageBox.Show("Unsuccessful!");
                }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Auswahl index flüssig oder fest
            comboBox1.Items.Clear();
            if (comboBox2.SelectedIndex == 0)
            {
                for (int i = 1; i <= 10; i++) // zählt bis 10 hoch 
                {
                    if (i == 10) // 10 gleich 1L
                    {
                        comboBox1.Items.Add(1 + "L");
                        break;
                    }
                    comboBox1.Items.Add(i + "00" + "ml"); //wert hinzufügen
                    
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                for (int i = 1; i <= 9; i++)// zählt bis 9 hoch 
                {
                    comboBox1.Items.Add(i);//wert hinzufügen
                }
            }
        }

     
    }
}
