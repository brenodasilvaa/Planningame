# 🍻 Happy Hours – Multiplayer Planning Poker Game

**Happy Hours** is a web-based multiplayer game designed to facilitate agile planning sessions using the Planning Poker technique. Set in a virtual bar environment, each player is represented by a beer glass around a central table, making the estimation process engaging and interactive.

## 🎮 Gameplay Overview

- **Session Creation**: Initiate a new game session and invite team members to join.
- **Estimation Process**: Each participant selects a number they believe corresponds to the effort required for a task.
- **Reveal Phase**: Once all votes are in, a central button becomes active. Upon activation, all selected values are displayed along with the average estimate.
- **Interactive Environment**: The bar-themed setting adds a fun twist to traditional planning meetings.

## 🛠️ Technologies Used

- **Frontend**: [React](https://reactjs.org/) with [Next.js](https://nextjs.org/)
- **Backend**: [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## 🚀 Getting Started

### Prerequisites

- **Node.js** (for frontend development)
- **.NET 8 SDK** (for backend development)

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/brenodasilvaa/Planningame.git
   cd Planningame
   ```

2. **Setup Frontend**:
   ```bash
   cd Front/planningame
   npm install
   npm run dev
   ```
   The frontend will be available at `http://localhost:3000`.

3. **Setup Backend**:
   ```bash
   cd ../../Api
   dotnet restore
   dotnet run
   ```
   The backend API will be running at `http://localhost:5000`.

## 🧪 Running Tests

1. Navigate to the `Tests` directory:
   ```bash
   cd Tests
   ```

2. Execute tests using the .NET CLI:
   ```bash
   dotnet test
   ```

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature/YourFeatureName
   ```
3. Commit your changes:
   ```bash
   git commit -m 'Add your feature'
   ```
4. Push to the branch:
   ```bash
   git push origin feature/YourFeatureName
   ```
5. Open a pull request.

Please ensure your code adheres to the project's coding standards and includes appropriate tests.

## 📧 Contact

For questions or support, please contact [brenodasilvaa](https://github.com/brenodasilvaa).

