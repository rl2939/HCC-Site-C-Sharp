using System.Data.Common;
using System.Net.Http.Headers;
namespace iSchoolWebApp.Services
{
    public class GetData
    {
        /*Task vs Thread, Task has async/await and return value
        no direct way to return from a thread
        task can do multiple things at once, threads only one
        can cancel a Task
        Task is a higher level language than a thread*/
        //string endpoint ex: "about/"
        public async Task<string> GetMyData(string endpoint)
        {
            //using statement - at end  of it automatically is disposed
            using (var client = new HttpClient())
            {
                //set up my baseAddress...
                client.BaseAddress = new Uri("http://ist.rit.edu/api/");
                //clean up for prev calls
                client.DefaultRequestHeaders.Accept.Clear();
                //set it up to accept json
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                     HttpResponseMessage response = 
                        await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                    //check that it worked!
                    response.EnsureSuccessStatusCode();
                    //we have done nothing... all setup so far
                    var data = await response.Content.ReadAsStringAsync();
                    //we know data is just a string...
                    return data;
                }
                catch (HttpRequestException hre)
                { 
                    var msg = hre.Message;
                    return "HttpRequest" + msg;
                }
                catch(Exception e)
                {
                    var msg = e.Message;
                    return "Ex:" + msg;
                }
            }
        }
    }
}
