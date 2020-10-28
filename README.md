# wavy-sms-sdk
Encapsula a requisição para envio de SMS utilizando a Wavy como broker

You can install the package 

```sh
Install-Package Wavy.SMS.SDK -Version 1.0.0
```

In the file appsettings.json you need add the code below:

```sh
  "WavySMSOptions": {
    "BaseURI": "https://api-messaging.wavy.global",
    "Username": "your username",
    "Token": "your token"
  }
 ```
 
 Add using statement
  ```sh
using Wavy.SMS.SDK;
 ```
 
 Then we need add some code to Startup.cs, into ConfigureServices method:
 
 ```sh
  services.AddWavySMSClient(opt =>
            {
                opt.BaseURI = Configuration.GetValue<string>("WavySMSOptions:BaseURI");
                opt.Username = Configuration.GetValue<string>("WavySMSOptions:Username");
                opt.Token = Configuration.GetValue<string>("WavySMSOptions:Token");
            });
 ```
 
 
 And finally we can send SMS using the interface  ISMSSender:
 
  ```sh
  await sender.Send(phoneNumber, $"Yoie message here");
   ```