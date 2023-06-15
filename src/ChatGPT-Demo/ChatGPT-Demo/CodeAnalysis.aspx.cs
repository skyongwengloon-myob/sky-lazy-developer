using OpenAI_API;
using OpenAI_API.Chat;
using System;

namespace ChatGPT_Demo
{
    public partial class CodeAnalysis : System.Web.UI.Page
    {
        private OpenAIAPI _api;
        private Conversation _chat;

        protected void Page_Load(object sender, EventArgs e)
        {
            OpenAiSetup();
            UiSetting();
        }

        protected void OpenAiSetup()
        {
            _api = new OpenAIAPI();

            _api = OpenAIAPI.ForAzure(
                YourResourceName: "aihackday062023",
                deploymentId: "chatGpt3",
                apiKey: "            _api = new OpenAIAPI();\r\n");
            _api.ApiVersion = "2023-03-15-preview";

            _chat = _api.Chat.CreateConversation();
        }

        protected void UiSetting()
        {
            PanelRefine.Visible = false;
            PanelUnitTest.Visible = false;
            PanelDocumentation.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Code_Rating();

            if (CheckBoxRefine.Checked)
                Code_Refine();
            
            if (CheckBoxUnitTest.Checked)
                Code_Testing();

            if (CheckBoxDocumentation.Checked)
                Code_Documentation();
        }

        protected async void Code_Rating()
        {
            //Input
            _chat.AppendUserInput(txtInput.Text);

            //System setup
            _chat.AppendSystemMessage("you going to rating the original code score, if 100% is perfection. you only have to response [rating: {original score/100}%], no other statement.");

            //Output
            var rating = await _chat.GetResponseFromChatbotAsync();
            lblRating.Text = rating;
        }

        protected async void Code_Refine()
        {
            //Input
            _chat.AppendUserInput(txtInput.Text);

            //System setup
            _chat.AppendSystemMessage("You are a coding master helps developer fine-tune the code. If the user give you coding, you going return complete c# fine-tune code with reason on your changes");

            //Output
            var refineCode = await _chat.GetResponseFromChatbotAsync();
            txtOutputRefine.Text = refineCode;
            
            //UI Setting
            PanelRefine.Visible = true;
        }

        protected async void Code_Testing()
        {
            //Input
            _chat.AppendUserInput(txtInput.Text);

            //System setup
            _chat.AppendSystemMessage("You are a coding QA master helps developer to writing unit test for the coding. you going to write complete c# unit test for all scenarios by using NSubstitute and fluent assertion, including boundary testing if necessary");
            
            //Output
            var response = await _chat.GetResponseFromChatbotAsync();
            txtOutputUnitTest.Text = response;

            //UI Setting
            PanelUnitTest.Visible = true;
        }

        protected async void Code_Documentation()
        {
            //Input
            _chat.AppendUserInput(txtInput.Text);

            //System setup
            _chat.AppendSystemMessage("You are a coding master helps developer to document coding. If the user give you coding, you going to understand and document as simple as possible with topic");

            //Output
            var response = await _chat.GetResponseFromChatbotAsync();
            txtOutputDocumentation.Text = response;

            //UI Setting
            PanelDocumentation.Visible = true;
        }
        
        protected void btnSample_Click(object sender, EventArgs e)
        {
            txtInput.Text = "        private decimal GetAmount(PayrunEmployeeLeave leave)\r\n        {\r\n            if (leave._LeaveType == PayrunEmployeeLeaveType.Annual &&\r\n                leave._FinalPay == true &&\r\n                leave.Amount < 0)\r\n            {\r\n                return 0;\r\n            }\r\n\r\n            return leave.Amount ?? 0;\r\n        }";
        }
    }
}