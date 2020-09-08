# OSRedirector

Simple function to redirect the visitor based on the user-agent.

## Settings

Your local.setting.json file should look something like this:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "RedirectUrl:iOS": "https://www.url-for-ios-visitors.com",
    "RedirectUrl:Android": "https://www.url-for-android-visitors.com",
    "RedirectUrl:Default": "https://www.url-for-other-visitors.com"
  }
}
```
