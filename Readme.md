# TCGaming.NET - [[TC] Gaming](https://tc-gaming.co.uk)
.NET Wrapper library for the [TC] Gaming API - Available for download via NuGet Package Manager! https://www.nuget.org/packages/TCGaming.NET/

```PM> Install-Package TCGaming.NET -Version 1.0.0.2```

### [TC] Gaming API
This wrapper library was written to assist developers wishing to make use of the [TC] Gaming API (further information available at [[TC] Gaming](https://apidocs.tc-gaming.co.uk))

### Functionality
Currently, all *CityDriving Statistic API's* are supported within this library. Various handling of data has been included to aid the user with conversions, such as:

- UNIX Date & Time to System.DateTime object
- String cleaner to remove colour and language formatting from Live For Speed
- Gaming time conversions
- Driven distance unit conversions

### API Keys
API Keys are available from [[TC] World > My Account](https://world.city-driving.co.uk/?page=myaccount) *(You must be a registered user within a [TC] CityDriving Server to access [TC] World)*

## Example Usage - Find all vehicles owned by a user

### 1. Pass your API Key
```
Configuration.AddAPIKey("YOUR_KEY");
```

### 2. Create a new instance of the UserProfile.Profile object
```
UserProfile.Profile myUser = new UserProfile.Profile("username");
```

### 3. Set what level of data you wish to return 
There are various methods available within the Profile object, these are 'GetCars(), GetLicenses(), GetProperties(), GetUpgrades(), GetStats() and GetData()'. For this particular example, we must ensure the GetCars() method is used.

GetData() must be the last method to be called.
```
myUser.GetCars();
myUser.GetLicenses();
myUser.GetProperties();
myUser.GetUpgrades();
myUser.GetStats();
myUser.GetData();
```
You can also also chain these methods together
```
myUser.GetCars().GetLicenses().GetStats().GetData();
```

### 4. Iterate through the collection of Vehicles owned by the user.
```
foreach(UserProfile.Vehicle car in myUser.Cars)
{
    Console.WriteLine($"VIN: {car.VIN}");
    Console.WriteLine($"Condition: {car.Condition}");
    Console.WriteLine($"Model Type: {car.Type}");
}
```

## Example Usage - Find all online users

### 1. Pass your API Key
```
Configuration.AddAPIKey("YOUR_KEY");
```

### 2. Create a new instance of Statistics.OnlineUsers
```
Statistics.OnlineUsers onlineUsers = new Statistics.OnlineUsers();
```

### 3. Construct your GetData() call similar to that of the previous example
You can specify the number of rows to return in the collection, and how many to skip using the GetRows() and SkipRows() methods.
```
onlineUsers.GetRows(10).SkipRows(5).GetData();
```

### 4. Access the data
Indexers make it easy to find a specific user within the collection. You can search by LFS (Live For Speed) Username or simply the index of the collection:

```
string username = onlineUsers[0].Username;
string car = onlineUsers[0].Car;
int money = onlineUsers[0].Money;
```

```
string username = onlineUsers["user"].Username;
string car = onlineUsers["user"].Car;
int money = onlineUsers["user"].Money;
```
# Lets work together!
If you find any bugs or have suggestions as to how this library could be improved - drop me a message! Or even better, fork the code and send a pull request!

# Mentions
Uses [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) library for handling of JSON.
