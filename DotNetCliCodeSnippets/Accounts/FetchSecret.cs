﻿using Vonage;
using Vonage.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets.Accounts
{
    public class FetchSecret : ICodeSnippet
    {
        public void Execute()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var VONAGE_SECRET_ID = Environment.GetEnvironmentVariable("VONAGE_SECRET_ID") ?? "VONAGE_SECRET_ID";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var response = client.AccountClient.RetrieveApiSecret(VONAGE_SECRET_ID, VONAGE_API_KEY);

            Console.WriteLine($"Api Secret Retrieved {response.Id} created at {response.CreatedAt}");
        }

        public async System.Threading.Tasks.Task ExecuteAsync()
        {
            var VONAGE_API_KEY = Environment.GetEnvironmentVariable("VONAGE_API_KEY") ?? "VONAGE_API_KEY";
            var VONAGE_API_SECRET = Environment.GetEnvironmentVariable("VONAGE_API_SECRET") ?? "VONAGE_API_SECRET";
            var VONAGE_SECRET_ID = Environment.GetEnvironmentVariable("VONAGE_SECRET_ID") ?? "VONAGE_SECRET_ID";

            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new VonageClient(credentials);

            var response = await client.AccountClient.RetrieveApiSecretAsync(VONAGE_SECRET_ID, VONAGE_API_KEY);

            Console.WriteLine($"Api Secret Retrieved {response.Id} created at {response.CreatedAt}");
        }
    }
}
