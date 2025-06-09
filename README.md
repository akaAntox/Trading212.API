# Trading212 Public API (v0) Wrapper for .NET

This project is a .NET wrapper for the Trading212 Public API (v0), designed to simplify integration and interaction with Trading212's endpoints. It provides a clean, organized structure to manage live and demo environments, as well as facilitate API calls in a straightforward manner.

---

## WORK IN PROGRESS: Missing or incomplete features

- Missing methods:
   - PlaceEquityLimitOrderAsync
   - PlaceEquityMarketOrderAsync
   - PlaceEquityStopOrderAsync
   - PlaceEquityStopLimitOrderAsync
   - UpdatePieAsync
- Object models are currently basic. Need better object models for easier usage and data analysis

---

## Features

- Seamless integration with Trading212 Public API (v0).
- Switch easily between demo and live environments.
- Simplified access to API endpoints.

---

## Getting Started

### Prerequisites

- .NET 6.0 or later
- Access to Trading212 API (via API key)

### Installation

To use this wrapper in your .NET project, add it as a dependency using your preferred method:

#### Manual Reference:
1. Clone or download this repository.
2. Add the project to your solution and reference it in your application.

#### Setup secrets:
- Add your "ApiKey" secret

---

## Usage

### Initialization

1. **Create the API Client:**
   Use the `ApiClientFactory` to initialize the client.

   ```csharp
   var apiClient = ApiClientFactory.Create(isDemo: true);
   ```

2. **Call API Methods:**
   Interact with the API using the methods provided by `TradingApiClient`.

   ```csharp
   var exchanges = await apiClient.GetExchangesAsync();
   foreach (var exchange in exchanges)
   {
       Console.WriteLine(exchange);
   }
   ```

---

## Examples

### Fetching Exchanges
```csharp
var apiClient = ApiClientFactory.Create(isDemo: true);
var exchanges = await apiClient.GetExchangesAsync();

foreach (var exchange in exchanges)
{
    Console.WriteLine(exchange);
}
```

### Fetching Instruments
```csharp
var instruments = await apiClient.GetInstrumentsAsync();

foreach (var instrument in instruments)
{
    Console.WriteLine(instrument);
}
```

---

## References

- [Trading212 Public API Documentation](https://t212public-api-docs.redoc.ly/)

---

## Contact

For questions or feedback, feel free to contact me:

- **Email**: akaantoninox@gmail.com
- **GitHub**: [akaAntox](https://github.com/akaAntox)

