# Welcome to Messaging Center Blazor Utitlity!


<img src="https://github.com/aksoftware98/blazor-utilities/blob/main/Assets/Blazor%20Utitlies.png?raw=true" alt="drawing" width="200"/>

### AKSoftware.Blazor.Utilities 
[![NuGet Status](https://img.shields.io/nuget/dt/AKSoftware.Blazor.Utilities?color=nuget&label=Nuget&style=plastic)](http://nugetstatus.com/packages/AKSoftware.Blazor.Utilities)

#### :zap: :zap: :rocket: Send data across your components fluently with the Messaging Center :rocket: :rocket: :zap:
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

> **Note:** The messaging center class with the current package is the same class and cloned from the Xamarin.Forms repository from the following link [Xamarin.Forms](Xamarin.Forms%20Repository)

## Check out the sample project:
In the current repository you can find a sample project to use the MessagingCenter service in Blazor that shows how to send a string value from one component to two other components without a direct relationship between them and update their states. 
The example shows using updating the username in a form component then using MessagingCenter we can send that update to the NavMenu component and the MainLayout and update the value there. 
Check out the following folder: 

## :earth_americas: :construction_worker: Get Started with Blazor MessagingCenter :golf:
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

## :zap:  🚀 Publish a message  🚀 :zap:
From the component that you want to send data from example a sample string like the example in the repository 

> The code takes a the sender object as a parameter, the filter of the message like for this example "greeting_message" which will be used by other components to receive the message, and the last parameter is the value to be sent

``` C#
public void SendMessage()
{
     string valueToSend = "Hi from Component 1";
     MessagingCenter.Send(this, "greeting_message", valueToSend);
}
```

## :airplane: Receive a message from destination component :airplane:

In the destination component all you can do is calling the subscribe method to subscribe for a target of messaging 

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

### Enjoy it :roller_coaster:

## :construction: How to contribute
Contributions are welcomed to the current repository you can get started by 

 - Cloning the project
 - Add your own features 
 - Submit a PR 
 - You can find me here https://ahmadmozaffar.net

## :warning: You have problems???
Feel free to open any issue directly from the issues section here [GitHub Issues](https://github.com/aksoftware98/blazor-utilities/issues)


#### Developed with all :heart: by :computer: [Ahmad Mozaffar](https://ahmadmozaffar.net)
