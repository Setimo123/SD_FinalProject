# UMECA Bulletin Board SystemThis is a [Next.js](https://nextjs.org) project bootstrapped with [`create-next-app`](https://nextjs.org/docs/app/api-reference/cli/create-next-app).



A modern, real-time bulletin board system built for displaying announcements and notices with an elegant carousel interface. This project was developed as part of the CpE 223/L Group Project.## Getting Started



## 📋 OverviewFirst, run the development server:



The UMECA Bulletin Board System is a Next.js-based web application that displays bulletins in an auto-scrolling carousel format. It features a vibrant gradient background, real-time clock, and seamless integration with a SQL Server database through a C# API bridge.```bash

npm run dev

## ✨ Features# or

yarn dev

- **Auto-Scrolling Carousel**: Bulletins automatically cycle through with smooth vertical transitions# or

- **Bulletin Overview**: Summary card showing all active bulletins at a glancepnpm dev

- **Real-Time Updates**: Live clock and date display# or

- **Responsive Design**: Optimized for full-screen displaybun dev

- **Elegant UI**: Modern gradient background with glass-morphism effects```

- **Database Integration**: SQL Server LocalDB backend via C# API

- **Publication Timestamps**: Each bulletin displays when it was publishedOpen [http://localhost:3000](http://localhost:3000) with your browser to see the result.



## 🛠️ Tech StackYou can start editing the page by modifying `app/page.tsx`. The page auto-updates as you edit the file.



### FrontendThis project uses [`next/font`](https://nextjs.org/docs/app/building-your-application/optimizing/fonts) to automatically optimize and load [Geist](https://vercel.com/font), a new font family for Vercel.

- **Framework**: Next.js 15.4.5 (React 19)

- **Language**: TypeScript## Learn More

- **Styling**: Tailwind CSS 4.0

- **UI Components**: Radix UITo learn more about Next.js, take a look at the following resources:

- **Carousel**: Embla Carousel with Autoplay

- **Date/Time**: Day.js- [Next.js Documentation](https://nextjs.org/docs) - learn about Next.js features and API.

- [Learn Next.js](https://nextjs.org/learn) - an interactive Next.js tutorial.

### Backend

- **Database**: SQL Server LocalDB (ConsultationDatabase)You can check out [the Next.js GitHub repository](https://github.com/vercel/next.js) - your feedback and contributions are welcome!

- **API Bridge**: C# .NET (BulletinApiServer.cs)

- **ORM**: ADO.NET / Entity Framework## Deploy on Vercel



## 📁 Project StructureThe easiest way to deploy your Next.js app is to use the [Vercel Platform](https://vercel.com/new?utm_medium=default-template&filter=next.js&utm_source=create-next-app&utm_campaign=create-next-app-readme) from the creators of Next.js.



```Check out our [Next.js deployment documentation](https://nextjs.org/docs/app/building-your-application/deploying) for more details.

antoni-main/
├── src/
│   ├── app/
│   │   ├── _components/          # Page-specific components
│   │   │   ├── bulletin.tsx      # Main carousel component
│   │   │   ├── timeclock.tsx     # Real-time clock display
│   │   │   └── currentDate.tsx   # Current date display
│   │   ├── api/
│   │   │   └── bulletin/
│   │   │       └── route.ts      # API route proxying to C# API
│   │   ├── layout.tsx            # Root layout with header
│   │   ├── page.tsx              # Home page
│   │   └── globals.css           # Global styles and theme
│   ├── components/
│   │   └── ui/                   # Reusable UI components
│   │       ├── button.tsx
│   │       ├── card.tsx
│   │       └── carousel.tsx
│   └── lib/
│       ├── db.ts                 # Database configuration
│       └── utils.ts              # Utility functions
├── public/
│   └── logo.png                  # UMECA logo
├── BulletinApiServer.cs          # C# API server
├── CSharp-API-Bridge.cs          # C# database bridge
└── Program.cs-example            # C# program template
```

## 🚀 Getting Started

### Prerequisites

- Node.js 20+ and npm
- SQL Server LocalDB or SQL Server Express
- .NET SDK (for C# API server)
- Git

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd antoni-main
   ```

2. **Install dependencies**
   ```bash
   npm install
   ```

3. **Configure environment variables**
   
   Create a `.env.local` file in the root directory:
   ```env
   NEXT_PUBLIC_BASE_URL=http://localhost:3000
   CS_API_URL=http://localhost:5000/api/bulletin
   ```

4. **Setup the database**
   
   - Ensure SQL Server LocalDB is installed and running
   - Database name: `ConsultationDatabase`
   - The database should have a `Bulletins` table with the following schema:
     ```sql
     CREATE TABLE Bulletins (
       Id INT PRIMARY KEY IDENTITY(1,1),
       Title NVARCHAR(255) NOT NULL,
       Author NVARCHAR(100),
       Content NVARCHAR(MAX) NOT NULL,
       Status INT DEFAULT 1,
       DatePublished DATETIME NOT NULL,
       FileCount INT DEFAULT 0,
       IsArchived BIT DEFAULT 0
     );
     ```

5. **Start the C# API Server**
   ```bash
   dotnet run BulletinApiServer.cs
   ```
   The API should run on `http://localhost:5000`

6. **Start the development server**
   ```bash
   npm run dev
   ```
   Open [http://localhost:3000](http://localhost:3000) in your browser

### Production Build

```bash
npm run build
npm start
```

## 🎨 Customization

### Changing the Gradient Background

Edit `src/app/globals.css` and `src/app/layout.tsx`:

```css
/* In globals.css */
--background: linear-gradient(115deg, #ff512f, #dd2476);
```

```tsx
/* In layout.tsx */
className="bg-[linear-gradient(115deg,_#ff512f,_#dd2476)]"
```

### Adjusting Carousel Speed

Edit `src/app/_components/bulletin.tsx`:

```typescript
const autoplayPlugin = React.useRef(
  Autoplay({ 
    delay: 5000, // Change delay in milliseconds
    stopOnInteraction: false,
  })
);
```

### Logo Customization

Replace `public/logo.png` with your institution's logo.

## 📊 Database Configuration

The application connects to SQL Server LocalDB through a C# API bridge. The connection settings are in `src/lib/db.ts`:

```typescript
const config = {
  server: 'localhost',
  database: 'ConsultationDatabase',
  options: {
    instanceName: 'MSSQLLocalDB',
    encrypt: false,
    trustServerCertificate: true,
  }
};
```

## 🔧 API Endpoints

### GET /api/bulletin
Fetches all active bulletins from the database.

**Response:**
```json
[
  {
    "Id": 1,
    "Title": "Announcement Title",
    "Content": "Bulletin content...",
    "DatePublished": "2025-11-03T14:30:00",
    "Status": 1
  }
]
```

### POST /api/bulletin
Creates a new bulletin entry.

**Request Body:**
```json
{
  "Title": "New Announcement",
  "Content": "Bulletin content...",
  "Author": "Admin",
  "Status": 1
}
```

## 👥 Contributors

**CpE 223/L Group Project**
- University of Mindanao - Electrical and Computer Engineering

## 📝 License

This project is developed for educational purposes as part of the CpE 223/L course requirements.

## 🐛 Troubleshooting

### Database Connection Issues
- Verify SQL Server LocalDB is installed and running
- Check connection string in `src/lib/db.ts`
- Ensure the database name matches your LocalDB instance

### C# API Not Starting
- Install .NET SDK
- Check if port 5000 is available
- Review BulletinApiServer.cs for configuration

### Carousel Not Auto-Playing
- Check browser console for errors
- Verify Embla Carousel dependencies are installed
- Ensure bulletins are being fetched successfully

## 📞 Support

For issues or questions regarding this project, please contact the development team or your course instructor.

---

**Built with ❤️ by the CpE 223/L Group**
