using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ChatGPTAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OpenAI : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetData(string input)
        {
            string apiKey = "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";
            string response = "";
            var openAIAPI = new OpenAIAPI(apiKey);
            var completion = new CompletionRequest();
            completion.Prompt = input;
            completion.Model = "text-davinci-003";
            completion.MaxTokens = 4000;
            var output = await openAIAPI.Completions.CreateCompletionAsync(completion);
            if (output != null)
            {
                foreach (var item in output.Completions)
                {
                    response = item.Text;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest("Not Found");
            }
        }
    }
}
