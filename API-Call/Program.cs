using System.Net.Http.Json;

Console.WriteLine("問題！ 答えが３０になる足し算の組み合わせは？");
Console.Write("1つめ：");
int one = int.Parse(Console.ReadLine());
Console.Write("2つめ：");
int two = int.Parse(Console.ReadLine());

// web apiを呼ぶための httpClient作成
var client = new HttpClient();

// POSTでrequestを投げる
var response = await client.PostAsJsonAsync($"https://localhost:7059/?answer1={one}&answer2={two}", new RequestBody { Answer = one + two });

if (response.IsSuccessStatusCode)
{
    var responseBody = await response.Content.ReadFromJsonAsync<Response>();
    Console.WriteLine(responseBody.Result);
    Console.WriteLine(responseBody.Result2);
}
else
{
    Console.WriteLine("接続に失敗しました");
}


//リクエストとレスポンス
class RequestBody
{
    public int? Answer { get; set; }
}
class Response
{
    public string? Result { get; set; }
    public int? Result2 { get; set; }
}