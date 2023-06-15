using System;
using System.Threading.Tasks;
using System.Web.UI;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace ChatGPT_Demo
{
    public partial class Chatbot : Page
    {
        private OpenAIAPI _api;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _api = new OpenAIAPI();

            _api = OpenAIAPI.ForAzure(
                YourResourceName: "aihackday062023",
                deploymentId: "chatGpt3",
                apiKey: "84b24763c9cb4411bdfb018e9c0305e1");
            _api.ApiVersion = "2023-03-15-preview";
        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(CallOpenAi));
            //var result = await CallOpenAi(apiKey, input);
            //Task.WaitAll(CallOpenAi());

        }

        private async Task CallOpenAi()
        {
            var input = txtInput.Text;

            //approach 1
            //txtOutput.Text = await _api.Completions.GetCompletion(input);

            //approach 2
            await _api.Completions.StreamCompletionAsync(
                new CompletionRequest(input, Model.DavinciText, 2000, 0.5, presencePenalty: 0.1, frequencyPenalty: 0.1),
                res => txtOutput.Text += res.ToString());

            //txtOutput.Text = await _api.Completions.CreateCompletionsAsync(input, 5);
        }

        protected async void btnChat_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ChatOpenAi));
        }

        private async Task ChatOpenAi()
        {
            var input = txtInput.Text;
            var chat = _api.Chat.CreateConversation();
            chat.AppendUserInput(input);

            await chat.StreamResponseFromChatbotAsync(res =>
            {
                txtOutput.Text = res;
            });
        }
    }
}