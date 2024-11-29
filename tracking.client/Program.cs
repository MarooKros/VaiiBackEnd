// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Net.Http.Json;
using tracking.client;

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7295");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage IssueResponse = await client.GetAsync("api/issue");
HttpResponseMessage UserResponse = await client.GetAsync("api/user");
HttpResponseMessage PostResponse = await client.GetAsync("api/post");
PostResponse.EnsureSuccessStatusCode();
UserResponse.EnsureSuccessStatusCode();
IssueResponse.EnsureSuccessStatusCode();

if (IssueResponse.IsSuccessStatusCode)
{
    var issues = await IssueResponse.Content.ReadFromJsonAsync<IEnumerable<IssueDto>>();
    foreach (var issue in issues)
    {
        Console.WriteLine(issue.Title);
    }
}
else
{
    Console.WriteLine("Problem with issue");
}

if (UserResponse.IsSuccessStatusCode)
{
    var users = await UserResponse.Content.ReadFromJsonAsync<IEnumerable<IssueDto>>();
    foreach (var user in users)
    {
        Console.WriteLine(user.Id);
    }
}
else
{
    Console.WriteLine("Problem with user");
}

if (PostResponse.IsSuccessStatusCode)
{
    var posts = await PostResponse.Content.ReadFromJsonAsync<IEnumerable<PostDto>>();
    foreach (var post in posts)
    {
        Console.WriteLine(post.Id);
    }
}
else
{
    Console.WriteLine("Problem with post");
}

Console.ReadLine();
