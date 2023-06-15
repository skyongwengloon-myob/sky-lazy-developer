using OpenAI_API.Chat;
using OpenAI_API;
using System;

namespace ChatGPT_Demo
{
    public partial class JiraToCode : System.Web.UI.Page
    {
        const string ApiKey = "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";
        private OpenAIAPI _api;
        private Conversation _chat;

        protected void Page_Load(object sender, EventArgs e)
        {
            OpenAiSetup();
            UiSetting();
        }

        protected void OpenAiSetup()
        {
            _api = new OpenAIAPI(ApiKey);

            _api = OpenAIAPI.ForAzure(
                YourResourceName: "aihackday062023",
                deploymentId: "chatGpt3",
                apiKey: "84b24763c9cb4411bdfb018e9c0305e1");
            _api.ApiVersion = "2023-03-15-preview";

            _chat = _api.Chat.CreateConversation();
        }

        protected void UiSetting()
        {
            PanelRefine.Visible = false;
        }
        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            var input = txtInput.Text;

            if (CheckBoxRefine.Checked)
                Code_Refine(input);
        }

        protected async void Code_Refine(string input)
        {
            //System setup
            _chat.AppendSystemMessage("You are a C# senior developer writing production code. If the user give you business description, you going return complete c# code and unit test for all scenarios by using NSubstitute and fluent assertion, including boundary testing if necessary.");

            //Input
            _chat.AppendUserInput(input);

            //Output
            var response = await _chat.GetResponseFromChatbotAsync();
            txtOutputRefine.Text = response;

            //UI Setting
            PanelRefine.Visible = true;
        }
        protected void btnSample_Click(object sender, EventArgs e)
        {
            txtInput.Text = "As a developer, I want to add a New Essential data validation to validate Count for nzpr.EmployeePay match to dbo.BusinessEvent(Type : EmployeePaymentEvent, 17) and nzpr.EmployeePayJournalEvent";
        }
    }
}