# Welcome to Messaging Center Blazor Utitlity!


<img src="https://github.com/aksoftware98/blazor-utilities/blob/main/Assets/Blazor%20Utitlies.png?raw=true" alt="drawing" width="200" style="width:200px"/>

### AKSoftware.Blazor.Utilities 

#### ⚡ ⚡ 🚀 Send data across your components fluently with the Messaging Center ⚡ ⚡ 🚀
Paramters, Cascading Parameters and Event Callbacks are ways to send data across components but MessagingCenter is much easier and straightforward
![MessagingCenter](https://github.com/aksoftware98/blazor-utilities/blob/main/Assets/MessagingCenter%20Sample.gif?raw=true)


If you are a Xamarin.Forms developer, you definitely passed across the MessagingCenter class that was being used to send messages across objects, this class helps a lot by pushing data across components in the system effiecently. 
And now for Blazor Messaging Center is a great tool to use to solve the issue of sending the data across components and updating them.
Using MessagingCenter you will be able to send data from one component to another or to a set of other components just with one line of code despite the relationship between those components (Parent - Child .etc...)
The following illustration shows the benefits of using MessagingCenter to send data between the components.

### Messaging Center Quick Explanation:  
![enter image description here](https://github.com/aksoftware98/blazor-utilities/blob/main/Assets/MessagingCenter.png?raw=true)
## Package Content:  
For now package the **AKSoftware.Blazor.Utilities** just contains the ***MessagingCenter*** service which is the same that is implemented in Xamarin.Forms to be used in Blazor projects as a service to send the data across the components using the Publish - Subscription pattern in addition to the existing model of Parameters & Event Callbacks.

> **Note:** The messaging center class with the current package is the same class and cloned from the Xamarin.Forms repository from the following link [Xamarin.Forms](https://github.com/xamarin/Xamarin.Forms/blob/5.0.0/Xamarin.Forms.Core/MessagingCenter.cs)

## Check out the sample project:
In the current repository you can find a sample project to use the MessagingCenter service in Blazor that shows how to send a string value from one component to two other components without a direct relationship between them and update their states. 
The example shows using updating the username in a form component then using MessagingCenter we can send that update to the NavMenu component and the MainLayout and update the value there. 
Check out the following folder: 

## 🌎 👷 Get Started with Blazor MessagingCenter ⛳
Make sure to instal the NuGet package of the library using the ***NuGet command*** 
``` 
	Install-Package AKSoftware.Blazor.Utilities
```

Or through the ***.NET CLI***
```
	dotnet package install AKSoftware.Blazor.Utilities
```

Now in the **_imports.razor** and add the following namesapce
``` Razor
@using AKSoftware.Blazor.Utilities
```

## ⚡  🚀 Publish a message  🚀 ⚡
From the component that you want to send data from example a sample string like the example in the repository 

> The code takes a the sender object as a parameter, the filter of the message like for this example "greeting_message" which will be used by other components to receive the message, and the last parameter is the value to be sent

``` C#
public void SendMessage()
{
     string valueToSend = "Hi from Component 1";
     MessagingCenter.Send(this, "greeting_message", valueToSend);
}
```

## ✈️ Receive a message from destination component ✈️

In the destination component all you can do is calling the subscribe method to subscribe for a target of messaging 

Blazor WebAssembly

``` C#
public void SubscribeToMessage()
{
	MessagingCenter.Subscribe<Component1, string>(this, "greeting_message", (sender, value) => 
	{
		// Do actions against the value 
		// If the value is updating the component make sure to call 
		string greeting = $"Welcome {value}";
		StateHasChanged(); // To update the state of the component 
	});
}
```

## 🚧⚠️ Blazor Server Notice 🚧⚠️

Becuase Blazor Server working on thread make sure to call that InvokeAsync within the callback
**Note:** This will be resolved and updated in the version 1.0.1 
Special thanks for **[Ferenc Czirok](https://github.com/czirok)** for mentioning the note and the following code snippet

``` C#
public void SubscribeToMessage()
{
	MessagingCenter.Subscribe<Component1, string>(this, "greeting_message", async (sender, value) => 
	{
		// Do actions against the value 
		// If the value is updating the component make sure to call 
		// Use InvokeAsync() to switch execution to the Dispatcher when triggering rendering or component state
		await InvokeAsync(() => {
			string greeting = $"Welcome {value}";
			StateHasChanged(); // To update the state of the component 
		});
	});
}
```

### Enjoy it 🎢

## 🚧 How to contribute
Contributions are welcomed to the current repository you can get started by 

 - Cloning the project
 - Add your own features 
 - Submit a PR 
 - You can find me here https://ahmadmozaffar.net

## ⚠️ You have problems???
Feel free to open any issue directly from the issues section here [GitHub Issues](https://github.com/aksoftware98/blazor-utilities/issues)


#### Developed with all ❤️ by 💻 [Ahmad Mozaffar](https://ahmadmozaffar.net)
