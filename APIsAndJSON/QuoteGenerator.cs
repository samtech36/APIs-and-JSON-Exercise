using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

public class QuoteGenerator
{
    
    
    

    private HttpClient _client;

    public QuoteGenerator(HttpClient client)
    {
        _client = client;
    }
    
    
    
    public string KanyeQuote()
    {

        var kanyeUrl = "https://api.kanye.rest";
            
        var kanyeResponseJson = _client.GetStringAsync(kanyeUrl).Result;

        var kanyeQuote = JObject.Parse(kanyeResponseJson).GetValue("quote").ToString();
        
        return kanyeQuote;

    }

    public string RonQuote()
    {

        var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            
        var ronResponseJson = _client.GetStringAsync(ronUrl).Result;


        var ronQuote = JArray.Parse(ronResponseJson).ToString().Replace('[', ' ').Replace(']', ' ').Trim();


        return ronQuote;

    }
    
}