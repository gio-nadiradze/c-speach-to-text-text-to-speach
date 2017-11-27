using System;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        private SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Started";

            Choices mychoices = new Choices();
            mychoices.Add(new string[] { "Hello", "hi" });
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(mychoices);
            Grammar mygrammar = new Grammar(gb);
            recEngine.LoadGrammarAsync(mygrammar);

            recEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs> (getWords);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        void getWords(object sender, SpeechRecognizedEventArgs e)
        {
            var word = e.Result.Text;
            if(word == "hi")
            {

                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;
                synthesizer.Rate = -5;

                synthesizer.Speak("Hello, how are you today?");

                richTextBox1.Text = word;
            }

            if (word == "hello")
            {

                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;
                synthesizer.Rate = -5;

                synthesizer.Speak("Hi, how can i help you?");

                richTextBox1.Text = word;
            }

        }

    }
}
